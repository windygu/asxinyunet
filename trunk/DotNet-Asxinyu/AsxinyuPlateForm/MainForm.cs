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
using System.Threading.Tasks;
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
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 数据转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertDB.CreateForm().Show();
        }

        private static DataManage _linkDM;
        //过滤管理窗体
        public static DataManage LinkDM
        {
            get
            {
                if (_linkDM == null)
                    _linkDM = new DataManage();
                _linkDM.Disposed += new EventHandler(link_Disposed);//单例模式解决无法访问的问题
                return _linkDM;
            }
            set {_linkDM = value; }
        }
        public static void link_Disposed(object sender, EventArgs e)
        {
            _linkDM = null;
        }
        private void ed2k链接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataControlParams CP = new DataControlParams("", typeof(tb_resoucelink));
            CP.IsEnableAddBtn = false;
            CP.IsEnablePaging = true;
            CP.IsEnableAddBtn = false;
            CP.DeleteColumnsName = new string[] {tb_resoucelink._.FromURL,tb_resoucelink._.ResouceLink ,
                tb_resoucelink._.ResouceMD5,tb_resoucelink._.ClassName };
            SetEd2kFormDM(CP);//DotNet.WinForm.Controls.DataManage.CreateForm(CP);
            FormModel frm = WinFormHelper.GetControlForm(LinkDM, "Ed2k链接管理");
            frm.MdiParent = this;
            frm.Show();
        }
        void SetEd2kFormDM(DataControlParams CP)
        {          
            string[] menuNames = {"OutPutDownLink"};
            string[] dispTexts = {"导出链接" };
            EventHandler[] eventNames = {(object sender, EventArgs e)=>{
                                            List<int> Ids = new List<int>();
                                            for (int i = 0; i < LinkDM.dgv.Rows.Count; i++)
                                            {
                                                Ids.Add(Convert.ToInt32(LinkDM.dgv.Rows[i].Cells[0].Value.ToString()));
                                            }
                                            VeryCdResouce.ExportLinkToLst("",Ids);
                                            MessageBox.Show("导出列表成功!");}
                                        }; 
            //默认的集成不能完成，需要修改生成的主窗体
            LinkDM.InitializeSettings(CP);
            LinkDM.Name = "ed2kdm";
            LinkDM.Dock = DockStyle.Fill;
            LinkDM.AppendedMenu = WinFormHelper.GetContextMenuStrip(menuNames, dispTexts, eventNames);
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
            CP.DeleteColumnsName = new string[] {tb_resoucepageslist._.PageURL ,tb_resoucepageslist._.ResouceType,
            tb_resoucelink._.ClassName };
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
            string[] menuNames = { "ScanContentPage", "ScanListPage", "AnalysisPageList", "AnalysisPage", "ResetCollectionMark"};
            string[] dispTexts = { "扫描内容首页", "扫描列表页面", "分析列表页面", "扫描页面链接","重置错误页面"};
            EventHandler[] eventNames ={(object sender, EventArgs e)=>{ Task.Factory.StartNew(() =>{VeryCdResouce.ScanPageContent();});},
                                        (object sender, EventArgs e)=>{ Task.Factory.StartNew(() =>{VeryCdResouce.ScanPageList();});},
                                        (object sender, EventArgs e)=>{ Task.Factory.StartNew(() =>{VeryCdResouce.StartCollectResoucePages();});},    
                                        (object sender, EventArgs e)=>{ Task.Factory.StartNew(() =>{VeryCdResouce.StartCollectResouceDownLoadLink();});},                                       
                                        (object sender, EventArgs e)=>{VeryCdResouce.ResetPageCollectionMark ();}                                                                             
                                       };
            //默认的集成不能完成，需要修改生成的主窗体
            FilterDM.InitializeSettings(CP);
            FilterDM.Name = "dm";
            FilterDM.Dock = DockStyle.Fill;            
            FilterDM.AppendedMenu = WinFormHelper.GetContextMenuStrip(menuNames, dispTexts, eventNames);            
        }
        #endregion
    }
}
