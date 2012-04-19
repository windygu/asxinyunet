//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// UCTableSort
    /// 对表进行排序
    /// 
    /// 修改纪录
    ///
    ///		2011.06.21 版本：1.1 JiRiGaLa 置顶置底的WCF运行模式的错误修正。
    ///		2008.05.16 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.06.21</date>
    /// </author> 
    /// </summary>
    public partial class UCTableSort : UserControl
    {
        public UCTableSort()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        private DataGridView dataGridView;
        private DataView dataView;

        // 实体主键
        public string EntityId
        {
            get
            {
                return BaseInterfaceLogic.GetDataGridViewEntityId(this.dataGridView, BaseBusinessLogic.FieldId);
                //这个方法可以吗？
                //return (this.dataGridView.CurrentRow.DataBoundItem as DataRowView).Row[BaseBusinessLogic.FieldId].ToString();
            }
        }

        private bool permissionEdit = true;    // 编辑权限

        #region public void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public void SetControlState()
        {
            this.SetSortButton(false);
            // 位置顺序改变按钮部分
            if ((this.dataView != null) && (this.dataView.Count > 1))
            {
                this.SetSortButton(this.permissionEdit);
            }
            if (BaseSystemInfo.BusinessDbType == CurrentDbType.DB2
                || BaseSystemInfo.BusinessDbType == CurrentDbType.Oracle)
            {
                this.btnSetTop.Visible = false;
                this.btnSetBottom.Visible = false;
            }
        }
        #endregion

        public void DataBind(DataGridView dataGridView, bool permissionEdit)
        {
            this.permissionEdit = permissionEdit;
            this.dataGridView = dataGridView;
            if (dataGridView.DataMember != null)
            {
                if (dataGridView.DataSource != null)
                {
                    this.dataView = (DataView)dataGridView.DataSource;
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }

        public void DataBind(DataGridView dataGridView)
        {
            this.DataBind(dataGridView, true);
        }

        public bool SetTopEnabled
        {
            get
            {
                return this.btnSetTop.Enabled;
            }
            set
            {
                this.btnSetTop.Enabled = value;
            }
        }

        public bool SetUpEnabled
        {
            get
            {
                return this.btnSetUp.Enabled;
            }
            set
            {
                this.btnSetUp.Enabled = value;
            }
        }

        public bool SetDownEnabled
        {
            get
            {
                return this.btnSetDown.Enabled;
            }
            set
            {
                this.btnSetDown.Enabled = value;
            }
        }

        public bool SetBottomEnabled
        {
            get
            {
                return this.btnSetBottom.Enabled;
            }
            set
            {
                this.btnSetBottom.Enabled = value;
            }
        }

        #region public void SetSortButton(bool enabled) 设置排序按钮
        /// <summary>
        /// 设置排序按钮
        /// </summary>
        /// <param name="enabled">有效</param>
        public void SetSortButton(bool enabled)
        {
            this.btnSetTop.Enabled = enabled;
            this.btnSetUp.Enabled = enabled;
            this.btnSetDown.Enabled = enabled;
            this.btnSetBottom.Enabled = enabled;
        }
        #endregion

        private void UCTableSort_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetSortButton(false);
            }
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetTop()
        {
            int returnValue = 0;
            string targetId = BaseSortLogic.GetPreviousId(this.dataView, this.EntityId);
            if (targetId.Length > 0)
            {
                DotNetService dotNetService = new DotNetService();
                string sequence = dotNetService.SequenceService.GetReduction(UserInfo, this.dataView.Table.TableName);
                if (dotNetService.SequenceService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.SequenceService).Close();
                }
                returnValue = BaseBusinessLogic.SetProperty(this.dataView.Table, this.EntityId, BaseBusinessLogic.FieldSortCode, sequence);
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0021, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }

        private void btnSetTop_Click(object sender, EventArgs e)
        {
            this.SetTop();
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetUp()
        {
            int returnValue = 0;
            string targetId = BaseSortLogic.GetPreviousId(this.dataView, this.EntityId);
            if (targetId.Length > 0)
            {
                returnValue = BaseSortLogic.Swap(this.dataView.Table, this.EntityId, targetId);
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0021, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            this.SetUp();
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetDown()
        {
            int returnValue = 0;
            string targetId = BaseSortLogic.GetNextId(this.dataView, this.EntityId);
            if (targetId.Length > 0)
            {
                returnValue = BaseSortLogic.Swap(this.dataView.Table, this.EntityId, targetId);
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0022, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }

        private void btnSetDown_Click(object sender, EventArgs e)
        {
            this.SetDown();
        }

        /// <summary>
        /// 置底
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetBottom()
        {
            int returnValue = 0;
            string targetId = BaseSortLogic.GetNextId(this.dataView, this.EntityId);
            if (targetId.Length > 0)
            {
                DotNetService dotNetService = new DotNetService();
                string sequence = dotNetService.SequenceService.GetSequence(UserInfo, this.dataView.Table.TableName);
                if (dotNetService.SequenceService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.SequenceService).Close();
                }
                returnValue = BaseBusinessLogic.SetProperty(this.dataView.Table, this.EntityId, BaseBusinessLogic.FieldSortCode, sequence);
            }
            else
            {
                if (BaseSystemInfo.ShowInformation)
                {
                    MessageBox.Show(AppMessage.MSG0022, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }

        private void btnSetBottom_Click(object sender, EventArgs e)
        {
            this.SetBottom();
        }
    }
}