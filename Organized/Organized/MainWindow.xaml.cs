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

            foreach (Course course in courseList)
            {
                Button button = new Button()
                {
                    Foreground = Brushes.Gold,
                    BorderBrush = Brushes.Gold
                };


                StackPanel card = new StackPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    
                };

                TextBlock nameBlock = new TextBlock() 
                { 
                  Text = course.getName(),
                  HorizontalAlignment = HorizontalAlignment.Center,
                  VerticalAlignment= VerticalAlignment.Center
                };

                TextBlock descriptionBlock = new TextBlock() 
                { 
                    Text= course.getDescription() ,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                TextBlock dateBlock = new TextBlock() 
                { 
                    Text = course.getStartDate() + " - " + course.getEndDate(), 
                    HorizontalAlignment= HorizontalAlignment.Center,
                    VerticalAlignment =  VerticalAlignment.Center
                };

                card.Children.Add(nameBlock);
                card.Children.Add(descriptionBlock);
                card.Children.Add(dateBlock);
                button.Content = card;
                CoursesNavPanel.Children.Add(button);
            }
        }

        private StackPanel generateCard(Course course)
        {
            StackPanel wrapperCard = new StackPanel() { HorizontalAlignment= HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };    
            StackPanel card = new StackPanel() { HorizontalAlignment= HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };

            Button button = new Button() { Content = course.getName() + "\n" + course.getDescription() + "\n" + course.getStartDate() + " - " + course.getEndDate() };
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;

            //card.Children.Add(button);
            CoursesNavPanel.Children.Add(button);
         
            return card;
        }
    }
}
