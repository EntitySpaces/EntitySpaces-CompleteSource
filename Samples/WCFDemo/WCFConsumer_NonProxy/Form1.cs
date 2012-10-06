using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EntitySpaces.Core;
using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace WCFConsumer_NonProxy
{
    public partial class Form1 : Form
    {
        WCFConsumer_NonProxy.ServiceReference1.NonProxyServiceClient svc = new WCFConsumer_NonProxy.ServiceReference1.NonProxyServiceClient();

        BusinessObjects.EmployeesCollection coll;

        public Form1()
        {
            InitializeComponent();

            System.Net.ServicePointManager.Expect100Continue = false;

            this.dataGrid.AutoGenerateColumns = true;

            EmployeesQuery q = new EmployeesQuery();
            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate);

            coll = svc.Employees_QueryForCollection(EmployeesQuery.SerializeHelper.ToXml(q));

            coll.EnableHierarchicalBinding = false;

            _bindingSource.DataSource = coll;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            BusinessObjects.Employees emp = coll.AddNew();
            emp.FirstName = "Mr.";
            emp.LastName = "EntitySpaces";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dataGrid.SelectedRows;

                foreach (DataGridViewRow row in selectedRows)
                {
                    BusinessObjects.Employees emp = row.DataBoundItem as BusinessObjects.Employees;
                    emp.FirstName = "Changed";
                    emp.LastName = "Changed";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dataGrid.SelectedRows;

                foreach (DataGridViewRow row in selectedRows)
                {
                    BusinessObjects.Employees emp = row.DataBoundItem as BusinessObjects.Employees;

                    if (emp == null) continue; // they tried to delete the "New Record Row"

                    emp.MarkAsDeleted();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                coll = svc.Employees_SaveCollection(coll);
                coll.EnableHierarchicalBinding = false;
                _bindingSource.DataSource = coll;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            EmployeesQuery q = new EmployeesQuery("emp");
            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate);

            q.Where(q.LastName.Like("%" + txtLastName.Text + "%"));
            q.OrderBy(q.LastName.Ascending);

            coll = svc.Employees_QueryForCollection(EmployeesQuery.SerializeHelper.ToXml(q));
            coll.EnableHierarchicalBinding = false;
            _bindingSource.DataSource = coll;
        }
    }
}
