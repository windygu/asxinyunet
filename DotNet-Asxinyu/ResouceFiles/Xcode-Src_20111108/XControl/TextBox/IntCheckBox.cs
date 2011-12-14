using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XControl
{
    /// <summary>
    /// ����ѡ��ؼ���
    /// </summary>
    [Description("����ѡ��ؼ�")]
    [ToolboxData("<{0}:IntCheckBox runat=server></{0}:IntCheckBox>")]
    [ToolboxBitmap(typeof(CheckBox))]
    [ControlValueProperty("Value")]
    public class IntCheckBox : CheckBox
    {

        /// <summary>
        /// ѡ��ֵ
        /// </summary>
        [Category(" ר������"), DefaultValue(1), Description("ѡ��ֵ")]
        public Int32 SelectedValue
        {
            get
            {
                String str = (String)ViewState["SelectedValue"];
                if (String.IsNullOrEmpty(str)) return 1;
                Int32 k = 1;
                if (!int.TryParse(str, out k)) return 1;
                return k;
            }
            set
            {
                ViewState["SelectedValue"] = value.ToString();
            }
        }

        /// <summary>
        /// ��ѡ��ֵ
        /// </summary>
        [Category(" ר������"), DefaultValue(0), Description("��ѡ��ֵ")]
        public Int32 UnSelectedValue
        {
            get
            {
                String str = (String)ViewState["UnSelectedValue"];
                if (String.IsNullOrEmpty(str)) return 0;
                Int32 k = 0;
                if (!int.TryParse(str, out k)) return 0;
                return k;
            }
            set
            {
                ViewState["UnSelectedValue"] = value.ToString();
            }
        }

        /// <summary>
        /// �Ƿ����ѡ��
        /// </summary>
        [Category(" ר������"), DefaultValue(false), Description("��ǰֵValue�Ƿ��������ѡ��ֵʱ��ѡ��")]
        public Boolean OnlySelect
        {
            get
            {
                String str = (String)ViewState["OnlySelect"];
                if (String.IsNullOrEmpty(str)) return false;
                Boolean k = false;
                if (!Boolean.TryParse(str, out k)) return false;
                return k;
            }
            set
            {
                ViewState["OnlySelect"] = value.ToString();
            }
        }

        /// <summary>
        /// ��ǰֵ
        /// </summary>
        [Category(" ר������"), DefaultValue(0), Description("��ǰֵ")]
        public Int32 Value
        {
            get
            {
                return Checked ? SelectedValue : UnSelectedValue;
            }
            set
            {
                if (OnlySelect)
                {
                    //ֻ�е���ѡ��ֵʱ��ѡ��
                    Checked = (value == SelectedValue);
                }
                else
                {
                    Checked = !(value == UnSelectedValue);
                }
            }
        }
    }
}