using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_EntityFramework
{
    public enum Color { Unset = 0, Red, Indigo, Purple, Algerian, Green, Lavender}

    // Person to Cars is 1 to many

    public interface ISchoolDbContext4
    {
        DbSet<Person> People { get; set; }
        DbSet<Car> Cars { get; set; }
    }

    public class SchoolDbContext4 : DbContext, ISchoolDbContext4
    {
        public SchoolDbContext4() { }

        public SchoolDbContext4(DbConnection dbConnection) : base(dbConnection, true)
        { // in Java super(dbConnection, true)
            
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }
    }

    class Program
    {
        static void AddPerson(Person p2)
        {
            Person p = new Person
            {
                First = "David",
                Last = "Langstein",
            };
            p.Cars = new List<Car>();
            p.Cars.Add(new Car
            {
                Color = Color.Algerian,
                Make = "Mazda",
                Model = "911"

            });
            using (var db = new SchoolDbContext4())
            {
                db.People.Add(p);
                db.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            //if (new String("Bob".ToCharArray()) == new String("Bob".ToCharArray()))
            //    Console.WriteLine("Really?");
                
            using (var db = new SchoolDbContext4())
            {
                //var david = db.People.Include(p=>p.Cars) //loads Cars despite lazy loading
                //    .FirstOrDefault(p => p.First.StartsWith("Dav"));
                //if (david == null)
                //{
                //    // log 
                //}
                //david.Cars.Add(new Car {Color = Color.Green, Make = "Ferrarri", Model = "912"});
                //david.First = "Dave"; // EF tracks changes and will save them

                var c = new Car() {Color = Color.Lavender};

                db.Cars.Add(c);

                db.SaveChanges();

               // Console.WriteLine(david);
            }
        }


        static void Main2(string[] args)
        {
            using (var db = new SchoolDbContext4()) 
            {
                Console.WriteLine(db.People.Count()); // on first access will create database
                //for (int i = 0; i < 10; i++)
                //{
                //    var p = new Person
                //    {
                //        First = "Abe",
                //        Last = "Lincoln",
                //        Suffix = i + 1 + ""
                //    };
                //    db.People.Add(p);
                //}
                //db.SaveChanges();
                Console.WriteLine(db.People.Count()); // on first access will create database

                var AnonObjectList = db.People
                    .Select(p222 => new 
                    {
                        FullName = p222.Last + ", " + p222.First,
                        Suffix = p222.Suffix,
                        Useless = 5
                    }).ToList();

                foreach (var qqqq in AnonObjectList)
                {
                    Console.WriteLine(qqqq.FullName);
                }

                //var _3ers = db.People
                //    .Where(p => p.Suffix.ToCharArray().Length == 1);  // will fail since when LINQ query is realized it will be converted to SQL, and SQL does not support toCharArray
                //foreach (var p in _3ers)
                //{
                //    Console.WriteLine(p.Suffix);
                //}
                Console.ReadLine();
            }
        }
    }
}
