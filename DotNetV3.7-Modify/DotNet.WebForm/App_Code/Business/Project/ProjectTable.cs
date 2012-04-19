//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace Project
{
    /// <summary>
    /// ProjectTable
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
    public class ProjectTable
    {
        ///<summary>
        /// 项目跟进表
        ///</summary>
        [NonSerialized]
        public static string TableName = "Project";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]  
        public static string FieldId = "Id";

        ///<summary>
        /// 立项日期
        ///</summary>
        [NonSerialized]
        public static string FieldLiXiangRiQi = "LiXiangRiQi";

        ///<summary>
        /// 客户名称
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuMingCheng = "KeHuMingCheng";

        ///<summary>
        /// 客户项目名称
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuXiangMuMingCheng = "KeHuXiangMuMingCheng";

        ///<summary>
        /// 客户资料
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuZiLiao = "KeHuZiLiao";

        ///<summary>
        /// 确认图纸
        ///</summary>
        [NonSerialized]
        public static string FieldQuRenTuZhi = "QuRenTuZhi";

        ///<summary>
        /// 确认结果
        ///</summary>
        [NonSerialized]
        public static string FieldQuRenJieGuo = "QuRenJieGuo";

        ///<summary>
        /// 型号
        ///</summary>
        [NonSerialized]
        public static string FieldXingHao = "XingHao";

        ///<summary>
        /// 开改模日期
        ///</summary>
        [NonSerialized]
        public static string FieldKaiGaiRiQi = "KaiGaiRiQi";

        ///<summary>
        /// 出样日期
        ///</summary>
        [NonSerialized]
        public static string FieldChuYangRiQi = "ChuYangRiQi";

        ///<summary>
        /// 报价编号
        ///</summary>
        [NonSerialized]
        public static string FieldBaoJiaBianHao = "BaoJiaBianHao";

        ///<summary>
        /// 投料编号
        ///</summary>
        [NonSerialized]
        public static string FieldTouLiaoBianHao = "TouLiaoBianHao";

        ///<summary>
        /// 样品编号
        ///</summary>
        [NonSerialized]
        public static string FieldYangPinBianHao = "YangPinBianHao";

        ///<summary>
        /// 试产过程问题
        ///</summary>
        [NonSerialized]
        public static string FieldShiChanGuoChengWenTi = "ShiChanGuoChengWenTi";

        ///<summary>
        /// 试产总结
        ///</summary>
        [NonSerialized]
        public static string FieldShiChanZongJie = "ShiChanZongJie";

        ///<summary>
        /// 客户问题
        ///</summary>
        [NonSerialized]
        public static string FieldKeHuWenTi = "KeHuWenTi";

        ///<summary>
        /// 处理方案
        ///</summary>
        public static string FieldChuLiFangAn = "ChuLiFangAn";

        ///<summary>
        /// 客户处理状态
        ///</summary>
        public static string FieldKeHuChuLiZhuangTai = "KeHuChuLiZhuangTai";

        ///<summary>
        /// 客户处理结果
        ///</summary>
        public static string FieldKeHuChuLiJieGuo = "KeHuChuLiJieGuo";

        ///<summary>
        /// PET测试报告
        ///</summary>
        public static string FieldPETCeShiBaoGao = "PETCeShiBaoGao";

        ///<summary>
        /// PET测试结果
        ///</summary>
        public static string FieldPETCeShiJieGuo = "PETCeShiJieGuo";

        ///<summary>
        /// TG测试报告
        ///</summary>
        public static string FieldTGCeShiBaoGao = "TGCeShiBaoGao";

        ///<summary>
        /// TG测试结果
        ///</summary>
        public static string FieldTGCeShiJieGuo = "TGCeShiJieGuo";

        ///<summary>
        /// FPC测试报告
        ///</summary>
        public static string FieldFPCCeShiBaoGao = "FPCCeShiBaoGao";

        ///<summary>
        /// FPC测试结果
        ///</summary>
        public static string FieldFPCCeShiJieGuo = "FPCCeShiJieGuo";

        ///<summary>
        /// 测试报告
        ///</summary>
        public static string FieldCeShiBaoGao = "CeShiBaoGao";

        ///<summary>
        /// 问题分析验证
        ///</summary>
        public static string FieldWenTiFenXiYanZheng = "WenTiFenXiYanZheng";

        ///<summary>
        /// 审核状态
        ///</summary>
        public static string FieldAuditStatus = "AuditStatus";

        ///<summary>
        /// 允许编辑
        ///</summary>
        public static string FieldAllowEdit = "AllowEdit";

        ///<summary>
        /// 允许删除
        ///</summary>
        public static string FieldAllowDelete = "AllowDelete";

        ///<summary>
        /// 排序码
        ///</summary>
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 删除标记
        ///</summary>
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 有效标志
        ///</summary>
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 描述
        ///</summary>
        public static string FieldDescription = "Description";

        ///<summary>
        /// 创建日期
        ///</summary>
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
