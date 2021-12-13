using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace XMLDemo
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        public void LoadData(List<Employee> employee)
        {
            if (employee != null)
            {
                BarChart.DataSource = employee;
                BarChart.Series["Salary"].ChartType = SeriesChartType.Pie;
                //set the member of the chart data source used to data bind to the X-values of the series  
                BarChart.Series["Salary"].XValueMember = "Name";
                //set the member columns of the chart data source used to data bind to the X-values of the series  
                BarChart.Series["Salary"].YValueMembers = "Salary";
                BarChart.Titles.Add("Salary Chart");
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
             
        }


    }
}
