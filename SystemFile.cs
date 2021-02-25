using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingSystem
{
    public class SystemFile
    {
        public string filePath {get; set;}
        public List<Ticket> Tickets {get; set;}

        public SystemFile(string file)
        {
            filePath = file;
            Tickets = new List<Ticket>();

            StreamReader sr = new StreamReader(filePath);
            
        }




        public void AddTicket(Ticket ticket)
        {
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{ticket.id},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|",ticket.watchers)}");
            sw.Close();

            Tickets.Add(ticket);
        }
    }








}

