using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CommentsData
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public List<ReplyInfo> ReplyList { get; set; }
    }
    public class ReplyInfo
    {
        public string ReplyText { get; set; }
        public int ReplyID { get; set; }
        public string RAuthorName { get; set; }
        public string RAuthorPfp { get; set; }
        public int RAuthorTopics { get; set; }
    }
}

