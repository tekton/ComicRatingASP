using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ComicRating.Models
{
    public class ComicRateEntities : DbContext
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<Writer> Writers { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}