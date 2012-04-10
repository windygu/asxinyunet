using System.Collections.Generic;
using Lephone.Data.Definition;

namespace OrmCommon
{
    [DbTable("People")]
    public class Person : DbObjectModel<Person>
    {
        [Length(50)]
        public string Name { get; set; }

        [HasOne(OrderBy = "Id DESC")]
        public PersonalComputer PC { get; set; }
    }

    [DbTable("PCs")]
    public class PersonalComputer : DbObjectModel<PersonalComputer>
    {
        [Length(50)]
        public string Name { get; set; }

        [BelongsTo, DbColumn("Person_Id")]
        public Person Owner { get; set; }
    }

    [DbTable("Books")]
    public class Book : DbObjectModel<Book>
    {
        [Length(50)]
        public string Name { get; set; }

        [BelongsTo, DbColumn("Category_Id")]
        public Category Category { get; set; }
    }

    [DbTable("Categories")]
    public class Category : DbObjectModel<Category>
    {
        [Length(50)]
        public string Name { get; set; }

        [HasMany(OrderBy = "Id")]
        public IList<Book> Books { get; private set; }
    }

    public class Article : DbObjectModel<Article>
    {
        public string Name { get; set; }

        [HasAndBelongsToMany(OrderBy = "Id")]
        public IList<Reader> Readers { get; private set; }
    }

    public class Reader : DbObjectModel<Reader>
    {
        public string Name { get; set; }

        [HasAndBelongsToMany(OrderBy = "Id")]
        public IList<Article> Articles { get; private set; }
    }
}
