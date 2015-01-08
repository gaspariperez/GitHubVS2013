using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FedoRomance.Data;
using FedoRomance.Data.Repositories;
using FedoRomance.Web.Api;
using FedoRomance.Web.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace FedoRomance.Web.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View();
        }
               
        public ActionResult LogIn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(HomeLogInModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = UserRepository.TestLogIn(model.Username, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Fel användarnamn eller lösernord.");
                return View();
            }

            FormsAuthentication.SetAuthCookie(model.Username, false);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Profile() {
            return View();
        }
        
        public ActionResult SearchResults() {
            return View();
        }

        public ActionResult Friends()
        {
            return View();
        }




        //Kanske dela här och skapa en egen controller?

        
        public void EditAndRegister() {
            var age = new List<SelectListItem>();
            var gender = new List<SelectListItem>();

            for (int i = 1; i <= 150; i++) {
                age.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            string[] genderList =
            {
                "Man", "Kvinna"
            };

            foreach (var x in genderList) {
                gender.Add(new SelectListItem {
                    Text = x,
                    Value = x
                });
            }

            ViewData["Age"] = age;
            ViewData["Gender"] = gender;
        }
        
        public ActionResult Edit()
        {
            EditAndRegister();
            return View();
        }

        public ActionResult Register() {
            EditAndRegister();
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            EditAndRegister();
            RegisterRepository.Register(model.Name, model.Age, model.Gender, model.About, model.Username, model.Password, model.Visible);
            return View();
        }



        public ActionResult Search() {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            var search = SearchRepository.Search(model.Name);
            var result = new List<SelectListItem>();

            foreach (User item in search)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name
                });
            }

            ViewData["Result"] = result;
                        
            return View();
        }

	}
}