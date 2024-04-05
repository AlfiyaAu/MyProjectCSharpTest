using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyProjectTest.Shared;
using static System.Collections.Specialized.BitVector32;
using BlazorWebAssemblyProjectTest.Server.DB;
using System.Linq;
using BlazorWebAssemblyProjectTest.Server;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyProjectTest.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        //private static List<Question> questions = new List<Question>
        //{
        //    new Question {Id = 1, Name = "Question 1", Type= 01},
        //    new Question {Id = 2, Name = "Question 2", Type= 02},
        //    new Question {Id = 3, Name = "Question 3", Type= 03}
        //};

        //      private static List<Answer> answers = new List<Answer>
        //      {
        //          new Answer {Id = 01, QuestionId = 1, Name = "Answer 1", SelfTypeId= 1},
        //          new Answer {Id = 02, QuestionId = 1, Name = "Answer 2", SelfTypeId= 2},
        //          new Answer {Id = 03, QuestionId = 1, Name = "Answer 3", SelfTypeId= 3},
        //          new Answer {Id = 04, QuestionId = 2, Name = "Answer 4", SelfTypeId= 4},
        //          new Answer {Id = 05, QuestionId = 2, Name = "Answer 5", SelfTypeId= 5},
        //      };

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

            //var a = _context.Questions.Where(x => x.Id == page);
            //int size = 1;
            //var put = new QuestionPart()
            //{
            //	CurrentPage = page,
            //	NumberPage = 3,
            //	Question = a,
            //};
            //return Ok(put);
        }

        [HttpPost]
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
            //var userST1 = new UserSelfType()
            //{
            //    Percent = selfTypes,
            //    Name = null
            //};
            _context.UserSelfTypes.Add(userSelfType);
            _context.SaveChanges();

            return Ok(userSelfType);
        }

        // здесь должна быть логика подсчёта и сохранение истории

        //int t1 = 0;
        //int t2 = 0;
        //int t3 = 0;

        //foreach (var answer in userAnswers)
        //{
        //    if (answer.SelfTypeId == 1)
        //    {

        //    }
        //    if (answer.SelfTypeId == 2)
        //    {

        //    }
        //    if (answer.SelfTypeId == 3)
        //    {

        //    }
        //}




        //[HttpPost]
        //public ActionResult<UserSelfType> Post([FromBody] UserSelfType[] userSelfTypes)
        //{
        //    _context.UserSelfType.Add();

        //[HttpPost]
        //public ActionResult<Product> Post([FromBody] Product product)
        //    {
        //        var last = products.LastOrDefault();
        //        product.Id = last.Id + 1;
        //        products.Add(product);
        //        return Ok(product);


        //int t1 = 0;
        //int t2 = 0;
        //int t3 = 0;

        //foreach (var answer in userAnswers)
        //{
        //    if (answer.SelfTypeId == 1)
        //    {

        //    }
        //    if (answer.SelfTypeId == 2)
        //    {

        //    }
        //    if (answer.SelfTypeId == 3)
        //    {

        //    }
        //}

        //    return Ok(2);
        //}



        //[HttpGet]
        //public ActionResult<IEnumerable<Answer>> Get(int id)
        //{
        //    var a = _context.Questions.SingleOrDefault(x => x.Id == 2);
        //    var b = _context.Answers.Where(x => x.QuestionId == a.Id);

        //    return Ok(b);
    }
        //[HttpGet("id/{idQ}")]
        //public ActionResult<Answer> GetAnswer(int idq)
        //{


        //	foreach (var ans in answers.Answer where)
        //		{

        //	}
        //}

        //[HttpPost]
        //public ActionResult<User> Post(User user)
        //{
        //    users.Add(user);
        //    return Ok(user);
        //}

    }

