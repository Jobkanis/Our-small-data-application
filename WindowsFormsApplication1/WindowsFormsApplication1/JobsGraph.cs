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
            // TO DO:
            // -  RELOAD BUTTON
            // -  ENABLE/DISABLE SERIES -> toggle true/false box    |  |    <->    | X |
            // -  Enable/Disable YasValues on graph -> toggle true/false box |   |    <->    | X |
            // -  SET MULTIPLIERS       -> insert integer in box    |   1   |    <->   |   3   |    <->    |   X   |
            // -  SET TIME DOMAIN (1:00 - 24:00 wordt bijvorobeeld 13:00 - 15:00)   |.|-----------|.....| 
            // -  SHOW YVALUE ON GRAPH
            // Show lines in GUI
            Boolean ShowFietsdiefstal = true;
            Boolean ShowStraatroof = true;

            // Multipliers in GUI
            int MultiplierFietsdiefstal = 1;
            int MultiplierStraatroof = 1;

            // YValue on map
            Boolean ShowYOnFietsdiefstal = false;
            Boolean ShowYOnStraatroof = true;


            // CREATING CONNECTION

            // Jonah :  string databaseplace = "C:\\Users\\Jonah Kalkman\\Desktop\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Job : string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Oguzhan :string databaseplace = "C:\\Users\\Oguzhan\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";

            string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf"; //Database location on computer

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databaseplace + ";Integrated Security=True"); //Connection with database
            
            // fietsdiefstal
            SqlCommand FDcommand; 
            SqlDataReader FDreader;

            // straatroof
            SqlCommand SRcommand; 
            SqlDataReader SRreader;
            
            InitializeComponent(); // Draw components

            // opened (fietsdiefstal)     

            if (ShowFietsdiefstal == true)
            {

                con.Open(); //open database connection
                FDcommand = new SqlCommand("select uur, count(waarde) from fietsdiefstal GROUP BY uur ORDER BY uur ASC;", con); // [Xvalue, Yvalue] = output query
                FDreader = FDcommand.ExecuteReader(); // Make it readable

                while (FDreader.Read()) // Read query
                {
                    string output = FDreader.GetValue(0).ToString();
                    var xvalue = GetInt(output); // Get int out of database: 0 if not convertable

                    output = FDreader.GetValue(1).ToString();
                    var yvalue = GetInt(output);

                    chart1.Series["Fietsdiefstal"].Points.AddXY(xvalue, yvalue * MultiplierFietsdiefstal); // Add point to graph
                    chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].AxisLabel = xvalue.ToString() + ":00"; // Time shown underneath graph
                    if (ShowYOnFietsdiefstal == true)
                    {
                        chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].Label = yvalue.ToString();
                    }
                    //ADD VALUE TO POINT: chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].Label = xvalue.ToString() + ":00"; // comment on the graph
                }
                con.Close();
            }
            // closed           

            // Straatroof queries
            // opened
            if (ShowStraatroof == true)
            {
                con.Open();
                SRcommand = new SqlCommand("select uur, count(waarde) from straatroof GROUP BY uur ORDER BY uur ASC;", con);
                SRreader = SRcommand.ExecuteReader();

                while (SRreader.Read())
                {
                    string output = SRreader.GetValue(0).ToString();
                    var xvalue = GetInt(output);

                    output = SRreader.GetValue(1).ToString();
                    var yvalue = GetInt(output);

                    chart1.Series["Straatroof"].Points.AddXY(xvalue, yvalue * MultiplierStraatroof);
                    chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].AxisLabel = xvalue.ToString() + ":00";
                    if (ShowYOnFietsdiefstal == true)
                    {
                        chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].Label = yvalue.ToString();
                    }
                    //ADD VALUE TO POINT:  chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].Label = xvalue.ToString() + ":00";
                }

                con.Close();
            }
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
