using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace XMLDemo
{
    public partial class Form1 : Form
    {
        XmlSerializer xmlSerializer;
        List<Employee> employees;
        public Form1()
        {
            InitializeComponent();
            employees = new List<Employee>();
            xmlSerializer = new XmlSerializer(typeof(List<Employee>));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("C:/Users/acer/source/repos/XMLDemo/employee.xml", FileMode.OpenOrCreate, FileAccess.Write);
        
          Employee employee = new Employee();
            
            employee.Name = textBox1.Text;
            employee.Address = textBox2.Text;
            employee.Designation = textBox3.Text;
            employee.Age = int.Parse(textBox4.Text);
            employee.Salary = double.Parse(textBox5.Text);

            employees.Add(employee);

            dataGridView1.DataSource = employees;


            xmlSerializer.Serialize(fileStream, employees);
            fileStream.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("C:/Users/acer/source/repos/XMLDemo/employee.xml", FileMode.Open, FileAccess.Read);

            Button button = (Button)sender;

            var asd = xmlSerializer.Deserialize(fileStream);

            employees = (List<Employee>)asd;

           

            dataGridView1.DataSource = employees;
            fileStream.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Exporting to CSV.
            string folderPath = "C:/Users/acer/source/repos/XMLDemo/asd.csv";
            File.WriteAllText(folderPath + "DataGridViewExport.csv", csv);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            FileStream fileStream = new FileStream("C:/Users/acer/source/repos/XMLDemo/employee.xml", FileMode.Open, FileAccess.Read);
            employees = (List<Employee>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();

            form3.LoadData(employees);
            form3.Show();
        }
    }
}
