using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WCFConsumer_Thin.ServiceReference1;
using Proxies;

namespace WCFConsumer_Thin
{
    public partial class Form1 : Form
    {
        Service1Client svc = new Service1Client();
        EmployeesCollectionProxyStub coll;

        public Form1()
        {
            InitializeComponent();

            Proxies.EmployeesQueryProxyStub q = new Proxies.EmployeesQueryProxyStub();
            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate, (q.LastName + ", " + q.FirstName).As("Fullname"));

            coll = svc.Employees_QueryForCollection(q);

            this.dataGrid.DataSource = coll.Collection;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmployeesProxyStub emp = new EmployeesProxyStub();
            emp.FirstName = "Mr.";
            emp.LastName = "EntitySpaces";
            coll.Collection.Add(emp);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGrid.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                EmployeesProxyStub emp = row.DataBoundItem as EmployeesProxyStub;
                emp.FirstName = "Changed";
                emp.LastName = "Changed";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGrid.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                EmployeesProxyStub emp = row.DataBoundItem as EmployeesProxyStub;
                emp.MarkAsDeleted();
            }

            coll = svc.Employees_SaveCollection(coll);
            this.dataGrid.DataSource = coll.Collection;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            coll = svc.Employees_SaveCollection(coll);
            this.dataGrid.DataSource = coll.Collection;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            Proxies.EmployeesQueryProxyStub q = new Proxies.EmployeesQueryProxyStub("emp");

            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate, (q.LastName + ", " + q.FirstName).As("Fullname"));
            q.Where(q.LastName.Like("%" + txtLastName.Text + "%"));
            q.OrderBy(q.LastName.Ascending);

            coll = svc.Employees_QueryForCollection(Proxies.EmployeesQueryProxyStub.SerializeHelper.ToXml(q));

            if (coll == null)
            {
                coll = new EmployeesCollectionProxyStub();
            }

            this.dataGrid.DataSource = coll.Collection;
        }
    }
}
