//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

public partial class CommentList : BaseUserControl
{
    public string CategoryCode
    {
        get
        {
            return this.txtCategoryCode.Value;
        }
        set
        {
            this.txtCategoryCode.Value = value;
        }
    }

    public string ObjectId
    {
        get
        {
            return this.txtObjectId.Value;
        }
        set
        {
            this.txtObjectId.Value = value;
        }
    }

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (String.IsNullOrEmpty(this.CategoryCode))
        {
            if (Page.Request["CategoryCode"] != null)
            {
                this.CategoryCode = Page.Request["CategoryCode"].ToString();
            }
        }
        if (String.IsNullOrEmpty(this.ObjectId))
        {
            if (Page.Request["Id"] != null)
            {
                this.ObjectId = Page.Request["Id"].ToString();
            }
        }
    }
    #endregion

    public void GetList(String categoryCode, string objectId)
    {
        this.CategoryCode = categoryCode;
        this.ObjectId = objectId;
        this.GetList();
    }

    public void GetList()
    {
        try
        {
            // 读取参数
            this.GetParamters();
            // 获取列表
            this.DbHelper.Open();
            BaseCommentManager commentManager = new BaseCommentManager(this.UserCenterDbHelper, this.UserInfo);
            DataTable dataTable = commentManager.GetDataTableByCategory(this.CategoryCode, this.ObjectId);
            // 用过滤器进行过滤，只显示没删除的数据。
            BaseBusinessLogic.SetFilter(dataTable, BaseCommentEntity.FieldDeletionStateCode, "0");
            this.grdComment.DataSource = dataTable;
            this.grdComment.DataBind();
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
            this.DbHelper.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 应该是检查是否已登录
        if (!Page.IsPostBack)
        {
            this.GetList();
        }
    }

    #region private void DeleteMark(String id) 删除事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">主键</param>
    private void DeleteMark(String id)
    {
        int returnValue = 0;
        try
        {
            this.DbHelper.Open();
            BaseCommentManager commentManager = new BaseCommentManager(this.UserCenterDbHelper, this.UserInfo);
            // 只能删除自己的评论或者是管理员能删
            if (commentManager.GetProperty(id, BaseMessageEntity.FieldCreateUserId).Equals(this.UserInfo.Id) || this.UserInfo.IsAdministrator)
            {
                returnValue = commentManager.SetDeleted(id);
            }
        }
        catch (Exception exception)
        {
            this.LogException(exception);
            throw exception;
        }
        finally
        {
            this.DbHelper.Close();
            this.GetList();
        }
        // 是否显示提示信息
        if (BaseSystemInfo.ShowInformation)
        {
            if (returnValue > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "deleteSucceed", "<script>alert('提示信息：删除成功。');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "deleteFailure", "<script>alert('提示信息：删除失败。');</script>");
            }
        }
    }
    #endregion

    protected void grdComment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.grdComment.DataKeys[e.RowIndex].Value.ToString();
        // 删除事件
        this.DeleteMark(id);
    }

    protected void grdComment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = color;");
            TableCell tableCell = e.Row.Cells[this.grdComment.Columns.Count - 1];
            // 回车换行的功能
            DataRowView dataRowView = (DataRowView)e.Row.DataItem;
            string commentContent = dataRowView[BaseCommentEntity.FieldContents].ToString();
            e.Row.Cells[2].Text = commentContent.Replace("\r\n", "<br>");
            LinkButton btnLinkDelete = (LinkButton)tableCell.Controls[0];
            if (btnLinkDelete != null)
            {
                if (this.UserInfo.IsAdministrator || this.UserInfo.Id.Equals(dataRowView[BaseCommentEntity.FieldCreateUserId]))
                {
                    string script = "return confirm('您确认要删除吗？');";
                    btnLinkDelete.Attributes.Add("onclick", script);
                }
                else
                {
                    btnLinkDelete.Visible = false;
                }
            }
        }
    }
}