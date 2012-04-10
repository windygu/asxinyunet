using System;
using Lephone.Data.Definition;

namespace OrmCommon
{
    [DbTable("Sheet1"), DbContext("Excel")]
	public class BookInfo : IDbObject
	{
		[DbColumn("Book Name")] public string BookName;
		public string ISBN;
	    public Date BuyDate;
	    public long Count;

		public override string ToString()
		{
			return string.Format("Item:{0},{1},{2},{3}", BookName, ISBN, BuyDate, Count);
		}
	}
}
