using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Models
{
    class Company
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }
        [NotMapped]
        public List<String> sl { get; set; } = new List<string>() { "Заключен", "Расторгнут", "Ещё не заключен" };
    }
}
