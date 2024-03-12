using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyProjectTest.Shared
{
	public class Answer
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
        public string Name { get; set; }
		public int SelfTypeId { get; set; }
        [ForeignKey(nameof(SelfTypeId))]
        public SelfType SelfType { get; set; }

    }
    public class AnswerHistory
    {
        public int Id { get; set; }
    }
}
