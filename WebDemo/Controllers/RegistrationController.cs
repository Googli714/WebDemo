using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using WebDemo.Filters;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    [CustomAuthenticationFilter]
    public class RegistrationController : Controller
    {
        [HttpGet]
        [CustomAuthorize("Administrator")]
        public ActionResult Add()
        {
            RegistrationViewModel p = new RegistrationViewModel();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize("Administrator")]
        public ActionResult Add(RegistrationViewModel p)
        {
            ViewBag.Message = p.FirstName + " " + p.LastName;
            Context Pmodel = new Context();
            Users_Table users = new Users_Table { Username = p.Username, Password = p.Password, Email = p.Email, RoleId = p.RoleId };
            List<Users_Table> userlist = new List<Users_Table>();
            userlist.Add(users);
            //Pmodel.Users_Table.Add(users);
            Pmodel.Person_Table.Add(new Person_Table { FirstName = p.FirstName, LastName = p.LastName, Gender = p.Gender, Users_Table = userlist });
            Pmodel.SaveChanges();
            return RedirectToAction("GetList", "Registration");
        }

        [HttpGet]
        [CustomAuthorize("Administrator", "Editor", "Guest")]
        public ActionResult GetList()
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

        [HttpPost]
        [CustomAuthorize("Administrator", "Editor", "Guest")]
        public ActionResult GetList(PersonViewModel pvm)
        {
            PersonModel filter = pvm.FilterPerson;
            Person_Table pt = new Person_Table();
            Context context = new Context();
            var persons = context.Person_Table.Where(x => (filter.FirstName == null ? true : x.FirstName.Contains(filter.FirstName))
                && (filter.LastName == null ? true : x.LastName.Contains(filter.LastName))
                && (filter.Gender == null ? true : x.Gender == filter.Gender)
                && (filter.Username == null ? true : x.Users_Table.FirstOrDefault().Username.Contains(filter.Username)));
            PersonViewModel k = new PersonViewModel();
            foreach (Person_Table person in persons)
            {
                PersonModel tmp = new PersonModel(person.Id, person.FirstName, person.LastName, person.Gender, person.Users_Table == null || person.Users_Table.Count == 0 ? "" : person.Users_Table.FirstOrDefault().Username);
                k.persons.Add(tmp);
            }

            return View(k);
        }

        [CustomAuthorize("Administrator", "Editor")]
        public ActionResult Edit(int Id)
        {
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
                Username = ut.Username,
                RoleId = ut.RoleId == null ? 2 : (int)ut.RoleId
            };

            return View(rvm);
        }

        [HttpPost]
        [CustomAuthorize("Administrator", "Editor")]
        public ActionResult Edit(RegistrationViewModel rvm)
        {
            Context context = new Context();
            Person_Table pt = context.Person_Table.Where(u => u.Id == rvm.Id).FirstOrDefault();
            Users_Table ut = pt.Users_Table.FirstOrDefault() == null ? new Users_Table() : pt.Users_Table.FirstOrDefault();
            ut.Username = rvm.Username;
            ut.Password = rvm.Password;
            ut.Email = rvm.Email;
            pt.FirstName = rvm.FirstName;
            pt.LastName = rvm.LastName;
            pt.Gender = rvm.Gender;
            ut.RoleId = rvm.RoleId;
            pt.Users_Table.Add(ut);
            context.SaveChanges();
            return RedirectToAction("GetList", "Registration");
        }
    }
}