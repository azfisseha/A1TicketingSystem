namespace A1TicketingSystem
{
    public class Program
    {
        public static void Main()
        {
            string menu;
            string filename = "tickets.csv";

            FileManager fileManager = new FileManager();
            do
            {
                Console.WriteLine("1. Read data from file.");
                Console.WriteLine("2. Create file from data.");
                Console.WriteLine("3. Exit.");
                menu = Console.ReadLine();

                //Option 1: Read data from file.
                if(menu == "1")
                {
                    fileManager.read(filename);   
                }

                //Option 2: Create file from data.
                else if(menu == "2")
                {
                    fileManager.create(filename);
                }
            } while (menu != "3");
        }
    
    }
}

