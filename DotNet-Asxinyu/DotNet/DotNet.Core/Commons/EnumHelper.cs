/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-6-12
 * Time: 15:44
 * 
 * 一些基础的枚举类
 */
using System;

namespace DotNet.Core.Commons
{
	#region 数据库枚举定义
	/// <summary>
	/// DataBaseType:有关数据库连接类型定义
	/// </summary>
	public enum DataBaseType
	{
		Oracle,
		SqlServer,
		Access,
		Bd2,
		MySql,
		SQLite
	}
	#endregion
	
	#region 权限枚举类型
	/// <summary>
	/// 权限枚举类型
	/// </summary>
	public enum OperationCode
	{
		Access = 1,     // 访问权限
		Add = 2,        // 新增权限
		Edit = 3,       // 编辑权限
		View = 4,       // 浏览权限
		Delete = 5,     // 删除权限
		Search = 6,     // 查询权限
		Import = 7,     // 导入权限
		Export = 8,     // 导出权限
		Print = 9,      // 打印权限
		Auditing = 10,  // 审核权限
		Admin = 11,     // 管理权限
		Config = 12,    // 配置权限
		UpLoad = 13,    // 上传权限
		DownLoad = 14   // 下载权限
	}
	#endregion
	
	#region 组织机构类别
	/// <summary>
	/// OrganizeCategory:组织机构类别。
	/// </summary>
	public enum OrganizeCategory
	{
		Group,          // 集团
		Area,           // 区域
		Company,        // 公司
		SubCompany,     // 子公司
		Department,     // 部门
		SubDepartment,  // 子部门
		Workgroup       // 工作组
	}
	#endregion
	
	#region 权限范围
	/// <summary>
	/// PermissionScope:权限范围
	/// </summary>
	public enum PermissionScope
	{
		None = 0,            // 没有任何数据权限
		All = -1,            // 全部数据
		UserCompany = -2,    // 用户所在公司数据
		UserSubOrg = -3,     // 用户所在分支机构数据
		UserDepartment = -4, // 用户所在部门数据
		UserWorkgroup = -5,  // 用户所在工作组数据
		User = -6,           // 自己的数据
		Detail = -7,         // 按详细设定的数据
	}
	#endregion
	
	#region 程序运行状态
	/// <summary>
	/// StateCode: 程序运行状态
	/// </summary>
	public enum StatusCode
	{
		Error = 0,                  //  0 发生错误。
		OK = 1,                     //  1 运行成功。
		OKAdd = 2,                  //  2 添加成功。
		CanNotLock = 3,             //  3 不能锁定数据。
		LockOK = 4,                 //  4 成功锁定数据。
		OKUpdate = 5,               //  5 更新数据成功。
		OKDelete = 6,               //  6 删除成功。
		Exist = 7,                  //  7 数据已重复,不可以重复。
		ErrorCodeExist = 8,         //  8 编号已存在,不可以重复。
		ErrorNameExist = 9,         //  9 名称已重复
		ErrorValueExist = 10,       // 10 值已重复
		ErrorUserExist = 11,        // 11 用户名已重复
		ErrorDataRelated = 12,      // 12 数据已经被引用，有关联数据在。
		ErrorDeleted = 13,          // 13 数据已被其他人删除。
		ErrorChanged = 14,          // 14 数据已被其他人修改。
		NotFound = 15,              // 15 为找到记录。
		UserNotFound = 16,          // 16 用户没有找到。
		PasswordError = 17,         // 17 密码错误。
		LogOnDeny = 18,             // 18 登录被拒绝。
		ErrorOnLine = 19,           // 19 只允许登录一次
		ErrorMacAddress = 20,       // 20 是否检查用户的网卡Mac地址
		ErrorIPAddress = 21,        // 21 是否检查用户IP地址
		ErrorOnLineLimit = 22,      // 22 同时在线用户数量限制
		PasswordCanNotBeNull = 23,  // 23 密码不允许为空。
		SetPasswordOK = 24,         // 24 设置密码成功。
		OldPasswordError = 25,      // 25 原密码错误。
		ChangePasswordOK = 26,      // 26 修改密码成功。
		UserNotEmail = 27,          // 27 用户没有电子邮件地址。
		UserLocked = 28,            // 28 用户被锁定。
		UserNotActive = 29,         // 29 用户还未被激活。
		UserIsActivate = 30,        // 30 用户已被激活，不用重复激活。
	}
	#endregion
}