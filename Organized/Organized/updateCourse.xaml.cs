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
    /// Interaction logic for updateCourse.xaml
    /// </summary>
    public partial class updateCourse : Window
    {
        private businessService service;
        private CourseViewModel courseViewModel;
        private Course c;

        public Course updatedCourse
        {
            get;
            set;
        }

        public updateCourse(Course course)
        {
            c = course;
            updatedCourse = null;

            service = new businessService();
            courseViewModel = new CourseViewModel();
            courseViewModel.Name = course.name;
            courseViewModel.Description = course.description;
            courseViewModel.Professor = course.professor;
            courseViewModel.StartDate = course.start_date;
            courseViewModel.EndDate = course.end_date;

            DataContext = courseViewModel;

            InitializeComponent();
        }

        private void updateCourseClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(name.Text != "" || description.Text != "" || professor.Text != "" || startDate.Text != "" || endDate.Text != "")
                {
                    updatedCourse = c;

                    updatedCourse.name = name.Text;
                    updatedCourse.description = description.Text;
                    updatedCourse.professor = professor.Text;
                    updatedCourse.start_date = startDate.Text;
                    updatedCourse.end_date = endDate.Text;

                    this.Close();
                }
                else
                {
                    this.Close();
                }
                

                
            }
            catch(Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
            
        }
    }
}
