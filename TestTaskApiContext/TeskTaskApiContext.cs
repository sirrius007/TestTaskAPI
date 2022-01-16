using Microsoft.EntityFrameworkCore;
using TestTaskApi.Domain.Core;

namespace TestTaskApi.Infrastructure.Data
{
    public class TestTaskApiContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public TestTaskApiContext(DbContextOptions<TestTaskApiContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .HasIndex(p => new { p.FirstName, p.LastName }).IsUnique();
        }
    }
}
