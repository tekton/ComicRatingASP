using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicRating.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string name { get; set; }
        public List<Series> Series { get; set; }
    }
}