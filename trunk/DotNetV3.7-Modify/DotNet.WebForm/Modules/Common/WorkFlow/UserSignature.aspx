<%@ Page Language="C#" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="DotNet.Utilities" %>
<%@ Import Namespace="DotNet.Business" %>

<script runat="server"> 

    private BaseUserInfo userInfo = null;
    /// <summary>
    /// 当前操作员信息对象
    /// </summary>                     
    public BaseUserInfo UserInfo
    {
        get
        {
            if (Session["UserInfo"] != null)
            {
                this.userInfo = (BaseUserInfo)Session["UserInfo"];
            }
            if (this.userInfo == null)
            {
                // 从 Session 读取 当前操作员信息
                if (Session["UserInfo"] == null)
                {
                    this.userInfo = new BaseUserInfo();
                    // 获得IP 地址
                    this.userInfo.Id = string.Empty;
                    this.userInfo.RealName = Context.Request.ServerVariables["REMOTE_ADDR"];
                    this.userInfo.UserName = Context.Request.ServerVariables["REMOTE_ADDR"];
                    this.userInfo.IPAddress = Context.Request.ServerVariables["REMOTE_ADDR"];
                    // 设置操作员类型，防止出现错误，因为不小心变成系统管理员就不好了
                    // if (this.userInfo.RoleId.Length == 0)
                    //{
                    //    this.userInfo.RoleId = DefaultRole.User.ToString();
                    //}
                }
            }
            return this.userInfo;
        }
        set
        {
            this.userInfo = value;
        }
    }

    private string userId = string.Empty;
    public string UserId
    {
        get
        {
            return this.userId;
        }
        set
        {
            this.userId = value;
        }
    }

    private string currentId = string.Empty;
    public string CurrentId
    {
        get
        {
            return this.currentId;
        }
        set
        {
            this.currentId = value;
        }
    }

    private string signature = string.Empty;
    public string Signature
    {
        get
        {
            return this.signature;
        }
        set
        {
            this.signature = value;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["Id"] != null)
        {
            this.CurrentId = Page.Request["Id"].ToString();
        }
        if (Page.Request["Signature"] != null)
        {
            this.Signature = Page.Request["Signature"].ToString();
        }
        if (Page.Request["UserId"] != null)
        {
            this.UserId = Page.Request["UserId"].ToString();
        }
    }
    #endregion

    /// <summary>
    /// 若当前用户的签名不存在了
    /// 被删除了,还需要优化以下
    /// </summary>
    /// <param name="fileId">签名文件主键</param>
    private void GetSignatureFile(string pictureId)
    {
        bool find = false;
        string commandText = "SELECT TOP 1 Contents FROM BaseFile WHERE Id=" + pictureId;
        IDbHelper dbHelper = new SqlHelper(BaseSystemInfo.UserCenterDbConnection);
        dbHelper.Open();
        IDataReader dataReader = dbHelper.ExecuteReader(commandText);
        if (dataReader.Read())
        {
            Response.BinaryWrite((byte[])dataReader["Contents"]);
            find = true;
        }
        dataReader.Close();

        if (!find)
        {
            commandText = "SELECT TOP 1 Contents FROM BaseFile WHERE Id=10000000";
            dataReader = dbHelper.ExecuteReader(commandText);
            if (dataReader.Read())
            {
                Response.BinaryWrite((byte[])dataReader["Contents"]);
            }
            dataReader.Close();
        }
        dbHelper.Close();
    }

    private void GetSignature(string userId)
    {
        string pictureId = string.Empty;
        if (!string.IsNullOrEmpty(userId))
        {
            ParameterService parameterService = new ParameterService();
            pictureId = parameterService.GetParameter(this.UserInfo, "User", userId, "UserSignature");
        }
        if (string.IsNullOrEmpty(pictureId))
        {
            pictureId = "10000000";
        }
        this.GetSignatureFile(pictureId);
    }

    private void GetSignatureByCurrentId()
    {
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
        BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
        // 通过当前的工作流主键,获得当前的审批流程主键
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.UserInfo);
        // 通过审批步骤,获取当前的用户
        // 再看当前用户,有审批通过否?再能确认是否审核通过
        // 当前是审核到了第几步了.是否有被退回情况等,需要确认.
        DataTable dt = null;
        string userId = string.Empty;
        if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditPass.ToString())
            || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.WaitForAudit.ToString()))
        {
            dt = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity);
        }
        else if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditComplete.ToString()))
        {
            dt = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity.Id, workFlowCurrentEntity.WorkFlowId.ToString());
        }
        if (dt != null)
        {
            dt.Columns.Remove("Id");
            dt.Columns["ActivityId"].ColumnName = "Id";
            BaseBusinessLogic.SetFilter(dt, "Id", null, true);
        }
        if (dt != null)
        {
            int userSignature = int.Parse(this.Signature);
            if (dt.Rows.Count >= userSignature)
            {
                userId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldAuditUserId].ToString();
            }
        }
        this.GetSignature(userId);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.GetParamters();
        if (!string.IsNullOrEmpty(this.UserId))
        {
            this.GetSignature(this.UserId);
            return;
        }
        else if (!string.IsNullOrEmpty(this.CurrentId) && !string.IsNullOrEmpty(this.Signature))
        {
            this.GetSignatureByCurrentId();
            return;
        }
        this.GetSignatureFile("10000000");      
    }
    
</script>
