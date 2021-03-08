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
            string input;

            


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
                Console.WriteLine("3) Task.");

                input = Console.ReadLine();

                //ticket system for bugs and defects
                if(input == "1")
                {
                    string file = "Tickets.csv";
                    BugSystemFile systemFile1 = new BugSystemFile(file);

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
                
                
                BugSystemFile.AddBugTicket(ticket);
                }

                //ticketing system for enhancements
                if(input == "2")
                {
                    string file = "Enhancements.csv";
                    EnhancementSystemFile systemFile2 = new EnhancementSystemFile(file);

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
                ticket.cost = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please input a reason.");
                ticket.reason = Console.ReadLine();
                Console.WriteLine("Please input an estimate.");
                ticket.estimate = Console.ReadLine();
                
                
                EnhancementSystemFile.AddEnhancement(ticket);
                }

                //ticketing system for tasks
                if(input == "3")
                {
                    string file = "Task.csv";
                    TaskSystemFile systemFile3 = new TaskSystemFile(file);

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
                
                
                TaskSystemFile.AddTask(ticket);
                }




            }

            else if(input == "2")
            {
                Console.Clear();
                Console.WriteLine("Bugs and Defects:");
                foreach(BugDefect t in BugSystemFile.Bugs)
                {
                    Console.WriteLine(t.Display());
                    Console.WriteLine();
                }

                Console.WriteLine("Enhancements:");
                foreach(Enchancement t in EnhancementSystemFile.Enhance)
                {
                    Console.WriteLine(t.Display());
                    Console.WriteLine();

                }

                Console.WriteLine("Tasks:");
                foreach(Task t in SystemFile.Task)
                {
                    Console.WriteLine(t.Display());
                    Console.WriteLine();

                }
            }
            }while (input == "1" || input == "2");
        }
    }
}
