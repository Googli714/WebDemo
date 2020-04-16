using System.Collections.Generic;
using System.Web.Mvc;
using WebDemo.Models;
using System.Linq;
using System.Data;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        #region example MVC
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        #endregion
        [HttpGet]
        public ActionResult Add()
        {
            RegistrationViewModel p = new RegistrationViewModel();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RegistrationViewModel p)
        {
            ViewBag.Message = p.FirstName + " " + p.LastName;
            Context Pmodel = new Context();
            Users_Table users = new Users_Table { Username = p.Username, Password = p.Password, Email = p.Email };
            List<Users_Table> userlist = new List<Users_Table>();
            userlist.Add(users);
            //Pmodel.Users_Table.Add(users);
            Pmodel.Person_Table.Add(new Person_Table { FirstName = p.FirstName, LastName = p.LastName, Gender = p.Gender, Users_Table = userlist });
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
                PersonModel tmp = new PersonModel(person.Id, person.FirstName, person.LastName, person.Gender, person.Users_Table == null || person.Users_Table.Count == 0 ? "" : person.Users_Table.FirstOrDefault().Username);
                personview.persons.Add(tmp);
            }
            return View(personview);
        }
        public ActionResult Edit(int Id)
        {
            Context context = new Context();
            Person_Table pw = context.Person_Table.Where(p => p.Id == Id).FirstOrDefault();
            Users_Table ut = context.Users_Table.Where(p => p.Id == Id).FirstOrDefault();
            RegistrationViewModel rw = new RegistrationViewModel(ut.Username, ut.Password, ut.Email, pw.FirstName, pw.LastName, pw.Gender);
            return View(rw);
            Context context = new Context();
            Person_Table pt = context.Person_Table.Where(o => o.Id == Id).FirstOrDefault();
            Users_Table ut = pt.Users_Table.FirstOrDefault() == null ? new Users_Table() : pt.Users_Table.FirstOrDefault();
            RegistrationViewModel rvm = new RegistrationViewModel
            {
                Id = pt.Id,
                Email = ut.Email,
                FirstName = pt.FirstName,
                Gender = pt.Gender,
                LastName = pt.LastName,
                Username = ut.Username
            };

            return View(rvm);
        }
        [HttpPost]
        public ActionResult Edit(RegistrationViewModel rvm)
        {
            return RedirectToAction("Get_Grid", "Home");
        }




    }
}