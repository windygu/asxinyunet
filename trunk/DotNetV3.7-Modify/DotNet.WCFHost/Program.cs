//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Windows.Forms;
using System.IO;

namespace DotNet.WCFHost
{
    using DotNet.Business;
    using DotNet.Utilities;

    static class Program
    {
        /// <summary>
        /// 應用程序的主入口點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 主应用程序集名
            BaseSystemInfo.MainAssembly = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            BaseSystemInfo.StartupPath = Application.StartupPath;
            BaseSystemInfo.AppIco = Path.Combine(Application.StartupPath, "Resource/Form.ico");

            // 讀取配置文件
            UserConfigHelper.GetConfig();

            // 服務集字串
            string consoleValue = string.Empty;
            string num = string.Empty;

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("WCFHost 服务器启动中。。。");
            System.Console.ForegroundColor = ConsoleColor.White;
            consoleValue = "WCFHost 服务器启动中。。。\r\n";

            // 讀取配置文件
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            ServiceModelSectionGroup serviceModelSectionGroup = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
            // 開啟每個服務
            int i = 1;
            foreach (ServiceElement serviceElement in serviceModelSectionGroup.Services.Services)
            {
                string assemblyString = serviceElement.Name.Substring(0, serviceElement.Name.LastIndexOf('.'));
                var serviceHost = new ServiceHost(Assembly.Load(assemblyString).GetType(serviceElement.Name), serviceElement.Endpoints[0].Address);
                serviceHost.Opened += delegate 
                {
                    Console.WriteLine("第{0:00}服务：{1}", i, serviceHost.BaseAddresses[0]);
                    if (i.ToString().Length == 1) { num = "0" + i.ToString(); } else { num = i.ToString(); }
                    consoleValue += "第" + num + "服务：" + serviceHost.BaseAddresses[0] + "\r\n";
                };
                serviceHost.Open();
                i++;
            }

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("WCFHost 伺服器端已啟動。。。");
            System.Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.WriteLine("WCFHost 伺服器 當前時間：" + DateTime.Now.ToString(BaseSystemInfo.DateTimeFormat));
            IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            System.Console.WriteLine("資料庫 伺服器 當前時間：" + dbHelper.GetDBDateTime());
            System.Console.WriteLine();

            consoleValue += "WCFHost 伺服器端已啟動。。。啟動時間：" + DateTime.Now.ToString(BaseSystemInfo.DateTimeFormat);

            //寫入測試訊息
            #if (DEBUG)
                UserCenterDbHelperService userCenterDbHelperService = new UserCenterDbHelperService();
                System.Console.WriteLine("使用者中心資料庫伺服器 資料庫連接：");
                System.Console.WriteLine(userCenterDbHelperService.ServiceDbConnection);
                System.Console.WriteLine(userCenterDbHelperService.ExecuteScalar(BaseSystemInfo.UserInfo, "SELECT GETDATE()").ToString());
                System.Console.WriteLine();

                BusinessDbHelperService businessDbHelperService = new BusinessDbHelperService();
                System.Console.WriteLine("業務中心資料庫伺服器 資料庫連接：");
                System.Console.WriteLine(businessDbHelperService.ServiceDbConnection);
                //System.Console.WriteLine(businessDbHelperService.ExecuteScalar(BaseSystemInfo.UserInfo, "SELECT TO_CHAR(SYSDATE,'yyyy/MM/dd HH24:mi:ss') FROM dual").ToString());
            #endif

            Application.Run(new FormWCFHost(consoleValue));
        }
    }

    public class UserNamePasswordValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != BaseSystemInfo.ServiceUserName || password != BaseSystemInfo.ServicePassword)
            {
                throw new System.IdentityModel.Tokens.SecurityTokenException(AppMessage.MSG0800);
            }
        }
    }
}