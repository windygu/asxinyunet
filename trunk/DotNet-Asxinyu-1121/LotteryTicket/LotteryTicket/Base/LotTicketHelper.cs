#region
/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-11-17
 * 时间: 16:08
 * 
 * 
 */
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using DotNet.Tools;
using System.Data;
using Kw.Combinatorics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
#endregion

namespace LotteryTicket
{
    #region 规则类，设置规则及比较参数
    /// <summary>
    /// 规则类
    /// </summary>
    [Serializable]
    public class Rule
    {
        #region 规则类型及模式
        /// <summary>
        /// 是否是1对1常规类型
        /// </summary>
        public bool IsOO { get; set; }

        /// <summary>
        /// 是否是特殊模式,此模式下,其他参数设置无效,只接受特殊参数数组
        /// </summary>
        public bool IsSpecialMode { get; set; }
        /// <summary>
        /// 特殊模式下的参数
        /// </summary>
        public object[] ParamsValues { get; set; }                
        #endregion

        #region MO类型时的计算期数N
        public int NumbersCount { get; set; }
        #endregion

        #region 指标函数委托及名称
        string _indexSelectorName;
        /// <summary>
        /// 指标函数的名称
        /// </summary>
        public string IndexSelectorName
        {
            get { return _indexSelectorName; }
            set
            {
                _indexSelectorName = value;
                if (IsOO)
                {
                    Type t = typeof(OOIndexCalculate);
                    MethodInfo cur = t.GetMethod(value);
                    OOSelector = (Func<int[], int>)Delegate.CreateDelegate(typeof(Func<int[], int>), cur);
                }
                else
                {
                    Type t = typeof(MOIndexCalculate);
                    MethodInfo cur = t.GetMethod(value);
                    MOSelector = (Func<int[][], int>)Delegate.CreateDelegate(typeof(Func<int[][], int>), cur);
                }
            }
        }
        /// <summary>
        /// 指标计算函数
        /// </summary>
        public System.Func<int[], int> OOSelector { get; set; }
        public System.Func<int[][], int> MOSelector { get; set; }
        #endregion

        #region 比较类型及名称
        private string _compareRuleName;
        /// <summary>
        /// 比较的类型名称
        /// </summary>
        public string CompareRuleName
        {
            get { return _compareRuleName; }
            set
            {
                _compareRuleName = value;
                CompareRule = value.ToEnum<CompareType>();
            }
        }
        /// <summary>
        /// 对比类型
        /// </summary>
        public CompareType CompareRule { get; set; }
        #endregion

        #region 范围比较参数
        /// <summary>
        /// 上限
        /// </summary>
        public int FloorLimit { get; set; }
        /// <summary>
        /// 下限
        /// </summary>
        public int CeilLimit { get; set; }

        //比较序列的字符串形式
        string _compListStr;
        /// <summary>
        /// 比较序列的字符串形式，逗号分隔
        /// </summary>
        public string CompListStr
        {
            get { return _compListStr; }
            set
            {
                if (value !=null && value !="")
                {
                    _compListStr = value;
                    CompList = value.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                }               
            }
        }
        /// <summary>
        /// 比较序列
        /// </summary>
        public int[] CompList { get; set; }
        #endregion           

        #region OO与MO通用构造函数,常用,传入字符串，并转换为类型
        /// <summary>
        /// 通用构造函数
        /// </summary>
        /// <param name="selector">指标计算函数</param>
        /// <param name="compareRule">对比规则</param>
        /// <param name="compList">对比序列,默认为空</param>
        /// <param name="isOO">是否是1对1类型</param>
        /// <param name="needRows">计算所需的函数,OO为0，MO需要设置</param>
        /// <param name="floorlimit">范围下限</param>
        /// <param name="ceilLimit">范围上限</param>
        public Rule(string selector, string compareRule,string compList ="",bool isOO = true ,
            int needRows = 0 ,int floorlimit = 0, int ceilLimit = 0)
        {
            this.IsSpecialMode = false;//默认为非特殊模式,也就是正常模式
            this.NumbersCount = needRows;
            this.IsOO = isOO;
            this.IndexSelectorName = selector;
            this.CompareRuleName = compareRule;
            this.FloorLimit = floorlimit;
            this.CeilLimit = ceilLimit;
            this.CompListStr = compList;
        }
        /// <summary>
        /// 特殊模式构造函数，直接传入参数数组即可
        /// </summary>
        /// <param name="selector">特殊模式下对应的方法名称</param>
        /// <param name="paramsValues">参数</param>
        public Rule(string selector, object[] paramsValues)
        {
            this._indexSelectorName = selector;
            this.IsSpecialMode = true;

        }
        #endregion       
    }
    #endregion

