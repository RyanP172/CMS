using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class Ticket
    {
        public Ticket(Session session)
        {
            Issued = DateTime.Now;
            Session = session;
            
        }
        public Seat Seat { get; set; }
        
        public Session Session { get; set; }
        public DateTime Issued { get; set; }

        
    }
}