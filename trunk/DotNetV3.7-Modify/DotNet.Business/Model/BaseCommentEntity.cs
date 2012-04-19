//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseCommentEntity
    /// 评论的基类结构定义
    ///
    /// 修改纪录
    ///
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
    [Serializable]
    public partial class BaseCommentEntity
    {
        private string id = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string parentId = string.Empty;
        /// <summary>
        /// 父亲节点主键
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        private string categoryId = null;
        /// <summary>
        /// 分类主键
        /// </summary>
        public string CategoryCode
        {
            get
            {
                return this.categoryId;
            }
            set
            {
                this.categoryId = value;
            }
        }

        private string objectId = null;
        /// <summary>
        /// 唯一识别主键
        /// </summary>
        public string ObjectId
        {
            get
            {
                return this.objectId;
            }
            set
            {
                this.objectId = value;
            }
        }

        private string title = null;
        /// <summary>
        /// 主题
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private string contents = null;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get
            {
                return this.contents;
            }
            set
            {
                this.contents = value;
            }
        }

        private string targetURL = null;
        /// <summary>
        /// 消息的指向网页页面
        /// </summary>
        public string TargetURL
        {
            get
            {
                return this.targetURL;
            }
            set
            {
                this.targetURL = value;
            }
        }

        private string iPAddress = null;
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress
        {
            get
            {
                return this.iPAddress;
            }
            set
            {
                this.iPAddress = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private int? enabled = 0;
        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private string description = null;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private int? sortCode = 0;
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private string createUserId = null;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private string createBy = null;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        private string modifiedUserId = null;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        private string modifiedBy = null;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseCommentEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseCommentEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseCommentEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseCommentEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseCommentEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseCommentEntity> GetList(DataTable dataTable)
        {
            List<BaseCommentEntity> entites = new List<BaseCommentEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseCommentEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldParentId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldObjectId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldContents]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldTargetURL]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldIPAddress]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseCommentEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseCommentEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseCommentEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseCommentEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseCommentEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseCommentEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldParentId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldObjectId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldContents]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldTargetURL]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldIPAddress]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseCommentEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseCommentEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseCommentEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseCommentEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseCommentEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldModifiedBy]);
            return this;
        }
    }
}