using System;
using Lephone.Data.Definition;

namespace OrmCommon
{
	public class User : IDbObject
	{
        [DbKey(IsDbGenerate = false), Length(50)]
        public string Name;

        [Length(50)]
		public string Password;

		public DateTime JoinDate;

		public User() {}

		public User(string name, string password, DateTime joinDate)
		{
			this.Name = name;
			this.Password = password;
			this.JoinDate = joinDate;
		}

		public override string ToString()
		{
			return string.Format("Item:{0},{1},{2}", Name, Password, JoinDate);
		}
	}
}
