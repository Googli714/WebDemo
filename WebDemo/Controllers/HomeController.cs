using System.Collections.Generic;
using System.Web.Mvc;
using WebDemo.Models;
using System.Linq;
using System.Data;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Info()
        {
            RegistrationViewModel p = new RegistrationViewModel();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Info(RegistrationViewModel p)
        {
            ViewBag.Message = p.FirstName + " " + p.LastName;
            Context Pmodel = new Context();
            Users_Table users = new Users_Table { Username = p.Username, Password=p.Password, Email = p.Email };
            List<Users_Table> userlist = new List<Users_Table>();
            userlist.Add(users);
            //Pmodel.Users_Table.Add(users);
            Pmodel.Person_Table.Add(new Person_Table { FirstName = p.FirstName, LastName = p.LastName, Gender = p.Gender, Users_Table = userlist});
            Pmodel.SaveChanges();
            return RedirectToAction("Get_Grid", "Home");
        }

        [HttpGet]
        public ActionResult Get_Grid()
        {
            PersonViewModel personview = new PersonViewModel();
            personview.persons = new List<PersonModel>(); 
            Context Pmodel = new Context();
            foreach (Person_Table person in Pmodel.Person_Table)
            {
                PersonModel tmp = new PersonModel(person.FirstName, person.LastName, person.Gender, person.Users_Table == null || person.Users_Table.Count == 0 ? "" : person.Users_Table.FirstOrDefault().Username);
                personview.persons.Add(tmp);
            }
            return View(personview);
        }

        public ActionResult Edit(int Id)
        {
            
        }




    }
}