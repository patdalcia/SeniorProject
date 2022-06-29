using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    internal class Course
    {
        private String name;
        private String description;
        private String professor;
        private String start_date;
        private String end_date;
        private List<Assignment> assignments;
        public Course()
        {
            this.assignments = null;
        }

        public Course(string name, string description, string professor, string start_date, string end_date, List<Assignment> assignments)
        {
            this.name = name;
            this.description = description;
            this.professor = professor;
            this.start_date = start_date;
            this.end_date = end_date;
            this.assignments = assignments;
        } 
        
        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name=name;
        }

        public String getDescription()
        {
            return this.description;
        }

        public void setDescription(String description)
        {
            this.description=description;   
        }

        public String getProfessor()
        {
            return this.professor;
        }

        public void setProfessor(String professor)
        {
            this.professor=professor;   
        }

        public String getStartDate()
        {
            return this.start_date;
        }

        public void setStartDate(String start_date)
        {
            this.start_date=start_date;
        }

        public String getEndDate()
        {
            return this.end_date;
        }

        public void setEndDate(String end_date)
        {
            this.end_date=end_date;
        }

        public List<Assignment> getAssignments()
        {
            return this.assignments;
        }

        public void setAssignments(List<Assignment> assignments)
        {
            this.assignments = assignments; 
        }
    } 

}
