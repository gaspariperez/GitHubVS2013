using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.WebPages;
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
            if(Session["UserAuth"] != null)
            {
                return RedirectToAction("Profile", "Home", new { username = Session["UserAuth"].ToString() });
            }
            return View();
        }

        [HttpPost] public ActionResult LogIn(LogInModel model)
        {
            var user = LogInRepository.LogIn(model.Username, model.Password);

            if (user != null) {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                Session["UserAuth"] = model.Username;
                return RedirectToAction("Profile", "Home", new { username = Session["UserAuth"].ToString() });
            }
            
            ModelState.AddModelError("", "Login details are wrong.");
            Session["UserAuth"] = null;

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["UserAuth"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile(string username) {
            if (Session["UserAuth"] == null) {
                return RedirectToAction("LogIn", "Home");
            }
            
            if (username == null)
            {
                username = Session["UserAuth"].ToString();
            }

            var info = ProfileRepository.GetProfile(username);

            var model = new ProfileModel();
            model.Name = info.Name;
            model.Age = info.Age;
            model.Gender = info.Gender;
            model.About = info.About;

            return View(model);
        }

        public ActionResult Friends()
        {
            if (Session["UserAuth"] == null) {
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }
        
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
        
        public ActionResult Edit(string username) {
            if (Session["UserAuth"] == null) {
                return RedirectToAction("LogIn", "Home");
            }

            EditAndRegister();
            username = Session["UserAuth"].ToString();
            var info = EditRepository.GetUser(username);

            ViewData["EditVisible"] = info.Visible;

            var model = new EditModel();
            model.Name = info.Name;
            model.Age = info.Age;
            model.Gender = info.Gender;
            model.About = info.About;
            model.Visible = info.Visible;
            return View(model);
        }

        [HttpPost] public ActionResult Edit(EditModel model)
        {
            EditAndRegister();

            if (!ModelState.IsValid)
                return View();

            var currentUser = Session["UserAuth"].ToString();

            EditRepository.EditUser(currentUser, model.Name, model.Age, model.Gender, model.About, model.Password, model.Visible);

            return RedirectToAction("Profile", "Home", new { username = Session["UserAuth"].ToString() });
        }

        public ActionResult Register() {
            if (Session["UserAuth"] != null) {
                return RedirectToAction("Profile", "Home", new { username = Session["UserAuth"].ToString() });
            }
            EditAndRegister();
            return View();
        }

        
        [HttpPost] public ActionResult Register(RegisterModel model)
        {
            EditAndRegister();
            
            if (!ModelState.IsValid)
                return View();
            
            RegisterRepository.Register(model.Name, model.Age, model.Gender, model.About, model.Username, model.Password, model.Visible);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Search() {
            if (Session["UserAuth"] == null) {
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }

        [HttpPost] public ActionResult Search(SearchModel model)
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