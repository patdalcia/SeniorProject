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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Organized
{
    /// <summary>
    /// Interaction logic for assignmentDetailsPage.xaml
    /// </summary>
    public partial class assignmentDetailsPage : Page
    {
        /* Event handlers used to update UI in Main Window */
        public event EventHandler modelChanged;
        public event EventHandler modelDeleted;

        Assignment selectedAssignment;


        public assignmentViewModel viewModel;
        private businessService service;

        private Course _course;
        public Course Course
        {
            get => _course; 
            set => _course = value; 
        }

        public assignmentDetailsPage()
        {
            service = new businessService();

            viewModel = new assignmentViewModel();
            DataContext = viewModel;
            InitializeComponent();

            viewModel.Name = "";
            viewModel.Description = "";
            viewModel.DueDate = "";
            viewModel.Completed = false;


            populateControls();           
        }

        /* Populates all UI controls with current information from Course Object */
        private void populateControls()
        {
            assignmentListPanel.Children.Clear();

            /* First: Populate basic course info panel */
            if (Course != null)
            {
                if (Course.assignments != null && Course.assignments.Count > 0)
                {
                    foreach (Assignment assignment in Course.assignments)
                    {
                        Button button = new Button()
                        {
                            Content = assignment.name,
                            Tag = assignment,

                        };
                        button.Click += assignmentClick;
                        assignmentListPanel.Children.Add(button);
                    }
                }
                else
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "No Active Assignments";
                }
            }
        }

        /* Click listener, triggers when an assignment from the list has been selected. Updates viewModel with selected assignment information */
        private void assignmentClick(object sender, RoutedEventArgs e)
        {
            Assignment assignment = (Assignment)(sender as Button).Tag;
            viewModel.Name = assignment.name;
            viewModel.Description = assignment.description;
            viewModel.DueDate = assignment.due_date;
            viewModel.Completed = assignment.completed;
        }

        /* Updates view model */
        public void Update_Model(Assignment assignment)
        {
            viewModel.Name = assignment.name;
            viewModel.Description = assignment.description;
            viewModel.DueDate = assignment.due_date;
            viewModel.Completed = assignment.completed;
        }

        /* Used to call private method populateControls(); */
        public void Update_List()
        {
            populateControls();
        }

        /* Click Listener, triggers when addAssignment button is clicked */
        private void addAssignmentClick(object sender, RoutedEventArgs e)
        {
            if(Course != null)
            {
                addAssignment addAssignment = new addAssignment(Course);
                addAssignment.ShowDialog();

                if(addAssignment.updatedCourse != null)
                {
                    Course = addAssignment.updatedCourse;

                    modelChanged?.Invoke(this, EventArgs.Empty);

                    populateControls();
                }
                
            }
            else
            {
                MessageBox.Show("A course must be selected to add an assignment, please select one from the list");
            }
        }

        /* Click Listener, Triggers when deleteAssignment button is clicked */
        private void deleteAssignmentClick(object sender, RoutedEventArgs e)
        {
            var assignmentName = (String)(sender as Button).Tag;

            if (assignmentName == null || assignmentName == "" || Course == null || Course.assignments == null || Course.assignments.Count == 0)
            {
                MessageBox.Show("No assignment has been selected");
            }
            else
            {
                Course = service.deleteAssignment(assignmentName, Course.name);
                if (Course != null)
                {
                    Update_List();

                    modelDeleted?.Invoke(this, EventArgs.Empty);   

                    MessageBox.Show("Course Was Successfully deleted");
                }
                else
                {
                    Update_List();
                    MessageBox.Show("Course was Not deleted");
                }
            }
        }

        /* Click Listener, triggers when completeAssignment button is clicked */
        private void completeAssignmentClick(object sender, RoutedEventArgs e)
        {
            var search = (String)(sender as Button).Tag;

            if(search == null || search == "" || Course == null || Course.assignments == null || Course.assignments.Count == 0)
            {
                MessageBox.Show("No assignment has been selected");
            }
            else
            {
                var assignmentToEdit = Course.assignments.Single(r => r.name == search);
                Course.assignments.Remove(assignmentToEdit);

                assignmentToEdit.completed = true;

                Course.assignments.Add(assignmentToEdit);

                if (service.updateCourse(Course))
                {
                    viewModel.Completed = true;
                    MessageBox.Show("Course was Updated");
                }
                else
                {
                    MessageBox.Show("Course was not Updated");
                }
            }          
        }

        private void updateAssignmentClick(object sender, RoutedEventArgs e)
        {
            var assignmentName = (String)(sender as Button).Tag;

            if (assignmentName == null || assignmentName == "" || Course == null || Course.assignments == null || Course.assignments.Count == 0)
            {
                MessageBox.Show("No assignment has been selected");
            }
            else
            {
                Assignment a = new Assignment();
                foreach(var assignment in Course.assignments)
                {
                    if(assignment.name == assignmentName)
                    {
                        a.name = assignment.name;
                        a.description = assignment.description;
                        a.due_date = assignment.due_date;
                        a.completed = assignment.completed;
                        break;
                    }
                }
                updateAssignment uAssignment = new updateAssignment(a);
                uAssignment.ShowDialog();

                if (uAssignment.updatedAssignment != null)
                {
                    List<Assignment> aList = service.updateAssignment(Course, uAssignment.updatedAssignment, assignmentName);
                    if (aList != Course.assignments)
                    {
                        Course.assignments = aList;

                        viewModel.Name = uAssignment.updatedAssignment.name;
                        viewModel.Description = uAssignment.updatedAssignment.description;
                        viewModel.DueDate = uAssignment.updatedAssignment.due_date;
                        viewModel.Completed = uAssignment.updatedAssignment.completed;

                        Update_List();
                        modelChanged?.Invoke(this, EventArgs.Empty);

                        MessageBox.Show("Course Was Updated");
                    }
                    else
                    {
                        MessageBox.Show("Course Was Not Updated");
                    }
                }
                else
                {
                    Update_List();
                    MessageBox.Show("Course was Not Updated");
                }
            }
        }
    }
}
