using System;
using Lephone.Data.Definition;
using Lephone.Extra;

namespace OrmCommon
{
    public class TheAge : DbObject
    {
        public int Age;

        public TheAge() { }

        public TheAge(int age)
        {
            this.Age = age;
        }
    }

    // for CompareOpration.Equal, JoinMode.Inner
    [JoinOn(0, typeof(SampleData), "Id", typeof(TheAge), "Id")]
    public class JoinTable1 : IDbObject
    {
        [DbColumn("SampleData.Id")] public long Id;
        public string Name;
        public UserRole Role;
        public DateTime JoinDate;
        public int Age;

        public override string ToString()
        {
            string s = string.Format("Item:{0},{1},{2},{3},{4}",
                Id, Name, Role, JoinDate, Age);
            return s;
        }
    }

    [JoinOn(0, typeof(SampleData), "Id", typeof(TheAge), "Id", CompareOpration.Equal, JoinMode.Inner)]
    [JoinOn(1, typeof(SampleData), "Id", typeof(LephoneEnum), "Id", CompareOpration.Equal, JoinMode.Inner)]
    public class JoinTable2 : IDbObject
    {
        [DbColumn("SampleData.Id")] public long Id;
        [DbColumn("SampleData.Name")] public string Name;
        public UserRole Role;
        public DateTime JoinDate;
        public int Age;
        [DbColumn("LephoneEnum.Name")] public string EnumName;

        public override string ToString()
        {
            string s = string.Format("Item:{0},{1},{2},{3},{4},{5}",
                Id, Name, Role, JoinDate, Age, EnumName);
            return s;
        }
    }
}
