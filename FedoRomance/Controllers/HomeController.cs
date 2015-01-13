using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
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
        public ActionResult Index()
        {
            var getUser1 = IndexRepository.GetUsers("GasPer");
            var getUser2 = IndexRepository.GetUsers("antkop");
            var getUser3 = IndexRepository.GetUsers("HenHo");

            var model = new IndexModel();
            model.ExampleUser1 = getUser1.Username;
            model.ExampleUser2 = getUser2.Username;
            model.ExampleUser3 = getUser3.Username;
            model.ExampleUserPic1 = getUser1.Picture;
            model.ExampleUserPic2 = getUser2.Picture;
            model.ExampleUserPic3 = getUser3.Picture;

            return View(model);
        }
               
        public ActionResult LogIn() {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Profile", "Home", new { username = User.Identity.Name});
            }
            return View();
        }

        [HttpPost] public ActionResult LogIn(LogInModel model)
        {
            var user = LogInRepository.LogIn(model.Username, model.Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Profile", "Home", new {username = User.Identity.Name});
            }
            else
            {
                
                /*ModelState.AddModelError("", "Login details are wrong.");*/
                FormsAuthentication.SignOut();

                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile(string username) {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }
            
            if (username == null)
            {
                username = User.Identity.Name;
            }

            var info = ProfileRepository.GetProfile(username);

            var model = new ProfileModel();
            model.Name = info.Name;
            model.Age = info.Age;
            model.Gender = info.Gender;
            model.About = info.About;
            model.Picture = info.Picture;

            return View(model);
        }

        public ActionResult Friends()
        {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }
        
        public void EditAndRegister() {
            var age = new List<SelectListItem>();
            var gender = new List<SelectListItem>();

            for (int i = 18; i <= 150; i++) {
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
        
        public ActionResult Edit() {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }

            EditAndRegister();
            var currentUser = User.Identity.Name;
            var info = EditRepository.GetUser(currentUser);
            
            var model = new EditModel();
            model.Name = info.Name;
            model.Age = info.Age;
            model.Gender = info.Gender;
            model.About = info.About;
            model.Visible = info.Visible;
            return View(model);
        }

        [HttpPost] public ActionResult Edit(EditModel model, HttpPostedFileBase file)
        {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }

            EditAndRegister();
            var currentUser = User.Identity.Name;
            var info = EditRepository.GetUser(currentUser);

            if (file != null) {
                var extension = Path.GetExtension(file.FileName);

                if (extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                {
                    var picName = currentUser + extension;
                    var folder = Server.MapPath("~/Images");
                    var path = Path.Combine(folder, picName);

                    if (info.Picture != null) {
                        var currentPicName = info.Picture;
                        var currentPicPath = Path.Combine(folder, currentPicName);

                        if (System.IO.File.Exists(currentPicPath)) {
                            System.IO.File.Delete(currentPicPath);
                        }
                    }
                    file.SaveAs(path);
                    model.Picture = picName;
                    EditRepository.UploadUserPic(currentUser, picName);
                }
            }
            
            EditRepository.EditUser(currentUser, model.Name, model.Age, model.Gender, model.About, model.Visible);

            return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
        }

        public ActionResult EditPassword()
        {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditPassword(EditModel model) 
        {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }

            var currentUser = User.Identity.Name;

            EditRepository.NewPassword(currentUser, model.CurrentPassword, model.NewPassword);

            return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
        }



        public ActionResult Register() {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
            }
            EditAndRegister();
            return View();
        }

        
        [HttpPost] public ActionResult Register(RegisterModel model)
        {
            EditAndRegister();
            
            RegisterRepository.Register(model.Name, model.Age, model.Gender, model.About, model.Username, model.Password, model.Visible);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Search() {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }

        [HttpPost] public ActionResult Search(SearchModel model)
        {
            if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }
            var search = SearchRepository.Search(model.Name);
            var result = new List<string>();

            foreach (User item in search)
            {
                if (item.Visible != 1)
                {
                    result.Add(item.Username);
                }
            }

            ViewData["SearchResult"] = result;
            
            return View();
        }

        
/*--------------------------language-------------------*/
        [HttpGet]
        public ActionResult ChangeCulture(string lang)
        {
            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };

            Response.AppendCookie(langCookie);

            return RedirectToAction("Register", "Home", new { culture = lang });  
        }

	}
}