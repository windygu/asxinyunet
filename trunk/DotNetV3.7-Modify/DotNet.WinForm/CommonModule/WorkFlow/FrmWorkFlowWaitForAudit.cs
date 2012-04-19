//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2011 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmMyWorkFlow.cs
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
    public partial class FrmWorkFlowWaitForAudit : BaseForm
    {
        DataTable DTWorkFlowCurrent = null;

        public FrmWorkFlowWaitForAudit()
        {
            InitializeComponent();
        }

        #region private void DataTableAddColumn() 往数据表里面添加一列
        /// <summary>
        /// 往数据表里面添加一列
        /// </summary>
        //private void DataTableAddColumn()
        //{
        //    BaseInterfaceLogic.DataTableAddColumn(this.DTWorkFlowCurrent, "colSelected");
        //    // 设置表主键
        //    DataColumn[] primaryKey = new DataColumn[] { this.DTWorkFlowCurrent.Columns[BaseUserEntity.FieldId] };
        //    this.DTWorkFlowCurrent.PrimaryKey = primaryKey;
        //}
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            this.grdWorkFlowCurrent.AutoGenerateColumns = false;
            this.DTWorkFlowCurrent = DotNetService.Instance.WorkFlowCurrentService.GetWaitForAudit(this.UserInfo);
            foreach (DataRow dataRow in DTWorkFlowCurrent.Rows)
            {
                dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus] = BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString());
            }
            this.DTWorkFlowCurrent.DefaultView.Sort = BaseWorkFlowCurrentEntity.FieldSortCode;
            // 往数据表里面添加一列
            //this.DataTableAddColumn();
            this.grdWorkFlowCurrent.DataSource = this.DTWorkFlowCurrent.DefaultView;
            this.grdWorkFlowCurrent.Refresh();
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdWorkFlowCurrent);
            // 绑定屏幕数据
            this.BindData();
            // 这里设置他是否有最终审核权限？
            this.ucFreeWorkFlow.PermissionAuditing = this.UserInfo.IsAdministrator;
        }
        #endregion

        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // this.btnAuditDetail.Enabled = this.grdAuditDetail.RowCount > 0;
        }

        private void grdAuditDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.btnAuditDetail.PerformClick();
        }

        private void btnAuditDetail_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdWorkFlowCurrent);
            if (dataRow != null)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity(dataRow);
                FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
                frmWorkFlowAuditDetail.Show();
            }
        }

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdWorkFlowCurrent, BaseWorkFlowCurrentEntity.FieldId, "colSelected", true);
        }
        #endregion

        private bool GetIds()
        {
            bool returnValue = false;
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdWorkFlowCurrent, "colSelected"))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.ucAutoWorkFlow.CurrentWorkFlowIds = this.GetSelecteIds();
                    this.ucFreeWorkFlow.CurrentWorkFlowIds = this.GetSelecteIds();
                    returnValue = true;
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
            return returnValue;
        }

        private bool ucAutoWorkFlow_BeforBtnAuditPassClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucAutoWorkFlow_AfterBtnAuditPassClick(string categoryId, string objectId)
        {
            // 重新刷新窗体
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditCompleteClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditCompleteClick(string categoryId, string objectId)
        {
            // 重新刷新窗体
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditPassClick(string categoryId, string objectId, string sendToUserId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditPassClick(string categoryId, string objectId, string sendToUserId)
        {
            // 重新刷新窗体
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnTransmitClick(string categoryId, string objectId, string sendToUserId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnTransmitClick(string categoryId, string objectId, string sendToUserId)
        {
            // 重新刷新窗体
            this.FormOnLoad();
            return true;
        }
        
        private bool ucWorkFlowUser_BeforBtnAuditRejectClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditRejectClick(string categoryId, string objectId)
        {
            // 重新刷新窗体
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditQuashClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditQuashClick(string categoryId, string objectId)
        {
            // 重新刷新窗体
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditDetailClick(string categoryId, string objectId)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdWorkFlowCurrent);
            if (dataRow != null)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity(dataRow);
                FrmWorkFlowAuditDetail frmWorkFlowAuditDetail = new FrmWorkFlowAuditDetail(workFlowCurrentEntity.CategoryCode, workFlowCurrentEntity.ObjectId);
                frmWorkFlowAuditDetail.Show();
            }
            return false;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbByUser.Checked)
            {
                this.ucFreeWorkFlow.WorkFlowCategory = "ByUser";
            }
            else
            {
                this.ucFreeWorkFlow.WorkFlowCategory = "ByRole";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}