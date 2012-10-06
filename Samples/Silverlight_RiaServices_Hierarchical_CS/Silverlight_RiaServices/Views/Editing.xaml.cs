using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

using BusinessObjects;

namespace Silverlight_RiaServices.Views
{
    public partial class Editing : Page
    {
        public Editing()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void employeesDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employeesDomainDataSource.SubmittedChanges +=
                    new System.EventHandler<SubmittedChangesEventArgs>(OnSubmittedChanges);

                employeesDomainDataSource.SubmitChanges();
            }
            catch { }
        }

        void OnSubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                // Prevents the application from throwing an exception
                e.MarkErrorAsHandled();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Employee
            Employees emp = new Employees();
            emp.FirstName = "David";
            emp.LastName = "Parsons";

            // Add it to the context so RIA knows about it
            employeesDomainDataSource.DataView.Add(emp);
        }

        private void btnMarkAsDeleted_Click(object sender, RoutedEventArgs e)
        {
            Employees emp = employeesDataGrid.SelectedItem as Employees;

            if (emp != null)
            {
                employeesDomainDataSource.DataView.Remove(emp);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            employeesDomainDataSource.Clear();
            employeesDomainDataSource.RejectChanges();
            employeesDomainDataSource.Load();
        }
    }
}
