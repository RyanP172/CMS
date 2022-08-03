using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class Cinema
    {

        public Cinema(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public List<Seat> TakenSeats
        {
            get
            {
                var result = new List<Seat>();
                foreach (var s in Seats)
                {
                    if (s.Status == Seat.SeatStatus.Taken)
                        result.Add(s);
                }
                return result;
            }
        }

        public List<Seat> AvailableSeats
        {
            get
            {
                var result = new List<Seat>();
                foreach (var s in Seats)
                {
                    if (s.Status == Seat.SeatStatus.Available)
                        result.Add(s);
                }
                return result;
            }
        }


        public Seat AddSeat(string name)
        {
            var s = new Seat(name);
            Seats.Add(s);
            return s;
        }
        public Seat FindSeat(string name)
        {
            foreach (var s in Seats)
            {
                if (s.Name == name)
                    return s;
            }
                throw new Exception("Seat not found:" + name);

        }        

        public Seat TakenSeat(string name)
        {
            var seat = FindSeat(name);
            if (seat != null)
            {
                seat.Status = Seat.SeatStatus.Taken;
                TakenSeats.Add(seat);
            }
            return seat;
        }



    }
}