using BlazorWebAssemblyProjectTest.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorWebAssemblyProjectTest.Server.DB;

namespace BlazorWebAssemblyProjectTest.Server.DB
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public SqlServerDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Question[] questions = new Question[3]
            {
                new Question {Id = 1, Name = "Question 1", Type= 01},
                new Question {Id = 2, Name = "Question 2", Type= 02},
                new Question {Id = 3, Name = "Question 3", Type= 03}
            };
            modelBuilder.Entity<Question>().HasData(questions);
        }
    }
}
