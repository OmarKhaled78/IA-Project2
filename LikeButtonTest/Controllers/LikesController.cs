using LikeButtonTest.datafunctionfolder;
using LikeButtonTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LikeButtonTest.Controllers
{
    public class LikesController : Controller
    {
       
        // GET: Likes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult details(int id) //id refers to the research id of the research we want to check 
        {

            var db = new datafunction(); // object of the class that contains the methods for the like logic
            //var Testid = ((int)Session["TestId"]);
            ViewBag.like = db.GetLikesCount(id);
                ViewBag.Dislike = db.GetDislikesCount(id);
                ViewBag.AllUserlikedislike = db.GetAllUsers(id);
                return View();
            
        }
        public ActionResult Like (int id ,bool status) //id of the research we want to like , if status is true then LIKE , if status is false then DISLIKE
        {
            var db = new datafunction(); // object of the class that contains the methods for the like logic
            var result = db.Like(id, status); // calling the Like function that is in the class that contains the methods for the like logic 
            return Content(result); //returns number of likes and number of dislikes


        }











    }
}