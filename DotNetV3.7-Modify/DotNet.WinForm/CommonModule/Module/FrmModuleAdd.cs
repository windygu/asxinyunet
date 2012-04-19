//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Utilities;
    using DotNet.Business;
    

    /// <summary>
    /// FrmModuleMultiSelect.cs
    /// 权限管理-选择权限窗体
    ///		
    /// 修改记录
    ///     2011.11.15 版本：1.5 张广梁    完善对FrmModuleAdmin的刷新。
    ///     2011.10.24 版本：1.4 张广梁    增加“添加”和“保存”的区别。
    ///     2011.10.24 版本：1.3 张广梁    增加ParentId和FullName属性，修改SaveEntity方法，适应FrmModuleAdmin中的处理。
    ///     2010.04.07 版本：1.2 JiRiGaLa  改进为面向实体对象。
    ///     2007.05.14 版本：1.1 JiRiGaLa  改进CheckInput()，SaveEntity()。
    ///     2007.05.10 版本：1.0 JiRiGaLa  添加功能页面编写。
    ///		
    /// 版本：1.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.10</date>
    /// </author> 
    /// </summary>
    public partial class FrmModuleAdd : BaseForm
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        private string fullName;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        /// <summary>
        /// 父模块Id
        /// </summary>
        private string parentId;

        /// <summary>
        /// /// <summary>
        /// 父模块Id
        /// </summary>
        /// </summary>
        public string ParentID
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }

        public FrmModuleAdd()
        {
            InitializeComponent();
        }

        #region public FrmModuleAdd(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmModuleAdd(string id): this()
        {
            this.EntityId = id;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            if (!UserInfo.IsAdministrator)
            {
            }
        }
        #endregion

        #region public FrmModuleAdd(string moduleId, string moduleFullName): this(string.Empty)
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="moduleId">模块主键</param>
        /// <param name="moduleFullName">模块名称</param>
        public FrmModuleAdd(string moduleId, string moduleFullName) : this(string.Empty)
        {
            this.ucParent.SelectedId = moduleId;
            this.ucParent.SelectedFullName = moduleFullName;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            /*
            BaseModuleEntity moduleEntity = new BaseModuleEntity(this.DTModule);
            // 将类转显示到页面
            this.txtCode.Text = moduleEntity.Code;
            this.txtFullName.Text = moduleEntity.FullName;
            this.txtWinForm.Text = moduleEntity.WinForm;
            this.txtNavigateUrl.Text = moduleEntity.NavigateUrl;
            this.txtTarget.Text = moduleEntity.Target;
            this.chkIsGroup.Checked = moduleEntity.IsGroup;
            this.chkEnabled.Checked = moduleEntity.Enabled;
            this.chkIsPublic.Checked = moduleEntity.IsPublic;
            this.txtDescription.Text = moduleEntity.Description;
            */
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 菜单信息
            // this.DTModule = DotNetService.Instance.ModuleService.Get(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();

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
            //this.txtCode.Text = this.txtCode.Text.TrimEnd();            
            //if (this.txtCode.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9977), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtCode.Focus();
            //    return false;
            //}
            this.txtFullName.Text = this.txtFullName.Text.TrimEnd();
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9978), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFullName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private BaseModuleEntity GetEntity() 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private BaseModuleEntity GetEntity()
        {
            BaseModuleEntity moduleEntity = new BaseModuleEntity();
            if (string.IsNullOrEmpty(this.ucParent.SelectedId))
            {
                moduleEntity.ParentId = null;
            }
            else
            {
                moduleEntity.ParentId = int.Parse(this.ucParent.SelectedId);
            }
            moduleEntity.Code = this.txtCode.Text;
            moduleEntity.FullName = this.txtFullName.Text;
            moduleEntity.NavigateUrl = this.txtNavigateUrl.Text;
            moduleEntity.Target = this.txtTarget.Text;
            moduleEntity.Enabled = this.chkEnabled.Checked ? 1:0;
            moduleEntity.IsPublic = this.chkIsPublic.Checked ? 1 : 0;
            moduleEntity.Description = this.txtDescription.Text;
            moduleEntity.DeletionStateCode = 0;
            moduleEntity.AllowDelete = 1;
            moduleEntity.AllowEdit = 1;
            return moduleEntity;
        }
        #endregion

        #region private  bool SaveEntity(bool close) 保存
        /// <summary>
        /// 保存
        /// </summary>
        private  bool SaveEntity(bool close)
        {
            bool returnValue = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 转换数据
            BaseModuleEntity moduleEntity = this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId = DotNetService.Instance.ModuleService.Add(UserInfo, moduleEntity, out statusCode, out statusMessage);
            this.FullName = moduleEntity.FullName;
            this.ParentID = this.ucParent.SelectedId;
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 即时刷新
                //if (this.Owner != null && !close)
                //{
                //    // 在sdi模式下即时刷新，在tabs和mdi下不起作用
                //    if (this.Owner is FrmModuleAdmin)
                //    {
                //        ((FrmModuleAdmin)this.Owner).FormOnLoad();
                //    }
                //}
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
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
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
            this.txtNavigateUrl.Clear();
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
                        this.Changed = true;
                        if (close)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 保存不关闭窗体
            this.SaveData(false);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 保存并关闭窗体
            this.SaveData(true);
        }



        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkEnabled.Checked)
                this.chkIsPublic.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                this.Close();
        }

    }
}