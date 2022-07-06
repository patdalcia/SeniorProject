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

        /* GETS all courses */
        public List<Course> getCourses()
        {
            return service.getCourses();
        }

        /* ADDS course to list */
        public bool addCourse(Course course)
        {
            return service.addCourse(course);
        }

        /* ADDS assignment to Course.assignments */
        public Course addAssignment(Course course, Assignment assignment)
        {
            return service.addAssignment(course, assignment);
        }

        /* DELETES assignment from Course.assignments */
        public Course deleteAssignment(String assignment, String course)
        {
            return service.deleteAssignment(assignment, course);
        }

        /* UPDATES Course in list, with updated Course object */
        public bool updateCourse(Course course)
        {
            return service.updateCourse(course);
        }

        /* DELETES Course from course list */
        public bool deleteCourse(Course course)
        {
            return service.deleteCourse(course);
        }

        /* UPDATES Course in list after UpdateCourse dialog */
        public bool updateCourseFromDialog(Course course, Course courseToBeUpdated)
        {
            return service.updateCourseFromDialog(course, courseToBeUpdated);
        }

        /* UPDATED Assignment in list */
        public List<Assignment> updateAssignment(Course course, Assignment assignment, String aName)
        {
            return service.updateAssignment(course, assignment, aName);
        }
    }
}
