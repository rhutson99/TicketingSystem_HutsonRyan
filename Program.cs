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
            string file1 = "Tickets.csv";
            string file2 = "Enhancements.csv";
            string file3 = "Task.csv";
            string input;

            SystemFile systemFile1 = new SystemFile(file1);
            SystemFile systemFile2 = new SystemFile(file2);
            SystemFile systemFile3 = new SystemFile(file3);

            //ask user input menu
            do{
            Console.WriteLine("1) Create a new ticket.");
            Console.WriteLine("2) Display tickets.");
            Console.WriteLine("Enter any other key to exit.");

            input = Console.ReadLine();

            if(input == "1")
            {
                //user menu for choosing what kind of ticket to create
                Console.WriteLine("1) Bug or Defect.");
                Console.WriteLine("2) Enhancement.");
                Console.WriteLine("3) Task");

                input = Console.ReadLine();

                //ticket system for bugs and defects
                if(input == "1")
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
                Console.WriteLine("Please input a submitter.");
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

                //ticketing system for enhancements
                if(input == "2")
                {
                    Enchancement ticket = new Enchancement();
                //create ticket
                Console.WriteLine("Please input a ticket ID.");
                ticket.id = Console.ReadLine();
                Console.WriteLine("Please input a ticket summary.");
                ticket.summary = Console.ReadLine();
                Console.WriteLine("Please input a status.");
                ticket.status = Console.ReadLine();
                Console.WriteLine("Please input a priority.");
                ticket.priority = Console.ReadLine();
                Console.WriteLine("Please input a submitter.");
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

                Console.WriteLine("Please input a software.");
                ticket.software = Console.ReadLine();
                Console.WriteLine("Please input a cost.");
                ticket.cost = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please input a reason.");
                ticket.reason = Console.ReadLine();
                Console.WriteLine("Please input an estimate.");
                ticket.estimate = Console.ReadLine();
                
                
                SystemFile.AddTicket(ticket);
                }

                //ticketing system for tasks
                if(input == "3")
                {
                    Task ticket = new Task();
                //create ticket
                Console.WriteLine("Please input a ticket ID.");
                ticket.id = Console.ReadLine();
                Console.WriteLine("Please input a ticket summary.");
                ticket.summary = Console.ReadLine();
                Console.WriteLine("Please input a status.");
                ticket.status = Console.ReadLine();
                Console.WriteLine("Please input a priority.");
                ticket.priority = Console.ReadLine();
                Console.WriteLine("Please input a submitter.");
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

                Console.WriteLine("Please input a project name.");
                ticket.ProjectName = Console.ReadLine();
                Console.WriteLine("Please input a due date in MM/DD/YYYY format.");
                ticket.DueDate = DateTime.Parse(Console.ReadLine());
                
                
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
