using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TP4.Models;
namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        static private UniversityContext universityContextInstance = null;
        static public int count = 0;
        private UniversityContext(DbContextOptions o) : base(o)
        {
            count++;
        }
        static public UniversityContext Instantiate_UniversityContext()
        {
            if (universityContextInstance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite(@"Data Source=C:\2022 GL3 .NET Framework TP4 - SQLite database.db");
                universityContextInstance = new UniversityContext(optionsBuilder.Options);
                return universityContextInstance;
            }
            else
            {
                return universityContextInstance;
            }
        }
    }
}
