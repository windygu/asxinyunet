//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;

namespace Project
{
    using DotNet.Utilities;

    /// <summary>
    /// ProjectEntity
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
    [Serializable]
    public class ProjectEntity
    {
        private int? id = 0;
        /// <summary>
        /// ����
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

        private DateTime? liXiangRiQi = null;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? LiXiangRiQi
        {
            get
            {
                return this.liXiangRiQi;
            }
            set
            {
                this.liXiangRiQi = value;
            }
        }

        private string keHuMingCheng = null;
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string KeHuMingCheng
        {
            get
            {
                return this.keHuMingCheng;
            }
            set
            {
                this.keHuMingCheng = value;
            }
        }

        private string keHuXiangMuMingCheng = null;
        /// <summary>
        /// �ͻ���Ŀ����
        /// </summary>
        public string KeHuXiangMuMingCheng
        {
            get
            {
                return this.keHuXiangMuMingCheng;
            }
            set
            {
                this.keHuXiangMuMingCheng = value;
            }
        }

        private int? keHuZiLiao = 0;
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public int? KeHuZiLiao
        {
            get
            {
                return this.keHuZiLiao;
            }
            set
            {
                this.keHuZiLiao = value;
            }
        }

        private int? quRenTuZhi = 0;
        /// <summary>
        /// ȷ��ͼֽ
        /// </summary>
        public int? QuRenTuZhi
        {
            get
            {
                return this.quRenTuZhi;
            }
            set
            {
                this.quRenTuZhi = value;
            }
        }

        private int? quRenJieGuo = 0;
        /// <summary>
        /// ȷ�Ͻ��
        /// </summary>
        public int? QuRenJieGuo
        {
            get
            {
                return this.quRenJieGuo;
            }
            set
            {
                this.quRenJieGuo = value;
            }
        }

        private string xingHao = null;
        /// <summary>
        /// �ͺ�
        /// </summary>
        public string XingHao
        {
            get
            {
                return this.xingHao;
            }
            set
            {
                this.xingHao = value;
            }
        }

        private DateTime? kaiGaiRiQi = null;
        /// <summary>
        /// ����ģ����
        /// </summary>
        public DateTime? KaiGaiRiQi
        {
            get
            {
                return this.kaiGaiRiQi;
            }
            set
            {
                this.kaiGaiRiQi = value;
            }
        }

        private DateTime? chuYangRiQi = null;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? ChuYangRiQi
        {
            get
            {
                return this.chuYangRiQi;
            }
            set
            {
                this.chuYangRiQi = value;
            }
        }

        private string baoJiaBianHao = null;
        /// <summary>
        /// ���۱��
        /// </summary>
        public string BaoJiaBianHao
        {
            get
            {
                return this.baoJiaBianHao;
            }
            set
            {
                this.baoJiaBianHao = value;
            }
        }

        private string touLiaoBianHao = null;
        /// <summary>
        /// Ͷ�ϱ��
        /// </summary>
        public string TouLiaoBianHao
        {
            get
            {
                return this.touLiaoBianHao;
            }
            set
            {
                this.touLiaoBianHao = value;
            }
        }

        private string yangPinBianHao = null;
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string YangPinBianHao
        {
            get
            {
                return this.yangPinBianHao;
            }
            set
            {
                this.yangPinBianHao = value;
            }
        }

        private string shiChanGuoChengWenTi = null;
        /// <summary>
        /// �Բ���������
        /// </summary>
        public string ShiChanGuoChengWenTi
        {
            get
            {
                return this.shiChanGuoChengWenTi;
            }
            set
            {
                this.shiChanGuoChengWenTi = value;
            }
        }

        private string shiChanZongJie = null;
        /// <summary>
        /// �Բ��ܽ�
        /// </summary>
        public string ShiChanZongJie
        {
            get
            {
                return this.shiChanZongJie;
            }
            set
            {
                this.shiChanZongJie = value;
            }
        }

        private string keHuWenTi = null;
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string KeHuWenTi
        {
            get
            {
                return this.keHuWenTi;
            }
            set
            {
                this.keHuWenTi = value;
            }
        }

        private int? chuLiFangAn = 0;
        /// <summary>
        /// ������
        /// </summary>
        public int? ChuLiFangAn
        {
            get
            {
                return this.chuLiFangAn;
            }
            set
            {
                this.chuLiFangAn = value;
            }
        }

