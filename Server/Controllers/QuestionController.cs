using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyProjectTest.Shared;
using static System.Collections.Specialized.BitVector32;

namespace BlazorWebAssemblyProjectTest.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class QuestionController : ControllerBase
	{
		private static List<Question> questions = new List<Question>
		{
			new Question {Id = 1, Name = "Question 1", Type= 01},
			new Question {Id = 2, Name = "Question 2", Type= 02},
			new Question {Id = 3, Name = "Question 3", Type= 03}
		};

        private static List<Answer> answers = new List<Answer>
        {
            new Answer {Id = 01, QuestionId = 1, Name = "Answer 1", SelfTypeId= "TypeSelf 1"},
            new Answer {Id = 02, QuestionId = 1, Name = "Answer 2", SelfTypeId= "TypeSelf 2"},
            new Answer {Id = 03, QuestionId = 1, Name = "Answer 3", SelfTypeId= "TypeSelf 3"},
            new Answer {Id = 04, QuestionId = 2, Name = "Answer 4", SelfTypeId= "TypeSelf 4"},
            new Answer {Id = 05, QuestionId = 2, Name = "Answer 5", SelfTypeId= "TypeSelf 5"},
        };


        [HttpGet("{page}")]
		public ActionResult<QuestionPart> GetWithPage(int page)
		{
			int size = 1;
			var put = new QuestionPart()
			{
				CurrentPage = page,
				NumberPage = questions.Count,
				Question = questions.Skip(page - 1).Take(size).ToArray()
			};
			return Ok(put);
		}

		//[HttpGet("id/{idQ}")]
		//public ActionResult<Answer> GetAnswer(int idq)
		//{
		//	var selectAnswer = answers.Where


		//	foreach (var ans in answers.Answer where)
		//		{

		//	}
		//}
	}
}
