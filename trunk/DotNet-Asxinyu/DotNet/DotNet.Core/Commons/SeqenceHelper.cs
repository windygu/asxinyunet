using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Commons
{
    /// <summary>
    /// 编号生成类,根据规则生成编号
    /// </summary>
    public class SeqenceHelper
    {
        
    }

    /// <summary>
    /// 编号单元设置,第一个版本
    /// </summary>
    public class SeqUnitSetting
    {
        /// <summary>
        /// 单元名称,就是显示出来的固定字符
        /// </summary>
        public string UnitName{get ;set ;}
        /// <summary>
        /// 单元长度
        /// </summary>
        public int UnitLength { get; set; }
        /// <summary>
        /// 是否启用左填充，就是长度不够，是否在左边填充字符串
        /// </summary>
        public bool IsFillLeft { get; set; }
        /// <summary>
        /// 如果位数不够，左边的填充字符
        /// </summary>
        public char FillChar { get; set; }
        /// <summary>
        /// 单元格之间的分割字符,比如-
        /// </summary>
        public char SpliteChar { get; set; }
        /// <summary>
        /// 如果单元是利用当前系统时间，则UnitName为系统时间格式，如"yyyyMMdd","yyMMddHHmmss"等，就是格式化时间用的
        /// </summary>
        public bool IsDateTimeFormate { get; set; }
        private int SquenceNumber;
        /// <summary>
        /// 是不是流水号单元,流水号是最后一个单元，一般是编号的，比如001 002 003,如果是流水号单元,那么UnitName就是空值
        /// </summary>
        public bool IsSequenceUnit { get; set; }

        public SeqUnitSetting (string unitName,int unitLength,bool isDateTimeFormate = false ,bool isSequenceUnit = false ,
                               bool isFillLeft = true,char fillChar ='0',char spliteChar='-')
        {
            this.UnitName = unitName ;
            this.IsDateTimeFormate = isDateTimeFormate ;
            this.UnitLength = unitLength ;
            this.IsFillLeft = isFillLeft ;
            this.FillChar = fillChar ;
            this.SpliteChar = spliteChar ;
            this.IsSequenceUnit = isSequenceUnit ;
            this.SquenceNumber = 1;
            this.CurrentSquenceString = GetString();            
        }
        /// <summary>
        /// 获取当前单元的代码
        /// </summary>
        public string CurrentSquenceString;
        /// <summary>
        /// 专门用于获取流水号单元的，GetString()只能获取第一次的流水号
        /// </summary>
        /// <returns></returns>
        public string GetCurrentSerialNumber()
        {
            return (IsFillLeft ? (this.SquenceNumber++).ToString().PadLeft(UnitLength, FillChar) : (this.SquenceNumber++).ToString());
        }
        /// <summary>
        /// 流水号,默认为1开始，通过指定位数和填充来生成流水号
        /// </summary>
        private string GetString()
        {
            //先判断是不是 流水号单元 ,流水号单元后面没有分隔符
            if (IsSequenceUnit ) 
                return  (IsFillLeft ? (this.SquenceNumber ++).ToString ().PadLeft (UnitLength ,FillChar):(this.SquenceNumber ++).ToString ());
            else 
            {
                //再判断是不是日期类型的单元
                if(IsDateTimeFormate )                
                    return (IsFillLeft ? DateTime.Now.ToString (UnitName ).PadLeft (UnitLength,FillChar ):DateTime.Now.ToString (UnitName))+SpliteChar ;                
                else 
                    return (IsFillLeft ? UnitName.PadLeft (UnitLength,FillChar ):UnitName) +SpliteChar ;
            }
        }
    }
}
