using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComicRating.Models
{
    public class Rating
    {
        [DisplayName("Issue")]
        public int IssueID { get; set; }
        
        [ScaffoldColumn(false)]
        public int RatingID { get; set; }

        [DisplayName("Overall : 1-10")]
        public int overall { get; set; }
        [DisplayName("Art : 1-10")]
        public int art { get; set; }
        [DisplayName("Story : 1-10")]
        public int story { get; set; }

        public string user { get; set; }

        public virtual Issue issue { get; set; }
    }
}