//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DevComponents.DotNetBar;
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// TabsMainForm Tab式主界面
    /// 
    /// 修改纪录
    ///     2011.12.07 版本：3.8    zgl       使tabs右键菜单位置随barleft的宽度动态变化。
    ///     2011.10.31 版本：3.7    zgl       修改F5刷新的问题。
    ///     2011.10.01 版本：3.6    Pcsky     修改成窗体显示软件名称+版本号。
    ///     2011.07.13 版本：3.6    24 3 8    增加自动锁屏。     
    ///     2011.06.17 版本：3.6    24 3 8    即时通讯异常处理、多语言。
    ///     2011.04.03 版本：3.4    24 3 8    修改即时通信功能栏。
    ///     2011.04.01 版本：3.4    24 3 8    修改功能栏的停放方式。
    ///		2011.03.25 版本：3.4    24 3 8    创建。  
    /// </summary>	
    /// 版本：3.8
    ///
    /// <author>
    ///		<name>24 3 8</name>
    ///		<date>2011.03.25</date>
    /// </author> 
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class TabsMainForm : BaseForm, IBaseMainForm
    {
        #region 构造函数
        public TabsMainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 属性
        private string userFormStyle = "默认风格";

        /// <summary>
        /// 允许打开相同的Tab页
        /// </summary>
        public bool AllowSameMenu = false;

        private string noteBookId;

        /// <summary>
        /// 记事本文件主键
        /// </summary>
        public string NoteBookId
        {
            get { return noteBookId; }
            set { noteBookId = value; }
        }

       private bool isLockSystem = true;
        
        /// <summary>
        /// 是否锁定系统
        /// </summary>
        public bool IsLockSystem
        {
            get { return isLockSystem; }
            set { isLockSystem = value; }
        }

        private int lockWaitMinute = 60;

        /// <summary>
        /// 锁定等待时间分钟
        /// </summary>
        public int LockWaitMinute
        {
            get { return lockWaitMinute; }
            set { lockWaitMinute = value; }
        } 
        #endregion

        #region public void InitForm() 初始化窗体(IBaseMainForm接口)
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void InitForm()
        {
            // 隐藏本窗口
            this.Hide();
            // 获取用户的权限
            ClientCache.Instance.GetUserPermission(UserInfo);
            // CallFormMessager CallFormMessager = new CallFormMessager(CallMessager);
            // CallFormMessager.BeginInvoke(false, null, null);
            // 这里是呼叫即时通讯部分
            //this.CallMessager(false);
            // 加载底部信息栏
            LoadlblInfo();
            // 加载界面风格
            LoadFormStyle();
            // 加载记事本
            LoadNoteBook();
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;      
            LoadLanguages();

            // 加载锁定信息
            LoadFormLockInfo();
        }
        #endregion

        #region 设置用户信息
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public void SetUserInfo(string userName, string password)
        {
        }
        #endregion

        #region public void InitService() 初始化服务(IBaseMainForm接口)
        /// <summary>
        /// 初始化服务
        /// </summary>
        public void InitService()
        {
            Program.InitService(UserInfo);
        }
        #endregion

        #region private void CheckMenu() 获得的菜单(IBaseMainForm接口)
        /// <summary>
        /// 获得的菜单
        /// </summary>
        public void CheckMenu()
        {
            // 清空左侧功能栏信息
            tvMain.Nodes.Clear();
            navigationBar.Items.Clear();

            // 加载左侧功能栏项
            LoadSildeBar();

            // 加载右侧消息项
            LoadMessage();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        /// <summary>
        /// 加载左侧功能栏项
        /// </summary>
        public void LoadSildeBar()
        {
            int itemIndex;

            foreach (DataRow dr in ClientCache.Instance.DTUserMoule.Rows)
            {
                //~这部分可以单独调优,只是为了把左侧功能栏项加载好，要新增项只需修改判断条件。
                if ((dr[BaseModuleEntity.FieldParentId].ToString() != "10000003"))
                {
                    continue;
                }

                itemIndex = navigationBar.Items.Add(new ButtonItem());
                ButtonItem bi = this.navigationBar.Items[itemIndex] as ButtonItem;
                bi.Name = dr[BaseModuleEntity.FieldCode].ToString();
                bi.OptionGroup = "navBar";
                bi.Text = dr[BaseModuleEntity.FieldFullName].ToString();//.PadLeft(9, ' ');
                bi.Tag = dr;
                //bi.Image = Image.FromFile(BaseSystemInfo.StartupPath + "\\Resource\\BaseBar.png");
                bi.Click += new System.EventHandler(this.toolStripButton_Click);
            }

            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            navigationBar.Size = rect.Size;

            if (this.navigationBar.Items.Count > 0)
            {
                (this.navigationBar.Items[0] as ButtonItem).Checked = true;
                toolStripButton_Click((this.navigationBar.Items[0] as ButtonItem), System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// 加载右侧消息项
        /// </summary>
        public void LoadMessage()
        {
            if (Program.frmMessage == null)
            {
                Program.frmMessage = new FrmMessage();
            }
            Program.frmMessage.Visible = true;
            Program.frmMessage.FormBorderStyle = FormBorderStyle.None;
            Program.frmMessage.WindowState = FormWindowState.Maximized;
            Program.frmMessage.TopLevel = false;
            Program.frmMessage.Parent = pnlMessage;
            Program.frmMessage.Dock = DockStyle.Fill;
            pnlMessage.Controls.Add(Program.frmMessage);
            Program.frmMessage.Show();
        }

        /// <summary>
        /// 左侧的SildeBar点击事件
        /// </summary>
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ButtonItem button = (sender as ButtonItem);
            tvMain.Nodes.Clear();

            TreeNode tNodeRoot = new TreeNode();
            tNodeRoot.Text = (button.Tag as DataRow)[BaseModuleEntity.FieldFullName].ToString();
            tNodeRoot.Tag = button.Tag;
            tNodeRoot.ImageIndex = 0;
            tNodeRoot.SelectedImageIndex = 0;
            tvMain.Nodes.Add(tNodeRoot);

            AddSonNode(tNodeRoot);
            tvMain.ExpandAll();
        }

        /// <summary>
        /// 添加TreeView子节点
        /// </summary>
        public void AddSonNode(TreeNode tNodeParent)
        {
            string strParentID = (tNodeParent.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
            foreach (DataRow dr in ClientCache.Instance.DTUserMoule.Rows)
            {
                if (dr[BaseModuleEntity.FieldParentId].ToString() != strParentID)
                {
                    continue;
                }
                TreeNode tNodeSon = new TreeNode();
                tNodeSon.Text = dr[BaseModuleEntity.FieldFullName].ToString();
                tNodeSon.Tag = dr;

                //如果Target字段为空 则说明其还有子菜单 先前版本是BaseBusinessLogic.ConvertIntToBoolean(dr[BaseModuleEntity.FieldIsMenu]) != true
                if (string.IsNullOrEmpty((dr[BaseModuleEntity.FieldTarget]).ToString()))
                {
                    tNodeSon.ImageIndex = 1;
                    tNodeSon.SelectedImageIndex = 1;
                    AddSonNode(tNodeSon);
                }
                else
                {
                    tNodeSon.ImageIndex = 2;
                    tNodeSon.SelectedImageIndex = 3;
                }
                tNodeParent.Nodes.Add(tNodeSon);
            }
        }
        #endregion

        #region public override void FormOnLoad() 窗体加载
        public override void FormOnLoad()
        {
            if (BaseSystemInfo.UserIsLogOn)
                return;
            // 加载系统界面信息
            LoadFormInfo();
            // 这里需要隐藏主窗体
            this.Hide();
            // 这里显示登录窗体
            Form logOnForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }
        #endregion

        #region private void LoadFormInfo() 加载系统界面信息
        private void LoadFormInfo()
        {
            //加载功能栏位置
            LoadAllBar();
            //加载界面文本信息
            LoadFormTextInfo();
        }

        /// <summary>
        /// 加载功能栏位置
        /// </summary>
        private void LoadAllBar()
        {
            if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\Left.xml"))
            {
                this.barLeft.LoadLayout("Left.xml");
            }
            else
            {
                this.barLeft.Items.Clear();
                this.barLeft.DockSide = eDockSide.Left;
                this.barLeft.Items.Add(this.dockContainerItem1);
                this.barLeft.Visible = true;
            }
            if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\Right.xml"))
            {
                this.barRight.LoadLayout("Right.xml");
            }
            else
            {
                this.barRight.Items.Clear();
                this.barRight.DockSide = eDockSide.Right;
                this.barRight.Items.Add(this.dockContainerItem2);
                this.barRight.Visible = true;
                this.barRight.AutoHide = false;
            }
            if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\RightN.xml"))
            {
                this.barRightN.LoadLayout("RightN.xml");
            }
            else
            {
                this.barRightN.Items.Clear();
                this.barRightN.DockSide = eDockSide.Right;
                this.barRightN.Items.Add(this.dockContainerItem3);
                this.barRightN.Visible = true;
                this.barRightN.AutoHide = true;

            }
            this.Refresh();
        }

        /// <summary>
        /// 加载界面文本信息
        /// </summary>
        private void LoadFormTextInfo()
        {
            // 修改成窗体显示软件名称+版本号
            this.Text = BaseSystemInfo.SoftFullName + " V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #endregion

        #region private void tvMain_MouseClick(object sender, MouseEventArgs e) TreeView鼠标点击事件
        private void tvMain_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    TreeNode treeNode = tvMain.GetNodeAt(e.X, e.Y);
            //    if (treeNode.Bounds.Contains(e.Location))
            //    {
            //        OpenForm(treeNode);
            //    }               
            //}
            //catch (Exception ex)
            //{
            //    this.ProcessException(ex);
            //}
        }

        private void tvMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                TreeNode treeNode = tvMain.GetNodeAt(e.X, e.Y);
                if (treeNode.Bounds.Contains(e.Location))
                {
                    OpenForm(treeNode);
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
        }

        /// <summary>
        /// 这里检查后台的数据是否配置正确
        /// 应该这个方式是调用后台服务代码就厉害了。
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void CheckFormSeting(TreeNode treeNode)
        {
            // 1: 检查模块是否存在？
            // 2: 检查模块上的文字、编号是否正确？
        }

        /// <summary>
        /// 打开新窗体
        /// </summary>
        private void OpenForm(TreeNode treeNode)
        {
            // 写入调试信息
            #if (DEBUG)
                this.CheckFormSeting(treeNode);
            #endif

            // 不打开分类菜单
            if (treeNode.ImageIndex != 2)
            {
                return;
            }

            //如果为消息窗体
            DataRow dataRow = treeNode.Tag as DataRow;
            if (dataRow[BaseModuleEntity.FieldCode].ToString() == "FrmMessage")
            {
                if (barLeft.Items.Contains("dockContainerItem2"))
                {
                    barLeft.AutoHide = false;
                    barLeft.SelectedDockContainerItem = dockContainerItem2;
                }
                if (barRightN.Items.Contains("dockContainerItem2"))
                {
                    barRightN.AutoHide = false;
                    barRightN.SelectedDockContainerItem = dockContainerItem2;
                }
                if (barRight.Items.Contains("dockContainerItem2"))
                {
                    barRight.AutoHide = false;
                    barRight.SelectedDockContainerItem = dockContainerItem2;
                    barRight.Focus();
                }
                return;
            }

            // 如果为锁定窗体
            if (dataRow[BaseModuleEntity.FieldCode].ToString() == "FrmLock")
            {
                tmrLock.Stop();
                DotNet.WinForm.FrmScreenLock lcForm = new FrmScreenLock();
                if (lcForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadFormLockInfo();
                }
                return;
            }

            // 通过数据库的值获得要打开的模块对应的窗体类型。
            System.Type type = System.Type.GetType(dataRow[BaseModuleEntity.FieldTarget].ToString() + "." + dataRow[BaseModuleEntity.FieldCode] + "," + dataRow[BaseModuleEntity.FieldTarget].ToString());
            if (type == null)
            {
                MessageBox.Show(AppMessage.MSG1000, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            object obj = (object)Activator.CreateInstance(type, null);
            BaseForm mdiForm = obj as BaseForm;
            if (mdiForm.ShowDialogOnly)
            {
                mdiForm.HelpButton = false;
                mdiForm.ShowInTaskbar = false;
                mdiForm.MinimizeBox = false;
                mdiForm.ShowDialog(this);
                return;
            }

            if (!AllowSameMenu)
            {
                if (TabIsExist(dataRow[BaseModuleEntity.FieldCode].ToString()))
                {
                    return;
                }
            }

            DevComponents.DotNetBar.TabItem tabItemNew = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel tabControlPanelNew = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanelNew.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPanelNew.Name = dataRow[BaseModuleEntity.FieldCode].ToString();
            tabControlPanelNew.TabItem = tabItemNew;
            tabItemNew.AttachedControl = tabControlPanelNew;
            tabItemNew.Name = dataRow[BaseModuleEntity.FieldCode].ToString();
            tabItemNew.MouseDown += new MouseEventHandler(this.tabItemsMouseDown);
            tabItemNew.MouseUp += new MouseEventHandler(this.tabItemsMouseUp);
            mdiForm.FormClosed += new FormClosedEventHandler(RemoveSelectedTab);
            mdiForm.FormBorderStyle = FormBorderStyle.None;
            mdiForm.TopLevel = false;
            mdiForm.Parent = tabControlPanelNew;
            mdiForm.Dock = DockStyle.Fill;
            tabControlPanelNew.Controls.Add(mdiForm);
            mdiForm.Show();
            tabItemNew.Text = mdiForm.Text;
            tabControlMain.Controls.Add(tabControlPanelNew);
            tabControlMain.Tabs.Add(tabItemNew);
            tabControlMain.Refresh();
            tabControlMain.SelectedTab = tabItemNew;
        }

        /// <summary>
        /// 关闭选中分页
        /// </summary>
        private void RemoveSelectedTab(object sender, FormClosedEventArgs e)
        {
            if (tabControlMain.SelectedTabIndex == 0)
            {
                return;
            }
            tabControlMain.Tabs.Remove(tabControlMain.SelectedTab);
        }

        /// <summary>
        /// 判断是否允许打开相同的Tab页
        /// </summary>
        private bool TabIsExist(string TabItemName)
        {
            foreach (TabItem item in tabControlMain.Tabs)
            {
                if (item.Name == TabItemName)
                {
                    tabControlMain.SelectedTab = item;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region private void tabItemsMouseDown(object sender, MouseEventArgs e) 分页鼠标按下事件
        /// <summary>
        /// 分页鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        DateTime dtStartClick = DateTime.Now;
        private void tabItemsMouseDown(object sender, MouseEventArgs e)
        {
            tabControlMain.SelectedTab = sender as TabItem;

            if (tabControlMain.SelectedTabIndex == 0)
            {
                return;
            }

            DateTime dtNow = DateTime.Now;
            TimeSpan tsSpan = dtNow - dtStartClick;
            double i = tsSpan.TotalSeconds;
            if (i < 0.25)
            {
                tabControlMain.Tabs.Remove(tabControlMain.SelectedTab);
            }

            dtStartClick = DateTime.Now;
        }
        #endregion

        #region  private void tabItemsMouseUp(object sender, MouseEventArgs e) 分页鼠标按起事件
        private void tabItemsMouseUp(object sender, MouseEventArgs e)
        {
            if (tabControlMain.SelectedTabIndex == 0)
            {
                tsMenuItemCloseThis.Visible = false;
            }
            else
            {
                tsMenuItemCloseThis.Visible = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                // 右键菜单定位要考虑barleft的影响。
                if (barLeft.AutoHide)
                {
                    contextMenuStripTab.Show(new Point(e.X, e.Y + 100));
                }
                else { contextMenuStripTab.Show(new Point(e.X+barLeft.Width, e.Y + 100));}
            }
        }
        #endregion

        #region private void tabControlMain_TabMoved(object sender, TabStripTabMovedEventArgs e) 移动Tabs事件
        private void tabControlMain_TabMoved(object sender, TabStripTabMovedEventArgs e)
        {
            if (e.NewIndex == 0 || e.OldIndex == 0)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region private void tabControlMain_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)  分页选择页改变事件
        private void tabControlMain_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (tabControlMain.SelectedTabIndex == 0)
            {
                tabControlMain.CloseButtonVisible = false;
            }
            else
            {
                tabControlMain.CloseButtonVisible = true;
            }
        }
        #endregion

        #region private void tsMenuItemShowFull_Click(object sender, EventArgs e) 右键全屏显示按下事件
        private void tsMenuItemShowFull_Click(object sender, EventArgs e)
        {
            this.Activate();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        #endregion

        #region private void tsMenuItemReLogOn_Click(object sender, EventArgs e) 右键重新登录按下事件
        private void tsMenuItemReLogOn_Click(object sender, EventArgs e)
        {
            this.ReMoveAllTabs();
            DotNetService.Instance.LogOnService.OnExit(UserInfo);
            Form logOnForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }

        /// <summary>
        /// 移除除了主Tab的所有Tabs页
        /// </summary>
        private void ReMoveAllTabs()
        {
            int i = 1;
            while (tabControlMain.Tabs.Count > 1)
            {
                TabItem ti = tabControlMain.Tabs[i];
                tabControlMain.Tabs.Remove(ti);
            }
        }
        #endregion

        #region private void tsMenuItemExit_Click(object sender, EventArgs e) 右键退出系统按下事件
        private void tsMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region private void tsMenuItemCloseThis_Click(object sender, EventArgs e) 右键关闭当前事件
        private void tsMenuItemCloseThis_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTabIndex == 0)
            {
                return;
            }
            tabControlMain.Tabs.Remove(tabControlMain.SelectedTab);
        }
        #endregion

        #region private void tsMenuItemCloseOther_Click(object sender, EventArgs e) 右键关闭其他
        private void tsMenuItemCloseOther_Click(object sender, EventArgs e)
        {
            int i = 1;
            while (tabControlMain.Tabs.Count > 1)
            {
                if (tabControlMain.SelectedTabIndex == 1)
                {
                    i = 2;
                }
                if (i == 2 && tabControlMain.Tabs.Count == 2)
                {
                    break;
                }
                TabItem ti = tabControlMain.Tabs[i];
                tabControlMain.Tabs.Remove(ti);
                ti.Dispose();
            }
            tabControlMain.Refresh();
        }
        #endregion

        #region private void btnToMain_Click(object sender, EventArgs e) 主控窗口按钮点击事件
        private void btnToMain_Click(object sender, EventArgs e)
        {
            if (barLeft.AutoHide == true)
            {
                barLeft.AutoHide = false;
            }
            else
            {
                barLeft.AutoHide = true;
            }
            tabControlMain.SelectedTabIndex = 0;
        }
        #endregion

        #region private void btnReLoadMenu_Click 重新加载界面风格
        private void btnReLoadMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppMessage.MSG1001, AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //删除配置文件
            if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\Left.xml"))
            {
                System.IO.File.Delete(BaseSystemInfo.StartupPath + "\\Left.xml");
            }
            if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\Right.xml"))
            {
                System.IO.File.Delete(BaseSystemInfo.StartupPath + "\\Right.xml");
            }
            if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\RightN.xml"))
            {
                System.IO.File.Delete(BaseSystemInfo.StartupPath + "\\RightN.xml");
            }

            //设置默认风格
            DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "UserFormStyle", "默认风格");
            this.LoadAllBar();
            this.LoadFormStyle();
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        #endregion

        #region private void btnStyle_MouseMove(object sender, MouseEventArgs e) 风格鼠标移过事件
        private void btnStyle_MouseMove(object sender, MouseEventArgs e)
        {
            SetFormStyle((sender as ButtonItem).Text);
        }

        private void SetFormStyle(string StyleName)
        {
            switch (StyleName)
            {
                case "Default":
                    SetMainFormStyle(eStyle.Office2007Blue, eTabStripStyle.Office2003, eDotNetBarStyle.Office2003);
                    BaseSystemInfo.Themes = "Default";
                    break;
                case "WindowsXP":
                    SetMainFormStyle(eStyle.Office2007Blue, eTabStripStyle.OneNote, eDotNetBarStyle.Office2003);
                    BaseSystemInfo.Themes = "WindowsXP";
                    break;
                case "Windows7Blue":
                    SetMainFormStyle(eStyle.Windows7Blue, eTabStripStyle.VS2005Document, eDotNetBarStyle.Office2007);
                    BaseSystemInfo.Themes = "Windows7Blue";
                    break;
                case "Office2007Blue":
                    SetMainFormStyle(eStyle.Office2007Blue, eTabStripStyle.VS2005Document, eDotNetBarStyle.Office2007);
                    BaseSystemInfo.Themes = "Office2007Blue";
                    break;
                case "Office2007Silver":
                    SetMainFormStyle(eStyle.Office2007Silver, eTabStripStyle.VS2005Document, eDotNetBarStyle.Office2007);
                    BaseSystemInfo.Themes = "Office2007Silver";
                    break;
                case "Office2007Black":
                    SetMainFormStyle(eStyle.Office2007Black, eTabStripStyle.VS2005Document, eDotNetBarStyle.Office2007);
                    BaseSystemInfo.Themes = "Office2007Black";
                    break;
                case "Office2007Vista":
                    SetMainFormStyle(eStyle.Office2007VistaGlass, eTabStripStyle.VS2005Document, eDotNetBarStyle.Office2007);
                    BaseSystemInfo.Themes = "Office2007Vista";
                    break;
                case "Office2010Silver":
                    SetMainFormStyle(eStyle.Office2010Silver, eTabStripStyle.VS2005Document, eDotNetBarStyle.Office2007);
                    BaseSystemInfo.Themes = "Office2010Silver";
                    break;
                default:
                    SetMainFormStyle(eStyle.Office2007Blue, eTabStripStyle.Office2003, eDotNetBarStyle.Office2003);
                    BaseSystemInfo.Themes = "Default";
                    break;
            }
            this.Refresh();
        }
        #endregion

        #region private void SetMainFormStyle() 设置主界面风格
        private void SetMainFormStyle(eStyle estyle, eTabStripStyle etabStripStyle, eDotNetBarStyle edotNetBarStyle)
        {
            this.styleManager.ManagerStyle = estyle;
            this.tabControlMain.Style = etabStripStyle;
            this.navigationBar.Style = edotNetBarStyle;
            this.dotNetBarManager.Style = edotNetBarStyle;
        }
        #endregion

        #region private void btnCalculator_Click(object sender, EventArgs e) 计算器按钮单击事件
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            // DotNet.WinForm.User.FrmCreateDigitalSignature frmAboutThis = new DotNet.WinForm.User.FrmCreateDigitalSignature();
            // frmAboutThis.ShowDialog();

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = Environment.SystemDirectory;
            psi.FileName = @"calc.exe";
            Process p = Process.Start(psi);
        }
        #endregion

        #region private void btnNoteBook_Click(object sender, EventArgs e) 记事本按钮单击事件
        private void btnNoteBook_Click(object sender, EventArgs e)
        {
            // DotNet.WinForm.User.FrmChangeSignedPassword frmAboutThis = new DotNet.WinForm.User.FrmChangeSignedPassword();
            // frmAboutThis.ShowDialog();

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = Environment.SystemDirectory;
            psi.FileName = @"notepad";
            Process p = Process.Start(psi);
        }
        #endregion

        #region  private void btnAbout_Click(object sender, EventArgs e) 关于按钮按下事件
        private void btnAbout_Click(object sender, EventArgs e)
        {
            DotNet.WinForm.FrmAboutThis frmAboutThis = new FrmAboutThis();
            frmAboutThis.ShowDialog();
        }
        #endregion

        #region private void btnModifPWD_Click(object sender, EventArgs e) 修改密码按钮按下事件
        private void btnModifPWD_Click(object sender, EventArgs e)
        {
            DotNet.WinForm.FrmUserChangePassword frmUserChangePassword = new DotNet.WinForm.FrmUserChangePassword();
            frmUserChangePassword.ShowDialog();
        }
        #endregion

        #region private void btnSaveNoteBook_Click(object sender, EventArgs e) 保存备忘录按钮按下事件
        private void btnSaveNoteBook_Click(object sender, EventArgs e)
        {
            SaveNoteBook();
            MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region private void LoadFormStyle() 加载界面风格
        private void LoadFormStyle()
        {
            BaseSystemInfo.Themes = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "UserFormStyle");
            if (string.IsNullOrEmpty(BaseSystemInfo.Themes))
            {
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "UserFormStyle", "默认风格");
                BaseSystemInfo.Themes = "默认风格";
            }
            else
            {
                SetFormStyle(BaseSystemInfo.Themes);
            }
        }
        #endregion

        #region private void LoadlblInfo() 加载底部标签信息
        /// <summary>
        /// 加载底部标签信息
        /// </summary>
        private void LoadlblInfo()
        {
            if (!string.IsNullOrEmpty(UserInfo.CompanyName))
            {
                lblCompany.Visible = true;
                lblCompany.Text = "公司：【" + UserInfo.CompanyName + "】";
            }
            else
            {
                lblCompany.Visible = false;
            }

            if (!string.IsNullOrEmpty(UserInfo.DepartmentName))
            {
                lblDept.Visible = true;
                lblDept.Text = "部门：【" + UserInfo.DepartmentName + "】";
            }
            else
            {
                lblDept.Visible = false;
            }

            lblUser.Text = "用户：【" + UserInfo.UserName + "】";
        }
        #endregion

        #region private void LoadNoteBook() 加载备忘录和通告栏是否收缩
        private void LoadNoteBook()
        {
            //左边功能栏位置
            string strBarLeft = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "BarLeft");

            if (string.IsNullOrEmpty(strBarLeft))
            {
                this.dockSiteLeft.Width = 250;
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "BarLeft", dockSiteLeft.Width.ToString());
            }
            else
            {
                if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\Left.xml"))
                {
                    dockSiteLeft.Width = Convert.ToInt32(strBarLeft);
                }
            }

            //右边边功能栏位置
            string strBarRight = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "BarRight");

            if (string.IsNullOrEmpty(strBarRight))
            {
                this.dockSiteRight.Width = 250;
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "BarRight", dockSiteRight.Size.Width.ToString());
            }
            else
            {
                if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\Right.xml"))
                {
                    dockSiteRight.Width = Convert.ToInt32(strBarRight);
                }
            }

            //右边边功能栏位置
            string strBarRightN = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "BarRightN");

            if (string.IsNullOrEmpty(strBarRightN))
            {
                this.dockSiteRightN.Width = 250;
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "BarRight1", dockSiteRightN.Size.Width.ToString());
            }
            else
            {
                if (System.IO.File.Exists(BaseSystemInfo.StartupPath + "\\RightN.xml"))
                {
                    dockSiteRightN.Width = Convert.ToInt32(strBarRightN);
                }
            }

            //加载信息
            NoteBookId = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "UserNoteBookId");

            if (string.IsNullOrEmpty(NoteBookId))
            {
                System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                this.txtNoteBook.Text = "";
                this.txtNoteBook.SaveFile(mstream, RichTextBoxStreamType.RichText);
                //将流转换成数组
                byte[] bWrite = mstream.ToArray();
                string PictureContent = DotNetService.Instance.FileService.Upload(UserInfo, "UserNoteBook", UserInfo.Id, bWrite, true);
                if (PictureContent != "")
                {
                    DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "UserNoteBookId", PictureContent);
                }
            }
            else
            {
                byte[] bWrite = DotNetService.Instance.FileService.Download(UserInfo, NoteBookId);
                if (bWrite != null)
                {
                    System.IO.MemoryStream mstream = new System.IO.MemoryStream(bWrite, false);
                    //将stream填充到RichTextBox
                    this.txtNoteBook.LoadFile(mstream, RichTextBoxStreamType.RichText);
                }
            }
        }
        #endregion

        #region private void SaveFormStyle() 保存界面风格
        private void SaveFormStyle()
        {
            DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "UserFormStyle", BaseSystemInfo.Themes);
            //保存左右功能栏位置
            barLeft.SaveLayout("Left.xml");
            barRight.SaveLayout("Right.xml");
            barRightN.SaveLayout("RightN.xml");
        }
        #endregion

        #region private void SaveNoteBook() 保存备忘录 和 界面位置
        private void SaveNoteBook()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            System.IO.MemoryStream mstream = new System.IO.MemoryStream();
            this.txtNoteBook.SaveFile(mstream, RichTextBoxStreamType.RichText);
            //将流转换成数组
            byte[] bWrite = mstream.ToArray();
            string PictureContent = DotNetService.Instance.FileService.Upload(UserInfo, "UserNoteBook", UserInfo.Id, bWrite, true);
            if (PictureContent != "")
            {
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "UserNoteBookId", PictureContent);
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "BarLeft", this.dockSiteLeft.Width.ToString());
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "BarRight", this.dockSiteRight.Size.Width.ToString());
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", UserInfo.Id, "BarRightN", this.dockSiteRightN.Size.Width.ToString());
            }
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void TabsMainFrm_FormClosed() 窗体关闭事件

        private void TabsMainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseSystemInfo.UserIsLogOn)
            {
                if (MessageBox.Show(AppMessage.MSG0204, AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                if (Program.frmMessage != null)
                {
                    Program.frmMessage.ExitApplication = true;
                    Program.frmMessage.Close();
                    Program.frmMessage.Dispose();
                }
                // 退出应用程序
                DotNetService.Instance.LogOnService.OnExit(UserInfo);
                SaveFormStyle();
                SaveNoteBook();
            }
        }
        #endregion

        #region 多语言选择
        private void btSelectLang_Click(object sender, EventArgs e)
        {
            BaseSystemInfo.CurrentLanguage = (sender as ButtonItem).Tag.ToString();
            UserConfigHelper.SaveConfig();
            LoadLanguages();
        }

        public void LoadLanguages()
        {
            foreach (ButtonItem item in btnLanguages.SubItems)
            {
                if (item.Tag.ToString() == BaseSystemInfo.CurrentLanguage)
                {
                    item.ForeColor = Color.Red;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
            }
            this.Localization(this);
        }
        #endregion

        #region tvMain_AfterExpand TreeView展开时间 目的使滚动框到最上面
        private void tvMain_AfterExpand(object sender, TreeViewEventArgs e)
        {
            this.tvMain.Nodes[0].EnsureVisible();
        }
        #endregion

        #region 移除页面保存列宽
        private void tabControlMain_TabRemoved(object sender, EventArgs e)
        {
            //保存列宽
            BaseInterfaceLogic.SaveDataGridViewColumnWidth(tabControlMain.SelectedTab.AttachedControl.Controls[0] as Form);
        }
        #endregion

        #region 自动锁屏
        private void LoadFormLockInfo()
        {
            // 是否锁定系统，默认是锁定状态
            this.tmrLock.Enabled = false;
            string isLockSystem = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "IsLockSystem");
            if (string.IsNullOrEmpty(isLockSystem))
            {
                this.tmrLock.Enabled = true;
                this.IsLockSystem = true;
            }
            else
            {
                if (isLockSystem.Equals(true.ToString()))
                {
                    this.tmrLock.Enabled = true;
                    this.IsLockSystem = true;
                }
            }
            // 锁定等待时间，默认是60分钟
            string lockWaitMinute = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "LockWaitMinute");
            if (string.IsNullOrEmpty(lockWaitMinute))
            {
                this.LockWaitMinute = 60;
            }
            else
            {
                this.LockWaitMinute = int.Parse(lockWaitMinute);
            }
            // 设定锁屏
            // if (tmrLock.Enabled == false)
            // {
            //    tmrLock.Start();
            // }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public long getIdleTick()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo))
            {
                return 0;
            }
            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }

        private void tmrLock_Tick(object sender, EventArgs e)
        {
            // 这里先判断是否进行锁屏
            if (this.IsLockSystem.Equals(false.ToString()))
            {
                // 不再进行循环判断了
                this.tmrLock.Enabled = false;
                return;
            }
            if (this.IsLockSystem)
            {
                long i = getIdleTick();
                if (i > this.LockWaitMinute * 1000 * 60)
                {
                    this.tmrLock.Stop();
                    DotNet.WinForm.FrmScreenLock lcForm = new FrmScreenLock();
                    if (lcForm.ShowDialog() == DialogResult.OK)
                    {
                        this.LoadFormLockInfo();
                    }
                }
            }
        }
        #endregion

        private void tmrTask_Tick(object sender, EventArgs e)
        {
            // 前提是用户已经登录系统了
            if (BaseSystemInfo.UserIsLogOn)
            {
                // 当退出程序时把当前用户的状态修改为离线状态
                if (BaseSystemInfo.CheckOnLine || (BaseSystemInfo.OnLineLimit > 0))
                {
                    try
                    {
                        // 每次都建立一个新的链接
                        DotNetService serviceManager = new DotNetService();
                        serviceManager.LogOnService.OnLine(this.UserInfo, 1);

                        // 每次都采用同一个连接，可能会有超时问题导致
                        // DotNetService.Instance.LogOnService.OnLine(this.UserInfo);
                    }
                    catch (System.Exception ex)
                    {
                        this.WriteException(ex);
                        System.Console.WriteLine(ex.InnerException);
                    }
                }
            }
        }
    }
}