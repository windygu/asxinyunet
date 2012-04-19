//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Utilities;
    using DotNet.Business;
    
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// FrmMessageBroadcast.cs
    /// 发送消息
    ///		
    /// 修改记录
    /// 
    ///     2011.12.11 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.12.11</date>
    /// </author> 
    /// </summary>
    public partial class FrmMessageBroadcast : BaseForm
    {
        public FrmMessageBroadcast()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
            this.txtContent.Tag = false;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSend.Enabled = this.txtContent.Text.Length > 0;
        }
        #endregion

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            StringBuilder sbmy = new StringBuilder();
            sbmy.Append("<div style='margin:2px;padding:0px 0px 0px 15px;" +
                    "font-family:" + this.txtContent.Font.FontFamily.Name + ";" +
                    "font-size:" +
                    this.txtContent.Font.Size + "pt;color:#" +
                    this.txtContent.ForeColor.R.ToString("X2") +
                    this.txtContent.ForeColor.G.ToString("X2") +
                    this.txtContent.ForeColor.B.ToString("X2"));
            sbmy.Append(";font-weight:");
            sbmy.Append(this.txtContent.Font.Bold ? "bold" : "");
            sbmy.Append(";font-style:");
            sbmy.Append(this.txtContent.Font.Italic ? "italic" : "");
            sbmy.Append(";'>");
            sbmy.Append(GetHtmlHref(this.txtContent.Text) + "</div>");

            DotNetService dotNetService = new DotNetService();

            // 发送信息
            BaseMessageEntity messageEntity = new BaseMessageEntity();
            messageEntity.Id = BaseBusinessLogic.NewGuid();
            messageEntity.FunctionCode = MessageFunction.Message.ToString();
            messageEntity.Contents = sbmy.ToString();
            messageEntity.IsNew = 1;
            messageEntity.ReadCount = 0;
            messageEntity.Enabled = 1;
            messageEntity.DeletionStateCode = 0;
            dotNetService.MessageService.Broadcast(UserInfo, messageEntity);            
            if (dotNetService.MessageService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.MessageService).Close();
            }
            // 2010-12-15 发好信息了，还是关闭了比较好
            // this.txtContent.Clear();
            // this.txtContent.Focus();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}