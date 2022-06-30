using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Organized
{
    /// <summary>
    /// Interaction logic for addAssignment.xaml
    /// </summary>
    public partial class addAssignment : Window
    {
        Course selectedCourse;
        businessService service;

        public Course updatedCourse { get; set; }
        public addAssignment(Course course)
        {
            selectedCourse = course;
            service = new businessService();
            InitializeComponent();
        }

        private void addAssignmentClick(object sender, RoutedEventArgs e)
        {
            Assignment assignment = new Assignment()
            {
                name = name.Text,
                description = description.Text,
                due_date = String.Format("{0:dd MM yyyy}", dueDate.Text),
                completed = false
            };
            if(completedNo.IsChecked == true)
            {
                assignment.completed = false;
            }
            else if(completedYes.IsChecked == true)
            {
                assignment.completed = true;
            }

            updatedCourse = service.addAssignment(selectedCourse, assignment);
            this.Close();
        }
    }
}
