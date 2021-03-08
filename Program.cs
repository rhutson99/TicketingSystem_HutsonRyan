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
            Console.WriteLine("2) Display tickets.");
            Console.WriteLine("Enter any other key to exit.");

            input = Console.ReadLine();

            if(input == "1")
            {
                if (File.Exists(file))
                {
                    BugDefect ticket = new BugDefect();
                //create ticket
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

                Console.WriteLine("Please input a severity.");
                ticket.severity = Console.ReadLine();
                
                
                SystemFile.AddTicket(ticket);
                

                }



            }

            else if(input == "2")
            {
                Console.Clear();
                foreach(Ticket t in SystemFile.Tickets)
                {
                    Console.WriteLine(t.Display());
                    Console.WriteLine();
                }
            }
            }while (input == "1" || input == "2");
        }
    }
}
