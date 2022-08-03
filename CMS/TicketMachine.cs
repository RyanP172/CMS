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

        public void PrintTicket(Session session)
        {
            var ticket = new Ticket(session);
            Console.WriteLine("TICKET");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(ticket.Session.Movie.Title.ToUpper());
            Console.WriteLine($"Location: \t\t{CinemaComplex.Name}");            
            Console.WriteLine($"Session Date: \t\t{ticket.Session.StartTime.Date.ToLongDateString()}");
            Console.WriteLine($"Start Time: \t\t{ticket.Session.StartTime.ToLongTimeString()}");
            Console.WriteLine($"End Time: \t\t{ticket.Session.EndTime.ToLongTimeString()}");
            Console.WriteLine($"Cinema: \t\t{ticket.Session.Cinema.Name}");
            Console.Write("Seat: ");
            foreach (var s in ticket.Session.Cinema.TakenSeats)
            {
                Console.Write($"\t\t\t{s.Name}");
            }
            Console.WriteLine("");
            Console.ReadLine();

        }




    }
}