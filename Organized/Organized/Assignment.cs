using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    
    public class Assignment 
    {
        public String name { get; set; }
        public String description { get; set; }
        public String due_date { get; set; }
        public bool completed { get; set; }

        public Assignment()
        {
            this.completed = false; 
        }

        public Assignment(string name, string description, string due_date, bool completed)
        {
            this.name = name;
            this.description = description;
            this.due_date = due_date;
            this.completed = completed;
        }
    }
}
