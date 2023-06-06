using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ForumController : Controller
    {
        [HttpGet]
        public ActionResult Comments(int id)
        {
            StorageEntities db = new StorageEntities();

            // create instances
            CommentsData commentsData = new CommentsData();
            commentsData.ReplyList = new List<ReplyInfo>();

            // find the entry and fill it up
            Topic _Topic = db.Topics.Find(id);
            commentsData.TopicName = _Topic.Topic_Name;
            commentsData.TopicId = _Topic.Topic_ID;

            // all replies related to the Topic
            List<TopicReply> tr = db.TopicReplies.Where(model => model.Topic_ID == _Topic.Topic_ID).ToList();

            foreach (var Treplyentry in tr)
            {
                ReplyInfo rInfo = new ReplyInfo();


                // we got number of user's topics in previous step
                User Utemp = db.Users.Where(model => model.User_Login == Treplyentry.Reply.Reply_Author).FirstOrDefault();

                // calculate number of replies
                List<UserTopic> uTopic = db.UserTopics.Where(model => model.User_ID == Utemp.User_ID).ToList();

                rInfo.RAuthorName = Utemp.User_Login;
                rInfo.RAuthorPfp = Utemp.User_Picture;
                rInfo.ReplyID = Treplyentry.Reply_ID;
                rInfo.RAuthorTopics = uTopic.Count();
                rInfo.ReplyText = Treplyentry.Reply.Reply_Content;

                commentsData.ReplyList.Add(rInfo);
            }

            return View(commentsData);
        }

        [HttpPost]
        public ActionResult Comments(string textReply, int? TopicId)
        {
            StorageEntities db = new StorageEntities();
            // get current user
            // find the user in DB by his name
            var User = db.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            Reply reply = new Reply();
            reply.Reply_Author = User.User_Login;
            reply.Reply_Content = textReply;
            reply.Reply_Date = DateTime.Now;

            UserReply uReply = new UserReply();
            uReply.User_ID = User.User_ID;
            uReply.Reply_ID = reply.Reply_ID;

            TopicReply tReply = new TopicReply();
            tReply.Topic_ID = (int)TopicId;
            tReply.Reply_ID = reply.Reply_ID;

            db.Replies.Add(reply);
            db.UserReplies.Add(uReply);
            db.TopicReplies.Add(tReply);
            db.SaveChanges();

            return RedirectToAction("Comments", new { id = TopicId });
        }

        [HttpGet]
        public ActionResult NewTopic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTopic(string newTopic, string newReply)
        {
            StorageEntities db = new StorageEntities();

            // TOPIC
            Topic topic = new Topic();
            topic.Topic_Name = newTopic;
            topic.Topic_Date = DateTime.Now;
            topic.Topic_Author = User.Identity.Name;
            db.Topics.Add(topic);

            // find the user's ID knowing name
            User tempUser = db.Users.Where(model => model.User_Login == topic.Topic_Author).FirstOrDefault();

            // REPLY
            Reply reply = new Reply();
            reply.Reply_Author = topic.Topic_Author;
            reply.Reply_Date = DateTime.Now;
            reply.Reply_Content = newReply;
            db.Replies.Add(reply);

            // TOPIC+REPLY
            TopicReply tr = new TopicReply();
            tr.Topic_ID = topic.Topic_ID;
            tr.Reply_ID = reply.Reply_ID;
            db.TopicReplies.Add(tr);

            // USER+REPLY
            UserReply ur = new UserReply();
            ur.User_ID = tempUser.User_ID;
            ur.UserReply_ID = reply.Reply_ID;
            db.UserReplies.Add(ur);

            // USER+TOPIC
            UserTopic ut = new UserTopic();
            ut.User_ID = tempUser.User_ID;
            ut.Topic_ID = topic.Topic_ID;
            db.UserTopics.Add(ut);

            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult Topics()
        {
            StorageEntities db = new StorageEntities();
            ManyTopics manyTopics = new ManyTopics();
            manyTopics.TopicData = new List<TopicData>();

            foreach (var topic in db.UserTopics)
            {
                TopicData td = new TopicData();
                Topic _Topic = db.Topics.Where(model => model.Topic_ID == topic.Topic_ID).FirstOrDefault();
                td.TopicAuthor = _Topic.Topic_Author;
                td.TopicDate = _Topic.Topic_Date;
                td.TopicName = _Topic.Topic_Name;
                td.TopicId = _Topic.Topic_ID;

                List<TopicReply> tr = db.TopicReplies.Where(model => model.Topic_ID == topic.Topic_ID).ToList();

                // calculate number of replies
                int repNumber = tr.Count();

                int rID = tr[tr.Count - 1].Reply_ID;
                Reply _Reply = db.Replies.Where(model => model.Reply_ID == rID).FirstOrDefault();

                // find the user's ID knowing name
                User tempUser = db.Users.Where(model => model.User_Login == _Reply.Reply_Author).FirstOrDefault();

                td.ProfilePic = tempUser.User_Picture;
                td.ReplyAuthor = _Reply.Reply_Author;
                td.RepliesNumber = repNumber;
                td.LastReply = _Reply.Reply_Content;

                manyTopics.TopicData.Add(td);
            }

            return View(manyTopics);
        }
    }
}