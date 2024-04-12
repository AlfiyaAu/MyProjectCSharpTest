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
        public float Percent1 { get; set; }
        public float Percent2 { get; set; }
        public float Percent3 { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class UserST
    {
        public int[] SelfType { get; set; }
    }
}
