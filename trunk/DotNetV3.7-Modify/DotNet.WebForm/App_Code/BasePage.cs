//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// BasePage
/// 基础网页类
/// 
/// 修改纪录
/// 版本：2.6 2011.06.19    zgl         修改dbHelper，userCenterDbHelper的属性为protected->private
///                                     增加protected  string  GetSequence(string tableName) 根据表名，取得序列号
///	版本：2.5 2009.11.09    JiRiGaLa    public void Authorized(string permissionItemCode) 函数进行改进。
///	版本：2.4 2008.03.17    JiRiGaLa    登录程序改进为面向服务的登录。
///	版本：2.3 2008.03.07    JiRiGaLa    登录时页面重新导向功能改进。
///	版本：2.2 2007.12.09    JiRiGaLa    获得页面权限的 GetPermission 函数改进。
///	版本：2.1 2007.12.08    JiRiGaLa    单点登录功能完善。
///	版本：2.0 2006.02.02    JiRiGaLa    页面注释都修改好。
///	
/// 版本：2.5
/// <author>
///     
///		<name>JiRiGaLa</name>
///		<date>2009.11.09</date>
/// </author> 
/// </remarks>
public class BasePage : System.Web.UI.Page
{
    /// <summary>
    /// 访问权限
    /// </summary>
    protected bool permissionAccess = true; 
   
    /// <summary>
    /// 新增权限
    /// </summary>
    protected bool permissionAdd = true;    

    /// <summary>
    /// 编辑权限
    /// </summary>
    protected bool permissionEdit = true;   

    /// <summary>
    /// 删除权限
    /// </summary>
    protected bool permissionDelete = true;    

    /// <summary>
    /// 查询权限
    /// </summary>
    protected bool permissionSearch = true;   
 
    /// <summary>
    /// 导出权限
    /// </summary>
    protected bool permissionExport = true;   

    /// <summary>
    /// 每页显示多少条记录
    /// </summary>
    protected int PageSize = 30;

    protected string ImagesURL = ConfigurationManager.AppSettings["ImagesURL"];

    public static readonly object UserLock = new object();

    private IDbHelper dbHelper = null;

