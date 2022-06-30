using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    internal class businessService
    {
        private businessDataService service;

        public businessService()
        {
            service = new businessDataService();
        }

        public List<Course> getCourses()
        {
            return service.getCourses();
        }

        public bool addCourse(Course course)
        {
            return service.addCourse(course);
        }

        public Course addAssignment(Course course, Assignment assignment)
        {
            return service.addAssignment(course, assignment);
        }
    }
}
