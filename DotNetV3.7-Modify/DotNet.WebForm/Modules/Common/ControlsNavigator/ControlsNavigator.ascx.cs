//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

// TODO: 吉日嘎拉派发任务50元 20120407, 最后一页全删除后，下面显示的分页不正确，需要改进一下

/// <summary>
/// 分页控件 
/// </summary>
public partial class ControlsNavigator : System.Web.UI.UserControl
{
    /// <summary>
    /// 页数
    /// </summary>
    public int PageCount
    {
        get
        {
            if (pageSize == 0)
            {
                return 0;
            }
            double pageCount = (double)this.RowCount / this.pageSize;
            return (int)Math.Ceiling(pageCount);
        }
    }

    /// <summary>
    /// 记录数
    /// </summary>
    public int RowCount
    {
        get
        {
            return int.Parse(this.txtRowCount.Value);
        }
        set
        {
            this.txtRowCount.Value = value.ToString();
        }
    }

    private bool allowPaging = false;
    /// <summary>
    /// 是否进行分页
    /// </summary>
    public bool AllowPaging
    {
        get
        {
            return this.allowPaging;
        }
        set
        {
            this.allowPaging = value;
        }
    }

    private int pageIndex = 0;
    /// <summary>
    /// 当前第几页
    /// </summary>
    public int PageIndex
    {
        get
        {
            return int.Parse(this.txtPageIndex.Value);
        }
        set
        {
            if (value > this.PageCount)
            {
                this.txtPageIndex.Value = this.PageCount.ToString();
            }
            else
            {
                this.txtPageIndex.Value = value.ToString();
            }
        }
    }

    int pageSize = 20;
    /// <summary>
    /// 每页显示几条数据
    /// </summary>
    public int PageSize
    {
        get
        {
            string perPage = this.cmbPerPage.SelectedValue;
            if (perPage.Length > 0)
            {
                pageSize = int.Parse(perPage);
            }
            return pageSize;
        }
        set
        {
            pageSize = value;
            this.cmbPerPage.SelectedValue = pageSize.ToString();
        }
    }

