using LikeButtonTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeButtonTest.datafunctionfolder
{
    public class datafunction
    {
        public string Like(int id, bool status)
        {
            using (var db = new TestDbEntities())
            {
                var Research = db.Researches.FirstOrDefault(x => x.ResearchId == id);
                var toggle = false;
                Like like = db.Likes.FirstOrDefault(x => x.ResearchId == id && x.UserId == x.UserId);

                //checking which button was pressed
                if (like == null)
                {

                    like = new Models.Like();
                    like.UserId = like.UserId;
                    like.IsLike = status;
                    like.ResearchId = id;
                    if (status)
                    {
                        if (Research.LikeCount == null) //if no previous likes or dislikes
                        {
                            Research.LikeCount = Research.LikeCount ?? 0 + 1;
                            Research.DislikeCount = Research.DislikeCount ?? 0;



                        }
                        else
                        {
                            Research.LikeCount = Research.LikeCount + 1;
                        }

                    }
                    else
                    {
                        if (Research.DislikeCount == null)
                        {
                            Research.DislikeCount = Research.DislikeCount ?? 0 + 1;
                            Research.LikeCount = Research.LikeCount ?? 0;
                        }
                        else
                        {
                            Research.DislikeCount = Research.DislikeCount + 1;

                        }
                    }
                    db.Likes.Add(like);

                }
                else
                {
                    toggle = true;
                }
                if (toggle)
                {
                    like.UserId = like.UserId;
                    like.IsLike = status;
                    like.ResearchId = id;
                    if (status)
                    {
                        //if user wants to change his dislike to a like ( need to increase likes by 1 and decrease dislikes by 1 )
                        Research.LikeCount = Research.LikeCount + 1;
                        if (Research.DislikeCount == 0 || Research.DislikeCount < 0)
                        {
                            Research.DislikeCount = 0;
                        }
                        else
                        {
                            Research.DislikeCount = Research.DislikeCount - 1;
                        }
                    }
                    else
                    {
                        // if user wants to change his like to dislike ( need to increase dislikes by 1 and decrease likes by 1)
                        Research.DislikeCount = Research.DislikeCount + 1;
                        if (Research.LikeCount == 0 || Research.LikeCount < 0)
                        {
                            Research.LikeCount = 0;
                        }
                        else
                        {
                            Research.LikeCount = Research.LikeCount - 1;
                        }
                    }
                }
                db.SaveChanges();
                return Research.LikeCount + "/" + Research.DislikeCount;

            }

        }



        public int? GetLikesCount(int id) //to count likes
        {
            using (var db = new TestDbEntities())
            {
                var count = (from x in db.Researches where (x.ResearchId == id && x.LikeCount != null) select x.LikeCount).FirstOrDefault();
                return count;

            }

        }



        public int? GetDislikesCount(int id) // to count dislikes
        {
            using (var db = new TestDbEntities())
            {
                var count = (from x in db.Researches where (x.ResearchId == id && x.DislikeCount != null) select x.DislikeCount).FirstOrDefault();
                return count;
            }

        }



        public List<Like> GetAllUsers(int id) //get all users who interacted with research
        {
            using (var db = new TestDbEntities())
            {
                var count = (from x in db.Likes where x.ResearchId == id select x).ToList();
                return count;
            }
        }
    }
}