using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    public class CourseViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _name;
        public String Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private String _description;
        public String Description
        {
            get => _description;
            //set => SetProperty(ref _description, value);
            set
            {
                SetProperty(ref _description, value);
                OnPropertyChanged("Description");
            }
        }

        private String _professor;
        public String Professor
        {
            get => _professor;
            set => SetProperty(ref _professor, value);
        }

        private String _startDate;
        public String StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private String _endDate;
        public String EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private List<Assignment> _assignments;
        public List<Assignment> Assignments
        {
            get => _assignments;
            set => SetProperty(ref _assignments, value);
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Name))
                        return "Name is Required";
                }
                else if (columnName == "Description")
                {
                    if (string.IsNullOrEmpty(Description))
                        return "Description is Required";
                }
                else if (columnName == "Professor")
                {
                    if (string.IsNullOrEmpty(Professor))
                        return "Professor is Required";
                }
                else if (columnName == "StartDate")
                {
                    if (string.IsNullOrEmpty(StartDate))
                        return "Start Date is Required";
                }
                else if (columnName == "EndDate")
                {
                    if (string.IsNullOrEmpty(EndDate))
                        return "End Date is Required";
                    else if (StartDate != null)
                        if (StartDate.Equals(EndDate))
                            return "Invalid Date Range";
                }

                // If there's no error, null gets returned
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
