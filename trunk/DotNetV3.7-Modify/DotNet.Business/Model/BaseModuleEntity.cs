//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseModuleEntity
    /// 模块（菜单）表
    ///
    /// 修改纪录
    ///
    ///		2011-10-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011-10-15</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseModuleEntity
    {
        private int? id = null;
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id
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

        private int? parentId = null;
        /// <summary>
        /// 父节点主键
        /// </summary>
        public int? ParentId
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

        private string code = string.Empty;
        /// <summary>
        /// 编号
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

        private string fullName = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        private string category = string.Empty;
        /// <summary>
        /// System\Application
        /// </summary>
        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        private string imageIndex = string.Empty;
        /// <summary>
        /// 图标编号
        /// </summary>
        public string ImageIndex
        {
            get
            {
                return this.imageIndex;
            }
            set
            {
                this.imageIndex = value;
            }
        }

        private string selectedImageIndex = string.Empty;
        /// <summary>
        /// 选中状态图标编号
        /// </summary>
        public string SelectedImageIndex
        {
            get
            {
                return this.selectedImageIndex;
            }
            set
            {
                this.selectedImageIndex = value;
            }
        }

        private string navigateUrl = string.Empty;
        /// <summary>
        /// 导航地址
        /// </summary>
        public string NavigateUrl
        {
            get
            {
                return this.navigateUrl;
            }
            set
            {
                this.navigateUrl = value;
            }
        }

        private string target = string.Empty;
        /// <summary>
        /// 目标
        /// </summary>
        public string Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
            }
        }

        private int? isPublic = 1;
        /// <summary>
        /// 是公开
        /// </summary>
        public int? IsPublic
        {
            get
            {
                return this.isPublic;
            }
            set
            {
                this.isPublic = value;
            }
        }

        private int? isMenu = 1;
        /// <summary>
        /// 是菜单
        /// </summary>
        public int? IsMenu
        {
            get
            {
                return this.isMenu;
            }
            set
            {
                this.isMenu = value;
            }
        }

        private int? expand = 0;
        /// <summary>
        /// 展开状态
        /// </summary>
        public int? Expand
        {
            get
            {
                return this.expand;
            }
            set
            {
                this.expand = value;
            }
        }

        private string permissionItemCode = "Resource.AccessPermission";
        /// <summary>
        /// 操作权限编号(数据权限范围)
        /// </summary>
        public string PermissionItemCode
        {
            get
            {
                return this.permissionItemCode;
            }
            set
            {
                this.permissionItemCode = value;
            }
        }

        private string permissionScopeTables = string.Empty;
        /// <summary>
        /// 需要数据权限过滤的表(,符号分割)
        /// </summary>
        public string PermissionScopeTables
        {
            get
            {
                return this.permissionScopeTables;
            }
            set
            {
                this.permissionScopeTables = value;
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

        private int? sortCode = null;
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

        private int? deletionStateCode = null;
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

        private string createUserId = string.Empty;
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

        private string createBy = string.Empty;
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

        private string modifiedUserId = string.Empty;
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

        private string modifiedBy = string.Empty;
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
        public BaseModuleEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseModuleEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseModuleEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseModuleEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseModuleEntity GetSingle(DataTable dataTable)
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
        public List<BaseModuleEntity> GetList(DataTable dataTable)
        {
            List<BaseModuleEntity> entites = new List<BaseModuleEntity>();
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
        public BaseModuleEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldFullName]);
            this.Category = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCategory]);
            this.ImageIndex = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldImageIndex]);
            this.SelectedImageIndex = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldSelectedImageIndex]);
            this.NavigateUrl = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldNavigateUrl]);
            this.Target = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldTarget]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldIsPublic]);
            this.IsMenu = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldIsMenu]);
            this.Expand = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldExpand]);
            this.PermissionItemCode = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldPermissionItemCode]);
            this.PermissionScopeTables = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldPermissionScopeTables]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldAllowDelete]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseModuleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseModuleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseModuleEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldFullName]);
            this.Category = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCategory]);
            this.ImageIndex = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldImageIndex]);
            this.SelectedImageIndex = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldSelectedImageIndex]);
            this.NavigateUrl = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldNavigateUrl]);
            this.Target = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldTarget]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldIsPublic]);
            this.IsMenu = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldIsMenu]);
            this.Expand = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldExpand]);
            this.PermissionItemCode = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldPermissionItemCode]);
            this.PermissionScopeTables = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldPermissionScopeTables]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldAllowDelete]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseModuleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseModuleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldModifiedBy]);
            return this;
        }
    }
}