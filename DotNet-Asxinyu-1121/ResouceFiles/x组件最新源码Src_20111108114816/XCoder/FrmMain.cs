using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using NewLife.Log;
using NewLife.Threading;
using XCode.DataAccessLayer;
using XTemplate.Templating;

namespace XCoder
{
    public partial class FrmMain : Form
    {
        #region ����
        /// <summary>
        /// ����
        /// </summary>
        public static XConfig Config { get { return XConfig.Current; } }

        private Engine _Engine;
        /// <summary>������</summary>
        public Engine Engine
        {
            get { return _Engine ?? (_Engine = new Engine(Config)); }
            set { _Engine = value; }
        }
        #endregion

        #region �����ʼ��
        public FrmMain()
        {
            InitializeComponent();

            this.Icon = FileSource.GetIcon();

            AutoLoadTables(Config.ConnName);

            //FileSource.CheckTemplate();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Text = "���������������� V" + Engine.FullVersion + "����";
            Template.BaseClassName = typeof(XCoderBase).FullName;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadConfig();

            try
            {
                List<String> list = new List<String>();
                foreach (String item in DAL.ConnStrs.Keys)
                {
                    list.Add(item);
                }
                //Conns = list;
                SetDatabaseList(list);

                BindTemplate(cb_Template);
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }

            LoadConfig();

            ThreadPoolX.QueueUserWorkItem(AutoDetectDatabase, null);
            ThreadPoolX.QueueUserWorkItem(UpdateArticles, null);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveConfig();
            }
            catch { }
        }
        #endregion

        #region ���ӡ��Զ�������ݿ⡢���ر�
        private void bt_Connection_Click(object sender, EventArgs e)
        {
            SaveConfig();

            if (bt_Connection.Text == "����")
            {
                Engine = null;
                Engine.Tables = DAL.Create(Config.ConnName).Tables;

                SetTables(Engine.Tables);
                SetTables(null);
                SetTables(Engine.Tables);

                gbConnect.Enabled = false;
                gbTable.Enabled = true;
                btnShowSchema.Enabled = true;
                btnImport.Enabled = false;
                bt_Connection.Text = "�Ͽ�";
            }
            else
            {
                SetTables(null);

                gbConnect.Enabled = true;
                gbTable.Enabled = false;
                btnShowSchema.Enabled = false;
                btnImport.Enabled = true;
                bt_Connection.Text = "����";
                Engine = null;
            }
        }

