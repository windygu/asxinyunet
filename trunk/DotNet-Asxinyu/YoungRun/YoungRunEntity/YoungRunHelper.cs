/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-27
 * 时间: 10:08
 */
using System;
using XCode;
using System.Collections.Generic ;
using System.Data ;
using System.IO ;
using System.ComponentModel;
using XCode.DataAccessLayer;
using System.Collections;
using System.Reflection ;
using NewLife.IO;
using NewLife.Reflection;
using XCode.Configuration;
using XCode.Exceptions;
using XCode.Model;
using NPOI.Util;
using NPOI.SS.Util ;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using NPOI.HSSF;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.UserModel.Contrib;
using System.Text ;
using NPOI.SS.UserModel ;

namespace YoungRunEntity
{
	
	#region 枚举类型
	/// <summary>
	/// 永润数据类型编号
	/// </summary>
	public enum YoungRunDataType
	{
		/// <summary>
		/// 糠醛车间检测
		/// </summary>
		[Description("糠醛车间检测")]
		R201 ,
		/// <summary>
		/// 白土车间检测
		/// </summary>
		[Description("白土车间检测")]
		R202 ,
		/// <summary>
		/// 油品全套数据检测
		/// </summary>
		[Description("油品全套数据检测")]
		R203 ,
		/// <summary>
		/// 样品单据
		/// </summary>
		[Description("样品单据")]
		R204
	}
	
	/// <summary>
	/// 永润数据字典的类型
	/// </summary>
	public enum YoungRunDicType
	{
		/// <summary>
		/// 记录类型
		/// </summary>
		[Description("记录类型")]
		RecordType = 1 ,
		/// <summary>
		/// 实验数据类型
		/// </summary>
		[Description("实验数据类型")]
		LabTestType =2 ,
		/// <summary>
		/// 罐编号
		/// </summary>
		[Description("罐编号")]
		TankId 	,
		/// <summary>
		/// 油罐储存类型
		/// </summary>
		[Description("油罐储存类型")]
		TankType ,
		/// <summary>
		/// 数据类型编号前缀
		/// </summary>
		[Description("数据类型编号前缀")]
		DataTypeId,
		/// <summary>
		/// 产品名称
		/// </summary>
		[Description("产品名称")]
		ProductName ,
		/// <summary>
		/// 原料名称
		/// </summary>
		[Description("原料名称")]
		RawName ,
		/// <summary>
		/// 精制油
		/// </summary>
		[Description("精制油")]
		KJZOil ,
		/// <summary>
		/// 辅料
		/// </summary>
		[Description("辅料")]
		AssistRaw ,
		
		/// <summary>
		/// 其他类型
		/// </summary>
		[Description("其他类型")]
		Other ,
		
		/// <summary>
		/// 白土车间采样地点
		/// </summary>
		[Description("白土车间采样地点")]
		BtGetSampleLocate ,
		/// <summary>
		/// 糠醛车间采样地点
		/// </summary>
		[Description("糠醛车间采样地点")]
		KqGetSampleLoate
	}
	#endregion

	
	/// <summary>
	/// 永润石化帮助类
	/// </summary>
	public class YoungRunHelper
	{
		#region 各种数据编号的生成
		public static string GetNextYoungRunDataId(YoungRunDataType yrDataType)
		{
			//先根据当前日期生成前缀，并查询最后一个类似的编号大小
			string perID = yrDataType.ToString ()+"-"+DateTime.Now.ToString ("yyMMdd") ;
			//查找
			switch (yrDataType)
			{
				case YoungRunDataType.R201 :
                    tb_KqTestData model = SearchNextId<tb_KqTestData>(tb_KqTestData._.ID + " like '%" + perID + "%'");
					return model == null ? perID + "-" + "01" :(perID+"-"+GetNextString(model.ID));
				case YoungRunDataType.R202 :
                    tb_BtTestData model202 = SearchNextId<tb_BtTestData>(tb_BtTestData._.ID + " like '%" + perID + "%'");
					return model202 == null ? perID + "-" + "01" : (perID + "-" + GetNextString(model202.ID));
				case YoungRunDataType.R203 :
                    tb_OilData model203 = SearchNextId<tb_OilData>(tb_OilData._.ID + " like '%" + perID + "%'");
					return model203 == null ? perID + "-" + "01" : (perID + "-" + GetNextString(model203.ID));
					
				case YoungRunDataType.R204 :
                    tb_OutSampleTest model207 = SearchNextId<tb_OutSampleTest>(tb_OutSampleTest._.ID + " like '%" + perID + "%'");
					return model207 == null ? perID + "-" + "01" : (perID + "-" + GetNextString(model207.ID));
					
					default :
						return "";
			}
		}
		
