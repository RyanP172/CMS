using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class Session
    {

        public Session(DateTime starttime, Movie movie, Cinema cinema)
        {
            StartTime = starttime;
            Movie = movie;
            movie.Sessions.Add(this);
            Cinema = cinema;
            

        }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime {get => StartTime.AddMinutes(Movie.Duration + 20);}

       
    }
}