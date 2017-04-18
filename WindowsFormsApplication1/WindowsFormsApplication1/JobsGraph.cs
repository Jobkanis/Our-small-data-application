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
        Boolean ShowYOnFietsdiefstal = false;
        Boolean ShowYOnStraatroof = false;
        bool chartHasLoaded = false;
        Boolean ShowFietsdiefstal = true;
        Boolean ShowStraatroof = true;
        int ToggleYvalues = 0;

        int minimumtime = 1;
        int maximumtime = 24;

        public JobsGraph()
        {
            InitializeComponent();
            label1.Text = "";
            // closed            
        }
        public Boolean chartvalues()
        {
            return true;
        }
        public Boolean notchartvalues()
        {
            return false;
        }
        public void loadgraph()
        {
            // TO DO:
            // -  RELOAD BUTTON
            // -  ENABLE/DISABLE SERIES -> toggle true/false box    |  |    <->    | X |
            // -  Enable/Disable YasValues on graph -> toggle true/false box |   |    <->    | X |
            // -  SET MULTIPLIERS       -> insert integer in box    |   1   |    <->   |   3   |    <->    |   X   |
            // -  SET TIME DOMAIN (1:00 - 24:00 wordt bijvorobeeld 13:00 - 15:00)   |.|-----------|.....| 
            // -  SHOW YVALUE ON GRAPH
            // Show lines in GUI
            

            // Multipliers in GUI
            int MultiplierFietsdiefstal = 1;
            int MultiplierStraatroof = 1;

            // YValue on map



            // CREATING CONNECTION

            // Jonah :  string databaseplace = "C:\\Users\\Jonah Kalkman\\Desktop\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Job : string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Oguzhan :string databaseplace = "C:\\Users\\Oguzhan\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Robin : string databaseplace = "C:\\Users\\robin\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";

            string databaseplace = "C:\\Users\\robin\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf"; //Database location on computer

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databaseplace + ";Integrated Security=True"); //Connection with database

            // fietsdiefstal
            SqlCommand FDcommand;
            SqlDataReader FDreader;

            // straatroof
            SqlCommand SRcommand;
            SqlDataReader SRreader;

            // Draw components

            // opened (fietsdiefstal)     
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            if (ShowFietsdiefstal == true)
            {

                con.Open(); //open database connection
                FDcommand = new SqlCommand("select uur, count(waarde) from fietsdiefstal WHERE uur >= " + minimumtime + " and uur <= " + maximumtime + "GROUP BY uur ORDER BY uur ASC;", con); // [Xvalue, Yvalue] = output query
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
                SRcommand = new SqlCommand("select uur, count(waarde) from straatroof WHERE uur >= " + minimumtime + " and uur <= " + maximumtime + "GROUP BY uur ORDER BY uur ASC;", con);
                SRreader = SRcommand.ExecuteReader();

                while (SRreader.Read())
                {
                    string output = SRreader.GetValue(0).ToString();
                    var xvalue = GetInt(output);

                    output = SRreader.GetValue(1).ToString();
                    var yvalue = GetInt(output);

                    chart1.Series["Straatroof"].Points.AddXY(xvalue, yvalue * MultiplierStraatroof);
                    chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].AxisLabel = xvalue.ToString() + ":00";
                    if (ShowYOnStraatroof == true)
                    {
                        chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].Label = yvalue.ToString();
                    }
                    //ADD VALUE TO POINT:  chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].Label = xvalue.ToString() + ":00";
                }

                con.Close();

                label1.Text = "";
            }

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
        //clear chart
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            ShowYOnFietsdiefstal = false;
            ShowYOnStraatroof = false;
            ToggleYvalues = 0;
            chartHasLoaded = false;
        }
        //y-as values
        private void button3_Click(object sender, EventArgs e)
        {
            if (ToggleYvalues == 0)
            {
                ToggleYvalues += 1;
                if (chartHasLoaded == true)
                {
                    ShowYOnFietsdiefstal = true;
                    ShowYOnStraatroof = true;
                    loadgraph();
                }
                else
                {
                    label1.Text = "First click load graph!";
                }
            }
            else
            {
                ToggleYvalues -= 1;
                if (chartHasLoaded == true)
                {
                    ShowYOnFietsdiefstal = false;
                    ShowYOnStraatroof = false;
                    loadgraph();
                }
                else
                {
                    label1.Text = "First click load graph!";
                }
            }
        }

        //show straatroof only
        private void button4_Click(object sender, EventArgs e)
        {
            ShowFietsdiefstal = false;
            ShowStraatroof = true;
            loadgraph();
            chartHasLoaded = true;
            label1.Text = "";
        }

        //show fietsdiefstal only
        private void button5_Click(object sender, EventArgs e)
        {
            ShowFietsdiefstal = true;
            ShowStraatroof = false;
            loadgraph();
            chartHasLoaded = true;
            label1.Text = "";
        }

        //show both datasets
        private void button6_Click(object sender, EventArgs e)
        {
            ShowFietsdiefstal = true;
            ShowStraatroof = true;
            loadgraph();
            chartHasLoaded = true;
            label1.Text = "";
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
