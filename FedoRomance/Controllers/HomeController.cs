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

        
        public void EditAndSearch() {
            var age = new List<SelectListItem>();
            var length = new List<SelectListItem>();
            var weight = new List<SelectListItem>();
            var region = new List<SelectListItem>();

            for (int i = 1; i <= 150; i++) {
                age.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            for (int i = 1; i <= 250; i++) {
                length.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            for (int i = 1; i <= 500; i++) {
                weight.Add(new SelectListItem {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            string[] regionList = {
                "Blekinge län", "Dalarnas län", "Gotlands län",
                "Gävleborgs län", "Hallands län", "Jämtlands län",
                "Jönköpings län", "Kalmar län", "Kronobergs län",
                "Norrbottens län", "Skåne Län", "Stockholms län",
                "Södermanlands län", "Uppsala län", "Värmlands län",
                "Västerbottens län", "Västernorrlands län", "Västmanlands län",
                "Västra Götalands län", "Örebro län", "Östergötlands län"
            };

            foreach (var x in regionList) {
                region.Add(new SelectListItem {
                    Text = x,
                    Value = x
                });
            }
            
            ViewBag.Age = age;
            ViewBag.Length = length;
            ViewBag.Weight = weight;
            ViewBag.Region = region;
        }
        
        public ActionResult Edit()
        {
            EditAndSearch();
            return View();
        }

        public ActionResult Search() {
            EditAndSearch();
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            var result = SearchRepository.Search(model.Name);

            var result1 = new List<SelectListItem>();

            foreach (User item in result)
            {
                result1.Add(new SelectListItem
                {
                    Text = item.Name
                });
            }

            ViewBag.Result = result1;

            return View();
        }
	}
}