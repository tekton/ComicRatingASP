using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicRating.Models
{
    public class Rating
    {
        public virtual Issue issue { get; set; }
        public string overall { get; set; }
        public string art { get; set; }
        public string story { get; set; }
    }
}