        private void cbConn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Config.ConnName)) toolTip1.SetToolTip(cbConn, DAL.Create(cbConn.Text).ConnStr);

            AutoLoadTables(cbConn.Text);

            if (String.IsNullOrEmpty(cb_Template.Text)) cb_Template.Text = cbConn.Text;
            if (String.IsNullOrEmpty(txt_OutPath.Text)) txt_OutPath.Text = cbConn.Text;
            if (String.IsNullOrEmpty(txt_NameSpace.Text)) txt_NameSpace.Text = cbConn.Text;
        }

        void AutoDetectDatabase()
        {
            List<String> list = new List<String>();

            // ���ϱ���MSSQL
            String localName = "local_MSSQL";
            String localstr = "Data Source=.;Initial Catalog=master;Integrated Security=True;";
            if (!ContainConnStr(localstr)) DAL.AddConnStr(localName, localstr, null, "sqlclient");

            #region ��Ȿ��Access��SQLite
            String[] ss = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.*", SearchOption.TopDirectoryOnly);
            foreach (String item in ss)
            {
                String ext = Path.GetExtension(item);
                if (String.Equals(ext, ".exe", StringComparison.OrdinalIgnoreCase)) continue;
                if (String.Equals(ext, ".dll", StringComparison.OrdinalIgnoreCase)) continue;
                if (String.Equals(ext, ".zip", StringComparison.OrdinalIgnoreCase)) continue;
                if (String.Equals(ext, ".rar", StringComparison.OrdinalIgnoreCase)) continue;
                if (String.Equals(ext, ".xml", StringComparison.OrdinalIgnoreCase)) continue;

                String access = "Standard Jet DB";
                String sqlite = "SQLite";

                try
                {
                    using (FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        BinaryReader reader = new BinaryReader(fs);
                        Byte[] bts = reader.ReadBytes(sqlite.Length);
                        if (bts != null && bts.Length > 0)
                        {
                            if (bts[0] == 'S' && bts[1] == 'Q' && Encoding.ASCII.GetString(bts) == sqlite)
                            {
                                localstr = String.Format("Data Source={0};", item);
                                if (!ContainConnStr(localstr)) DAL.AddConnStr("SQLite_" + Path.GetFileNameWithoutExtension(item), localstr, null, "SQLite");
                            }
                            else if (bts[4] == 'S' && bts[5] == 't')
                            {
                                fs.Seek(4, SeekOrigin.Begin);
                                bts = reader.ReadBytes(access.Length);
                                if (Encoding.ASCII.GetString(bts) == access)
                                {
                                    localstr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Persist Security Info=False;OLE DB Services=-1", item);
                                    if (!ContainConnStr(localstr)) DAL.AddConnStr("Access_" + Path.GetFileNameWithoutExtension(item), localstr, null, "Access");
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            #endregion

            foreach (String item in DAL.ConnStrs.Keys)
            {
                if (!String.IsNullOrEmpty(DAL.ConnStrs[item].ConnectionString)) list.Add(item);
            }

            #region ̽�������е�������
            String[] sysdbnames = new String[] { "master", "tempdb", "model", "msdb" };

            List<String> names = new List<String>();
            foreach (String item in list)
            {
                try
                {
                    DAL dal = DAL.Create(item);
                    if (dal.DbType != DatabaseType.SqlServer) continue;

                    //DataSet ds = null;
                    DataTable dt = null;
                    String dbprovider = null;

                    // �г��������ݿ�
                    Boolean old = DAL.ShowSQL;
                    DAL.ShowSQL = false;
                    try
                    {
                        //if (dal.DbType == DatabaseType.SqlServer)
                        //{
                        //    if (dal.Db.ServerVersion.StartsWith("08"))
                        //        ds = dal.Select("SELECT name FROM sysdatabases", "");
                        //    else
                        //        ds = dal.Select("SELECT name FROM sys.databases", "");

                        //    dbprovider = dal.Db.ServerVersion.StartsWith("08") ? "sql2000" : "sql2005";
                        //}
                        //else if (dal.DbType == DatabaseType.MySql)
                        //{
                        //    continue;
                        //}
                        //else
                        //    continue;

                        if (dal.Db.CreateMetaData().MetaDataCollections.Contains("Databases"))
                        {
                            dt = dal.Db.CreateSession().GetSchema("Databases", null);
                            dbprovider = dal.DbType.ToString();
                        }
                    }
                    finally { DAL.ShowSQL = old; }

                    if (dt == null) continue;

                    DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
                    builder.ConnectionString = dal.ConnStr;

                    // ͳ�ƿ���
                    foreach (DataRow dr in dt.Rows)
                    {
                        String dbname = dr[0].ToString();
                        if (Array.IndexOf(sysdbnames, dbname) >= 0) continue;

                        String connName = String.Format("{0}_{1}", item, dbname);

                        builder["Database"] = dbname;
                        DAL.AddConnStr(connName, builder.ToString(), null, dbprovider);

                        try
                        {
                            String ver = dal.Db.ServerVersion;
                            names.Add(connName);
                        }
                        catch
                        {
                            if (DAL.ConnStrs.ContainsKey(connName)) DAL.ConnStrs.Remove(connName);
                        }
                    }
                }
                catch
                {
                    if (item == localName) DAL.ConnStrs.Remove(localName);
                }
            }
            #endregion

            if (DAL.ConnStrs.ContainsKey(localName)) DAL.ConnStrs.Remove(localName);
            if (list.Contains(localName)) list.Remove(localName);

            if (names != null && names.Count > 0)
            {
                list.AddRange(names);

                //Conns = list;
                this.Invoke(new Action<List<String>>(SetDatabaseList), list);
            }
        }

        Boolean ContainConnStr(String connstr)
        {
            foreach (String item in DAL.ConnStrs.Keys)
            {
                if (String.Equals(connstr, DAL.ConnStrs[item].ConnectionString, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }

        void SetDatabaseList(List<String> list)
        {
            String str = cbConn.Text;

            cbConn.DataSource = list;
            cbConn.DisplayMember = "value";
            cbConn.Update();

            //Conns = null;
            if (!String.IsNullOrEmpty(str)) cbConn.Text = str;

            if (!String.IsNullOrEmpty(Config.ConnName))
            {
                Int32 n = cbConn.FindString(Config.ConnName);
                if (n >= 0) cbConn.SelectedIndex = n;
            }

            if (cbConn.SelectedIndex < 0 && cbConn.Items != null && cbConn.Items.Count > 0) cbConn.SelectedIndex = 0;
        }

        void SetTables(Object source)
        {
            cbTableList.DataSource = source;
            if (source == null)
                cbTableList.Items.Clear();
            else
            {
                cbTableList.DataSource = source;
                //cbTableList.DisplayMember = "Name";
                cbTableList.ValueMember = "Name";
            }
            cbTableList.Update();
        }

        void AutoLoadTables(String name)
        {
            if (String.IsNullOrEmpty(name)) return;
            if (!DAL.ConnStrs.ContainsKey(name) || String.IsNullOrEmpty(DAL.ConnStrs[name].ConnectionString)) return;

            // �첽����
            ThreadPoolX.QueueUserWorkItem(delegate(Object state) { IList<IDataTable> tables = DAL.Create((String)state).Tables; }, name, null);
        }
        #endregion

        #region ����
        Stopwatch sw = new Stopwatch();
        private void bt_GenTable_Click(object sender, EventArgs e)
        {
            SaveConfig();

            if (cb_Template.SelectedValue == null || cbTableList.SelectedValue == null) return;

            sw.Reset();
            sw.Start();

            try
            {
                //Engine.FixTable();
                String[] ss = Engine.Render((String)cbTableList.SelectedValue);
                //richTextBox1.Text = ss[0];
            }
            catch (TemplateException ex)
            {
                MessageBox.Show(ex.Message, "ģ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sw.Stop();
            lb_Status.Text = "���� " + cbTableList.Text + " ��ɣ���ʱ��" + sw.Elapsed.ToString();
        }

        private void bt_GenAll_Click(object sender, EventArgs e)
        {
            SaveConfig();

            if (cb_Template.SelectedValue == null || cbTableList.Items.Count < 1) return;

            IList<IDataTable> tables = Engine.Tables;
            if (tables == null || tables.Count < 1) return;

            pg_Process.Minimum = 0;
            pg_Process.Maximum = tables.Count;
            pg_Process.Step = 1;
            pg_Process.Value = pg_Process.Minimum;

            List<String> param = new List<string>();
            foreach (IDataTable item in tables)
            {
                param.Add(item.Name);
            }

            bt_GenAll.Enabled = false;

            if (!bw.IsBusy)
            {
                sw.Reset();
                sw.Start();

                bw.RunWorkerAsync(param);
            }
            else
                bw.CancelAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<String> param = e.Argument as List<String>;
            int i = 1;
            //Engine.FixTable();
            foreach (String tableName in param)
            {
                try
                {
                    Engine.Render(tableName);
                }
                catch (TemplateException ex)
                {
                    bw.ReportProgress(i++, "����" + ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    bw.ReportProgress(i++, "����" + ex.ToString());
                    break;
                }

                bw.ReportProgress(i++, "�����ɣ�" + tableName);
                if (bw.CancellationPending) break;
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pg_Process.Value = e.ProgressPercentage;
            proc_percent.Text = (int)(100 * pg_Process.Value / pg_Process.Maximum) + "%";
            lb_Status.Text = e.UserState.ToString();

            if (lb_Status.Text.StartsWith("����")) MessageBox.Show(lb_Status.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pg_Process.Value = pg_Process.Maximum;
            proc_percent.Text = (int)(100 * pg_Process.Value / pg_Process.Maximum) + "%";
            //Engine = null;

            sw.Stop();
            lb_Status.Text = "���� " + cbTableList.Items.Count + " ������ɣ���ʱ��" + sw.Elapsed.ToString();

            bt_GenAll.Enabled = true;
        }
        #endregion

        #region ���ء�����
        public void LoadConfig()
        {
            cbConn.Text = Config.ConnName;
            cb_Template.Text = Config.TemplateName;
            txt_OutPath.Text = Config.OutputPath;
            txt_NameSpace.Text = Config.NameSpace;
            txt_ConnName.Text = Config.EntityConnName;
            txtBaseClass.Text = Config.BaseClass;
            cbRenderGenEntity.Checked = Config.RenderGenEntity;
            txtPrefix.Text = Config.Prefix;
            checkBox1.Checked = Config.AutoCutPrefix;
            checkBox2.Checked = Config.AutoFixWord;
            checkBox3.Checked = Config.UseCNFileName;
            checkBox5.Checked = Config.UseHeadTemplate;
            richTextBox2.Text = Config.HeadTemplate;
            checkBox4.Checked = Config.Debug;
        }

        public void SaveConfig()
        {
            Config.ConnName = cbConn.Text;
            Config.TemplateName = cb_Template.Text;
            Config.OutputPath = txt_OutPath.Text;
            Config.NameSpace = txt_NameSpace.Text;
            Config.EntityConnName = txt_ConnName.Text;
            Config.BaseClass = txtBaseClass.Text;
            Config.RenderGenEntity = cbRenderGenEntity.Checked;
            Config.Prefix = txtPrefix.Text;
            Config.AutoCutPrefix = checkBox1.Checked;
            Config.AutoFixWord = checkBox2.Checked;
            Config.UseCNFileName = checkBox3.Checked;
            Config.UseHeadTemplate = checkBox5.Checked;
            Config.HeadTemplate = richTextBox2.Text;
            Config.Debug = checkBox4.Checked;

            Config.Save();
        }
        #endregion

        #region ����ӳ���ļ�
        private void button1_Click(object sender, EventArgs e)
        {
            //if (Engine == null) return;

            //IList<IDataTable> tables = Engine.Tables;
            //if (tables == null || tables.Count < 1) return;

            //foreach (IDataTable table in tables)
            //{
            //    Engine.AddWord(table.Name, table.Description);
            //    foreach (IDataColumn field in table.Columns)
            //    {
            //        Engine.AddWord(field.Name, field.Description);
            //    }
            //}

            //MessageBox.Show("��ɣ�", this.Text);
        }
        #endregion

        #region ������Ϣ
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            String url = String.Empty;
            if (control.Tag != null) url = control.Tag.ToString();
            if (String.IsNullOrEmpty(url)) url = control.Text;
            if (String.IsNullOrEmpty(url)) return;

            Process.Start(url);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Clipboard.SetData("10193406", null);
            MessageBox.Show("QQȺ���Ѹ��Ƶ����а壡", "��ʾ");
        }

        List<Article> articles = new List<Article>();

        void UpdateArticles()
        {
            String url = "http://www.cnblogs.com/nnhy/rss";
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            XmlNodeList nodes = doc.SelectNodes(@"//item");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode item in nodes)
                {
                    Article entity = new Article();
                    entity.Title = item.SelectSingleNode("title").InnerText;
                    entity.Link = item.SelectSingleNode("link").InnerText;
                    entity.Description = item.SelectSingleNode("description").InnerText;

                    try
                    {
                        entity.PubDate = Convert.ToDateTime(item.SelectSingleNode("pubDate").InnerText);
                    }
                    catch { }

                    #region ǿ�Ƶ���
                    //if (entity.PubDate > DateTime.MinValue)
                    //{
                    //    Int32 h = (Int32)(DateTime.Now - entity.PubDate).TotalHours;
                    //    if (h < 24 * 30)
                    //    {
                    //        Random rnd = new Random((Int32)DateTime.Now.Ticks);
                    //        // ʱ��Խ�ã�hԽ�������Ϊ0�Ŀ����Ծ�ԽС�������Ŀ����Ծ�ԽС
                    //        // һСʱ֮�ڣ���50%�Ŀ�����
                    //        if (rnd.Next(0, h + 1) == 0)
                    //        {
                    //            Process.Start(entity.Link);
                    //        }
                    //    }
                    //}
                    #endregion

                    articles.Add(entity);
                }
            }

            if (articles.Count > 0)
            {
                Article entity = articles[0];
                if (entity.Title != Config.LastBlogTitle)
                {
                    Config.LastBlogTitle = entity.Title;
                    Config.Save();

                    Process.Start(entity.Link);
                }
            }
        }

        Int32 articleIndex = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (articles != null && articles.Count > 0)
            {
                if (articleIndex >= articles.Count) articleIndex = 0;
                Article entity = articles[articleIndex];

                linkLabel1.Text = entity.Title;
                linkLabel1.Tag = entity.Link;

                articleIndex++;
            }
        }

        class Article
        {
            public String Title;
            public String Link;
            public DateTime PubDate;
            public String Description;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            try
            {
                //String url = "http://www.7765.com/api/";
                String url = "http://www.nnhy.org/j";
                url += String.Format("?tag=XCoder_v{0}&r={1}&ID=2", Engine.FileVersion, DateTime.Now.Ticks);
                webBrowser1.Navigate(url);
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }
        }
        #endregion

        #region �����Ŀ¼
        private void btnOpenOutputDir_Click(object sender, EventArgs e)
        {
            String dir = txt_OutPath.Text;
            dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);

            Process.Start("explorer.exe", "\"" + dir + "\"");
            //Process.Start("explorer.exe", "/root,\"" + dir + "\"");
            //Process.Start("explorer.exe", "/select," + dir);
        }
        #endregion

        #region ģ�͹���
        private void btnShowSchema_Click(object sender, EventArgs e)
        {
            String connName = "" + cbConn.SelectedValue;
            if (String.IsNullOrEmpty(connName)) return;

            FrmSchema.Create(DAL.Create(connName).Db).Show();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            String connName = "" + cbConn.SelectedValue;
            if (String.IsNullOrEmpty(connName)) return;

            FrmQuery.Create(DAL.Create(connName)).Show();
        }

        private void btnShowMetaData_Click(object sender, EventArgs e)
        {
            List<IDataTable> tables = Engine.Tables;
            if (tables == null || tables.Count < 1) return;

            FrmModel.Create(tables).Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK || String.IsNullOrEmpty(openFileDialog1.FileName)) return;
            try
            {
                List<IDataTable> list = DAL.Import(File.ReadAllText(openFileDialog1.FileName));

                Engine = null;
                Engine.Tables = list;

                SetTables(list);

                gbTable.Enabled = true;
                btnShowSchema.Enabled = false;

                MessageBox.Show("����ܹ��ɹ�����" + (list == null ? 0 : list.Count) + "�ű�", "����ܹ�", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnExportModel_Click(object sender, EventArgs e)
        {
            List<IDataTable> tables = Engine.Tables;
            if (tables == null || tables.Count < 1)
            {
                MessageBox.Show(this.Text, "���ݿ�ܹ�Ϊ�գ�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!String.IsNullOrEmpty(Config.ConnName))
            {
                String file = Config.ConnName + ".xml";
                String dir = null;
                if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
                    dir = Path.GetDirectoryName(saveFileDialog1.FileName);
                if (String.IsNullOrEmpty(dir)) dir = AppDomain.CurrentDomain.BaseDirectory;
                //saveFileDialog1.FileName = Path.Combine(dir, file);
                saveFileDialog1.InitialDirectory = dir;
                saveFileDialog1.FileName = file;
            }
            if (saveFileDialog1.ShowDialog() != DialogResult.OK || String.IsNullOrEmpty(saveFileDialog1.FileName)) return;
            try
            {
                String xml = DAL.Export(tables);
                File.WriteAllText(saveFileDialog1.FileName, xml);

                MessageBox.Show("�����ܹ��ɹ���", "�����ܹ�", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region ģ�����
        public void BindTemplate(ComboBox cb)
        {
            List<String> list = Engine.FileTemplates;
            foreach (String item in Engine.Templates.Keys)
            {
                String[] ks = item.Split('.');
                if (ks == null || ks.Length < 1) continue;

                String name = "*" + ks[0];
                if (!list.Contains(name)) list.Add(name);
            }
            cb.Items.Clear();
            cb.DataSource = list;
            cb.DisplayMember = "value";
            cb.Update();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            try
            {
                FileSource.ReleaseAllTemplateFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void frmItems_Click(object sender, EventArgs e)
        {
            //FrmItems.Create(XConfig.Current.Items).Show();

            FrmItems.Create(XConfig.Current).Show();
        }
    }
}