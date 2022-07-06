using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Organized
{
    public class Course : IDataErrorInfo, INotifyPropertyChanged
    {
        public String name { get; set; }
        public String description { get; set; }
        public String professor { get; set; }
        public String start_date { get; set; }
        public String end_date { get; set; }
        public List<Assignment> assignments { get; set; }
        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(name))
                        return "Name is Required";
                }
                else if (columnName == "Description")
                {
                    if (string.IsNullOrEmpty(description))
                        return "Description is Required";
                }
                else if (columnName == "Professor")
                {
                    if (string.IsNullOrEmpty(professor))
                        return "Professor is Required";
                }
                else if (columnName == "StartDate")
                {
                    if (string.IsNullOrEmpty(start_date))
                        return "Start Date is Required";
                }
                else if (columnName == "EndDate")
                {
                    if (string.IsNullOrEmpty(end_date))
                        return "End Date is Required";
                }

                // If there's no error, null gets returned
                return null;
            }
        }

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

        public event PropertyChangedEventHandler? PropertyChanged;
    } 

}
