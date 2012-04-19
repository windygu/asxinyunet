//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.ServiceModel;
using System.Collections.Generic;

namespace Project
{
    using DotNet.Utilities;

    /// <summary>
    /// IMaintainService
    /// 服务层接口
    /// 
    /// 修改纪录
    /// 
    ///		2012-02-17 版本：1.0  创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name></name>
    ///		<date>2012-02-17</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IMaintainService
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, MaintainEntity entity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        MaintainEntity GetEntity(BaseUserInfo userInfo, string id);
        
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, MaintainEntity entity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 按主键数组获取数据列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parameters">字段,值</param>
        /// <param name="values"></param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByValues(BaseUserInfo userInfo, List<KeyValuePair<string, object>> parameters);
                
        /// <summary>
        /// 批量保存数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entites">实体列表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, List<MaintainEntity> entites);
                
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(BaseUserInfo userInfo, string[] ids);
     }
}
