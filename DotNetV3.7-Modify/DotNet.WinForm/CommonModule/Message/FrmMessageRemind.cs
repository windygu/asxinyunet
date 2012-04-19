//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace DotNet.WinForm
{
    using DotNet.Business;

    /// <summary>
    /// FrmMessageRemind.cs
    /// 消息提醒
    ///		
    /// 修改记录
    /// 
    ///     2007.10.31 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.10.31</date>
    /// </author> 
    /// </summary>
    public partial class FrmMessageRemind : BaseForm
    {
        private string FromStaffFullName = string.Empty;
        private string FromStaffId = string.Empty;
        private string MessageId = string.Empty;

        private StringBuilder sbContent = new StringBuilder();

        public FrmMessageRemind()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        public FrmMessageRemind(string messageId, string fromStaffId, string fromStaffFullName, string content) : this()
        {
            this.SetRemind(messageId, fromStaffId, fromStaffFullName, content);
        }

        public void SetRemind(string messageId, string fromStaffId, string fromStaffFullName, string content)
        {
            this.lblFrom.Text = fromStaffFullName;
            this.MessageId = messageId;
            this.FromStaffId = fromStaffId;
            sbContent.Append(content);
            BindWebMsgContent();
            //this.txtContent.Text = content;
            this.SetControlState();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.FromStaffId.Length == 0)
            {
                this.btnReply.Enabled = false;
            }
            else
            {
                this.btnReply.Enabled = true;
            }
        }
        #endregion

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (this.FromStaffId.Length > 0)
            {
                this.Hide();
                ((FrmMessage)this.Owner).ShowMessageRead(this.FromStaffId, this.FromStaffFullName, this.Owner);
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DotNetService dotNetService = new DotNetService();
            dotNetService.MessageService.Read(UserInfo, this.MessageId);
            if (dotNetService.MessageService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.MessageService).Close();
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMessageRemind_Load(object sender, EventArgs e)
        {

        }

        private void webBMsg_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBMsg.DocumentText == "<HTML></HTML>\0")
                BindWebMsgContent();
        }

        private void BindWebMsgContent()
        {
            this.webBMsg.DocumentText = @"<body style=""margin: 3px;font-family:宋体"" onload=""scrollBy(0,document.body.scrollHeight)"">" +
                    @"<script language=""javascript"" type=""text/javascript"">document.oncontextmenu=new Function(""event.returnValue=false;""); </script>" +  //屏蔽右键
                    GetHtmlFace(sbContent.ToString());
        }

        private string GetHtmlFace(string html)
        {
            if (String.IsNullOrEmpty(html.Trim()))
                return "";
            else
            {
                string path = Application.StartupPath;
                Regex regex = new Regex(@"\{\[(\d+)\]\}", RegexOptions.IgnoreCase
                    | RegexOptions.CultureInvariant
                    | RegexOptions.IgnorePatternWhitespace
                    | RegexOptions.Compiled);
                html = regex.Replace(html, "<img src=\"" + Application.StartupPath + "\\Face\\Face_" + "$1" + ".gif\" style=\"vertical-align:middle;\" />");
                playSound();
                return html;
            }
        }

        //播放音乐
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);//播放windows音乐，重载
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;
        string strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Media\\msg.wav";

        void playSound()
        {
            PlaySound(strPath, 0, SND_ASYNC | SND_FILENAME);
        }
    }
}