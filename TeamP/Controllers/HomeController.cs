using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamP.Models;

namespace TeamP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext db = ApplicationDbContext.Create();
                List<Post> PostsList = db.Posts.ToList();
                List<Course> CoursesList = db.Courses.ToList();
                ViewBag.Posts = PostsList.AsEnumerable().Reverse();
                ViewBag.Courses = CoursesList.AsEnumerable().Reverse();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
      

        public ActionResult CreateCourse()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse(string CourseTitle,string UserId)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    Course x = new Course();
                    x.CourseTitle = CourseTitle;
                    x.UserId = UserId;
                    ApplicationDbContext db = ApplicationDbContext.Create();
                    db.Courses.Add(x);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        
        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(string PostText, string UserID)
        {
            if (ModelState.IsValid)
            {
                Post x = new Post();
                x.PostText = PostText;
                x.PostDate = DateTime.Today.Date;
                x.UserId = UserID;
                ApplicationDbContext db = ApplicationDbContext.Create();
                var user = db.Users.Find(UserID);
                if(user!=null)
                {
                    x.ProfilePic = user.ProfilePic;
                    x.Login = user.Login;
                }
                db.Posts.Add(x);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}