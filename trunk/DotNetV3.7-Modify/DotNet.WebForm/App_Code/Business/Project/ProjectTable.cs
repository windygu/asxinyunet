//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace Project
{
    /// <summary>
    /// ProjectTable
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
    public class ProjectTable
    {
        ///<summary>
        /// ��Ŀ������
        ///</summary>
        [NonSerialized]
        public static string TableName = "Project";

        ///<summary>
        /// ����
        ///</summary>
        [NonSerialized]  
        public static string FieldId = "Id";

        ///<summary>
        /// ��������
        ///</summary>
        [NonSerialized]
        public static string FieldLiXiangRiQi = "LiXiangRiQi";

        ///<summary>
        /// �ͻ�����
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuMingCheng = "KeHuMingCheng";

        ///<summary>
        /// �ͻ���Ŀ����
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuXiangMuMingCheng = "KeHuXiangMuMingCheng";

        ///<summary>
        /// �ͻ�����
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuZiLiao = "KeHuZiLiao";

        ///<summary>
        /// ȷ��ͼֽ
        ///</summary>
        [NonSerialized]
        public static string FieldQuRenTuZhi = "QuRenTuZhi";

        ///<summary>
        /// ȷ�Ͻ��
        ///</summary>
        [NonSerialized]
        public static string FieldQuRenJieGuo = "QuRenJieGuo";

        ///<summary>
        /// �ͺ�
        ///</summary>
        [NonSerialized]
        public static string FieldXingHao = "XingHao";

        ///<summary>
        /// ����ģ����
        ///</summary>
        [NonSerialized]
        public static string FieldKaiGaiRiQi = "KaiGaiRiQi";

        ///<summary>
        /// ��������
        ///</summary>
        [NonSerialized]
        public static string FieldChuYangRiQi = "ChuYangRiQi";

        ///<summary>
        /// ���۱��
        ///</summary>
        [NonSerialized]
        public static string FieldBaoJiaBianHao = "BaoJiaBianHao";

        ///<summary>
        /// Ͷ�ϱ��
        ///</summary>
        [NonSerialized]
        public static string FieldTouLiaoBianHao = "TouLiaoBianHao";

        ///<summary>
        /// ��Ʒ���
        ///</summary>
        [NonSerialized]
        public static string FieldYangPinBianHao = "YangPinBianHao";

        ///<summary>
        /// �Բ���������
        ///</summary>
        [NonSerialized]
        public static string FieldShiChanGuoChengWenTi = "ShiChanGuoChengWenTi";

        ///<summary>
        /// �Բ��ܽ�
        ///</summary>
        [NonSerialized]
        public static string FieldShiChanZongJie = "ShiChanZongJie";

        ///<summary>
        /// �ͻ�����
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuWenTi = "KeHuWenTi";

        ///<summary>
        /// ������
        ///</summary>
        public static string FieldChuLiFangAn = "ChuLiFangAn";

        ///<summary>
        /// �ͻ�����״̬
        ///</summary>
        public static string FieldKeHuChuLiZhuangTai = "KeHuChuLiZhuangTai";

        ///<summary>
        /// �ͻ�������
        ///</summary>
        public static string FieldKeHuChuLiJieGuo = "KeHuChuLiJieGuo";

        ///<summary>
        /// PET���Ա���
        ///</summary>
        public static string FieldPETCeShiBaoGao = "PETCeShiBaoGao";

        ///<summary>
        /// PET���Խ��
        ///</summary>
        public static string FieldPETCeShiJieGuo = "PETCeShiJieGuo";

        ///<summary>
        /// TG���Ա���
        ///</summary>
        public static string FieldTGCeShiBaoGao = "TGCeShiBaoGao";

        ///<summary>
        /// TG���Խ��
        ///</summary>
        public static string FieldTGCeShiJieGuo = "TGCeShiJieGuo";

        ///<summary>
        /// FPC���Ա���
        ///</summary>
        public static string FieldFPCCeShiBaoGao = "FPCCeShiBaoGao";

        ///<summary>
        /// FPC���Խ��
        ///</summary>
        public static string FieldFPCCeShiJieGuo = "FPCCeShiJieGuo";

        ///<summary>
        /// ���Ա���
        ///</summary>
        public static string FieldCeShiBaoGao = "CeShiBaoGao";

        ///<summary>
        /// ���������֤
        ///</summary>
        public static string FieldWenTiFenXiYanZheng = "WenTiFenXiYanZheng";

        ///<summary>
        /// ���״̬
        ///</summary>
        public static string FieldAuditStatus = "AuditStatus";

        ///<summary>
        /// ����༭
        ///</summary>
        public static string FieldAllowEdit = "AllowEdit";

        ///<summary>
        /// ����ɾ��
        ///</summary>
        public static string FieldAllowDelete = "AllowDelete";

        ///<summary>
        /// ������
        ///</summary>
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// ɾ�����
        ///</summary>
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// ��Ч��־
        ///</summary>
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// ����
        ///</summary>
        public static string FieldDescription = "Description";

        ///<summary>
        /// ��������
        ///</summary>
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// �����û�����
        ///</summary>
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// �����û�
        ///</summary>
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// �޸�����
        ///</summary>
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// �޸��û�����
        ///</summary>
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// �޸��û�
        ///</summary>
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
