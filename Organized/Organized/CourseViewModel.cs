using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    public class CourseViewModel : ViewModelBase
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
            set => SetProperty(ref _description, value);
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
    }
}
