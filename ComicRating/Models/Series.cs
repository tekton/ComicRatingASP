using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicRating.Models
{
    public class Series
    {
        public int SeriesID { get; set; }
        public string name { get; set; }
        public Publisher publisher { get; set; } //DC, Marvel, Boom!, Vertigo, etc
        public string max_issue { get; set; }
        public string start_year { get; set; }
        public string volume { get; set; }
        public List<Issue> issue { get; set; }
    }
}