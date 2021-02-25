using System;
using System.IO;
using System.Collections;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string input;

            SystemFile systemFile = new SystemFile(file);

            //ask user input menu
            do{
            Console.WriteLine("1) Create a new ticket.");
            Console.WriteLine("Enter any other key to exit.");

            input = Console.ReadLine();

            if(input == "1")
            {
                if (File.Exists(file))
                {
                //create ticket
                StreamWriter sw = new StreamWriter(file, append: true);
                Console.WriteLine("Please input a ticket ID.");
                string iD = Console.ReadLine();
                Console.WriteLine("Please input a ticket summary.");
                string sum = Console.ReadLine();
                Console.WriteLine("Please input a status.");
                string stat = Console.ReadLine();
                Console.WriteLine("Please input a priority.");
                string prior = Console.ReadLine();
                Console.WriteLine("Please input a Submitter.");
                string sub = Console.ReadLine();
                Console.WriteLine("Please input the person assigned.");
                string assign = Console.ReadLine();
                Console.WriteLine("Please input a watcher.");
                
                 //multiple inputs for watcher on one ticket

                ArrayList watchers = new ArrayList();
                int i;
                for(i=0; i < 3; i++)
                {
                    string watch = Console.ReadLine();
                    watchers.Add(watch);
                    Console.WriteLine("Would you like to add another watcher? (Y/N)");
                    string res = Console.ReadLine().ToUpper();
                    if (res != "Y") {break;}
                }
                sw.Write("{0},{1},{2},{3},{4},{5},", iD, sum, stat, prior, sub, assign);
                foreach(var d in watchers)
                {
                    sw.Write("{0}|", d);
                }
                sw.WriteLine();
                sw.Close();
                }

                //set up file with headers
                else
                {
                    Console.WriteLine("No file found. Creating new file.");
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                    sw.Close();
                }


            }
            }while (input == "1");
        }
    }
}
