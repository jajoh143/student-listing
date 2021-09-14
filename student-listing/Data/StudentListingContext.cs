using Microsoft.EntityFrameworkCore;
using student_listing.Data.Models;

namespace student_listing.Data.DataContext
{
    public class StudentListingContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\Sql2016;Database=StudentListing;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
