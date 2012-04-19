﻿//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmMessageRead.cs
    /// 发送消息
    ///		
    /// 修改记录
    /// 
    ///     2008.01.10 版本：1.2 JiRiGaLa 将信息在本窗口标记为已阅读。
    ///     2008.01.06 版本：1.1 JiRiGaLa 诱惑获得信息的方法，从主窗口统一获取信息。
    ///     2007.10.30 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.10.30</date>
    /// </author> 
    /// </summary>
    public partial class FrmMessageRead : BaseForm
    {
        public FrmMessage FrmMessageOwner = null;

        /// <summary>
        /// 发送给谁的主键
        /// </summary>
        public string ReceiverId = string.Empty;
        
        /// <summary>
        /// 发送给谁
        /// </summary>
        public string ReceiverFullName = string.Empty;

        private delegate bool SetMessage(BaseMessageEntity messageEntity);    // 防止线程阻塞的写法

        public StringBuilder strOneShow = new StringBuilder();  //聊天内容（带样式）字符串

        public FrmMessageRead()
        {
            InitializeComponent();
        }

        public FrmMessageRead(string receiverId, string receiverFullName)
            : this()
        {
            this.ReceiverFullName = receiverFullName;
            this.ReceiverId = receiverId;
            this.Text += " (" + this.ReceiverFullName + ")";
        }

        private string ReplaceMessage(string contents)
        {
            string webHostUrl = string.Empty;
            contents = contents.Replace("{OpenId}", this.UserInfo.OpenId);
            webHostUrl = ConfigurationManager.AppSettings["WebHostUrl1"];
            if (!string.IsNullOrEmpty(webHostUrl))
            {
                contents = contents.Replace("{WebHostUrl1}", webHostUrl);
            }
            webHostUrl = ConfigurationManager.AppSettings["WebHostUrl2"];
            if (!string.IsNullOrEmpty(webHostUrl))
            {
                contents = contents.Replace("{WebHostUrl2}", webHostUrl);
            }
            webHostUrl = ConfigurationManager.AppSettings["WebHostUrl"];
            if (!string.IsNullOrEmpty(webHostUrl))
            {
                contents = contents.Replace("{WebHostUrl}", webHostUrl);
            }
            return contents;
        }

        public bool OnReceiveMessage(BaseMessageEntity messageEntity)
        {
            bool returnValue = false;
            // 判断消息，是否发送给本窗体的
            //if (this.ReceiverId.Equals(Message.ReceiverId))
            //{
            returnValue = true;
            if (this.InvokeRequired)
            {
                SetMessage SetMessage = new SetMessage(OnReceiveMessage);
                this.Invoke(SetMessage, new object[] { messageEntity });
            }
            else
            {
                //this.txtMessage.AppendText(messageEntity.CreateBy + " " + ((DateTime)messageEntity.CreateOn).ToString(BaseSystemInfo.DateTimeFormat) + " 说: " + "\r\n");
                //this.txtMessage.AppendText(messageEntity.Content + "\r\n");
                //this.txtMessage.AppendText("- - - - - - - - - - - - - - -" + "\r\n");
                //this.txtMessage.ScrollToCaret();

                //StringBuilder sbContent = new StringBuilder();
                //sbContent.Append("<div style='color:#00f;font-size:12px;'>" + messageEntity.CreateBy + " [");
                //if (isToday((DateTime)messageEntity.CreateOn))
                //{
                //    sbContent.Append(((DateTime)messageEntity.CreateOn).ToLongTimeString() + "]：</div>");
                //}
                //else
                //{
                //    sbContent.Append(((DateTime)messageEntity.CreateOn).ToString(BaseSystemInfo.DateTimeFormat) + "]：</div>");
                //}
                //// Web里的单点登录识别码进行转换 
                //messageEntity.Contents = messageEntity.Contents.Replace("{OpenId}", this.UserInfo.OpenId);
                //sbContent.Append(messageEntity.Contents);
                //strOneShow.Append(sbContent.ToString());
                //this.webBMsg.DocumentText = this.webBMsg.DocumentText.Insert(this.webBMsg.DocumentText.Length, sbContent.ToString());

                messageEntity.Contents = ReplaceMessage(messageEntity.Contents);
                
                StringBuilder sbContent = new StringBuilder();
                sbContent.Append("<div style='color:#00f;font-size:12px;'>" + messageEntity.CreateBy + " [");
                if (isToday((DateTime)messageEntity.CreateOn))
                {
                    sbContent.Append(((DateTime)messageEntity.CreateOn).ToLongTimeString() + "]：</div>");
                }
                else
                {
                    sbContent.Append(((DateTime)messageEntity.CreateOn).ToString(BaseSystemInfo.DateTimeFormat) + "]：</div>");
                }
                sbContent.Append(messageEntity.Contents);
                strOneShow.Append(sbContent.ToString());
                this.webBMsg.DocumentText = this.webBMsg.DocumentText.Insert(this.webBMsg.DocumentText.Length, GetHtmlFace(sbContent.ToString()));

                PlaySound();
            }
            //}
            return returnValue;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (!this.ReceiverId.Equals(this.UserInfo.Id))
            {
                this.btnSend.Enabled = (!string.IsNullOrEmpty(this.ReceiverId) && (this.txtContent.Text.Length > 0));
            }
        }
        #endregion

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            // 设置按钮状态
            this.SetControlState();
        }

        #region private void SendMessage() 发送消息
        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendMessage()
        {
            this.btnSend.Enabled = false;
            StringBuilder sbmy = new StringBuilder();
            // 不是发给自己的消息
            if (!UserInfo.Id.Equals(this.ReceiverId))
            {
                // 设置信息样式 GGYY
                string sendName = "<div style='color:#00f;font-size:12px;margin:2px;padding:0px'>" + UserInfo.RealName + " [" + DateTime.Now.ToLongTimeString() + "]:</div>";
                sbmy.Append("<div style='margin:2px;padding:0px 0px 0px 15px;" +
                    "font-family:" + txtContent.Font.FontFamily.Name + ";" +
                    "font-size:" +
                    txtContent.Font.Size + "pt;color:#" +
                    txtContent.ForeColor.R.ToString("X2") +
                    txtContent.ForeColor.G.ToString("X2") +
                    txtContent.ForeColor.B.ToString("X2"));
                sbmy.Append(";font-weight:");
                sbmy.Append(txtContent.Font.Bold ? "bold" : "");
                sbmy.Append(";font-style:");
                sbmy.Append(txtContent.Font.Italic ? "italic" : "");
                sbmy.Append(";'>");
                sbmy.Append(GetHtmlHref(this.txtContent.Text) + "</div>");

                this.webBMsg.DocumentText = this.webBMsg.DocumentText.Insert(this.webBMsg.DocumentText.Length, sendName + GetHtmlFace(sbmy.ToString()));
                //this.webBMsg.DocumentText = this.webBMsg.DocumentText.Insert(this.webBMsg.DocumentText.Length, strSendName + sbmy.ToString());
                //sb1.Insert(0, strSendName);
            }
            DotNetService dotNetService = new DotNetService();
            dotNetService.MessageService.Send(UserInfo, this.ReceiverId, sbmy.ToString());
            if (dotNetService.MessageService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.MessageService).Close();
            }
            this.txtContent.Clear();
            this.txtContent.Focus();
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 发送消息
            this.SendMessage();
        }

        private void FrmMessageRead_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                //((FrmMessage)this.Owner).ReceiveUserList.Remove(this.ReceiverId);
                //((FrmMessage)this.Owner).OnReceiveMessage -= this.OnReceiveMessage;
                ((FrmMessage)this.FrmMessageOwner).ReceiveUserList.Remove(this.ReceiverId);
                ((FrmMessage)this.FrmMessageOwner).OnReceiveMessage -= this.OnReceiveMessage;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMessageRead_Load(object sender, EventArgs e)
        {
            //初始化窗体时加载 GGYY
            this.webBMsg.Navigate("about:blank");
            this.webBMsg.DocumentText = @"<body style=""margin: 3px;font-family:宋体"" onload=""scrollBy(0,document.body.scrollHeight)"">" +
               @"<script language=""javascript"" type=""text/javascript"">document.oncontextmenu=new Function(""event.returnValue=false;""); </script>"; //屏蔽右键
        }

        private string GetHtmlHref(string html)
        {
            Regex regex = new Regex(@"(http:\/\/([\w.]+\/?)\S*) ", RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled);
            html = regex.Replace(html, "<a href=\"$1\" target=\"_blank\">$1</a>");
            return html;
        }

        //表情图标字符串替换为html显示
        private string GetHtmlFace(string html)
        {
            string path = Application.StartupPath;
            Regex regex = new Regex(@"\{\[(\d+)\]\}", RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled);
            html = regex.Replace(html, "<img src=\"" + Application.StartupPath + "\\Face\\Face_" + "$1" + ".gif\" style=\"vertical-align:middle;\" />");
            return html;
        }

        //设置消息颜色
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialogMsg.ShowDialog() != DialogResult.Cancel)
            {
                txtContent.ForeColor = colorDialogMsg.Color;
            }
        }

        // 设置消息字体 
        private void btnMsgFont_Click(object sender, EventArgs e)
        {
            if (fontDialogMsg.ShowDialog() != DialogResult.Cancel)
            {
                txtContent.Font = fontDialogMsg.Font;
            }
        }

        // 弹出显示加载不成功时重新加载一次 GGYY
        private void webBMsg_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBMsg.DocumentText == "<HTML></HTML>\0")
            {
                this.webBMsg.DocumentText = @"<body style=""margin: 3px;font-family:宋体"" onload=""scrollBy(0,document.body.scrollHeight)"">" +
                   @"<script language=""javascript"" type=""text/javascript"">document.oncontextmenu=new Function(""event.returnValue=false;""); </script>" +  //屏蔽右键
                   GetHtmlFace(strOneShow.ToString()); //屏蔽右键
            }
        }

        // 检查日期是否今天 
        public static bool isToday(DateTime dt)
        {
            DateTime today = DateTime.Today;
            DateTime tempToday = new DateTime(dt.Year, dt.Month, dt.Day);
            if (today == tempToday)
                return true;
            else
                return false;
        }

        public ImagePopup _faceForm = null;
        public ImagePopup FaceForm
        {
            get
            {
                if (this._faceForm == null)
                {
                    this._faceForm = new ImagePopup
                    {
                        ImagePath = "Face\\",
                        //CustomImagePath = "Face\\Custom\\",
                        CanManage = true,
                        ShowDemo = true,
                    };

                    this._faceForm.Init(24, 24, 8, 8, 12, 8);
                    this._faceForm.Selected += this._faceForm_AddFace;

                }

                return this._faceForm;
            }
        }


        void _faceForm_AddFace(object sender, SelectFaceArgs e)
        {
            string imgName = "";
            int? imgInt = null;

            imgName = e.Img.FullName.Replace(Application.StartupPath + "\\", "");
            imgInt = Tools.GetNumberInt(imgName);
            int i = this.txtContent.SelectionStart;
            string result = this.txtContent.Text;
            imgName = "{[" + imgInt + "]}";
            result = result.Insert(i, imgName);
            this.txtContent.Text = result;
            this.txtContent.SelectionStart = i + imgName.Length;
        }

        private void btnSelectFack_Click(object sender, EventArgs e)
        {
            Point pt = this.PointToScreen(new Point(((Button)sender).Left, ((Button)sender).Height + 5));
            this.FaceForm.Show(pt.X, pt.Y, ((Button)sender).Height);
        }

        // 播放音乐
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);//播放windows音乐，重载
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;
        string strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Media\\msg.wav";

        void PlaySound()
        {
            PlaySound(strPath, 0, SND_ASYNC | SND_FILENAME);
        }

        private void FrmMessageRead_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void FrmMessageRead_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DotNetService dotNetService = new DotNetService();
                    for (int i = 0; i <= file.Length - 1; i++)
                    {
                        if (System.IO.File.Exists(file[i]))
                        {
                            byte[] fileContents = FileUtil.GetFile(file[i]);
                            string fileName = System.IO.Path.GetFileName(file[i]);
                            dotNetService.FileService.Send(UserInfo, fileName, fileContents, this.ReceiverId);
                            // this.Text = this.webBMsg.DocumentText.Length.ToString();
                            string message = "发送文件 " + fileName + " 成功，等待对方接收。";
                            if (this.webBMsg.DocumentText.Length > 216)
                            {
                                message = "<br>" + message;
                            }
                            this.webBMsg.DocumentText = this.webBMsg.DocumentText.Insert(this.webBMsg.DocumentText.Length, message);
                        }
                    }
                    if (dotNetService.MessageService is ICommunicationObject)
                    {
                        ((ICommunicationObject)dotNetService.MessageService).Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
    }
}