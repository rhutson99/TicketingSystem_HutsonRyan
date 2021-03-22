using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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
            Console.WriteLine("3) Search for a ticket.");
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
                
                
                systemFile1.AddBugTicket(ticket);
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
                
                
                systemFile2.AddEnhancement(ticket);
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
                
                
                systemFile3.AddTask(ticket);
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

            else if(input == "3")
            {
                Console.WriteLine("1) Search by status.");
                Console.WriteLine("2) Search by priority.");
                Console.WriteLine("3) Search by submitter.");

                string type = Console.ReadLine();

                if(type == "1")
                {
                    Console.WriteLine("Please enter the status to search for.");
                    string search = Console.ReadLine();
                    var stsearch1 = systemFile1.Bugs.Where(t => t.status.Contains(search, StringComparison.OrdinalIgnoreCase));
                    var stsearch2 = systemFile2.Enhance.Where(t => t.status.Contains(search, StringComparison.OrdinalIgnoreCase));
                    var stsearch3 = systemFile3.Task.Where(t => t.status.Contains(search, StringComparison.OrdinalIgnoreCase));
                    int stsearchresults = stsearch1.Count() + stsearch2.Count() + stsearch3.Count();
                    Console.WriteLine($"There are {stsearchresults} tickets with the search query as the status.");



                }

                if(type == "2")
                {
                   Console.WriteLine("Please enter the priority to search for.");
                    string search = Console.ReadLine();
                    var psearch1 = systemFile1.Bugs.Where(t => t.priority.Contains(search, StringComparison.OrdinalIgnoreCase));
                    var psearch2 = systemFile2.Enhance.Where(t => t.priority.Contains(search, StringComparison.OrdinalIgnoreCase));
                    var psearch3 = systemFile3.Task.Where(t => t.priority.Contains(search, StringComparison.OrdinalIgnoreCase));
                    int psearchresults = psearch1.Count() + psearch2.Count() + psearch3.Count();
                    Console.WriteLine($"There are {psearchresults} tickets with the search query as the priority."); 
                }

                if(type == "3")
                {
                    Console.WriteLine("Please enter the submitter to search for.");
                    string search = Console.ReadLine();
                    var susearch1 = systemFile1.Bugs.Where(t => t.submitter.Contains(search, StringComparison.OrdinalIgnoreCase));
                    var susearch2 = systemFile2.Enhance.Where(t => t.submitter.Contains(search, StringComparison.OrdinalIgnoreCase));
                    var susearch3 = systemFile3.Task.Where(t => t.submitter.Contains(search, StringComparison.OrdinalIgnoreCase));
                    int susearchresults = susearch1.Count() + susearch2.Count() + susearch3.Count();
                    Console.WriteLine($"There are {susearchresults} tickets with the search query as the status");
                }



            }


            }while (input == "1" || input == "2" || input == "3");
        }
    }
}
