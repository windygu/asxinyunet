using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XControl
{
    /// <summary>
    /// ����������ؼ���ֻ���������֣������Թ涨��Χ�������
    /// </summary>
    [Description("����������ؼ�")]
    [ToolboxData("<{0}:RealBox runat=server></{0}:RealBox>")]
    [ToolboxBitmap(typeof(TextBox))]
    [ControlValueProperty("Value")]
    public class RealBox : TextBox
    {
        /// <summary>
        /// ��ʼ����������ؼ�����ʽ��
        /// </summary>
        public RealBox()
            : base()
        {
            this.ToolTip = "ֻ�����븡������";
            BorderWidth = Unit.Pixel(0);
            BorderColor = Color.Black;
            BorderStyle = BorderStyle.Solid;
            Font.Size = FontUnit.Point(10);
            Width = Unit.Pixel(70);
            if (String.IsNullOrEmpty(Attributes["style"])) this.Attributes.Add("style", "border-bottom-width:1px;text-align : right ");
        }

        /// <summary>
        /// �����ء�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // У��ű�
            Helper.HTMLPropertyEscape(this, "onkeypress", "return ValidReal({0});", AllowMinus ? 1 : 0);
            Helper.HTMLPropertyEscape(this, "onblur", "return ValidReal2();");
            Helper.HTMLPropertyEscape(this, "onkeyup", "FilterNumber(this,{0});", Helper.JsObjectString(
                // "allowFloat", 1, // Ĭ����true
                    "allowMinus", AllowMinus ? 1 : 0
                ));
            this.Page.ClientScript.RegisterClientScriptResource(typeof(NumberBox), "XControl.TextBox.Validator.js");
        }

        /// <summary>
        /// ��ǰֵ
        /// </summary>
        [Category(" ר������"), DefaultValue(0), Description("��ǰֵ")]
        public Double Value
        {
            get
            {
                if (String.IsNullOrEmpty(Text)) return Double.NaN;
                Double k = 0;
                if (!Double.TryParse(Text, out k)) return Double.NaN;
                return k;
            }
            set
            {
                Text = value.ToString();
            }
        }

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        [Category(" ר������"), DefaultValue(true), Description("�Ƿ�������,Ĭ��true")]
        public bool AllowMinus
        {
            get
            {
                object o = ViewState["AllowMinus"];
                if (o == null) o = true;
                bool r;
                if (bool.TryParse(o.ToString(), out r)) return r;
                return true;
            }
            set
            {
                ViewState["AllowMinus"] = value;
            }
        }
    }
}