		private static T SearchNextId<T>(string condition) where T :Entity<T>,new()
		{
			List<T> list = Entity<T>.FindAll(condition, Entity<T>.Meta.Unique.ColumnName +" Desc", null, 0, 1);
			if (list == null)
			{
				return null;
			}
			else
				return list[0];
		}
		private static string GetNextString(string curStr)
		{
			string[] str = curStr.Split ('-') ;
			int curValue;
			if (!Int32.TryParse(str[str.Length - 1], out curValue))
			{
				return curStr + "-" + "00";
			}
			return (curValue + 1).ToString().PadLeft(2, '0');
		}
		#endregion

		#region 计算粘度指数与调和比例
		public static int CalcuteVI(double V40, double V100)
		{
			double L, H;
			int res = -1;
			if (V100 < 2)
				return res;
			if (V100 >= 2 && V100 < 4)
			{
				L = 1.1364 * Math.Pow(V100, 2) + 1.814 * V100 - 0.181;
				H = 0.827 * Math.Pow(V100, 2) + 1.632 * V100 - 0.181;
			}
			else if (V100 >= 4 && V100 < 6.1)
			{
				L = -9.8713 * Math.Pow(V100, 2) + 338.663 * V100 - 995.142 * Math.Pow(V100, 0.5) + 818.905;
				H = -2.6758 * Math.Pow(V100, 2) + 96.671 * V100 - 269.664 * Math.Pow(V100, 0.5) + 215.025;
			}
			else if (V100 >= 6.1 && V100 < 7.2)
			{
				L = 2.838 * Math.Pow(V100, 2) + 2.32 * Math.Pow(V100, 1.5626) - 27.35 * V100 + 81.83;
				H = 2.32 * Math.Pow(V100, 1.5626);
			}
			else if (V100 >= 7.2 && V100 < 12.4)
			{
				L = 0.7385 * Math.Pow(V100, 2) + 10.692 * V100 - 32.888;
				H = 0.1922 * Math.Pow(V100, 2) + 8.25 * V100 - 18.728;
			}
			else if (V100 >= 12.4 && V100 < 70)
			{
				L = 1795.2 * Math.Pow(V100, -2) + 0.8813 * Math.Pow(V100, 2) + 9.167 * V100 - 46.947;
				H = 1795.2 * Math.Pow(V100, -2) + 0.1818 * Math.Pow(V100, 2) + 10.357 * V100 - 54.547;
			}
			else
			{
				L = 0.8353 * Math.Pow(V100, 2) + 14.67 * V100 - 216;
				H = 0.1684 * Math.Pow(V100, 2) + 11.85 * V100 - 97;
			}
			res = (int)Math.Round(((L - V40) * 100 / (L - H)), 0);
			if (res >= 100)
			{
				if (V100 > 70)
				{
					H = 0.1684 * Math.Pow(V100, 2) + 11.85 * V100 - 97;
				}
				double N = (Math.Log10(H) - Math.Log10(V40)) / Math.Log10(V100);
				double t = ((Math.Pow(10, N) - 1) / 0.00715 + 100);
				res = (int)(Math.Round(t, 0));
			}
			return res;
		}
		public static double CalcuateMixV(double KV1, double KV2, double percent, int i)
		{
			int[] Kvalue = new int[] { 4, 2 };   //40度和100度的k值
			int K = Kvalue[i];
			double x1 = percent / 100;
			return Math.Round(100 * (Math.Exp(Math.Log(KV2 + K) * Math.Exp(x1 * Math.Log(Math.Log(KV1 + K) / Math.Log(KV2 + K)))) - K)) / 100;
		}
		public static double CalcuateMixVs(double KV1, double KV2, double KV, int i)
		{
			int[] Kvalue = new int[] { 4, 2 };   //40度和100度的k值
			int K = Kvalue[i];
			double a = Math.Log(KV + K);
			double b = Math.Log(KV1 + K);
			double c = Math.Log(KV2 + K);
			return Math.Round(10000 * (Math.Log(a / c) / Math.Log(b / c))) / 100;
		}
		#endregion

