using System;
using Lephone.Data.Definition;

namespace OrmCommon
{
    public class SystemTime : DbObjectModel<SystemTime>
    {
        public string Name { get; set; }

        [SpecialName]
        public DateTime CreatedOn { get; set; }

        [SpecialName]
        public DateTime? UpdatedOn { get; set; }

        [SpecialName]
        public DateTime SavedOn { get; set; }
    }
}
