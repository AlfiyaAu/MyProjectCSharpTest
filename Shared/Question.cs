using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyProjectTest.Shared
{
	public class Question
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Type { get; set; }
	}

	public class QuestionPart
	{
		public int NumberPage { get; set; }
		public int CurrentPage { get; set; }
		public IEnumerable<Question> Question { get; set; }
	}
}
