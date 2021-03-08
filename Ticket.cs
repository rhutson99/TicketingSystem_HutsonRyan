using System;
using System.Collections.Generic;

namespace TicketingSystem
{

    public abstract class Ticket
    {
        public string id {get; set;}
        public string summary {get; set;}
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public List<string> watchers {get; set;}

        public Ticket()
        {
            watchers = new List<string>();
        }

        public virtual string Display()
        {
            return $"{id}\nSum: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nPerson assigned: {assigned}\nWatchers: {string.Join(",", watchers)}";
        }
    }

    public class BugDefect : Ticket
    {
        public string severity {get; set;}

        public override string Display()
        {
            return $"{id}\nSum: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nPerson assigned: {assigned}\nWatchers: {string.Join(",", watchers)}\nSeverity: {severity}";
        }
    }

    public class Enchancement : Ticket
    {
        public string software {get; set;}
        public int cost {get; set;}
        public string reason {get; set;}
        public string estimate {get; set;}

        public override string Display()
        {
            return $"{id}\nSum: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nPerson assigned: {assigned}\nWatchers: {string.Join(",", watchers)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate} ";
        }
    }

    public class Task : Ticket
    {
        public string ProjectName {get; set;}
        public DateTime DueDate {get; set;}

        public override string Display()
        {
            return $"{id}\nSum: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nPerson assigned: {assigned}\nWatchers: {string.Join(",", watchers)}\nProject Name: {ProjectName}\nDue Date: {DueDate}";
        }
    }



}