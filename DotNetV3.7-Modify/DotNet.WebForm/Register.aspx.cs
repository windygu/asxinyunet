//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

using DotNet.Business;
using DotNet.Utilities;

/// <remarks>
/// Register
/// 注册
///		
/// 修改记录
///
///		2008.12.21 版本：1.0 JiRiGaLa 建立代码。 
///		
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2008.12.21</date>
/// </author> 
/// </remarks>
public partial class Register : BasePage
{
    private BaseUserInfo userInfo = null;
    /// <summary>
    /// 当前操作员信息对象
    /// </summary>
    public BaseUserInfo UserInfo
    {
        get
        {
            if (userInfo == null)
            {
                userInfo = Utilities.GetUserInfo();
            }
            return userInfo;
        }
        set
        {
            this.userInfo = value;
        }
    }

    private readonly string EncryptValue = "Project";

    new protected void Page_Load(object sender, EventArgs e)
    {
        // 设置页面不被缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");
    }

    #region private bool CheckInput() 检查页面输入
    /// <summary>
    /// 检查页面输入
    /// </summary>
    /// <returns>是否正确</returns>
    private bool CheckInput()
    {
        string checkInput = string.Empty;

        if (this.txtEmail.Value.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入您的电子邮箱。'); document.getElementById('" + this.txtEmail.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (!ValidateUtil.IsEmail(txtEmail.Value.Trim()))
        {
            checkInput = "<script>alert('提示信息：您输入的电子邮箱格式不正确。'); document.getElementById('" + this.txtEmail.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (txtUserName.Value.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入用户名。'); document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (this.txtPwd.Value.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入密码。'); document.getElementById('" + this.txtPwd.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtPwd.Value.Trim(), @"^\w{6,32}$"))
        {
            checkInput = "<script>alert('提示信息：输入的密码长度必须为6-32位。'); document.getElementById('" + this.txtPwd.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (this.txtPwd2.Value.Trim().Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入确认密码。'); document.getElementById('" + this.txtPwd2.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (!this.txtPwd.Value.Trim().Equals(this.txtPwd2.Value.Trim()))
        {
            checkInput = "<script>alert('提示信息：确认密码不正确，请重新输入。'); document.getElementById('" + this.txtPwd2.ClientID + "').focus();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }

        if (Session["CheckCode"] != null && String.IsNullOrEmpty(Session["CheckCode"].ToString()))
        {
            if (!this.txtCaptcha.Value.Trim().ToUpper().Equals(Session["CheckCode"].ToString()))
            {
                checkInput = "<script>document.getElementById('captchaTip').innerHTML = '验证码输入有误，请重新输入。';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
                this.txtCaptcha.Value = "";
                this.txtCaptcha.Focus();
                return false;
            }
        }
        return true;
    }
    #endregion

    #region public string Encrypt(string text)加密
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="Text"></param>
    /// <returns></returns>
    public string Encrypt(string text)
    {
        if (String.IsNullOrEmpty(EncryptValue) || EncryptValue == "")
        {
            return Encrypt(text, "Administrator");
        }
        return Encrypt(text, EncryptValue);
    }

    /// <summary> 
    /// 加密数据 
    /// </summary> 
    /// <param name="Text"></param> 
    /// <param name="sKey"></param> 
    /// <returns></returns> 
    public string Encrypt(string text, string key)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] inputByteArray;
        inputByteArray = Encoding.Default.GetBytes(text);
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").Substring(0, 8));
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").Substring(0, 8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        StringBuilder ret = new StringBuilder();
        foreach (byte b in ms.ToArray())
        {
            ret.AppendFormat("{0:X2}", b);
        }
        return ret.ToString();
    }

    #endregion

    #region public string Decrypt(string text)解密
    /// <summary>
    /// 解密
    /// </summary>
    public string Decrypt(string text)
    {
        if (String.IsNullOrEmpty(EncryptValue) || EncryptValue == "")
        {
            return Encrypt(text, "Administrator");
        }
        return Encrypt(text, EncryptValue);
    }

    /// <summary> 
    /// 解密数据 
    /// </summary> 
    public string Decrypt(string text, string key)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        int len;
        len = text.Length / 2;
        byte[] inputByteArray = new byte[len];
        int x, i;
        for (x = 0; x < len; x++)
        {
            i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
            inputByteArray[x] = (byte)i;
        }
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").Substring(0, 8));
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").Substring(0, 8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Encoding.Default.GetString(ms.ToArray());
    }
    #endregion

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (this.CheckInput())
        {
            string returnStatusCode = string.Empty;
            string returnStatusMessage = string.Empty;
            //string code = this.Encrypt(this.txtUserName.Value.Trim());
            BaseUserEntity userEntity = new BaseUserEntity();
            userEntity.UserName = this.txtUserName.Value.Trim();//用户名_
            userEntity.UserPassword = this.txtPwd.Value.Trim();//用户密码_ 

            // DotNetService.Instance.UserService.AddUser(this.UserInfo, string.Empty, string.Empty, string.Empty, string.Empty, this.txtUserName.Value.Trim(), this.txtUserName.Value.Trim(), code, DefaultRole.User.ToString(), this.txtPwd.Value, this.txtEmail.Value, string.Empty, false, string.Empty, out returnStatusCode, out returnStatusMessage);
            DotNetService dotNetService = new DotNetService();
            dotNetService.UserService.AddUser(this.UserInfo, userEntity, out returnStatusCode, out returnStatusMessage);
            if (returnStatusCode.Equals(StatusCode.OKAdd.ToString()))
            {
                Session["Email"] = this.txtEmail.Value.Trim();
                this.Page.Response.Redirect("register2.aspx");
            }
            else
            {
                if (Utilities.ShowInformation)
                {
                    string checkInput = "<script>alert('提示信息：" + returnStatusMessage + "');document.getElementById('" + this.txtEmail.ClientID + "').focus();</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
                    this.txtUserName.Focus();
                }
            }
        }
    }
}