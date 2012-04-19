//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    
    /// <summary>
    /// FrmStaffAdmin.cs
    /// 角色管理-管理角色窗体
    ///		
    /// 修改记录
    ///     2011.12.08 版本：2.6 张广梁    屏蔽右键添加角色菜单，删除用户报表菜单。
    ///     2011.07.04 版本：1.2 zgl       优化treeview节点选择，左键单击 展开或折叠    
    ///     2011.02.25 版本：1.1 JiRiGaLa  只显示内部组织机构。
    ///     2007.05.22 版本：1.0 JiRiGaLa  员工管理功能页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.02.25</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffAdmin : BaseForm, IBaseForm
    {
        private DataTable DTStaff = new DataTable(BaseStaffEntity.TableName);    // 员工 DataTable
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName); // 组织机构 DataTable
        private DataTable DTOrganizeList = new DataTable(BaseOrganizeEntity.TableName); // 组织机构 DataTable

        private System.Windows.Forms.Control lastControl = null;      // 记录最后点击的控件

        public event SetControlStateEventHandler OnButtonStateChange;

        private bool permissionAccredit = false; // 用户授权

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        private string parentEntityId = string.Empty;
        // 部门主键
        public string ParentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.parentEntityId = this.tvOrganize.SelectedNode.Tag.ToString();
                }
                else
                {
                    this.parentEntityId = string.Empty;
                }
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 组织机构主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.grdStaff, BaseStaffEntity.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                string entityId = string.Empty;
                if (this.lastControl == this.tvOrganize)
                {
                    entityId = this.parentEntityId;
                }
                else
                {
                    entityId = this.EntityId;
                }
                return entityId;
            }
        }

        public FrmStaffAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
            this.btnSetPassword.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnMove.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnBatchDelete.Enabled = false;
            this.btnUserPermission.Enabled = false;
            this.btnBatchSave.Enabled = false;

            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd && (this.tvOrganize.Nodes.Count > 0);

            if (this.DTStaff.DefaultView.Count >= 1)
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionEdit;
                this.btnSetPassword.Enabled = this.permissionEdit;
                this.btnBatchDelete.Enabled = this.permissionDelete;
                this.btnExport.Enabled = this.permissionEdit;
                // 用户授权
                this.btnUserPermission.Enabled = this.permissionAccredit;
                this.btnBatchSave.Enabled = this.permissionEdit;
            }

            // 位置顺序改变按钮部分
            if (this.DTStaff.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }

            // 右手弹出菜单
            this.mItmAdd.Enabled = this.permissionAdd;
            this.mItmEdit.Enabled = this.permissionEdit;
            this.mItmMove.Enabled = this.permissionEdit;
            this.mItmDelete.Enabled = this.permissionDelete;
            this.mItemRoleAdd.Enabled = this.ModuleIsVisible("FrmRoleAdmin");
            if (this.mItemRoleAdd.Visible)
            {
                this.mItemRoleAdd.Enabled = this.IsModuleAuthorized("FrmRoleAdmin");
            }
            this.mItmStaffAdd.Enabled = this.ModuleIsVisible("FrmStaffAdmin");
            if (this.mItmStaffAdd.Visible)
            {
                this.mItmStaffAdd.Enabled = this.IsModuleAuthorized("FrmStaffAdmin");
            }
            this.mItmGender.Enabled = this.ModuleIsVisible("FrmItemsAdmin");
            if (this.mItmGender.Visible)
            {
                this.mItmGender.Enabled = this.IsModuleAuthorized("FrmItemsAdmin");
            }
            this.mItmParty.Enabled = this.mItmGender.Enabled;
            if (this.mItmParty.Visible)
            {
                this.mItmParty.Enabled = this.mItmGender.Enabled;
            }
            this.mItmNationality.Enabled = this.mItmGender.Enabled;
            if (this.mItmNationality.Visible)
            {
                this.mItmNationality.Enabled = this.mItmGender.Enabled;
            }
            this.mItmTitle.Enabled = this.mItmGender.Enabled;
            if (this.mItmTitle.Visible)
            {
                this.mItmTitle.Enabled = this.mItmGender.Enabled;
            }
            this.mItmDuty.Enabled = this.mItmGender.Enabled;
            if (this.mItmDuty.Visible)
            {
                this.mItmDuty.Enabled = this.mItmGender.Enabled;
            }
            this.mItmEducation.Enabled = this.mItmGender.Enabled;
            if (this.mItmEducation.Visible)
            {
                this.mItmEducation.Enabled = this.mItmGender.Enabled;
            }
            this.mItmDegree.Enabled = this.mItmGender.Enabled;
            if (this.mItmDegree.Visible)
            {
                this.mItmDegree.Enabled = this.mItmGender.Enabled;
            }
            this.mItmWorkingProperty.Enabled = this.mItmGender.Enabled;
            if (this.mItmWorkingProperty.Visible)
            {
                this.mItmWorkingProperty.Enabled = this.mItmGender.Enabled;
            }
            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                bool setTop = this.ucTableSort.SetTopEnabled;
                bool setUp = this.ucTableSort.SetUpEnabled;
                bool setDown = this.ucTableSort.SetDownEnabled;
                bool setBottom = this.ucTableSort.SetBottomEnabled;
                bool add = this.btnAdd.Enabled;
                bool edit = this.btnEdit.Enabled;
                bool batchDelete = this.btnBatchDelete.Enabled;
                bool batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchDelete, batchSave);
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("StaffAdmin");
            this.permissionAdd = this.IsAuthorized("StaffAdmin.Add");
            this.permissionEdit = this.IsAuthorized("StaffAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("StaffAdmin.Delete");
            this.permissionAccredit = this.IsAuthorized("UserAdmin.Accredit");
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                this.LoadTreeOrganize();
                if (this.tvOrganize.SelectedNode == null)
                {
                    if (this.tvOrganize.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                        }
                        else
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
                            if (BaseInterfaceLogic.TargetNode != null)
                            {
                                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                            }
                        }
                        if (this.tvOrganize.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvOrganize.SelectedNode.Expand();
                            this.tvOrganize.SelectedNode.EnsureVisible();
                        }
                    }
                }
            }
            if (reloadTree)
            {
                this.GetStaffList();
            }
            // 添加选择列
            if (this.ParentEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    // 获得子部门列表
                    this.GetOrganizeList();
                }
            }
            // 判断编辑权限
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.grdStaff.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.grdStaff.Columns["colRealName"].ReadOnly = !this.permissionEdit;
                this.grdStaff.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                this.grdStaff.Columns["colRealName"].DefaultCellStyle.BackColor = Color.White;
                this.grdStaff.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            }

            // 设置按钮状态
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
            this.DataGridViewOnLoad(grdStaff);
            // 获取部门数据，这里按管理范围进行获取数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            // 内部组织机构必须要检查父亲节点的逻辑关系
            BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
            // 这个不需要加载， 加载了这个，导致运行速度有些慢，下面的函数已经有这个功能了。
            // this.DSStaff = StaffAdminService.Instance.GetList(UserInfo, this.ParentEntityId);
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTOrganizeList = DotNetService.Instance.OrganizeService.GetDataTableByParent(UserInfo, this.ParentEntityId);
            this.DTOrganizeList.DefaultView.Sort = BaseOrganizeEntity.FieldSortCode;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                foreach (DataRow dataRow in this.DTOrganizeList.Rows)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dataRow[BaseOrganizeEntity.FieldFullName].ToString();
                    treeNode.Tag = dataRow[BaseOrganizeEntity.FieldId].ToString();
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
            }
            this.tvOrganize.SelectedNode.Expand();
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void GetStaffList() 获得表格里的用户
        /// <summary>
        /// 获得表格里的用户
        /// </summary>
        private void GetStaffList()
        {
            this.grdStaff.AutoGenerateColumns = false;
            this.DTStaff = DotNetService.Instance.StaffService.GetDataTableByOrganize(UserInfo, this.ParentEntityId, false);
           
            // 把已经删除的过滤掉
            BaseBusinessLogic.SetFilter(this.DTStaff, BaseStaffEntity.FieldDeletionStateCode, "0");
            // 只显示有效的用户
            if (this.chkEnabled.Checked)
            {
                BaseBusinessLogic.SetFilter(this.DTStaff, BaseStaffEntity.FieldEnabled, "1");
            }
            if (this.chkNotIsUser.Checked)
            {
                this.DTStaff.DefaultView.RowFilter = BaseStaffEntity.FieldUserId + " IS NULL ";
            }
            // 添加选择列
            //this.DataTableAddColumn();
            if (this.ParentEntityId.Length > 0)
            {
                this.DTStaff.DefaultView.Sort = BaseStaffEntity.FieldSortCode;
                this.grdStaff.DataSource = this.DTStaff.DefaultView;
            }
            // 设置排序按钮
            this.ucTableSort.DataBind(this.grdStaff, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
            // 检查员工的对应用户是否存在
            this.CheckUserExist();
        }
        #endregion

        #region private void LoadTreeOrganize() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTreeOrganize()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode, !BaseSystemInfo.OrganizeDynamicLoading);
        }
        #endregion

        #region private void DataTableAddColumn() 往DataTable里面添加一列
        /// <summary>
        /// 往DataTable里面添加一列
        /// </summary>
        //private void DataTableAddColumn()
        //{
        //    BaseInterfaceLogic.DataTableAddColumn(this.DTStaff, "colSelected");
        //}
        #endregion

        /// <summary>
        /// 设置查询条件
        /// </summary>
        private void SetSearch()
        {
            this.grdStaff.AutoGenerateColumns = false;
            string search = this.txtSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                this.DTStaff.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTStaff.DefaultView.RowFilter = BaseStaffEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldUserName + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldRealName + " LIKE '" + search + "'"
                    // + " OR " + BaseStaffEntity.FieldEmail + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldDescription + " LIKE '" + search + "'";
                this.grdStaff.DataSource = this.DTStaff.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = this.txtSearch.Text.TrimEnd();
            if (this.txtSearch.Text.Trim().Length == 0)
            {
                //MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG0212), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.txtSearch.Focus();
                //return;
                this.DTStaff = DotNetService.Instance.StaffService.GetDataTable(UserInfo);
                this.grdStaff.DataSource = this.DTStaff.DefaultView;
            }
            this.DTStaff = DotNetService.Instance.StaffService.Search(UserInfo, this.ParentEntityId, this.txtSearch.Text);
            //this.DataTableAddColumn();
            this.grdStaff.DataSource = this.DTStaff.DefaultView;
            // 设置按钮状态
            this.SetControlState();
        }

        private void chkNotIsUser_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStaffList();
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStaffList();
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            this.lastControl = this.tvOrganize;
            if (this.tvOrganize.SelectedNode == null)
            {
                this.tvOrganize.ContextMenuStrip = null;
            }
            else
            {
                this.tvOrganize.ContextMenuStrip = this.cMnuStaff;
            }
            // 这里需要解决效率问题，这个程序被执行了2次了
            //this.GetOrganizeList();//comment by zgl
            this.GetStaffList();
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.ParentEntityId.Length > 0)
                {
                    // Click 时也执行了这个程序，需要将来优化一下，也需要考虑，只有一个父节点的问题
                    this.GetOrganizeList();
                    this.GetStaffList();
                }
            }
        }

        private void tvOrganize_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                //定义一个位置点的变量，保存当前光标所处的坐标点
                Point point;
                //拖放的目标节点
                TreeNode targetTreeNode;
                //获取当前光标所处的坐标
                point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                //根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                //获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 是否移动部门
                        if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0038, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    DotNetService.Instance.OrganizeService.MoveTo(UserInfo, treeNode.Tag.ToString(), targetTreeNode.Tag.ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void tvOrganize_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void mitmAdd_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeAdd";
            Form frmOrganizeAdd = CacheManager.Instance.GetForm(assemblyName, formName);
            if (this.tvOrganize.SelectedNode != null)
            {
                ((IBaseOrganizeAddForm)frmOrganizeAdd).ParentId = this.tvOrganize.SelectedNode.Tag.ToString();
                ((IBaseOrganizeAddForm)frmOrganizeAdd).ParentFullName = this.tvOrganize.SelectedNode.Text;
            }
            if (frmOrganizeAdd.ShowDialog(this) == DialogResult.OK)
            {
                this.FormLoaded = false;
               
                // 绑定屏幕数据
                this.BindData(true);
                this.FormLoaded = true;
            }
        }

        private void mitmEdit_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmOrganizeEdit";
                Form frmOrganizeEdit = CacheManager.Instance.GetForm(assemblyName, formName);
                ((IBaseOrganizeEditForm)frmOrganizeEdit).EntityId = this.tvOrganize.SelectedNode.Tag.ToString();
                if (frmOrganizeEdit.ShowDialog(this) == DialogResult.OK)
                {
                    this.FormLoaded = false;

                    // 绑定屏幕数据
                    this.BindData(true);
                    this.FormLoaded = true;
                }
            }
        }

        private void mitmMove_Click(object sender, EventArgs e)
        {
            this.btnMove.PerformClick();
        }

        private void mitmDelete_Click(object sender, EventArgs e)
        {
            if (this.lastControl == this.tvOrganize)
            {
                if (!BaseInterfaceLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvOrganize.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // 有数据时禁止删除
                else if (this.DTStaff.DefaultView.Count > 0)
                {
                    MessageBox.Show(AppMessage.MSG0225, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        this.FormLoaded = false;
                        DotNetService.Instance.OrganizeService.SetDeleted(UserInfo, new string[]{this.ParentEntityId});
                        // DotNetService.Instance.OrganizeService.Delete(UserInfo, this.ParentEntityId);
                        ClientCache.Instance.DTOrganize = null;
                        // 获取部门数据
                        this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
                        this.ParentEntityId = string.Empty;
                        // 绑定数据
                        this.BindData(true);
                        this.FormLoaded = true;
                        // 设置鼠标默认状态，原来的光标状态
                        this.Cursor = holdCursor;
                    }
                }
            }
        }

        private void mitmStaffAdd_Click(object sender, EventArgs e)
        {
            FrmStaffAdd frmStaffAdd;
            if (this.tvOrganize.SelectedNode == null)
            {
                frmStaffAdd = new FrmStaffAdd();
            }
            else
            {
                string departmentId = string.Empty;
                string departmentname = string.Empty;
                string companyId = string.Empty;
                string companyName = string.Empty;
                TreeNode treeNode = this.tvOrganize.SelectedNode;
                if (BaseBusinessLogic.GetProperty(ClientCache.Instance.DTOrganize, treeNode.Tag.ToString(), BaseOrganizeEntity.FieldCategory) != "Company")
                {
                    departmentId = treeNode.Tag.ToString();
                    departmentname = treeNode.Text;
                }
                while (treeNode.Parent != null)
                {
                    if (BaseBusinessLogic.GetProperty(ClientCache.Instance.DTOrganize, treeNode.Tag.ToString(), BaseOrganizeEntity.FieldCategory) == "Company")
                    {
                        break;
                    }
                    treeNode = treeNode.Parent;
                }
                companyId = treeNode.Tag.ToString();
                companyName = treeNode.Text;
                frmStaffAdd = new FrmStaffAdd(companyId, companyName, departmentId, departmentname);
            }
            frmStaffAdd.ShowDialog(this);
            if (frmStaffAdd.Changed)
            {
                this.GetStaffList();
            }
        }

        private void mItemRoleAdd_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeRoleAdd";
            Form frmOrganizeRoleAdd = CacheManager.Instance.GetForm(assemblyName, formName);
            if (this.tvOrganize.SelectedNode != null)
            {
                ((IBaseOrganizeRoleAddForm)frmOrganizeRoleAdd).OrganizeId = this.tvOrganize.SelectedNode.Tag.ToString();
                ((IBaseOrganizeRoleAddForm)frmOrganizeRoleAdd).OrganizeFullName = this.tvOrganize.SelectedNode.Text;
            }
            frmOrganizeRoleAdd.ShowDialog(this);
        }

        private void mitm_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmItemDetailsAdmin";
            Form frmItemDetailsAdmin = CacheManager.Instance.GetForm(assemblyName, formName);
            string targetTable = string.Empty;
            // targetTable = "ItemsGender";
            targetTable = "Items" + ((ToolStripMenuItem)sender).Name.Substring(4);
            ((IBaseItemDetailsAdminForm)frmItemDetailsAdmin).TargetTable = targetTable;
            frmItemDetailsAdmin.ShowDialog();
        }

        private void mitmRoleAdmin_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmRoleAdmin";
            Form frmRoleAdmin = CacheManager.Instance.GetForm(assemblyName, formName);
            frmRoleAdmin.ShowDialog();
        }

        private void mItemResetSortCode_Click(object sender, EventArgs e)
        {
            DotNetService.Instance.StaffService.ResetSortCode(UserInfo);
        }

        private void grdStaff_Click(object sender, EventArgs e)
        {
            this.lastControl = this.grdStaff;
        }

        private void grdStaff_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 判断是否有删除权限
            //if (!this.permissionDelete)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //else
            //{
            //    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        StaffAdminService.Instance.Delete(UserInfo, this.EntityId);
            //    }
            //}
        }

        private void grdStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        /// <summary>
        /// 置顶
        /// </summary>
        public int SetTop()
        {
            return this.ucTableSort.SetTop();
        }

        /// <summary>
        /// 上移
        /// </summary>
        public int SetUp()
        {
            return this.ucTableSort.SetUp();
        }

        /// <summary>
        /// 下移
        /// </summary>
        public int SetDown()
        {
            return this.ucTableSort.SetDown();
        }

        /// <summary>
        /// 置底
        /// </summary>
        public int SetBottom()
        {
            return this.ucTableSort.SetBottom();
        }

        public void SetSortButton(bool enabled)
        {
            this.ucTableSort.SetSortButton(enabled);
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdStaff, "colSelected"))
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserSetPassword";
                Form frmUserSetPassword = CacheManager.Instance.GetForm(assemblyName, formName);
                ((IBaseUserSetPasswordForm)frmUserSetPassword).SelectedIds = this.GetSelecteUserIds();
                frmUserSetPassword.ShowDialog();
            }
        }

        #region private string[] GetSelecteIds() 获得已被选择的员工主键数组
        /// <summary>
        /// 获得已被选择的员工主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdStaff, BaseStaffEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private string[] GetSelecteUserIds() 获得已被选择的用户主键数组
        /// <summary>
        /// 获得已被选择的用户主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteUserIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdStaff, BaseStaffEntity.FieldUserId, "colSelected", true);
        }
        #endregion

        private void grdStaff_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = DotNetService.Instance.SequenceService.GetBatchSequence(UserInfo, BaseStaffEntity.TableName, this.DTStaff.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTStaff.DefaultView)
                {
                    dataRowView.Row[BaseStaffEntity.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        /// <summary>
        /// 检查员工的对应用户是否存在
        /// </summary>
        private void CheckUserExist()
        {
            this.btnSetPassword.Enabled = false;
            this.btnUserPermission.Enabled = false;
            
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
            if (dataRow != null)
            {
                string id = dataRow[BaseStaffEntity.FieldUserId].ToString();
                if (!String.IsNullOrEmpty(id))
                {
                    this.btnSetPassword.Enabled = this.permissionEdit;
                    this.btnUserPermission.Enabled = this.permissionAccredit;
                }
            }
        }

        private void grdStaff_SelectionChanged(object sender, EventArgs e)
        {
            this.CheckUserExist();
        }

        #region public string Add() 添加组织机构
        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            string DepartmentId = string.Empty;
            string departmentname = string.Empty;
            string CompanyId = string.Empty;
            string companyName = string.Empty;
            TreeNode treeNode = this.tvOrganize.SelectedNode;
            if (treeNode != null)
            {
                if (BaseBusinessLogic.GetProperty(this.DTOrganize, treeNode.Tag.ToString(), BaseOrganizeEntity.FieldCategory) != "Company")
                {
                    DepartmentId = treeNode.Tag.ToString();
                    departmentname = treeNode.Text;
                }
                while (treeNode.Parent != null)
                {
                    if (BaseBusinessLogic.GetProperty(this.DTOrganize, treeNode.Tag.ToString(), BaseOrganizeEntity.FieldCategory) == "Company")
                    {
                        break;
                    }
                    treeNode = treeNode.Parent;
                }
                CompanyId = treeNode.Tag.ToString();
                companyName = treeNode.Text;
                FrmStaffAdd frmStaffAdd = new FrmStaffAdd(CompanyId, companyName, DepartmentId, departmentname);
                if (frmStaffAdd.ShowDialog(this) == DialogResult.OK)
                {
                    returnValue = frmStaffAdd.EntityId;
                    this.GetStaffList();
                }
            }
            return returnValue;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加员工
            this.Add();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            string id = BaseInterfaceLogic.GetDataGridViewEntityId(this.grdStaff, BaseStaffEntity.FieldId);
            FrmStaffEdit frmStaffEdit = new FrmStaffEdit(id);
            if (frmStaffEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 获得用户列表
                this.GetStaffList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private bool CheckInputMove(string selectedId) 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove(string selectedId)
        {
            bool returnValue = true;
            // 单个移动检查
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
            TreeNode treeNode = BaseInterfaceLogic.TargetNode;
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, selectedId);
            TreeNode targetTreeNode = BaseInterfaceLogic.TargetNode;
            if (!BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0036, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region private void BatchMove() 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        private void BatchMove()
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.ParentEntityId))
            {
                ((IBaseSelectOrganizeForm)frmOrganizeSelect).OpenId = this.ParentEntityId;
            }
            ((IBaseSelectOrganizeForm)frmOrganizeSelect).AllowNull = false;
            ((IBaseSelectOrganizeForm)frmOrganizeSelect).PermissionItemScopeCode = "OrganizeAdmin";
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                try
                {
                    // 调用事件
                    DotNetService.Instance.StaffService.BatchMoveTo(UserInfo, this.GetSelecteIds(), ((IBaseSelectOrganizeForm)frmOrganizeSelect).SelectedId);
                    // 绑定屏幕数据
                    this.GetStaffList();
                    this.FormLoaded = true;
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
        #endregion

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        public void SingleMove(string currentEntityId)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.ParentEntityId))
            {
                ((IBaseSelectOrganizeForm)frmOrganizeSelect).OpenId = this.ParentEntityId;
            }
            ((IBaseSelectOrganizeForm)frmOrganizeSelect).AllowNull = false;
            ((IBaseSelectOrganizeForm)frmOrganizeSelect).PermissionItemScopeCode = "OrganizeAdmin";
            ((IBaseSelectOrganizeForm)frmOrganizeSelect).OnButtonConfirmClick += new BaseBusinessLogic.CheckMoveEventHandler(CheckInputMove);
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                DotNetService.Instance.StaffService.MoveTo(UserInfo, currentEntityId, ((IBaseSelectOrganizeForm)frmOrganizeSelect).SelectedId);
                // 绑定屏幕数据
                this.BindData(true);
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveObject()
        {
            if (this.lastControl == this.grdStaff)
            {
                if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdStaff, "colSelected"))
                {
                    this.BatchMove();
                }
            }
            if (this.lastControl == this.tvOrganize)
            {
                if (this.parentEntityId.Length > 0)
                {
                    this.SingleMove(this.CurrentEntityId);
                }
            }
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
        }

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;

            foreach (DataGridViewRow dgvRow in grdStaff.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                    {
                        // 有记录被选中了
                        returnValue = true;
                        // break;
                        // 是否有子节点
                        string id = dataRow[BaseStaffEntity.FieldId].ToString();
                        if (id == UserInfo.Id)
                        {
                            MessageBox.Show(AppMessage.MSG0226, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = false;
                            return returnValue;
                        }
                    }
                }
            }

            //foreach (DataRow dataRow in this.DTStaff.Rows)
            //{
            //    if (dataRow.RowState != DataRowState.Deleted)
            //    {
            //        if (dataRow["colSelected"].ToString() == true.ToString())
            //        {
            //            // 有记录被选中了
            //            returnValue = true;
            //            // break;
            //            // 是否有子节点
            //            string id = dataRow[BaseStaffEntity.FieldId].ToString();
            //            if (id == UserInfo.Id)
            //            {
            //                MessageBox.Show(AppMessage.MSG0226, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }
            //    }
            //}
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            int returnValue = 0;
            this.FormLoaded = false;
            returnValue = DotNetService.Instance.StaffService.SetDeleted(UserInfo, this.GetSelecteIds());
            // returnValue = DotNetService.Instance.StaffService.BatchDelete(UserInfo, this.GetSelecteIds());
            // 绑定数据
            this.GetStaffList();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        #region private int SingleDelete() 单个记录删除
        /// <summary>
        /// 单个记录删除
        /// </summary>
        /// <returns>影响行数</returns>
        private int SingleDelete()
        {
            int returnValue = 0;
            this.FormLoaded = false;
            returnValue = DotNetService.Instance.OrganizeService.SetDeleted(UserInfo, new string[] {this.ParentEntityId});
            // returnValue = DotNetService.Instance.OrganizeService.Delete(UserInfo, this.ParentEntityId);
            ClientCache.Instance.DTOrganize = null;
            // 获取部门数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            // 清除当前记录
            this.ParentEntityId = string.Empty;
            // 绑定数据
            this.BindData(true);
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int Delete()
        {
            int returnValue = 0;
            if (this.lastControl == this.grdStaff)
            {
                if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        returnValue = this.BatchDelete();
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
            if (this.lastControl == this.tvOrganize)
            {
                if (!BaseInterfaceLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0035, this.tvOrganize.SelectedNode.Text), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show(AppMessage.MSG0015, AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            returnValue = this.SingleDelete();
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
            }
            return returnValue;
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool returnValue = false;


            foreach (DataGridViewRow dgvRow in grdStaff.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    returnValue = true;
                    break;
                }
            }

            //foreach (DataRow dataRow in this.DTOrganize.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        returnValue = true;
            //        break;
            //    }
            //}
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdStaff, @"\Modules\Export\", exportFileName);
        }

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            if (this.CheckInputBatchDelete())
            {
                // 删除数据
                this.Delete();
            }
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DotNetService.Instance.StaffService.BatchSave(UserInfo, this.DTStaff);
                // 绑定屏幕数据
                this.BindData(true);
                if (BaseSystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
        }
        #endregion

        private void btnUserPermission_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
            string id = dataRow[BaseStaffEntity.FieldUserId].ToString();
            if (String.IsNullOrEmpty(id))
            {
                // 请先创建该员工的登录系统的用户信息
                MessageBox.Show(AppMessage.MSG0060, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string realName = dataRow[BaseStaffEntity.FieldRealName].ToString();
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserPermission";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(type, id, realName);
                frmUserPermissionAdmin.ShowDialog(this);
            }
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
            string id = dataRow[BaseStaffEntity.FieldUserId].ToString();
            if (String.IsNullOrEmpty(id))
            {
                // 请先创建该员工的登录系统的用户信息
                MessageBox.Show(AppMessage.MSG0060, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string fullName = dataRow[BaseStaffEntity.FieldRealName].ToString();
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserRoleAdmin";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmUserRoleAdmin = (Form)Activator.CreateInstance(type, id, fullName);
                frmUserRoleAdmin.ShowDialog(this);
            }
        }

        public void Save()
        {
            // 检查批量输入的有效性
            if (BaseInterfaceLogic.CheckInputModifyAnyOne(this.DTStaff))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStaffAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseInterfaceLogic.IsModfiedAnyOne(this.DTStaff))
            {
                // 数据有变动是否保存的提示
                DialogResult dialogResult = MessageBox.Show(AppMessage.MSG0045, AppMessage.MSG0000, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    // 保存数据
                    this.BatchSave();
                }
            }
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }
    }
}