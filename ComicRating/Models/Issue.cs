using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComicRating.Models
{
    public class Issue
    {

        [DisplayName("Series")]
        public int SeriesID { get; set; }
        //[ScaffoldColumn(false)]
        //public string SeriesName { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Number")]
        public string number { get; set; }

        [ScaffoldColumn(false)]
        public int IssueID { get; set; }

        public virtual Series series { get; set; }

        public List<Rating> ratings { get; set; }
    }
}