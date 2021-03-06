﻿/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-18
 * 时间: 11:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using XCode;
using XCode.DataAccessLayer;
using DotNet.WinForm.Controls;

namespace DotNet.WinForm
{
    #region 字典集合类-为配置窗体特有
    /// <summary>
    /// 配置信息字典
    /// </summary>
    public class ConfigDictionary
    {
        /// <summary>
        /// 字典集合
        /// </summary>
        public Dictionary<string, string> Items { get; set; }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        public static ConfigDictionary Create(Dictionary<string, string> dic)
        {
            ConfigDictionary cd = new ConfigDictionary();
            cd.Items = dic;
            return cd;
        }
        /// <summary>
        /// 根据key获取对应的值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">key</param>
        /// <returns>返回值</returns>
        public string GetStringValueByKey(string key)
        {
            return Items.ContainsKey(key) ? Items[key] : string.Empty;         
        }
        public int GetIntValueByKey(string key)
        {
            return Items.ContainsKey(key) ? Convert.ToInt32(Items[key]) : -1 ;
        }    
    }
    #endregion

    #region 实体控件中当前实体的状态
    /// <summary>
    /// 控件状态：清空，只读，修改
    /// </summary>
    public enum ControlStatus
    {
        /// <summary>
        /// 清空控件
        /// </summary>
        ReSet,
        /// <summary>
        /// 修改控件内容
        /// </summary>
        Edit,
        /// <summary>
        /// 只读
        /// </summary>		
        ReadOnly
    }
    /// <summary>
    /// 实体控件窗体的显示类型
    /// </summary>
    public enum FormShowMode
    {
        /// <summary>
        /// 连续添加
        /// </summary>
        ContinueAdd,
        /// <summary>
        /// 只添加一次
        /// </summary>
        AddOne,
        /// <summary>
        /// 连续显示,可编辑
        /// </summary>
        ContinueDisplay,
        /// <summary>
        /// 显示当前一条实体,可编辑
        /// </summary>
        DisplayCurrent,
        /// <summary>
        /// 连续只读浏览
        /// </summary>
        ReadOnlyForAll,
        /// <summary>
        /// 当前一条实体只读显示
        /// </summary>
        ReadOnlyForOne
    }
    #endregion

