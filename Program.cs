using System;
using System.IO;
using System.Collections.Generic;
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
                    Ticket ticket = new Ticket();
                //create ticket
                StreamWriter sw = new StreamWriter(file, append: true);
                Console.WriteLine("Please input a ticket ID.");
                ticket.id = Console.ReadLine();
                Console.WriteLine("Please input a ticket summary.");
                ticket.summary = Console.ReadLine();
                Console.WriteLine("Please input a status.");
                ticket.status = Console.ReadLine();
                Console.WriteLine("Please input a priority.");
                ticket.priority = Console.ReadLine();
                Console.WriteLine("Please input a Submitter.");
                ticket.submitter = Console.ReadLine();
                Console.WriteLine("Please input the person assigned.");
                ticket.assigned = Console.ReadLine();
                Console.WriteLine("Please input a watcher.");
                
                 //multiple inputs for watcher on one ticket

                int i;
                for(i=0; i < 3; i++)
                {
                    string watch = Console.ReadLine();
                    ticket.watchers.Add(watch);
                    Console.WriteLine("Would you like to add another watcher? (Y/N)");
                    string res = Console.ReadLine().ToUpper();
                    if (res != "Y") {break;}
                }
                
                SystemFile.AddTicket(ticket);
                

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
