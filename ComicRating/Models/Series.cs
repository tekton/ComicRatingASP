using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComicRating.Models
{
    public class Series
    {



        public int SeriesID { get; set; }

        [DisplayName("Publisher")]
        public int PublisherID { get; set; }

        public string name { get; set; }
        
        public string max_issue { get; set; }
        public string start_year { get; set; }
        public string volume { get; set; }
        public List<Issue> issue { get; set; }

        public virtual Publisher publisher { get; set; } //DC, Marvel, Boom!, Vertigo, etc
    }
}