//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System.Windows.Forms;

namespace DotNet.WCFHost
{
    public partial class FormWCFHost : Form
    {
        private string ConsoleValue;

        public FormWCFHost()
        {
            InitializeComponent();
        }

        public FormWCFHost(string consoleValue)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(consoleValue))
            {
                ConsoleValue = consoleValue;
            }
        }

        private void FormWCFHost_Load(object sender, System.EventArgs e)
        {
            txtWCFHost.Text = ConsoleValue;
            txtWCFHost.SelectionStart = txtWCFHost.TextLength;
        }

        private void FormWCFHost_Activated(object sender, System.EventArgs e)
        {
            #if (DEBUG)
                //this.Visible = false;
            #endif
        }
    }
}
