﻿using System;
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
    /// Interaction logic for addCourse.xaml
    /// </summary>
    public partial class addCourse : Window
    {
        private businessService service;
        public addCourse()
        {
            InitializeComponent();
            service = new businessService();
        }

        private void createCourse(object sender, RoutedEventArgs e)
        {
            try
            {
                //Mock Assignment
                Assignment assignment = new Assignment()
                {
                    name = "Test",
                    description = "Test",
                    due_date = "1/1/2001",
                    completed = false
                };

                List<Assignment> aList = new List<Assignment>();
                aList.Add(assignment);

                Course course = new Course()
                {
                    name = name.Text,
                    description = description.Text,
                    professor = professor.Text,
                    start_date = String.Format("{0:dd MM yyyy}", startDate.Text),
                    end_date = String.Format("{0:dd MM yyyy}", endDate.Text),
                    assignments = aList
                };

                if(service.addCourse(course))
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("ERROR: Could not add Course");
                }
            }
            catch(Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
        }
    }
}