using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Organized
{
    public class Course
    {
        public String name { get; set; }
        public String description { get; set; }
        public String professor { get; set; }
        public String start_date { get; set; }
        public String end_date { get; set; }
        public List<Assignment> assignments { get; set; }
        //private List<Assignment> assignments;

        public Course()
        {

        }
        public Course(string name, string description, string professor, string start_date, string end_date)
        {
            this.name = name;
            this.description = description;
            this.professor = professor;
            this.start_date = start_date;
            this.end_date = end_date;
        } 
      
    } 

}