    #region 比较类型枚举
    /// <summary>
    /// 比较类型
    /// </summary>
    public enum CompareType
    {
        /// <summary>
        /// 相等匹配
        /// </summary>
        Equal,

        /// <summary>
        /// 一定范围内,上下限:[a,b]
        /// </summary>
        RangeLimite,

        /// <summary>
        /// 小于或等于
        /// </summary>
        LessThanLimite,

        /// <summary>
        /// 大于或等于
        /// </summary>
        GreaterThanLimite,

        /// <summary>
        /// 包含在列表中
        /// </summary>
        InList,
        /// <summary>
        /// 不包含在列表中
        /// </summary>
        NotInList
    }
    #endregion

    #region 彩票类型基类
    public class BaseLotTickClass
    {
        public LotTickType lotTickType;//彩票类型
        public string lotTickName;     //彩票名称
        public string lotTickRemark;   //彩票说明，比如规则
        public int allBallNumber;      //开奖总球个数
        public int RedBallNumber;      //开奖红球个数
        public int BlueBallNumber;     //开奖蓝球个数
        public int RedNumRangeLimite;  //红球范围上限，下限根据类型，从1或者0开始
        public int BlueNumRangeLimite; //蓝球范围上限	
        public int[][] LotTickDatas;    //彩票数据
        public int[][] redlotTickNoAfterFilt;//过滤期号和日期后的数据号码		
        //过滤到期号及日期，得到处理前的数据
        //考虑增加一个控制开关和属性，可以动态调整计算的期数
        //比如，只计算最近的50期的和值，但是计算所有期的数字频率
        public bool IsAllDataUsed = true;//是否计算所有数据,默认为true
        public int CurrentDataNumbers; //当前所计算的数据期数，最近		
    }
    #endregion

    #region 接口和基类
    /// <summary>
    /// 获取网络彩票数据接口
    /// </summary>
    interface IGetWebLotTickData
    {
        void GetAllHistoryData(int pages = -1);//获取所有历史数据，自动计算所有页面的总数
        void UpdateRecentData(int pages = 1);//更新最新数据,默认为一页
    }

    /// <summary>
    /// 获取彩票数据类基类
    /// </summary>
    public class BaseGetLotTicData
    {

    }
    #endregion

    #region 彩票类型枚举
    /// <summary>
    /// 彩票类型
    /// </summary>
    public enum LotTickType
    {
        /// <summary>
        /// 排列型,如32选5，选出几个数字，没有顺序
        /// </summary>
        Range,

        /// <summary>
        /// 数字型,如3D，选出一个整数，号码不能变顺序
        /// </summary>
        Number
    }
    #endregion

    #region LotTicketHelper 帮助类
    /// <summary>
    /// 项目常规帮助类
    /// </summary>
    public static class LotTicketHelper
    {
        #region 公共方法---获得正确率
        /// <summary>
        /// 统计bool数组中True的比例,即正确率
        /// </summary>
        public static double GetRateReuslt(bool[] result)
        {
            int sum = result.Where(n => n == true).Count();
            return ((double)sum) / ((double)result.Length);
        }
        #endregion
            
        #region 生成文件名和验证文件是否合法
        /// <summary>
        /// 验证文件是否合法
        /// </summary>
        /// <param name="filePath">文件全路径名称:根据名称和内容验证其合法性</param>
        /// <returns>True 合法文件 ; False 非法文件</returns>
        public static bool FileValidation(string filePath)
        {
            //TODO:需要设计相应的规则,并在生成时就确定
            return true;
        }

