using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class Seat
    {
        public Seat(string name)
        {
            Name = name;
            Status = SeatStatus.Available;

        }
        public string Name { get; set; }
        public SeatStatus Status { get; set; }
        public enum SeatStatus { Available, Taken }

        



    }
}