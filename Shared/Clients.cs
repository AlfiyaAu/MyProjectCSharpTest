using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorWebAssemblyProjectTest.Shared
{
    public class Clients
    {
        [Key]
        public string IdClient { get; set; }
        public string Name { get; set; }
    }
}
