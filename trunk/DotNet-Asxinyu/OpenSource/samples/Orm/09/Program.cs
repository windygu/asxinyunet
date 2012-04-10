using System;
using OrmCommon;
using Lephone.Data;

namespace Orm9
{
    class Program
    {
        static void Main()
        {
            // RebuildTables();

            Console.WriteLine("Relationship objects and Auto create table");
            Console.WriteLine("============Has One============");
            ShowHasOne(DbEntry.GetObject<Person>(1));
            ShowHasOne(DbEntry.GetObject<Person>(2));
            ShowHasOne(DbEntry.GetObject<Person>(3));

            Console.WriteLine("============Has Many===========");
            ShowHasMany(DbEntry.GetObject<Category>(1));
            ShowHasMany(DbEntry.GetObject<Category>(2));
            ShowHasMany(DbEntry.GetObject<Category>(3));

            Console.WriteLine("===========Update One==========");
            var p = DbEntry.GetObject<Person>(2);
            Console.WriteLine(">>Before:");
            ShowHasOne(p);
            p.Name = "Neo";
            p.PC.Name = "Matrix";
            DbEntry.Save(p);
            Console.WriteLine(">>After:");
            ShowHasOne(DbEntry.GetObject<Person>(2));
            Console.WriteLine(">>Delete:");
            DbEntry.Delete(p);
            ShowHasOne(DbEntry.GetObject<Person>(2));

            Console.WriteLine("==========Update Many==========");
            var c = DbEntry.GetObject<Category>(3);
            Console.WriteLine(">>Before:");
            ShowHasMany(c);
            Console.WriteLine(">>After:");
            c.Name = "Sport";
            c.Books[0].Name = "Kungfu";
            c.Books[1].Name = "Dodge the bullets";
            DbEntry.Save(c);
            ShowHasMany(DbEntry.GetObject<Category>(3));
            Console.WriteLine(">>Delete:");
            DbEntry.Delete(c);
            ShowHasMany(DbEntry.GetObject<Category>(3));

            Console.WriteLine("====Has Many And Belongs To====");
            var a = new Article {Name = "fly away"};
            a.Readers.Add(new Reader {Name = "Kingkong"});
            a.Readers.Add(new Reader {Name = "Spiderman"});
            a.Save();
            var a1 = Article.FindById(a.Id);
            ShowHasManyAndBelongsTo(a1);

            Console.WriteLine("======Restoring Tables...======");
            RebuildTables();
            Console.WriteLine("============The End============");
            Console.WriteLine("Done! Press Enter to exit.");
        }

        private static void RebuildTables()
        {
            DbEntry.DropAndCreate(typeof(Person));
            DbEntry.DropAndCreate(typeof(PersonalComputer));
            DbEntry.DropAndCreate(typeof(Category));
            DbEntry.DropAndCreate(typeof(Book));
            DbEntry.DropAndCreate(typeof(Article));
            DbEntry.DropAndCreate(typeof(Reader));
            DbEntry.CreateCrossTable(typeof(Article), typeof(Reader));
            DbEntry.Save( new Person {Name = "Tom"});
            var p = new Person {Name = "Jerry", PC = new PersonalComputer {Name = "IBM"}};
            DbEntry.Save(p);
            p = new Person {Name = "Mike", PC = new PersonalComputer {Name = "DELL"}};
            DbEntry.Save(p);
            p.PC = new PersonalComputer {Name = "HP"};
            DbEntry.Save(p);
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

        private static void ShowHasMany(Category c)
        {
            if (c == null)
            {
                Console.WriteLine("(NULL Category)");
            }
            else
            {
                Console.Write(c.Name);
                Console.WriteLine("=>");
                foreach (var b in c.Books)
                {
                    Console.WriteLine("\t{0}", b.Name);
                }
            }
        }

        private static void ShowHasManyAndBelongsTo(Article c)
        {
            if (c == null)
            {
                Console.WriteLine("(NULL Article)");
            }
            else
            {
                Console.Write(c.Name);
                Console.WriteLine("=>");
                foreach (var b in c.Readers)
                {
                    Console.WriteLine("\t{0}", b.Name);
                }
            }
        }

        private static void ShowHasOne(Person p)
        {
            if (p == null)
            {
                Console.WriteLine("(NULL Person)");
            }
            else
            {
                Console.Write(p.Name);
                Console.Write("=>\t");
                Console.WriteLine(p.PC != null ? p.PC.Name : "(NULL)");
            }
        }
    }
}
