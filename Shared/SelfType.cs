using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssemblyProjectTest.Shared
{
    public class SelfType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserSelfType
    {
        [Key]
        public int Id { get; set; }
        public int Percent1 { get; set; }
        public int Percent2 { get; set; }
        public int Percent3 { get; set; }
        public string? Name { get; set; }
    }

    public class UserST
    {
        public int[] SelfType { get; set; }
    }
}