        private string keHuChuLiZhuangTai = null;
        /// <summary>
        /// �ͻ�����״̬
        /// </summary>
        public string KeHuChuLiZhuangTai
        {
            get
            {
                return this.keHuChuLiZhuangTai;
            }
            set
            {
                this.keHuChuLiZhuangTai = value;
            }
        }

        private string keHuChuLiJieGuo = null;
        /// <summary>
        /// �ͻ�������
        /// </summary>
        public string KeHuChuLiJieGuo
        {
            get
            {
                return this.keHuChuLiJieGuo;
            }
            set
            {
                this.keHuChuLiJieGuo = value;
            }
        }

        private int? pETCeShiBaoGao = 0;
        /// <summary>
        /// PET���Ա���
        /// </summary>
        public int? PETCeShiBaoGao
        {
            get
            {
                return this.pETCeShiBaoGao;
            }
            set
            {
                this.pETCeShiBaoGao = value;
            }
        }

        private int? pETCeShiJieGuo = 0;
        /// <summary>
        /// PET���Խ��
        /// </summary>
        public int? PETCeShiJieGuo
        {
            get
            {
                return this.pETCeShiJieGuo;
            }
            set
            {
                this.pETCeShiJieGuo = value;
            }
        }

        private int? tGCeShiBaoGao = 0;
        /// <summary>
        /// TG���Ա���
        /// </summary>
        public int? TGCeShiBaoGao
        {
            get
            {
                return this.tGCeShiBaoGao;
            }
            set
            {
                this.tGCeShiBaoGao = value;
            }
        }

        private int? tGCeShiJieGuo = 0;
        /// <summary>
        /// TG���Խ��
        /// </summary>
        public int? TGCeShiJieGuo
        {
            get
            {
                return this.tGCeShiJieGuo;
            }
            set
            {
                this.tGCeShiJieGuo = value;
            }
        }

        private int? fPCCeShiBaoGao = 0;
        /// <summary>
        /// FPC���Ա���
        /// </summary>
        public int? FPCCeShiBaoGao
        {
            get
            {
                return this.fPCCeShiBaoGao;
            }
            set
            {
                this.fPCCeShiBaoGao = value;
            }
        }

        private int? fPCCeShiJieGuo = 0;
        /// <summary>
        /// FPC���Խ��
        /// </summary>
        public int? FPCCeShiJieGuo
        {
            get
            {
                return this.fPCCeShiJieGuo;
            }
            set
            {
                this.fPCCeShiJieGuo = value;
            }
        }

        private int? ceShiBaoGao = 0;
        /// <summary>
        /// ���Ա���
        /// </summary>
        public int? CeShiBaoGao
        {
            get
            {
                return this.ceShiBaoGao;
            }
            set
            {
                this.ceShiBaoGao = value;
            }
        }

        private string wenTiFenXiYanZheng = null;
        /// <summary>
        /// ���������֤
        /// </summary>
        public string WenTiFenXiYanZheng
        {
            get
            {
                return this.wenTiFenXiYanZheng;
            }
            set
            {
                this.wenTiFenXiYanZheng = value;
            }
        }

        private string auditStatus = null;
        /// <summary>
        /// ���״̬
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

        private int? allowEdit = 0;
        /// <summary>
        /// ����༭
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

        private int? allowDelete = 0;
        /// <summary>
        /// ����ɾ��
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

        private int? sortCode = 0;
        /// <summary>
        /// ������
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

