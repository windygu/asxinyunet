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
    ///	BaseFolderEntity
    /// 文件夹实体
    ///
    ///
    /// 修改纪录
    ///
    ///     2008.05.04 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.04</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseFolderEntity
    {
        public BaseFolderEntity()
        {
        }

        public BaseFolderEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        public BaseFolderEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseFolderEntity> GetList(DataTable dataTable)
        {
            List<BaseFolderEntity> entites = new List<BaseFolderEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        #region public BaseFolderEntity GetFrom(DataRow dataRow) 从数据行读取
        /// <summary>
        ///  从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <returns>BaseFolderEntity</returns>
        public BaseFolderEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldParentId]);
            this.FolderName = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldFolderName]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldAllowDelete]);
            this.Enabled = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseFolderEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldDescription]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldCreateUserId]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldCreateOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldModifiedUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldModifiedOn]);
            return this;
        }
        #endregion

        #region public BaseFolderEntity GetSingle(DataTable dataTable) 从数据表读取实体
        /// <summary>
        /// 从数据表读取实体
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>实体</returns>
        public BaseFolderEntity GetSingle(DataTable dataTable)
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
        #endregion

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

        private string folderName = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string FolderName
        {
            get
            {
                return this.folderName;
            }
            set
            {
                this.folderName = value;
            }
        }

        private int? allowEdit = 1;
        /// <summary>
        /// 允许编辑
        /// </summary>
        public int? AllowEdit
        {
            get
            {
                return this.allowEdit;
            }
            set
            {
                this.allowEdit = value;
            }
        }

        private int? allowDelete = 1;
        /// <summary>
        /// 允许删除
        /// </summary>
        public int? AllowDelete
        {
            get
            {
                return this.allowDelete;
            }
            set
            {
                this.allowDelete = value;
            }
        }

        private bool enabled = true;
        /// <summary>
        /// 有效
        /// </summary>
        public bool Enabled
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

        private string description = string.Empty;
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

        private string sortCode = string.Empty;
        /// <summary>
        /// 排序
        /// </summary>
        public string SortCode
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

        private string createUserId = string.Empty;
        /// <summary>
        /// 创建者主键
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

        private string createBy = string.Empty;
        /// <summary>
        /// 创建者
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

        private string createOn = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateOn
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

        private string modifiedUserId = string.Empty;
        /// <summary>
        /// 最后修改者主键
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

        private string modifiedBy = string.Empty;
        /// <summary>
        /// 最后修改者
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

        private string modifiedOn = string.Empty;
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public string ModifiedOn
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
    }
}