		#region 根据字典类型获取相应键值的列表
		public static string[] GetDicValueList(YoungRunDicType dicType)
		{
            List<tb_DicType> tlist = tb_DicType.FindAll(tb_DicType._.TypeName, dicType.ToString());
			string[] res = new string[tlist.Count ] ;
			if (tlist !=null )
			{
				for (int i = 0; i < tlist.Count; i++)
				{
					res[i] = tlist[i].Value ;
				}
			}
			return res ;
		}
		#endregion

		#region 获取数据库服务器的时间
		public static DateTime GetDBServerTime()
		{
            return Convert.ToDateTime(tb_OilTankST.Meta.Query("select now();").Tables[0].Rows[0][0].ToString());
		}
		#endregion
		
		#region 获取枚举字段的属性列表
		public static string[] GetEnumFields<TEnum>()
		{
			Type enumType = typeof(TEnum);
			if (!enumType.IsEnum)
			{
				throw new ArgumentException("enumItem requires a Enum ");
			}
			FieldInfo[] objs =  enumType.GetFields () ;
			if (objs == null || objs.Length == 0)
			{
				return null ;
			}
			else
			{
				string[] res = new string[objs.Length -1] ;
				for (int i = 1 ; i < objs.Length  ; i++) {
					string s =( enumType.GetField(objs[i].Name ).GetCustomAttributes (
						typeof (DescriptionAttribute ),false)[0] as DescriptionAttribute).Description ;
					res[i -1] = (s +"("+objs [i].Name+")") ;
				}
				return res ;
			}
		}

		#endregion

		#region 获取实体类所有的字段名及描述
		public static string[] GetEntityColumnsName<T>() where T:Entity <T>,new ()
		{
			FieldItem[] items = Entity<T>.Meta.AllFields;
			string[] res = new string[items.Length -1] ;
			for (int i = 0; i < items.Length -1; i++)
			{
				//                res[0, i] = items[i].Field.ID.ToString();
				res[i] = items[i].Field.Description + "("+items[i].Field.Name +")";
			}
			return res ;
		}
		#endregion

		#region 动态得到实体
		public static IEntity GetEntityType(string name)
		{
			IEntityOperate Entity = EntityFactory.CreateOperate(name );
			IEntity EnItem = EntityFactory.Create(name );
			foreach (FieldItem item in Entity.Fields)
			{
				
			}
			EnItem.Save();
			return EnItem ;
		}
		#endregion
		
