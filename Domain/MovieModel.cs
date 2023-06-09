using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieModel
    {
        public string picture { get; set; }
        public string overview { get; set; }
        public string popularity { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
        public int ID { get; set; }
        public List<string> genres { get; set; }
    }
    public class MoviesModel
    {
        public List<MovieModel> movies
        {
            get; set;
        }
    }
}