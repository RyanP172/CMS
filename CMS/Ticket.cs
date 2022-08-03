using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class Ticket
    {
        public Seat Seat { get; set; }
        public Session Session { get; set; }
        public DateTime Issued { get; set; }
    }
}