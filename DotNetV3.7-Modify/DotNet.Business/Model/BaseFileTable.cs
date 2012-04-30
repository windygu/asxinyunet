﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <remarks>
    ///	BaseFile
    /// 文件信息
    ///
    /// 注意事项
    ///     1.主键与编号一定要一致否则以后比较难扩展。
    ///     2.或者模块权限添加时，能自动添加到基本权限表里，这样也能解决问题。
    ///
    /// 修改纪录
    ///
    ///     2007.05.30 版本：2.3 JiRiGaLa 整理 Entity 主键部分。
    ///     2007.01.20 版本：2.2 JiRiGaLa 添加AllowEdit,AllowDelete两个字段。
    ///     2007.01.19 版本：2.1 JiRiGaLa SQLBuild修改为SQLBuild。
    ///     2007.01.04 版本：2.0 JiRiGaLa 重新整理主键。
    ///		2006.03.16 版本：1.0 JiRiGaLa 规范化主键。
    /// 
    /// 版本：2.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.30</date>
    /// </author>
    /// </remarks>
    public partial class BaseFileEntity
    {
        ///<summary>
        /// 文件新闻表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseFile";

        ///<summary>
        /// 代码
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 文件夹节点代码
        ///</summary>
        [NonSerialized]
        public static string FieldFolderId = "FolderId";

        ///<summary>
        /// 文件类别码
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 文件编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 文件名
        ///</summary>
        [NonSerialized]
        public static string FieldFileName = "FileName";

        ///<summary>
        /// 文件路径
        ///</summary>
        [NonSerialized]
        public static string FieldFilePath = "FilePath";

        ///<summary>
        /// 内容简介
        ///</summary>
        [NonSerialized]
        public static string FieldIntroduction = "Introduction";

        ///<summary>
        /// 文件内容
        ///</summary>
        [NonSerialized]
        public static string FieldContents = "Contents";

        ///<summary>
        /// 新闻来源
        ///</summary>
        [NonSerialized]
        public static string FieldSource = "Source";

        ///<summary>
        /// 关键字
        ///</summary>
        [NonSerialized]
        public static string FieldKeywords = "Keywords";

        ///<summary>
        /// 文件大小
        ///</summary>
        [NonSerialized]
        public static string FieldFileSize = "FileSize";

        ///<summary>
        /// 图片文件位置(图片新闻)
        ///</summary>
        [NonSerialized]
        public static string FieldImageUrl = "ImageUrl";

        ///<summary>
        /// 置首页
        ///</summary>
        [NonSerialized]
        public static string FieldHomePage = "HomePage";

        ///<summary>
        /// 置二级页
        ///</summary>
        [NonSerialized]
        public static string FieldSubPage = "SubPage";

        ///<summary>
        /// 审核状态
        ///</summary>
        [NonSerialized]
        public static string FieldAuditStatus = "AuditStatus";

        ///<summary>
        /// 被阅读次数
        ///</summary>
        [NonSerialized]
        public static string FieldReadCount = "ReadCount";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";
    }
}