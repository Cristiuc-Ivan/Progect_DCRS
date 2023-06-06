using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TopicData
    {
        public string TopicName { get; set; }
        public int TopicId { get; set; }
        public string ProfilePic { get; set; }
        public string TopicAuthor { get; set; }
        public DateTime TopicDate { get; set; }
        public string LastReply { get; set; }
        public int RepliesNumber { get; set; }
        public string ReplyAuthor { get; set; }
    }
    public class ManyTopics
    {
        public List<TopicData> TopicData { get; set; }
    }
}