    public void Initialize()
    {
        if (this.cmbPerPage != null && this.cmbPerPage.Items.Count > 0)
        {
            this.cmbPerPage.SelectedIndex = 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region private void SetControlState();
    /// <summary>
    /// 设置按钮的状态
    /// </summary>
    private void SetControlState()
    {
        // 在中间的页面时
        this.lbtnFirst.Enabled = true;
        this.lbtnPrevious.Enabled = true;
        this.lbtnNext.Enabled = true;
        this.lbtnLast.Enabled = true;
        // 第一页时候
        if (this.PageIndex == 0)
        {
            this.lbtnFirst.Enabled = false;
            this.lbtnPrevious.Enabled = false;
            this.lbtnNext.Enabled = true;
            this.lbtnLast.Enabled = true;
        }
        // 第后页时候
        if (this.PageIndex == this.PageCount - 1)
        {
            this.lbtnFirst.Enabled = true;
            this.lbtnPrevious.Enabled = true;
            this.lbtnNext.Enabled = false;
            this.lbtnLast.Enabled = false;
        }
        // 只有1页或者没内容时
        if (this.PageCount < 2)
        {
            this.lbtnFirst.Enabled = false;
            this.lbtnPrevious.Enabled = false;
            this.lbtnNext.Enabled = false;
            this.lbtnLast.Enabled = false;
        }
        // 当前页面的信息
        if (this.AllowPaging)
        {
        }
        this.lblPageIndex.Text = this.PageCount > 0 ? (this.PageIndex + 1).ToString() : "0";
        this.lblPageCount.Text = this.PageCount.ToString();
        this.lblRowCount.Text = this.RowCount.ToString();
    }
    #endregion

    #region public void BindData(GridView gridView, DataTable dataTable)
    /// <summary>
    /// 页面不存在添加功能
    /// </summary>
    /// <param name="gridView">当前Grid</param>
    /// <param name="dataTable">数据源</param>
    /// <param name="e">事件</param>
    public void BindData(GridView gridView, DataTable dataTable)
    {
        // 绑定数据
        PageChangeEventArgs e = new PageChangeEventArgs();
        e.Action = "BindData";
        this.BindData(gridView, dataTable, e);
    }
    #endregion

    #region public void BindData(GridView gridView, DataTable dataTable, PageChangeEventArgs e)
    /// <summary>
    /// 页面不存在添加功能
    /// </summary>
    /// <param name="gridView">当前Grid</param>
    /// <param name="dataTable">数据源</param>
    /// <param name="e">事件</param>
    public void BindData(GridView gridView, DataTable dataTable, PageChangeEventArgs e)
    {
        // 计算页面数
        if (this.RowCount == 0)
        {
            this.RowCount = dataTable.Rows.Count;
        }
        if ((!Page.IsPostBack) || (e.Action.Equals("BindData")))
        {
            this.BindGoPage(this.PageCount);
        }
        gridView.DataSource = dataTable;
        // 设置每页显示多少
        gridView.PageSize = this.PageSize;
        // 页数不够了，进行调整
        if (gridView.PageIndex >= this.PageCount)
        {
            gridView.PageIndex = this.PageCount == 0 ? 0 : this.PageCount - 1;
        }
        else
        {
            gridView.PageIndex = this.PageIndex;
        }
        gridView.DataBind();
        // 设置按钮的状态
        this.SetControlState();
    }
    #endregion

    /// <summary>
    /// 总共有几页的设置
    /// </summary>
    /// <param name="pageCount">页数</param>
    private void BindGoPage(int pageCount)
    {
        // 这里是为了优化超级多的数据时的处理方法
        int step = 1;
        if (pageCount >= 200 && pageCount < 500)
        {
            step = 5;
        }
        else if (pageCount>=500 && pageCount < 1000)
        {
            step = 10;
        }
        else if (pageCount >=1000 && pageCount< 5000)
        {
            step = 25;
        }
        else if (pageCount >=5000 && pageCount<10000)
        {
            step = 50;
        }
        else if (pageCount >= 10000)
        {
            step = 1000;
        }
        
        this.cmbGoPage.Items.Clear();
        for (int i = 1; i < pageCount + step; i += step)
        {
            if (step != 1 && i != 1)
            {
                this.cmbGoPage.Items.Add((i-1).ToString());
            }
            else
            {
                this.cmbGoPage.Items.Add(i.ToString());
            }
        }
    }

    protected void cmbGoPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        OnPageChange(new PageChangeEventArgs(sender, "GoPage"));
    }

    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
        OnPageChange(new PageChangeEventArgs(sender, "First"));
    }

    protected void lbtnPrevious_Click(object sender, EventArgs e)
    {
        OnPageChange(new PageChangeEventArgs(sender, "Previous"));
    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        OnPageChange(new PageChangeEventArgs(sender, "Last"));
    }

    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        OnPageChange(new PageChangeEventArgs(sender, "Next"));
    }

    protected void cmbPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        OnPageChange(new PageChangeEventArgs(sender, "PageSizeChanged"));
    }

    public event PageChangeHandler PageChange;

    protected virtual void OnPageChange(PageChangeEventArgs e)
    {
        switch (e.Action)
        {
            case "":
            case "Search":
            case "Sorting":
            case "RowEditing":
            case "RowCancelingEdit":
            case "RowUpdating":
            case "Delete":
            case "Refresh":
                break;
            case "PageLoad":
            case "BindData":
            case "First":
            case "PageSizeChanged":
                this.PageIndex = 0;
                this.BindGoPage(PageCount);
                break;
            case "Previous":
                this.PageIndex--;
                break;
            case "Next":
                this.PageIndex++;
                break;
            case "Last":
                this.PageIndex = this.PageCount - 1;
                break;
            case "GoPage":
                this.PageIndex = int.Parse(this.cmbGoPage.SelectedValue) - 1;
                break;
            default:
                this.PageIndex = 0;
                break;
        }
        if (PageChange != null)
        {

            PageChange(this, e);
        }
    }
}

public class PageChangeEventArgs : EventArgs
{
    private string action = string.Empty;
    public string Action
    {
        get
        {
            return this.action;
        }
        set
        {
            this.action = value;
        }
    }

    public PageChangeEventArgs()
    {
    }

    public PageChangeEventArgs(object sender, string paramAction)
    {
        this.Action = paramAction;

    }
}

/// <summary>
/// 自定义翻页控件的页码委托
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
public delegate void PageChangeHandler(object sender, PageChangeEventArgs e);