        private int? deletionStateCode = 0;
        /// <summary>
        /// ɾ�����
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
        /// ��Ч��־
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
        /// ����
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
        /// ��������
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
        /// �����û�����
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
        /// �����û�
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
        /// �޸�����
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
        /// �޸��û�����
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
        /// �޸��û�
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
        /// ���캯��
        /// </summary>
        public ProjectEntity()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dataRow">������</param>
        public ProjectEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dataReader">������</param>
        public ProjectEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dataTable">���ݱ�</param>
        public ProjectEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// �����ݱ��ȡ
        /// </summary>
        /// <param name="dataTable">���ݱ�</param>
        public ProjectEntity GetSingle(DataTable dataTable)
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
        /// �������ж�ȡ
        /// </summary>
        /// <param name="dataRow">������</param>
        public ProjectEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldId]);
            this.LiXiangRiQi = BaseBusinessLogic.ConvertToDateTime(dataRow[ProjectTable.FieldLiXiangRiQi]);
            this.KeHuMingCheng = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldKeHuMingCheng]);
            this.KeHuXiangMuMingCheng = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldKeHuXiangMuMingCheng]);
            this.KeHuZiLiao = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldKeHuZiLiao]);
            this.QuRenTuZhi = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldQuRenTuZhi]);
            this.QuRenJieGuo = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldQuRenJieGuo]);
            this.XingHao = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldXingHao]);
            this.KaiGaiRiQi = BaseBusinessLogic.ConvertToDateTime(dataRow[ProjectTable.FieldKaiGaiRiQi]);
            this.ChuYangRiQi = BaseBusinessLogic.ConvertToDateTime(dataRow[ProjectTable.FieldChuYangRiQi]);
            this.BaoJiaBianHao = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldBaoJiaBianHao]);
            this.TouLiaoBianHao = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldTouLiaoBianHao]);
            this.YangPinBianHao = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldYangPinBianHao]);
            this.ShiChanGuoChengWenTi = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldShiChanGuoChengWenTi]);
            this.ShiChanZongJie = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldShiChanZongJie]);
            this.KeHuWenTi = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldKeHuWenTi]);
            this.ChuLiFangAn = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldChuLiFangAn]);
            this.KeHuChuLiZhuangTai = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldKeHuChuLiZhuangTai]);
            this.KeHuChuLiJieGuo = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldKeHuChuLiJieGuo]);
            this.PETCeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldPETCeShiBaoGao]);
            this.PETCeShiJieGuo = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldPETCeShiJieGuo]);
            this.TGCeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldTGCeShiBaoGao]);
            this.TGCeShiJieGuo = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldTGCeShiJieGuo]);
            this.FPCCeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldFPCCeShiBaoGao]);
            this.FPCCeShiJieGuo = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldFPCCeShiJieGuo]);
            this.CeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldCeShiBaoGao]);
            this.WenTiFenXiYanZheng = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldWenTiFenXiYanZheng]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldAuditStatus]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldAllowDelete]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[ProjectTable.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[ProjectTable.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[ProjectTable.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[ProjectTable.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// ����������ȡ
        /// </summary>
        /// <param name="dataReader">������</param>
        public ProjectEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldId]);
            this.LiXiangRiQi = BaseBusinessLogic.ConvertToDateTime(dataReader[ProjectTable.FieldLiXiangRiQi]);
            this.KeHuMingCheng = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldKeHuMingCheng]);
            this.KeHuXiangMuMingCheng = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldKeHuXiangMuMingCheng]);
            this.KeHuZiLiao = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldKeHuZiLiao]);
            this.QuRenTuZhi = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldQuRenTuZhi]);
            this.QuRenJieGuo = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldQuRenJieGuo]);
            this.XingHao = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldXingHao]);
            this.KaiGaiRiQi = BaseBusinessLogic.ConvertToDateTime(dataReader[ProjectTable.FieldKaiGaiRiQi]);
            this.ChuYangRiQi = BaseBusinessLogic.ConvertToDateTime(dataReader[ProjectTable.FieldChuYangRiQi]);
            this.BaoJiaBianHao = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldBaoJiaBianHao]);
            this.TouLiaoBianHao = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldTouLiaoBianHao]);
            this.YangPinBianHao = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldYangPinBianHao]);
            this.ShiChanGuoChengWenTi = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldShiChanGuoChengWenTi]);
            this.ShiChanZongJie = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldShiChanZongJie]);
            this.KeHuWenTi = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldKeHuWenTi]);
            this.ChuLiFangAn = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldChuLiFangAn]);
            this.KeHuChuLiZhuangTai = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldKeHuChuLiZhuangTai]);
            this.KeHuChuLiJieGuo = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldKeHuChuLiJieGuo]);
            this.PETCeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldPETCeShiBaoGao]);
            this.PETCeShiJieGuo = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldPETCeShiJieGuo]);
            this.TGCeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldTGCeShiBaoGao]);
            this.TGCeShiJieGuo = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldTGCeShiJieGuo]);
            this.FPCCeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldFPCCeShiBaoGao]);
            this.FPCCeShiJieGuo = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldFPCCeShiJieGuo]);
            this.CeShiBaoGao = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldCeShiBaoGao]);
            this.WenTiFenXiYanZheng = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldWenTiFenXiYanZheng]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldAuditStatus]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldAllowDelete]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[ProjectTable.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[ProjectTable.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[ProjectTable.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[ProjectTable.FieldModifiedBy]);
            return this;
        }
    }
}