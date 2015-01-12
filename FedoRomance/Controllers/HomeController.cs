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
            if(Session["CurrentUser"] != null)
            {
                return RedirectToAction("Profile", "Home", new { username = Session["CurrentUser"].ToString() });
            }
            return View();
        }

        [HttpPost] public ActionResult LogIn(LogInModel model)
        {
            var user = LogInRepository.LogIn(model.Username, model.Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                Session["CurrentUser"] = model.Username;
                return RedirectToAction("Profile", "Home", new {username = Session["CurrentUser"].ToString()});
            }
            else
            {
                
                /*ModelState.AddModelError("", "Login details are wrong.");*/
                Session["CurrentUser"] = null;

                return View();
            }
        }

        public ActionResult LogOut()
        {
            
            FormsAuthentication.SignOut();
            Session["CurrentUser"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile(string username) {
            if (Session["CurrentUser"] == null) {
                return RedirectToAction("LogIn", "Home");
            }
            
            if (username == null)
            {
                username = Session["CurrentUser"].ToString();
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
            if (Session["CurrentUser"] == null) {
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
        
        public ActionResult Edit() {
            if (Session["CurrentUser"] == null) {
                return RedirectToAction("LogIn", "Home");
            }

            EditAndRegister();
            var currentUser = Session["CurrentUser"].ToString();
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
            EditAndRegister();

            if (!ModelState.IsValid)
                return View();

            var currentUser = Session["CurrentUser"].ToString();
            var info = EditRepository.GetUser(currentUser);
            

            if (file != null) {
                var extension = Path.GetExtension(file.FileName);
                var picName = currentUser + extension;
                var folder = Server.MapPath("~/Images");
                var path = Path.Combine(folder, picName);

                if (info.Picture != null)
                {
                    var currentPicName = info.Picture;
                    var currentPicPath = Path.Combine(folder, currentPicName);

                    if (System.IO.File.Exists(currentPicPath)) {
                        System.IO.File.Delete(currentPicPath);
                    }
                }
                else if (info.Picture == null)
                {
                    if (extension == ".jpeg" || extension == ".jpg" || extension == ".png") {
                        file.SaveAs(path);
                        model.Picture = picName;
                        EditRepository.UploadUserPic(currentUser, picName);
                    }
                }
            }
            
            EditRepository.EditUser(currentUser, model.Name, model.Age, model.Gender, model.About, model.Password, model.Visible);

            return RedirectToAction("Profile", "Home", new { username = Session["CurrentUser"].ToString() });
        }

        public ActionResult Register() {
            if (Session["CurrentUser"] != null) {
                return RedirectToAction("Profile", "Home", new { username = Session["CurrentUser"].ToString() });
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
            if (Session["CurrentUser"] == null) {
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }

        [HttpPost] public ActionResult Search(SearchModel model)
        {
            var search = SearchRepository.Search(model.Name);
            var result = new List<string>();

            foreach (User item in search)
            {
                result.Add(item.Username);
            }

            ViewData["SearchResult"] = result;
            
            return View();
        }

        
	}
}