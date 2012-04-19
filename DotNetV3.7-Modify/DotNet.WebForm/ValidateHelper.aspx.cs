//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;

public partial class ValidateHelper : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DrawingVerifyCodeImage();
    }

    #region VerifyCode
    public static string SessionNameVerifyCode
    {
        get
        {
            return "VerifyCode";
        }
    }

    /// <summary>
    /// 画安全码图片
    /// </summary>
    public static void DrawingVerifyCodeImage()
    {
        VerifyCodeImage verifyCodeImage = new VerifyCodeImage();
        // 取随机码
        string code = verifyCodeImage.CreateVerifyCode().ToUpper();
        // 输出图片
        verifyCodeImage.CreateImageOnPage(code, 3, HttpContext.Current);
        // 使用Session取验证码的值              
        HttpContext.Current.Session[SessionNameVerifyCode] = code;                        
    }

    /// <summary>
    /// 验证安全码
    /// </summary>
    /// <param name="code">输入的安全码</param>
    /// <returns>成功与否</returns>
    public static bool ValidateVerifyCode(string code)
    {
        if (HttpContext.Current.Session[SessionNameVerifyCode] != null)
        {
            string verifyCode = HttpContext.Current.Session[SessionNameVerifyCode].ToString().Trim();
            if (verifyCode != string.Empty && verifyCode.ToLower() == code.ToLower())
            {
                return true;
            }
        }
        return false;
    }
    #endregion

    #region Validate
    /// <summary>
    /// 验证用户名
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <returns>成功与否</returns>
    public static bool ValidateUserName(string userName)
    {
        bool success = false;
        if (!string.IsNullOrEmpty(userName))
        {
            string format = @"^[0-9a-zA-Z_]{5,20}$";
            if (Regex.IsMatch(userName, format))
            {
                format = @"(anonymous)|(admin)|(administrator)|(官方)|(管理)|(客服)";
                if (!Regex.IsMatch(userName, format, RegexOptions.IgnoreCase))
                {
                    success = true;
                }
            }
        }
        return success;
    }

    /// <summary>
    /// 验证Email
    /// </summary>
    /// <param name="email">email</param>
    /// <returns>成功与否</returns>
    public static bool ValidateEmail(string email)
    {
        string format = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        return Regex.IsMatch(email, format);
    }

    /// <summary>
    /// 验证密码格式
    /// </summary>
    /// <param name="password">密码</param>
    /// <returns>成功与否</returns>
    public static bool ValidatePassword(string password)
    {
        string format = @"^\S{6,20}$";
        return Regex.IsMatch(password, format);
    }

    /// <summary>
    /// 验证手机
    /// </summary>
    /// <param name="mobile">手机号</param>
    /// <returns>成功与否</returns>
    public static bool ValidateMobile(string mobile)
    {
        string format = @"^(13\d{9})|(15\d{9})|(18\d{9})$";
        return Regex.IsMatch(mobile, format);
    }
    #endregion
}