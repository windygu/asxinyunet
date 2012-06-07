#region 
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
using WHC.Pager.WinControl;
#endregion

namespace DotNet.WinForm.Controls
{
    /// <summary>
    /// 通用数据管理控件
    /// //TODO:还需要考虑一种外部数据加载进来,只单纯的显示和分页的情况，即数据显示用
    /// 2012-06-7 住朋网项目定制控件
    /// </summary>
    public partial class ZP365DataManage : UserControl
    {
        #region 初始化
        public ZP365DataManage()
        {
            InitializeComponent();
        }        
        /// 初始化配置,传入配置信息类
        /// </summary>
        public virtual void InitializeSettings(DataControlParams controlParams)
        {
            ControlParams = controlParams;//先设置属性
            InitialDgvMenu();//Dgv右键菜单
            InitialDgvDynamicSum();//单元格动态求和
            Initial();//其他配置
            InitialDgvColumns(ControlParams.ColumnsBandingList );//配置dgv列
        }        
        #endregion

        #region 字段
        /// <summary>
        /// 窗体标题文本,也可以用于打印
        /// </summary>
        public string Title;
        /// <summary>
        /// 实体列表
        /// </summary>
        public IEntityList btList; //List<IEntity>

        /// <summary>
        /// 当前查询字符串,初始为空
        /// </summary>
        public string cutSql;

        /// <summary>
        /// 实体操作对象
        /// </summary>
        public IEntityOperate EntityOper;
        /// <summary>
        /// 配置参数,主要参数都在此
        /// </summary>
        public DataControlParams ControlParams;
                
        #endregion

        #region 静态方法
        /// <summary>
        /// 创建数据管理窗体
        /// </summary>
        /// <param name="controlParams">控件参数</param>
        /// <returns>数据管理控件的窗体</returns>
        public static FormModel CreateForm(DataControlParams controlParams)
        {
            ZP365DataManage dm = new ZP365DataManage();
            dm.InitializeSettings(controlParams);
            dm.Name = "dm";
            dm.Dock = DockStyle.Fill;
            FormModel tf = new FormModel();
            tf.Size = new Size(dm.Width + 15, dm.Size.Height + 40);
            tf.Controls.Add(dm);//将控件添加到窗体中            
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            return tf;
        }
        
        #endregion

        #region 右键菜单配置
        /// <summary>
        /// 初始化Dgv右键菜单:修改和删除
        /// </summary>
        public virtual void InitialDgvMenu()
        {
            //配置菜单,这一功能提供让在基类中实现,提供基本的增删查改等常规菜单代码
            if (ControlParams.IsEnableMenu)
            {
                dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                        new string[] { "Edit", "Delete" }, new string[] { "修改记录", "删除记录" },
                        new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
            }
        }
        /// <summary>
        /// 添加外部菜单
        /// </summary>
        public ContextMenuStrip AppendedMenu
        {
            get { return this.dgv.ContextMenuStrip ;}
            set
            {
                if (value != null)
                {
                    int count = value.Items.Count;
                    for (int i = 0; i< count ; i++)
                    {
                        this.dgv.ContextMenuStrip.Items.Add (value.Items[0]);
                    }                    
                }
            }
        }
        #endregion

