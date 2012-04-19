//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
	/// <summary>
    ///	BaseCommentEntity
	/// 评论的基类结构定义
	///
	/// 修改纪录
    ///
    ///		2009.01.10 版本：2.1 JiRiGaLa		将评论表，放在 消息表中。
    ///		2007.01.19 版本：2.0 JiRiGaLa		重新整理主键。
    ///		2006.02.05 版本：1.1 JiRiGaLa	    重新调整主键的规范化。
	///		2004.10.28 版本：1.0 JiRiGaLa		改进可以多部门的主页可以统一使用一个数据库建立多个网站的需求。
	///		2004.08.12 版本：1.0 JiRiGaLa		添加IsNew标志。
	///		2004.07.23 版本：1.0 JiRiGaLa		建议用SortCode进行倒序索引比较好。
	///		2004.07.20 版本：1.0 JiRiGaLa		主键ID需要进行倒序排序，这样数据库管理员很方便地找到最新的纪录及被修改的纪录。
	///		2004.07.20 版本：1.0 JiRiGaLa		CategoryId，PriorityId 需要进行外键数据库完整性约束。
	///		2004.07.20 版本：1.0 JiRiGaLa		CreateOn 需要进行有默认值，不需要赋值也能获得当前的系统时间。
	///		2004.07.20 版本：1.0 JiRiGaLa		CreateUserId、ModifiedUserId 需要有外件数据库完整性约束。
	///		2004.07.20 版本：1.0 JiRiGaLa		ID、ParentId 需要进行本身表的自我数据库外键约束。
	///		2004.07.20 版本：1.0 JiRiGaLa		Content、CreateUserId 不可以为空，减少垃圾数据。
	///		2005.02.02 版本：1.0 JiRiGaLa		主键规范化。
	///
    /// 版本：2.0
	///
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.01.19</date>
	/// </author>
	/// </summary>
    public partial class BaseCommentEntity
	{
        ///<summary>
        /// 评论表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseComment";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 父亲节点主键
        ///</summary>
        [NonSerialized]
        public static string FieldParentId = "ParentId";

        ///<summary>
        /// 分类主键
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 唯一识别主键
        ///</summary>
        [NonSerialized]
        public static string FieldObjectId = "ObjectId";

        ///<summary>
        /// 主题
        ///</summary>
        [NonSerialized]
        public static string FieldTitle = "Title";

        ///<summary>
        /// 内容
        ///</summary>
        [NonSerialized]
        public static string FieldContents = "Contents";

        ///<summary>
        /// 消息的指向网页页面
        ///</summary>
        [NonSerialized]
        public static string FieldTargetURL = "TargetURL";

        ///<summary>
        /// IP地址
        ///</summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPAddress";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

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
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
	}
}