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
        public MainWindow()
        {
            InitializeComponent();
            service = new businessService();
            Populate_Course_List();
        }

        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Button Clicked");
        }

        private void Populate_Course_List()
        {
            List<Course> courseList = service.getCourses();

            CoursesNavPanel.Children.Clear();

            TextBlock courseHeader = new TextBlock()
            {
                Text = "Courses",
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = Brushes.Gold,
                FontSize = 20
            };

            CoursesNavPanel.Children.Add(courseHeader);

            if(courseList.Count > 0)
            {
                foreach (Course course in courseList)
                {
                    Button button = new Button()
                    {
                        MinHeight = 50,
                        MinWidth = 70,
                        FontSize = 10,
                        Margin = new Thickness(0, 0, 5, 5),
                        Style = (Style)Resources["roundedCornerButtonStyle"],
                        Tag = course,
                        
                    };
                    button.Click += courseClick;

                    StackPanel card = new StackPanel()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,

                    };

                    TextBlock nameBlock = new TextBlock()
                    {
                        Text = course.name,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    card.Children.Add(nameBlock);
                    button.Content = card;

                    CoursesNavPanel.Children.Add(button);
                }
            }
            else
            {
                TextBlock text = new TextBlock()
                {
                    Text = "You have no ACTIVE Courses",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                CoursesNavPanel.Children.Add(text);
            }
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
