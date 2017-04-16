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
    public partial class JobsGraph : Form
    {
        public JobsGraph()
        {
            // CREATING CONNECTION

            // Jonah :  string databaseplace = "C:\\Users\\Jonah Kalkman\\Desktop\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Job :    string databaseplace = "C:\Users\jobka\Documents\GitHub\Project3\WindowsFormsApplication1\WindowsFormsApplication1\Official_Database.mdf";
            string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databaseplace + ";Integrated Security=True");
            
            // fietsdiefstal
            SqlCommand FDcommand; 
            SqlDataReader FDreader;

            // straatroof
            SqlCommand SRcommand; 
            SqlDataReader SRreader;
            
            InitializeComponent();

// opened (fietsdiefstal)     

            con.Open();
            FDcommand = new SqlCommand("select uur, count(waarde) from fietsdiefstal GROUP BY uur ORDER BY uur ASC;", con); // [Xvalue, Yvalue] = output query
            FDreader = FDcommand.ExecuteReader();

            while (FDreader.Read())
            {
                string output = FDreader.GetValue(0).ToString();
                var xvalue = GetInt(output);

                output = FDreader.GetValue(1).ToString();
                var yvalue = GetInt(output);

                chart1.Series["Fietsdiefstal"].Points.AddXY(xvalue, yvalue);
            }
            con.Close();
// closed           

            // Straatroof queries
// opened
            con.Open();
            SRcommand = new SqlCommand("select uur, count(waarde) from straatroof GROUP BY uur ORDER BY uur ASC;", con);
            SRreader = SRcommand.ExecuteReader();

            while (SRreader.Read())
            {
                string output = SRreader.GetValue(0).ToString();
                var xvalue = GetInt(output);

                output = SRreader.GetValue(1).ToString();
                var yvalue = GetInt(output);

                chart1.Series["Straatroof"].Points.AddXY(xvalue, yvalue);
            }

            con.Close();
// closed            
        }

        private int GetInt(string value) // returns 0 if not returns int if it is
        {
            int returnvalue;
            Boolean isNumeric = int.TryParse(value, out returnvalue);
            return returnvalue;
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
