using System;
using Lephone.Data.Definition;

namespace Common
{
    [Serializable]
	public class SampleData : DbObjectModel<SampleData>
	{
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public DateTime JoinDate { get; set; }
        public bool Enabled { get; set; }

        public static SampleData New(string name, UserRole role, DateTime joinDate, bool enabled)
        {
            return new SampleData
            {
                Name = name,
                Role = role,
                JoinDate = joinDate,
                Enabled = enabled,
            };
        }
	}
}
