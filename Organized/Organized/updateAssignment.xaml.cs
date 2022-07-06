using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for updateAssignment.xaml
    /// </summary>
    public partial class updateAssignment : Window
    {
        public Assignment updatedAssignment
        {
            get;
            set;
        }

        private assignmentViewModel viewModel;

        public updateAssignment(Assignment a)
        {
            viewModel = new assignmentViewModel();

            DataContext = viewModel;

            viewModel.Name = a.name;
            viewModel.Description = a.description;
            viewModel.DueDate = a.due_date;
            viewModel.Completed = a.completed;

            InitializeComponent();
        }

        private void updateAssignmentClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" || description.Text != "" || dueDate.Text != "" || completedNo.IsChecked != false && completedYes.IsChecked != false)
                {
                    updatedAssignment = new Assignment();

                    updatedAssignment.name = name.Text;
                    updatedAssignment.description = description.Text;
                    updatedAssignment.due_date = dueDate.Text;
                    if(completedNo.IsChecked == true)
                        updatedAssignment.completed = false;
                    if (completedYes.IsChecked == true)
                        updatedAssignment.completed = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fields Were left Blank, Aborting changes please try again");
                    this.Close();
                }



            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
        }
    }
}
