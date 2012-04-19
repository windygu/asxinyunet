//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System.ServiceModel;

namespace DotNet.WCFClient
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// ServiceFactory
    /// 本地服务的具体实现接口
    /// 
    /// 修改纪录
    /// 
    ///		2011.07.03 版本：2.0 JiRiGaLa 可以动态指定服务器地址的调用方法。
    ///		2009.09.20 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.07.03</date>
    /// </author> 
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        private string host = string.Empty;
        /// <summary>
        /// 主机地址
        /// Host = "192.168.0.122";
        /// </summary>
        public string Host
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }

        private int port = 0;
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public ServiceFactory()
        {
        }

        /// <summary>
        /// 初始化服务
        /// </summary>
        public void InitService()
        {
        }

        /// <summary>
        /// 动态设定WCF主机地址端口的方法
        /// </summary>
        /// <param name="address">主机地址</param>
        /// <returns>主机地址</returns>
        public virtual EndpointAddress GetHotsUrl(EndpointAddress address)
        {
            // 若当前配置都是空的，就不用生成新的URL了。
            if (string.IsNullOrEmpty(Host) && (Port == 0))
            {
                return address;
            }
            // 判断当前配置的情况
            string endpointAddress = string.Empty;
            if (string.IsNullOrEmpty(Host))
            {
                Host = address.Uri.Host;
            }
            if (Port == 0)
            {
                Port = address.Uri.Port;
            }
            endpointAddress = address.Uri.Scheme + "://" + Host + ":" + Port.ToString() + address.Uri.LocalPath;
            address = new EndpointAddress(endpointAddress);
            return address;
        }

        public virtual ISequenceService CreateSequenceService()
        {
            ChannelFactory<ISequenceService> channelFactory = new ChannelFactory<ISequenceService>("DotNet.Business.SequenceService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            ISequenceService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IUserService CreateUserService()
        {
            ChannelFactory<IUserService> channelFactory = new ChannelFactory<IUserService>("DotNet.Business.UserService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IUserService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual ILogOnService CreateLogOnService()
        {
            ChannelFactory<ILogOnService> channelFactory = new ChannelFactory<ILogOnService>("DotNet.Business.LogOnService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            ILogOnService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual ILogService CreateLogService()
        {
            ChannelFactory<ILogService> channelFactory = new ChannelFactory<ILogService>("DotNet.Business.LogService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            ILogService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IExceptionService CreateExceptionService()
        {
            ChannelFactory<IExceptionService> channelFactory = new ChannelFactory<IExceptionService>("DotNet.Business.ExceptionService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IExceptionService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IPermissionItemService CreatePermissionItemService()
        {
            ChannelFactory<IPermissionItemService> channelFactory = new ChannelFactory<IPermissionItemService>("DotNet.Business.PermissionItemService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IPermissionItemService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IOrganizeService CreateOrganizeService()
        {
            ChannelFactory<IOrganizeService> channelFactory = new ChannelFactory<IOrganizeService>("DotNet.Business.OrganizeService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IOrganizeService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IItemsService CreateItemsService()
        {
            ChannelFactory<IItemsService> channelFactory = new ChannelFactory<IItemsService>("DotNet.Business.ItemsService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IItemsService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public IItemDetailsService CreateItemDetailsService()
        {
            ChannelFactory<IItemDetailsService> channelFactory = new ChannelFactory<IItemDetailsService>("DotNet.Business.ItemDetailsService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IItemDetailsService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IModuleService CreateModuleService()
        {
            ChannelFactory<IModuleService> channelFactory = new ChannelFactory<IModuleService>("DotNet.Business.ModuleService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IModuleService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IStaffService CreateStaffService()
        {
            ChannelFactory<IStaffService> channelFactory = new ChannelFactory<IStaffService>("DotNet.Business.StaffService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IStaffService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IRoleService CreateRoleService()
        {
            ChannelFactory<IRoleService> channelFactory = new ChannelFactory<IRoleService>("DotNet.Business.RoleService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IRoleService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IMessageService CreateMessageService()
        {
            ChannelFactory<IMessageService> channelFactory = new ChannelFactory<IMessageService>("DotNet.Business.MessageService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IMessageService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IFileService CreateFileService()
        {
            ChannelFactory<IFileService> channelFactory = new ChannelFactory<IFileService>("DotNet.Business.FileService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IFileService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IFolderService CreateFolderService()
        {
            ChannelFactory<IFolderService> channelFactory = new ChannelFactory<IFolderService>("DotNet.Business.FolderService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IFolderService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IParameterService CreateParameterService()
        {
            ChannelFactory<IParameterService> channelFactory = new ChannelFactory<IParameterService>("DotNet.Business.ParameterService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IParameterService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IPermissionService CreatePermissionService()
        {
            ChannelFactory<IPermissionService> channelFactory = new ChannelFactory<IPermissionService>("DotNet.Business.PermissionService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IPermissionService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IDbHelperService CreateBusinessDbHelperService()
        {
            ChannelFactory<IDbHelperService> channelFactory = new ChannelFactory<IDbHelperService>("DotNet.Business.BusinessDbHelperService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IDbHelperService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IDbHelperService CreateUserCenterDbHelperService()
        {
            ChannelFactory<IDbHelperService> channelFactory = new ChannelFactory<IDbHelperService>("DotNet.Business.UserCenterDbHelperService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IDbHelperService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IWorkFlowActivityAdminService CreateWorkFlowActivityAdminService()
        {
            ChannelFactory<IWorkFlowActivityAdminService> channelFactory = new ChannelFactory<IWorkFlowActivityAdminService>("DotNet.Business.WorkFlowActivityAdminService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IWorkFlowActivityAdminService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IWorkFlowCurrentService CreateWorkFlowCurrentService()
        {
            ChannelFactory<IWorkFlowCurrentService> channelFactory = new ChannelFactory<IWorkFlowCurrentService>("DotNet.Business.WorkFlowCurrentService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IWorkFlowCurrentService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual IWorkFlowProcessAdminService CreateWorkFlowProcessAdminService()
        {
            ChannelFactory<IWorkFlowProcessAdminService> channelFactory = new ChannelFactory<IWorkFlowProcessAdminService>("DotNet.Business.WorkFlowProcessAdminService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            IWorkFlowProcessAdminService proxy = channelFactory.CreateChannel();
            return proxy;
        }

        public virtual ITableColumnsService CreateTableColumnsService()
        {
            ChannelFactory<ITableColumnsService> channelFactory = new ChannelFactory<ITableColumnsService>("DotNet.Business.TableColumnsService");
            channelFactory.Endpoint.Address = GetHotsUrl(channelFactory.Endpoint.Address);
            // 加强安全验证防止未授权匿名调用
            channelFactory.Credentials.UserName.UserName = BaseSystemInfo.ServiceUserName;
            channelFactory.Credentials.UserName.Password = BaseSystemInfo.ServicePassword;
            ITableColumnsService proxy = channelFactory.CreateChannel();
            return proxy;
        }
    }
}