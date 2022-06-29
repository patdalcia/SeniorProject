using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    internal class businessDataService
    {
        public businessDataService()
        {

        }
        
        public List<Course> getCourses()
        {
            // Mock Data, will be populated from database or txt/xml file. 
            List<Course> courses = new List<Course>(); 
            
            for(int i = 0; i < 10; i++)
            {
                Course course = new Course();
                course.setName("Course: " + i.ToString());
                course.setDescription("Description: " + i.ToString());
                course.setProfessor("Professor: " + i.ToString());
                course.setStartDate("MOCK DATE: " + i.ToString());
                course.setEndDate("MOCK DATE: " + i.ToString());    
                courses.Add(course);
            }
            return courses; 
        }
    }
}
