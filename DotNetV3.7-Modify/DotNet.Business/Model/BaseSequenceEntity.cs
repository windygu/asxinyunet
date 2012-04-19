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
    /// BaseSequenceEntity
    /// 序列产生器表
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
    public partial class BaseSequenceEntity
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

        private string fullName = null;
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

        private string prefix = null;
        /// <summary>
        /// 序列号前缀
        /// </summary>
        public string Prefix
        {
            get
            {
                return this.prefix;
            }
            set
            {
                this.prefix = value;
            }
        }

        private string separator = null;
        /// <summary>
        /// 序列号分隔符
        /// </summary>
        public string Separator
        {
            get
            {
                return this.separator;
            }
            set
            {
                this.separator = value;
            }
        }

        private int? sequence = 0;
        /// <summary>
        /// 升序序列
        /// </summary>
        public int? Sequence
        {
            get
            {
                return this.sequence;
            }
            set
            {
                this.sequence = value;
            }
        }

        private int? reduction = 0;
        /// <summary>
        /// 倒序序列
        /// </summary>
        public int? Reduction
        {
            get
            {
                return this.reduction;
            }
            set
            {
                this.reduction = value;
            }
        }

        private int? step = 0;
        /// <summary>
        /// 步骤
        /// </summary>
        public int? Step
        {
            get
            {
                return this.step;
            }
            set
            {
                this.step = value;
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
        public BaseSequenceEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseSequenceEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseSequenceEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseSequenceEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseSequenceEntity GetSingle(DataTable dataTable)
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
        public List<BaseSequenceEntity> GetList(DataTable dataTable)
        {
            List<BaseSequenceEntity> entites = new List<BaseSequenceEntity>();
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
        public BaseSequenceEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldId]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldFullName]);
            this.Prefix = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldPrefix]);
            this.Separator = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldSeparator]);
            this.Sequence = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldSequence]);
            this.Reduction = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldReduction]);
            this.Step = BaseBusinessLogic.ConvertToInt(dataRow[BaseSequenceEntity.FieldStep]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseSequenceEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseSequenceEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseSequenceEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseSequenceEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldId]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldFullName]);
            this.Prefix = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldPrefix]);
            this.Separator = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldSeparator]);
            this.Sequence = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldSequence]);
            this.Reduction = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldReduction]);
            this.Step = BaseBusinessLogic.ConvertToInt(dataReader[BaseSequenceEntity.FieldStep]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseSequenceEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseSequenceEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseSequenceEntity.FieldModifiedBy]);
            return this;
        }
    }
}
