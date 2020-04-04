using System.Collections.Generic;
using System.Web.Mvc;
using WebDemo.Models;

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
            Person p = new Person();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Info(Person p)
        {
            ViewBag.Message = p.FirstName + " " + p.LastName;
            Context Pmodel = new Context();
            Pmodel.Person_Table.Add(new Person_Table { FirstName = p.FirstName, LastName = p.LastName, Gender = p.Gender});
            Pmodel.SaveChanges();
            return View(p);
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Get_Grid()
        {
            PersonViewModel personview = new PersonViewModel();
            personview.persons = new List<Person>();
            Context Pmodel = new Context();
            foreach (Person_Table person in Pmodel.Person_Table)
            {
                Person tmp = new Person(person.FirstName, person.LastName, person.Gender);
                personview.persons.Add(tmp);
            }
            return View(personview);
        }


    }
}