using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;
using EntitySpaces.DynamicQuery;
using EntitySpaces.Profiler;

using BusinessObjects;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        EmployeesCollection coll = new EmployeesCollection();
        bool acending = false;
        bool filtered = false;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            coll = new EmployeesCollection();
            coll.LoadAll();

            _bindingSource.DataSource = coll;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                coll.Save();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (acending)
            {
                acending = false;
                coll.Filter = coll.AsQueryable().OrderByDescending(d => d.LastName);
            }
            else
            {
                acending = true;
                coll.Filter = coll.AsQueryable().OrderBy(d => d.LastName);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (filtered)
            {
                filtered = false;
                coll.Filter = null;
            }
            else
            {
                filtered = true;
                coll.Filter = coll.AsQueryable().Where(d => d.FirstName.Contains("a"));
            }
        }

        private void btnFilterSort_Click(object sender, EventArgs e)
        {
            if (acending)
            {
                acending = false;
                coll.Filter = coll.AsQueryable().Where(d => d.FirstName.Contains("a"));
            }
            else
            {
                acending = true;
                coll.Filter = coll.AsQueryable().Where(d => d.FirstName.Contains("a")).OrderBy(d => d.LastName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employees emp = coll.AddNew();
            emp.FirstName = "Joe";
            emp.LastName = "Smith";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;

            List<Employees> list = new List<Employees>();
            foreach (DataGridViewRow item in selectedRows)
            {
                Employees emp = item.DataBoundItem as Employees;

                if (emp != null)
                {
                    list.Add(emp);
                }
            }

            foreach (Employees emp in list)
            {
                emp.MarkAsDeleted();
            }
        }

        private void btnChangeFirstName_Click(object sender, EventArgs e)
        {
            foreach (Employees emp in coll)
            {
                emp.FirstName = "Sally";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;

            coll = new EmployeesCollection();
            coll.LoadAll();

            _bindingSource.DataSource = coll;
        }

        private void btnDynamicQuery_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            EmployeesQuery eq = new EmployeesQuery("eq");
            OrdersQuery oq = new OrdersQuery("oq");

            eq.Select(eq.EmployeeID, eq.LastName, eq.FirstName, oq.OrderID, oq.ShipCity);
            eq.InnerJoin(oq).On(eq.EmployeeID == oq.EmployeeID);

            coll = new EmployeesCollection();
            coll.Load(eq);

            _bindingSource.DataSource = coll;
        }

        private void btnBeginProfiling_Click(object sender, EventArgs e)
        {
            ProfilerListener.BeginProfiling("EntitySpaces.SqlClientProvider", 
                ProfilerListener.Channels.Channel_1);
        }

        private void btnEndProfiling_Click(object sender, EventArgs e)
        {
            ProfilerListener.EndProfiling("EntitySpaces.SqlClientProvider");
        }
    }
}
