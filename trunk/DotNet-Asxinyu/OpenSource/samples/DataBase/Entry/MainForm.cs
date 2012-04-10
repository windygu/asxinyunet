using System.Windows.Forms;
using System.Data;
using Lephone.Core;
using Lephone.Data;
using Lephone.Data.SqlEntry;

namespace DataBaseEntry
{
	public class MainForm : Form
	{
		#region System Code

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button1;

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

		#region form designer gen codes
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(24, 360);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "Query";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(24, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(576, 320);
			this.dataGrid1.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(472, 360);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 40);
			this.button2.TabIndex = 2;
			this.button2.Text = "Transaction";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(256, 360);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(112, 40);
			this.button4.TabIndex = 4;
			this.button4.Text = "Query 2";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(624, 414);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Llf\'s .Net DbEntry Tester";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
            var sql = new SqlStatement(
				"SELECT TOP 50 * FROM [SampleData] WHERE [id] > @id AND [Enabled] = @Enabled",
				new DataParameter("@id", 5),
				new DataParameter("@Enabled", false)
				);
			DataSet ds = DbEntry.Provider.ExecuteDataset(sql);
			dataGrid1.DataSource = ds.Tables[0];
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
            var dataBase1 = new DataProvider("1");
            var sql = new SqlStatement("SELECT TOP 50 * FROM [Sheet1$]");
			dataGrid1.DataSource = dataBase1.ExecuteDataset(sql).Tables[0];
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			var s = new[]
				{
					"Insert Into [SampleData] ([Name],[Role],[JoinDate],[Enabled]) Values ('angel',1,'2004-2-27 15:10:21',true)",
					"Insert Into [SampleData] ([Name],[Role],[JoinDate],[Enabled]) Values ('demon',2,'2005-10-20 9:22:10',false)"
				};

            DbEntry.UsingTransaction(delegate()
            {
                DbEntry.Provider.ExecuteNonQuery(s[0]);
                DbEntry.Provider.ExecuteNonQuery(s[1]);

                if (MessageBox.Show("Do you want commit this transaction ?", "llf.hanzify.org", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    Scope<ConnectionContext>.Current.Rollback();
                }
            });
			MessageBox.Show("OK");
		}
	}
}
