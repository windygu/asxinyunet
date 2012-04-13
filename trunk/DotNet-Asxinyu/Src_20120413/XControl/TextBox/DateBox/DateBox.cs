using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.IO;
using System.Drawing;

// �ر�Ҫע�⣬����ü���Ĭ�������ռ��Ŀ¼������Ϊvs2005�����ʱ����js�ļ�������Щ������
[assembly: WebResource("XControl.TextBox.DateBox.SelectDate.js", "application/x-javascript")]

namespace XControl
{
    /// <summary>����ѡ��ؼ�</summary>
    [Description("����ѡ��ؼ�")]
    [ToolboxData("<{0}:DateBox runat=server></{0}:DateBox>")]
    [ToolboxBitmap(typeof(TextBox))]
    public class DateBox : TextBox
    {
        /// <summary>��ʼ��ѡ������ʽ��</summary>
        public DateBox()
            : base()
        {
            //this.BackColor = Color.FromArgb(0xff, 0xe0, 0xc0);
            this.ToolTip = "�������ѡ������";
            BorderWidth = Unit.Pixel(0);
            BorderColor = Color.Olive;
            BorderStyle = BorderStyle.Dotted;
            Font.Size = FontUnit.Point(10);
            Width = Unit.Pixel(118);
            if (String.IsNullOrEmpty(Attributes["style"])) this.Attributes.Add("style", "border-bottom-width:1px;");
        }

        /// <summary>�����ء�</summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // ����Popup
            this.Attributes.Add("onclick", "SelectDate(this);");
            this.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "XControl.TextBox.DateBox.SelectDate.js");
        }

        /// <summary>��ǰֵ</summary>
        [Category(" ר������"), DefaultValue(0), Description("��ǰֵ")]
        public DateTime Value
        {
            get
            {
                if (String.IsNullOrEmpty(Text)) return DateTime.MinValue;
                DateTime k;
                if (!DateTime.TryParse(Text, out k)) return DateTime.MinValue;
                return k;
            }
            set
            {
                Text = value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}