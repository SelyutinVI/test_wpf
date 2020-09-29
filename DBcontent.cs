using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.Models;

namespace WPF_TEST
{
    class DBcontent
    {
        public static void initial(AppDB db)
        {
            if (!db.Companies.Any())
            {
                db.Companies.AddRange(_Companies.Select(c=>c.Value));
            }
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new MyUsers
                    {
                        Name = "Иванов Иван Иванович",
                        Login = "Ivanov",
                        Password = "Ivanov123321",
                        Company = _companies["Первая компания"]
                    },
                    new MyUsers
                    {
                        Name = "Петров Петр Петрович",
                        Login = "Petrov",
                        Password = "Petrov456654",
                        Company = _companies["Третья компания"]
                    },
                    new MyUsers
                    {
                        Name = "Николаев Николай Николаевич",
                        Login = "Nikolaev",
                        Password = "Nikolaev789987",
                        Company = _companies["Первая компания"]
                    },
                    new MyUsers
                    {
                        Name = "Васильев Василий Васильевич",
                        Login = "Vasilev",
                        Password = "Vasilev198213",
                        Company = _companies["Третья компания"]
                    },
                    new MyUsers
                    {
                        Name = "Никулин Дмитрий Александрович",
                        Login = "Nikulin",
                        Password = "Nikulin768743",
                        Company = _companies["Вторая компания"]
                    }
                );
            }
            db.SaveChanges();
        }

        private static Dictionary<String, Company> _companies;
        public static Dictionary<String, Company> _Companies
        {
            get {
                if (_companies == null)
                {
                    var list = new Company[] {                   
                    new Company
                    {
                        Name = "Первая компания",
                        Status = "Заключен"
                    },
                    new Company
                    {
                        Name = "Вторая компания",
                        Status = "Ещё не заключен"
                    },
                    new Company
                    {
                        Name = "Третья компания",
                        Status = "Расторгнут"
                    }
                    };

                    _companies = new Dictionary<string, Company>();
                    foreach (Company e in list)
                        _companies.Add(e.Name,e);
                }
                return _companies;                   
                }
             
        }
    }
}
