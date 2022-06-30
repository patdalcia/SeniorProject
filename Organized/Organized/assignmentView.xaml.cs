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
    /// Interaction logic for assignmentView.xaml
    /// </summary>
    public partial class assignmentView : Window
    {
        Assignment selectedAssignment;
        public assignmentView(Assignment assignment)
        {
            selectedAssignment = assignment;   
            InitializeComponent();
            this.populateControls();
        }

        private void populateControls()
        {
            TextBox nameBox = new TextBox()
            {
                Text = selectedAssignment.name
            };

            TextBox descriptionBox = new TextBox()
            {
                Text = selectedAssignment.description
            };

            TextBox dateBox = new TextBox()
            {
                Text = selectedAssignment.due_date
            };

            TextBox completedBox = new TextBox()
            {
                Text = selectedAssignment.completed.ToString()
            };

            titlePanel.Children.Add(nameBox);
            descriptionPanel.Children.Add(descriptionBox);
            datePanel.Children.Add(dateBox);
            completedPanel.Children.Add(completedBox); 
        }
    }
}
