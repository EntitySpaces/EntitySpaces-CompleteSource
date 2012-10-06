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
using Microsoft.Phone.Controls;

using Proxies;
using WindowsPhone.MyNorthwindService;

namespace WindowsPhone
{
    public partial class esDemo : PhoneApplicationPage
    {
        private NorthwindClient service = new NorthwindClient();

        public esDemo()
        {
            InitializeComponent();

            // Create our Query Object
            EmployeesQueryProxyStub query = new EmployeesQueryProxyStub();
            query.es.Top = 20; // Limit it to 20 
            query.Select(query.EmployeeID, query.FirstName, query.LastName);

            service.Employees_QueryForCollectionCompleted += new 
                EventHandler<Employees_QueryForCollectionCompletedEventArgs>(service_Employees_QueryForCollectionCompleted);

            // Make the request on our Serivce
            service.Employees_QueryForCollectionAsync(query);
        }

        void service_Employees_QueryForCollectionCompleted(object sender, Employees_QueryForCollectionCompletedEventArgs e)
        {
            // Bind
            myListBox.ItemsSource = e.Result.Collection;
        }
    }
}