namespace A1TicketingSystem
{
    public class Program
    {
        public static void Main()
        {
            string menu;

            Console.WriteLine("Ticketing System\n___________");

            FileManager fileManager = new FileManager();
            do
            {
                Console.WriteLine("1. Read data from file.\n2. Create file from data.\n3. Exit.\n___________");
                menu = Console.ReadLine();
                Console.WriteLine();

                //Option 1: Read data from file.
                if (menu == "1")
                {
                    Console.WriteLine("Enter Filename:\n___________");
                    fileManager.read(Console.ReadLine());   
                }

                //Option 2: Create file from data.
                else if(menu == "2")
                {
                    Console.WriteLine("Enter Filename:\n___________");
                    fileManager.create(Console.ReadLine());
                }
            } while (menu != "3");
            Console.WriteLine("Exiting...");
        }
    
    }
}

