//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , DotNet , Ltd .
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCFreeWorkFlowStatr.cs
    /// 工作流提交控件
    ///		
    /// 修改记录
    ///
    ///     2010.08.03 版本：1.3 JiRiGaLa 重新整理程序。
    ///     2007.08.10 版本：1.2 chenning 添加委托 完善提交逻辑。
    ///     2007.08.10 版本：1.0 JiRiGaLa 实现控件提交功能。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.08.03</date>
    /// </author> 
    /// </summary> 
    public partial class UCFreeWorkFlowStatr : UserControl
    {
        // ByUser按用户审核、ByRole按角色审核
        private string workFlowCategory = "ByRole";

        /// <summary>
        /// 审核流类别
        /// </summary>
        public string WorkFlowCategory
        {
            get
            {
                return workFlowCategory;
            }
            set
            {
                workFlowCategory = value;
            }
        }


        public string CheckPermissionItemCode  = String.Empty;   // 审批流程时，需要判断的操作权限

        public string CategoryId        = String.Empty; // 单据分类代码
        public string CategoryFullName  = String.Empty; // 单据分类名称
        public string ObjectId          = String.Empty; // 单据代码
        public string ObjectFullName    = String.Empty; // 单据名称

        // 转发给其他人 "提交" 按钮事件中挂接事件 并指定是否允许进行次操作
        public delegate bool ButtonSendToClickEventHandler(String categoryId, string objectId, string sendToUserId);
        public event ButtonSendToClickEventHandler BeforBtnSendToClick;
        public event ButtonSendToClickEventHandler AfterBtnSendToClick;

        // 输入有效性事件中挂接事件 并指定是否允许进行次操作
        public delegate bool OnCheckInputClickEventHandler();
        public event OnCheckInputClickEventHandler BeforCheckInputClick;

        public string DefaultUser = string.Empty;

        /// <summary>
        /// 只显示角色
        /// </summary>
        public bool ShowRoleOnly = true;

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        public UCFreeWorkFlowStatr()
        {
            InitializeComponent();
        }

        private string selectedId = string.Empty;

        /// <summary>
        /// 被选中的主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                if (!this.DesignMode)
                {
                    this.SelectedFullName = string.Empty;
                    this.selectedId = value;
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        if (this.WorkFlowCategory.Equals("ByUser"))
                        {
                            // 用户审核模式
                            BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(UserInfo, this.selectedId);
                            if (userEntity != null)
                            {
                                this.SelectedFullName = userEntity.RealName;
                                this.txtFullName.Text = userEntity.RealName;
                            }
                        }
                        else
                        {
                            // 角色审核模式
                            BaseRoleEntity roleEntity = DotNetService.Instance.RoleService.GetEntity(UserInfo, this.selectedId);
                            if (roleEntity != null)
                            {
                                this.SelectedFullName = roleEntity.RealName;
                                this.txtFullName.Text = roleEntity.RealName;
                            }
                        }
                    }
                    this.SetControlState();
                }
            }
        }

        private string[] selectedIds = null;    // 被选中的主键集
        /// <summary>
        /// 被选中的主键
        /// </summary>
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;
            }
        }

        private string[] setSelectIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectIds
        {
            get
            {
                return this.setSelectIds;
            }
            set
            {
                this.setSelectIds = value;
            }
        }

        private string selectedFullName = string.Empty;
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
                this.txtFullName.Text = value;
                this.SetControlState();
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect
        {
            get
            {
                return this.multiSelect;
            }
            set
            {
                this.multiSelect = value;
            }
        }

        private bool allowNull = false;
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
                this.SetControlState();
            }
        }

        private bool allowSelect = false;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
            }
        }

        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域列表
        /// </summary>
        public string PermissionItemScopeCode
        {
            get
            {
                return this.byPermissionCode;
            }
            set
            {
                this.byPermissionCode = value;
            }
        }

        private string[] removeIds = null;
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        public string[] RemoveIds
        {
            get
            {
                return this.removeIds;
            }
            set
            {
                this.removeIds = value;
            }
        }

        // 当选择的用户发生变化时
        public event BaseBusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
        }
        #endregion

        #region public void Init() 初始化工作流控件
        /// <summary>
        /// 初始化工作流控件
        /// </summary>
        /// <returns>单据当前工作流识别代码</returns>
        public void Init()
        {
            // 清除挂接的事件
            // this.BeforCheckInputClick = null;
            // this.BeforBtnSendToClick = null;
            // this.AfterBtnSendToClick = null;
            if (!string.IsNullOrEmpty(this.DefaultUser))
            {
                this.SelectedId = this.DefaultUser;
            }
        }
        #endregion

        private void SelectByUser()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmUserSelect";
            Form frmSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((IBaseSelectUserForm)frmSelect).AllowNull = this.AllowNull;
            ((IBaseSelectUserForm)frmSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;

            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((IBaseSelectUserForm)frmSelect).SelectedId;
                this.SelectedFullName = ((IBaseSelectUserForm)frmSelect).SelectedFullName;
                this.txtFullName.Text = ((IBaseSelectUserForm)frmSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
            }
        }

        private void SelectByRole()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleSelect";
            Form frmSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((IBaseSelectRoleForm)frmSelect).AllowNull = this.AllowNull;
            ((IBaseSelectRoleForm)frmSelect).PermissionItemScopeCode = this.PermissionItemScopeCode;

            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((IBaseSelectRoleForm)frmSelect).SelectedId;
                this.SelectedFullName = ((IBaseSelectRoleForm)frmSelect).SelectedFullName;
                this.txtFullName.Text = ((IBaseSelectRoleForm)frmSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.WorkFlowCategory.Equals("ByUser"))
            {
                this.SelectByUser();
            }
            else
            {
                this.SelectByRole();
            }
        }

        #region private bool CheckInput() 是否选择了角色
        /// <summary>
        /// 是否选择了角色
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool returnValue = true;
            if (this.BeforCheckInputClick != null)
            {
                returnValue = this.BeforCheckInputClick();
            }
            if (!returnValue)
            {
                return returnValue;
            }
            if (string.IsNullOrEmpty(this.SelectedId))
            {
                MessageBox.Show(AppMessage.MSG0277, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0278, this.txtFullName.Text), AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private bool SendTo() 提交单据、进入审批流程
        /// <summary>
        /// 提交单据、进入审批流程
        /// </summary>
        /// <returns>成功</returns>
        private bool SendTo()
        {
            bool returnValue = false;
            if (!string.IsNullOrEmpty(this.ObjectId) && !string.IsNullOrEmpty(this.CategoryId) && !string.IsNullOrEmpty(this.SelectedId))
            {
                string returnStatusCode = string.Empty;

                if (this.WorkFlowCategory.Equals("ByUser"))
                {
                    // DotNetService.Instance.WorkFlowCurrentService.AuditStatr(this.UserInfo, this.CategoryId, this.CategoryFullName, this.ObjectId, this.ObjectFullName, this.SelectedId, this.txtAuditIdea.Text, out returnStatusCode);
                }

                if (returnStatusCode == StatusCode.OK.ToString())
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        MessageBox.Show(AppMessage.MSG0279, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    returnValue = true;
                }
                else
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        MessageBox.Show(AppMessage.MSG0280, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    returnValue = false;
                }
            }
            return returnValue;
        }
        #endregion

        private void btnSendTo_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnSendToClick != null)
            {
                if (!this.BeforBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId))
                {
                    return;
                }
            }
            if (this.CheckInput())
            {
                // 提交单据、进入审批流程
                if (this.SendTo())
                {
                    if (this.AfterBtnSendToClick != null)
                    {
                        this.AfterBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId);
                    }
                }
            }
        }

        private void btnSendToBy_Click(object sender, EventArgs e)
        {
            // 提交前的检查工作
            if (this.BeforBtnSendToClick != null)
            {
                if (!this.BeforBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId))
                {
                    return;
                }
            }
            if (this.CheckInput())
            {
                // 提交单据、进入审批流程
                if (this.SendTo())
                {
                    if (this.AfterBtnSendToClick != null)
                    {
                        this.AfterBtnSendToClick(this.CategoryId, this.ObjectId, this.SelectedId);
                    }
                }
            }
        }
    }
}