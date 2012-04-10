using System;
using Lephone.Data.Definition;

namespace OrmCommon
{
    [Cacheable, Serializable]
	public class SampleData : DbObjectModel<SampleData>
	{
        [Length(50)]
        public string Name { get; set; }

        public UserRole Role { get; set; }

        public DateTime JoinDate { get; set; }

        public bool Enabled { get; set; }

        public int? NullInt { get; set; }

        public static SampleData New(string name, UserRole role, DateTime joinDate, bool enabled, int? nullInt)
        {
            return new SampleData
            {
                Name = name,
                Role = role,
                JoinDate = joinDate,
                Enabled = enabled,
                NullInt = nullInt,
            };
        }
    }
}
