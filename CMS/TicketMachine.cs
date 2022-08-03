using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class TicketMachine
    {

        public TicketMachine(string id, CinemaComplex cinemaComplex)
        {
            Id = id;
            CinemaComplex = cinemaComplex;
        }
        public CinemaComplex CinemaComplex { get; set; }
        public string Id { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<Movie> Movies
        {
            get
            {
                var nowShowingMovies = new List<Movie>();
                foreach (var movie in CinemaComplex.Movies)
                {
                    if (movie.HasFutureSession)
                    {
                        nowShowingMovies.Add(movie);
                    }
                }
                return nowShowingMovies;
            }
        }




    }
}