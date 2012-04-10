
#region usings

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lephone.Data;
using Lephone.Data.SqlEntry;

#endregion

namespace DataBaseStoredProcedure
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region System Code

		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
        private Button button2;

		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region System Gen Codes
		private void InitializeComponent()
		{
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(233, 368);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 40);
            this.button4.TabIndex = 9;
            this.button4.Text = "Query 2";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(32, 31);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(552, 320);
            this.dataGrid1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(73, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Query 1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(411, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "Test Out Param";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(616, 438);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Llf\'s .Net SpEntry Tester";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
            DataSet ds = DbEntry.Provider.ExecuteDataset("llf_GetTestData", 2, 10);
			dataGrid1.DataSource = ds.Tables[0];
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
            DataSet ds = DbEntry.Provider.ExecuteDataset("llf_GetTestData", 3, 10);
			dataGrid1.DataSource = ds.Tables[0];
		}

        private void button2_Click(object sender, EventArgs e)
        {
            var Sql = new SqlStatement("llf_GetOutParam",
                new DataParameter("@InParam", 12),
                new DataParameter("@OutParam", 0, typeof(int), ParameterDirection.Output),
                new DataParameter("@Ret", 0, typeof(int), ParameterDirection.ReturnValue)
            );
            int i = Convert.ToInt32(DbEntry.Provider.ExecuteScalar(Sql));

            string s = string.Format("The Select Value Is: {0}\nThe Out Value Is: {1}\nThe Ret Value Is: {2}",
                i, Sql.Parameters[1].Value, Sql.Parameters[2].Value); 

            MessageBox.Show(s);
        }
	}
}
