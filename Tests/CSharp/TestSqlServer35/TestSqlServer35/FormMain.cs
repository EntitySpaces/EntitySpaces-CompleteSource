using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Tests.Base;
using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;
using BusinessObjects;
using EntitySpaces.Profiler;

namespace TestSqlServer35
{
    public partial class FormMain : Form
    {
        ProductsCollection coll = new ProductsCollection();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            // ListBox
            ProductsCollection prdColl = new ProductsCollection();
            prdColl.Query.Select(prdColl.Query.ProductID, prdColl.Query.ProductName);
            prdColl.Query.Load();

            listBox1.DisplayMember = ProductsMetadata.PropertyNames.ProductName;
            listBox1.ValueMember = ProductsMetadata.PropertyNames.ProductID;
            listBox1.DataSource = prdColl;

            // DataGridView

            // The main query

            coll = new ProductsCollection();
            coll.Query.Where(coll.Query.Discontinued == false);
            coll.Query.Load();

            bindingSource1.DataSource = coll;
            dataGridView1.DataSource = bindingSource1;
        }

        private void CopyAnnotationData(int fromAnnotationId, int toAnnotationId)
        {
            Annotation ann = new Annotation();
            if (!ann.LoadByPrimaryKey(toAnnotationId))
            {
                MessageBox.Show("To Annotation Not found");
                return;
            }

            ann = new Annotation();
            if (!ann.LoadByPrimaryKey(fromAnnotationId))
            {
                MessageBox.Show("From Annotation Not found");
                return;
            }

            Dictionary<int, int> axisKeys = new Dictionary<int, int>();
            Dictionary<int, int> seriesKeys = new Dictionary<int,int>();

            using (esTransactionScope scope = new esTransactionScope())
            {
                foreach (AnnotationPlot annPlot in ann.AnnotationPlotCollectionByAnnotationId)
                {
                    AnnotationPlot annPlotClone = new AnnotationPlot();
                    annPlotClone.AnnotationId = toAnnotationId;
                    annPlotClone.RegionId = annPlot.RegionId;
                    annPlotClone.Description = annPlot.Description;
                    annPlotClone.Title = annPlot.Title;
                    annPlotClone.Type = annPlot.Type;
                    annPlotClone.DimensionCount = annPlot.DimensionCount;
                    annPlotClone.Save();

                    foreach (AnnotationPlotAxis annPlotAxis in annPlot.AnnotationPlotAxisCollectionByPlotId)
                    {
                        AnnotationPlotAxis annPlotAxisClone =  new AnnotationPlotAxis();
                        annPlotAxisClone.PlotId = annPlotClone.Id;
                        annPlotAxisClone.Label = annPlotAxis.Label;
                        annPlotAxisClone.MinValue = annPlotAxis.MinValue;
                        annPlotAxisClone.MaxValue = annPlotAxis.MaxValue;
                        annPlotAxisClone.Scale = annPlotAxis.Scale;
                        annPlotAxisClone.Type = annPlotAxis.Type;
                        annPlotAxisClone.Dimension = annPlotAxis.Dimension;
                        annPlotAxisClone.Save();
                        axisKeys.Add(annPlotAxis.Id.Value, annPlotAxisClone.Id.Value);
                    }

                    foreach (AnnotationPlotSeries annPlotSeries in annPlot.AnnotationPlotSeriesCollectionByPlotId)
                    {
                        AnnotationPlotSeries annPlotSeriesClone = new AnnotationPlotSeries();
                        annPlotSeriesClone.PlotId = annPlotClone.Id;
                        annPlotSeriesClone.Description = annPlotSeries.Description;
                        annPlotSeriesClone.ColorRGB = annPlotSeries.ColorRGB;
                        annPlotSeriesClone.Save();
                        seriesKeys.Add(annPlotSeries.Id.Value, annPlotSeriesClone.Id.Value);
                    }
                }

                foreach (AnnotationPlot annPlot in ann.AnnotationPlotCollectionByAnnotationId)
                {
                    foreach (AnnotationPlotAxis annPlotAxis in annPlot.AnnotationPlotAxisCollectionByPlotId)
                    {
                        foreach (AnnotationPlotAxisData annPlotAxisData in annPlotAxis.AnnotationPlotAxisDataCollectionByAxisId)
                        {
                            AnnotationPlotAxisData annPlotAxisDataClone = new AnnotationPlotAxisData();
                            annPlotAxisDataClone.AxisId = axisKeys[annPlotAxisData.AxisId.Value];
                            annPlotAxisDataClone.SeriesId  = seriesKeys[annPlotAxisData.SeriesId.Value];
                            annPlotAxisDataClone.DataBin = annPlotAxisData.DataBin;
                            annPlotAxisDataClone.Save();
                        }
                    }

                    foreach (AnnotationPlotSeries annPlotSeries in annPlot.AnnotationPlotSeriesCollectionByPlotId)
                    {
                        foreach (AnnotationPlotAxisData annPlotAxisData in annPlotSeries.AnnotationPlotAxisDataCollectionBySeriesId)
                        {
                            AnnotationPlotAxisData annPlotAxisDataClone = new AnnotationPlotAxisData();
                            annPlotAxisDataClone.Query.Where(
                                annPlotAxisDataClone.Query.AxisId == axisKeys[annPlotAxisData.AxisId.Value] &&
                                annPlotAxisDataClone.Query.SeriesId == seriesKeys[annPlotAxisData.SeriesId.Value]);

                            if (!annPlotAxisDataClone.Query.Load())
                            {
                                annPlotAxisDataClone = new AnnotationPlotAxisData();
                                annPlotAxisDataClone.AxisId = axisKeys[annPlotAxisData.AxisId.Value];
                                annPlotAxisDataClone.SeriesId = seriesKeys[annPlotAxisData.SeriesId.Value];
                                annPlotAxisDataClone.DataBin = annPlotAxisData.DataBin;
                                annPlotAxisDataClone.Save();
                            }
                        }
                    }
                }
                scope.Complete();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            coll.Save();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            bindingSource1.CancelEdit();
        }
    }
}
