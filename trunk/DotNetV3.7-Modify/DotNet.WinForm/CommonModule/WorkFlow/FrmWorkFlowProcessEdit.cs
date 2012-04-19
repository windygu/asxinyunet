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
    /// FormWorkFlowEdit.cs
    /// 工作流管理-编辑工作流窗体
    ///		
    /// 修改记录
    ///
    ///     2007.06.26 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.06.26 版本：1.0 JiRiGaLa  工作流编辑功能页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.26</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowProcessEdit : BaseForm
    {
        public BaseWorkFlowProcessEntity WorkFlowProcessEntity = new BaseWorkFlowProcessEntity();
        
        public FrmWorkFlowProcessEdit()
        {
            InitializeComponent();
        }

        #region public FormWorkFlowEdit(String id): this()
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">工作流代码</param>
        public FrmWorkFlowProcessEdit(String id) : this()        
        {
            this.EntityId = id;            
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 从数据权限读取类属性
            if (this.WorkFlowProcessEntity.Id > 0)
            {
                this.ucOrganize.SelectedId = this.WorkFlowProcessEntity.OrganizeId.ToString();
                this.txtCode.Text = this.WorkFlowProcessEntity.Code;
                this.txtFullName.Text = this.WorkFlowProcessEntity.FullName;
                this.chkEnabled.Checked = this.WorkFlowProcessEntity.Enabled == 1;
                this.txtDescription.Text = this.WorkFlowProcessEntity.Description;
                if (!string.IsNullOrEmpty(WorkFlowProcessEntity.CategoryCode))
                {
                    this.cmbWorkFlowCategory.SelectedValue = WorkFlowProcessEntity.CategoryCode;
                }
                // 设置焦点
                this.ActiveControl = this.txtFullName;
                this.txtFullName.Focus();
            }
            else
            {
                // 这里需要进行判断，数据是否被其他人已经删除
                MessageBox.Show(AppMessage.MSG0005, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "WorkFlowCategories");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbWorkFlowCategory.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbWorkFlowCategory.ValueMember = BaseItemDetailsEntity.FieldItemValue;
            this.cmbWorkFlowCategory.DataSource = dataTable.DefaultView;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 获取分类列表
            this.BindItemDetails();
            // 实体信息
            this.WorkFlowProcessEntity = DotNetService.Instance.WorkFlowProcessAdminService.GetEntity(this.UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private void GetEntity() 转换数据，将表单保存到实体类
        /// <summary>
        /// 转换数据，将表单保存到实体类
        /// </summary>
        private void GetEntity()
        {
            this.WorkFlowProcessEntity.OrganizeId = this.ucOrganize.SelectedId;
            this.WorkFlowProcessEntity.Code = this.txtCode.Text;
            this.WorkFlowProcessEntity.FullName = this.txtFullName.Text;
            this.WorkFlowProcessEntity.CategoryCode = this.cmbWorkFlowCategory.SelectedValue.ToString();
            this.WorkFlowProcessEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            this.WorkFlowProcessEntity.Description = this.txtDescription.Text;
        }
        #endregion

        #region public override bool SaveEntity() 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            // 调用接口方式实现
            DotNetService.Instance.WorkFlowProcessAdminService.Update(UserInfo, this.WorkFlowProcessEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
            }
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        // 关闭窗口
                        this.Close();
                    }
                }
                catch (Exception exception)
                {
                    // 在本地记录异常
                    this.ProcessException(exception);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}