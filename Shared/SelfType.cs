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
        //public int Id { get; set; }
        public double Percent1 { get; set; }
        public double Percent2 { get; set; }
        public double Percent3 { get; set; }
        [Key]
        public string IdUser { get; set; }
        public string? Email { get; set; }
    }

    public class UserST
    {
        public int[] SelfType { get; set; }
    }
}
