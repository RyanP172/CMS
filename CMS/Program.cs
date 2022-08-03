namespace CMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildDummyData();

            
            
        }

        public static void BuildDummyData()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            var complex = new CinemaComplex("Hoyts", "123 King St, CBD");
            
            

            foreach (var cinemaName in new[] { "C1", "C2", "IMax" })
            {
                var cinema = complex.AddCinema(cinemaName);
                foreach (var row in "ABCDE")
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        cinema.AddSeat($"{row}{i}");
                    }
                }
            }

            complex.AddMovie("Mia", 110, "R");
            complex.AddMovie("Cat", 75, "M");
            complex.AddMovie("Sniper", 90, "G");
            var ticketMachine = complex.AddTicketMachine("TM1");

            complex.ScheduleSession(DateTime.Parse("2022/08/10 8:30:00 AM"), "Mia", "C1", "TM1");
            complex.ScheduleSession(DateTime.Parse("2022/08/10 8:30:00 AM"), "Cat", "C2", "TM1");
            complex.ScheduleSession(DateTime.Parse("2022/08/10 11:30:00 AM"), "Mia", "C1", "TM1");
            complex.ScheduleSession(DateTime.Parse("2022/08/10 11:30:00 AM"), "Sniper", "C2", "TM1");


            //var ticketMachine = complex.AddTicketMachine("TM1");
            Console.WriteLine($"Welcome to {complex.Name} ");
            Console.WriteLine($"Ticket Machine: {ticketMachine.Id}");
            Console.WriteLine("Movie (now Showing)");

            foreach (var m in ticketMachine.Movies)
            {
                Console.WriteLine(m.Title);
                //foreach (var session in movie.FutureSessions)
                //{
                //    Console.WriteLine($"CINEMA: { session.Cinema.Name} { session.StartTime}");
                //}
            }

            Console.Write("Please enter a movie title: ");
            var title = Console.ReadLine();
            var movie = complex.FindMovieByTitle(title);

            Console.WriteLine("Session: ");
            int sessionIndex = 1;
            foreach (var s in movie.FutureSessions)
            {
                Console.WriteLine($" {sessionIndex++} CINEMA: { s.Cinema.Name} TIME { s.StartTime}");
            }
            Console.WriteLine("Please select a session:");
            int selectedSessionIndex = int.Parse(Console.ReadLine());
            var sessions = movie.FutureSessions[selectedSessionIndex - 1];

            Console.WriteLine("");
            Console.WriteLine("Available Seats: ");
            foreach (var s in sessions.Cinema.AvailableSeats)
            {
                Console.Write($"{s.Name}\t");
            }
            Console.WriteLine("");

            Console.WriteLine("Please select a seat: ");
            var seat = Console.ReadLine();
            sessions.Cinema.TakenSeat(seat);
            Console.WriteLine("");
            sessions.TicketMachine.PrintTicket(sessions);
           
            


            //Uncommend this section to test the taken seat
            #region Test taken seat
            

            //Console.WriteLine("Available Seats: ");
            //foreach (var s in sessions.Cinema.AvailableSeats)
            //{
            //    Console.Write($"{s.Name}\t");
            //}
            //Console.WriteLine("");
            #endregion







        }
    }
}