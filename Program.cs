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
                    string file1 = "Tickets.csv";
                    BugSystemFile systemFile1 = new BugSystemFile(file1);
                     string file2 = "Enhancements.csv";
                    EnhancementSystemFile systemFile2 = new EnhancementSystemFile(file2);
                    string file3 = "Task.csv";
                    TaskSystemFile systemFile3 = new TaskSystemFile(file3);
            


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


                    Enhancement ticket = new Enhancement();
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
                try{
                    StreamReader sr = new StreamReader(file1);
                    while (!sr.EndOfStream)
                    {

                        Console.WriteLine(sr.ReadLine());


                    }
                    sr.Close();
                }

                catch(FileNotFoundException)
                {
                    Console.WriteLine("No bugs or defects listed");
                }


                Console.WriteLine("Enhancements:");
                try{
                    StreamReader sr1 = new StreamReader(file2);
                    while (!sr1.EndOfStream)
                    {

                        Console.WriteLine(sr1.ReadLine());


                    }
                    sr1.Close();
                }

                catch(FileNotFoundException)
                {
                    Console.WriteLine("No enhancements listed");
                }


                Console.WriteLine("Tasks:");
                try{
                    StreamReader sr2 = new StreamReader(file3);
                    while (!sr2.EndOfStream)
                    {

                        //read movie file

                        Console.WriteLine(sr2.ReadLine());

                        // display library


                    }
                    sr2.Close();
                }

                catch(FileNotFoundException)
                {
                    Console.WriteLine("No tasks listed");
                }

            }
            }while (input == "1" || input == "2");
        }
    }
}
