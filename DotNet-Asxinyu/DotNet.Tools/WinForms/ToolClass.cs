namespace EntLib.Controls.WinForm
{
    using System;
    using System.Windows.Forms;

    public class ToolClass
    {
        public static void CleanPanel(Control parentContol)
        {
            foreach (Control control in parentContol.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control control2 in control.Controls)
                    {
                        if (control2 is TextBox) (control2 as TextBox).Text = "";
                        if (control2 is ExtTextBox)
                        {
                            ExtTextBox.ExtTextBoxType inpType = ((ExtTextBox) control2).InputType;
                            if (inpType == ExtTextBox.ExtTextBoxType.Single | inpType == ExtTextBox.ExtTextBoxType.Double)
                                (control2 as ExtTextBox).Text = "0.0";
                            else if (inpType == ExtTextBox.ExtTextBoxType.String)
                                (control2 as ExtTextBox).Text = "";
                            else
                                (control2 as ExtTextBox).Text = "0";
                        }
                        if (control2 is ComboBox) (control2 as ComboBox).SelectedIndex = -1;
                        if (control2 is Uc_Datetime) (control2 as Uc_Datetime).Value = Convert.ToDateTime("2000-01-01 00:00:00");
                        if (control2 is DateTimePicker) (control2 as DateTimePicker).Value = DateTime.Now;
                        if (control2 is UserTxtIP) (control2 as UserTxtIP).Text = "0.0.0.0";
                    }
                }
                if (control is TextBox) (control as TextBox).Text = "";
                if (control is ExtTextBox)
                {
                    ExtTextBox.ExtTextBoxType inpType = ((ExtTextBox) control).InputType;
                    if (inpType == ExtTextBox.ExtTextBoxType.Single | inpType == ExtTextBox.ExtTextBoxType.Double)
                        (control as ExtTextBox).Text = "0.0";
                    else if (inpType == ExtTextBox.ExtTextBoxType.String)
                        (control as ExtTextBox).Text = "";
                    else
                        (control as ExtTextBox).Text = "0";
                }
                if (control is ComboBox) (control as ComboBox).Text = "";
                if (control is Uc_Datetime) (control as Uc_Datetime).Value = Convert.ToDateTime("2000-01-01 00:00:00");
                if (control is DateTimePicker) (control as DateTimePicker).Value = Convert.ToDateTime("2000-01-01 00:00:00");
                if (control is UserTxtIP) (control as UserTxtIP).Text = "0.0.0.0";
            }
        }
    }
}
