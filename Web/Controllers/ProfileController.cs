using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            StorageEntities db = new StorageEntities();
            var User = db.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            List<Actor> _actors = db.UserActors
                .Where(model => model.User_ID == User.User_ID)
                .Select(model => model.Actor)
                .ToList();

            List<Movie> _movies = db.UserMovies
                .Where(model => model.User_ID == User.User_ID)
                .Select(model => model.Movie)
                .ToList();

            List<Topic> _topics = db.UserTopics
                .Where(model => model.User_ID == User.User_ID)
                .Select(model => model.Topic)
                .ToList();

            List<Reply> _replies = db.UserReplies
                .Where(model => model.User_ID == User.User_ID)
                .Select(model => model.Reply)
                .ToList();

            List<Topic> _replyTopic = new List<Topic>();
            List<TopicReplyModel> trModel = new List<TopicReplyModel>();


            foreach (Reply reply in _replies)
            {
                Topic topic = db.TopicReplies
                    .Where(model => model.Reply_ID == reply.Reply_ID)
                    .Select(model => model.Topic).FirstOrDefault();
                _replyTopic.Add(topic);
            }

            for (int i = 0; i < _replies.Count; i++)
            {
                TopicReplyModel theModel = new TopicReplyModel
                {
                    reply = _replies[i],
                    topic = _replyTopic[i]
                };
                trModel.Add(theModel);
            }

            UserCompleteModel userCompleteD = new UserCompleteModel
            {
                Actors = _actors,
                Movies = _movies,
                Topics = _topics,
                Replies = trModel
            };

            return View(userCompleteD);
        }
    }
}