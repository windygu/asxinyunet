#region 
/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-09-30 11:54:03
 * 版权：版权所有 (C) 新生命开发团队 2011
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet.Tools.Controls;
using XCode;
using NewLife;
using NewLife.Reflection;
#endregion

namespace LotteryTicketSoft.GraphForm
{
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
        IEntityList btList; //List<IEntity>

        /// <summary>
        /// 当前查询字符串,初始为空
        /// </summary>
        string cutSql;
        /// <summary>
        /// 配置参数,主要参数都在此
        /// </summary>
        public DataControlParams ControlParams { get; set; }

        /// <summary>
        /// 实体操作
        /// </summary>
        public IEntityOperate EntityOper { get; set; }
        
        /// <summary>
        /// 初始化配置,传入配置信息类
        /// </summary>
        public void InitializeSettings(DataControlParams controlParams)
        {
            this.ControlParams = controlParams;//先设置属性
            //配置菜单
            if (controlParams.IsHaveMenu)
            {
                dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                        new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });                
            }
            //动态求和设置
            if (controlParams.IsHaveSelectSum)
            {
                this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
                this.stausInfoShow1.SetToolInfo1(controlParams.FirStatusInfo);
                this.stausInfoShow1.SetToolInfo3(controlParams.ThirdStatusInfo);
            }
            else
            {
                this.stausInfoShow1.SetToolInfo1(controlParams.FirStatusInfo);
                this.stausInfoShow1.SetToolInfo2(controlParams.SecStatusInfo);
                this.stausInfoShow1.SetToolInfo3(controlParams.ThirdStatusInfo);
            }
            this.winPage.PageSize = controlParams.PageSize;
            if (controlParams.EntityType != null)
            {
                this.EntityOper  = EntityFactory.CreateOperate(controlParams.EntityType);                
                //string maininfo = EntityOper.Table.Description;
            }
            this.winPage.Visible = controlParams.IsEnablePaging;
            this.cutSql = "";
        }
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
            //关键代码,添加对象按钮可用,则再次通过反射，动态加载一个添加控件的窗体对象
            if (ControlParams.IsEnableAddBtn )
            {
                //是否可提出为一个单独的静态方法
                Assembly assembly = Assembly.LoadFrom(ControlParams.ControlAssemblyName);
                Type T = assembly.GetType(ControlParams.ControlName);
                IEntityControl obj = (IEntityControl)Activator.CreateInstance(T, null);
                obj.InitializeSettings(this.ControlParams );//参数也放到一起去
                UserControl EntityControl = (UserControl)obj;
                EntityControl.Dock = System.Windows.Forms.DockStyle.Fill;
                EntityControl.Location = new System.Drawing.Point(0, 0);
                EntityControl.Name = "EntityControl";
                EntityControl.TabIndex = 0;                
                FormModel tf = new FormModel();
                tf.Size = new Size(EntityControl.Width + 10, EntityControl.Size.Height + 35);
                tf.Controls.Add(EntityControl);//将控件添加到窗体中            
                tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                tf.Show();
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
            SearchConditionForm sf = new SearchConditionForm();
            sf.CutEntityName = EntityOper.TableName;
            sf.CurConditions = cutSql;
            if (sf.ShowDialog() == DialogResult.OK)
            {
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

        #region 废弃代码---很有参考价值
        //IListSource ls=btList as IListSource ;
        //dgv.DataSource = ls.GetList(); ;// btList ;
        //Type type = typeof(EntityList<>).MakeGenericType(_entityType);
        //IList list = TypeX.CreateInstance(type) as System.Collections.IList;	
        //获取数据并绑定到dgv    列的 SortMode 不能设置为 Automatic。
        //List<IEntity> btlist;
        //IEntityList btList; //实体列表
        #endregion
    }
}