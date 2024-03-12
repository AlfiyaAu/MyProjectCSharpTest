using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblyProjectTest.Shared
{
    public class SelfType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserSelfType
    {
        public int Id { get; set; }
        public float Percent { get; set; }
        public string Name { get; set; }
    }
}
