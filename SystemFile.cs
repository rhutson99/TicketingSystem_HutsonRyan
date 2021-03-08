using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingSystem
{
    public abstract class SystemFile
    {
        public static string filePath {get; set;}
        public static List<BugDefect> Bugs {get; set;}
        public static List<Enchancement> Enhance {get; set;}
        public static List<Task> Task {get; set;}

    }

        public class BugSystemFile : SystemFile
        {


        public BugSystemFile(string file)
        {
            filePath = file;
            Bugs = new List<BugDefect>();

            if(file == "Tickets.csv")
            {
            try{

            StreamReader sr = new StreamReader(filePath);
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

                public static void AddBugTicket(BugDefect ticket)
        {


            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)},{ticket.severity}");
            sw.Close();

            Bugs.Add(ticket);
            
        }


    }

    public class EnhancementSystemFile : SystemFile
    {
        public EnhancementSystemFile(string file)
        {
            filePath = file;
            Enhance = new List<Enchancement>();
            if(file == "Enhancements.csv")
            {
            try{

            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Enchancement ticket = new Enchancement();
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

        public static void AddEnhancement(Enchancement ticket)
        {


            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)},{ticket.software},{ticket.cost},{ticket.reason},{ticket.estimate}");
            sw.Close();

            Enhance.Add(ticket);
            
        }

    }

    public class TaskSystemFile : SystemFile
    {

                public TaskSystemFile(string file)
        {
            filePath = file;
            Task = new List<Task>();
            if(file == "Task.csv")
            {
            try{

            StreamReader sr = new StreamReader(filePath);
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

        public static void AddTask(Task ticket)
        {


            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)},{ticket.ProjectName},{ticket.DueDate}");
            sw.Close();

            Task.Add(ticket);
            
        }
    }






    

}

