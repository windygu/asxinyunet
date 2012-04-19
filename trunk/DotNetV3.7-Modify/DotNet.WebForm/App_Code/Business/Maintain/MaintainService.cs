//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace Project
{
	using DotNet.Utilities;
	using DotNet.Business;

	/// <summary>
	/// MaintainService
	/// 服務層
	/// 
	/// 修改紀錄
	/// 
	///		2012-02-17 版本：1.0  建立檔案。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name></name>
	///		<date>2012-02-17</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class MaintainService : System.MarshalByRefObject, IMaintainService
	{
		private string serviceName = "AppMaintain";
		
		/// <summary>
		/// 權限資料庫連接
		/// </summary>
		private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

		/// <summary>
		/// 商務資料庫連接
		/// </summary>
		private readonly string BusinessDbConnection = BaseSystemInfo.BusinessDbConnection;

		/// <summary>
		/// 新增实体
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回狀態碼</param>
		/// <param name="statusMessage">返回狀態訊息</param>
		/// <returns>主鍵</returns>
		public string Add(BaseUserInfo userInfo, MaintainEntity entity, out string statusCode, out string statusMessage)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			string returnValue = string.Empty;            
			statusCode = string.Empty;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "新增实体", MethodBase.GetCurrentMethod());

					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							returnValue = manager.AddEntity(entity);
							// returnValue = manager.Add(entity, out statusCode);
							statusMessage = manager.GetStateMessage(statusCode);
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif
			
			return returnValue;
		}

		/// <summary>
		/// 取得列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <returns>資料表</returns>
		public DataTable GetDataTable(BaseUserInfo userInfo)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			DataTable dataTable = new DataTable(MaintainEntity.TableName);
			
			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "取得列表", MethodBase.GetCurrentMethod());

					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							// 取得列表
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							dataTable = manager.GetDataTable(new KeyValuePair<string, object>(MaintainEntity.FieldDeletionStateCode, 0), MaintainEntity.FieldSortCode);
							dataTable.TableName = MaintainEntity.TableName;
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return dataTable;
		}

		/// <summary>
		/// 取得实体
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="id">主鍵</param>
		/// <returns>实体</returns>
		public MaintainEntity GetEntity(BaseUserInfo userInfo, string id)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			MaintainEntity entity = null;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "取得实体", MethodBase.GetCurrentMethod());
					
					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							entity = manager.GetEntity(id);
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return entity;
		}

		/// <summary>
		/// 更新实体
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回狀態碼</param>
		/// <param name="statusMessage">返回狀態訊息</param>
		/// <returns>影響行數</returns>
		public int Update(BaseUserInfo userInfo, MaintainEntity entity, out string statusCode, out string statusMessage)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			int returnValue = 0;
			statusCode = string.Empty;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "更新实体", MethodBase.GetCurrentMethod());
					
					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							returnValue = manager.UpdateEntity(entity);
							// returnValue = manager.Update(entity, out statusCode);
							statusMessage = manager.GetStateMessage(statusCode);
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return returnValue;
		}

		/// <summary>
		/// 依主鍵陣列獲取資料列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主鍵</param>
		/// <returns>資料表</returns>
		public DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			DataTable dataTable = new DataTable(MaintainEntity.TableName);

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "依主鍵陣列獲取資料列表", MethodBase.GetCurrentMethod());
					
					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							dataTable = manager.GetDataTable(MaintainEntity.FieldId, ids, MaintainEntity.FieldSortCode);
							dataTable.TableName = MaintainEntity.TableName;
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return dataTable;
		}
		
        /// <summary>
		/// 依條件獲取資料列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="names">字段</param>
		/// <param name="values">值</param>
		/// <returns>資料表</returns>
        public DataTable GetDataTableByValues(BaseUserInfo userInfo, List<KeyValuePair<string, object>> parameters)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			DataTable dataTable = new DataTable(MaintainEntity.TableName);

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "依條件獲取資料列表", MethodBase.GetCurrentMethod());
					
					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							// 依條件獲取資料列表
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
                            dataTable = manager.GetDataTable(parameters);
							dataTable.TableName = MaintainEntity.TableName;
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return dataTable;
		}
		
		/// <summary>
		/// 批次儲存資料
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="entites">实体列表</param>
		/// <returns>影響行數</returns>
		public int BatchSave(BaseUserInfo userInfo, List<MaintainEntity> entites)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			int returnValue = 0;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "批次儲存資料", MethodBase.GetCurrentMethod());

					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							// returnValue = manager.BatchSave(entites);
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return returnValue;
		}
		
		/// <summary>
		/// 刪除資料
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="id">主鍵</param>
		/// <returns>資料表</returns>
		public int Delete(BaseUserInfo userInfo, string id)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			int returnValue = 0;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "刪除資料", MethodBase.GetCurrentMethod());
					
					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							returnValue = manager.Delete(id);
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return returnValue;
		}
		
		/// <summary>
		/// 批次刪除資料
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主鍵陣列</param>
		/// <returns>影響行數</returns>
        public int BatchDelete(BaseUserInfo userInfo, string[] ids)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			int returnValue = 0;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "批次刪除資料", MethodBase.GetCurrentMethod());

					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							// 開始資料庫事務
							dbHelper.BeginTransaction();
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							returnValue = manager.Delete(ids);
							// 遞交資料庫事務
							dbHelper.CommitTransaction();
						}
						catch (Exception ex)
						{
							// 撤銷資料庫事務
							dbHelper.RollbackTransaction();
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return returnValue;
		}

		/// <summary>
		/// 批次設置刪除標誌
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主鍵陣列</param>
		/// <returns>影響行數</returns>
		public int SetDeleted(BaseUserInfo userInfo, string[] ids)
		{
			// 寫入調試訊息
			#if (DEBUG)
				int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
			#endif

			// 加強安全驗證防止未授權匿名調用
			#if (!DEBUG)
				LogOnService.UserIsLogOn(userInfo);
			#endif

			int returnValue = 0;

			using (IDbHelper UCdbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType))
			{
				try
				{
					UCdbHelper.Open(UserCenterDbConnection);
					BaseLogManager.Instance.Add(UCdbHelper, userInfo, this.serviceName, "批次設置刪除標誌", MethodBase.GetCurrentMethod());
					
					using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType))
					{
						try
						{
							dbHelper.Open(BusinessDbConnection);
							MaintainManager manager = new MaintainManager(dbHelper, userInfo);
							returnValue = manager.SetDeleted(ids);
						}
						catch (Exception ex)
						{
							BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
							throw ex;
						}
						finally
						{
							dbHelper.Close();
						}
					}
				}
				catch (Exception ex)
				{
					BaseExceptionManager.LogException(UCdbHelper, userInfo, ex);
					throw ex;
				}
				finally
				{
					UCdbHelper.Close();
				}
			}

			// 寫入調試訊息
			#if (DEBUG)
				BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
			#endif

			return returnValue;
		}
	}
}
