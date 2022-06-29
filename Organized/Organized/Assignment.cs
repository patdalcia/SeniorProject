using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    
    internal class Assignment
    {
        private String name;
        private String description;
        private String due_date;
        private bool completed;

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

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name =name;    
        }

        public String getDescription()
        {
            return this.description;
        }

        public void setDescription(String description)
        {
            this.description=description;   
        }

        public String getDueDate(String due_date)
        {
            return this.due_date;
        }

        public void setDueDate(String due_date)
        {
            this.due_date=due_date; 
        }

        public bool getCompleted()
        {
            return this.completed;
        }

        public void setCompleted(bool completed)
        {
            this.completed=completed;
        }
    }
}
