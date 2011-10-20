namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class ExtTextBox : TextBox
    {
        private ExtTextBoxType m_inpType;

        public ExtTextBox()
        {
            this.InputType = ExtTextBoxType.Integer;
            this.ContextMenu = new ContextMenu();
        }

        private bool IsValid(string val, bool user)
        {
            bool ret = true;
            if (!val.Equals("") && !val.Equals(string.Empty))
            {
                if (user && val.Equals("-")) return ret;
                try
                {
                    switch (this.m_inpType)
                    {
                        case ExtTextBoxType.Currency:
                        {
                            decimal.Parse(val);
                            int pos = val.IndexOf(".");
                            if (pos != -1) ret = val.Substring(pos).Length <= 3;
                            return ret;
                        }
                        case ExtTextBoxType.Decimal:
                            decimal.Parse(val);
                            return ret;

                        case ExtTextBoxType.Single:
                            float.Parse(val);
                            return ret;

                        case ExtTextBoxType.Double:
                            double.Parse(val);
                            return ret;

                        case ExtTextBoxType.SmallInteger:
                            short.Parse(val);
                            return ret;

                        case ExtTextBoxType.Integer:
                            int.Parse(val);
                            return ret;

                        case ExtTextBoxType.LargeInteger:
                            long.Parse(val);
                            return ret;

                        case ExtTextBoxType.Byte:
                            byte.Parse(val);
                            return ret;

                        case ExtTextBoxType.String:
                            return ret;
                    }
                    throw new ApplicationException();
                }
                catch
                {
                    ret = false;
                }
            }
            return ret;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsControl(c))
            {
                if (c.ToString() == " ")
                {
                    e.Handled = true;
                    return;
                }
                string newText = base.Text.Substring(0, base.SelectionStart) + c.ToString() + base.Text.Substring(base.SelectionStart + base.SelectionLength);
                if (!this.IsValid(newText, true)) e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (base.Text != "")
            {
                if (!this.IsValid(base.Text, false))
                    base.Text = "";
                else if (this.InputType != ExtTextBoxType.String && double.Parse(base.Text) == 0.0) base.Text = "0";
            }
            base.OnLeave(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V) || keyData == (Keys.Shift | Keys.Insert))
            {
                IDataObject iData = Clipboard.GetDataObject();
                string newText = base.Text.Substring(0, base.SelectionStart) + ((string) iData.GetData(DataFormats.Text)) + base.Text.Substring(base.SelectionStart + base.SelectionLength);
                if (!this.IsValid(newText, true)) return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        [Description("Sets the numeric type allowed"), Category("Behavior")]
        public ExtTextBoxType InputType { get { return this.m_inpType; } set { this.m_inpType = value; } }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (this.IsValid(value, true)) base.Text = value;
            }
        }

        public enum ExtTextBoxType
        {
            Currency,
            Decimal,
            Single,
            Double,
            SmallInteger,
            Integer,
            LargeInteger,
            Byte,
            String
        }
    }
}
