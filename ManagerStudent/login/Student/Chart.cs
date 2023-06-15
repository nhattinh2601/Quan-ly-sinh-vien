using System;
using System.Drawing;
using System.Windows.Forms;

namespace login
{
    public partial class Chart : Form
    {
        public Chart()
        {
            STUDENT student = new STUDENT();
            InitializeComponent();
            try
            {
                double total = Convert.ToDouble(student.totalStudent());
                double totalMale = Convert.ToDouble(student.totalMaleStudent());
                double totalFemale = Convert.ToDouble(student.totalFemaleStudent());

                double maleStudentsPercentage = (totalMale * (100 / total));
                double femaleStudentsPercentage = (totalFemale * (100 / total));

                if (totalFemale == 0)
                {
                    chart2.Series["s1"].Points.AddXY("Male", maleStudentsPercentage);

                }
                else
                //chart2.Series["s1"].Points.AddXY("Total", total);
                {
                    chart2.Series["s1"].Points.AddXY("Male", maleStudentsPercentage);
                    chart2.Series["s1"].Points.AddXY("Female", femaleStudentsPercentage);
                }

                if (totalFemale == 0)
                {
                    chart1.Series["Series1"].Points.AddXY("Male", maleStudentsPercentage);
                }
                else
                //chart2.Series["s1"].Points.AddXY("Total", total);
                {
                    //chart1.Series["Series1"].Points.AddXY("Total", total);
                    chart1.Series["Series1"].Points.AddXY("Male", maleStudentsPercentage);
                    chart1.Series["Series1"].Points.AddXY("Female", femaleStudentsPercentage);
                }

                


            }
            //
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        /*
private void DrawPieChart(int value1, int value2, int value3, int value4, int value5)
{
   //reset your chart series and legends
   chart1.Series.Clear();
   chart1.Legends.Clear();

   //Add a new Legend(if needed) and do some formating
   chart1.Legends.Add("MyLegend");
   chart1.Legends[0].LegendStyle = LegendStyle.Table;
   chart1.Legends[0].Docking = Docking.Bottom;
   chart1.Legends[0].Alignment = StringAlignment.Center;
   chart1.Legends[0].Title = "MyTitle";
   chart1.Legends[0].BorderColor = Color.Black;

   //Add a new chart-series
   string seriesname = "MySeriesName";
   chart1.Series.Add(seriesname);
   //set the chart-type to "Pie"
   chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

   //Add some datapoints so the series. in this case you can pass the values to this method
   chart1.Series[seriesname].Points.AddXY("MyPointName", value1);
   chart1.Series[seriesname].Points.AddXY("MyPointName1", value2);
   chart1.Series[seriesname].Points.AddXY("MyPointName2", value3);
   chart1.Series[seriesname].Points.AddXY("MyPointName3", value4);
   chart1.Series[seriesname].Points.AddXY("MyPointName4", value5);
}
*/
    }
}
