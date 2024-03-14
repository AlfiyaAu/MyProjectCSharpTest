using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyProjectTest.Shared;
using static System.Collections.Specialized.BitVector32;
using BlazorWebAssemblyProjectTest.Server.DB;
using System.Linq;
using BlazorWebAssemblyProjectTest.Server;

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

        [HttpGet("{page}")]
		public ActionResult<QuestionPart> GetWithPage(int page)
		{
            var a = _context.Questions.Where(x => x.Id == page);
            int size = 1;
			var put = new QuestionPart()
			{
				CurrentPage = page,
				NumberPage = 3,
				Question = a,
            };
			return Ok(put);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Answer>> Get(int id)
        {
            var a = _context.Questions.SingleOrDefault(x => x.Id == 2);
            var b = _context.Answers.Where(x => x.QuestionId == a.Id);

            return Ok(b);
        }
        //[HttpGet("id/{idQ}")]
        //public ActionResult<Answer> GetAnswer(int idq)
        //{


        //	foreach (var ans in answers.Answer where)
        //		{

        //	}
        //}

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            users.Add(user);
            return Ok(user);
        }
    }
}
