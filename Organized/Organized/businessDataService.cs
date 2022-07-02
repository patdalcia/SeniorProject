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

        String fileName = "Courses.json";
        public businessDataService()
        {

        }

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
    }
}
