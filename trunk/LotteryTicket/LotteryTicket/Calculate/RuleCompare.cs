/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-18
 * Time: 23:33
 * 
 * 号码过滤
 */
using System;
using System.Reflection ;
using System.Collections;

namespace LotteryTicket
{
	/// <summary>
	/// 过滤规则类型枚举
	/// </summary>
	public enum FilterRuleType
	{
		/// <summary>
		/// 相等匹配:只匹配队列中一种即可
		/// </summary>
		EqualSingle ,
		
		/// <summary>
		/// 相等匹配：匹配参数队列中的所有元素,即完全匹配
		/// </summary>
		EqualAll ,
		
		/// <summary>
		/// 不相等匹配：不和参数队列中的任何一个相同
		/// </summary>
		NotEqual ,
		
		/// <summary>
		/// 一定范围内,上下限:[a,b]
		/// </summary>
		RangeLimite ,
		
		/// <summary>
		/// 不在范围内 <a,>b
		/// </summary>
		NotInRangeLimite ,
		
		/// <summary>
		/// 小于一个数 <= a
		/// </summary>
		LessThanLimite,
		
		/// <summary>
		/// 大于一个数 >=b
		/// </summary>
		GreaterThanLimite,
		
		/// <summary>
		/// 字符串的比较,如2个组合出现的情况和2个不出现的情况
		/// 只要一个符合就可以
		/// </summary>
		StringEqualSingle,
		
		/// <summary>
		/// 字符串完全匹配
		/// </summary>
		StringEqualAll
	}
	
	/// <summary>
	/// 基本的规则比较方法类,静态方法
	/// </summary>
	public static class BaseRuleCompare
	{
		//TODO:增加字符串比较的方法,并增加统一调用接口
		
		public static readonly double Precision = 0.001 ;
		
		#region 数值比较		
		public static bool EqualSingle(double[] data ,double[] Conditons)
		{
			//相等匹配:只匹配队列中一种即可,全部转换为double进行计算,差小于0.001即认为相等
			//data可能为有多个数,默认只要有一种和目标集合相同就可以.一般和值,均值只有1个数字
			//可能用途:胆号,每次选择一个号码或几个号码做胆号,进行过滤.	
			for (int i = 0 ; i <data.Length ; i ++ )
			{
				for (int j = 0 ; j <Conditons.Length ; j ++)
				{
					if (Math.Abs (data [i ]-Conditons [j ])<Precision)
					{
						return true ;//一旦有相等的,即可返回
					}
				}
			}
			return false ;
		}
		
		public static bool EqualAll(double[] data ,double[] Conditons)
		{
			//完全匹配:匹配队列中所有值,全部转换为double进行计算,差小于0.001即认为相等
			//如和值匹配,跨度匹配,组合匹配(2个数字都要出现,组合出现)				
			for (int i = 0 ; i <data.Length ; i ++ )
			{
				for (int j = 0 ; j <Conditons.Length ; j ++)
				{
					if (Math.Abs (data [i ]-Conditons [j ]) >Precision)
					{
						return false  ;//一旦有不相等的,说明不满足,即可返回
					}
				}
			}
			return true  ;
		}
		
		public static bool NotEqual(double[] data , double[] Conditons)
		{
			//不相等匹配:与目标集合都不相同即可
			//可用于杀号,如杀和值，杀跨度.
			double[] obj = new double[Conditons.Length ] ;
			for (int i = 0 ; i <Conditons.Length ; i ++)
			{
				obj [i ] = (double )Conditons [i ] ;
			}			
			for (int i = 0 ; i <data.Length ; i ++ )
			{
				for (int j = 0 ; j <Conditons.Length ; j ++)
				{
					if (Math.Abs (data [i ]-Conditons [j ]) < Precision )
					{
						return false  ;//一旦有相等的,说明不满足,即可返回
					}
				}
			}
			return true  ;
		}
	
		public static bool RangeLimite(double[] data ,double[] Conditons)
		{
			//范围匹配:属于目标集合范围即可,规定上下限,[]，闭区间		
			for (int i = 0 ; i <data.Length ; i ++ )
			{				
				if ((data[i ]>Conditons [1])||(data [i ]<Conditons [0]))
				{
					return false  ;//一旦有不在范围的,说明不满足,即可返回
				}				
			}
			return true  ;
		}
		
		public static bool NotInRangeLimite(double[] data ,params double[] Conditons)
		{
			//不在某一区间,即<=或者>=
			for (int i = 0 ; i <data.Length ; i ++ )
			{				
				if ((data[i ]<Conditons [1])&&(data [i ]>Conditons [0]))
				{
					return false  ;//一旦有不在范围的,说明不满足,即可返回
				}				
			}
			return true  ;
		}
		
		public static bool LessThanLimite(double[] data ,params double[] Conditons)
		{
			//小于等于比较<=
			for (int i = 0 ; i <data.Length ; i ++ )
			{				
				if ((data[i ]>Conditons [0]))
				{
					return false  ;//一旦有大于范围的,说明不满足,即可返回
				}				
			}
			return true  ;
		}
		
		public static bool GreaterThanLimite(double[] data ,params double[] Conditons)
		{
			//大于等于比较>=
			for (int i = 0 ; i <data.Length ; i ++ )
			{				
				if ((data[i ]<Conditons [0]))
				{
					return false  ;//一旦有小于于范围的,说明不满足,即可返回
				}				
			}
			return true  ;
		}
		#endregion
		
		#region 字符串比较
		public static bool StringEqualSingle(ArrayList data ,ArrayList Conditons)
		{
			//只要有一个符合就可以
			foreach(object e in data )
			{
				foreach(object c in Conditons )
				{
					if (e.ToString ().Equals (c.ToString ())) 
					{
						return true ;
					}
				}
			}
			return false ;
		}
		
		public static bool StringEqualAll(ArrayList data,ArrayList Conditons)
		{
			//所有的都要符合
			foreach(object e in data )
			{
				foreach(object c in Conditons )
				{
					if (e.ToString ().Equals (c.ToString ())) 
					{
						return false ;
					}
				}
			}
			return true ;			
		}
		#endregion

        #region 综合比较       
        /// <summary>
		/// 根据指定的规则将数据 与 指定参数进行对比，确定是否满足条件
		/// </summary>
		/// <param name="typeName">过滤规则名称</param>
		/// <param name="data">需要对比的数据</param>
		/// <param name="Conditons">参数列表</param>
		/// <returns>是否满足</returns>
		public static bool RuleCompare(FilterRuleType typeName,object data ,double[] Conditons)
		{
			//根据名称，采用反射调用,data为Arraylist数组
			if ((typeName == FilterRuleType.StringEqualSingle )||(typeName == FilterRuleType.StringEqualAll ))
			{
				Type t = typeof (BaseRuleCompare);
				MethodInfo mi = t.GetMethod (typeName.ToString ()) ;
				//invoke,传入数组参数
				ArrayList[] ar = (ArrayList[])data ;
				return  (bool )mi.Invoke (null ,new object []{ar[0],ar [1] }) ;
			}
			else
			{
				Type t = typeof (BaseRuleCompare);
				MethodInfo mi = t.GetMethod (typeName.ToString ()) ;
				//invoke,传入数组参数
				return (bool ) mi.Invoke (null ,new object []{(double[])data ,Conditons }) ;
			}
        }
        #endregion
    }	
}