using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Organized
{
    internal class businessDataService
    {

        /* Path to JSON file containing course information */
        String fileName = "Courses.json";
        public businessDataService(){}

        /* GETS all courses */
        public bool addCourse(Course course)
        {
            string jsonString = JsonSerializer.Serialize(course);
            Trace.WriteLine(jsonString);

            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(jsonString);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(jsonString);
                }
            }

                return true;     
        }

        /* ADDS course to list */
        public List<Course> getCourses()
        {
            try
            {
                String[] jsonStrings = File.ReadAllLines(fileName);
                List<Course> courses = new List<Course>();
                foreach (String jsonString in jsonStrings)
                {
                    courses.Add(JsonSerializer.Deserialize<Course>(jsonString)!);                   
                }
                return courses;
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.ToString());
                return null;
            }
        }

        /* ADDS assignment to Course.assignments */
        public Course addAssignment(Course course, Assignment assignment)
        {
            try
            {
                //Retrieving course List
                List<Course> cList = this.getCourses();

                if(cList != null)
                {
                    String search = course.name;
                    var courseToBeUpdated = cList.Where(courseToBeUpdated => courseToBeUpdated.name == search).FirstOrDefault();

                    foreach(Course c in cList)
                    {
                        if (c.name == search)
                        {
                            c.assignments.Add(assignment);
                            break;
                        }
                    }

                    if (updateSavedCourses(cList))
                    {
                        return cList.Where(courseToBeUpdated => courseToBeUpdated.name == search).FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("Error: Could not add Assignment");
                    }

                    return null;
                }
                else
                {
                    throw new Exception("Error: Could not add Assignment");
                    return null;
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.ToString());
                return course;
            }
        }

        /* UPDATES JSON file with updated course list */
        private bool updateSavedCourses(List<Course> courses)
        {
            try
            {
                //Clearing stored information
                File.WriteAllText(fileName, "");

                foreach (Course course in courses)
                {
                    string jsonString = JsonSerializer.Serialize(course);
                    Trace.WriteLine(jsonString);

                    if (!File.Exists(fileName))
                    {
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            sw.WriteLine(jsonString);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            sw.WriteLine(jsonString);
                        }
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.ToString());
                return false;
            }
              
        }

        /* DELETES assignment from Course.assignments */
        public Course deleteAssignment(String assignment, String course)
        {
            try
            {
                //Retrieving course List
                List<Course> cList = this.getCourses();

                var courseToEdit = cList.Single(r => r.name == course);
                cList.Remove(courseToEdit);

                var assignmentToRemove = courseToEdit.assignments.Single(r => r.name == assignment);
                courseToEdit.assignments.Remove(assignmentToRemove);

                cList.Add(courseToEdit);

                if(updateSavedCourses(cList))
                {
                    return courseToEdit;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception exception)
            {
                Trace.WriteLine(exception.ToString());
                return null ;
            }
            
        }

        /* UPDATES Course in list, with updated Course object */
        public bool updateCourse(Course course)
        {
            //Retrieving course List
            List<Course> cList = this.getCourses();

            var courseToEdit = cList.Single(r => r.name == course.name);
            cList.Remove(courseToEdit);

            courseToEdit = course;

            cList.Add(courseToEdit);

            if(updateSavedCourses(cList))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* DELETES Course from course list */
        public bool deleteCourse(Course course)
        {
            //Retrieving course List
            List<Course> cList = this.getCourses();

            var courseToEdit = cList.Single(r => r.name == course.name);
            cList.Remove(courseToEdit);

            if (updateSavedCourses(cList))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* UPDATES course after updateCourse dialog is shown and closed */
        public bool updateCourseFromDialog(Course course, Course courseToBeUpdated)
        {
            //Retrieving course List
            List<Course> cList = this.getCourses();

            var courseToEdit = cList.Single(r => r.name == course.name);
            cList.Remove(courseToEdit);

            courseToEdit = courseToBeUpdated;

            cList.Add(courseToEdit);

            if (updateSavedCourses(cList))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* UPDATES course in list */
        public List<Assignment> updateAssignment(Course course, Assignment assignment, String aName)
        {
            try
            {
                //Retrieving course List
                List<Course> cList = this.getCourses();

                var courseToEdit = cList.Single(r => r.name == course.name);
                cList.Remove(courseToEdit);

                var assignmentToRemove = courseToEdit.assignments.Single(r => r.name == aName);
                courseToEdit.assignments.Remove(assignmentToRemove);

                courseToEdit.assignments.Add(assignment);
                cList.Add(courseToEdit);

                if (updateSavedCourses(cList))
                {
                    return courseToEdit.assignments;
                }
                else
                {
                    return course.assignments;
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.ToString());
                return course.assignments;
            }
        }
    }
}
