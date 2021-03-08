using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingSystem
{
    public class SystemFile
    {
        public static string filePath {get; set;}
        public static List<Ticket> Tickets {get; set;}

        public SystemFile(string file)
        {
            filePath = file;
            Tickets = new List<Ticket>();

            try{

            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Ticket ticket = new BugDefect();
                string line = sr.ReadLine();
                string[] TicketDetails = line.Split(",");
                ticket.id = TicketDetails[0];
                ticket.summary = TicketDetails[1];
                ticket.status = TicketDetails[2];
                ticket.priority = TicketDetails[3];
                ticket.submitter = TicketDetails[4];
                ticket.assigned = TicketDetails[5];
                ticket.watchers = TicketDetails[6].Split('|').ToList();
                Tickets.Add(ticket);

            }
            sr.Close();
            }
            catch{
                                {
                    Console.WriteLine("No file found. Creating new file.");
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                    sw.Close();
                }
            }

        }




        public static void AddTicket(Ticket ticket)
        {
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)}");
            sw.Close();

            Tickets.Add(ticket);
        }
    }








}

