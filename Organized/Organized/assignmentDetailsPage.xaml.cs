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
        Assignment selectedAssignment;
        assignmentViewModel viewModel;
        public assignmentDetailsPage(Assignment assignment)
        {
            selectedAssignment = assignment;
            viewModel = new assignmentViewModel();
            DataContext = viewModel;
            InitializeComponent();

            viewModel.Name = selectedAssignment.name;
            viewModel.Description = selectedAssignment.description;
            viewModel.DueDate = selectedAssignment.due_date;
            viewModel.Completed = selectedAssignment.completed;


            populateControls();           
        }

        private void populateControls()
        {
            /* First: Populate basic course info panel */

            //Assignment Name Label
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

            Label dueDateLabel = new Label()
            {
                FontSize = 13,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.Black,
                Margin = new Thickness(2),
                Padding = new Thickness(1)
            };
            var dueDateBindingObject = new Binding("DueDate");
            dueDateLabel.SetBinding(Label.ContentProperty, dueDateBindingObject);

            Label completedLabel = new Label()
            {
                FontSize = 13,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.Black,
                Margin = new Thickness(2),
                Padding = new Thickness(1)
            };
            var completedBindingObject = new Binding("Completed");
            completedLabel.SetBinding(Label.ContentProperty, completedBindingObject);

            assignmentNamePanel.Children.Add(nameLabel);
            assignmentNamePanel.Children.Add(descriptionLabel);
            assignmentNamePanel.Children.Add(dueDateLabel);
            assignmentNamePanel.Children.Add(completedLabel);
        }
    }
}
