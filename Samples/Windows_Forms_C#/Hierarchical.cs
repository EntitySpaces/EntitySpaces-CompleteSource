using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

using BusinessObjects;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;

namespace WindowsForms
{
    public partial class Hierarchical : Form
    {
        public Hierarchical()
        {
            InitializeComponent();

            EmployeesQuery q = new EmployeesQuery();
            q.es.Top = 15;
            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.BirthDate.As("ExtraColumn"));

            EmployeesCollection coll = new EmployeesCollection();
            coll.Load(q);

            dataGrid1.DataSource = coll;
        }
    }
}
