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

            employees.Add(employee);


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
    }
}
