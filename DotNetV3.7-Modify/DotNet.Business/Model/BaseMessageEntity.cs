//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseMessageEntity
    /// 消息表
    ///
    /// 修改纪录
    ///
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseMessageEntity
    {
        private string id = null;
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

        private string parentId = null;
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

        private string functionCode = null;
        /// <summary>
        /// 功能分类主键，Send发送、Receiver接收
        /// </summary>
        public string FunctionCode
        {
            get
            {
                return this.functionCode;
            }
            set
            {
                this.functionCode = value;
            }
        }

        private string categoryCode = null;
        /// <summary>
        /// 分类主键
        /// </summary>
        public string CategoryCode
        {
            get
            {
                return this.categoryCode;
            }
            set
            {
                this.categoryCode = value;
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

        private string content = null;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        private string receiverId = null;
        /// <summary>
        /// 接收者主键
        /// </summary>
        public string ReceiverId
        {
            get
            {
                return this.receiverId;
            }
            set
            {
                this.receiverId = value;
            }
        }

        private string receiverRealName = null;
        /// <summary>
        /// 接收着姓名
        /// </summary>
        public string ReceiverRealName
        {
            get
            {
                return this.receiverRealName;
            }
            set
            {
                this.receiverRealName = value;
            }
        }

        private int? isNew = 1;
        /// <summary>
        /// 是否新信息
        /// </summary>
        public int? IsNew
        {
            get
            {
                return this.isNew;
            }
            set
            {
                this.isNew = value;
            }
        }

        private int? readCount = 0;
        /// <summary>
        /// 被阅读次数
        /// </summary>
        public int? ReadCount
        {
            get
            {
                return this.readCount;
            }
            set
            {
                this.readCount = value;
            }
        }

        private DateTime? readDate = null;
        /// <summary>
        /// 阅读日期
        /// </summary>
        public DateTime? ReadDate
        {
            get
            {
                return this.readDate;
            }
            set
            {
                this.readDate = value;
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

        private int? enabled = 1;
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
        public BaseMessageEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseMessageEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseMessageEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseMessageEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseMessageEntity GetSingle(DataTable dataTable)
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
        public List<BaseMessageEntity> GetList(DataTable dataTable)
        {
            List<BaseMessageEntity> entites = new List<BaseMessageEntity>();
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
        public BaseMessageEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldParentId]);
            this.FunctionCode = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldFunctionCode]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldObjectId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldContents]);
            this.ReceiverId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldReceiverId]);
            this.ReceiverRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldReceiverRealName]);
            this.IsNew = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldIsNew]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldReadCount]);
            this.ReadDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseMessageEntity.FieldReadDate]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldTargetURL]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldIPAddress]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseMessageEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseMessageEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseMessageEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldParentId]);
            this.FunctionCode = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldFunctionCode]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldObjectId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldContents]);
            this.ReceiverId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldReceiverId]);
            this.ReceiverRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldReceiverRealName]);
            this.IsNew = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldIsNew]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldReadCount]);
            this.ReadDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseMessageEntity.FieldReadDate]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldTargetURL]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldIPAddress]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseMessageEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseMessageEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldModifiedBy]);
            return this;
        }
    }
}
