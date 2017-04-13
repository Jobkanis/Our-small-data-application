using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            string databaseplace = "C:\\Users\\Jonah Kalkman\\Desktop\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ databaseplace+ ";Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand("select Begintijd from fietsdiefstal", con);
            con.Open();
            dr = cmd.ExecuteReader();
            Console.WriteLine("pen15 -> " + dr.HasRows);
            int counter = 0;
            
            while (dr.Read())
            {
                //get rows
                counter++;
            }
            Console.WriteLine(counter);
            con.Close();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
