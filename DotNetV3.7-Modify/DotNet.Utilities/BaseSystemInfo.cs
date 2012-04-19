//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// BaseSystemInfo
    /// 这是系统的核心基础信息部分
    /// 
    /// 修改记录
    ///     2012.02.02 版本：3.8 zhangyi    修改OrganizeDynamicLoading = true。
    ///     2011.10.07 版本：2.3 JiRiGaLa   每个数据库都支持多类型数据库。
    ///     2011.07.15 版本：2.2 JiRiGaLa   参数信息整理，获取硬件信息的功能部分进行分离。
    ///     2011.07.07 版本：2.1 zgl        优化获取IP地址和Mac地址的方法
    ///		2010.09.19 版本：2.0 JiRiGaLa   彻底进行重构。
    ///		2007.04.02 版本：1.2 JiRiGaLa   进行主键优化。
    ///		2007.01.02 版本：1.1 JiRiGaLa   进行主键优化。
    ///		2006.02.05 版本：1.1 JiRiGaLa	重新调整主键的规范化。
    ///		2004.11.19 版本：1.0 JiRiGaLa	主键创建。
    ///		
    /// 版本：2.3
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.07</date>
    /// </author>
    /// </summary>
    public partial class BaseSystemInfo
    {
        /// <summary>
        /// 用户是否已经成功登录系统
        /// </summary>
        public static bool UserIsLogOn = false;

        /// <summary>
        /// 用户在线状态
        /// </summary>
        public static int OnLineState = 0;


        #region 客户端的配置信息部分
        
        /// <summary>
        /// 当前用户名
        /// </summary>
        public static string CurrentUserName = string.Empty;

        /// <summary>
        /// 当前密码
        /// </summary>
        public static string CurrentPassword = string.Empty;

        /// <summary>
        /// 登录是否保存密码，默认能记住密码会好用一些
        /// </summary>
        public static bool RememberPassword = true;

        /// <summary>
        /// 是否自动登录，默认不自动登录会好一些
        /// </summary>
        public static bool AutoLogOn = false;

        /// <summary>
        /// 客户端加密存储密码，这个应该是要加密才可以
        /// </summary>
        public static bool ClientEncryptPassword = true;

        /// <summary>
        /// 远程调用Service用户名（为了提高软件的安全性）
        /// </summary>
        public static string ServiceUserName = "Jirisoft";

        /// <summary>
        /// 远程调用Service密码（为了提高软件的安全性）
        /// </summary>
        public static string ServicePassword = "Jirisoft";
        
        /// <summary>
        /// 默认加载所有用户用户量特别大时的优化配置项目，默认是小规模用户
        /// </summary>
        public static bool LoadAllUser = true;

        /// <summary>
        /// 动态加载组织机构树，当数据量非常庞大时用的参数，默认是小规模用户
        /// </summary>
        public static bool OrganizeDynamicLoading = true;

        /// <summary>
        /// 是否采用多语言
        /// </summary>
        public static bool MultiLanguage = false;

        /// <summary>
        /// 当前客户选择的语言
        /// </summary>
        public static string CurrentLanguage = "zh-CN";

        /// <summary>
        /// 当前语言
        /// </summary>
        public static string Themes = string.Empty;

        private int lockWaitMinute = 60;

        /// <summary>
        /// 锁定等待时间分钟
        /// </summary>
        public int LockWaitMinute
        {
            get { return lockWaitMinute; }
            set { lockWaitMinute = value; }
        }

        /// <summary>
        /// 即时通信指向的网站地址
        /// </summary>
        public static string WebHostUrl = "WebHostUrl";

        #endregion
        
        #region 系统性的参数配置
        
        /// <summary>
        /// 软件是否需要注册
        /// </summary>
        public static bool NeedRegister = true;        

        /// <summary>
        /// 检查周期5分钟内不在线的，就认为是已经没在线了，生命周期检查
        /// </summary>
        public static int OnLineTime0ut = 5*60 +20;

        /// <summary>
        /// 每过1分钟，检查一次在线状态
        /// </summary>
        public static int OnLineCheck = 60;

        /// <summary>
        /// 注册码
        /// </summary>
        public static string RegisterKey = string.Empty;

        /// <summary>
        /// 当前网站的安装地址
        /// </summary>
        public static string StartupPath = string.Empty;

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public static bool MatchCase = true;

        /// <summary>
        /// 最多获取数据的行数限制
        /// </summary>
        public static int TopLimit = 200;

        /// <summary>
        /// 锁不住记录时的循环次数
        /// </summary>
        public static int LockNoWaitCount = 5;

        /// <summary>
        /// 锁不住记录时的等待时间
        /// </summary>
        public static int LockNoWaitTickMilliSeconds = 30;

        /// <summary>
        /// 是否采用服务器端缓存
        /// </summary>
        public static bool ServerCache = false;

        /// <summary>
        /// 最后更新日期
        /// </summary>
        public static string LastUpdate = "2011.10.07";

        /// <summary>
        /// 当前版本
        /// </summary>
        public static string Version = "3.7";

        /// <summary>
        /// 每个操作是否进行信息提示。
        /// </summary>
        public static bool ShowInformation = true;

        /// <summary>
        /// 时间格式
        /// </summary>
        public static string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期短格式
        /// </summary>
        public static string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 日期长格式
        /// </summary>
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 当前软件Id
        /// </summary>
        public static string SoftName = string.Empty;

        /// <summary>
        /// 软件的名称
        /// </summary>
        public static string SoftFullName = string.Empty;

        /// <summary>
        /// 这里是设置，读取哪个系统的菜单
        /// </summary>
        public static string SystemCode = "Base";

        /// <summary>
        /// 这里是设置，读取哪个子系统的菜单
        /// </summary>
        public static string RootMenuCode = string.Empty;

        /// <summary>
        /// 是否采用客户端缓存
        /// </summary>
        public static bool ClientCache = false;

        /// <summary>
        /// 当前客户公司名称
        /// </summary>
        public static string CustomerCompanyName = string.Empty;
        
        /// <summary>
        /// 系统图标文件
        /// </summary>
        public static string AppIco = "Resource\\Form.ico";

        /// <summary>
        /// RegistryKey、Configuration、UserConfig 注册表或者配置文件读取参数
        /// </summary>
        public static ConfigurationCategory ConfigurationFrom = ConfigurationCategory.Configuration;

        public static string UploadDirectory = "Document/";
        #endregion
        
        #region 客户端动态加载程序相关
        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = "DotNet.WinForm";
        public static string MainForm = "MainForm";
        public static string LogOnForm = "FrmLogOnByName";
        public static string ServiceFactory = "ServiceFactory";
        public static string Service = "DotNet.Business";
        #endregion
    }
}