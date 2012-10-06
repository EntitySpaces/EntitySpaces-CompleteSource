using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace WCFConsumer_Thick
{
    public partial class Form1 : Form
    {
        WCFConsumer_Thick.ServiceReference1.Service1Client svc = new WCFConsumer_Thick.ServiceReference1.Service1Client();

        BusinessObjects.EmployeesCollection coll;

        public Form1()
        {
            InitializeComponent();

            this.dataGrid.AutoGenerateColumns = true;

            EmployeesQuery q = new EmployeesQuery();
            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate, (q.LastName + ", " + q.FirstName).As("Fullname"));

            EmployeesCollectionProxyStub proxyColl = svc.Employees_QueryForCollection(EmployeesQuery.SerializeHelper.ToXml(q));

            _bindingSource.DataSource = coll = proxyColl.GetCollection();
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
                if (coll.IsDirty)
                {
                    EmployeesCollectionProxyStub proxyColl = new EmployeesCollectionProxyStub(coll);
                    proxyColl = svc.Employees_SaveCollection(proxyColl);

                    _bindingSource.DataSource = coll = proxyColl.GetCollection();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            EmployeesQuery q = new EmployeesQuery("emp");

            q.Where(q.LastName.Like("%" + txtLastName.Text + "%"));
            q.OrderBy(q.LastName.Ascending);

            EmployeesCollectionProxyStub proxyColl = svc.Employees_QueryForCollection(EmployeesQuery.SerializeHelper.ToXml(q));

            if (proxyColl != null)
            {
                _bindingSource.DataSource = coll = proxyColl.GetCollection();
            }
            else
            {
                _bindingSource.DataSource = coll = new BusinessObjects.EmployeesCollection();
            }
        }
    }
}
