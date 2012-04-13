using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Drawing;
using System.ComponentModel;
using System.Web.UI;

namespace XControl
{
    /// <summary>�ʼ���ַ����ؼ���ֻ���������֣������Թ涨��Χ�������</summary>
    [Description("����ѡ��ؼ�")]
    [ToolboxData("<{0}:MailBox runat=server></{0}:MailBox>")]
    [ToolboxBitmap(typeof(TextBox))]
    public class MailBox : TextBox
    {
          /// <summary>��ʼ���ʼ���ַ����ؼ�����ʽ��</summary>
        public MailBox()
            : base()
        {
            this.ToolTip = "ֻ�������ʼ���ַ��";
            BorderWidth = Unit.Pixel(0);
            BorderColor = Color.Black;
            BorderStyle = BorderStyle.Solid;
            Font.Size = FontUnit.Point(10);
            Width = Unit.Pixel(120);
            if (String.IsNullOrEmpty(Attributes["style"])) this.Attributes.Add("style", "border-bottom-width:1px;");
        }

        /// <summary>�����ء�</summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // У��ű�
            this.Attributes.Add("onblur", "return ValidMail();");
            this.Page.ClientScript.RegisterClientScriptResource(typeof(NumberBox), "XControl.TextBox.Validator.js");
        }
   }
}
