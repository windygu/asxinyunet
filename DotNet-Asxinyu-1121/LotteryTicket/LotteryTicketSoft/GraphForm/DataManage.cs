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
using LotteryTicket;
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
                        new string[] { "Edit", "Delete", "Validate","CrossValidate","Filter" }, new string[] { "修改", "删除", "验证", "交叉验证", "过滤" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click,
                        toolStripStatics_Click,toolStripCrossValidate_Click,toolStripFilter_Click});
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
                this.EntityOper = EntityFactory.CreateOperate(controlParams.EntityType);
            }
            this.winPage.Visible = controlParams.IsEnablePaging;
            this.cutSql = "";
            InitialDataGridView();
        }
        #endregion

        #region 分页事件--获取数据
        //分页事件-得到数据
        void GetData()
        {
            BindingSource bs = new BindingSource();
            //开启分页的情况下
            if (ControlParams.IsEnablePaging)
            {
                btList = EntityOper.FindAll(cutSql, tb_Rules._.Id + " asc", "",
                    (winPage.PageIndex - 1) * winPage.PageSize, winPage.PageSize);
            }
            else //不需要分页的情况下
            {
                btList = EntityOper.FindAll(cutSql, tb_Rules._.Id + " asc", "", 0, 0);
            }
            for (int i = 0; i < btList.Count; i++) bs.Add(btList[i]);
            dgv.DataSource = bs;//绑定数据
            //移除不需要的列，可以设置为一个开关，根据需要是否打开
            if (dgv.Columns.Contains(tb_Rules._.Remark.Description))
            {
                dgv.Columns.Remove(tb_Rules._.Remark.Description);
            }
            if (dgv.Columns.Contains(tb_Rules._.Remark.Name ))
            {
                dgv.Columns.Remove(tb_Rules._.Remark.Name);
            }
           
        }
        /// <summary>
        /// 初始化，格式控制
        /// </summary>
        void InitialDataGridView()
        {
            //现在初始化列   
            DataGridViewTextBoxColumn tb1 = CreateTextBoxWithNames(tb_Rules._.Id, tb_Rules._.Id.Description);
            tb1.Width = 60;
            dgv.Columns.Add(tb1);
            DataGridViewComboBoxColumn tb2 = CreateComboBoxWithNames(LotTicketHelper.GetAllIndexFuncNames(), tb_Rules._.IndexSelectorNameTP, tb_Rules._.IndexSelectorNameTP.Description);
            tb2.Width = 140;
            dgv.Columns.Add(tb2);
            DataGridViewComboBoxColumn tb3 = CreateComboBoxWithNames(LotTicketHelper.GetAllEnumNames<CompareType>(), tb_Rules._.CompareRuleNameTP, tb_Rules._.CompareRuleNameTP.Description);
            tb3.Width = 140;
            dgv.Columns.Add(tb3);
            DataGridViewTextBoxColumn tb4 = CreateTextBoxWithNames(tb_Rules._.RuleCompareParams, tb_Rules._.RuleCompareParams.Description);
            tb4.Width = 160;
            dgv.Columns.Add(tb4);
            DataGridViewTextBoxColumn tb5 = CreateTextBoxWithNames(tb_Rules._.DataRows, tb_Rules._.DataRows.Description);
            tb5.Width = 80;
            dgv.Columns.Add(tb5);
            DataGridViewTextBoxColumn tb6 = CreateTextBoxWithNames(tb_Rules._.CorrectRate, tb_Rules._.CorrectRate.Description);
            tb6.Width = 80;
            dgv.Columns.Add(tb6);
            DataGridViewTextBoxColumn tb7 = CreateTextBoxWithNames(tb_Rules._.FilterInfo, tb_Rules._.FilterInfo.Description);
            tb7.Width = 80;
            dgv.Columns.Add(tb7);
            DataGridViewTextBoxColumn tb8 = CreateTextBoxWithNames(tb_Rules._.UpdateTime, tb_Rules._.UpdateTime.Description);
            tb8.Width = 120;
            dgv.Columns.Add(tb8);
            DataGridViewTextBoxColumn tb9 = CreateTextBoxWithNames(tb_Rules._.Remark, tb_Rules._.Remark.Description);
            tb9.Width = 60;
            dgv.Columns.Add(tb9);
            dgv.Columns.Remove(tb_Rules._.Remark.Description);
        }
        DataGridViewComboBoxColumn CreateComboBoxWithNames(List<string> dataSource, string dataPropertyName, string DispalyName)
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = dataSource;
            combo.DataPropertyName = dataPropertyName;
            combo.Name = DispalyName;
            return combo;
        }
        DataGridViewTextBoxColumn CreateTextBoxWithNames(string dataPropertyName, string DispalyName)
        {
            DataGridViewTextBoxColumn combo = new DataGridViewTextBoxColumn();
            combo.DataPropertyName = dataPropertyName;
            combo.Name = DispalyName;
            return combo;
        }
        #endregion

        #region 右键菜单事件
        #region 右键编辑与删除
        //右键编辑修改
        private void toolStripMenuEdit_Click(object sender, EventArgs e)
        {
            if (ControlParams.IsHaveMenu && dgv.CurrentCell != null)
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

        #region 交叉验证
        private void toolStripCrossValidate_Click(object sender, EventArgs e)
        {
            double res = LotTicketHelper.CrossValidateRules(dgv);
            this.stausInfoShow1.SetToolInfo2("交叉验证概率(%):"+(res * 100).ToString("F4"));
        }
        #endregion

        #region 右键预测与过滤
        //右键预测验证频率
        private void toolStripStatics_Click(object sender, EventArgs e)
        {
            //循环读取当前列表中的规则
            LotTicketHelper.CalculateCurrentRow(this.dgv);
        }
        //右键过滤
        private void toolStripFilter_Click(object sender, EventArgs e)
        {
            LotTicketHelper.FilterAllRows(this.dgv, LotTicketHelper.GetInitiaData());
        }
        #endregion
        #endregion

        #region 添加 查找 退出
        //添加
        void ToolAddClick(object sender, EventArgs e)
        {
            //关键代码,添加对象按钮可用,则再次通过反射，动态加载一个添加控件的窗体对象
            if (ControlParams.IsEnableAddBtn)
            {
                //是否可提出为一个单独的静态方法
                Assembly assembly = Assembly.LoadFrom(ControlParams.ControlAssemblyName);
                Type T = assembly.GetType(ControlParams.ControlName);
                IEntityControl obj = (IEntityControl)Activator.CreateInstance(T, null);
                obj.InitializeSettings(this.ControlParams);//参数也放到一起去
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
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
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
        //参数配置界面
        private void toolStripSetting_Click(object sender, EventArgs e)
        {
            //增加参数配置界面,形成一个窗体
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