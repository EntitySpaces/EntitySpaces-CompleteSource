using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

using NUnit.Framework;
using EntitySpaces.Core;
using EntitySpaces.DynamicQuery;
using BusinessObjects;
using Tests.Base;

namespace TestAllDatabases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            PopulateKeywords();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            FullNameViewCollection coll = new FullNameViewCollection();
            coll.es.Connection.Name = "SQLiteAggregateDb";

            try
            {
                //FullNameViewQuery vwQuery = new FullNameViewQuery();
                //vwQuery.Select(vwQuery.FullName, vwQuery.HireDate);
                //coll.Load(vwQuery);

                coll.Query.Select
                (
                    coll.Query.FullName.As(FullNameViewMetadata.PropertyNames.FullName),
                    coll.Query.HireDate.As(FullNameViewMetadata.PropertyNames.HireDate)
                );
                coll.Query.Load();

                //coll.LoadAll();

                int i = 0;
                foreach (FullNameView entity in coll)
                {
                    i++;
                    Debug.WriteLine(i.ToString() + " : " + entity.HireDate + " : " + entity.FullName);
                }

                if (coll != null)
                {
                    textBox1.Text = "Row count: " + coll.Count + "\r\n\r\n";
                }
                else
                {
                    textBox1.Text = "Collection is null.\r\n";
                }

                if (coll.Query.es.LastQuery != null)
                {
                    textBox1.Text += FormatLastQuery(coll.Query.es.LastQuery);
                }
                else
                {
                    textBox1.Text += "LastQuery is null.";
                }

                bindingSource1.DataSource = coll;
                dataGridView1.DataSource = bindingSource1;

                //coll.Filter = coll.AsQueryable().Where(d => 
                //    d.BirthDate >= Convert.ToDateTime("1950-01-01")
                //    && d.BirthDate <= Convert.ToDateTime("1959-12-31"));
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.ToString();

                if (coll.Query.es.LastQuery != null)
                {
                    textBox1.Text += "\r\n\r\n";
                    textBox1.Text += FormatLastQuery(coll.Query.es.LastQuery);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonINotify_Click(object sender, EventArgs e)
        {
            //Employee emp = (Employee)bindingSource1.Current;
            //emp.LastName = "INotify";
        }

        private string FormatLastQuery(string lq)
        {
            foreach (string keyword in keywords)
            {
                lq = lq.Replace(keyword, "\r\n" + keyword);
            }
            lq = lq.Substring(2, lq.Length - 2);

            return lq;
        }

        private void PopulateKeywords()
        {
            keywords.Add("SELECT");
            keywords.Add("FROM");
            keywords.Add("WHERE");
            keywords.Add("ORDER BY");
            keywords.Add("GROUP BY");
            keywords.Add("INNER");
            keywords.Add("LEFT");
            keywords.Add("RIGHT");
            keywords.Add("FULL");
            keywords.Add("ON");
            keywords.Add("WITH");
            keywords.Add("HAVING");
        }

        private List<string> keywords = new List<string>();
    }
}