        /// <summary>
        /// 根据原始规则文件名以及其他信息得到合法的最终文件名
        /// </summary>
        /// <param name="origFilePath">原始的临时文件</param>
        /// <returns >合法的文件名</returns>
        public static string GetRigthFileName(string origFilePath)
        {
            //TODO:加密,根据硬件、时间、以及规则来生成
            return "";
        }
        #endregion
                
        #region 验证实际预测结果的收获
        /// <summary>
        /// 验证实际预测结果的收获
        /// </summary>
        /// <param name="dataFilePath">实际预测文件路径名称</param>
        /// <param name="prizedata">实际中奖数据</param>
        /// <returns>实际收益(按照所有预测文件单注计算)</returns>
        //public static double ValidatePrizes(string dataFilePath, double[] prizedata)
        //{
        //    //TODO:循环数据 与 正确号码进行对比,确定奖等级
        //    //直接调用彩票类的兑奖计算
        //    double[][] data = GetPredictDataFormFile(dataFilePath);
        //    return TwoColorBall.GetAllPrizeReward(prizedata, data);
        //}

        /// <summary>
        /// 验证实际预测结果的收获
        /// </summary>
        /// <param name="dataFilePath">实际预测文件路径名称</param>
        /// <param name="prizedata">实际中奖数据</param>
        /// <returns>实际收益(按照所有预测文件单注计算)</returns>
        //public static double ValidatePrizes(double[][] predictData, double[] prizedata)
        //{
        //    return TwoColorBall.GetAllPrizeReward(prizedata, predictData);
        //}
        #endregion

        #region 过滤处理
        /// <summary>
        /// 生成双色球全部数据,默认过滤指标：3连号及以上、和值、跨度
        /// </summary>
        /// <param name="fileName">最终号码存储的文件名</param>
        public static List<double[]> InitialFilterData(double[] deleteNumbers, int latestNos = 5, int repeatNumbers = 2)
        {
            double[] data = new double[33];//初始化所有号码
            List<double> listNumbers = new List<double>();
            //初始化
            for (int i = 0; i < data.Length; i++) { listNumbers.Add((double)(i + 1)); }
            //杀号处理
            for (int i = 0; i < deleteNumbers.Length; i++) { listNumbers.Remove(deleteNumbers[i]); }
            //迭代获取所有组合序列,并对每个序列进行判断
            List<double[]> res = new List<double[]>();
            foreach (Combination combom in new Combination(data.Length, 6).Rows)
            {
                double[] curComb = Combination.Permute(combom, data).ToArray();
                //杀组合，参数为最近的期数和最大重复数,也可以单独杀
                if (latestNos > 0) //最近的期数
                {
                    //先获取需要杀号的数据
                    bool temp = true;
                    double[][] deleteNos = TwoColorBall.GetRedBallData(latestNos);
                    for (int i = 0; i < deleteNos.GetLength(0); i++)
                    {
                        //if (IndexCalculate.GetRepeatNumbers(curComb, deleteNos[i]) >= repeatNumbers)
                        //{
                        //    temp = false;
                        //    break;
                        //}
                    }
                    if (temp) res.Add(curComb);//符合要求则添加
                }
            }
            return res;
        }
        #endregion

        #region XML序列化
        /// <summary>
        /// 读取XML文件，反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <param name="fileName">xml文件名</param>
        /// <returns>反序列化的对象</returns>
        public static T ReadXMLFileToType<T>(string xmlFileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read);
            return (T)ser.Deserialize(fileStream);
        }

