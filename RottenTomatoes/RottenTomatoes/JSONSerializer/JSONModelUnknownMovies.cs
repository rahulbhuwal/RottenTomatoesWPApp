﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace RottenTomatoes.JSONSerializer.UpcomingMovies
{
    public class ReleaseDates
    {
        public string theater { get; set; }
        public string dvd { get; set; }
    }

    public class Ratings
    {
        public string critics_rating { get; set; }
        public int critics_score { get; set; }
        public int audience_score { get; set; }
    }

    public class Posters
    {
        public string thumbnail { get; set; }
        public string profile { get; set; }
        public string detailed { get; set; }
        public string original { get; set; }
    }

    public class AbridgedCast
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<string> characters { get; set; }
    }

    public class AlternateIds
    {
        public string imdb { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string alternate { get; set; }
        public string cast { get; set; }
        public string clips { get; set; }
        public string reviews { get; set; }
        public string similar { get; set; }
    }

    public class Movie
    {
        public string id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string mpaa_rating { get; set; }
        public object runtime { get; set; }
        public ReleaseDates release_dates { get; set; }
        public Ratings ratings { get; set; }
        public string synopsis { get; set; }
        public Posters posters { get; set; }
        public List<AbridgedCast> abridged_cast { get; set; }
        public AlternateIds alternate_ids { get; set; }
        public Links links { get; set; }
    }

    public class Links2
    {
        public string self { get; set; }
        public string next { get; set; }
        public string alternate { get; set; }
    }

    public class ComingSoonMovies
    {
        public int total { get; set; }
        public List<Movie> movies { get; set; }
        public Links2 links { get; set; }
        public string link_template { get; set; }
    }

}
