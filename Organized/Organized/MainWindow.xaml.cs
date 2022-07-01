using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private businessService service;
        private CourseViewModel courseViewModel;
        public MainWindow()
        {
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
            populateCourseInformationPanel();
            Populate_Course_List();
        }

        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Button Clicked");
        }

        private void Populate_Course_List()
        {
            List<Course> courseList = service.getCourses();
            courseListPanel.Children.Clear();

            foreach (Course course in courseList)
            {
                Button button = new Button();
                button.Content = course.name;
                courseListPanel.Children.Add(button);
            }
        }

        private void populateCourseInformationPanel()
        {
            List<Course> courseList = service.getCourses();

            /* Setting Course Header Information */
            StackPanel courseInformationPanel = new StackPanel();
            courseInformationBorder.Child = courseInformationPanel;

            //Course Name Label
            Label nameLabel = new Label()
            {
                FontSize = 30,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.Gold,
                Margin = new Thickness(2),
                Padding = new Thickness(1),
            };
            var nameBindingObject = new Binding("Name");
            nameLabel.SetBinding(Label.ContentProperty, nameBindingObject);

            //Course Description Label
            Label descriptionLabel = new Label()
            {
                FontSize = 13,
                FontWeight = FontWeights.ExtraLight,
                Foreground = Brushes.Black,
                Margin = new Thickness(2),
                Padding = new Thickness(1)
            };
            var descriptionBindingObject = new Binding("Description");
            descriptionLabel.SetBinding(Label.ContentProperty, descriptionBindingObject);

            //Course professor label
            Label professorLabel = new Label()
            {
                FontSize = 13,
                FontWeight = FontWeights.ExtraLight,
                Foreground = Brushes.Black,
                Margin = new Thickness(2),
                Padding = new Thickness(1)
            };
            var professorBindingObject = new Binding("Professor");
            descriptionLabel.SetBinding(Label.ContentProperty, descriptionBindingObject);

            //Course Start Date Label
            Label startDateLabel = new Label()
            {
                FontSize = 13,
                FontWeight = FontWeights.ExtraLight,
                Foreground = Brushes.Black,
                Margin = new Thickness(2),
                Padding = new Thickness(1)
            };
            var startDateBindingObject = new Binding("StartDate");
            descriptionLabel.SetBinding(Label.ContentProperty, descriptionBindingObject);

            //Coures End Date Label
            Label endDateLabel = new Label()
            {
                FontSize = 13,
                FontWeight = FontWeights.ExtraLight,
                Foreground = Brushes.Black,
                Margin = new Thickness(2),
                Padding = new Thickness(1)
            };
            var endDateBindingObject = new Binding("EndDate");
            descriptionLabel.SetBinding(Label.ContentProperty, descriptionBindingObject);

            /* Adding created Labels to Course Information Panel For Display */
            courseInformationPanel.Children.Add(nameLabel);
            courseInformationPanel.Children.Add(descriptionLabel);
            courseInformationPanel.Children.Add(professorLabel);
            courseInformationPanel.Children.Add(startDateLabel);
            courseInformationPanel.Children.Add(endDateLabel);
        }

        private void addCourse(object sender, RoutedEventArgs e)
        {
            addCourse addCourseView = new addCourse();

            addCourseView.ShowDialog();
            
            Populate_Course_List();
        }

        private void courseClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Course course = (sender as Button).Tag as Course;
                Trace.WriteLine(JsonSerializer.Serialize(course));
                courseView courseView = new courseView(course);
                courseView.DataContext = this;
                courseView.ShowDialog();
            }
            catch(Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
        }
    }
}
