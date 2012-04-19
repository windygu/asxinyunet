//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// UserCode
/// 用户工号查询
///
/// 修改记录
///
///		
///		2011.11.18 版本：1.0 张广梁   创建。
///
/// 版本：1.0
///
/// <author>
///		<name>张广梁</name>
///		<date>2011.11.18</date>
/// </author>
/// </remarks>
public partial class UserCode : BasePage
{
    /// <summary>
    /// 索引
    /// </summary>
    protected int itemIndex;

    /// <summary>
    /// 列数
    /// </summary>
    protected int columNum = 6;

    /// <summary>
    /// 行索引
    /// </summary>
    protected int rowIndex = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时的动作
            this.DoPageLoad();
        }
    }

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        // 读取参数
        try
        {
            this.UserCenterDbHelper.Open();
            this.GetOrganizeTree();
            // 获取用户列表
            this.DoSearch();
            this.txtSearch.Focus();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    #region private void GetOrganizeTree() 绑定下拉筐数据
    /// <summary>
    /// 绑定下拉筐数据
    /// </summary>
    private void GetOrganizeTree()
    {
        BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.UserCenterDbHelper, this.UserInfo);
        DataTable organizeTable = organizeManager.GetOrganizeTree();
        this.cmbDepartment.DataValueField = BaseOrganizeEntity.FieldId;
        this.cmbDepartment.DataTextField = BaseOrganizeEntity.FieldFullName;
        this.cmbDepartment.DataSource = organizeTable;
        this.cmbDepartment.DataBind();
        this.cmbDepartment.Items.Insert(0, new ListItem());
    }
    #endregion

    #region private void SetControlState() 设置控件状态
    /// <summary>
    /// 设置控件状态
    /// </summary>
    private void SetControlState()
    {
    }
    #endregion

    #region private void Search() 查询
    /// <summary>
    /// 查询
    /// </summary>
    private void Search()
    {
        try
        {
            this.DoSearch();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        // 是否显示提示信息
        if ((Utilities.ShowInformation) && (this.rpUserCode.Items.Count== 0))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "searchFailure", "<script>alert('提示信息： 未找到查询内容。');</script>");
        }
    }
    #endregion

    #region private void DoSearch() 查询
    /// <summary>
    /// 进行查询
    /// </summary>
    private void DoSearch()
    {
        string search = this.txtSearch.Text;
        BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
        string organizeId = this.cmbDepartment.SelectedValue;
        string searchValue = this.txtSearch.Text.Trim();
        DataTable dataTable = userManager.SearchByDepartment(organizeId, searchValue);
        this.rpUserCode.DataSource = dataTable;
        this.rpUserCode.DataBind();
        this.SetControlState();
        this.txtSearch.Focus();
    }
    #endregion

    protected void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Search();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // 进行查询
        this.Search();
    }

    protected void rpUserCode_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            itemIndex++;
            if ((itemIndex % columNum == 0))//是否换行 
            {
                rowIndex++;
                if (rowIndex % 2 == 0)
                {
                    e.Item.Controls.Add(new LiteralControl("</tr><tr class='tr-content'>"));
                }
                else { e.Item.Controls.Add(new LiteralControl("</tr><tr class='tr-toggle'>")); }
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)//在末尾补齐表格单元格 
        {
            string s = string.Empty;
            if ((itemIndex >= columNum) && ((itemIndex - 1) % columNum > 0))
            {
                for (int i = 0; i <= (columNum - (itemIndex - 1) % columNum); i++)
                {
                    s += "<td class='td-content'></td>";
                }
                e.Item.Controls.AddAt(0, new LiteralControl(s));
            }
        }
    }

    private DataTable DTUser
    {
        get
        {
            return Utilities.GetFromSession("_DTUser") as DataTable;
        }
        set
        {
            Utilities.AddSession("_DTUser", value);
        }
    }

}