using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.Exceptions;

namespace XControl
{
    /// <summary>
    /// ��������ؼ���ֻ���������֣������Թ涨��Χ�������
    /// <remarks>�����Сֵֻ����������Ч</remarks>
    /// </summary>
    [Description("��������ؼ�")]
    [ToolboxData("<{0}:NumberBox runat=server></{0}:NumberBox>")]
    [ToolboxBitmap(typeof(TextBox))]
    [ControlValueProperty("Value")]
    public class NumberBox : TextBox
    {
        /// <summary>��ʼ����������ؼ�����ʽ��</summary>
        public NumberBox()
            : base()
        {
            this.ToolTip = "ֻ���������֣�";
            BorderWidth = Unit.Pixel(0);
            BorderColor = Color.Black;
            BorderStyle = BorderStyle.Solid;
            Font.Size = FontUnit.Point(10);
            Width = Unit.Pixel(70);
            if (String.IsNullOrEmpty(Attributes["style"])) this.Attributes.Add("style", "border-bottom-width:1px;text-align : right ");
        }

        /// <summary>�����ء�</summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (Min > Max) ShowError("��������ؼ��У����õ���Сֵ�����ֵ�����������á�");
            if (Min > -1 && Max > -1)
            {
                this.ToolTip = "ֻ������ " + Min + " �� " + Max + " ֮�����֣�";
            }
            else if (Min > -1 && Max < 0)
            {
                this.ToolTip = "ֻ��������ڻ���� " + Min + " ���֣�";
            }
            else if (Min < 0 && Max > -1)
            {
                this.ToolTip = "ֻ������С�ڻ���� " + Max + " ���֣�";
            }

            // У��ű�
            Helper.HTMLPropertyEscape(this, "onkeypress", "return ValidNumber({0});", AllowMinus ? 1 : 0);
            Helper.HTMLPropertyEscape(this, "onblur", "return ValidNumber2({0},{1});", Min ?? -1, Max ?? -1);
            Helper.HTMLPropertyEscape(this, "onkeyup", "FilterNumber(this,{0});", Helper.JsObjectString(
                    "allowFloat", 0,
                    "allowMinus", AllowMinus ? 1 : 0
                ));
            this.Page.ClientScript.RegisterClientScriptResource(typeof(NumberBox), "XControl.TextBox.Validator.js");

            //���û��ֵ����Ĭ����ʾ0
            if (String.IsNullOrEmpty(Text)) Text = "0";
        }

        /// <summary>�������</summary>
        /// <param name="err">������Ϣ</param>
        private void ShowError(String err)
        {
            if (this.DesignMode)
            {
                System.Windows.Forms.MessageBox.Show(err, "XControl�ؼ����ʱ����");
            }
            else
            {
                throw new XException(err);
            }
        }

        /// <summary>��Сֵ</summary>
        [Category(" ר������"), DefaultValue(null), Description("��Сֵ")]
        public Int32? Min
        {
            get
            {
                String str = (String)ViewState["Min"];
                if (String.IsNullOrEmpty(str)) return null;
                Int32 k = 0;
                if (!int.TryParse(str, out k)) return null;
                return k;
            }
            set
            {
                //if (value < -1) ShowError("�Ƿ���СֵMin����Сֵ�������0��Ϊ-1(��ʾ������)��");
                if (value == null)
                {
                    ViewState.Remove("Min");
                    return;
                }

                if (Max != null && value > Max)
                {
                    ShowError("��������ؼ��У����õ���Сֵ�����ֵ�����������á�");
                    return;
                }

                if (Max != null)
                    ToolTip = "ֻ������ " + Min + " �� " + Max + " ֮�����֣�";
                else
                    ToolTip = "ֻ��������ڻ���� " + Min + " ���֣�";

                if (Value < value.Value) Value = value.Value;

                ViewState["Min"] = value.ToString();
            }
        }

        /// <summary>���ֵ</summary>
        [Category(" ר������"), DefaultValue(null), Description("���ֵ")]
        public Int32? Max
        {
            get
            {
                String str = (String)ViewState["Max"];
                if (String.IsNullOrEmpty(str)) return null;
                Int32 k = 0;
                if (!int.TryParse(str, out k)) return null;
                return k;
            }
            set
            {
                if (value == null)
                {
                    //ShowError("�Ƿ����ֵMax�����ֵ�������0��Ϊ-1(��ʾ������)��");
                    ViewState.Remove("Max");
                    return;
                }

                if (Min != null && value < Min)
                {
                    ShowError("��������ؼ��У����õ���Сֵ�����ֵ�����������á�");
                    return;
                }

                Width = Unit.Empty;
                Columns = value.ToString().Length;
                if (Columns > 3) Columns -= 3;

                if (Min != null)
                    ToolTip = "ֻ������ " + Min + " �� " + Max + " ֮�����֣�";
                else
                    ToolTip = "ֻ������С�ڻ���� " + Max + " ���֣�";

                if (Value > value.Value) Value = value.Value;

                ViewState["Max"] = value.ToString();
            }
        }

        /// <summary>��ǰֵ</summary>
        [Category(" ר������"), DefaultValue(0), Description("��ǰֵ")]
        public Int32 Value
        {
            get
            {
                if (String.IsNullOrEmpty(Text)) return 0;
                Int32 k = 0;
                if (!Int32.TryParse(Text, out k)) return 0;
                return k;
            }
            set
            {
                Text = value.ToString();

                Check();
            }
        }

        /// <summary>�Ƿ�������</summary>
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

        /// <summary>�����ء�У�����������Ƿ���ָ����Χ��</summary>
        protected override void RaisePostDataChangedEvent()
        {
            try
            {
                Check();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "err", String.Format("alert('{0}');", ex.Message), true);
                this.Focus();
            }

            base.RaisePostDataChangedEvent();
        }

        private void Check()
        {
            if (Min != null && Value < Min) throw new ArgumentOutOfRangeException("Min", "ֻ��������ڻ���� " + Min + " �����֣�");
            if (Max != null && Value > Max) throw new ArgumentOutOfRangeException("Min", "ֻ������С�ڻ���� " + Max + " �����֣�");
        }
    }
}