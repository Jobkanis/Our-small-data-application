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
    public partial class Hours_Chart : Form
    {
        //All values that needs to load when form started (global values)
        Boolean ShowYOnFietsdiefstal = false;
        Boolean ShowYOnStraatroof = false;
        Boolean ShowFietsdiefstal = true;
        Boolean ShowStraatroof = true;
        int minimumtime = 1;
        int maximumtime = 24;

        public Hours_Chart() //All stuff that needs to load when started (global values)
        {
            InitializeComponent();
            label1.Text = "";
            checkBox4.Enabled = false;
            checkBox3.Enabled = false;
            
            // closed            
        }        
        void loadgraph() // Function for loading and reloading graph
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

            // CREATING CONNECTION

            // Jonah :  string databaseplace = "C:\\Users\\Jonah Kalkman\\Desktop\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Job : string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Oguzhan :string databaseplace = "C:\\Users\\Oguzhan\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Dion: string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            string databaseplace = "C:\\Users\\Oguzhan\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";

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
                FDcommand = new SqlCommand("select uur, count(waarde) from fietsdiefstal WHERE uur >= " + minimumtime + " and uur <= " + maximumtime + "AND plaats = 'Rotterdam' GROUP BY uur ORDER BY uur ASC;", con); // [Xvalue, Yvalue] = output query
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
                SRcommand = new SqlCommand("select uur, count(waarde) from straatroof WHERE uur >= " + minimumtime + " and uur <= " + maximumtime + "AND plaats = 'Rotterdam' GROUP BY uur ORDER BY uur ASC;", con);
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
                chart1.ChartAreas[0].AxisX.Maximum = maximumtime + 1;
                chart1.ChartAreas[0].AxisX.Minimum = minimumtime - 1;
                label1.Text = "";
            }

        } 
        private int GetInt(string value) // Converts string to int
        {
            int returnvalue;
            Boolean isNumeric = int.TryParse(value, out returnvalue);
            return returnvalue;
        }
        private void chart1_Click(object sender, EventArgs e)//When there is clicked on chart1
        {

        } 
        private void textBox2_TextChanged(object sender, EventArgs e) //Minimum domain value input (live update)
        {
            TextBox minTextBox = (TextBox)sender;
            string minValue = minTextBox.Text;
            GetInt(minValue);
            minimumtime = GetInt(minValue);
            loadgraph();
        }        
        private void textBox1_TextChanged(object sender, EventArgs e) //Maximum domain value input (live update)
        {
            TextBox maxTextBox = (TextBox)sender;

            string maxValue = maxTextBox.Text; 
            GetInt(maxValue); //converts the input to a int
            maximumtime = GetInt(maxValue); //sets the maximumtime to maxValue
            loadgraph(); //refresh the graph

        }       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//Straatroof checkbox
        {
            if (checkBox1.Checked) // check if straatroof is selected
            {
                checkBox4.Enabled = true;
                if (checkBox2.Checked) // Check if fietsendiefstal is also selected
                {
                    ShowFietsdiefstal = true;
                    ShowStraatroof = true;
                    loadgraph();
                    
                    label1.Text = "";//set warning string to none
                }
                else // If fietsdiefstal is not checked, only view straatroof
                {
                    ShowFietsdiefstal = false;
                    ShowStraatroof = true;
                    loadgraph();
                    
                    label1.Text = "";//set warning string to none
                }

            }
            else // If straatroof is not checked set showstraatroof to false
            {
                ShowStraatroof = false;
                checkBox4.Enabled = false;
                loadgraph();
            }
        }         
        private void checkBox2_CheckedChanged(object sender, EventArgs e)//Fietsdiefstal checkbox
        {
            if (checkBox2.Checked) // Check if fietsdiefstal is selected
            {
                checkBox3.Enabled = true;
                if (checkBox1.Checked) // Check if straatroof is also selected
                {
                    ShowFietsdiefstal = true;
                    ShowStraatroof = true;
                    loadgraph();
                    
                    label1.Text = ""; //set warning string to none
                }
                else // If straatroof is not checked only view fietsdiefstal
                {
                    ShowFietsdiefstal = true;
                    ShowStraatroof = false;
                    loadgraph();
                    
                    label1.Text = "";//set warning string to none
                }
            }

            else // If fietsdiefstal is not checked set showfietsdiefstal to false
            {
                ShowFietsdiefstal = false;
                checkBox3.Enabled = false;
                loadgraph();
            }
        } 
        private void JobsGraph_Load(object sender, EventArgs e) //Function for loading
        {

        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e) //Display y-axe on Straatroof
        {
            if (checkBox1.Checked) //Checks if Straatroof is selected
            {
                if (checkBox4.Checked) //Checks if Y-axe Values is selected
                {
                    ShowYOnStraatroof = true;
                    loadgraph();
                }
                else //Makes sure that ShowYOnStraatroof is false
                {
                    ShowYOnStraatroof = false;
                    loadgraph();
                }
            }

        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) //show y-axe on fietsdiefstal
        {
            if (checkBox2.Checked)//Checks if Fietsdiefstal is selected
            {
                if (checkBox3.Checked) //Checks if Y-axe Values is selected
                {
                    ShowYOnFietsdiefstal = true;
                    loadgraph();
                }
                else //Makes sure that ShowYOnFietsdiefstal is false
                {
                    ShowYOnFietsdiefstal = false;
                    loadgraph();
                }
            }

        }
        private void label4_Click(object sender, EventArgs e) //When clicked on label (not implemented)
        {

        }
        private void label3_Click(object sender, EventArgs e) //When clicked on label (not implemented)
        {

        }
        private void button1_Click(object sender, EventArgs e) //Reset Domain button
        {
            
            textBox2.Text = String.Empty; //Clears text in domain textbox2
            textBox1.Text = String.Empty; //Clears text in domain textbox1
            minimumtime = 1; // Reset the minimumtime domain value
            maximumtime = 24; // Reset the maximumtime domain value
            loadgraph(); //Reloads the graph
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI menu = new GUI();
            this.Hide();
            menu.ShowDialog();
        }
    }
}
