using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using DotNet.Tools.Controls;
using ResouceCollector;
using ResouceEntity;

namespace ResouceControls
{
    public partial class VeryCdTypeList : UserControl
    {
        public VeryCdTypeList()
        {
            InitializeComponent();
        }


        #region 菜单事件
        private void toolStripMenuEdit_Click(object sender, EventArgs e)
        {
            dgvTypeList.BeginEdit(false);
        }
        private void toolStripMenuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    int count = dgvTypeList.SelectedCells.Count;
                    List<int> index = new List<int>();
                    for (int i = 0; i < count; i++)
                    {
                        int RowIndex = dgvTypeList.SelectedCells[i].RowIndex;
                        if (!index.Contains(RowIndex))
                        {
                            typeList[RowIndex].Delete();
                        }


                    }
                    typeList = tb_typelist.FindAll();
                    dgvTypeList.DataSource = typeList;
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
        List<tb_typelist> typeList;
        private void VeryCdTypeList_Load(object sender, EventArgs e)
        {
            stausInfoShow1.SetAllToolInfo("资源采集列表", "KP.NET资源采集管理系统", DateTime.Today.ToShortDateString());
            dgvTypeList.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
                new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
                new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
            typeList = new List<tb_typelist>();
            typeList = tb_typelist.FindAll();
            dgvTypeList.DataSource = typeList;
        }
    }
}
