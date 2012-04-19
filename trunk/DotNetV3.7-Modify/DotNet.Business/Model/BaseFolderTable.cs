//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    ///	BaseFolderEntity
    /// 文件夹信息
    ///
    /// 注意事项
    ///     1.主键与编号一定要一致否则以后比较难扩展。
    ///     2.或者模块权限添加时，能自动添加到基本权限表里，这样也能解决问题。
    ///
    /// 修改纪录
    ///
    ///     2007.06.06 版本：2.4 JiRiGaLa 统一进行主键整理，添加GetFrom()方法，改进从数据行读取主键。
    ///     2007.05.29 版本：2.3 JiRiGaLa 整理 Entity 主键部分。
    ///     2007.01.20 版本：2.2 JiRiGaLa 添加AllowEdit,AllowDelete两个字段。
    ///     2007.01.19 版本：2.1 JiRiGaLa SQLBuild修改为SQLBuild。
    ///     2007.01.04 版本：2.0 JiRiGaLa 重新整理主键。
    ///		2006.03.16 版本：1.0 JiRiGaLa 规范化主键。
    /// 
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.06</date>
    /// </author>
    /// </summary>
    public partial class BaseFolderEntity
    {
        /// <summary>
        /// 内容表
        /// </summary>
        [NonSerialized]
        public static string TableName = "BaseFolder";

        /// <summary>
        /// 主键
        /// </summary>
        [NonSerialized]
        public static string FieldId = "Id";

        /// <summary>
        /// 父亲节点主键
        /// </summary>
        [NonSerialized]
        public static string FieldParentId = "ParentId";

        /// <summary>
        /// 文件夹名
        /// </summary>
        [NonSerialized]
        public static string FieldFolderName = "FolderName";

        /// <summary>
        /// 描述
        /// </summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        /// <summary>
        /// 状态码
        /// </summary>
        [NonSerialized]
        public static string FieldStateCode = "StateCode";

        ///<summary>
        /// 允许编辑
        ///</summary>
        [NonSerialized]
        public static string FieldAllowEdit = "AllowEdit";

        ///<summary>
        /// 允许删除
        ///</summary>
        [NonSerialized]
        public static string FieldAllowDelete = "AllowDelete";

        /// <summary>
        /// 有效
        /// </summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        /// <summary>
        /// 排序码
        /// </summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        /// <summary>
        /// 创建者
        /// </summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        /// <summary>
        /// 创建者主键
        /// </summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        /// <summary>
        /// 创建时间
        /// </summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        /// <summary>
        /// 最后修改者主键
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        /// <summary>
        /// 最后修改者
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";
    }
}