    #region 实体接口
    public interface IEntityControl
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void InitializeSettings(DataControlParams controlParams);
    }
    #endregion

    #region 通用管理界面控件的参数类:参数设置好,以后只需要传入一个类型对象即可
    /// <summary>
    /// 通用管理界面控件的参数类
    /// </summary>
    public class DataControlParams
    {
        #region 程序集和实体类型
        /// <summary>
        /// 添加实体控件所在程序的名称
        /// </summary>
        public string ControlAssemblyName { get; set; }

        /// <summary>
        /// 控件的类型名称
        /// </summary>
        public string ControlName { get; set; }
                
        /// <summary>
		/// 实体类型
		/// </summary>
        public Type EntityType { get; set; }
        #endregion

        #region 工具栏可用性
        /// <summary>
        /// 是否使得添加按钮可用，默认：可用
        /// </summary>
        public bool IsEnableAddBtn { get; set; }
        
        /// <summary>
        /// 是否开启搜索窗体，默认：可用
        /// </summary>
        public bool IsEnableSearchBtn { get; set; }
        /// <summary>
        /// 是否开启配置窗体，默认：可用
        /// </summary>
        public bool IsEnableSettingBtn { get; set; }
        /// <summary>
        /// 是否开启打印功能，默认：可用
        /// </summary>
        public bool IsEnablePrintBtn { get; set; }
        #endregion

        #region 标题、状态栏等
        /// <summary>
        /// 窗体标题文本,默认：集中数据管理
        /// </summary>
        public string FormText { get; set; }

        /// <summary>
        /// 底部状态栏 第一个的显示信息
        /// </summary>
        public string FirStatusInfo { get; set; }

        /// <summary>
        /// 底部状态栏 第二个的显示信息
        /// </summary>
        public string SecStatusInfo { get; set; }

        /// <summary>
        /// 底部状态栏 第三个的显示信息
        /// </summary>
        public string ThirdStatusInfo { get; set; }        
        #endregion

        #region 菜单、分页控件
        /// <summary>
        /// 是否开启右键菜单，默认开启
        /// </summary>
        public bool IsEnableMenu { get; set; }               

        /// <summary>
        /// 是否开启鼠标选择动态求和功能：默认关闭
        /// </summary>
        public bool IsEnableSelectSum { get; set; }

        /// <summary>
        /// 是否开启分页功能：默认关闭
        /// </summary>
        public bool IsEnablePaging { get; set; }

        /// <summary>
        /// 开启分页后，每页的记录数,默认20
        /// </summary>
        public int PageSize { get; set; }
        #endregion

        #region 子窗体属性
        /// <summary>
        /// 添加窗体的标题，默认：添加数据
        /// </summary>
        public string AddFormTitleText { get; set; }

        /// <summary>
        /// 添加实体窗体的显示模式
        /// </summary>
        public FormShowMode AddFormShowMode { get; set; }
        /// <summary>
        /// 添加窗体的搜索字符串
        /// </summary>
        public string AddFormSearchString { get; set; }

        /// <summary>
        /// 配置文件名称
        /// </summary>
        public string SettingFileName { get; set; }

        #endregion

        #region Dgv 格式控制
        /// <summary>
        /// 不需要显示的列的名称,默认都显示
        /// </summary>
        public string[] DeleteColumnsName { get; set; }
        /// <summary>
        /// 需要绑定的列的数据源，键值对(列名：字符串数组)
        /// </summary>
        public Dictionary<string, string[]> ColumnsBandingList { get; set; }
        #endregion

        #region  初始化方法--分开进行
        /// <summary>
        /// 设置程序集及实体类型、名称
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="entityTyp"></param>
        /// <param name="controlName"></param>
        public void SetAssemblyType(string assemblyName, Type entityTyp, string controlName = "")
        {
            this.ControlAssemblyName = assemblyName;
            this.EntityType = entityTyp;
            this.ControlName = ControlName;
        }
        /// <summary>
        /// 设置工具栏的可用性，默认都为可用
        /// </summary>
        /// <param name="isEnableAddBtn"></param>
        /// <param name="isEnableSearchBtn"></param>
        /// <param name="isEnableSetBtn"></param>
        /// <param name="isEnablePrintBtn"></param>
        public void SetEnableToolBtn(bool isEnableAddBtn = true, bool isEnableSearchBtn = true,
                                     bool isEnableSetBtn = true, bool isEnablePrintBtn = true)
        {
            this.IsEnableAddBtn = isEnableAddBtn;
            this.IsEnableSearchBtn = isEnableSearchBtn;
            this.IsEnableSettingBtn = isEnableSetBtn;
            this.IsEnablePrintBtn = isEnablePrintBtn;
        }
        /// <summary>
        /// 设置窗体文本和状态栏文本
        /// </summary>
        /// <param name="formText"></param>
        /// <param name="firSi"></param>
        /// <param name="SecSi"></param>
        /// <param name="ThirdSi"></param>
        public void SetText(string formText , string firSi = "", string SecSi = "", string ThirdSi = "")
        {
            this.FormText = formText;
            this.FirStatusInfo = firSi;
            this.SecStatusInfo = SecSi;
            this.ThirdStatusInfo = ThirdSi;
        }
        /// <summary>
        /// 设置右键菜单及分页控件
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="isEnableMenu"></param>
        /// <param name="isEnableSelectSum"></param>
        /// <param name="isEnablePage"></param>
        public void SetMenuAndPager(int pageSize = 20, bool isEnableMenu = true,
                                    bool isEnableSelectSum = false, bool isEnablePage = false)
        {
            this.PageSize = pageSize;
            this.IsEnableMenu = isEnableMenu;
            this.IsEnableSelectSum = isEnableSelectSum;
            this.IsEnablePaging = isEnablePage;
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数, 大部分默认配置
        /// </summary>
        public DataControlParams(string assemblyName, Type entityType)
        {
            SetAssemblyType(assemblyName,entityType );
            SetEnableToolBtn();
            SetMenuAndPager();
        }
        #endregion
    }
    #endregion

    #region WinForm开发帮助类
    /// <summary>
    /// WinForm帮助类
    /// </summary>
    public class WinFormHelper
    {
        #region 添加右键菜单
        /// <summary>
        /// 添加右键菜单
        /// </summary>
        /// <param name="names">菜单名称</param>
        /// <param name="texts"></param>
        /// <param name="onclick"></param>
        /// <returns></returns>
        public static ContextMenuStrip GetContextMenuStrip(string[] names, string[] texts, EventHandler[] onclick)
        {
            ContextMenuStrip CellcontextMenuStrip = new ContextMenuStrip();
            for (int i = 0; i < names.Length; i++)
            {
                ToolStripMenuItem toolStripMenu = new ToolStripMenuItem();
                toolStripMenu.Name = names[i];
                toolStripMenu.Size = new System.Drawing.Size(180, 70);
                toolStripMenu.Text = texts[i];
                toolStripMenu.Click += new EventHandler(onclick[i]);
                CellcontextMenuStrip.Items.Add(toolStripMenu);
            }
            return CellcontextMenuStrip;
        }
        #endregion

        #region 设置控件只能输入数字
        /// <summary>
        /// 设置控件只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SetControlOnlyValue(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == '.' || e.KeyChar == '-');
            if (!e.Handled)
                (sender as TextBox).Tag = (sender as TextBox).Text;//记录最后一次正确输入
        }
        /// <summary>
        /// 只能输入正数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SetControlOnlyZS(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == '.');
            if (!e.Handled)
                (sender as TextBox).Tag = (sender as TextBox).Text;//记录最后一次正确输入
        }
        #endregion

        #region 重置控件
        public static void ResetFormControls(object sender, EventArgs e, Control cur)
        {
            foreach (var item in cur.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Text = string.Empty;
                }
                else if (item.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)item).SelectedIndex = -1;
                }
                else if (item.GetType() == typeof(GroupBox))
                {
                    foreach (var items in ((GroupBox)item).Controls)
                    {
                        if (items.GetType() == typeof(TextBox))
                        {
                            ((TextBox)items).Text = string.Empty;
                        }
                        else if (item.GetType() == typeof(ComboBox))
                        {
                            ((ComboBox)items).SelectedIndex = -1;
                        }
                        else
                        {
                        }
                    }
                }
                else
                {

                }
            }
        }
        #endregion

        #region 删除DataGridView控件中的数据
        public static void DeleteDgvItems<T>(object sender, EventArgs e, DataGridView dgv, List<T> btList) where T : Entity<T>, new()
        {
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
                        if (!index.Contains(RowIndex))
                        {
                            btList[RowIndex].Delete();
                        }
                    }
                }
                else
                    return;
            }
            catch (Exception err)
            {
                MessageBox.Show("删除出错:" + err.Message);
            }
        }
        #endregion

        #region DataGridView单元格动态求值
        /// <summary>
        /// 鼠标选中单元格动态求值
        /// </summary>
        public static string[] GetDynamicSecletedInfo(DataGridView dgv)
        {
            double SelectedCellTotal = 0;//所选单元格中数据的和值
            ArrayList selectRowsCount = new ArrayList();//行统计//dgv.SelectedColumns.Count 
            ArrayList selectColumsCount = new ArrayList();//列统计
            try
            {
                for (int counter = 0; counter < dgv.SelectedCells.Count; counter++)
                {
                    if (dgv.SelectedCells[counter].Value != null)
                    {
                        string rowNum = dgv.SelectedCells[counter].RowIndex.ToString();
                        string colNum = dgv.SelectedCells[counter].ColumnIndex.ToString();
                        if (!selectRowsCount.Contains(rowNum))//不包括
                        {
                            selectRowsCount.Add(rowNum);//添加
                        }
                        if (!selectColumsCount.Contains(colNum))
                        {
                            selectColumsCount.Add(colNum);
                        }
                        Type selectCellType = dgv.SelectedCells[counter].ValueType;
                        if (selectCellType == typeof(double) || (selectCellType == typeof(decimal)) ||
                            (selectCellType == typeof(int)) || (selectCellType == typeof(float)) || (selectCellType == typeof(byte)))
                        {
                            if (dgv.SelectedCells[counter].Value.ToString().Trim() != "")
                            {
                                //选定的数据不能为空，或者不能为null，否则会出现异常
                                SelectedCellTotal += double.Parse(dgv.SelectedCells[counter].Value.ToString());
                            }
                        }
                    }
                }
                return new string[] {SelectedCellTotal.ToString("F2"),selectRowsCount.Count.ToString(), selectColumsCount.Count.ToString (),
                dgv.SelectedCells.Count.ToString ()};
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        #endregion       

        #region DataGridView添加列样式
        /// <summary>
        /// 返回一个ComboBox列
        /// </summary>
        /// <param name="dataSource">ComboBox填充的列表</param>
        /// <param name="dataPropertyName">绑定数据的属性</param>
        /// <param name="DispalyName">列的显示名称</param>
        /// <param name="width">列宽度</param>
        public static DataGridViewComboBoxColumn CreateDgvComboBox(string[] dataSource, string dataPropertyName,
            string DispalyName,Type valueType,int width = 80)
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = dataSource;
            combo.DataPropertyName = dataPropertyName;
            combo.Name = DispalyName;
            combo.ValueType = valueType;
            combo.Width = width;
            return combo;
        }
        public static DataGridViewTextBoxColumn CreateDgvTextBox(string dataPropertyName, string DispalyName, Type valueType, int width = 80)
        {
            DataGridViewTextBoxColumn combo = new DataGridViewTextBoxColumn();
            combo.DataPropertyName = dataPropertyName;
            combo.Name = DispalyName;
            combo.ValueType = valueType;
            combo.Width = width;     
            return combo;
        }
        public static DataGridViewCheckBoxColumn CreateDgvCheckBox(string dataPropertyName, string DispalyName, int width = 80)
        {
            DataGridViewCheckBoxColumn combo = new DataGridViewCheckBoxColumn();
            combo.DataPropertyName = dataPropertyName;
            combo.Name = DispalyName;
            combo.ValueType = typeof(bool);
            combo.Width = width;    
            return combo ;
        }
        #endregion

        #region 获取FormModel窗体，传入一个控件
        /// <summary>
        /// 获取控件的窗体，并设置标题
        /// </summary>
        /// <param name="cl">控件</param>
        /// <param name="titleText">标题文本</param>        
        public static FormModel GetControlForm(Control cl,string titleText = "")
        {
            FormModel tf = new FormModel();            
            tf.Size = new Size(cl.Width + 15, cl.Size.Height + 40);
            tf.Controls.Add(cl);//将控件添加到窗体中
            tf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            tf.Text = titleText;
            return tf;
        }
        #endregion
    }
    #endregion
}