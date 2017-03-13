using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_EntityFramework
{
    public class DbStatistics
    {
        private ISchoolDbContext4 _db;
        public DbStatistics(ISchoolDbContext4 db )
        {
            _db = db;
            
            PeopleCount = _db.People.Count();
            CarCount = _db.Cars.Count();
            // auto closed
        }
        public int PeopleCount { get; set; }
        public int CarCount { get; set; }

        public IEnumerable<Tuple<string, int>> CarsPerPerson
        {
            get
            {
                return _db.People
                    //    .Include(p => p.Cars)
                    .ToList()
                    .Select(p => new {Name = p.Last, CarCount = p.Cars.Count(c=>c.Make != null) })
                    .ToList()
                    .Select(o => new Tuple<string, int>(o.Name, o.CarCount));
            }
        }
    }
}