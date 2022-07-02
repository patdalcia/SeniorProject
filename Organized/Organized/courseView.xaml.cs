using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for courseView.xaml
    /// </summary>
    public partial class courseView : Window
    {
        private businessService service;
        private Course selectedCourse;
        public courseView(Course course)
        {
            service = new businessService();
            selectedCourse = course;
            InitializeComponent();
            populateCourseView();
            populateAssignmentList();
            getUpcomingAssignments();   
        }

        private void returnToDash(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void populateCourseView()
        {
            courseInfoPanel.Children.Clear();
            /* First: Populate basic course info panel */
            Label nameLabel = new Label()
            {
                FontSize = 25,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.Gold,
                Margin= new Thickness(2),
                Content = selectedCourse.name,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0.5),
                Padding = new Thickness(1)
            };

            Label descriptionLabel = new Label()
            {
                Content = selectedCourse.description,
                FontSize = 13,
                FontWeight = FontWeights.ExtraLight,
                Foreground = Brushes.White,
                Margin = new Thickness(2),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0.5),
                Padding = new Thickness(1)
            };

            Label professorLabel = new Label()
            {
                Content = selectedCourse.professor,
                FontSize = 13,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.White,
                Margin = new Thickness(2),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0.5),
                Padding = new Thickness(1)
            };

            Label dateLabel = new Label()
            {
                Content = String.Format("{0:dd MM yyyy}", selectedCourse.start_date) + " - " + String.Format("{0:dd MM yyyy}", selectedCourse.end_date),
                FontSize = 13,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.White,
                Margin = new Thickness(2),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0.5),
                Padding = new Thickness(1)
            };

            courseInfoPanel.Children.Add(nameLabel);
            courseInfoPanel.Children.Add(professorLabel);
            courseInfoPanel.Children.Add(descriptionLabel);
            courseInfoPanel.Children.Add(dateLabel);

        }

        private void populateAssignmentList()
        {
            assingmentListPanel.Children.Clear();
           foreach(Assignment assignment in selectedCourse.assignments)
            {
                Button button = new Button();
                button.Content = assignment.name;
                button.Style = (Style)Resources["assignmentListButtons"]; 
                button.Tag = assignment;
                button.Click += assignmentClick;
                assingmentListPanel.Children.Add(button);
            }
            
        }

        private void addAssignmentClick(Object sender, RoutedEventArgs e)
        {
            addAssignment addAssignment = new addAssignment(selectedCourse);

            if(!addAssignment.ShowDialog().Value)
            {
                selectedCourse = addAssignment.updatedCourse;
            }
            this.refresh();
        }

        private void assignmentClick(Object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("CLick");
            Assignment a = (Assignment)(sender as Button).Tag;
            //assignmentView assignmentView = new assignmentView(a);
            //var updatedCourse =assignmentView.ShowDialog();
           // assignmentDetailsPage assignmentDetailsPage = new assignmentDetailsPage(a);
           // assignmentDetailsFrame.Content = assignmentDetailsPage;
        }

        private void getUpcomingAssignments()
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

        private void refresh()
        {
            populateCourseView();
            populateAssignmentList();
            getUpcomingAssignments();
        }
    }
}
