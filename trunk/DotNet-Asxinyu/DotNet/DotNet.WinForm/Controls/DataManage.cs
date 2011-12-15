﻿#region 
/*
 * 作者：asxinyu
 * 时间：2011-09-30 11:54:03
 * 版权：版权所有 (C) asxinyu 2011
 * 联系：asxinyu@qq.com
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using XCode;
using NewLife;
using NewLife.Reflection;
#endregion

namespace DotNet.WinForm.Controls
{
    /// <summary>
    /// 通用数据管理控件
    /// 
    /// 2011-12-15 进一步优化操作，重构代码和增加配置窗体功能
    /// 2011-11-20 完成基本功能,基本数据浏览，修改等操作
    /// </summary>
    public partial class DataManage : UserControl
    {
        #region 初始化,属性及字段
        public DataManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 实体列表
        /// </summary>
        protected IEntityList btList; //List<IEntity>

        /// <summary>
        /// 当前查询字符串,初始为空
        /// </summary>
        protected string cutSql;
        
        /// <summary>
        /// 实体操作对象
        /// </summary>
        public IEntityOperate EntityOper { get; set; }
       
        /// <summary>
        /// 初始化配置,传入配置信息类
        /// </summary>
        public virtual void InitializeSettings(DataControlParams controlParams)
        {
            ControlParams = controlParams;//先设置属性
            InitialDgvMenu();//Dgv右键菜单
            InitialDgvDynamicSum();//单元格动态求和
            Initial();//其他配置
        }        
        #endregion

        #region 静态字段
        /// <summary>
        /// 配置参数,主要参数都在此
        /// </summary>
        protected static DataControlParams ControlParams;
        /// <summary>
        /// 用于配置条件窗体
        /// </summary>
        protected static string TableName;

        /// <summary>
        /// 添加实体窗体对象
        /// </summary>
        protected static FormModel AddForm;

        /// <summary>
        /// 搜索窗体对象
        /// </summary>
        protected static FormModel SeachFm;

        /// <summary>
        /// 相关的配置参数字典类
        /// </summary>
        protected static ConfigDictionary Items;
        #endregion

        #region 静态方法
        /// <summary>
        /// 创建数据管理窗体
        /// </summary>
        /// <param name="controlParams">控件参数</param>
        /// <returns>数据管理控件的窗体</returns>
        public static FormModel CreateForm(DataControlParams controlParams)
        {
            DataManage dm = new DataManage();
            dm.InitializeSettings(controlParams);
            dm.Name = "dm";
            dm.Dock = DockStyle.Fill;
            FormModel tf = new FormModel();
            tf.Size = new Size(dm.Width + 15, dm.Size.Height + 40);
            tf.Controls.Add(dm);//将控件添加到窗体中            
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            return tf;
        }

        /// <summary>
        /// 获取添加实体窗体
        /// </summary>
        /// <returns>窗体对象</returns>
        public static FormModel GetAddForm()
        {
            if (AddForm == null)
            {
                Assembly assembly = Assembly.LoadFrom(ControlParams.ControlAssemblyName);
                Type T = assembly.GetType(ControlParams.ControlName);
                MethodInfo mi = T.GetMethod("CreateForm");
                AddForm = (FormModel)mi.Invoke(null, new object[] { ControlParams });
            }
            return AddForm;
        }       
        /// <summary>
        /// 获取搜索窗体
        /// </summary>
        /// <returns></returns>
        public static FormModel GetSearchForm()
        {
            if (SeachFm == null)
            {
                SeachFm = SearchCondition.CreateForm(TableName);
            }
            return SeachFm;
        }
        #endregion

        #region 各个功能模块实现
        #region 右键菜单配置
        /// <summary>
        /// 初始化Dgv右键菜单
        /// </summary>
        public virtual void InitialDgvMenu()
        {
            //配置菜单,这一功能提供让在基类中实现,提供基本的增删查改等常规菜单代码
            if (ControlParams.IsHaveMenu)
            {
                dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                        new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
            }
        }

        #endregion

        #region Dgv动态求和
        /// <summary>
        /// Dgv单元格动态求和功能配置
        /// </summary>
        public virtual void InitialDgvDynamicSum()
        {
            //动态求和设置
            if (ControlParams.IsHaveSelectSum)
            {
                this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
                this.stausInfoShow1.SetToolInfo1(ControlParams.FirStatusInfo);
                this.stausInfoShow1.SetToolInfo3(ControlParams.ThirdStatusInfo);
            }
            else
            {
                this.stausInfoShow1.SetToolInfo1(ControlParams.FirStatusInfo);
                this.stausInfoShow1.SetToolInfo2(ControlParams.SecStatusInfo);
                this.stausInfoShow1.SetToolInfo3(ControlParams.ThirdStatusInfo);
            }            
        }       
        #endregion

        #region 其他配置,分页，数据操作对象等
        public virtual void Initial()
        {
            this.winPage.PageSize = ControlParams.PageSize;
            if (ControlParams.EntityType != null)
            {
                this.EntityOper = EntityFactory.CreateOperate(ControlParams.EntityType);
                TableName = EntityOper.TableName;
            }
            this.winPage.Visible = ControlParams.IsEnablePaging;
            this.cutSql = "";
        }
        #endregion

        #region
        #endregion

        #region
        #endregion
        #endregion

        #region 分页事件--获取数据
        //分页事件-得到数据
        void GetData()
        {
            //开启分页的情况下
            if (ControlParams.IsEnablePaging)
            {
                btList = EntityOper.FindAll(cutSql, "", "", (winPage.PageIndex - 1) * winPage.PageSize,
                                            winPage.PageSize);
               // btList = temp.ToList(); 
            }
            else //不需要分页的情况下
            {
                btList = EntityOper.FindAll(cutSql, "", "", 0, 0);//.ToList()               
            }
            dgv.DataSource = btList;
            ArrayList list = new ArrayList();
            for (int i = 0; i < btList.Count; i++)
            {
                list.Add(btList[i]);
            }
            dgv.DataSource = list;            
        }
        #endregion

        #region 菜单事件
        //右键编辑修改
        private void toolStripMenuEdit_Click(object sender, EventArgs e)
        {
            if (ControlParams.IsHaveMenu  && dgv.CurrentCell != null)
            {
                dgv.BeginEdit(false);
            }
        }
        //右键删除
        private void toolStripMenuDelete_Click(object sender, EventArgs e)
        {
            if (!ControlParams.IsHaveMenu) return;
            try
            {
                if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    int count = dgv.SelectedCells.Count;
                    List<int> index = new List<int>();
                    for (int i = 0; i < count; i++)
                    {
                        int RowIndex = dgv.SelectedCells[i].RowIndex;
                        if (!index.Contains(RowIndex)) btList[RowIndex].Delete();
                    }
                }
                else
                    return;
            }
            catch (Exception err)
            {
                MessageBox.Show("删除出错:" + err.Message);
            }
            ToolFindClick(sender, e);
        }
        #endregion

        #region 添加 查找 退出
        //添加
        void ToolAddClick(object sender, EventArgs e)
        {           
            if (ControlParams.IsEnableAddBtn )
            {
                //是否可提出为一个单独的静态方法
                GetAddForm().ShowDialog();          
            }
        }
        void ToolFindClick(object sender, EventArgs e)
        {
            GetData();
        }
        void ToolExitClick(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion

        #region 按钮事件--搜索--查询条件
        //搜索事件
        void BtnSearchClick(object sender, EventArgs e)
        {
            GetData();
        }
        //设置查询条件
        void ToolExportToExcelClick(object sender, EventArgs e)
        {
            FormModel fm = GetSearchForm();                                   
            if (fm.ShowDialog() == DialogResult.OK)
            {    //从fm中取出一个搜索窗体控件       
                SearchCondition sf = ((SearchCondition)fm.Controls.Find("SC", false)[0]);
                cutSql = sf.CurConditions;
                //在此更新所有记录信息
                winPage.RecordCount = EntityOper.FindCount(cutSql, "", "", 0, 0);
                GetData();
            }
        }       
        //数据分页事件
        private void winPage_PageIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }
        #endregion

        #region 求和操作
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            stausInfoShow1.SetToolInfo2("和值:" + WinFormHelper.GetDynamicSecletedInfo(dgv)[0].ToString());
        }
        #endregion

        #region 参数配置界面
        private void toolStripSetting_Click(object sender, EventArgs e)
        {
            if (ControlParams.SettingFileName==null )
            {
                string direct = Application.StartupPath + @"\Setting\";
                ControlParams.SettingFileName = direct + EntityOper.Table.TableName + "-配置.xml";
                if (!Directory.Exists(direct))
                    Directory.CreateDirectory(direct);
            }
            ConfigSetting.CreateForm(ControlParams.SettingFileName).ShowDialog ();
            //需要将配置文件的字典值进行动态的更新才行,需要设置一个静态变量
            Items = ConfigDictionary.Create (ConfigSetting.LoadDic(ControlParams.SettingFileName));//重新加载一遍           
        }
        #endregion       
    }
}