using System;
using Lephone.Extra;
using OrmCommon;
using Lephone.Data;

namespace OrmInitDatabase
{
    class Program
    {
        static void Main()
        {
            Init();
        }

        private static void Init()
        {
            CreateTables();
            InitEnumTable();
            InitMKey();
            InitMyData();
            InitTheAge();
            InitUser();
            InitPersonAndPc();
            InitCategoryAndBook();
            Console.WriteLine("**********************************");
            Console.WriteLine("All Done! Press Enter to exit.");
        }

        private static void CreateTables()
        {
            DbEntry.DropAndCreate(typeof(LephoneEnum));
            DbEntry.DropAndCreate(typeof(MKey));
            DbEntry.DropAndCreate(typeof(SampleData));
            DbEntry.DropAndCreate(typeof(TheAge));
            DbEntry.DropAndCreate(typeof(User));
            DbEntry.DropAndCreate(typeof(Person));
            DbEntry.DropAndCreate(typeof(PersonalComputer));
            DbEntry.DropAndCreate(typeof(Category));
            DbEntry.DropAndCreate(typeof(Book));
            DbEntry.DropAndCreate(typeof(Article));
            DbEntry.DropAndCreate(typeof(Reader));
            DbEntry.DropAndCreate(typeof(DateAndTime));
            DbEntry.CreateCrossTable(typeof(Article), typeof(Reader));
        }

        private static void InitEnumTable()
        {
            DbEntry.Insert(new LephoneEnum(0, "Manager", 2));
            DbEntry.Insert(new LephoneEnum(0, "Worker", null));
            DbEntry.Insert(new LephoneEnum(1, "Array", null));
            DbEntry.Insert(new LephoneEnum(1, "Link List", null));
            DbEntry.Insert(new LephoneEnum(1, "Hash Table", null));
            DbEntry.Insert(new LephoneEnum(2, "Low", null));
            DbEntry.Insert(new LephoneEnum(2, "Normal", null));
            DbEntry.Insert(new LephoneEnum(2, "High", null));
        }

        private static void InitMKey()
        {
            DbEntry.Insert(new MKey("bb", 33, false));
        }

        private static void InitMyData()
        {
            SampleData.New("( 1)liang lifeng", UserRole.Manager, DateTime.Parse("2004-2-27"), false, null).Save();
            SampleData.New("( 2)liang lifeng", UserRole.Manager, DateTime.Parse("2005-1-10"), true, null).Save();
            SampleData.New("( 3)liang lifeng", UserRole.Client, DateTime.Parse("2005-2-18"), false, null).Save();
            SampleData.New("( 4)liang lifeng", UserRole.Worker, DateTime.Parse("2005-3-1"), true, null).Save();
            SampleData.New("( 5)liang lifeng", UserRole.Client, DateTime.Parse("2005-5-15"), false, null).Save();
            SampleData.New("( 6)liang lifeng", UserRole.Client, DateTime.Parse("2005-7-15"), false, null).Save();
            SampleData.New("( 7)liang lifeng", UserRole.Client, DateTime.Parse("2005-8-16"), true, 1).Save();
            SampleData.New("( 8)liang lifeng", UserRole.Manager, DateTime.Parse("2005-9-23"), false, 2).Save();
            SampleData.New("( 9)liang lifeng", UserRole.Worker, DateTime.Parse("2005-10-29"), false, 3).Save();
        }

        private static void InitTheAge()
        {
            DbEntry.Insert(new TheAge(14));
            DbEntry.Insert(new TheAge(66));
            DbEntry.Insert(new TheAge(44));
            DbEntry.Insert(new TheAge(33));
        }

        private static void InitUser()
        {
            DbEntry.Insert(new User("tom", "123", DateTime.Parse("2005-5-1")));
            DbEntry.Insert(new User("john", "456", DateTime.Parse("2005-6-1")));
            DbEntry.Insert(new User("mike", "789", DateTime.Parse("2005-7-1")));
        }

        private static void InitPersonAndPc()
        {
            DbEntry.Save(new Person {Name = "Tom"});
            var p = new Person {Name = "Jerry", PC = new PersonalComputer {Name = "IBM"}};
            DbEntry.Save(p);
            p = new Person {Name = "Mike", PC = new PersonalComputer {Name = "DELL"}};
            DbEntry.Save(p);
            p.PC = new PersonalComputer {Name = "HP"};
            DbEntry.Save(p);
        }

        private static void InitCategoryAndBook()
        {
            DbEntry.Save(new Category {Name = "Tech"});
            var c = new Category {Name = "Game"};
            c.Books.Add(new Book {Name = "Diablo"});
            DbEntry.Save(c);
            var c1 = new Category {Name = "Tour"};
            c1.Books.Add(new Book {Name = "Beijing"});
            c1.Books.Add(new Book {Name = "Shanghai"});
            DbEntry.Save(c1);
            c.Books.Clear();
            c.Books.Add(new Book {Name = "Pal95"});
            c.Books.Add(new Book {Name = "Wow"});
            DbEntry.Save(c);
        }
    }
}