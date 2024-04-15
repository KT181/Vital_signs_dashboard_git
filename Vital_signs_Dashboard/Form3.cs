using ScottPlot.AxisLimitCalculators;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vital_signs_Dashboard
{
    public partial class Form3 : Form
    {
        public Form3(int count,int btcount)
        {
            InitializeComponent();
            int normal = count - btcount;
            PieSlice slice1 = new() { Value = btcount, FillColor = Colors.Orange, Label = "BT unusual: " + btcount.ToString() };
            PieSlice slice2 = new() { Value = normal, FillColor = Colors.Gold, Label = "BT normal: " + normal.ToString() };
            List<PieSlice> slices = new() { slice1, slice2};
            // setup the pie to display slice labels
            var pie = formsPlot1.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.ShowSliceLabels = true;
            pie.SliceLabelDistance = 1.3;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
    }
}
