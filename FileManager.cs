namespace A1TicketingSystem
{
    public class FileManager
    {
        
        public void read(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);

                //Skip the header line
                //Instead of discarding it, parse it to use in formatting output.
                var headers = sr.ReadLine().Split(',');

                //Read the file out to console.
                while (!sr.EndOfStream)
                {
                    var lineArray = sr.ReadLine().Split(',');

                    for(int i = 0; i < 7; i++)
                    {
                        if(i < 6)
                            Console.WriteLine($"{headers[i]}: {lineArray[i]}");
                        else
                        {
                            var watchers = lineArray[i].Split('|');
                            Console.Write($"{headers[i]}: ");
                            for(int x = 0; x < watchers.Length; x++)
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
                        Console.WriteLine();
                    }
                }
                sr.Close();
            }else
            {
                Console.WriteLine($"{filename} does not exist");
            }

        }

        public void create(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");

            string addAnother;
            do
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

                for(int i = 0; i < watchers; i++)
                {
                    Console.Write($"Watcher #{i+1}: ");
                    line += Console.ReadLine();
                    if (i < watchers) line += "|";
                }

                sw.WriteLine(line);

                Console.WriteLine("Add another ticket? (Y/N)");
                addAnother = Console.ReadLine().ToUpper();
            } while (addAnother == "Y");


            sw.Close();
        }
    }
}

