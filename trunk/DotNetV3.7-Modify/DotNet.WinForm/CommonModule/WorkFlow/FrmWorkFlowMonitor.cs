//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2011 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FormWorkFlowAuditDetail.cs
    /// 权限管理-管理权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2010.08.05 版本：1.1 JiRiGaLa 重新整理代码。
    ///     2007.07.18 版本：1.0 JiRiGaLa Gredview显示。
    /// 
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.05</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowMonitor : BaseForm
    {
        private DataTable DTWorkFlowCurrent = new DataTable(BaseWorkFlowCurrentEntity.TableName);

        private string entityId = string.Empty;
        /// <summary>
        /// 当前选中的记录主键
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }

        public FrmWorkFlowMonitor()
        {
            InitializeComponent();
        }

        #region private void GetItemDetails() 绑定下拉框数据
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void GetItemDetails()
        {
            // 绑定表单类别
            DataTable dataTable = DotNetService.Instance.WorkFlowProcessAdminService.GetBillTemplateDT(this.UserInfo);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbCategory.DataSource = dataTable;
            this.cmbCategory.DisplayMember = BaseNewsEntity.FieldTitle;
            this.cmbCategory.ValueMember = BaseNewsEntity.FieldId;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAuditDetail.Enabled = this.grdAuditDetail.RowCount > 0;
        }
        #endregion

        #region private void Search() 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        private void Search()
        {
            int recordCount = 0;
            string searchValue=this.txtSearch.Text.Trim();
            string billCategory = string.Empty;
            if (this.cmbCategory.SelectedValue != null)
            {
                // billCategory = this.cmbCategory.SelectedValue.ToString();
            }
            // 获取全部数据
            this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetMonitorDT(this.UserInfo);
            // 获取分页数据
            // this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetMonitorPagedDT(this.UserInfo, pager.PageSize, pager.PageIndex, out recordCount, billCategory, searchValue);
            foreach (DataRow dataRow in DTWorkFlowCurrent.Rows)
            {
                dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString());
            }
            pager.RecordCount = recordCount;
            pager.InitPageInfo();

            // 绑定屏幕数据
            this.grdAuditDetail.AutoGenerateColumns = false;
            this.grdAuditDetail.DataSource = this.DTWorkFlowCurrent.DefaultView;
            this.grdAuditDetail.Refresh();
            if (this.CurrentEntityId.Length > 0)
            {
                this.grdAuditDetail.FirstDisplayedScrollingRowIndex = BaseInterfaceLogic.GetRowIndex(this.DTWorkFlowCurrent, BaseStaffEntity.FieldId, this.CurrentEntityId);
            }
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetItemDetails();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdAuditDetail);
            //设置每页显示的数量
            pager.PageSize = 20;
            this.Search();
        }
        #endregion

        private void grdAuditDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAuditDetail.PerformClick();
        }

        private void btnAuditDetail_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdAuditDetail);
            if (dataRow != null)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity(dataRow);
                FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
                frmWorkFlowAuditDetail.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 弹出关闭对话框
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.Search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 获取全部列表
                this.Search();
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            this.Search();
        }
    }
}