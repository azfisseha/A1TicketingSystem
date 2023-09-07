namespace A1TicketingSystem
{

    /// <summary>
    /// An object that handles file input and output for the ticketing system.
    /// 
    /// Uses <see cref="TicketHandler"/>
    /// </summary>
    public class FileManager
    {

        private TicketHandler ticketHandler = new TicketHandler();

        /// <summary>
        /// Opens a given filename and reads the ticket data within to the console.
        /// </summary>
        /// <param name="filename"></param>
        public void read(string filename)
        {
            Console.WriteLine("___________");

            if (File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);

                //Skip the header line
                //Instead of discarding it, parse it to use in formatting output.
                string[] headers = sr.ReadLine().Split(',');

                //Read the file out to console, line by line.
                while (!sr.EndOfStream)
                {
                    ticketHandler.readTicket(headers, sr.ReadLine().Split(','));
                }
                sr.Close();
            }else
            {
                Console.WriteLine($"{filename} does not exist\n");
            }
            Console.WriteLine("___________");

        }

        /// <summary>
        /// Writes out to a file with the given filename and writes user-submitted ticket data to it.
        /// In the event the file already exists, confirms with user whether they wish to append, overwrite, or neither.
        /// </summary>
        /// <param name="filename"></param>
        public void create(string filename)
        {
            Console.WriteLine("___________");
            var append = false;
            if (File.Exists(filename))
            {
                //Confirm if the user intends to overwrite the file that exists or just add tickets to it.
               
                char menu;
                do
                {
                    Console.WriteLine("1. Append to existing file.\n2. Overwrite existing file.\n3. Return to Main Menu.\n___________");
                    menu = Console.ReadLine().ToUpper()[0];
                    switch (menu)
                    {
                        case '1':
                            append = true;
                            break;
                        case '2':
                            append = false;
                            break;
                        case '3':
                            Console.WriteLine("Returning to Main Menu...\n");
                            return;
                    }
                } while (menu != '1' && menu != '2' && menu != '3');
            }
            StreamWriter sw = new StreamWriter(filename, append);

            //Write the header line if this is a new file.
            if(!append) sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");

            //Collect ticket information and write to file.
            char addAnother;
            do
            {
                sw.WriteLine(ticketHandler.buildTicket());
                Console.WriteLine("Add another ticket? (Y)es/(N)o");
                addAnother = Console.ReadLine().ToUpper()[0];
                Console.WriteLine("___________");
            } while (addAnother == 'Y');

            sw.Close();
        }
    }
}

