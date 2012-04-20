/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 08:40:35
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites
{
    /// <summary>项目</summary>
    [Serializable]
    [DataObject]
    [Description("项目")]
    [BindIndex("PK_PROJECT", true, "Id")]
    [BindTable("Project", Description = "项目", ConnName = "BusinessDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class Project : IProject
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "编号", null, "int", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private DateTime _LiXiangRiQi;
        /// <summary>李湘Ri齐</summary>
        [DisplayName("李湘Ri齐")]
        [Description("李湘Ri齐")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(2, "LiXiangRiQi", "李湘Ri齐", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime LiXiangRiQi
        {
            get { return _LiXiangRiQi; }
            set { if (OnPropertyChanging("LiXiangRiQi", value)) { _LiXiangRiQi = value; OnPropertyChanged("LiXiangRiQi"); } }
        }

        private String _KeHuMingCheng;
        /// <summary>柯胡明郑</summary>
        [DisplayName("柯胡明郑")]
        [Description("柯胡明郑")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "KeHuMingCheng", "柯胡明郑", null, "nvarchar(100)", 0, 0, true)]
        public virtual String KeHuMingCheng
        {
            get { return _KeHuMingCheng; }
            set { if (OnPropertyChanging("KeHuMingCheng", value)) { _KeHuMingCheng = value; OnPropertyChanged("KeHuMingCheng"); } }
        }

        private String _KeHuXiangMuMingCheng;
        /// <summary>柯胡湘穆明郑</summary>
        [DisplayName("柯胡湘穆明郑")]
        [Description("柯胡湘穆明郑")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "KeHuXiangMuMingCheng", "柯胡湘穆明郑", null, "nvarchar(100)", 0, 0, true)]
        public virtual String KeHuXiangMuMingCheng
        {
            get { return _KeHuXiangMuMingCheng; }
            set { if (OnPropertyChanging("KeHuXiangMuMingCheng", value)) { _KeHuXiangMuMingCheng = value; OnPropertyChanged("KeHuXiangMuMingCheng"); } }
        }

        private Int32 _KeHuZiLiao;
        /// <summary>柯胡子廖</summary>
        [DisplayName("柯胡子廖")]
        [Description("柯胡子廖")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "KeHuZiLiao", "柯胡子廖", null, "int", 10, 0, false)]
        public virtual Int32 KeHuZiLiao
        {
            get { return _KeHuZiLiao; }
            set { if (OnPropertyChanging("KeHuZiLiao", value)) { _KeHuZiLiao = value; OnPropertyChanged("KeHuZiLiao"); } }
        }

        private Int32 _QuRenTuZhi;
        /// <summary>曲任杜志</summary>
        [DisplayName("曲任杜志")]
        [Description("曲任杜志")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "QuRenTuZhi", "曲任杜志", null, "int", 10, 0, false)]
        public virtual Int32 QuRenTuZhi
        {
            get { return _QuRenTuZhi; }
            set { if (OnPropertyChanging("QuRenTuZhi", value)) { _QuRenTuZhi = value; OnPropertyChanged("QuRenTuZhi"); } }
        }

        private Int32 _QuRenJieGuo;
        /// <summary>曲任洁郭</summary>
        [DisplayName("曲任洁郭")]
        [Description("曲任洁郭")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "QuRenJieGuo", "曲任洁郭", null, "int", 10, 0, false)]
        public virtual Int32 QuRenJieGuo
        {
            get { return _QuRenJieGuo; }
            set { if (OnPropertyChanging("QuRenJieGuo", value)) { _QuRenJieGuo = value; OnPropertyChanged("QuRenJieGuo"); } }
        }

        private String _XingHao;
        /// <summary>产品型号</summary>
        [DisplayName("产品型号")]
        [Description("产品型号")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(8, "XingHao", "产品型号", null, "nvarchar(100)", 0, 0, true)]
        public virtual String XingHao
        {
            get { return _XingHao; }
            set { if (OnPropertyChanging("XingHao", value)) { _XingHao = value; OnPropertyChanged("XingHao"); } }
        }

        private DateTime _KaiGaiRiQi;
        /// <summary>启盖Ri齐</summary>
        [DisplayName("启盖Ri齐")]
        [Description("启盖Ri齐")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "KaiGaiRiQi", "启盖Ri齐", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime KaiGaiRiQi
        {
            get { return _KaiGaiRiQi; }
            set { if (OnPropertyChanging("KaiGaiRiQi", value)) { _KaiGaiRiQi = value; OnPropertyChanged("KaiGaiRiQi"); } }
        }

        private DateTime _ChuYangRiQi;
        /// <summary>楚杨Ri齐</summary>
        [DisplayName("楚杨Ri齐")]
        [Description("楚杨Ri齐")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "ChuYangRiQi", "楚杨Ri齐", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime ChuYangRiQi
        {
            get { return _ChuYangRiQi; }
            set { if (OnPropertyChanging("ChuYangRiQi", value)) { _ChuYangRiQi = value; OnPropertyChanged("ChuYangRiQi"); } }
        }

        private String _BaoJiaBianHao;
        /// <summary>可以贾陈水扁郝</summary>
        [DisplayName("可以贾陈水扁郝")]
        [Description("可以贾陈水扁郝")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(11, "BaoJiaBianHao", "可以贾陈水扁郝", null, "nvarchar(100)", 0, 0, true)]
        public virtual String BaoJiaBianHao
        {
            get { return _BaoJiaBianHao; }
            set { if (OnPropertyChanging("BaoJiaBianHao", value)) { _BaoJiaBianHao = value; OnPropertyChanged("BaoJiaBianHao"); } }
        }

        private String _TouLiaoBianHao;
        /// <summary>包头廖陈水扁郝</summary>
        [DisplayName("包头廖陈水扁郝")]
        [Description("包头廖陈水扁郝")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(12, "TouLiaoBianHao", "包头廖陈水扁郝", null, "nvarchar(800)", 0, 0, true)]
        public virtual String TouLiaoBianHao
        {
            get { return _TouLiaoBianHao; }
            set { if (OnPropertyChanging("TouLiaoBianHao", value)) { _TouLiaoBianHao = value; OnPropertyChanged("TouLiaoBianHao"); } }
        }

        private String _YangPinBianHao;
        /// <summary>杨针陈水扁郝</summary>
        [DisplayName("杨针陈水扁郝")]
        [Description("杨针陈水扁郝")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(13, "YangPinBianHao", "杨针陈水扁郝", null, "nvarchar(100)", 0, 0, true)]
        public virtual String YangPinBianHao
        {
            get { return _YangPinBianHao; }
            set { if (OnPropertyChanging("YangPinBianHao", value)) { _YangPinBianHao = value; OnPropertyChanged("YangPinBianHao"); } }
        }

        private String _ShiChanGuoChengWenTi;
        /// <summary>室陈郭郑温家宝Ti</summary>
        [DisplayName("室陈郭郑温家宝Ti")]
        [Description("室陈郭郑温家宝Ti")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(14, "ShiChanGuoChengWenTi", "室陈郭郑温家宝Ti", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String ShiChanGuoChengWenTi
        {
            get { return _ShiChanGuoChengWenTi; }
            set { if (OnPropertyChanging("ShiChanGuoChengWenTi", value)) { _ShiChanGuoChengWenTi = value; OnPropertyChanged("ShiChanGuoChengWenTi"); } }
        }

        private String _ShiChanZongJie;
        /// <summary>室陈宗洁</summary>
        [DisplayName("室陈宗洁")]
        [Description("室陈宗洁")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(15, "ShiChanZongJie", "室陈宗洁", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String ShiChanZongJie
        {
            get { return _ShiChanZongJie; }
            set { if (OnPropertyChanging("ShiChanZongJie", value)) { _ShiChanZongJie = value; OnPropertyChanged("ShiChanZongJie"); } }
        }

        private String _KeHuWenTi;
        /// <summary>柯胡温家宝Ti</summary>
        [DisplayName("柯胡温家宝Ti")]
        [Description("柯胡温家宝Ti")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(16, "KeHuWenTi", "柯胡温家宝Ti", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String KeHuWenTi
        {
            get { return _KeHuWenTi; }
            set { if (OnPropertyChanging("KeHuWenTi", value)) { _KeHuWenTi = value; OnPropertyChanged("KeHuWenTi"); } }
        }

        private Int32 _ChuLiFangAn;
        /// <summary>楚李方一</summary>
        [DisplayName("楚李方一")]
        [Description("楚李方一")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(17, "ChuLiFangAn", "楚李方一", null, "int", 10, 0, false)]
        public virtual Int32 ChuLiFangAn
        {
            get { return _ChuLiFangAn; }
            set { if (OnPropertyChanging("ChuLiFangAn", value)) { _ChuLiFangAn = value; OnPropertyChanged("ChuLiFangAn"); } }
        }

        private String _KeHuChuLiZhuangTai;
        /// <summary>柯胡楚李庄泰</summary>
        [DisplayName("柯胡楚李庄泰")]
        [Description("柯胡楚李庄泰")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(18, "KeHuChuLiZhuangTai", "柯胡楚李庄泰", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String KeHuChuLiZhuangTai
        {
            get { return _KeHuChuLiZhuangTai; }
            set { if (OnPropertyChanging("KeHuChuLiZhuangTai", value)) { _KeHuChuLiZhuangTai = value; OnPropertyChanged("KeHuChuLiZhuangTai"); } }
        }

        private String _KeHuChuLiJieGuo;
        /// <summary>柯胡楚李洁郭</summary>
        [DisplayName("柯胡楚李洁郭")]
        [Description("柯胡楚李洁郭")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(19, "KeHuChuLiJieGuo", "柯胡楚李洁郭", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String KeHuChuLiJieGuo
        {
            get { return _KeHuChuLiJieGuo; }
            set { if (OnPropertyChanging("KeHuChuLiJieGuo", value)) { _KeHuChuLiJieGuo = value; OnPropertyChanged("KeHuChuLiJieGuo"); } }
        }

        private Int32 _PETCeShiBaoGao;
        /// <summary>用户宠物表行政长官室可以高</summary>
        [DisplayName("用户宠物表行政长官室可以高")]
        [Description("用户宠物表行政长官室可以高")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(20, "PETCeShiBaoGao", "用户宠物表行政长官室可以高", null, "int", 10, 0, false)]
        public virtual Int32 PETCeShiBaoGao
        {
            get { return _PETCeShiBaoGao; }
            set { if (OnPropertyChanging("PETCeShiBaoGao", value)) { _PETCeShiBaoGao = value; OnPropertyChanged("PETCeShiBaoGao"); } }
        }

        private Int32 _PETCeShiJieGuo;
        /// <summary>用户宠物表行政长官室洁郭</summary>
        [DisplayName("用户宠物表行政长官室洁郭")]
        [Description("用户宠物表行政长官室洁郭")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(21, "PETCeShiJieGuo", "用户宠物表行政长官室洁郭", null, "int", 10, 0, false)]
        public virtual Int32 PETCeShiJieGuo
        {
            get { return _PETCeShiJieGuo; }
            set { if (OnPropertyChanging("PETCeShiJieGuo", value)) { _PETCeShiJieGuo = value; OnPropertyChanged("PETCeShiJieGuo"); } }
        }

        private Int32 _TGCeShiBaoGao;
        /// <summary>TG行政长官室可以高</summary>
        [DisplayName("TG行政长官室可以高")]
        [Description("TG行政长官室可以高")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(22, "TGCeShiBaoGao", "TG行政长官室可以高", null, "int", 10, 0, false)]
        public virtual Int32 TGCeShiBaoGao
        {
            get { return _TGCeShiBaoGao; }
            set { if (OnPropertyChanging("TGCeShiBaoGao", value)) { _TGCeShiBaoGao = value; OnPropertyChanged("TGCeShiBaoGao"); } }
        }

        private Int32 _TGCeShiJieGuo;
        /// <summary>TG行政长官室洁郭</summary>
        [DisplayName("TG行政长官室洁郭")]
        [Description("TG行政长官室洁郭")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(23, "TGCeShiJieGuo", "TG行政长官室洁郭", null, "int", 10, 0, false)]
        public virtual Int32 TGCeShiJieGuo
        {
            get { return _TGCeShiJieGuo; }
            set { if (OnPropertyChanging("TGCeShiJieGuo", value)) { _TGCeShiJieGuo = value; OnPropertyChanged("TGCeShiJieGuo"); } }
        }

        private Int32 _FPCCeShiBaoGao;
        /// <summary>FPC行政长官室可以高</summary>
        [DisplayName("FPC行政长官室可以高")]
        [Description("FPC行政长官室可以高")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(24, "FPCCeShiBaoGao", "FPC行政长官室可以高", null, "int", 10, 0, false)]
        public virtual Int32 FPCCeShiBaoGao
        {
            get { return _FPCCeShiBaoGao; }
            set { if (OnPropertyChanging("FPCCeShiBaoGao", value)) { _FPCCeShiBaoGao = value; OnPropertyChanged("FPCCeShiBaoGao"); } }
        }

        private Int32 _FPCCeShiJieGuo;
        /// <summary>FPC行政长官室洁郭</summary>
        [DisplayName("FPC行政长官室洁郭")]
        [Description("FPC行政长官室洁郭")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(25, "FPCCeShiJieGuo", "FPC行政长官室洁郭", null, "int", 10, 0, false)]
        public virtual Int32 FPCCeShiJieGuo
        {
            get { return _FPCCeShiJieGuo; }
            set { if (OnPropertyChanging("FPCCeShiJieGuo", value)) { _FPCCeShiJieGuo = value; OnPropertyChanged("FPCCeShiJieGuo"); } }
        }

        private Int32 _CeShiBaoGao;
        /// <summary>行政长官室可以高</summary>
        [DisplayName("行政长官室可以高")]
        [Description("行政长官室可以高")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(26, "CeShiBaoGao", "行政长官室可以高", null, "int", 10, 0, false)]
        public virtual Int32 CeShiBaoGao
        {
            get { return _CeShiBaoGao; }
            set { if (OnPropertyChanging("CeShiBaoGao", value)) { _CeShiBaoGao = value; OnPropertyChanged("CeShiBaoGao"); } }
        }

        private String _WenTiFenXiYanZheng;
        /// <summary>温家宝Ti工业铁损十一严郑</summary>
        [DisplayName("温家宝Ti工业铁损十一严郑")]
        [Description("温家宝Ti工业铁损十一严郑")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(27, "WenTiFenXiYanZheng", "温家宝Ti工业铁损十一严郑", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String WenTiFenXiYanZheng
        {
            get { return _WenTiFenXiYanZheng; }
            set { if (OnPropertyChanging("WenTiFenXiYanZheng", value)) { _WenTiFenXiYanZheng = value; OnPropertyChanged("WenTiFenXiYanZheng"); } }
        }

        private String _AuditStatus;
        /// <summary>审核状态</summary>
        [DisplayName("审核状态")]
        [Description("审核状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(28, "AuditStatus", "审核状态", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditStatus
        {
            get { return _AuditStatus; }
            set { if (OnPropertyChanging("AuditStatus", value)) { _AuditStatus = value; OnPropertyChanged("AuditStatus"); } }
        }

        private Int32 _AllowEdit;
        /// <summary>允许编辑</summary>
        [DisplayName("允许编辑")]
        [Description("允许编辑")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(29, "AllowEdit", "允许编辑", "1", "int", 10, 0, false)]
        public virtual Int32 AllowEdit
        {
            get { return _AllowEdit; }
            set { if (OnPropertyChanging("AllowEdit", value)) { _AllowEdit = value; OnPropertyChanged("AllowEdit"); } }
        }

        private Int32 _AllowDelete;
        /// <summary>允许删除</summary>
        [DisplayName("允许删除")]
        [Description("允许删除")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(30, "AllowDelete", "允许删除", "1", "int", 10, 0, false)]
        public virtual Int32 AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging("AllowDelete", value)) { _AllowDelete = value; OnPropertyChanged("AllowDelete"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序号</summary>
        [DisplayName("排序号")]
        [Description("排序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(31, "SortCode", "排序号", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private Int32 _Enabled;
        /// <summary>是否可用</summary>
        [DisplayName("是否可用")]
        [Description("是否可用")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(32, "Enabled", "是否可用", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary>用户是否删除</summary>
        [DisplayName("用户是否删除")]
        [Description("用户是否删除")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(33, "DeletionStateCode", "用户是否删除", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(34, "Description", "描述", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _CreateOn;
        /// <summary>创建上</summary>
        [DisplayName("创建上")]
        [Description("创建上")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(35, "CreateOn", "创建上", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary>创建人ID</summary>
        [DisplayName("创建人ID")]
        [Description("创建人ID")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(36, "CreateUserId", "创建人ID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary>创建由</summary>
        [DisplayName("创建由")]
        [Description("创建由")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(37, "CreateBy", "创建由", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateBy
        {
            get { return _CreateBy; }
            set { if (OnPropertyChanging("CreateBy", value)) { _CreateBy = value; OnPropertyChanged("CreateBy"); } }
        }

        private DateTime _ModifiedOn;
        /// <summary>修改日期</summary>
        [DisplayName("修改日期")]
        [Description("修改日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(38, "ModifiedOn", "修改日期", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        [DisplayName("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [Description("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(39, "ModifiedUserId", "修改标识1修改0没修改Usersandglobalprivileges编号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary>修改者</summary>
        [DisplayName("修改者")]
        [Description("修改者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(40, "ModifiedBy", "修改者", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedBy
        {
            get { return _ModifiedBy; }
            set { if (OnPropertyChanging("ModifiedBy", value)) { _ModifiedBy = value; OnPropertyChanged("ModifiedBy"); } }
        }
		#endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "Id" : return _Id;
                    case "LiXiangRiQi" : return _LiXiangRiQi;
                    case "KeHuMingCheng" : return _KeHuMingCheng;
                    case "KeHuXiangMuMingCheng" : return _KeHuXiangMuMingCheng;
                    case "KeHuZiLiao" : return _KeHuZiLiao;
                    case "QuRenTuZhi" : return _QuRenTuZhi;
                    case "QuRenJieGuo" : return _QuRenJieGuo;
                    case "XingHao" : return _XingHao;
                    case "KaiGaiRiQi" : return _KaiGaiRiQi;
                    case "ChuYangRiQi" : return _ChuYangRiQi;
                    case "BaoJiaBianHao" : return _BaoJiaBianHao;
                    case "TouLiaoBianHao" : return _TouLiaoBianHao;
                    case "YangPinBianHao" : return _YangPinBianHao;
                    case "ShiChanGuoChengWenTi" : return _ShiChanGuoChengWenTi;
                    case "ShiChanZongJie" : return _ShiChanZongJie;
                    case "KeHuWenTi" : return _KeHuWenTi;
                    case "ChuLiFangAn" : return _ChuLiFangAn;
                    case "KeHuChuLiZhuangTai" : return _KeHuChuLiZhuangTai;
                    case "KeHuChuLiJieGuo" : return _KeHuChuLiJieGuo;
                    case "PETCeShiBaoGao" : return _PETCeShiBaoGao;
                    case "PETCeShiJieGuo" : return _PETCeShiJieGuo;
                    case "TGCeShiBaoGao" : return _TGCeShiBaoGao;
                    case "TGCeShiJieGuo" : return _TGCeShiJieGuo;
                    case "FPCCeShiBaoGao" : return _FPCCeShiBaoGao;
                    case "FPCCeShiJieGuo" : return _FPCCeShiJieGuo;
                    case "CeShiBaoGao" : return _CeShiBaoGao;
                    case "WenTiFenXiYanZheng" : return _WenTiFenXiYanZheng;
                    case "AuditStatus" : return _AuditStatus;
                    case "AllowEdit" : return _AllowEdit;
                    case "AllowDelete" : return _AllowDelete;
                    case "SortCode" : return _SortCode;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Description" : return _Description;
                    case "CreateOn" : return _CreateOn;
                    case "CreateUserId" : return _CreateUserId;
                    case "CreateBy" : return _CreateBy;
                    case "ModifiedOn" : return _ModifiedOn;
                    case "ModifiedUserId" : return _ModifiedUserId;
                    case "ModifiedBy" : return _ModifiedBy;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "LiXiangRiQi" : _LiXiangRiQi = Convert.ToDateTime(value); break;
                    case "KeHuMingCheng" : _KeHuMingCheng = Convert.ToString(value); break;
                    case "KeHuXiangMuMingCheng" : _KeHuXiangMuMingCheng = Convert.ToString(value); break;
                    case "KeHuZiLiao" : _KeHuZiLiao = Convert.ToInt32(value); break;
                    case "QuRenTuZhi" : _QuRenTuZhi = Convert.ToInt32(value); break;
                    case "QuRenJieGuo" : _QuRenJieGuo = Convert.ToInt32(value); break;
                    case "XingHao" : _XingHao = Convert.ToString(value); break;
                    case "KaiGaiRiQi" : _KaiGaiRiQi = Convert.ToDateTime(value); break;
                    case "ChuYangRiQi" : _ChuYangRiQi = Convert.ToDateTime(value); break;
                    case "BaoJiaBianHao" : _BaoJiaBianHao = Convert.ToString(value); break;
                    case "TouLiaoBianHao" : _TouLiaoBianHao = Convert.ToString(value); break;
                    case "YangPinBianHao" : _YangPinBianHao = Convert.ToString(value); break;
                    case "ShiChanGuoChengWenTi" : _ShiChanGuoChengWenTi = Convert.ToString(value); break;
                    case "ShiChanZongJie" : _ShiChanZongJie = Convert.ToString(value); break;
                    case "KeHuWenTi" : _KeHuWenTi = Convert.ToString(value); break;
                    case "ChuLiFangAn" : _ChuLiFangAn = Convert.ToInt32(value); break;
                    case "KeHuChuLiZhuangTai" : _KeHuChuLiZhuangTai = Convert.ToString(value); break;
                    case "KeHuChuLiJieGuo" : _KeHuChuLiJieGuo = Convert.ToString(value); break;
                    case "PETCeShiBaoGao" : _PETCeShiBaoGao = Convert.ToInt32(value); break;
                    case "PETCeShiJieGuo" : _PETCeShiJieGuo = Convert.ToInt32(value); break;
                    case "TGCeShiBaoGao" : _TGCeShiBaoGao = Convert.ToInt32(value); break;
                    case "TGCeShiJieGuo" : _TGCeShiJieGuo = Convert.ToInt32(value); break;
                    case "FPCCeShiBaoGao" : _FPCCeShiBaoGao = Convert.ToInt32(value); break;
                    case "FPCCeShiJieGuo" : _FPCCeShiJieGuo = Convert.ToInt32(value); break;
                    case "CeShiBaoGao" : _CeShiBaoGao = Convert.ToInt32(value); break;
                    case "WenTiFenXiYanZheng" : _WenTiFenXiYanZheng = Convert.ToString(value); break;
                    case "AuditStatus" : _AuditStatus = Convert.ToString(value); break;
                    case "AllowEdit" : _AllowEdit = Convert.ToInt32(value); break;
                    case "AllowDelete" : _AllowDelete = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "CreateOn" : _CreateOn = Convert.ToDateTime(value); break;
                    case "CreateUserId" : _CreateUserId = Convert.ToString(value); break;
                    case "CreateBy" : _CreateBy = Convert.ToString(value); break;
                    case "ModifiedOn" : _ModifiedOn = Convert.ToDateTime(value); break;
                    case "ModifiedUserId" : _ModifiedUserId = Convert.ToString(value); break;
                    case "ModifiedBy" : _ModifiedBy = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得项目字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>李湘Ri齐</summary>
            public static readonly Field LiXiangRiQi = FindByName("LiXiangRiQi");

            ///<summary>柯胡明郑</summary>
            public static readonly Field KeHuMingCheng = FindByName("KeHuMingCheng");

            ///<summary>柯胡湘穆明郑</summary>
            public static readonly Field KeHuXiangMuMingCheng = FindByName("KeHuXiangMuMingCheng");

            ///<summary>柯胡子廖</summary>
            public static readonly Field KeHuZiLiao = FindByName("KeHuZiLiao");

            ///<summary>曲任杜志</summary>
            public static readonly Field QuRenTuZhi = FindByName("QuRenTuZhi");

            ///<summary>曲任洁郭</summary>
            public static readonly Field QuRenJieGuo = FindByName("QuRenJieGuo");

            ///<summary>产品型号</summary>
            public static readonly Field XingHao = FindByName("XingHao");

            ///<summary>启盖Ri齐</summary>
            public static readonly Field KaiGaiRiQi = FindByName("KaiGaiRiQi");

            ///<summary>楚杨Ri齐</summary>
            public static readonly Field ChuYangRiQi = FindByName("ChuYangRiQi");

            ///<summary>可以贾陈水扁郝</summary>
            public static readonly Field BaoJiaBianHao = FindByName("BaoJiaBianHao");

            ///<summary>包头廖陈水扁郝</summary>
            public static readonly Field TouLiaoBianHao = FindByName("TouLiaoBianHao");

            ///<summary>杨针陈水扁郝</summary>
            public static readonly Field YangPinBianHao = FindByName("YangPinBianHao");

            ///<summary>室陈郭郑温家宝Ti</summary>
            public static readonly Field ShiChanGuoChengWenTi = FindByName("ShiChanGuoChengWenTi");

            ///<summary>室陈宗洁</summary>
            public static readonly Field ShiChanZongJie = FindByName("ShiChanZongJie");

            ///<summary>柯胡温家宝Ti</summary>
            public static readonly Field KeHuWenTi = FindByName("KeHuWenTi");

            ///<summary>楚李方一</summary>
            public static readonly Field ChuLiFangAn = FindByName("ChuLiFangAn");

            ///<summary>柯胡楚李庄泰</summary>
            public static readonly Field KeHuChuLiZhuangTai = FindByName("KeHuChuLiZhuangTai");

            ///<summary>柯胡楚李洁郭</summary>
            public static readonly Field KeHuChuLiJieGuo = FindByName("KeHuChuLiJieGuo");

            ///<summary>用户宠物表行政长官室可以高</summary>
            public static readonly Field PETCeShiBaoGao = FindByName("PETCeShiBaoGao");

            ///<summary>用户宠物表行政长官室洁郭</summary>
            public static readonly Field PETCeShiJieGuo = FindByName("PETCeShiJieGuo");

            ///<summary>TG行政长官室可以高</summary>
            public static readonly Field TGCeShiBaoGao = FindByName("TGCeShiBaoGao");

            ///<summary>TG行政长官室洁郭</summary>
            public static readonly Field TGCeShiJieGuo = FindByName("TGCeShiJieGuo");

            ///<summary>FPC行政长官室可以高</summary>
            public static readonly Field FPCCeShiBaoGao = FindByName("FPCCeShiBaoGao");

            ///<summary>FPC行政长官室洁郭</summary>
            public static readonly Field FPCCeShiJieGuo = FindByName("FPCCeShiJieGuo");

            ///<summary>行政长官室可以高</summary>
            public static readonly Field CeShiBaoGao = FindByName("CeShiBaoGao");

            ///<summary>温家宝Ti工业铁损十一严郑</summary>
            public static readonly Field WenTiFenXiYanZheng = FindByName("WenTiFenXiYanZheng");

            ///<summary>审核状态</summary>
            public static readonly Field AuditStatus = FindByName("AuditStatus");

            ///<summary>允许编辑</summary>
            public static readonly Field AllowEdit = FindByName("AllowEdit");

            ///<summary>允许删除</summary>
            public static readonly Field AllowDelete = FindByName("AllowDelete");

            ///<summary>排序号</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否可用</summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary>用户是否删除</summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary>创建上</summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            ///<summary>创建人ID</summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            ///<summary>创建由</summary>
            public static readonly Field CreateBy = FindByName("CreateBy");

            ///<summary>修改日期</summary>
            public static readonly Field ModifiedOn = FindByName("ModifiedOn");

            ///<summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
            public static readonly Field ModifiedUserId = FindByName("ModifiedUserId");

            ///<summary>修改者</summary>
            public static readonly Field ModifiedBy = FindByName("ModifiedBy");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>项目接口</summary>
    public partial interface IProject
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>李湘Ri齐</summary>
        DateTime LiXiangRiQi { get; set; }

        /// <summary>柯胡明郑</summary>
        String KeHuMingCheng { get; set; }

        /// <summary>柯胡湘穆明郑</summary>
        String KeHuXiangMuMingCheng { get; set; }

        /// <summary>柯胡子廖</summary>
        Int32 KeHuZiLiao { get; set; }

        /// <summary>曲任杜志</summary>
        Int32 QuRenTuZhi { get; set; }

        /// <summary>曲任洁郭</summary>
        Int32 QuRenJieGuo { get; set; }

        /// <summary>产品型号</summary>
        String XingHao { get; set; }

        /// <summary>启盖Ri齐</summary>
        DateTime KaiGaiRiQi { get; set; }

        /// <summary>楚杨Ri齐</summary>
        DateTime ChuYangRiQi { get; set; }

        /// <summary>可以贾陈水扁郝</summary>
        String BaoJiaBianHao { get; set; }

        /// <summary>包头廖陈水扁郝</summary>
        String TouLiaoBianHao { get; set; }

        /// <summary>杨针陈水扁郝</summary>
        String YangPinBianHao { get; set; }

        /// <summary>室陈郭郑温家宝Ti</summary>
        String ShiChanGuoChengWenTi { get; set; }

        /// <summary>室陈宗洁</summary>
        String ShiChanZongJie { get; set; }

        /// <summary>柯胡温家宝Ti</summary>
        String KeHuWenTi { get; set; }

        /// <summary>楚李方一</summary>
        Int32 ChuLiFangAn { get; set; }

        /// <summary>柯胡楚李庄泰</summary>
        String KeHuChuLiZhuangTai { get; set; }

        /// <summary>柯胡楚李洁郭</summary>
        String KeHuChuLiJieGuo { get; set; }

        /// <summary>用户宠物表行政长官室可以高</summary>
        Int32 PETCeShiBaoGao { get; set; }

        /// <summary>用户宠物表行政长官室洁郭</summary>
        Int32 PETCeShiJieGuo { get; set; }

        /// <summary>TG行政长官室可以高</summary>
        Int32 TGCeShiBaoGao { get; set; }

        /// <summary>TG行政长官室洁郭</summary>
        Int32 TGCeShiJieGuo { get; set; }

        /// <summary>FPC行政长官室可以高</summary>
        Int32 FPCCeShiBaoGao { get; set; }

        /// <summary>FPC行政长官室洁郭</summary>
        Int32 FPCCeShiJieGuo { get; set; }

        /// <summary>行政长官室可以高</summary>
        Int32 CeShiBaoGao { get; set; }

        /// <summary>温家宝Ti工业铁损十一严郑</summary>
        String WenTiFenXiYanZheng { get; set; }

        /// <summary>审核状态</summary>
        String AuditStatus { get; set; }

        /// <summary>允许编辑</summary>
        Int32 AllowEdit { get; set; }

        /// <summary>允许删除</summary>
        Int32 AllowDelete { get; set; }

        /// <summary>排序号</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否可用</summary>
        Int32 Enabled { get; set; }

        /// <summary>用户是否删除</summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary>描述</summary>
        String Description { get; set; }

        /// <summary>创建上</summary>
        DateTime CreateOn { get; set; }

        /// <summary>创建人ID</summary>
        String CreateUserId { get; set; }

        /// <summary>创建由</summary>
        String CreateBy { get; set; }

        /// <summary>修改日期</summary>
        DateTime ModifiedOn { get; set; }

        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        String ModifiedUserId { get; set; }

        /// <summary>修改者</summary>
        String ModifiedBy { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}