
#region usings

using System;
using System.Collections.Generic;
using Common;
using Lephone.Data;

#endregion

namespace Server
{
	public class DataLayer : MarshalByRefObject, IDataLayer
	{
		public DataLayer() {}

        public List<SampleData> GetTestItems(Condition iwc)
		{
            List<SampleData> dic = DbEntry.From<SampleData>().Where(iwc).Select();
			return dic;
		}

        public void SaveTestItem(ref SampleData ti)
        {
            DbEntry.Save(ti);
        }

        public void DeleteTestItem(SampleData ti)
        {
            DbEntry.Delete(ti);
        }
    }
}
