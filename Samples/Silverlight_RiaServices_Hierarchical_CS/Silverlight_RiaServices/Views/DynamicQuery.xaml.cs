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

using Silverlight_RiaServices.Web;

using BusinessObjects;
using System.ServiceModel.DomainServices.Client;

namespace Silverlight_RiaServices.Views
{
    public partial class DynamicQuery : Page
    {
        public DynamicQuery()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void customersDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs ee)
        {
            string searchText = txtCompanyName.Text;

            if (searchText.Length == 0)
            {
                searchText = "%"; // everybody
            }

            CustomersQueryProxyStub c = new CustomersQueryProxyStub();
            c.Where(c.CompanyName.Like(searchText));

            esDomainContext context = this.customersDomainDataSource.DomainContext as esDomainContext;

            context.Load(context.Customers_LoadByDynamicQuery(c), LoadBehavior.RefreshCurrent,
                MyOtherCallback, null);
        }

        void MyOtherCallback(LoadOperation<Customers> loadOperation)
        {
            customersDataGrid.ItemsSource = loadOperation.Entities;
        }

    }
}
