using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EntitySpaces.Interfaces;
using BusinessObjects;

namespace SqlCeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EmployeeCollection coll = new EmployeeCollection();
            EmployeeQuery query = coll.Query; // short hand

            query.Select(query.EmployeeID, query.LastName, query.FirstName);

            if (coll.Query.Load())
            {
                this.dataGrid1.DataSource = coll;
            }
        }
    }
}