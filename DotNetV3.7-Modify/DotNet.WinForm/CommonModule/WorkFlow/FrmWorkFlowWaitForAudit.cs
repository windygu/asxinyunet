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
    /// Ȩ�޹���-����Ȩ�޴���
    ///		
    /// �޸ļ�¼
    /// 
    ///     2010.08.05 �汾��1.1 JiRiGaLa ����������롣
    ///     2007.07.18 �汾��1.0 JiRiGaLa Gredview��ʾ��
    /// 
    /// �汾��1.1
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

        #region private void DataTableAddColumn() �����ݱ��������һ��
        /// <summary>
        /// �����ݱ��������һ��
        /// </summary>
        //private void DataTableAddColumn()
        //{
        //    BaseInterfaceLogic.DataTableAddColumn(this.DTWorkFlowCurrent, "colSelected");
        //    // ���ñ�����
        //    DataColumn[] primaryKey = new DataColumn[] { this.DTWorkFlowCurrent.Columns[BaseUserEntity.FieldId] };
        //    this.DTWorkFlowCurrent.PrimaryKey = primaryKey;
        //}
        #endregion

        #region private void BindData() ����Ļ����
        /// <summary>
        /// ����Ļ����
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
            // �����ݱ��������һ��
            //this.DataTableAddColumn();
            this.grdWorkFlowCurrent.DataSource = this.DTWorkFlowCurrent.DefaultView;
            this.grdWorkFlowCurrent.Refresh();
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() ���ش���
        /// <summary>
        /// ���ش���
        /// </summary>
        public override void FormOnLoad()
        {
            // �����ʾ��ŵĴ�����
            this.DataGridViewOnLoad(grdWorkFlowCurrent);
            // ����Ļ����
            this.BindData();
            // �����������Ƿ����������Ȩ�ޣ�
            this.ucFreeWorkFlow.PermissionAuditing = this.UserInfo.IsAdministrator;
        }
        #endregion

        /// <summary>
        /// ���ÿؼ�״̬
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

        #region private string[] GetSelecteIds() ����ѱ�ѡ��Ĳ�����������
        /// <summary>
        /// ����ѱ�ѡ�����������
        /// </summary>
        /// <returns>��������</returns>
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
                // ������귱æ״̬��������ԭ�ȵ�״̬
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
                    // �������Ĭ��״̬��ԭ���Ĺ��״̬
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
            // ����ˢ�´���
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditCompleteClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditCompleteClick(string categoryId, string objectId)
        {
            // ����ˢ�´���
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditPassClick(string categoryId, string objectId, string sendToUserId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditPassClick(string categoryId, string objectId, string sendToUserId)
        {
            // ����ˢ�´���
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnTransmitClick(string categoryId, string objectId, string sendToUserId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnTransmitClick(string categoryId, string objectId, string sendToUserId)
        {
            // ����ˢ�´���
            this.FormOnLoad();
            return true;
        }
        
        private bool ucWorkFlowUser_BeforBtnAuditRejectClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditRejectClick(string categoryId, string objectId)
        {
            // ����ˢ�´���
            this.FormOnLoad();
            return true;
        }

        private bool ucWorkFlowUser_BeforBtnAuditQuashClick(string categoryId, string objectId)
        {
            return GetIds();
        }

        private bool ucWorkFlowUser_AfterBtnAuditQuashClick(string categoryId, string objectId)
        {
            // ����ˢ�´���
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