		#region 储量日报表统计  +  库存统计算法,包括原辅料，成品油
		public static void StockStatistics(DateTime dt)
		{
			#region 统计参数与准备
			int curRow = 4 ;//当前行
			//先获取罐的存储类型
			string[] AllTankType = GetDicValueList (YoungRunDicType.TankType ) ;
			//获取指定时刻的储量数据,2分钟之内
            string str1 = tb_OilTankST._.RecordTime + ">='" + dt.ToString("yyyy-MM-dd HH:mm") + ":00'";
            string str2 = " and " + tb_OilTankST._.RecordTime + "<='" + dt.AddMinutes(1).ToString("yyyy-MM-dd HH:mm") + ":59'";
            List<tb_OilTankST> cutST = tb_OilTankST.FindAll(str1 + str2, "", "", 0, 0);//
            List<tb_OilTankST> s = cutST.FindAll(delegate(tb_OilTankST name)
            {
			                                        	return true ;
			                                        }) ;
			#endregion
			
			#region Excel设置
			FileStream fs = new FileStream ("Tests.xls", FileMode.Create ) ;
			HSSFWorkbook hssfworkbook = new HSSFWorkbook () ;
			HSSFSheet  newSheet =(HSSFSheet ) hssfworkbook.CreateSheet ("Sheet1") ; //新建工作簿
			for (int i = 0; i < 40; i++) {
				newSheet.CreateRow (i ) ;
			}
			//设置标题与时间
			HSSFRow row = (HSSFRow )newSheet.GetRow(0);
			row.HeightInPoints = 30;
			HSSFCell cell =(HSSFCell ) row.CreateCell(0);
			cell.SetCellValue("灌区油品储量日报表");
			HSSFCellStyle style = (HSSFCellStyle )hssfworkbook.CreateCellStyle();
			style.Alignment =  HorizontalAlignment.CENTER ;
			HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
			font.FontHeight = 30*20;
			style.SetFont(font);
			cell.CellStyle = style;
			newSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 7));//合并单元格，并设置好样式
			newSheet.GetRow (1).CreateCell (5).SetCellValue (dt.ToString ("yyyy-MM-dd HH:mm"));//添加日期
			newSheet.GetRow (1).Height = 450 ;
			newSheet.SetColumnWidth(0, 10 * 256); //设置列宽度
			newSheet.SetColumnWidth(1, 22* 256); //设置列宽度
			newSheet.SetColumnWidth(2, 22 * 256); //设置列宽度
			newSheet.SetColumnWidth(3, 24 * 256);//设置列宽度
			newSheet.SetColumnWidth(4, 15 * 256);//设置列宽度
			newSheet.SetColumnWidth(5, 12 * 256);//设置列宽度
			newSheet.SetColumnWidth(6, 26 * 256);//设置列宽度
			
			//设置
			newSheet.GetRow(3).Height = 500 ;
			newSheet.GetRow (3 ).CreateCell (0).SetCellValue ("类别");
			newSheet.GetRow (3 ).CreateCell (1).SetCellValue ("油品名称");
			newSheet.GetRow (3 ).CreateCell (2).SetCellValue ("罐号/(总体积)");
			newSheet.GetRow (3 ).CreateCell (3).SetCellValue ("液位(米)/(总高度)");
			newSheet.GetRow (3 ).CreateCell (4).SetCellValue ("重量(吨)");
			newSheet.GetRow (3 ).CreateCell (5).SetCellValue ("汇总(吨)");
			newSheet.GetRow (3 ).CreateCell (6).SetCellValue ("备注");
			for (int i = 0; i <= 6; i++) {
				newSheet.GetRow (3 ).GetCell (i ).CellStyle =  GetSheetBorderStyle (hssfworkbook,1) ;
			}
			#endregion
			
