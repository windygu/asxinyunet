
#region usings

using System;
using System.Collections.Generic;
using Lephone.Data;

#endregion

namespace Common
{
	public interface IDataLayer
	{
		List<SampleData> GetTestItems(Condition iwc);
        void SaveTestItem(ref SampleData ti);
        void DeleteTestItem(SampleData ti);
	}
}
