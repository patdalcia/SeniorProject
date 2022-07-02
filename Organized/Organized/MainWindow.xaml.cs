using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set;}


        private businessService service;
        private CourseViewModel courseViewModel;
        private Course selectedCourse;

        public assignmentDetailsPage assignmentDetailsPage;

        public MainWindow()
        {
            selectedCourse = new Course();
            

            courseViewModel = new CourseViewModel();
            DataContext = courseViewModel;
          

            courseViewModel.Name = "";
            courseViewModel.Description = "";
            courseViewModel.StartDate = "";
            courseViewModel.EndDate = "";
            courseViewModel.Professor = "";
            courseViewModel.Assignments = new List<Assignment>();

            service = new businessService();

            InitializeComponent();

            Populate_Course_List();

            assignmentDetailsPage = new assignmentDetailsPage();
            assignmentDetailsPage.modelChanged += c_ModelChanged;
            assignmentDetailsPage.modelDeleted += c_ModelDeleted;
            
            assignmentDetailsFrame.Content = assignmentDetailsPage;

            Instance = this;
        }

        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Button Clicked");
        }

        private void Populate_Course_List()
        {
            List<Course> courseList = service.getCourses();
            courseListPanel.Children.Clear();

            if(courseList.Count > 0)
            {
                foreach (Course course in courseList)
                {
                    Button button = new Button();
                    button.Content = course.name;
                    button.Click += courseClick;
                    button.Tag = course;
                    courseListPanel.Children.Add(button);
                }
            }
            else
            {
                TextBlock text = new TextBlock()
                {
                    Text = "No Active Courses"
                };
                courseListPanel.Children.Add(text); 
            }
            
        }

        private void addCourse(object sender, RoutedEventArgs e)
        {
            addCourse addCourseView = new addCourse();

            addCourseView.ShowDialog();
            
            Populate_Course_List();
        }

        private void updateUpcomingAssignmentList()
        {

            upcomingAssignmentsPanel.Children.Clear();
            List<Assignment> upcomingAssignments = new List<Assignment>();
            CultureInfo provider = new CultureInfo("en-US");

            if (selectedCourse.assignments != null)
            {
                foreach (Assignment a in selectedCourse.assignments)
                {
                    DateTime date = DateTime.Parse(a.due_date, provider,
                    DateTimeStyles.AdjustToUniversal);

                    if (date <= DateTime.Today.AddDays(5))
                    {
                        upcomingAssignments.Add(a);
                    }
                }
                foreach (Assignment a in upcomingAssignments)
                {
                    Button button = new Button()
                    {
                        Content = a.name,
                        Tag = a,
                    };
                    button.Click += assignmentClick;
                    button.Margin = new Thickness(0, 0, 0, 0);
                    button.Height = 8;
                    upcomingAssignmentsPanel.Children.Add(button);
                }
            }
            else
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "No Assingments are due within 5 days, take a breather!";
                upcomingAssignmentsPanel.Children.Add(textBlock);
            }
        }

        private void courseClick(object sender, RoutedEventArgs e)
        {
            try
            {
                /* Updating view model with selected course information */
                selectedCourse = (sender as Button).Tag as Course;
                courseViewModel.Name = selectedCourse.name;
                courseViewModel.Description = selectedCourse.description;
                courseViewModel.StartDate = selectedCourse.start_date;
                courseViewModel.EndDate = selectedCourse.end_date;
                courseViewModel.Professor = selectedCourse.professor;

                assignmentDetailsPage.Course = selectedCourse;
                assignmentDetailsPage.Update_List();

                updateUpcomingAssignmentList();
            }
            catch(Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
        }

        private void assignmentClick(object sender, RoutedEventArgs e)
        {
            var assignment = (Assignment)(sender as Button).Tag;
            assignmentDetailsPage.Update_Model(assignment);
        }

        private void deleteCourse(object sender, RoutedEventArgs e)
        {
            if(selectedCourse != null)
            {
                if(service.deleteCourse(selectedCourse))
                {
                    courseViewModel.Name = "";
                    courseViewModel.Description = "";
                    courseViewModel.StartDate = "";
                    courseViewModel.EndDate = "";
                    courseViewModel.Professor = "";

                    Populate_Course_List();
                    MessageBox.Show("Course was deleted");
                }
                else
                {
                    MessageBox.Show("Course was not deleted");
                }
            }
            else
            {
                MessageBox.Show("No Course has been selected for deletion");
            }
        }

        public static void c_ModelChanged(object sender, EventArgs e)
        {
            Instance = Instance.updateInstance(Instance);

            Instance.selectedCourse = Instance.assignmentDetailsPage.Course;

            Instance.Populate_Course_List();
            Instance.updateUpcomingAssignmentList();
        }

        public static void c_ModelDeleted(object sender, EventArgs e)
        {
            Instance = Instance.updateInstance(Instance);

            Instance.selectedCourse = Instance.assignmentDetailsPage.Course;
            Instance.Populate_Course_List();
            Instance.updateUpcomingAssignmentList();
        }

        public MainWindow updateInstance(MainWindow instance)
        {
            instance = this;
            return instance;
        }
    }
}
