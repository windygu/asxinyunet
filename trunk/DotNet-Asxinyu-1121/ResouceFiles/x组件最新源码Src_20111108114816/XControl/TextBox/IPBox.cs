using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Drawing;
using System.ComponentModel;
using System.Web.UI;

namespace XControl
{
    /// <summary>
    /// IP��ַ����ؼ���ֻ���������֣������Թ涨��Χ�������
    /// </summary>
    [Description("����ѡ��ؼ�")]
    [ToolboxData("<{0}:IPBox runat=server></{0}:IPBox>")]
    [ToolboxBitmap(typeof(TextBox))]
    public class IPBox : TextBox
    {
         /// <summary>
        /// ��ʼ��IP��ַ����ؼ�����ʽ��
        /// </summary>
        public IPBox()
            : base()
        {
            this.ToolTip = "ֻ������IP��ַ��";
            BorderWidth = Unit.Pixel(0);
            BorderColor = Color.Black;
            BorderStyle = BorderStyle.Solid;
            Font.Size = FontUnit.Point(10);
            Width = Unit.Pixel(90);
            if (String.IsNullOrEmpty(Attributes["style"])) this.Attributes.Add("style", "border-bottom-width:1px;");
        }

        /// <summary>
        /// �����ء�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // У��ű�
            this.Attributes.Add("onkeypress", "return ValidIP();");
            this.Attributes.Add("onblur", "return ValidIP2();");
            this.Page.ClientScript.RegisterClientScriptResource(typeof(NumberBox), "XControl.TextBox.Validator.js");
        }
   }
}
