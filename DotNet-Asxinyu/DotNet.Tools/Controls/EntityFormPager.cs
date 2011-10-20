using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DotNet.Tools.Controls
{
    /// <summary>
    /// WinForm下分页控件
    /// </summary>
    [ToolboxBitmap(typeof(WinFormPager), "Resources.Icon.Pager.ico")]
    [Description("WinForm下的分页控件")]
    [DefaultProperty("RecordCount")]
    [DefaultEvent("PageIndexChanged")]
    public partial class EntityFormPager : UserControl
    {
        #region 私有属性
        /// <summary>
        /// 分页数据信息
        /// </summary>
//        private string PagerText = "总共{0}条记录,当前第{1}页,共{2}页,每页{3}条记录";

        #region 跳转按钮文字
        /// <summary>
        /// 跳转按钮文字
        /// </summary>
        private string _JumpText = "跳转";
        /// <summary>
        /// 跳转按钮文字
        /// </summary>
        [Description("跳转按钮文字")]
        [Category("自定义属性")]
        [DefaultValue("跳转")]
        public string JumpText
        {
            get { return this._JumpText; }
            set { this._JumpText = value; btnToPageIndex.Text = _JumpText; }
        }
        #endregion

        #region 更改页面索引事件
        /// <summary>
        /// 更改页面索引事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandler(object sender, EventArgs e);
        /// <summary>
        /// 更改页面索引事件
        /// </summary>
        [Description("更改页面索引事件")]
        [Category("自定义事件")]
        public event EventHandler PageIndexChanged;
        #endregion

        #region 记录总数
        /// <summary>
        /// 记录总数
        /// </summary>
        private int _RecordCount = 0;
        /// <summary>
        /// 记录总数
        /// </summary>
        [Description("要分页的总记录数")]
        [Category("自定义属性")]
        public int RecordCount
        {
            get { return this._RecordCount; }
            set
            {
                this._RecordCount = value;
            }
        }
        #endregion

        #region 每页记录数
        /// <summary>
        /// 每页记录数
        /// </summary>
        private int _PageSize = 10;
        /// <summary>
        /// 每页记录数
        /// </summary>
        [Description("每页显示的记录数")]
        [Category("自定义属性")]
        [DefaultValue(10)]
        public int PageSize
        {
            get { return this._PageSize; }
            set
            {
                if (value <= 0) value = 10;
                this._PageSize = value;
                SetLabelLocation();
            }
        }
        #endregion

        #region 当前页数
        /// <summary>
        /// 当前页数
        /// </summary>
        private int _PageIndex = 1;
        /// <summary>
        /// 当前页数
        /// </summary>
        [Description("当前显示的页数")]
        [Category("自定义属性")]
        [DefaultValue(1)]
        public int PageIndex
        {
            get { return this._PageIndex; }
            set
            {
                this._PageIndex = value;
            }
        }
        #endregion

        #region 总页数
        /// <summary>
        /// 总页数
        /// </summary>
        private int _PageCount = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        private int PageCount
        {
            get { return _PageCount; }
        }
        #endregion

        #region 显示类型（图片文字）
        /// <summary>
        /// 显示类型（图片文字）
        /// </summary>
        public enum DisplayStyleEnum
        {
            图片 = 1,
            文字 = 2,
            图片及文字 = 3
        }
        /// <summary>
        /// 显示类型（图片文字）
        /// </summary>
        private DisplayStyleEnum _DisplayStyle = DisplayStyleEnum.图片;
        /// <summary>
        /// 显示类型（图片文字）
        /// </summary>
        [Description("显示类型：图片、文字、图片及文字")]
        [Category("自定义属性")]
        [DefaultValue(DisplayStyleEnum.图片)]
        public DisplayStyleEnum DisplayStyle
        {
            get { return this._DisplayStyle; }
            set
            {
                this._DisplayStyle = value;
                SetDisplayStyle();
            }
        }
        #endregion

        #region 首页按钮文字
        private string _BtnTextFirst = "首页";
        /// <summary>
        /// 首页按钮文字
        /// </summary>
        [Description("首页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        [Category("自定义属性")]
        [DefaultValue("首页")]
        public string BtnTextFirst
        {
            get { return this._BtnTextFirst; }
            set { this._BtnTextFirst = value; SetDisplayStyle(); }
        }
        #endregion

        #region 上一页按钮文字
        private string _BtnTextPrevious = "上一页";
        /// <summary>
        /// 上一页按钮文字
        /// </summary>
        [Description("上一页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        [Category("自定义属性")]
        [DefaultValue("上一页")]
        public string BtnTextPrevious
        {
            get { return this._BtnTextPrevious; }
            set { this._BtnTextPrevious = value; SetDisplayStyle(); }
        }
        #endregion

        #region 下一页按钮文字
        private string _BtnTextNext = "下一页";
        /// <summary>
        /// 下一页按钮文字
        /// </summary>
        [Description("下一页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        [Category("自定义属性")]
        [DefaultValue("下一页")]
        public string BtnTextNext
        {
            get { return this._BtnTextNext; }
            set { this._BtnTextNext = value; SetDisplayStyle(); }
        }
        #endregion

        #region 末页按钮文字
        private string _BtnTextLast = "末页";
        /// <summary>
        /// 末按钮文字
        /// </summary>
        [Description("末页按钮文字,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        [Category("自定义属性")]
        [DefaultValue("末页")]
        public string BtnTextLast
        {
            get { return this._BtnTextLast; }
            set { this._BtnTextLast = value; SetDisplayStyle(); }
        }
        #endregion

        #region 图片和文字显示相对位置
        private TextImageRalitionEnum _TextImageRalition = TextImageRalitionEnum.图片显示在文字前方;
        public enum TextImageRalitionEnum
        {
            图片显示在文字上方 = 1,
            图片显示在文字下方 = 2,
            图片显示在文字前方 = 3,
            图片显示在文字后方 = 4
        }
        /// <summary>
        /// 图片和文字显示相对位置
        /// </summary>
        [Description("图片和文字显示相对位置,当DisplayStyle=文字或DisplayStyle=图片及文字时生效")]
        [Category("自定义属性")]
        [DefaultValue(TextImageRalitionEnum.图片显示在文字前方)]
        public TextImageRalitionEnum TextImageRalitions
        {
            get { return this._TextImageRalition; }
            set
            {
                this._TextImageRalition = value;
                SetDisplayStyle();
            }
        }
        #endregion

        #endregion

        #region 初始化事件
        /// <summary>
        /// 初始化事件
        /// </summary>
        public EntityFormPager()
        {
            InitializeComponent();
           
        }
        #endregion

        #region 加载时事件
        /// <summary>
        /// 加载时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pager_Load(object sender, EventArgs e)
        {
            SetBtnEnabled();
            btnToPageIndex.Text = _JumpText;  //hfmedical   2011.10.13
        }
        #endregion

        #region 绘制控件事件
        /// <summary>
        /// 绘制控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pager_Paint(object sender, PaintEventArgs e)
        {
            _PageCount = GetPageCount(_RecordCount, _PageSize);
            SetPagerText();
            SetBtnEnabled();  //hfmedical   2011.10.13
            SetDisplayStyle();
            SetLabelLocation();
        }
        #endregion

        #region 转到第一页
        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            _PageIndex = 1;
            SetPagerText();
            SetBtnEnabled();
            txtToPageIndex.Text = this.PageIndex.ToString();
            SetLabelLocation();
            CustomEvent(sender, e);
        }
        #endregion

        #region 转到上一页
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int StrIndex = _PageIndex;
            try
            {
                int Tmp = Convert.ToInt32(StrIndex);
                Tmp--;
                if (Tmp <= 0) Tmp = 1;
                _PageIndex = Tmp;
                SetPagerText();
                SetBtnEnabled();
                txtToPageIndex.Text = this.PageIndex.ToString();
                SetLabelLocation();
                CustomEvent(sender, e);
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #region 转到下一页
        /// <summary>
        /// 转到下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            int StrIndex = _PageIndex;
            try
            {
                int Tmp = Convert.ToInt32(StrIndex);
                Tmp = Tmp + 1;
                if (Tmp >= PageCount) Tmp = PageCount;  //hfmedical   2011.10.13
                _PageIndex = Tmp;
                SetPagerText();
                SetBtnEnabled();
                txtToPageIndex.Text = this.PageIndex.ToString();
                SetLabelLocation();
                CustomEvent(sender, e);
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #region 转到最后一页
        /// <summary>
        /// 转到最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            _PageIndex = _PageCount;
            SetPagerText();
            txtToPageIndex.Text = this.PageIndex.ToString();
            SetBtnEnabled();
            SetLabelLocation();
            CustomEvent(sender, e);
        }
        #endregion

        #region 设置页面中四个按钮是否显示
        /// <summary>
        /// 设置页面中四个按钮是否显示
        /// </summary>
        protected void SetBtnEnabled()
        {
            if (_PageIndex == 1)
            {
                if (_PageCount == 1)   //hfmedical   2011.10.13
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
            }
            else if (_PageIndex > 1 && _PageIndex < _PageCount)
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else if (_PageIndex == _PageCount)
            {
                if (_PageCount == 1)  //hfmedical   2011.10.13
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
            }
        }
        #endregion

        #region 根据记录数计算总页数
        /// <summary>
        /// 根据记录数计算总页数
        /// </summary>
        /// <param name="RecordCounts"></param>
        /// <param name="PageSizes"></param>
        /// <returns></returns>
        protected int GetPageCount(int RecordCounts, int PageSizes)
        {
            int PageCount = 0;
            String StrRe = (Convert.ToDouble(RecordCounts) / Convert.ToDouble(PageSizes)).ToString();
            if (StrRe.IndexOf(".") < 0) PageCount = Convert.ToInt32(StrRe);
            else
            {
                string[] tmp = Regex.Split(StrRe, @"\.", RegexOptions.IgnoreCase);
                if (!string.IsNullOrEmpty(tmp[1].ToString()))
                {
                    PageCount = Convert.ToInt32(tmp[0]) + 1;
                }
            }
            return PageCount;
        }


        public void LoadData()  //hfmedical   2011.10.13
        {
            SetBtnEnabled();
        }


        #endregion

        #region 设置每个标签的位置
        /// <summary>
        /// 设置每个标签的位置
        /// </summary>
        protected void SetLabelLocation()
        {
            btnFirst.Left =  10;
            btnPrevious.Left = btnFirst.Left + btnFirst.Width;
            btnNext.Left = btnPrevious.Left + btnPrevious.Width;
            btnLast.Left = btnNext.Left + btnNext.Width;
            label3.Left = btnLast.Left + btnLast.Width + 10;
            txtToPageIndex.Left = label3.Left + label3.Width;
            label1.Left = txtToPageIndex.Left + txtToPageIndex.Width;
            btnToPageIndex.Left = label1.Left + label1.Width;
        }
        #endregion

        #region 跳转到指定页面
        /// <summary>
        /// 跳转到指定页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToPageIndex_Click(object sender, EventArgs e)
        {
            string StrToPageIndex = txtToPageIndex.Text;
            int ToPageIndex = _PageIndex;
            if (string.IsNullOrEmpty(StrToPageIndex))
            {
                ToPageIndex = 1;
                txtToPageIndex.Text = "1";
            }
            else
            {
                ToPageIndex = Convert.ToInt32(StrToPageIndex);
                if (ToPageIndex > _PageCount)
                {
                    ToPageIndex = _PageCount;
                    txtToPageIndex.Text = _PageCount.ToString();
                }
                else
                {
                    _PageIndex = ToPageIndex;
                    SetPagerText();
                    SetBtnEnabled();
                    SetLabelLocation();
                    CustomEvent(sender, e);
                }
            }
        }
        /// <summary>
        /// 转到文本框按下键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnToPageIndex_Click(new object(), new EventArgs());
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region 自定义事件
        /// <summary>
        /// 自定义事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomEvent(object sender, EventArgs e)
        {
            try
            {
                this.PageIndexChanged(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("未找到PageIndexChanged事件！");
            }
        }
        #endregion

        #region 设置分页标签内容
        /// <summary>
        /// 设置分页标签内容
        /// </summary>
        private void SetPagerText()
        {
            string[] Pagearr = new string[4];
            Pagearr[0] = this.RecordCount.ToString();
            Pagearr[1] = this.PageIndex.ToString();
            Pagearr[2] = this.PageCount.ToString();
            Pagearr[3] = this.PageSize.ToString();            
        }
        #endregion

        #region 设置显示样式
        /// <summary>
        /// 设置显示样式
        /// </summary>
        private void SetDisplayStyle()
        {
            TextImageRelation TextImageDisplay = TextImageRelation.ImageBeforeText;            
            if (TextImageRalitions == TextImageRalitionEnum.图片显示在文字上方) TextImageDisplay = TextImageRelation.ImageAboveText;
            else if (TextImageRalitions == TextImageRalitionEnum.图片显示在文字下方) TextImageDisplay = TextImageRelation.TextAboveImage;
            else if (TextImageRalitions == TextImageRalitionEnum.图片显示在文字前方) TextImageDisplay = TextImageRelation.ImageBeforeText;
            else if (TextImageRalitions == TextImageRalitionEnum.图片显示在文字后方) TextImageDisplay = TextImageRelation.TextBeforeImage;
            if (this.DisplayStyle == DisplayStyleEnum.图片)
            {
                btnFirst.ImageList =btnPrevious.ImageList=btnNext.ImageList=btnLast.ImageList= imglstPager;
                btnFirst.ImageIndex = 0;
                btnPrevious.ImageIndex = 1;
                btnNext.ImageIndex = 2;
                btnLast.ImageIndex = 3;
                btnFirst.Text = btnPrevious.Text = btnNext.Text = btnLast.Text = "";
                btnFirst.TextImageRelation = btnPrevious.TextImageRelation = btnNext.TextImageRelation = btnLast.TextImageRelation = TextImageRelation.Overlay;
            }
            else if (this.DisplayStyle == DisplayStyleEnum.文字)
            {
                btnFirst.ImageList = btnPrevious.ImageList = btnNext.ImageList = btnLast.ImageList = null;
                btnFirst.Text = string.IsNullOrEmpty(BtnTextFirst) ? "首页" : BtnTextFirst;
                btnPrevious.Text = string.IsNullOrEmpty(BtnTextPrevious) ? "上一页" : BtnTextPrevious; ;
                btnNext.Text = string.IsNullOrEmpty(BtnTextNext) ? "下一页" : BtnTextNext; ;
                btnLast.Text = string.IsNullOrEmpty(BtnTextLast) ? "末页" : BtnTextLast;
                btnFirst.TextImageRelation = btnPrevious.TextImageRelation = btnNext.TextImageRelation = btnLast.TextImageRelation = TextImageRelation.Overlay;
            }
            else if (DisplayStyle == DisplayStyleEnum.图片及文字)
            {
                
                btnFirst.ImageList = btnPrevious.ImageList = btnNext.ImageList = btnLast.ImageList = imglstPager;
                btnFirst.ImageIndex = 0;
                btnPrevious.ImageIndex = 1;
                btnNext.ImageIndex = 2;
                btnLast.ImageIndex = 3;
                btnFirst.Text = string.IsNullOrEmpty(BtnTextFirst) ? "首页" : BtnTextFirst;
                btnPrevious.Text = string.IsNullOrEmpty(BtnTextPrevious) ? "上一页" : BtnTextPrevious; ;
                btnNext.Text = string.IsNullOrEmpty(BtnTextNext) ? "下一页" : BtnTextNext; ;
                btnLast.Text = string.IsNullOrEmpty(BtnTextLast) ? "末页" : BtnTextLast; ;                
                btnFirst.TextImageRelation = btnPrevious.TextImageRelation = btnNext.TextImageRelation = btnLast.TextImageRelation = TextImageDisplay;
            }
        }
        #endregion

        #region 鼠标滑过控件时
        /// <summary>
        /// 鼠标滑过控件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinFormPager_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Control ctl in this.Controls)  //设置按钮背景
            {
                if (ctl is Button)
                {
                    Button BtnCtl = (Button)ctl;
                    BtnCtl.BackColor = Color.Transparent;
                    BtnCtl.FlatAppearance.BorderColor = Color.White;
                    BtnCtl.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    BtnCtl.FlatAppearance.MouseOverBackColor = Color.Transparent;   
                }
            }
        }
        #endregion
    }
}