        #region Dgv动态求和
        /// <summary>
        /// Dgv单元格动态求和功能配置
        /// </summary>
        protected void InitialDgvDynamicSum()
        {
            //动态求和设置
            if (ControlParams.IsEnableSelectSum)
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
        protected virtual void dgv_SelectionChanged(object sender, EventArgs e)
        {
            stausInfoShow1.SetToolInfo2("和值:" + WinFormHelper.GetDynamicSecletedInfo(dgv)[0].ToString());
        }
        #endregion

        #region 其他配置,分页，数据操作对象等
        /// <summary>
        /// 初始化其他属性
        /// </summary>
        protected virtual void Initial()
        {
            this.winPage.PageSize = ControlParams.PageSize;//设置每页数目
            if (ControlParams.EntityType != null)
            {
                this.EntityOper = EntityFactory.CreateOperate(ControlParams.EntityType);               
            }
            this.winPage.Visible = ControlParams.IsEnablePaging;
            if (!ControlParams.IsEnablePaging )
            {
                //不分页,这隐藏掉分页控件
                this.splitContainer1.SplitterDistance = this.Size.Height - stausInfoShow1.Height;
            }
            this.cutSql = "";            
        }
        #endregion

        #region 获取分页事件所需要的当前数据
        /// <summary>
        /// 获取分页事件所需要的当前数据
        /// </summary>
        public virtual void GetData()
        {
            //开启分页的情况下
            if (ControlParams.IsEnablePaging)
            {
                winPage.RecordCount = EntityOper.FindCount(cutSql, "", "", 0, 0);//获取当前查询的记录总数
                btList = EntityOper.FindAll(cutSql, "", "", (winPage.PageIndex - 1) * winPage.PageSize,
                                            winPage.PageSize);
                //更新分页显示数据

            }
            else //不需要分页的情况下
                btList = EntityOper.FindAll(cutSql, "", "", 0, 0);           
            ArrayList list = new ArrayList();
            for (int i = 0; i < btList.Count; i++) list.Add(btList[i]);            
            dgv.DataSource = list;
            //每次移除不需要的列
            if (ControlParams.DeleteColumnsName !=null )
            {
                foreach (string item in ControlParams.DeleteColumnsName)
                {
                    if (dgv.Columns.Contains(item)) dgv.Columns.Remove(item);
                }
            }
        }
        #endregion
             
        #region 右键菜单事件
        /// <summary>
        /// 右键菜单-编辑修改事件
        /// </summary>       
        protected virtual void toolStripMenuEdit_Click(object sender, EventArgs e)
        {
            if (ControlParams.IsEnableMenu  && dgv.CurrentCell != null)
            {
                dgv.BeginEdit(false);
            }
        }
        /// <summary>
        /// 右键菜单删除事件
        /// </summary>       
        protected virtual void toolStripMenuDelete_Click(object sender, EventArgs e)
        {
            if (!ControlParams.IsEnableMenu) return;//是否非法删除,没有权限则不能操作
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
                    GetData();//刷新
                }
                else return;
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format(DotNet.Core.Exceptions.ErrorCode.Db_DeleteError,err.Message ));
            }
            //ToolFindClick(sender, e);
        }
        #endregion

        #region 工具栏按钮事件
        //数据分页事件
        private void winPage_PageIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }        
        #endregion                

        #region 数据显示格式,及单元格下拉列表框设置
        /// <summary>
        /// 初始化Dgv的列
        /// </summary>
        /// <param name="NamesAndBangdingSource">需要绑定是数据的列,这里仅为CombBox列</param>
        protected virtual void InitialDgvColumns(Dictionary<string,string[]> NamesAndBangdingSource)
        {
            //根据实体的信息,来添加列,并除去不必要的列removeColumnsName
            if (NamesAndBangdingSource ==null )
            {
                return;
            }
            foreach (var item in EntityOper.Table.Fields )
            {
                //if (removeColumnsName.Contains(item.Name)) continue;//是删除对象则继续下一条
                //逐一根据类型添加
                if (item.Name.Contains ("Type")||item.Name.Contains ("TP"))
                {
                    string[] list = new string[1] ;
                    if(NamesAndBangdingSource.ContainsKey (item.Name )) list = NamesAndBangdingSource[item.Name ];
                    //列宽是固定的,也可以考虑做成配置的
                    DataGridViewComboBoxColumn dc = WinFormHelper.CreateDgvComboBox(list, item.Name, item.Description, item.Type, 100);
                    this.dgv.Columns.Add(dc);
                }
                else if (item.Type == typeof(bool))
                {
                    DataGridViewCheckBoxColumn dc = WinFormHelper.CreateDgvCheckBox(item.Name, item.Description);
                    this.dgv.Columns.Add(dc);
                }
                else //全是TextBox类型
                {
                    DataGridViewTextBoxColumn dt = WinFormHelper.CreateDgvTextBox(item.Name, item.Description, item.Type, 100);
                    this.dgv.Columns.Add(dt);
                }
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //不做任何处理
        }
        #endregion              

        #region 设置数据行的提示信息
        private void SetCellToolTipText(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgv.Rows[e.RowIndex].Cells.Count; i++)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendFormat("行数据基本信息：\r\n\t", new object[0]);
                    for (int j = 0; j < this.dgv.Rows[e.RowIndex].Cells.Count; j++)
                    {
                        if (this.dgv.Columns[j].Visible)
                        {
                            DataGridViewCell cell = this.dgv.Rows[e.RowIndex].Cells[j];
                            builder.AppendFormat("{0}：{1}\r\n\t", this.dgv.Columns[j].HeaderText, cell.Value);
                        }
                    }
                    this.dgv[i, e.RowIndex].ToolTipText = builder.ToString();
                }                    
            }
            catch
            {
            }
        }      
        //离开当前行后
        private void dgv_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < this.dgv.Rows[e.RowIndex].Cells.Count; i++)
            {
                this.dgv[i, e.RowIndex].ToolTipText = string.Empty;
            }
        }
        #endregion
    }
}