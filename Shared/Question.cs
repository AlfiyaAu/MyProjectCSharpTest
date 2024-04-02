using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssemblyProjectTest.Shared
{
	public class Question
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Type { get; set; } //0 - one, 1 - more
    }

	public class QuestionPartInfo
	{
        public int CurrentId { get; set; }
        public int CountId { get; set; }
        public Question Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }

        //public int NumberPage { get; set; }
		//public int CurrentPage { get; set; }
		//public IEnumerable<Question> Question { get; set; }
    }
}
