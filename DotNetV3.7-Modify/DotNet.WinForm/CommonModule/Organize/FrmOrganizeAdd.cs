//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmOrganizeAdd.cs
    /// 组织机构管理-添加组织机构窗体
    ///		
    /// 修改记录
    ///     2011.10.24 版本：1.7 张广梁    增加ParentId和FullName属性，修改SaveEntity方法，适应FrmPermissionItemAdmin中的处理。
    ///     2010.10.21 版本：1.6 JiRiGaLa  部门类别进行优化。
    ///     2007.06.05 版本：1.5 JiRiGaLa  整理主键。
    ///     2007.05.30 版本：1.4 JiRiGaLa  删除移动的主键优化，提示信息优化，标准工程完成。
    ///     2007.05.30 版本：1.3 JiRiGaLa  整体整理主键
    ///     2007.05.17 版本：1.2 JiRiGaLa  增加了多国语言功能，调整了细节部分。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  组织机构添加功能页面编写。
    ///		
    /// 版本：1.7
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.21</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeAdd : BaseForm, IBaseOrganizeAddForm
    {
        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        private string fullName=string.Empty;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        /// <summary>
        /// 父节点主键
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.ucParent.SelectedId;
            }
            set
            {
                this.ucParent.SelectedId = value;
            }
        }

        /// <summary>
        /// 父节点全称
        /// </summary>
        public string ParentFullName
        {
            get
            {
                return this.ucParent.SelectedFullName;
            }
            set
            {
                this.ucParent.SelectedFullName = value;
            }
        }

        public FrmOrganizeAdd()
        {
            InitializeComponent();
        }

        public FrmOrganizeAdd(string id) : this()
        {
            this.EntityId = id;
        }

        public FrmOrganizeAdd(string parentId, string parentFullName) : this(string.Empty)
        {
            this.ParentId = parentId;
            this.ParentFullName = parentFullName;
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            DataTable dataTable = new DataTable(BaseItemDetailsEntity.TableName);
            dataTable = DotNetService.Instance.ItemDetailsService.GetDataTableByCode(UserInfo, "OrganizeCategory");
            // 添加一个空记录
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            // 绑定数据
            this.cmbCategory.DisplayMember  = BaseItemDetailsEntity.FieldItemName;
            this.cmbCategory.ValueMember    = BaseItemDetailsEntity.FieldItemCode;
            // this.cmbCategory.ValueMember = BaseItemDetailsEntity.FieldId;
            this.cmbCategory.DataSource     = dataTable.DefaultView;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 若不是系统管理员，不能添加跟节点
            this.lblParentReq.Visible = false;
            this.ucParent.AllowNull = true;
            if (!UserInfo.IsAdministrator)
            {
                this.lblParentReq.Visible = true;
                this.ucParent.AllowNull = false;
                this.ucParent.PermissionItemScopeCode = this.PermissionItemScopeCode;
            }
        }
        #endregion

        #region private void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 部门信息
            // this.DTOrganize = DotNetService.Instance.OrganizeService.Get(UserInfo, this.EntityId);
            // 绑定下拉筐数据
            this.BindItemDetails();
            // 显示内容
            //this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtCode.Focus();
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            if (this.lblParentReq.Visible)
            {
                if (String.IsNullOrEmpty(this.ucParent.SelectedId))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0282), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ucParent.Focus();
                    return false;
                }
            }

            this.txtFullName.Text = this.txtFullName.Text.TrimEnd();
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            //if (this.cmbCategory.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("分类不能为空。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.cmbCategory.Focus();
            //    return false;
            //}
            return returnValue;
        }
        #endregion

        #region private BaseOrganizeEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据,将实体类保存到数据表
        /// </summary>
        private BaseOrganizeEntity GetEntity()
        {
            BaseOrganizeEntity organizeEntity = new BaseOrganizeEntity();
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                organizeEntity.ParentId = null;
            }
            else
            {
                organizeEntity.ParentId = int.Parse(this.ucParent.SelectedId);
            }
            organizeEntity.Code = this.txtCode.Text;
            organizeEntity.FullName = this.txtFullName.Text;
            organizeEntity.Category = this.cmbCategory.SelectedValue.ToString();
            organizeEntity.OuterPhone = this.txtOuterPhone.Text;
            organizeEntity.InnerPhone = this.txtInnerPhone.Text;
            organizeEntity.Fax = this.txtFax.Text;
            organizeEntity.Postalcode = this.txtPostalcode.Text;
            organizeEntity.Address = this.txtAddress.Text;
            organizeEntity.Web = this.txtWeb.Text;
            organizeEntity.Enabled = this.chkEnabled.Checked ? 1:0;
            organizeEntity.IsInnerOrganize = this.chkIsInnerOrganize.Checked ? 1 : 0;
            organizeEntity.Description = this.txtDescription.Text;
            organizeEntity.DeletionStateCode = 0;
            return organizeEntity;
        }
        #endregion

        #region public override void SaveEntity(bool close) 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        private  bool SaveEntity(bool close)
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 转换数据
            BaseOrganizeEntity organizeEntity = this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId = DotNetService.Instance.OrganizeService.Add(UserInfo, organizeEntity, out statusCode, out statusMessage);
            this.FullName = this.txtFullName.Text;
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (this.Owner != null && !close)
                {
                    if (this.Owner is FrmOrganizeAdmin)
                    {
                        ((FrmOrganizeAdmin)this.Owner).FormOnLoad();
                    }
                }
                if (BaseSystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFullName.SelectAll();
                    this.txtFullName.Focus();
                }
                else
                {
                    // 是否编号重复了，提高友善性
                    if (statusCode == StatusCode.ErrorCodeExist.ToString())
                    {
                        this.txtCode.SelectAll();
                        this.txtCode.Focus();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region private void ClearForm() 清除窗体
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtFullName.Clear();
            this.txtCode.Clear();
            this.txtOuterPhone.Clear();
            this.txtInnerPhone.Clear();
            this.txtFax.Clear();
            this.txtPostalcode.Clear();
            this.txtAddress.Clear();
            this.txtWeb.Clear();
            this.txtDescription.Clear();
        }
        #endregion

        private void SaveData(bool close)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity(close))
                    {
                        if (close)
                        {
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearForm();
                            this.txtFullName.Focus();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 保存并关闭窗体
            this.SaveData(false);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 保存并关闭窗体
            this.SaveData(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}