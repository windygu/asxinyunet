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
    /// ��Ŀ������
    ///
    /// �޸ļ�¼
    ///
    ///		2010-10-06 �汾��1.0 JiRiGaLa ����������
    ///
    /// �汾��1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-10-06</date>
    /// </author>
    /// </summary>
    public partial class ProjectManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public ProjectManager()
        {
            base.CurrentTableName = ProjectTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// ���캯��
        /// <param name="tableName">ָ������</param>
        /// </summary>
        public ProjectManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dbHelper">���ݿ�����</param>
        public ProjectManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="userInfo">����Ա��Ϣ</param>
        public ProjectManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dbHelper">���ݿ�����</param>
        /// <param name="userInfo">����Ա��Ϣ</param>
        public ProjectManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dbHelper">���ݿ�����</param>
        /// <param name="userInfo">����Ա��Ϣ</param>
        /// <param name="tableName">ָ������</param>
        public ProjectManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="projectEntity">ʵ��</param>
        /// <returns>����</returns>
        public string Add(ProjectEntity projectEntity)
        {
            return this.AddEntity(projectEntity);
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="projectEntity">ʵ��</param>
        /// <param name="identity">��������ʽ</param>
        /// <returns>����</returns>
        public string Add(ProjectEntity projectEntity, bool identity)
        {
            this.Identity = identity;
            return this.AddEntity(projectEntity);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="projectEntity">ʵ��</param>
        public int Update(ProjectEntity projectEntity)
        {
            return this.UpdateEntity(projectEntity);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="id">����</param>
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
        /// ���ʵ��
        /// </summary>
        /// <param name="projectEntity">ʵ��</param>
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
        /// ����ʵ��
        /// </summary>
        /// <param name="projectEntity">ʵ��</param>
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
        /// ����ʵ��
        /// </summary>
        /// <param name="projectEntity">ʵ��</param>
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
        /// ɾ��ʵ��
        /// </summary>
        /// <param name="id">����</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(ProjectTable.FieldId, id));
        }

        /// <summary>
        /// ���ɱ��ֶ�˵��
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int SetTableColumns()
        {
            int returnValue = 0;
            string tableCode = base.CurrentTableName;
            string tableName = "��Ŀ������";
            // ��ɾ���ظ�������
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginDelete(BaseTableColumnsEntity.TableName);
            sqlBuilder.SetWhere(BaseTableColumnsEntity.FieldTableCode, ProjectTable.TableName);
            returnValue += sqlBuilder.EndDelete();
            // �����ֶ�˵������
            returnValue += SetTableColumns(tableCode, tableName, "Id", "����");
            returnValue += SetTableColumns(tableCode, tableName, "LiXiangRiQi", "��������");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuMingCheng", "�ͻ�����");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuXiangMuMingCheng", "�ͻ���Ŀ����");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuZiLiao", "�ͻ�����");
            returnValue += SetTableColumns(tableCode, tableName, "QuRenTuZhi", "ȷ��ͼֽ");
            returnValue += SetTableColumns(tableCode, tableName, "QuRenJieGuo", "ȷ�Ͻ��");
            returnValue += SetTableColumns(tableCode, tableName, "XingHao", "�ͺ�");
            returnValue += SetTableColumns(tableCode, tableName, "KaiGaiRiQi", "����ģ����");
            returnValue += SetTableColumns(tableCode, tableName, "ChuYangRiQi", "��������");
            returnValue += SetTableColumns(tableCode, tableName, "BaoJiaBianHao", "���۱��");
            returnValue += SetTableColumns(tableCode, tableName, "TouLiaoBianHao", "Ͷ�ϱ��");
            returnValue += SetTableColumns(tableCode, tableName, "YangPinBianHao", "��Ʒ���");
            returnValue += SetTableColumns(tableCode, tableName, "ShiChanGuoChengWenTi", "�Բ���������");
            returnValue += SetTableColumns(tableCode, tableName, "ShiChanZongJie", "�Բ��ܽ�");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuWenTi", "�ͻ�����");
            returnValue += SetTableColumns(tableCode, tableName, "ChuLiFangAn", "������");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuChuLiZhuangTai", "�ͻ�����״̬");
            returnValue += SetTableColumns(tableCode, tableName, "KeHuChuLiJieGuo", "�ͻ�������");
            returnValue += SetTableColumns(tableCode, tableName, "PETCeShiBaoGao", "PET���Ա���");
            returnValue += SetTableColumns(tableCode, tableName, "PETCeShiJieGuo", "PET���Խ��");
            returnValue += SetTableColumns(tableCode, tableName, "TGCeShiBaoGao", "TG���Ա���");
            returnValue += SetTableColumns(tableCode, tableName, "TGCeShiJieGuo", "TG���Խ��");
            returnValue += SetTableColumns(tableCode, tableName, "FPCCeShiBaoGao", "FPC���Ա���");
            returnValue += SetTableColumns(tableCode, tableName, "FPCCeShiJieGuo", "FPC���Խ��");
            returnValue += SetTableColumns(tableCode, tableName, "CeShiBaoGao", "���Ա���");
            returnValue += SetTableColumns(tableCode, tableName, "WenTiFenXiYanZheng", "���������֤");
            returnValue += SetTableColumns(tableCode, tableName, "AuditStatus", "���״̬");
            returnValue += SetTableColumns(tableCode, tableName, "AllowEdit", "����༭");
            returnValue += SetTableColumns(tableCode, tableName, "AllowDelete", "����ɾ��");
            returnValue += SetTableColumns(tableCode, tableName, "SortCode", "������");
            returnValue += SetTableColumns(tableCode, tableName, "DeletionStateCode", "ɾ�����");
            returnValue += SetTableColumns(tableCode, tableName, "Enabled", "��Ч��־");
            returnValue += SetTableColumns(tableCode, tableName, "Description", "����");
            returnValue += SetTableColumns(tableCode, tableName, "CreateOn", "��������");
            returnValue += SetTableColumns(tableCode, tableName, "CreateUserId", "�����û�����");
            returnValue += SetTableColumns(tableCode, tableName, "CreateBy", "�����û�");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedOn", "�޸�����");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedUserId", "�޸��û�����");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedBy", "�޸��û�");
            return returnValue;
        }
    }
}