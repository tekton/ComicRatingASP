using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ComicRating.Models
{
    public class SeedData : DropCreateDatabaseIfModelChanges<ComicRateEntities> //DropCreateDatabaseAlways<ComicRateEntities>//  
    {
        protected override void Seed(ComicRateEntities context) {
            var publishers = new List<Publisher> {
                new Publisher { name = "DC" },
                new Publisher {name="Marvel"},
                new Publisher {name="Vertigo"},
                new Publisher {name="BOOM!"}
            };

            var artists = new List<Artist>
            {
                new Artist {name="Kubert"},
                new Artist {name="Random"},
                new Artist {name="unknown"}
            };

            var writers = new List<Writer>
            {
                new Writer {name="Geoff"},
                new Writer {name="Ran Dom"},
                new Writer {name="Bendis"}
            };

            var series = new List<Series>
            { 
                new Series {name="Batman",publisher= publishers.Single(p=> p.name=="DC"),start_year="2011",volume="2"},
                new Series {name="Green Lantern",publisher= publishers.Single(p=> p.name=="DC"),start_year="2011",volume="2"},
                new Series {name="Spider-Man",publisher= publishers.Single(p=> p.name=="Marvel"),start_year="2000",volume="1"},
                new Series {name="Darkwing Duck",publisher= publishers.Single(p=> p.name=="BOOM!"),start_year="2010",volume="3"}
            };

            new List<Issue>
            {
                new Issue {series = series.Single(s => s.name=="Batman"), number="1"},
                new Issue {series = series.Single(s => s.name=="Batman"), number="2"},
                new Issue {series = series.Single(s => s.name=="Batman"), number="3"},
                new Issue {series = series.Single(s => s.name=="Batman"), number="4"},
                new Issue {series = series.Single(s => s.name=="Batman"), number="5"},
                new Issue {series = series.Single(s => s.name=="Batman"), number="6"},

                new Issue {series = series.Single(s => s.name=="Green Lantern"), number="1"},
                new Issue {series = series.Single(s => s.name=="Green Lantern"), number="2"},
                new Issue {series = series.Single(s => s.name=="Green Lantern"), number="3"},
                new Issue {series = series.Single(s => s.name=="Green Lantern"), number="4"},
                new Issue {series = series.Single(s => s.name=="Green Lantern"), number="5"},
                new Issue {series = series.Single(s => s.name=="Green Lantern"), number="6"},

                new Issue {series = series.Single(s => s.name=="Darkwing Duck"), number="1"},
                new Issue {series = series.Single(s => s.name=="Darkwing Duck"), number="2"},
                new Issue {series = series.Single(s => s.name=="Darkwing Duck"), number="3"},
                new Issue {series = series.Single(s => s.name=="Darkwing Duck"), number="4"},
                new Issue {series = series.Single(s => s.name=="Darkwing Duck"), number="5"},
                new Issue {series = series.Single(s => s.name=="Darkwing Duck"), number="6"},

                new Issue {series = series.Single(s => s.name=="Spider-Man"), number="1"},
                new Issue {series = series.Single(s => s.name=="Spider-Man"), number="2"},
                new Issue {series = series.Single(s => s.name=="Spider-Man"), number="3"},
                new Issue {series = series.Single(s => s.name=="Spider-Man"), number="4"},
                new Issue {series = series.Single(s => s.name=="Spider-Man"), number="5"},
                new Issue {series = series.Single(s => s.name=="Spider-Man"), number="6"}
            }.ForEach(i => context.Issues.Add(i));

        }
    }
}