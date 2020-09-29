using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Models
{
    class MyUsers
    {
            public int id { get; set; }
            public String Name { get; set; }
            public String Login { get; set; }
            public String Password { get; set; }
            public Company Company { get; set; }
    }
}
