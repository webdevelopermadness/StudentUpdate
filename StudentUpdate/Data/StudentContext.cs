using Microsoft.EntityFrameworkCore;
using StudentUpdate.Model;

namespace StudentUpdate.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
