//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <remarks>
    ///	BaseFileEntity
    /// 文件信息
    ///
    /// 注意事项
    ///     1.主键与编号一定要一致否则以后比较难扩展。
    ///     2.或者模块权限添加时，能自动添加到基本权限表里，这样也能解决问题。
    ///
    /// 修改纪录
    ///
    ///     2008.04.29 版本：2.4 JiRiGaLa 整理 Entity 主键部分。
    ///     2007.05.30 版本：2.3 JiRiGaLa 整理 Entity 主键部分。
    ///     2007.01.20 版本：2.2 JiRiGaLa 添加AllowEdit,AllowDelete两个字段。
    ///     2007.01.19 版本：2.1 JiRiGaLa SQLBuild修改为SQLBuild。
    ///     2007.01.04 版本：2.0 JiRiGaLa 重新整理主键。
    ///		2006.03.16 版本：1.0 JiRiGaLa 规范化主键。
    /// 
    /// 版本：2.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.29</date>
    /// </author>
    /// </remarks>
    [Serializable]
    public partial class BaseFileEntity
    {
        private string id = null;
        /// <summary>
        /// 代码
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

        private string folderId = null;
        /// <summary>
        /// 文件夹节点代码
        /// </summary>
        public string FolderId
        {
            get
            {
                return this.folderId;
            }
            set
            {
                this.folderId = value;
            }
        }

        private string categoryCode = null;
        /// <summary>
        /// 文件类别码
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

        private string code = null;
        /// <summary>
        /// 文件编号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string fileName = null;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }

        private string filePath = null;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        private string introduction = null;
        /// <summary>
        /// 内容简介
        /// </summary>
        public string Introduction
        {
            get
            {
                return this.introduction;
            }
            set
            {
                this.introduction = value;
            }
        }

        private byte[] contents = null;
        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] Contents
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

        private string source = null;
        /// <summary>
        /// 新闻来源
        /// </summary>
        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }

        private string keywords = null;
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords
        {
            get
            {
                return this.keywords;
            }
            set
            {
                this.keywords = value;
            }
        }

        private int? fileSize = 0;
        /// <summary>
        /// 文件大小
        /// </summary>
        public int? FileSize
        {
            get
            {
                return this.fileSize;
            }
            set
            {
                this.fileSize = value;
            }
        }

        private string imageUrl = null;
        /// <summary>
        /// 图片文件位置(图片新闻)
        /// </summary>
        public string ImageUrl
        {
            get
            {
                return this.imageUrl;
            }
            set
            {
                this.imageUrl = value;
            }
        }

        private int? homePage = 0;
        /// <summary>
        /// 置首页
        /// </summary>
        public int? HomePage
        {
            get
            {
                return this.homePage;
            }
            set
            {
                this.homePage = value;
            }
        }

        private int? subPage = 0;
        /// <summary>
        /// 置二级页
        /// </summary>
        public int? SubPage
        {
            get
            {
                return this.subPage;
            }
            set
            {
                this.subPage = value;
            }
        }

        private string auditStatus = null;
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditStatus
        {
            get
            {
                return this.auditStatus;
            }
            set
            {
                this.auditStatus = value;
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

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseFileEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseFileEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseFileEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseFileEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseFileEntity GetSingle(DataTable dataTable)
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
        public List<BaseFileEntity> GetList(DataTable dataTable)
        {
            List<BaseFileEntity> entites = new List<BaseFileEntity>();
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
        public BaseFileEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldId]);
            this.FolderId = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldFolderId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldCategoryCode]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldCode]);
            this.FileName = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldFileName]);
            this.FilePath = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldFilePath]);
            this.Introduction = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldIntroduction]);
            this.Source = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldSource]);
            this.Keywords = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldKeywords]);
            this.FileSize = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldFileSize]);
            this.ImageUrl = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldImageUrl]);
            this.SubPage = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldSubPage]);
            this.HomePage = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldHomePage]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldAuditStatus]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldReadCount]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldDescription]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseFileEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseFileEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseFileEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseFileEntity.FieldModifiedUserId]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseFileEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldId]);
            this.FolderId = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldFolderId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldCategoryCode]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldCode]);
            this.FileName = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldFileName]);
            this.FilePath = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldFilePath]);
            this.Introduction = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldIntroduction]);
            this.Source = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldSource]);
            this.Keywords = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldKeywords]);
            this.FileSize = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldFileSize]);
            this.ImageUrl = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldImageUrl]);
            this.SubPage = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldSubPage]);
            this.HomePage = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldHomePage]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldAuditStatus]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldReadCount]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldDescription]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseFileEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseFileEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseFileEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseFileEntity.FieldModifiedUserId]);
            return this;
        }
    }
}