			#region 循环获取数据并设置
			for (int i = 0; i < AllTankType.Length ; i++) {
				
				//每一个储罐类型下找对应的子类型
                tb_DicType dic = tb_DicType.Find(tb_DicType._.Value, AllTankType[i]);
				//再查找每个子类型下所有的油品名称
                List<tb_DicType> subDicTypes = tb_DicType.FindAll(tb_DicType._.TypeName, dic.Remark);
				//循环获取与统计每个子类型下面的油品名称的储量数据
				#region 写入每一个大类的信息
				//合并单元格，设置居中，文字大小，文字方向按照换行解决
				newSheet.GetRow(curRow ).CreateCell (0).SetCellValue (dic.Value ) ;
				newSheet.GetRow (curRow).GetCell (0).CellStyle = GetSheetBorderStyle (hssfworkbook,1) ;
				//查询当前类中包括的油品名称，总共有多少个罐
				int allSubCount = 0 ;
				for (int r = 0; r < subDicTypes.Count ; r++) {
                    List<tb_OilTankST> cutSub = cutST.FindAll(delegate(tb_OilTankST st)
                    {
					                                            	return st.ProductNameTP  == subDicTypes[r ].Value ? true:false ;
					                                            }) ;
					allSubCount += cutSub.Count ;
				}
				for (int j = curRow ; j < curRow+allSubCount ; j++) {
					if (newSheet.GetRow (j).GetCell (0)==null ) {
						newSheet.GetRow (j ).CreateCell(0).CellStyle = GetSheetBorderStyle (hssfworkbook,8) ;
					}
					else {
						newSheet.GetRow (j ).GetCell (0).CellStyle = GetSheetBorderStyle (hssfworkbook,8) ;
					}
				}
				newSheet.AddMergedRegion(new CellRangeAddress(curRow ,curRow+allSubCount-1, 0, 0)); //合并单元格，并设置好样式
				#endregion
				
				for (int j = 0; j < subDicTypes.Count ; j++)
				{
					//根据油罐储量信息表存储的信息为准，因为储罐信息表是当前的信息，不能代表过去的信息
                    List<tb_OilTankST> cutSubTypeTanks = cutST.FindAll(delegate(tb_OilTankST st)
                    {
					                                                     	return st.ProductNameTP == subDicTypes[j ].Value ? true:false ;
					                                                     }) ;
					#region 写入每一个子类的信息
					//合并单元格，设置居中，文字大小，文字方向按照换行解决
					newSheet.GetRow (curRow ).CreateCell (1).SetCellValue (subDicTypes[j].Value) ;
					//合并单元格，并设置好样式
					newSheet.AddMergedRegion(new CellRangeAddress(curRow ,curRow+cutSubTypeTanks.Count-1, 1, 1));//油品名称列
					newSheet.AddMergedRegion(new CellRangeAddress(curRow ,curRow+cutSubTypeTanks.Count-1, 5, 5));//汇总列
					newSheet.GetRow (curRow).GetCell(1).CellStyle = GetSheetBorderStyle(hssfworkbook,8) ;					
					for (int r = curRow ; r < curRow+cutSubTypeTanks.Count ; r ++) {
						if (newSheet.GetRow (r ).GetCell (1)==null ) {
							newSheet.GetRow (r ).CreateCell(1).CellStyle = GetSheetBorderStyle (hssfworkbook,8) ;
						}
						else {
							newSheet.GetRow (r ).GetCell (1).CellStyle = GetSheetBorderStyle (hssfworkbook,8) ;
						}
					}
					#endregion
					
					#region 循环写入每个罐的信息
					double sum = 0 ;//每类型相同的油的重量总和
					for (int k = 0; k < cutSubTypeTanks.Count ; k++)
					{
						sum += cutSubTypeTanks[k ].CurWeigth ;
						newSheet.GetRow (curRow).Height = 500 ;
						newSheet.GetRow (curRow ).CreateCell (2).SetCellValue (GetRichText (hssfworkbook,cutSubTypeTanks[k].TankIdTP.Replace ("罐","")
      + "   " + tb_OilTankInfo.Find(tb_OilTankInfo._.TankId, cutSubTypeTanks[k].TankIdTP).Volume.ToString() + "m3"));//设置油罐号
						newSheet.GetRow (curRow ).CreateCell (3).SetCellValue (GetRichTextForSize (hssfworkbook,cutSubTypeTanks[k].LiquidLevel.ToString ("F2")+
                                                                                            "   " + tb_OilTankInfo.Find(tb_OilTankInfo._.TankId, cutSubTypeTanks[k].TankIdTP).Height.ToString() + "m"));//设置液位
						newSheet.GetRow (curRow ).CreateCell (4).SetCellValue ( cutSubTypeTanks[k].CurWeigth.ToString ("F2"));//设置液位
						newSheet.GetRow (curRow ).CreateCell (5).SetCellValue ("");//汇总
						newSheet.GetRow (curRow ).CreateCell (6).SetCellValue ( cutSubTypeTanks[k].Remark);//备注
						if (k ==0) {
							newSheet.GetRow (curRow ).GetCell (2).CellStyle = GetSheetBorderStyle(hssfworkbook,5) ;//左上
							newSheet.GetRow (curRow ).GetCell (3).CellStyle = GetSheetBorderStyle(hssfworkbook,3) ;//上
							newSheet.GetRow (curRow ).GetCell (4).CellStyle = GetSheetBorderStyle(hssfworkbook,3) ;//上
							newSheet.GetRow (curRow ).GetCell (5).CellStyle = GetSheetBorderStyle(hssfworkbook,3) ;//上
							newSheet.GetRow (curRow ).GetCell (6).CellStyle = GetSheetBorderStyle(hssfworkbook,9) ;//上
							if (cutSubTypeTanks.Count ==1) {
								//最后一个罐计算完后写入汇总信息
								newSheet.GetRow (curRow-cutSubTypeTanks.Count+1).GetCell(5).SetCellValue(sum.ToString ("F2")) ;
							}
						}
						else if (k == cutSubTypeTanks.Count -1) {
							newSheet.GetRow (curRow ).GetCell (2).CellStyle = GetSheetBorderStyle(hssfworkbook,6) ;//左下
							newSheet.GetRow (curRow ).GetCell (3).CellStyle = GetSheetBorderStyle(hssfworkbook,2) ;//下
							newSheet.GetRow (curRow ).GetCell (4).CellStyle = GetSheetBorderStyle(hssfworkbook,2) ;//下
							newSheet.GetRow (curRow ).GetCell (5).CellStyle = GetSheetBorderStyle(hssfworkbook,2) ;//下
							newSheet.GetRow (curRow ).GetCell (6).CellStyle = GetSheetBorderStyle(hssfworkbook,10) ;//下
							//最后一个罐计算完后写入汇总信息
							newSheet.GetRow (curRow-cutSubTypeTanks.Count+1).GetCell(5).SetCellValue(sum.ToString ("F2")) ;
						}
						else
						{
							newSheet.GetRow (curRow ).GetCell (2).CellStyle = GetSheetBorderStyle(hssfworkbook,4) ;//左
							newSheet.GetRow (curRow ).GetCell (3).CellStyle = GetSheetBorderStyle(hssfworkbook,7) ;//下
							newSheet.GetRow (curRow ).GetCell (4).CellStyle = GetSheetBorderStyle(hssfworkbook,7) ;//下
							newSheet.GetRow (curRow ).GetCell (5).CellStyle = GetSheetBorderStyle(hssfworkbook,7) ;//下
							newSheet.GetRow (curRow ).GetCell (6).CellStyle = GetSheetBorderStyle(hssfworkbook ,11) ;//下
						}
						curRow ++ ;
					}
					#endregion
				}
			}
			hssfworkbook .Write (fs ) ;
			fs.Close () ;
			#endregion
		}
		#region 辅助Excel设置
		public static HSSFCellStyle GetSheetBorderStyle(HSSFWorkbook workbook,int typeId)
		{
			HSSFCellStyle cutStyle = (HSSFCellStyle )workbook.CreateCellStyle();
			HSSFFont BigClassFont = (HSSFFont)workbook.CreateFont() ;
			BigClassFont.FontHeightInPoints = 16 ;
			cutStyle.SetFont(BigClassFont) ;
			
			if (typeId ==1) { //左,上下为粗 ，右边细
				cutStyle.BorderBottom= CellBorderType.MEDIUM ;//粗边框
				cutStyle.BorderLeft= CellBorderType.MEDIUM ;
				cutStyle.BorderRight=CellBorderType.THIN ;//细边框
				cutStyle.BorderTop = CellBorderType.MEDIUM ;
			}
			else if (typeId ==2) {//下为粗，左右为细
				cutStyle.BorderBottom= CellBorderType.MEDIUM ;
				cutStyle.BorderLeft= CellBorderType.THIN ;
				cutStyle.BorderRight=CellBorderType.THIN ;
				cutStyle.BorderTop = CellBorderType.THIN ;
			}
			else if (typeId ==3) {//上为粗，下，左，右为细
				cutStyle.BorderBottom= CellBorderType.THIN ;
				cutStyle.BorderLeft= CellBorderType.THIN ;
				cutStyle.BorderRight=CellBorderType.THIN ;
				cutStyle.BorderTop = CellBorderType.MEDIUM ;
			}
			else if (typeId ==4) {//左为粗，上下右为细
				cutStyle.BorderBottom= CellBorderType.THIN ;
				cutStyle.BorderLeft= CellBorderType.MEDIUM ;
				cutStyle.BorderRight=CellBorderType.THIN ;
				cutStyle.BorderTop = CellBorderType.THIN ;
			}
			else if (typeId ==5) {//上左为粗，下右为细
				cutStyle.BorderBottom= CellBorderType.THIN ;
				cutStyle.BorderLeft= CellBorderType.MEDIUM ;
				cutStyle.BorderRight=CellBorderType.THIN ;
				cutStyle.BorderTop = CellBorderType.MEDIUM ;
			}
			else if (typeId ==6) {//下左为粗，上右为细
				cutStyle.BorderBottom= CellBorderType.MEDIUM ;
				cutStyle.BorderLeft= CellBorderType.MEDIUM ;
				cutStyle.BorderRight=CellBorderType.THIN ;
				cutStyle.BorderTop = CellBorderType.THIN ;
			}
			else if (typeId ==7) {//全为细
				cutStyle.BorderBottom= CellBorderType.THIN ;
				cutStyle.BorderLeft= CellBorderType.THIN ;
				cutStyle.BorderRight=CellBorderType.THIN ;
				cutStyle.BorderTop = CellBorderType.THIN ;
			}
			else if (typeId ==8) {//全为粗
				cutStyle.BorderBottom= CellBorderType.MEDIUM ;
				cutStyle.BorderLeft= CellBorderType.MEDIUM ;
				cutStyle.BorderRight=CellBorderType.MEDIUM ;
				cutStyle.BorderTop = CellBorderType.MEDIUM ;
			}
			else if (typeId ==9) {//上右为粗
				cutStyle.BorderBottom= CellBorderType.THIN ;
				cutStyle.BorderLeft= CellBorderType.THIN ;
				cutStyle.BorderRight=CellBorderType.MEDIUM ;
				cutStyle.BorderTop = CellBorderType.MEDIUM ;
			}
			else if (typeId ==10) {//下右为粗
				cutStyle.BorderBottom= CellBorderType.MEDIUM ;
				cutStyle.BorderLeft= CellBorderType.THIN ;
				cutStyle.BorderRight=CellBorderType.MEDIUM ;
				cutStyle.BorderTop = CellBorderType.THIN ;
			}
			else if (typeId ==11) {//右为粗
				cutStyle.BorderBottom= CellBorderType.THIN ;
				cutStyle.BorderLeft= CellBorderType.THIN ;
				cutStyle.BorderRight=CellBorderType.MEDIUM ;
				cutStyle.BorderTop = CellBorderType.THIN ;
			}
			cutStyle.VerticalAlignment= VerticalAlignment.CENTER ;
			cutStyle.Alignment = HorizontalAlignment.CENTER_SELECTION  ;
			return cutStyle ;
		}		
		public static HSSFRichTextString GetRichText(HSSFWorkbook workbook,string text)
		{
			HSSFRichTextString richtext = new HSSFRichTextString(text );	
			HSSFFont BigClassFont = (HSSFFont)workbook.CreateFont() ;
			BigClassFont.FontHeightInPoints = 16 ;
			richtext.ApplyFont(0,text.Length -6,BigClassFont);				
			
			Font font2 = workbook.CreateFont();
			font2.FontHeightInPoints = 14 ;
			richtext.ApplyFont(text.Length -5,text.Length-1 , font2);
			
			Font font4 = workbook.CreateFont();
			font4.FontHeightInPoints = 14 ;
			font4.TypeOffset = (short)FontSuperScript.SUPER ;			
			richtext.ApplyFont(text.Length -1,text.Length , font4);
			
			return richtext ;
		}
		public static HSSFRichTextString GetRichTextForSize(HSSFWorkbook workbook,string text)
		{
			HSSFRichTextString richtext = new HSSFRichTextString(text );	
			HSSFFont BigClassFont = (HSSFFont)workbook.CreateFont() ;
			BigClassFont.FontHeightInPoints = 16 ;
			richtext.ApplyFont(0,text.Length -5,BigClassFont);							
			Font font4 = workbook.CreateFont();
			font4.FontHeightInPoints = 14 ;				
			richtext.ApplyFont(text.Length -5,text.Length , font4);	
			return richtext ;
		}
		#endregion
		#endregion
	}
}