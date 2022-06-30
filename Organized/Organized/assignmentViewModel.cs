using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    public class assignmentViewModel : ViewModelBase
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

        private String _dueDate;
        public String DueDate
        {
            get => _dueDate;
            set => SetProperty(ref _dueDate, value);
        }

        private bool _completed;
        public bool Completed
        {
            get => _completed;
            set => SetProperty(ref _completed, value);
        }
    }
}
