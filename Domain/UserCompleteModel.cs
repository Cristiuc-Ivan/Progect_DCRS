using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserCompleteModel
    {
        public List<Actor> Actors { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Topic> Topics { get; set; }
        public List<TopicReplyModel> Replies { get; set; }
    }
    public class TopicReplyModel
    {
        public Reply reply { get; set; }
        public Topic topic { get; set; }
    }
}
