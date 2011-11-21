using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DotNet.Tools.Controls 
{
    [ToolboxBitmap(typeof(ValidateCode), "Resources.Icon.ValidateCode.ico")]
    [Description("WinForm下的验证码控件")]
    [DefaultProperty("CodeType")]
    public partial class ValidateCode : UserControl
    {
        #region 私有属性
        /// <summary>
        /// 验证码的长度 
        /// </summary>
        private int _CodeLength = 4;
        
        /// <summary>
        /// 随机码类型
        /// </summary>
        private CodeTypeEnum _CodeType = CodeTypeEnum.数字;
        /// <summary>
        /// 随机码类型枚举
        /// </summary>
        public enum CodeTypeEnum
        {
            数字 = 1,
            字母 = 2,
            数字和字母 = 3            
        }
        /// <summary>
        /// 验证码内容
        /// </summary>
        private string _CodeText;
        /// <summary>
        /// 背景噪点数
        /// </summary>
        private int _BlackPen = 50;
        /// <summary>
        /// 重新生成验证码提示内容
        /// </summary>
        private string _TooltipText = "点击重新生成验证码";
        /// <summary>
        /// 验证码内容
        /// </summary>
        [Description("验证码内容"), Category("自定义属性"),DefaultValue("")]
        public string CodeText
        {
            get { return _CodeText; }
            set { this._CodeText = value; }
        }
        /// <summary>
        /// 验证码类型
        /// </summary>
        [Description("验证码类型：数字、字母、数字+字母")]
        [Category("自定义属性")]
        [DefaultValue(CodeTypeEnum.数字)]
        public CodeTypeEnum CodeType
        {
            get { return this._CodeType; }
            set
            {
                this._CodeType = value;
                if (_CodeType == CodeTypeEnum.数字) _CodeType = CodeTypeEnum.数字;
                else if (_CodeType == CodeTypeEnum.字母) _CodeType = CodeTypeEnum.字母;
                else if (_CodeType == CodeTypeEnum.数字和字母) _CodeType = CodeTypeEnum.数字和字母;
            }
        }
        /// <summary>
        /// 验证码的长度,默认为4位
        /// </summary>
        [Description("随机码的长度")]
        [Category("自定义属性")]
        [DefaultValue(4)]
        public int CodeLength
        {
            get { return _CodeLength; }
            set
            {
                this._CodeLength = value;
                if (_CodeLength <= 1) _CodeLength = 4;
            }
        }
        /// <summary>
        /// 背景噪点数
        /// </summary>
        [Description("背景噪点数")]
        [Category("自定义属性")]
        [DefaultValue(50)]
        public int CodeBlackPen
        {
            get { return this._BlackPen; }
            set
            {
                this._BlackPen = value;
                if (this._BlackPen < 0) _BlackPen = 50;
            }
        }
        /// <summary>
        /// 重新生成验证码提示内容
        /// </summary>
        [Description("重新生成验证码提示内容")]
        [Category("自定义属性")]
        [DefaultValue("点击重新生成验证码")]
        public string CodeToolTipText
        {
            get { return this._TooltipText; }
            set { this._TooltipText = value; }
        }
        #endregion

        #region 构造事件
        /// <summary>
        /// 构造事件
        /// </summary>
        public ValidateCode()
        {
            InitializeComponent();
        }
        #endregion

        #region 加载事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateCode_Load(object sender, EventArgs e)
        {
            this.CodeText = "";            
            toolTip1.SetToolTip(picCode, CodeToolTipText);
            CreateImage();
        }
        #endregion

        #region 单击验证码事件
        /// <summary>
        /// 单击验证码事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCode_Click(object sender, EventArgs e)
        {
            CreateImage();
        }
        #endregion

        #region 获取随机数
        /// <summary>
        /// 获取随机数
        /// </summary>
        private void GetRanCode()
        {
            string RanCode = "";
            string CodeGens = "123456789";
            try
            {
                if (_CodeType == CodeTypeEnum.数字) CodeGens = "123456789";
                else if (_CodeType == CodeTypeEnum.字母) CodeGens = "abcdefghijklmnopqrstuvwxyz";
                else if (_CodeType == CodeTypeEnum.数字和字母) CodeGens = "123456789abcdefghijklmnopqrstuvwxyz";
                int i;
                Random rd = new Random();
                for (i = 0; i < _CodeLength; i++)
                {
                    RanCode += CodeGens.Substring(rd.Next(0, CodeGens.Length), 1);
                }
            }
            catch (Exception)
            {
            }
            _CodeText = RanCode.ToUpper();
        }
        #endregion

        #region 生成验证码图像
        /// <summary>
        /// 生成验证码图像
        /// </summary>
        private void CreateImage()
        {
            GetRanCode();
            Bitmap Map = null;
            try
            {
                int randAngle = 20; //随机转动角度
                if (Map != null) Map = null;
                int CodeWidth = _CodeLength * ((_CodeType == CodeTypeEnum.数字和字母 || _CodeType == CodeTypeEnum.字母) ? 16 : 14);
                int CodeHeight = 24;
                Map = new Bitmap(CodeWidth, CodeHeight);
                this.Width = Map.Width;
                this.Height = Map.Height;
                Graphics graph = Graphics.FromImage(Map);
                graph.Clear(Color.AliceBlue);//清除画面，填充背景   
                graph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, Map.Width - 1, Map.Height - 1);//画一个边框   
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//模式 
                Random rand = new Random();
                //背景噪点生成   
                Pen blackPen = new Pen(Color.LightGray, 0);
                for (int i = 0; i < _BlackPen; i++)
                {
                    int x = rand.Next(0, Map.Width);
                    int y = rand.Next(0, Map.Height);
                    graph.DrawRectangle(blackPen, x, y, 1, 1);
                }
                if (!string.IsNullOrEmpty(_CodeText) && _CodeText.Length > 0)
                {
                    char[] chars = _CodeText.ToCharArray();//拆散字符串成单字符数组  
                    StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    //定义颜色   
                    Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                    //定义字体   
                    string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
                    int[] FontSize = { 10, 12, 14, 16 };
                    int Stx = 9;
                    if (_CodeType == CodeTypeEnum.数字和字母 || _CodeType == CodeTypeEnum.字母) Stx = 11;
                    for (int i = 0; i < chars.Length; i++)
                    {
                        int cindex = rand.Next(7);
                        int findex = rand.Next(5);
                        int sindex = rand.Next(4);
                        Font f = new System.Drawing.Font(font[findex], FontSize[sindex], System.Drawing.FontStyle.Bold);//字体样式(参数2为字体大小) 
                        Brush b = new System.Drawing.SolidBrush(c[cindex]);
                        Point dot = new Point(Stx, (int)(CodeHeight / 2));
                        float angle = rand.Next(-randAngle, randAngle);//转动的度数 
                        graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置   
                        graph.RotateTransform(angle);
                        graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                        graph.RotateTransform(-angle);//转回去   
                        graph.TranslateTransform(2, -dot.Y);//移动光标到指定位置   
                    }
                }
            }
            catch (Exception)
            {
            }
            picCode.Image = Map;
        }
        #endregion

      
    }
}
