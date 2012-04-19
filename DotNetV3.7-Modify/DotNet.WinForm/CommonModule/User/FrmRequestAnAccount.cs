//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{    
    using DotNet.Business;
    using DotNet.Utilities;    

    /// <summary>
    /// FrmRequestAnAccount
    /// 申请用户帐号。
    /// 
    /// 修改纪录
    /// 
    ///     2010.08.07 版本：1.3 JiRiGaLa 利用周末休息时间，把帐户申请功能重新仔细整理一下，做得铜墙铁臂的小程序。
    ///     2008.10.01 版本：1.2 JiRiGaLa 重新定位账号申请。
    ///     2008.04.17 版本：1.1 JiRiGaLa 主键整理。
    ///     2007.07.03 版本：1.0 JiRiGaLa 主键编辑。
    /// 
    /// 版本：1.3
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.07</date>
    /// </author>
    public partial class FrmRequestAnAccount : BaseForm
    {
        public new string EntityId = string.Empty;

        /// <summary>
        /// 系统默认密码
        /// </summary>
        string DefaultPassword = UserConfigHelper.GetValue("DefaultPassword");
        
        public FrmRequestAnAccount()
        {
            InitializeComponent();
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定性别数据
            DataTable dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "Gender");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbGender.DisplayMember = BaseItemDetailsEntity.FieldItemName;
            this.cmbGender.ValueMember = BaseItemDetailsEntity.FieldItemCode;
            this.cmbGender.DataSource = dataTable.DefaultView;

            // 绑定类型数据
            dataTable = DotNetService.Instance.UserService.GetRoleDT(this.UserInfo);
            dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cmbRole.DisplayMember = BaseRoleEntity.FieldRealName;
            this.cmbRole.ValueMember = BaseRoleEntity.FieldId;
            this.cmbRole.DataSource = dataTable.DefaultView;
            
            // 默认是本公司的，本部门的员工的用户帐户，为了提高友善性，一般是帮自己部门的人申请帐号
            this.ucCompany.SelectedId = this.UserInfo.CompanyId;
            this.ucCompany.SelectedFullName = this.UserInfo.CompanyName;
            this.ucDepartment.SelectedId = this.UserInfo.DepartmentId;
            this.ucDepartment.SelectedFullName = this.UserInfo.DepartmentName;
            this.ucWorkgroup.SelectedId = this.UserInfo.WorkgroupId;
            this.ucWorkgroup.SelectedFullName = this.UserInfo.WorkgroupName;
            // 默认打开的公司
            this.ucDepartment.OpenId = UserInfo.CompanyId;
            this.ucWorkgroup.OpenId = UserInfo.DepartmentId;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.ucCompany.AllowNull = false;
            this.ucCompany.CanEdit = false;
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.CanEdit = false;
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.CanEdit = false;
            // 当前用户是否系统管理员？
            this.chkEnabled.Enabled = this.UserInfo.IsAdministrator;
            // 密码强度检查
            this.lblPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            this.lblConfirmPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;

            // 只有已登录的才可以反复申请用户
            this.rbtnUserInput.Visible = BaseSystemInfo.UserIsLogOn;
            this.rbtnDefaultPassword.Visible = BaseSystemInfo.UserIsLogOn;
            this.rbtnUserNamePassword.Visible = BaseSystemInfo.UserIsLogOn;
            this.chkClose.Enabled = BaseSystemInfo.UserIsLogOn;

            this.ActiveControl = this.txtUserName;
            this.txtUserName.Focus();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 绑定下拉筐数据
            this.BindItemDetails();
        }
        #endregion

        private void rbtnUserInput_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnUserInput.Checked)
            {
                this.txtPassword.Text = string.Empty;
                this.txtConfirmPassword.Text = string.Empty;
            }
        }

        private void rbtnDefaultPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnDefaultPassword.Checked)
            {
                this.txtPassword.Text = this.DefaultPassword;
                this.txtConfirmPassword.Text = this.DefaultPassword;
            }
        }

        private void rbtnUserNamePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnUserNamePassword.Checked)
            {
                this.txtPassword.Text = this.txtUserName.Text;
                this.txtConfirmPassword.Text = this.txtUserName.Text;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                return;
            }

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldUserName, this.txtUserName.Text));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));

            bool exists = DotNetService.Instance.UserService.Exists(this.UserInfo, parameters);
            if (exists)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUserName.SelectAll();
                this.txtUserName.Focus();
                return;
            }
            if (this.rbtnDefaultPassword.Checked)
            {
                this.txtPassword.Text = this.DefaultPassword;
                this.txtConfirmPassword.Text = this.DefaultPassword;
            }
            else if (this.rbtnUserNamePassword.Checked)
            {
                this.txtPassword.Text = this.txtUserName.Text;
                this.txtConfirmPassword.Text = this.txtUserName.Text;
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.Text))
            {
                return;
            }
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, this.txtCode.Text));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
            bool exists = DotNetService.Instance.UserService.Exists(this.UserInfo, parameters);
            if (exists)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG8900), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCode.SelectAll();
                this.txtCode.Focus();
                return;
            }
        }

        private void SetCompany(string companyId)
        {
            // 设置部门与公司的联动功能
            this.ucDepartment.OpenId = companyId;
        }

        private void SetDepartment(string departmentId)
        {
            // 设置部门与公司的联动功能
            this.ucWorkgroup.OpenId = departmentId;
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.txtUserName.Text = this.txtUserName.Text.TrimEnd();
            if (!BaseCheckInput.CheckEmpty(this.txtUserName, AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0232)))
            {
                return false;
            }
            this.txtRealName.Text = this.txtRealName.Text.TrimEnd();
            if (!BaseCheckInput.CheckEmpty(this.txtRealName, AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0233)))
            {
                return false;
            }
            if (!string.IsNullOrEmpty(this.txtEmail.Text))
            {
                if (!BaseCheckInput.CheckEmail(this.txtEmail, AppMessage.MSG0234))
                {
                    return false;
                }
            }
            if (this.txtConfirmPassword.Text != this.txtPassword.Text)
            {
                MessageBox.Show(AppMessage.MSG0231, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPassword.Clear();
                this.txtConfirmPassword.Clear();
                this.txtPassword.Focus();
                return false;
            }
            if (this.ucCompany.SelectedFullName.Length == 0)
            {
                MessageBox.Show(AppMessage.MSG0229, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucCompany.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseUserEntity GetEntity()
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns>用户实体</returns>
        private BaseUserEntity GetEntity()
        {
            BaseUserEntity userEntity = new BaseUserEntity();
            if (this.cmbRole.SelectedValue == null || this.cmbRole.SelectedValue.ToString().Length == 0)
            {
                userEntity.RoleId = null;
            }
            else
            {
                userEntity.RoleId = this.cmbRole.SelectedValue.ToString();
            }
            // 获取用户数据
            userEntity.UserName = this.txtUserName.Text;
            userEntity.RealName = this.txtRealName.Text;
            userEntity.QuickQuery = StringUtil.GetPinyin(userEntity.RealName);
            if (this.cmbGender.SelectedValue != null)
            {
                userEntity.Gender = this.cmbGender.Text;
            }
            userEntity.Code = this.txtCode.Text;
            userEntity.Email = this.txtEmail.Text;
            userEntity.Mobile = this.txtMobile.Text;
            userEntity.Telephone = this.txtTelephone.Text;
            userEntity.UserPassword = this.txtPassword.Text;
            // 安全交易密码、安全通讯密码
            userEntity.CommunicationPassword = this.txtPassword.Text;
            if (string.IsNullOrEmpty(this.ucCompany.SelectedId))
            {
                userEntity.CompanyId = null;
                userEntity.CompanyName = null;
            }
            else
            {
                userEntity.CompanyId = this.ucCompany.SelectedId;
                userEntity.CompanyName = this.ucCompany.SelectedFullName;
            }
            if (string.IsNullOrEmpty(this.ucDepartment.SelectedId))
            {
                userEntity.DepartmentId = null;
                userEntity.DepartmentName = null;
            }
            else
            {
                userEntity.DepartmentId = this.ucDepartment.SelectedId;
                userEntity.DepartmentName = this.ucDepartment.SelectedFullName;
            }
            if (string.IsNullOrEmpty(this.ucWorkgroup.SelectedId))
            {
                userEntity.WorkgroupId = null;
                userEntity.WorkgroupName = null;
            }
            else
            {
                userEntity.WorkgroupId = this.ucWorkgroup.SelectedId;
                userEntity.WorkgroupName = this.ucWorkgroup.SelectedFullName;
            }
            userEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            // 应该是在待审核状态
            if (userEntity.Enabled == 0)
            {
                userEntity.AuditStatus = AuditStatus.WaitForAudit.ToString();
            }
            userEntity.Description = this.txtDescription.Text;
            return userEntity;
        }
        #endregion

        #region private bool RequestAnAccount() 申请帐号
        /// <summary>
        /// 申请帐号
        /// </summary>
        /// <returns>保存成功</returns>
        private bool RequestAnAccount()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            BaseUserEntity userEntity = this.GetEntity();
            this.EntityId = DotNetService.Instance.UserService.AddUser(this.UserInfo, userEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 没审核通过的，才可以有提示信息
                if (BaseSystemInfo.ShowInformation && !this.chkEnabled.Checked)
                {
                    // 这里应该判断，申请帐号是否需要进行审核，若需要审核提示等待审核，否则直接提示成功信息。
                    // 添加成功，进行提示
                    MessageBox.Show(AppMessage.MSG0235, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
            }
            else
            {
                // 是否用户名重复了，提高友善性
                if (statusCode == StatusCode.ErrorUserExist.ToString())
                {
                    this.txtUserName.SelectAll();
                    this.txtUserName.Focus();
                }
                else if (statusCode == StatusCode.ErrorUserExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region private void ClearForm()
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtUserName.Text = string.Empty;
            this.txtRealName.Text = string.Empty;
            this.txtCode.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtUserName.Focus();
        }
        #endregion

        private void btnRequestAnAccount_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 申请帐号
                    if (this.RequestAnAccount())
                    {
                        if (this.chkClose.Checked)
                        {
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearForm();
                        }
                    }
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}