    /// <summary>
    /// 业务数据库部分
    /// </summary>
    protected IDbHelper DbHelper
    {
        get
        {
            if (dbHelper == null)
            {
                // 当前数据库连接对象
                dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType, BaseSystemInfo.BusinessDbConnection);
            }
            return dbHelper;
        }
    }

    private IDbHelper userCenterDbHelper = null;

    /// <summary>
    /// 用户中心数据库部分
    /// </summary>
    protected IDbHelper UserCenterDbHelper
    {
        get
        {
            if (userCenterDbHelper == null)
            {
                // 当前数据库连接对象
                userCenterDbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            return userCenterDbHelper;
        }
    }

    private IDbHelper workFlowDbHelper = null;

    /// <summary>
    /// 工作流数据库部分
    /// </summary>
    protected IDbHelper WorkFlowDbHelper
    {
        get
        {
            if (workFlowDbHelper == null)
            {
                // 当前数据库连接对象
                workFlowDbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            return workFlowDbHelper;
        }
    }

    private BaseUserInfo userInfo = null;                       // 当前操作员信息对象
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

    /// <summary>
    /// 单点登录唯一识别标识
    /// </summary>
    public string OpenId = string.Empty;


    #region protected override void OnInit(EventArgs e) 所有页面加载时默认运行的方法
    /// <summary>
    /// 所有页面加载时默认运行的方法
    /// </summary>
    /// <param name="e">系统默认参数</param>
    protected override void OnInit(EventArgs e)
    {
        // 当要用到主题皮肤切换时必须加上
        base.OnInit(e);
        this.GetParamterOpenId();
        if (!Utilities.UserIsLogOn())
        {
            if (this.OpenId.Length > 0)
            {
                this.UserInfo = Utilities.LogOn(this.OpenId);
                // 判断用户是否已登录
                // this.UserIsLogOn();
            }
        }
        // 统一的错误处理页面部分
        // this.Error += new EventHandler(BasePage_Error);
        Page_Load();
    }
    #endregion

    #region public void GetParamterOpenId() 所有页面基础类的，活得单点登录唯一识别标识的方法
    /// <summary>
    ///所有页面基础类的，活得单点登录唯一识别标识的方法
    /// </summary>
    public void GetParamterOpenId()
    {
        if (Page.Request["OpenId"] != null)
        {
            this.OpenId = Page.Request["OpenId"].ToString();
        }
    }
    #endregion

    protected void Page_Load()
    {
        string jsurl = "http://" + Request.Url.Authority + Request.ApplicationPath + "/JavaScript/jquery-1.4.2.min.js";
        Page.ClientScript.RegisterClientScriptInclude("jquery", jsurl);
        jsurl = "http://" + Request.Url.Authority + Request.ApplicationPath + "/JavaScript/jfloat.js";
        Page.ClientScript.RegisterClientScriptInclude("jfloat", jsurl);
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        this.UserCenterDbHelper.Close();
        this.DbHelper.Close();
    }

    public bool UserCanSystemAdmin()
    {
        // 1.先判断是否已登录
        if (Utilities.CheckIsLogOn())
        {
            // 2.有没有假劣药审核的权限？
            if (!IsAuthorized("SystemAdmin"))
            {
                //HttpContext.Current.Response.Redirect(Utilities.UserNotLogOn);
                Response.Write("<script>window.top.location.href='" + Utilities.UserNotLogOn + "'</script>");
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }


    #region protected void GetConfig() 读取一些基本配置信息
    /// <summary>
    /// 读取一些基本配置信息
    /// </summary>
    protected void GetConfig()
    {
    }
    #endregion

    public void Authorized(string permissionItemCode)
    {
        // 若没有相应的权限，那就跳转到没有权限的页面里
        if (!Utilities.UserIsLogOn() || !IsAuthorized(permissionItemCode))
        {
            HttpContext.Current.Response.Redirect(Utilities.AccessDenyPage + "?Code=" + permissionItemCode);
        }
    }

    #region public bool IsAuthorized(string permissionItemCode) 是否有相应的权限
    /// <summary>
    /// 是否有相应的权限
    /// </summary>
    /// <param name="permissionItemCode">权限编号</param>
    /// <returns>是否有权限</returns>
    public bool IsAuthorized(string permissionItemCode, string permissionItemName = null)
    {
        DotNetService dotNetService = new DotNetService();
        return dotNetService.PermissionService.IsAuthorizedByUser(this.UserInfo, this.UserInfo.Id, permissionItemCode, permissionItemName);
    }
    #endregion

    #region public bool IsModuleAuthorized(string moduleCode) 是否有相应的模块权限
    /// <summary>
    /// 是否有相应的模块权限
    /// </summary>
    /// <param name="moduleCode">模块编号</param>
    /// <returns>是否有权限</returns>
    public bool IsModuleAuthorized(string moduleCode)
    {
        if (this.UserInfo.IsAdministrator)
        {
            return true;
        }
        return BaseBusinessLogic.Exists(this.DTModule, BaseModuleEntity.FieldCode, moduleCode);
    }
    #endregion

    protected DataTable DTModule
    {
        get
        {
            // 判断是否有数据，若没数据自动读取一次
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["_DTModule"] == null)
            {
                // 这里进行了菜单优化，出错问题
                bool openDB = false;
                if (this.UserCenterDbHelper.GetDbConnection() == null)
                {
                    this.UserCenterDbHelper.Open();
                    openDB = true;
                }
                this.GetModuleDT();
                if (openDB)
                {
                    this.UserCenterDbHelper.Close();
                }
            }
            return Utilities.GetFromSession("_DTModule") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTModule", value);
        }
    }

    #region protected void GetModuleDT()
    /// <summary>
    /// 获模块列表
    /// </summary>
    protected void GetModuleDT()
    {
        lock (BasePage.UserLock)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["_DTModule"] == null)
            {
                // 这个是默认的系统表名称
                string tableName = "BaseModule";
                if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                {
                    tableName = BaseSystemInfo.SystemCode + "Module";
                }
                BaseModuleManager moduleManager = new BaseModuleManager(this.UserCenterDbHelper, this.UserInfo, tableName);
                if (this.UserInfo.IsAdministrator)
                {
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));
                    DTModule = moduleManager.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
                }
                else
                {
                    DTModule = moduleManager.GetDataTableByUser(this.UserInfo.Id);
                }
                // 按有效的模块进行过滤
                BaseBusinessLogic.SetFilter(DTModule, BaseModuleEntity.FieldEnabled, "1");
                BaseBusinessLogic.SetFilter(DTModule, BaseModuleEntity.FieldDeletionStateCode, "0");
                DTModule.DefaultView.Sort = BaseModuleEntity.FieldSortCode;
            }
        }
    }
    #endregion


    #region public void LogException(Exception exception) 记录异常信息
    /// <summary>
    /// 记录异常信息
    /// </summary>
    /// <param name="exception">异常信息实体</param>
    public void LogException(Exception exception)
    {
        BaseExceptionManager.LogException(this.UserCenterDbHelper, this.UserInfo, exception);
    }
    #endregion


    /// <summary>
    /// 取得序列号,主键为非自增时使用
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <returns>序列</returns>
    protected string GetSequence(string tableName)
    {
        string sequence = string.Empty;
        BaseSequenceManager manager = new BaseSequenceManager(this.UserCenterDbHelper, true);
        sequence = manager.GetSequence(tableName);
        return sequence;
    }

    //
    // 排序功能部分
    //

    public string SortExpression
    {
        get
        {
            if (ViewState["sortExpression"] == null)
            {
                ViewState["sortExpression"] = BaseBusinessLogic.FieldCreateOn;
            }
            return ViewState["sortExpression"].ToString();
        }
        set
        {
            ViewState["sortExpression"] = value;
        }
    }

    public string SortDire
    {
        get
        {
            if (ViewState["sortDire"] == null)
            {
                ViewState["sortDire"] = " DESC ";
            }
            return ViewState["sortDire"].ToString();
        }
        set
        {
            ViewState["sortDire"] = value;
        }
    }
}