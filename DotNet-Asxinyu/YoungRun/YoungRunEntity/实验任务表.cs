using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>实验任务表</summary>
    [Serializable]
    [DataObject]
    [Description("实验任务表")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_TestTask", Description = "实验任务表", ConnName = "YoungRunST", DbType = DatabaseType.MySql)]
    public partial class tb_TestTask : Itb_TestTask
    
    {
        #region 属性
        private String _ID;
        /// <summary>实验编号</summary>
        [DisplayName("实验编号")]
        [Description("实验编号")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "ID", "实验编号", null, "varchar(20)", 0, 0, false)]
        public String ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _TestTitle;
        /// <summary>实验名称</summary>
        [DisplayName("实验名称")]
        [Description("实验名称")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(2, "TestTitle", "实验名称", null, "varchar(30)", 0, 0, false)]
        public String TestTitle
        {
            get { return _TestTitle; }
            set { if (OnPropertyChanging("TestTitle", value)) { _TestTitle = value; OnPropertyChanged("TestTitle"); } }
        }

        private String _TestType;
        /// <summary>实验类型</summary>
        [DisplayName("实验类型")]
        [Description("实验类型")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "TestType", "实验类型", null, "varchar(20)", 0, 0, false)]
        public String TestType
        {
            get { return _TestType; }
            set { if (OnPropertyChanging("TestType", value)) { _TestType = value; OnPropertyChanged("TestType"); } }
        }

        private String _TestProcedure;
        /// <summary>实验过程</summary>
        [DisplayName("实验过程")]
        [Description("实验过程")]
        [DataObjectField(false, false, false, 300)]
        [BindColumn(4, "TestProcedure", "实验过程", null, "varchar(300)", 0, 0, false)]
        public String TestProcedure
        {
            get { return _TestProcedure; }
            set { if (OnPropertyChanging("TestProcedure", value)) { _TestProcedure = value; OnPropertyChanged("TestProcedure"); } }
        }

        private String _TestResult;
        /// <summary>实验结果</summary>
        [DisplayName("实验结果")]
        [Description("实验结果")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(5, "TestResult", "实验结果", null, "varchar(200)", 0, 0, false)]
        public String TestResult
        {
            get { return _TestResult; }
            set { if (OnPropertyChanging("TestResult", value)) { _TestResult = value; OnPropertyChanged("TestResult"); } }
        }

        private String _Summary;
        /// <summary>总结</summary>
        [DisplayName("总结")]
        [Description("总结")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(6, "Summary", "总结", null, "varchar(200)", 0, 0, false)]
        public String Summary
        {
            get { return _Summary; }
            set { if (OnPropertyChanging("Summary", value)) { _Summary = value; OnPropertyChanged("Summary"); } }
        }

        private DateTime _StartTime;
        /// <summary>开始时间</summary>
        [DisplayName("开始时间")]
        [Description("开始时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(7, "StartTime", "开始时间", null, "datetime", 0, 0, false)]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { if (OnPropertyChanging("StartTime", value)) { _StartTime = value; OnPropertyChanged("StartTime"); } }
        }

        private String _InvolvedPerson;
        /// <summary>参与人员</summary>
        [DisplayName("参与人员")]
        [Description("参与人员")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(8, "InvolvedPerson", "参与人员", null, "varchar(30)", 0, 0, false)]
        public String InvolvedPerson
        {
            get { return _InvolvedPerson; }
            set { if (OnPropertyChanging("InvolvedPerson", value)) { _InvolvedPerson = value; OnPropertyChanged("InvolvedPerson"); } }
        }

        private DateTime _FinishTime;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(9, "FinishTime", "结束时间", null, "datetime", 0, 0, false)]
        public DateTime FinishTime
        {
            get { return _FinishTime; }
            set { if (OnPropertyChanging("FinishTime", value)) { _FinishTime = value; OnPropertyChanged("FinishTime"); } }
        }

        private String _ReportID;
        /// <summary>报告编号</summary>
        [DisplayName("报告编号")]
        [Description("报告编号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(10, "ReportID", "报告编号", null, "varchar(20)", 0, 0, false)]
        public String ReportID
        {
            get { return _ReportID; }
            set { if (OnPropertyChanging("ReportID", value)) { _ReportID = value; OnPropertyChanged("ReportID"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(11, "Remark", "备注", null, "varchar(100)", 0, 0, false)]
        public String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
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
                    case "ID" : return _ID;
                    case "TestTitle" : return _TestTitle;
                    case "TestType" : return _TestType;
                    case "TestProcedure" : return _TestProcedure;
                    case "TestResult" : return _TestResult;
                    case "Summary" : return _Summary;
                    case "StartTime" : return _StartTime;
                    case "InvolvedPerson" : return _InvolvedPerson;
                    case "FinishTime" : return _FinishTime;
                    case "ReportID" : return _ReportID;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToString(value); break;
                    case "TestTitle" : _TestTitle = Convert.ToString(value); break;
                    case "TestType" : _TestType = Convert.ToString(value); break;
                    case "TestProcedure" : _TestProcedure = Convert.ToString(value); break;
                    case "TestResult" : _TestResult = Convert.ToString(value); break;
                    case "Summary" : _Summary = Convert.ToString(value); break;
                    case "StartTime" : _StartTime = Convert.ToDateTime(value); break;
                    case "InvolvedPerson" : _InvolvedPerson = Convert.ToString(value); break;
                    case "FinishTime" : _FinishTime = Convert.ToDateTime(value); break;
                    case "ReportID" : _ReportID = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得实验任务表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>实验编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>实验名称</summary>
            public static readonly FieldItem TestTitle = Meta.Table.FindByName("TestTitle");

            ///<summary>实验类型</summary>
            public static readonly FieldItem TestType = Meta.Table.FindByName("TestType");

            ///<summary>实验过程</summary>
            public static readonly FieldItem TestProcedure = Meta.Table.FindByName("TestProcedure");

            ///<summary>实验结果</summary>
            public static readonly FieldItem TestResult = Meta.Table.FindByName("TestResult");

            ///<summary>总结</summary>
            public static readonly FieldItem Summary = Meta.Table.FindByName("Summary");

            ///<summary>开始时间</summary>
            public static readonly FieldItem StartTime = Meta.Table.FindByName("StartTime");

            ///<summary>参与人员</summary>
            public static readonly FieldItem InvolvedPerson = Meta.Table.FindByName("InvolvedPerson");

            ///<summary>结束时间</summary>
            public static readonly FieldItem FinishTime = Meta.Table.FindByName("FinishTime");

            ///<summary>报告编号</summary>
            public static readonly FieldItem ReportID = Meta.Table.FindByName("ReportID");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>实验任务表接口</summary>
    public partial interface Itb_TestTask
    {
        #region 属性
        /// <summary>实验编号</summary>
        String ID { get; set; }

        /// <summary>实验名称</summary>
        String TestTitle { get; set; }

        /// <summary>实验类型</summary>
        String TestType { get; set; }

        /// <summary>实验过程</summary>
        String TestProcedure { get; set; }

        /// <summary>实验结果</summary>
        String TestResult { get; set; }

        /// <summary>总结</summary>
        String Summary { get; set; }

        /// <summary>开始时间</summary>
        DateTime StartTime { get; set; }

        /// <summary>参与人员</summary>
        String InvolvedPerson { get; set; }

        /// <summary>结束时间</summary>
        DateTime FinishTime { get; set; }

        /// <summary>报告编号</summary>
        String ReportID { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}