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
using EntitySpaces.SilverlightApplication.NorthwindClient;
using Proxies;

namespace EntitySpaces.SilverlightApplication.Views
{
    public partial class SimpleDataGrid : Page
    {
        private NorthwindClient.NorthwindClient service = new NorthwindClient.NorthwindClient();
        private Proxies.EmployeesCollectionProxyStub employees;
        private Storyboard Timer = new Storyboard();
        private int RecordsAdded;

        public SimpleDataGrid()
        {
            InitializeComponent();

            Timer.Completed += new EventHandler(Timer_Completed);
            Timer.Duration = TimeSpan.FromMilliseconds(2);

            service.Employees_QueryForCollectionCompleted += new EventHandler<Employees_QueryForCollectionCompletedEventArgs>(Employees_QueryForCollectionCompleted);
            service.Employees_SaveCollectionCompleted += new EventHandler<Employees_SaveCollectionCompletedEventArgs>(Employees_SaveCollectionCompleted);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Proxies.EmployeesQueryProxyStub q = new Proxies.EmployeesQueryProxyStub("emp");
                q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate, (q.LastName + ", " + q.FirstName).As("Fullname"));
                q.Where
                (
                    q.FirstName.Like("%" + SearchTextBox.Text + "%") | q.LastName.Like("%" + SearchTextBox.Text + "%")
                );

                service.Employees_QueryForCollectionAsync(q);

                WorkingBar.Value = 0;
                Timer.Begin();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }

        void Employees_QueryForCollectionCompleted(object sender, Employees_QueryForCollectionCompletedEventArgs e)
        {
            WorkingBar.Value = 100;
            Timer.Stop();

            if (e.Result != null)
            {
                employees = e.Result;
                EmployeesDataGrid.ItemsSource = employees.Collection;
            }
            else
            {
                EmployeesDataGrid.ItemsSource = null;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            employees = null;
            EmployeesDataGrid.ItemsSource = null;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (employees == null) return;

                WorkingBar.Value = 0;
                Timer.Begin();

                service.Employees_SaveCollectionAsync(employees);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (employees == null)
            {
                employees = new EmployeesCollectionProxyStub();
                EmployeesDataGrid.ItemsSource = employees.Collection;
            }

            if (RecordsAdded++ < 5)
            {
                EmployeesProxyStub newEmp = new EmployeesProxyStub();
                newEmp.FirstName = "Scott";
                newEmp.LastName = "Schecter";

                employees.Collection.Add(newEmp);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesProxyStub emp = EmployeesDataGrid.SelectedItem as EmployeesProxyStub;

            employees.Collection.Remove(emp);

            emp.MarkAsDeleted();
            service.Employees_SaveEntityAsync(emp);
        }

        void Employees_SaveCollectionCompleted(object sender, Employees_SaveCollectionCompletedEventArgs e)
        {
            try
            {
                WorkingBar.Value = 100;
                Timer.Stop();

                RecordsAdded = 0;

                employees = e.Result;
                EmployeesDataGrid.ItemsSource = employees.Collection;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Enter Criteria Here")
            {
                SearchTextBox.Text = "";
            }
        }

        void Timer_Completed(object sender, EventArgs e)
        {
            WorkingBar.Value++;
            Timer.Begin();

            if (WorkingBar.Value >= 100)
            {
                WorkingBar.UpdateLayout();
                WorkingBar.Value = 1;
            }
        }
    }
}
