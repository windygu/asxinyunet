//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Business
{
    /// <summary>
    /// ServiceFactory
    /// 本地服务的具体实现接口
    /// 
    /// 修改纪录
    /// 
    ///		2011.08.21 版本：2.0 JiRiGaLa 方便在系统组件化用,命名进行了修改。
    ///		2007.12.30 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.08.21</date>
    /// </author> 
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        public void InitService()
        {
        }

        public ILogOnService CreateLogOnService()
        {
            return new LogOnService();
        }

        public ISequenceService CreateSequenceService()
        {
            return new SequenceService();
        }

        public IUserService CreateUserService()
        {
            return new UserService();
        }

        public ILogService CreateLogService()
        {
            return new LogService();
        }

        public IExceptionService CreateExceptionService()
        {
            return new ExceptionService();
        }

        public IPermissionItemService CreatePermissionItemService()
        {
            return new PermissionItemService();
        }

        public IOrganizeService CreateOrganizeService()
        {
            return new OrganizeService();
        }

        public IItemsService CreateItemsService()
        {
            return new ItemsService();
        }

        public IItemDetailsService CreateItemDetailsService()
        {
            return new ItemDetailsService();
        }

        public IModuleService CreateModuleService()
        {
            return new ModuleService();
        }

        public IStaffService CreateStaffService()
        {
            return new StaffService();
        }

        public IRoleService CreateRoleService()
        {
            return new RoleService();
        }

        public IMessageService CreateMessageService()
        {
            return new MessageService();
        }

        public IFileService CreateFileService()
        {
            return new FileService();
        }

        public IFolderService CreateFolderService()
        {
            return new FolderService();
        }

        public IParameterService CreateParameterService()
        {
            return new ParameterService();
        }

        public IPermissionService CreatePermissionService()
        {
            return new PermissionService();
        }

        /// <summary>
        /// 创建业务数据库服务
        /// </summary>
        /// <returns>数据库服务</returns>
        public IDbHelperService CreateBusinessDbHelperService()
        {
            return new BusinessDbHelperService();
        }

        /// <summary>
        /// 创建用户中心数据库服务
        /// </summary>
        /// <returns>数据库服务</returns>
        public IDbHelperService CreateUserCenterDbHelperService()
        {
            return new UserCenterDbHelperService();
        }

        public IWorkFlowCurrentService CreateWorkFlowCurrentService()
        {
            return new WorkFlowCurrentService();
        }

        public IWorkFlowActivityAdminService CreateWorkFlowActivityAdminService()
        {
            return new WorkFlowActivityAdminService();
        }

        public IWorkFlowProcessAdminService CreateWorkFlowProcessAdminService()
        {
            return new WorkFlowProcessAdminService();
        }

        public ITableColumnsService CreateTableColumnsService()
        {
            return new TableColumnsService();
        }
    }
}