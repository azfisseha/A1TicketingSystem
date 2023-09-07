namespace A1TicketingSystem
{

    /// <summary>
    /// An object that handles the processing of ticket information.
    /// </summary>
    public class TicketHandler
    {
        /// <summary>
        /// Reads ticket information out to the console.
        /// </summary>
        /// <param name="headerData">A string array containing the names of the ticket fields in the file</param>
        /// <param name="ticketData">A string array containing the ticket fields</param>
        public void readTicket(string[] headerData, string[] ticketData)
        {
            for (int i = 0; i < headerData.Length; i++)
            {
                if (i < headerData.Length - 1)
                    Console.WriteLine($"{headerData[i]} | {ticketData[i]}");
                else
                {
                    var watchers = ticketData[i].Split('|');
                    Console.Write($"{headerData[i]} | ");
                    for (int x = 0; x < watchers.Length; x++)
                    {
                        if (x < watchers.Length - 2)
                        {
                            Console.Write(watchers[x] + ", ");
                        }
                        else
                        {
                            Console.WriteLine(watchers[x]);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Prompts the user to submit a ticket one field at a time.
        /// </summary>
        /// <returns></returns>
        public string buildTicket()
        {
            var line = "";
            Console.Write("Ticket ID: ");
            line = Console.ReadLine() + ",";

            Console.Write("Summary: ");
            line += Console.ReadLine() + ",";

            Console.Write("Status: ");
            line += Console.ReadLine() + ",";

            Console.Write("Priority: ");
            line += Console.ReadLine() + ",";

            Console.Write("Submitter: ");
            line += Console.ReadLine() + ",";

            Console.Write("Assigned: ");
            line += Console.ReadLine() + ",";

            Console.Write("How many are watching?: ");
            var watchers = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < watchers; i++)
            {
                Console.Write($"Watcher #{i + 1}: ");
                line += Console.ReadLine();
                if (i < watchers) line += "|";
            }

            return line;
        }
    }
}

