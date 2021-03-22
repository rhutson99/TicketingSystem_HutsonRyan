using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingSystem
{


        public class BugSystemFile
        {
            public string filePath1 {get; set;}
            public List<BugDefect> Bugs {get; set;}


        public BugSystemFile(string file)
        {
            filePath1 = file;
            Bugs = new List<BugDefect>();

            if(File.Exists(file))
            {
            try{

            StreamReader sr = new StreamReader(filePath1);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                BugDefect ticket = new BugDefect();
                string line = sr.ReadLine();
                string[] TicketDetails = line.Split(",");
                ticket.id = TicketDetails[0];
                ticket.summary = TicketDetails[1];
                ticket.status = TicketDetails[2];
                ticket.priority = TicketDetails[3];
                ticket.submitter = TicketDetails[4];
                ticket.assigned = TicketDetails[5];
                ticket.watchers = TicketDetails[6].Split('|').ToList();
                ticket.severity = TicketDetails[7];
                Bugs.Add(ticket);

            }
            sr.Close();
            }
            catch{
                                
                    Console.WriteLine("No file found. Creating new file.");
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                    sw.Close();
                
            }
            
            }
        }

                public void AddBugTicket(BugDefect ticket)
        {


            StreamWriter sw = new StreamWriter(filePath1, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)},{ticket.severity}");
            sw.Close();

            Bugs.Add(ticket);
            
        }


    }

    public class EnhancementSystemFile
    {

        public string filePath2 {get; set;}
        public List<Enhancement> Enhance {get; set;}
        public EnhancementSystemFile(string file)
        {
            filePath2 = file;
            Enhance = new List<Enhancement>();
            if(File.Exists(file))
            {
            try{

            StreamReader sr = new StreamReader(filePath2);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Enhancement ticket = new Enhancement();
                string line = sr.ReadLine();
                string[] TicketDetails = line.Split(",");
                ticket.id = TicketDetails[0];
                ticket.summary = TicketDetails[1];
                ticket.status = TicketDetails[2];
                ticket.priority = TicketDetails[3];
                ticket.submitter = TicketDetails[4];
                ticket.assigned = TicketDetails[5];
                ticket.watchers = TicketDetails[6].Split('|').ToList();
                ticket.software = TicketDetails[7];
                ticket.cost = Convert.ToDouble(TicketDetails[8]);
                ticket.reason = TicketDetails[9];
                ticket.estimate = TicketDetails[10];
                Enhance.Add(ticket);

            }
            sr.Close();
            }
            catch{
                                {
                    Console.WriteLine("No file found. Creating new file.");
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate");
                    sw.Close();
                }
            }
            }
        }

        public void AddEnhancement(Enhancement ticket)
        {


            StreamWriter sw = new StreamWriter(filePath2, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)},{ticket.software},{ticket.cost},{ticket.reason},{ticket.estimate}");
            sw.Close();

            Enhance.Add(ticket);
            
        }

    }

    public class TaskSystemFile
    {

        public string filePath3 {get; set;}
        public List<Task> Task {get; set;}

                public TaskSystemFile(string file)
        {
            filePath3 = file;
            Task = new List<Task>();
            if(File.Exists(file))
            {
            try{

            StreamReader sr = new StreamReader(filePath3);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Task ticket = new Task();
                string line = sr.ReadLine();
                string[] TicketDetails = line.Split(",");
                ticket.id = TicketDetails[0];
                ticket.summary = TicketDetails[1];
                ticket.status = TicketDetails[2];
                ticket.priority = TicketDetails[3];
                ticket.submitter = TicketDetails[4];
                ticket.assigned = TicketDetails[5];
                ticket.watchers = TicketDetails[6].Split('|').ToList();
                ticket.ProjectName = TicketDetails[7];
                ticket.DueDate = DateTime.Parse(TicketDetails[8]);
                Task.Add(ticket);

            }
            sr.Close();
            }
            catch{
                                {
                    Console.WriteLine("No file found. Creating new file.");
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate");
                    sw.Close();
                }
            }
            }

        }

        public void AddTask(Task ticket)
        {


            StreamWriter sw = new StreamWriter(filePath3, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)},{ticket.ProjectName},{ticket.DueDate}");
            sw.Close();

            Task.Add(ticket);
            
        }
    }






    

}

