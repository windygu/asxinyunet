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
    /// 规则类，增加数据参数类：将上下限，等参数放到一个类中，一个对象
    /// </summary>
    [Serializable]
    public class RuleInfo
    {
        #region 计算所需要的期数N
        /// <summary>
        /// 每一次计算所需要的行数
        /// </summary>
        public int NumbersCount { get; set; }
        #endregion

        #region 是否是验证模式
        /// <summary>
        /// 是否是验证模式,默认true
        /// </summary>
        public bool IsValidateMode { get; set; }
        #endregion

        #region 指标函数类型及名称
        /// <summary>
        /// 当前规则中的指标类型,通过IndexSelectorName的方法名称来识别
        /// </summary>
        public IndexType CurIndexType { get; set; }
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
                if (value.Contains("Index_OO")) CurIndexType = IndexType.OO;
                else if (value.Contains("Index_MM")) CurIndexType = IndexType.MM;
                else if (value.Contains("Index_MO")) CurIndexType = IndexType.MO;
                else if (value.Contains("Index_OM")) CurIndexType = IndexType.OM;
                else if (value.Contains("Static_S")) CurIndexType = IndexType.Specail;//特殊验证和过滤的名字相同
                else CurIndexType = IndexType.None;
            }
        }
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

        #region 参数对象
        /// <summary>
        /// 规则比较参数
        /// </summary>
        public RuleCompareParams RuleParams { get; set; }
        #endregion

        #region 通用构造函数,常用,传入字符串，并转换为类型
        /// <summary>
        /// 通用构造函数
        /// </summary>
        /// <param name="selector">指标计算函数</param>
        /// <param name="compareRule">对比规则</param>
        /// <param name="needRows">计算所需的行数</param>
        public RuleInfo(RuleCompareParams ruleParams,string selector, string compareRule,
            bool isValidate = true ,int needRows = 1 )
        {
            this.IsValidateMode = isValidate;
            this.RuleParams = ruleParams;            
            this.NumbersCount = needRows;            
            this.IndexSelectorName = selector;
            this.CompareRuleName = compareRule;  
        }           
        #endregion           
    }

    /// <summary>
    /// 规则比较参数类
    /// </summary>
    [Serializable]
    public class RuleCompareParams
    {
        #region 范围比较参数
        /// <summary>
        /// 下限
        /// </summary>
        public int FloorLimit { get; set; }
        /// <summary>
        /// 上限
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
                if (value != null && value != "")
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

        /// <summary>
        /// 特殊模式下的参数
        /// </summary>
        public string ParamsValue { get; set; }
        #endregion           
        
        #region 构造函数---特殊模式时,参数就只给一个
        /// <summary>
        /// 构造函数，字符串格式：**-**-*,*,*-**,**
        /// </summary>
        /// <param name="conditons">参数条件字符串,安装指定格式</param>
        public RuleCompareParams(string conditons,bool isSpecialMode = false )
        {
            if (isSpecialMode)//特殊模式
            {
                this.ParamsValue = conditons ;
            }
            else
            {
                if (conditons != null && conditons != "")
                {
                    string[] str = conditons.Split('-');
                    if (str.Length == 1) this.FloorLimit = Convert.ToInt32(str[0]);
                    if (str.Length == 2)
                    {
                        this.FloorLimit = Convert.ToInt32(str[0]);
                        this.CeilLimit = Convert.ToInt32(str[1]);
                    }
                    if (str.Length == 3)
                    {
                        this.FloorLimit = Convert.ToInt32(str[0]);
                        this.CeilLimit = Convert.ToInt32(str[1]);
                        this.CompListStr = str[2];
                    }
                    if (str.Length == 4)
                    {
                        this.FloorLimit = Convert.ToInt32(str[0]);
                        this.CeilLimit = Convert.ToInt32(str[1]);
                        this.CompListStr = str[2];
                        this.ParamsValue = str[3];
                    }
                }
            }
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

    #region 指标类别枚举
    public enum IndexType
    {
        /// <summary>
        /// 单期数据1个结果
        /// </summary>
        OO ,
        /// <summary>
        /// 多期数据，多个结果
        /// </summary>
        MM ,
        /// <summary>
        /// 多期数据，一个结果
        /// </summary>
        MO ,
        /// <summary>
        /// 单期数据，多个结果
        /// </summary>
        OM ,
        /// <summary>
        /// 其他特殊的
        /// </summary>
        Specail ,
        /// <summary>
        /// 空的，未指定
        /// </summary>
        None 
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
                for (int i = 0; i < s1.Length; i++)
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
            for (int i = 0; i < s.Length - 1; i++)
            {
                res += (s[i].ToString() + ",");
            }
            res += s[s.Length - 1].ToString();
            return res;
        }
        #endregion

        #region 获取邻号出现的个数
        /// <summary>
        /// 获取上期的邻号在当前期出现的个数
        /// </summary>
        /// <param name="source">本期数据</param>
        /// <param name="LastSouce">上期数据或者指定期数据</param>
        /// <returns>上期邻号在本期出现的个数</returns>
        public static int Index_上期邻号出现个数(this IEnumerable<int> source, IEnumerable<int> LastSouce)
        {
            int count = 0;
            double temp = 0;
            foreach (int item in source)
            {
                foreach (int cur in LastSouce)
                {
                    temp = Math.Abs(item - cur);
                    if (temp == 1 || temp == 32) count++;
                }
            }
            return count;
        }
        #endregion

        #region 获取2个序列的重复号码个数
        /// <summary>
        /// 获取2个序列的重复号码个数
        /// </summary>
        /// <returns>返回重复号码的个数</returns>
        public static int Index_S2个序列的重复号码个数(this IEnumerable<int> source, IEnumerable<int> compareSouce)
        {
            int count = 0;
            foreach (int item in source)
            {
                foreach (int s in compareSouce)
                {
                    if (item == s) { count++; break; }
                    if (item < s) { break; }//后面的已经比其越来越大了
                }
            }
            return count;
        }
        #endregion

        #region 统计次数与频率-多对多
        /// <summary>
        /// 计算在所有当前数据中，号码出现的频率(百分比)
        /// </summary>
        public static double[] Index_S号码频率(this IEnumerable<int[]> source, int maxNumber = 33)
        {
            //先从最后一列找出最大值,确定出现的最大数字
            int[] numbers = new int[maxNumber];
            foreach (var item in source)
            {
                foreach (var s in item)
                {
                    numbers[s + 1]++;
                }
            }
            int allNumbers = numbers.Sum();
            return numbers.Select(n => ((double)n) / ((double)allNumbers)).ToArray();
        }
        #endregion

        #region 跨度列表-1对多--验证和过滤已完成
        /// <summary>
        /// 计算跨度列表
        /// </summary>
        public static int[] Index_SP跨度列表(this int[] source)
        {
            int[] res = new int[source.Length];
            for (int i = 0; i < source.Length - 1; i++)
            {
                res[i] = source[i + 1] - source[i];
            }
            return res;
        }
        #endregion        
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
        
        #region 获取所有的方法类型和比较类型
        /// <summary>
        /// 加入OM,特殊验证方法,其他指标的名字，通过前缀区分来区分
        /// </summary>
        public static List<string> GetAllIndexFuncNames()
        {
            List<string> index =(typeof(OOIndexCalculate)).GetMethods().Select(n => n.Name)
                .Where(n => n.Contains("Index_OO")).ToList();
            List<string> index_MM = (typeof(MMIndexCalculate)).GetMethods().Select(n => n.Name)
                .Where(n => n.Contains("Index_MM")).ToList();
            List<string> index_MO = (typeof(MOIndexCalculate)).GetMethods().Select(n => n.Name)
                .Where(n => n.Contains("Index_MO")).ToList();
            List<string> index_OM = (typeof(OMIndexCalculate)).GetMethods().Select(n => n.Name)
          .Where(n => n.Contains("Index_OM")).ToList();
            List<string> index_S = (typeof(OtherIndexStatic)).GetMethods().Select(n => n.Name)
      .Where(n => n.Contains("Static_S")).ToList(); 
            index.AddRange(index_MM);
            index.AddRange(index_MO);
            index.AddRange(index_OM);
            index.AddRange(index_S);
            return index;
        }

        public static string GetClassNameByIndexName(string indexName)
        {
            if (indexName.Contains("Index_OO")) return "OOIndexCalculate";
            if (indexName.Contains("Index_MM")) return "MMIndexCalculate";
            if (indexName.Contains("Index_MO")) return "MOIndexCalculate";
            if (indexName.Contains("Index_OM")) return "OMIndexCalculate";
            if (indexName.Contains("Static_S")) return "OtherIndexStatic";
            return "None";
        }

        /// <summary>
        /// 获取枚举类型的所有枚举值
        /// </summary>
        public static List<string> GetAllEnumNames<T>()
        {
            return Enum.GetNames(typeof(T)).ToList();
        }
        #endregion            

        #region 根据表格显示的规则进行计算和过滤，并显示结果
        //计算当期规则
        public static void CalculateCurrentRow(DataGridView dgv,int defaultHisDataCount = 1000)
        {
            int rowIndex = dgv.CurrentRow.Index;            
            //先得到一个tb_Rules对象,直接从数据库读取就OK了,因为是实时更新
            tb_Rules ruleMode = tb_Rules.FindById((int)dgv.Rows[rowIndex].Cells[0].Value);
            //再根据ruleMode判断规则类别，调用相应的方法进行计算            
            int[][] data = TwoColorBall.GetRedBallData(defaultHisDataCount);
            dgv.Rows[rowIndex].Cells[5].Value = GetDgvCalculateResult(data ,ruleMode );
        }
        //计算所有期规则
        public static void CalculateAllRows(DataGridView dgv, int defaultHisDataCount = 1000)
        {
            int[][] data = TwoColorBall.GetRedBallData(defaultHisDataCount);
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {               
                //先得到一个tb_Rules对象,直接从数据库读取就OK了,因为是实时更新
                tb_Rules ruleMode = tb_Rules.FindById((int)dgv.Rows[rowIndex].Cells[0].Value);
                //再根据ruleMode判断规则类别，调用相应的方法进行计算                            
                dgv.Rows[rowIndex].Cells[5].Value = GetDgvCalculateResult(data, ruleMode);
            }
        }
        static string GetDgvCalculateResult(int[][] data,tb_Rules ruleMode)
        {           
            //再根据ruleMode判断规则类别，调用相应的方法进行计算                       
            RuleCompareParams ruleParams = new RuleCompareParams(ruleMode.RuleCompareParams);//参数
            RuleInfo rule = new RuleInfo(ruleParams, ruleMode.IndexSelectorNameTP, ruleMode.CompareRuleNameTP,true ,ruleMode.DataRows );
            double res = data.Static_单个指标频率(rule);
            return (res * 100).ToString("F4");            
        }
        #endregion

        #region 交叉验证
        public static double CrossValidateRules(DataGridView dgv, int defaultHisDataCount = 1000)
        {
            int[][] data = TwoColorBall.GetRedBallData(defaultHisDataCount);
            //交叉验证,对OO类型的规则进行交叉验证，结果显示在下方状态栏中间
            RuleInfo[] rules = new RuleInfo[dgv.Rows.Count];
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                //先得到一个tb_Rules对象,直接从数据库读取就OK了,因为是实时更新
                tb_Rules ruleMode = tb_Rules.FindById((int)dgv.Rows[rowIndex].Cells[0].Value);
                //再根据ruleMode判断规则类别，调用相应的方法进行计算                            
                RuleCompareParams ruleParams = new RuleCompareParams(ruleMode.RuleCompareParams);//参数
                rules[rowIndex ] = new RuleInfo(ruleParams, ruleMode.IndexSelectorNameTP, ruleMode.CompareRuleNameTP, true,ruleMode.DataRows);
            }
            //每一期 验证所有规则，都通过算一次
            int sum = 0;
            for (int i = 0; i < data.GetLength (0); i++)
            {
                bool flag = true ;
                for (int j = 0; j < rules.Length ; j++)
                {
                    if (rules[j ].CurIndexType == IndexType.OO )
                    {
                        var selector = (Func<int[], int>)Delegate.CreateDelegate(typeof(Func<int[], int>),
                            typeof(OOIndexCalculate ).GetMethod (rules[j].IndexSelectorName ));
                        bool res = StatisticalFilter.GetCompareResult (selector (data[i]),rules[j]);
                        if (!res)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if(flag )  sum++;
            }
            double result = ((double )sum) /((double )data.GetLength (0));
            return result;
        }
        #endregion

        #region 过滤处理,从头开始，对所有规则进行过滤--直接计算所有行
        public static void FilterAllRows(DataGridView dgv, int[][] InitiaData)
        {
            //测试期间只考虑单独指标计算的情况
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                //先得到一个tb_Rules对象,直接从数据库读取就OK了,因为是实时更新              
                tb_Rules ruleMode = tb_Rules.FindById((int)dgv.Rows[rowIndex].Cells[0].Value);
                //再根据ruleMode判断规则类别，调用相应的方法进行计算                      
                RuleCompareParams ruleParams = new RuleCompareParams(ruleMode.RuleCompareParams);//参数
                RuleInfo rule = new RuleInfo(ruleParams, ruleMode.IndexSelectorNameTP, ruleMode.CompareRuleNameTP,true,ruleMode.DataRows);
                int count1 = InitiaData.Count();
                InitiaData = InitiaData.Filter_范围过滤(rule);
                int count2 = InitiaData.Count();
                dgv.Rows[rowIndex].Cells[6].Value = string.Format("{0}-{1}={2}", count1, count1 - count2, count2);
            }
        }
        public static int[][] GetInitiaData()
        {
            int[] data = new int[33];
            //初始化
            for (int i = 0; i < data.Length; i++) { data[i] = i + 1; }
            //迭代获取所有组合序列,并对每个序列进行判断         
            return new Combination(data.Length, 6).Rows.Select(n => n.ToArray()).ToArray ();
        }

        #endregion
    } 
    #endregion
}