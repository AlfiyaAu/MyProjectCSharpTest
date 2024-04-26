using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyProjectTest.Shared;
using static System.Collections.Specialized.BitVector32;
using BlazorWebAssemblyProjectTest.Server.DB;
using System.Linq;
using BlazorWebAssemblyProjectTest.Server;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage.StorageOptions;
using System;
using Blazored.LocalStorage;
using System.Net.Http.Json;




namespace BlazorWebAssemblyProjectTest.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        //////private static List<Question> questions = new List<Question>
        //////{
        //////    new Question {Id = 1, Name = "Question 1", Type= 01},
        //////    new Question {Id = 2, Name = "Question 2", Type= 02},
        //////    new Question {Id = 3, Name = "Question 3", Type= 03}
        //////};

        //////      private static List<Answer> answers = new List<Answer>
        //////      {
        //////          new Answer {Id = 01, QuestionId = 1, Name = "Answer 1", SelfTypeId= 1},
        //////          new Answer {Id = 02, QuestionId = 1, Name = "Answer 2", SelfTypeId= 2},
        //////          new Answer {Id = 03, QuestionId = 1, Name = "Answer 3", SelfTypeId= 3},
        //////          new Answer {Id = 04, QuestionId = 2, Name = "Answer 4", SelfTypeId= 4},
        //////          new Answer {Id = 05, QuestionId = 2, Name = "Answer 5", SelfTypeId= 5},
        //////      };

        private readonly SqlServerDbContext _context;

        public QuestionController(SqlServerDbContext context)
        {
            _context = context;
        }

        [HttpGet("{number}")]
        public ActionResult<QuestionPartInfo> GetNextQuestion(int number)
        {
            var question = _context.Questions.Skip(number).FirstOrDefault(); // ищем вопрос в бд
            if (question == null) // если не нашли выдадим ошибку
            {
                return NotFound();
            }
            var response = new QuestionPartInfo() // формируем ответ
            {
                CurrentId = number + 1,
                CountId = _context.Questions.Count(),
                Question = question,
                Answers = _context.Answers.Where(x => x.QuestionId == question.Id)
            };
            return Ok(response); // отсылаем ответ

            ////var a = _context.Questions.Where(x => x.Id == page);
            ////int size = 1;
            ////var put = new QuestionPart()
            ////{
            ////	CurrentPage = page,
            ////	NumberPage = 3,
            ////	Question = a,
            ////};
            ////return Ok(put);
        }

        [HttpPost("Quest")]
        public ActionResult<Question> PostQuestions(Question quest)
        {
            //var lastQuest = _context.Questions.OrderBy(quest => quest).LastOrDefault();
            //quest.Id = quest.Id + 1;
            _context.Questions.Add(quest);
            _context.SaveChanges();
            return Ok(quest);
        }


        [HttpPost("final")]
        public ActionResult<UserSelfType> FinalTest([FromBody] UserSelfType userSelfType)
        {
            _context.UserSelfTypes.Add(userSelfType);
            _context.SaveChanges();

            return Ok(userSelfType);
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserSelfType>> Get()
        {
            {
                return Ok(_context.UserSelfTypes);
            }
        }

        [HttpPost("Client")]
        public ActionResult<Clients> PostClient(Clients client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return Ok(client);
        }

        [HttpGet("getClient")]
        public ActionResult<IEnumerable<Clients>> GetClient()
        {
            {
                return Ok(_context.Clients);
            }
        }

    }

}