        /// <summary>
        /// 序列化对象，保存为XML文件，前缀为空
        /// </summary>
        /// <param name="t">对象类型</param>
        /// <param name="s">对象序列化后的Xml文件</param>
        public static void SaveTypeToXmlFile<T>(T t, string xmlFile)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(xmlFile, FileMode.Create, FileAccess.Write);
            ser.Serialize(fileStream, t);
            fileStream.Close();
        }
        #endregion

        #region 二进制序列化
        /// <summary>
        /// 二进制序列化,将对象保存为文件
        /// </summary>
        private static void BinarySerialize<T>(T t,string fileName)
        {            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Create(fileName );
            formatter.Serialize(fileStream, t);
            fileStream.Close();
        }
        /// <summary>
        /// 二进制反序列化,将文件读取为对象
        /// </summary>
        private static T BinaryDeserialize<T>(string fileName)
        {
            BinaryFormatter derializer = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName , FileMode.Open, FileAccess.Read, FileShare.Read);
            T t = (T )derializer.Deserialize(fileStream);          
            fileStream.Close();
            return t;
        }
        #endregion

        #region 将Rule数组转换为DataTable显示,并可编辑
        public static DataTable RulesToDataTable(Rule[] rules)
        {
            DataTable dt = new DataTable("Rules");
            dt.Columns.Add(new DataColumn("序号", typeof(Int32)));
            dt.Columns.Add(new DataColumn("指标函数", typeof(string)));
            dt.Columns.Add(new DataColumn("对比类型", typeof(CompareType)));
            dt.Columns.Add(new DataColumn("范围下限", typeof(Int32)));
            dt.Columns.Add(new DataColumn("范围上限", typeof(Int32)));
            dt.Columns.Add(new DataColumn("列表范围", typeof(int[])));
            int count = 0;
            foreach (Rule item in rules)
            {
                DataRow dr = dt.NewRow();
                dr[0] = ++count;
                dr[1] = item.IndexSelectorName;
                dr[2] = item.CompareRule;
                dr[3] = item.FloorLimit;
                dr[4] = item.CeilLimit;
                dr[5] = item.CompList;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region 获取所有的方法类型和比较类型
        public static List<string> GetAllIndexNames()
        {
            Type t = typeof(OOIndexCalculate);
            MethodInfo[] methods = t.GetMethods();
            List<string> res = new List<string>(methods.Length);
            foreach (MethodInfo item in methods)
            {
                res.Add(item.Name);
            }
            return res;
        }

        /// <summary>
        /// 获取枚举类型的所有枚举值
        /// </summary>
        public static List<string> GetAllEnumNames<T>()
        {
            Type t = typeof(T);
            List<string> list = new List<string>();
            foreach (string s in Enum.GetNames(t))
            {
                list.Add(s);
            }
            return list;
        }
        #endregion
                       
        #region 将Rule数组转换为DataTable显示,并实时计算，保存
        /// <summary>
        /// 将规则类数组转换为DataGridView，便于编辑
        /// </summary>
        public static void RulesToDgv(LotteryTicket.Rule[] rules, DataGridView dgv)
        {
            DataGridViewTextBoxColumn tb = new DataGridViewTextBoxColumn();
            tb.Name = "序号";
            tb.ValueType = typeof(int);
            tb.Width = 80;
            dgv.Columns.Add(tb);

            DataGridViewComboBoxColumn comb = new DataGridViewComboBoxColumn();
            comb.Name = "指标函数";
            comb.Width = 180;
            comb.ValueType = typeof(string);
            comb.DataSource = LotTicketHelper.GetAllIndexNames().Where(n => n.Contains("Index_")).ToList();
            dgv.Columns.Add(comb);

            DataGridViewComboBoxColumn comb2 = new DataGridViewComboBoxColumn();
            comb2.Name = "对比类型";
            comb2.Width = 160;
            comb2.ValueType = typeof(string);
            comb2.DataSource = LotTicketHelper.GetAllEnumNames<CompareType>();
            dgv.Columns.Add(comb2);

            DataGridViewTextBoxColumn tb2 = new DataGridViewTextBoxColumn();
            tb2.Name = "下限";
            tb2.Width = 80;
            tb2.ValueType = typeof(int);
            dgv.Columns.Add(tb2);

            DataGridViewTextBoxColumn tb3 = new DataGridViewTextBoxColumn();
            tb3.Name = "上限";
            tb3.Width = 80;
            tb3.ValueType = typeof(int);
            dgv.Columns.Add(tb3);

            DataGridViewTextBoxColumn tb4 = new DataGridViewTextBoxColumn();
            tb4.Name = "列表范围";
            tb4.Width = 200;
            tb4.ValueType = typeof(string);
            dgv.Columns.Add(tb4);

            DataGridViewTextBoxColumn tb5 = new DataGridViewTextBoxColumn();
            tb5.Name = "概率值";
            tb5.Width = 80;
            tb5.ValueType = typeof(string);
            dgv.Columns.Add(tb5);

            dgv.Rows.Add(rules.Length);
            for (int i = 0; i < rules.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = i + 1;
                dgv.Rows[i].Cells[1].Value = rules[i].IndexSelectorName;
                dgv.Rows[i].Cells[2].Value = rules[i].CompareRuleName;
                dgv.Rows[i].Cells[3].Value = rules[i].FloorLimit;
                dgv.Rows[i].Cells[4].Value = rules[i].CeilLimit;
                dgv.Rows[i].Cells[5].Value = rules[i].CompListStr;
            }
        }        
        #endregion

        #region 根据配置文件的规则,对历史数据进行计算，并显示结果
        //计算当期规则
        public static void CalculateCurrent(int[][] data, DataGridView dgv)
        {
            //int rowIndex = dgv.CurrentRow.Index;
            //LotteryTicket.Rule cutRule = new LotteryTicket.Rule((string)dgv.Rows[rowIndex].Cells[1].Value,
            //    (string)dgv.Rows[rowIndex].Cells[2].Value, (string)dgv.Rows[rowIndex].Cells[5].Value,
            //    (int)dgv.Rows[rowIndex].Cells[3].Value, (int)dgv.Rows[rowIndex].Cells[4].Value);
            //double res = data.Static_单个指标频率(cutRule);
            //dgv.Rows[rowIndex].Cells[6].Value = (res * 100).ToString("F4");
        }
        //计算所有期规则
        public static void CalculateAllRules(int[][] data, DataGridView dgv)
        {
            //for (int i = 0; i < dgv.Rows.Count; i++)
            //{
            //    LotteryTicket.Rule cutRule = new LotteryTicket.Rule((string)dgv.Rows[i].Cells[1].Value,
            //   (string)dgv.Rows[i].Cells[2].Value, (string)dgv.Rows[i].Cells[5].Value,
            //   (int)dgv.Rows[i].Cells[3].Value, (int)dgv.Rows[i].Cells[4].Value);
            //    double res = data.Static_单个指标频率(cutRule);
            //    dgv.Rows[i].Cells[6].Value = (res * 100).ToString("F4");
            //}
        }
        #endregion
    }
    #endregion

    #region 常规的扩展方法类
    public static class ExtendsExpress
    {
        #region 扩展方法
        /// <summary>
        /// 根据字符串获取指定类型的枚举值
        /// </summary>
        public static T ToEnum<T>(this string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
       
        public static bool IsNullEmpty(this IEnumerable source)
        {
            if (source == null) return true;
            foreach (var item in source)
                return false;
            return true;
        }
        /// <summary>
        /// 将对象转换为DataTable
        /// </summary>
        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            colType = colType.GetGenericArguments()[0];
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        #endregion

        #region 比较2个序列是否相等
        public static bool IsEqual<T>(this IEnumerable<T> source, IEnumerable<T> compList) where T : IComparable 
        {
            if (source.Count() != compList.Count()) return false;
            else
            {
                T[] s1 = source.ToArray();
                T[] s2 = source.ToArray();
                for (int i = 0; i < s1.Length ; i++)
                {
                    if (s1[i].CompareTo(s2[i]) != 0) return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 将数组转换为字符串序列,通过逗号拼接
        /// </summary>
        public static string ListToString<T>(this IEnumerable<T> source) 
        {
            string res = "";
            T[] s = source.ToArray();
            for (int i = 0; i < s.Length -1; i++)
            {
                res += (s [i].ToString ()+",");
            }
            res += s[s.Length - 1].ToString();
            return res;
        }
        #endregion
    }
    #endregion
}