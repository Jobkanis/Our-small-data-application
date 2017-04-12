using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TESTGITHUB
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;" +
                                    "Password=DionKlein98;Database=project3;");
            conn.Open();


            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand("select straat,plaats from fietsdiefstal", conn);

            // Execute the query and obtain a result set
            NpgsqlDataReader dr = cmd.ExecuteReader();
            List<string> straat = new List<string>();
            List<string> plaats = new List<string>();
            // Output rows
            while (dr.Read())
            {
                //Console.Write("{0}\t{1} \n", dr[0], dr[1]);

                straat.Add(dr.GetValue(0).ToString());
                plaats.Add(dr.GetValue(1).ToString());
            }



            Console.WriteLine(plaats.Count());
            Console.WriteLine(straat.Count());
            Console.WriteLine(straat[3] + " te " + plaats[3]);



            conn.Close();

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
