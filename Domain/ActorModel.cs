using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ActorModel
    {
        public string picture { get; set; }
        public string realName { get; set; }
        public string name { get; set; }
        public string popularity { get; set; }
        public string gender { get; set; }
        public List<string> known_for { get; set; }
    }
    public class ActorsModel
    {
        public List<ActorModel> actors
        {
            get; set;
        }
    }
}

