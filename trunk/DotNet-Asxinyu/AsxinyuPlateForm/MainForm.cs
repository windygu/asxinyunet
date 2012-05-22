#region 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.Tools;
using DotNet.Core;
using DotNet.WinForm.Controls;
using DotNet.WinForm;
using ResourceManage;
using XCode;
using XCode.DataAccessLayer;
using ResouceEntity;
#endregion

namespace AsxinyuPlateForm
{
    public partial class MainForm : Form
    {
        #region 常规事件
        public MainForm()
        {
            InitializeComponent();
        }
        string AssemblyName = "";
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 数据转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertDB.CreateForm().Show();
        }

        private void ed2k链接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams("", typeof(tb_resoucelink));
            CP.IsEnableAddBtn = false;
            CP.IsEnablePaging = true;
            CP.IsEnableAddBtn = false;
            FormModel frm = DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region 页面数据管理----核心
        private static DataManage _pageDM;
        //过滤管理窗体
        public static DataManage FilterDM
        {
            get
            {
                if (_pageDM == null)
                    _pageDM = new DataManage();
                _pageDM.Disposed += new EventHandler(dm_Disposed);//单例模式解决无法访问的问题
                return _pageDM;
            }
            set { _pageDM = value; }
        }
        public static void dm_Disposed(object sender, EventArgs e)
        {
            _pageDM = null;
        }
        private void 页面管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams("", typeof(tb_resoucepageslist));
            CP.IsEnableAddBtn = false;
            CP.IsEnablePaging = true;            
            SetFilterDM(CP);//设置控件
            FormModel frm = WinFormHelper.GetControlForm(FilterDM, "资源页面管理");// DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            frm.MdiParent = this;
            frm.Show();
        }
        /// <summary>
        /// 设置控件的菜单及相关属性
        /// </summary>
        /// <param name="CP"></param>
        private void SetFilterDM(DataControlParams CP)
        {
            //增加菜单的相关代码,
            //TODO:增加单独记录的验证功能
            string[] menuNames = { "ValidateCurrent", "CrossValidate", "Filter", "Remove", "SaveProject" };
            string[] dispTexts = { "验证当前", "交叉验证", "过滤", "移除记录", "保存方案" };
            //EventHandler[] eventNames ={ FilterDmHelper .toolStripValidateOneRule,
            //                               FilterDmHelper.toolStripCrossValidate_Click,
            //            FilterDmHelper.toolStripFilter_Click,
            //            FilterDmHelper.toolStripRemove_Click,
            //            FilterDmHelper.toolStripSaveProject_Click}; //保存方案
            //默认的集成不能完成，需要修改生成的主窗体
            FilterDM.InitializeSettings(CP);
            FilterDM.Name = "dm";
            FilterDM.Dock = DockStyle.Fill;
            //FilterDM.AppendedMenu = WinFormHelper.GetContextMenuStrip(menuNames, dispTexts, eventNames);
        }
        #endregion
    }
}
