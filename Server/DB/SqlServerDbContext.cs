using BlazorWebAssemblyProjectTest.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorWebAssemblyProjectTest.Server.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BlazorWebAssemblyProjectTest.Server.DB
{
    public class SqlServerDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SelfType> SelfTypes { get; set; }
        //public DbSet<SelfType> Users { get; set; }

        //public DbSet<TipeS> TipeS { get; set; }

        public DbSet<UserSelfType> UserSelfTypes { get; set; }
        //public DbSet<Admin> Admins { get; set; }

        public SqlServerDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    Question[] questions = new Question[4]
        //    {
        //        new Question {Id = 1, Name = "Question 1", Type= 1},
        //        new Question {Id = 2, Name = "Question 2", Type= 1},
        //        new Question {Id = 3, Name = "Question 3", Type= 1},
        //        new Question {Id = 4, Name = "Question 4", Type= 1}
        //    };
        //    modelBuilder.Entity<Question>().HasData(questions);

        //    SelfType[] types = new SelfType[]
        //    {
        //        new SelfType { Id = 1, Name = "SelfType 1" },
        //        new SelfType { Id = 2, Name = "SelfType 2" },
        //        new SelfType { Id = 3, Name = "SelfType 3" }
        //    };
        //    modelBuilder.Entity<SelfType>().HasData(types);

        //    List<Answer> answers = new List<Answer>
        //    {
        //        new Answer {Id = 01, QuestionId = 1, Name = "Answer 1", SelfTypeId = 1},
        //        new Answer {Id = 02, QuestionId = 1, Name = "Answer 2", SelfTypeId = 2},
        //        new Answer {Id = 03, QuestionId = 1, Name = "Answer 3", SelfTypeId = 3},
        //        new Answer {Id = 04, QuestionId = 2, Name = "Answer 4", SelfTypeId = 1},
        //        new Answer {Id = 05, QuestionId = 2, Name = "Answer 5", SelfTypeId = 2},
        //        new Answer {Id = 06, QuestionId = 2, Name = "Answer 6", SelfTypeId = 3},
        //        new Answer {Id = 07, QuestionId = 3, Name = "Answer 7", SelfTypeId = 1},
        //        new Answer {Id = 08, QuestionId = 3, Name = "Answer 8", SelfTypeId = 2},
        //        new Answer {Id = 09, QuestionId = 3, Name = "Answer 9", SelfTypeId = 3},
        //        new Answer {Id = 10, QuestionId = 4, Name = "Answer 10", SelfTypeId = 1},
        //        new Answer {Id = 11, QuestionId = 4, Name = "Answer 11", SelfTypeId = 2},
        //        new Answer {Id = 12, QuestionId = 4, Name = "Answer 12", SelfTypeId = 3}
        //    };
        //    modelBuilder.Entity<Answer>().HasData(answers);

        //   // Admin[] adm = new Admin[]
        //   //{
        //   //    new Admin {Id = 1, Login ="aaa", Password = "123!!!aa"},
        //   //};
        //   // modelBuilder.Entity<Admin>().HasData(adm);

        //    // TipeS[] tipe = new TipeS[]
        //    //{
        //    //     new TipeS { Id = 1, Name1 = "SelfType1", Persent = 25},

        //    //};
        //    // modelBuilder.Entity<TipeS>().HasData(tipe);

        //    //    UserSelfType[] userST = new UserSelfType[]
        //    //   {
        //    //        new UserSelfType { Id = 1, Percent = 25, Name = "SelfType1",},

        //    //   };
        //    //    modelBuilder.Entity<TipeS>().HasData(userST);
        //}
    }
}
