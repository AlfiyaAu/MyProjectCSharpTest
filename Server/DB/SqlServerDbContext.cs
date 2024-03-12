using BlazorWebAssemblyProjectTest.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorWebAssemblyProjectTest.Server.DB;

namespace BlazorWebAssemblyProjectTest.Server.DB
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SelfType> SelfTypes { get; set; }

        public SqlServerDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
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

            SelfType[] types = new SelfType[]
            {
                new SelfType { Id = 1, Name = "SelfType 1" },
                new SelfType { Id = 2, Name = "SelfType 2" },
                new SelfType { Id = 3, Name = "SelfType 3" }
            };
            modelBuilder.Entity<SelfType>().HasData(types);

            List<Answer> answers = new List<Answer>
            {
                new Answer {Id = 01, QuestionId = 1, Name = "Answer 1", SelfTypeId = 1},
                new Answer {Id = 02, QuestionId = 1, Name = "Answer 2", SelfTypeId = 2},
                new Answer {Id = 03, QuestionId = 1, Name = "Answer 3", SelfTypeId = 3},
                new Answer {Id = 04, QuestionId = 2, Name = "Answer 4", SelfTypeId = 1},
                new Answer {Id = 05, QuestionId = 2, Name = "Answer 5", SelfTypeId = 2},
                new Answer {Id = 06, QuestionId = 2, Name = "Answer 6", SelfTypeId = 3}
            };
            modelBuilder.Entity<Answer>().HasData(answers);
        }
    }
}
