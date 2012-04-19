//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace Project
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// ProjectManager
    /// 项目跟进表
    ///
    /// 修改纪录
    ///
    ///		2010-10-06 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-10-06</date>
    /// </author>
    /// </summary>
    public partial class ProjectManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProjectManager()
        {
            base.CurrentTableName = ProjectTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public ProjectManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public ProjectManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public ProjectManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public ProjectManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        /// <param name="tableName">指定表名</param>
        public ProjectManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="projectEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(ProjectEntity projectEntity)
        {
            return this.AddEntity(projectEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="projectEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <returns>主键</returns>
        public string Add(ProjectEntity projectEntity, bool identity)
        {
            this.Identity = identity;
            return this.AddEntity(projectEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="projectEntity">实体</param>
        public int Update(ProjectEntity projectEntity)
        {
            return this.UpdateEntity(projectEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public ProjectEntity GetEntity(string id)
        {
            return GetEntity(id);
        }

        public ProjectEntity GetEntity(int id)
        {
            ProjectEntity projectEntity = new ProjectEntity(this.GetDataTable(new KeyValuePair<string, object>(ProjectTable.FieldId, id)));
            return projectEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="projectEntity">实体</param>
        public string AddEntity(ProjectEntity projectEntity)
        {
            string sequence = string.Empty;
            if (projectEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(ProjectTable.TableName);
                projectEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, ProjectTable.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(ProjectTable.FieldId, projectEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(ProjectTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetValue(ProjectTable.FieldId, projectEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, projectEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(ProjectTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(ProjectTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(ProjectTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(ProjectTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(ProjectTable.FieldModifiedOn);
            if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.SqlServer || DbHelper.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="projectEntity">实体</param>
        public int UpdateEntity(ProjectEntity projectEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, projectEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(ProjectTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(ProjectTable.FieldModifiedOn);
            sqlBuilder.SetWhere(ProjectTable.FieldId, projectEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="projectEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, ProjectEntity projectEntity)
        {
            sqlBuilder.SetValue(ProjectTable.FieldLiXiangRiQi, projectEntity.LiXiangRiQi);
            sqlBuilder.SetValue(ProjectTable.FieldKeHuMingCheng, projectEntity.KeHuMingCheng);
            sqlBuilder.SetValue(ProjectTable.FieldKeHuXiangMuMingCheng, projectEntity.KeHuXiangMuMingCheng);
            sqlBuilder.SetValue(ProjectTable.FieldKeHuZiLiao, projectEntity.KeHuZiLiao);
            sqlBuilder.SetValue(ProjectTable.FieldQuRenTuZhi, projectEntity.QuRenTuZhi);
            sqlBuilder.SetValue(ProjectTable.FieldQuRenJieGuo, projectEntity.QuRenJieGuo);
            sqlBuilder.SetValue(ProjectTable.FieldXingHao, projectEntity.XingHao);
            sqlBuilder.SetValue(ProjectTable.FieldKaiGaiRiQi, projectEntity.KaiGaiRiQi);
            sqlBuilder.SetValue(ProjectTable.FieldChuYangRiQi, projectEntity.ChuYangRiQi);
            sqlBuilder.SetValue(ProjectTable.FieldBaoJiaBianHao, projectEntity.BaoJiaBianHao);
            sqlBuilder.SetValue(ProjectTable.FieldTouLiaoBianHao, projectEntity.TouLiaoBianHao);
            sqlBuilder.SetValue(ProjectTable.FieldYangPinBianHao, projectEntity.YangPinBianHao);
            sqlBuilder.SetValue(ProjectTable.FieldShiChanGuoChengWenTi, projectEntity.ShiChanGuoChengWenTi);
            sqlBuilder.SetValue(ProjectTable.FieldShiChanZongJie, projectEntity.ShiChanZongJie);
            sqlBuilder.SetValue(ProjectTable.FieldKeHuWenTi, projectEntity.KeHuWenTi);
            sqlBuilder.SetValue(ProjectTable.FieldChuLiFangAn, projectEntity.ChuLiFangAn);
            sqlBuilder.SetValue(ProjectTable.FieldKeHuChuLiZhuangTai, projectEntity.KeHuChuLiZhuangTai);
            sqlBuilder.SetValue(ProjectTable.FieldKeHuChuLiJieGuo, projectEntity.KeHuChuLiJieGuo);
            sqlBuilder.SetValue(ProjectTable.FieldPETCeShiBaoGao, projectEntity.PETCeShiBaoGao);
            sqlBuilder.SetValue(ProjectTable.FieldPETCeShiJieGuo, projectEntity.PETCeShiJieGuo);
            sqlBuilder.SetValue(ProjectTable.FieldTGCeShiBaoGao, projectEntity.TGCeShiBaoGao);
            sqlBuilder.SetValue(ProjectTable.FieldTGCeShiJieGuo, projectEntity.TGCeShiJieGuo);
            sqlBuilder.SetValue(ProjectTable.FieldFPCCeShiBaoGao, projectEntity.FPCCeShiBaoGao);
            sqlBuilder.SetValue(ProjectTable.FieldFPCCeShiJieGuo, projectEntity.FPCCeShiJieGuo);
            sqlBuilder.SetValue(ProjectTable.FieldCeShiBaoGao, projectEntity.CeShiBaoGao);
            sqlBuilder.SetValue(ProjectTable.FieldWenTiFenXiYanZheng, projectEntity.WenTiFenXiYanZheng);
            sqlBuilder.SetValue(ProjectTable.FieldAuditStatus, projectEntity.AuditStatus);
            sqlBuilder.SetValue(ProjectTable.FieldAllowEdit, projectEntity.AllowEdit);
            sqlBuilder.SetValue(ProjectTable.FieldAllowDelete, projectEntity.AllowDelete);
            sqlBuilder.SetValue(ProjectTable.FieldSortCode, projectEntity.SortCode);
            sqlBuilder.SetValue(ProjectTable.FieldDeletionStateCode, projectEntity.DeletionStateCode);
            sqlBuilder.SetValue(ProjectTable.FieldEnabled, projectEntity.Enabled);
            sqlBuilder.SetValue(ProjectTable.FieldDescription, projectEntity.Description);
            sqlBuilder.SetValue(ProjectTable.FieldModifiedUserId, projectEntity.ModifiedUserId);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(ProjectTable.FieldId, id));
        }

        /// <summary>
        /// 生成表字段说明
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetTableColumns()
        {
            int returnValue = 0;
            string tableCode = base.CurrentTableName;
            string tableName = "项目跟进表";
            // 先删除重复的数据
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginDelete(BaseTableColumnsEntity.TableName);
            sqlBuilder.SetWhere(BaseTableColumnsEntity.FieldTableCode, ProjectTable.TableName);
            returnValue += sqlBuilder.EndDelete();
            // 插入字段说明数据
            returnValue += SetTableColumns(tableCode, tableName, "Id", "主键");
            returnValue += SetTableColumns(tableCode, tableName, "LiXiangRiQi", "立项日期");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuMingCheng", "客户名称");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuXiangMuMingCheng", "客户项目名称");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuZiLiao", "客户资料");
            returnValue += SetTableColumns(tableCode, tableName, "QuRenTuZhi", "确认图纸");
            returnValue += SetTableColumns(tableCode, tableName, "QuRenJieGuo", "确认结果");
            returnValue += SetTableColumns(tableCode, tableName, "XingHao", "型号");
            returnValue += SetTableColumns(tableCode, tableName, "KaiGaiRiQi", "开改模日期");
            returnValue += SetTableColumns(tableCode, tableName, "ChuYangRiQi", "出样日期");
            returnValue += SetTableColumns(tableCode, tableName, "BaoJiaBianHao", "报价编号");
            returnValue += SetTableColumns(tableCode, tableName, "TouLiaoBianHao", "投料编号");
            returnValue += SetTableColumns(tableCode, tableName, "YangPinBianHao", "样品编号");
            returnValue += SetTableColumns(tableCode, tableName, "ShiChanGuoChengWenTi", "试产过程问题");
            returnValue += SetTableColumns(tableCode, tableName, "ShiChanZongJie", "试产总结");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuWenTi", "客户问题");
            returnValue += SetTableColumns(tableCode, tableName, "ChuLiFangAn", "处理方案");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuChuLiZhuangTai", "客户处理状态");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuChuLiJieGuo", "客户处理结果");
            returnValue += SetTableColumns(tableCode, tableName, "PETCeShiBaoGao", "PET测试报告");
            returnValue += SetTableColumns(tableCode, tableName, "PETCeShiJieGuo", "PET测试结果");
            returnValue += SetTableColumns(tableCode, tableName, "TGCeShiBaoGao", "TG测试报告");
            returnValue += SetTableColumns(tableCode, tableName, "TGCeShiJieGuo", "TG测试结果");
            returnValue += SetTableColumns(tableCode, tableName, "FPCCeShiBaoGao", "FPC测试报告");
            returnValue += SetTableColumns(tableCode, tableName, "FPCCeShiJieGuo", "FPC测试结果");
            returnValue += SetTableColumns(tableCode, tableName, "CeShiBaoGao", "测试报告");
            returnValue += SetTableColumns(tableCode, tableName, "WenTiFenXiYanZheng", "问题分析验证");
            returnValue += SetTableColumns(tableCode, tableName, "AuditStatus", "审核状态");
            returnValue += SetTableColumns(tableCode, tableName, "AllowEdit", "允许编辑");
            returnValue += SetTableColumns(tableCode, tableName, "AllowDelete", "允许删除");
            returnValue += SetTableColumns(tableCode, tableName, "SortCode", "排序码");
            returnValue += SetTableColumns(tableCode, tableName, "DeletionStateCode", "删除标记");
            returnValue += SetTableColumns(tableCode, tableName, "Enabled", "有效标志");
            returnValue += SetTableColumns(tableCode, tableName, "Description", "描述");
            returnValue += SetTableColumns(tableCode, tableName, "CreateOn", "创建日期");
            returnValue += SetTableColumns(tableCode, tableName, "CreateUserId", "创建用户主键");
            returnValue += SetTableColumns(tableCode, tableName, "CreateBy", "创建用户");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedOn", "修改日期");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedUserId", "修改用户主键");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedBy", "修改用户");
            return returnValue;
        }
    }
}