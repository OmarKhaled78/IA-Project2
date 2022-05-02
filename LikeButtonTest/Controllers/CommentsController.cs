using LikeButtonTest.Models;
using LikeButtonTest.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LikeButtonTest.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult details(int id)
        {
            var db = new TestDbEntities();
            var Research = db.Researches.FirstOrDefault(x => x.ResearchId == id);

            return View(Research);

            
        }
        [HttpPost]
        public JsonResult LeaveComment(CommentViewModel model)
        {
            JsonResult result = new JsonResult();
            try
            {
                var comment = new Comment();
                comment.CommentText = model.CommentText;
                comment.ResearchId = model.ResearchId;
                comment.CommentId = model.CommentId;
                comment.UserId = Int16.Parse(User.Identity.GetUserId());
                comment.TimeStamp = DateTime.Now;
                result.Data = new { Success = SaveComment(comment) };
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            
            

            return result;


        }
        public bool SaveComment(Comment comment)
        {
            var db = new TestDbEntities();


            db.Comments.Add(comment);
            return db.SaveChanges() > 0;

           

            
        }
    }
}