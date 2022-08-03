using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class CinemaComplex
    {

        public CinemaComplex(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }

        public Cinema AddCinema (string name)
        {
            var cinema = new Cinema (name);
            Cinemas.Add (cinema);
            return cinema;
            
        }

        public Cinema FindCinemaByName(string name)
        {
            foreach (var c in Cinemas)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }

            throw new Exception("No Cinema with provided name: " + name);
        }

        public Movie AddMovie(string title, int duration, string rating)
        {
            var movie = new Movie(title, duration, rating);
            Movies.Add(movie);
            return movie;

        }

        public Movie FindMovieByTitle(string title)
        {
            foreach (var m in Movies)
            {
                if (m.Title == title)
                {
                    return m;
                }
            }
            throw new Exception("Movie not found:" + title);
                
        }
        

        public List<Cinema> Cinemas { get; set; } = new List<Cinema>();
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Session> Sessions { get; set; } = new List<Session>();

        public Session ScheduleSession(DateTime starttime, string title, string cinemaName, string ticketMachine)
        {
            var movie = FindMovieByTitle(title);
            var cinema = FindCinemaByName(cinemaName);
            var tm = FindTicketMachineById(ticketMachine);
            var session = new Session(starttime, movie, cinema, tm);
            Sessions.Add(session);
            return session;

        }
        public List<TicketMachine> TicketMachines { get; set; } = new List<TicketMachine>();

        public TicketMachine AddTicketMachine(string id)
        {
            var tm = new TicketMachine(id, this);
            TicketMachines.Add(tm);
            return tm;
        }

        public TicketMachine FindTicketMachineById(string id)
        {
            foreach (var tm in TicketMachines)
            {
                if (tm.Id == id)
                {
                    return tm;
                }
            }
            throw new Exception("Ticket Machine not found:" + id);

        }


    }
}