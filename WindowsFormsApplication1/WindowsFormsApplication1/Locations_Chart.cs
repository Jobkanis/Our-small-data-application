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
    public partial class Locations_Chart : Form
    {
        // Values for modefying the chart
        public Boolean ShowYOnFietsdiefstal = true;
        public Boolean ShowYOnStraatroof = true;
        public Boolean ShowYOnTotal = true;

        public Boolean ShowTotal = false;
        public Boolean ShowFietsdiefstal = true;
        public Boolean ShowStraatroof = true;

        // Lists for getting the name out of the district numbers
        List<int> FullDistrictList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 9, 10, 11, 12 });
        List<string> FullDistrictNames = new List<string>(new string[] { "Waterweg", "Schiedam", "Rotterdam-West", "Rotterdam Centrum", "De Noordhoek", "District Oost", "Feyenoord", "Rotterdam-Zuid", "De eilanden", "Rivierpolitie" });

        //List of selected districts
        public List<int> SelectedDisticts = new List<int>();

        public Locations_Chart() //constructor
        {
            InitializeComponent();
        }

        public string CreateQuerie(string tabel, int district) // Creates query per district per datasource
        {
            string WhereString = " WHERE plaats = 'Rotterdam' AND district = 'district ";
            WhereString += district.ToString() + "' ";

            //Adding all districts together
            //foreach (int dist in SelectedDisticts)
            //{
            //    Console.WriteLine(dist);
            //    if (WhereString == "")
            //    {
            //        WhereString += " WHERE ";
            //    }
            //    else
            //    {
            //        WhereString += " OR ";
            //    }

            //    WhereString += "District = 'district " + dist.ToString() + "' ";
            //}


            string returnstring = "Select count(*) from " + tabel + WhereString + " GROUP BY District " + ";";

            return returnstring;

        }
        public string CreateTotalQuery(int district) //Creates query for the total of both datasources per district: TAKE NOTICE: RIGHT JOIN IS USED (+1.0)
        {
            string returnstring = "";
            returnstring = "select (COALESCE(fdamount, 0) + COALESCE(sramount, 0)) as total from (select district AS fddistrict, count(*) AS fdamount from fietsdiefstal WHERE Plaats = 'Rotterdam' GROUP BY district) fd right join (select district AS srdistrict, count(*) AS sramount from straatroof WHERE Plaats = 'Rotterdam' GROUP by district) sr on srdistrict = fddistrict WHERE srdistrict = 'district "
                + district.ToString() +
                "'  or fddistrict = 'district "
                + district.ToString() + "';";

            return returnstring;
        }
        public bool ChangeDistrict(int district) // Any button can give its corresponding district to this function. It returns false if it is removed from the list (when in the list) and true when it is added to the list (when not in the list)
        {
            if (SelectedDisticts.Find(x => x == district) == 0)
            {
                SelectedDisticts.Add(district);
                loadgraph();
                return false;
            }
            else
            {
                SelectedDisticts.Remove(district);
                loadgraph();
                return true;
            }

        }

        public void loadgraph() // function creates the graph
        {
            // CREATING CONNECTION

            // Jonah :  string databaseplace = "C:\\Users\\Jonah Kalkman\\Desktop\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Job : string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Oguzhan :string databaseplace = "C:\\Users\\Oguzhan\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Robin : string databaseplace = "C:\\Users\\robin\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";
            // Dion : string databaseplace = "C:\\Users\\Dionykn\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";

            string databaseplace = "C:\\Users\\jobka\\Documents\\GitHub\\Project3\\WindowsFormsApplication1\\WindowsFormsApplication1\\Official_Database.mdf";

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databaseplace + ";Integrated Security=True"); //Connection with database

            // fietsdiefstal
            SqlCommand FDcommand;
            SqlDataReader FDreader;

            // straatroof
            SqlCommand SRcommand;
            SqlDataReader SRreader;

            // total
            SqlCommand Totalcommand;
            SqlDataReader Totalreader;

            // Draw components
            int districtfietsdiefstal;
            int districtstraatroof;
            int districttotal;

            // opened (fietsdiefstal)     
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();


            foreach (int district in SelectedDisticts) //create a plot for every distict in the districtlist
            {
                districtfietsdiefstal = 0; 
                districtstraatroof = 0;
                districttotal = 0;
                string sqlquery;
                // fietsdiefstal
                if (ShowFietsdiefstal == true) //if we want to show it
                    {
                    con.Open(); //open database connection

                    sqlquery = CreateQuerie("fietsdiefstal", district); //select count(*) from fietsdiefstal where district = 'district 1'
                    FDcommand = new SqlCommand(sqlquery, con); //(output = 1 row of district count size)
                    FDreader = FDcommand.ExecuteReader(); // Make it readable
                    while (FDreader.Read()) // Read query
                    {
                        int output = FDreader.GetInt32(0);
                        districtfietsdiefstal = output;
                    }

                    chart1.Series["Fietsdiefstal"].Points.AddXY(GetName(district), districtfietsdiefstal); // Add point to graph
                    chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].AxisLabel = GetName(district); //add axislabel (underneath)
                    if (ShowYOnFietsdiefstal == true)
                    {
                        chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].Label = districtfietsdiefstal.ToString(); //add value to point
                    }

                    //ADD VALUE TO POINT: chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].Label = xvalue.ToString() + ":00"; // comment on the graph
                    con.Close(); //close database connection
                }
                // straatroof
                if (ShowStraatroof == true) // if we want to show it
                {
                    con.Open(); //open database connection

                    sqlquery = CreateQuerie("straatroof", district); //select count(*) from fietsdiefstal where district = 'district 1';
                    SRcommand = new SqlCommand(sqlquery, con); //(output = 1 row of district count size)
                    SRreader = SRcommand.ExecuteReader(); // Make it readable
                    while (SRreader.Read()) // Read query
                    {
                        string output = SRreader.GetValue(0).ToString();
                        districtstraatroof = GetInt(output); // Get int out of database: 0 -> gets string out of database
                    }
                    chart1.Series["Straatroof"].Points.AddXY(GetName(district), districtstraatroof); // Add point to graph
                    chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].AxisLabel = GetName(district); // Time shown underneath graph
                    if (ShowYOnStraatroof == true)
                    {
                        chart1.Series["Straatroof"].Points[chart1.Series["Straatroof"].Points.Count() - 1].Label = districtstraatroof.ToString();
                    }
                    //ADD VALUE TO POINT: chart1.Series["Fietsdiefstal"].Points[chart1.Series["Fietsdiefstal"].Points.Count() - 1].Label = xvalue.ToString() + ":00"; // comment on the graph
                    con.Close(); // close connection with database
                }
                // total

                if (ShowTotal == true) // if we want to show it
                {
                    con.Open(); //open database connection

                    sqlquery = CreateTotalQuery(district); //select count(*) from fietsdiefstal where district = 'district 1'
                    Totalcommand = new SqlCommand(sqlquery, con); //(output = 1 row of district count size)
                    Totalreader = Totalcommand.ExecuteReader(); // Make it readable
                    while (Totalreader.Read()) // Read query
                    {
                        int output = Totalreader.GetInt32(0); // get value out
// TO PROOF WE USED OUR JOIN FUNCTION CORRECTLY
Console.WriteLine("total by query: " + output.ToString());
Console.WriteLine("Total by calculator: " + (districtfietsdiefstal + districtstraatroof).ToString());

                        districttotal = output; //output; // Get int out of database: 0 if not convertable
                    }
                    con.Close(); //close connection

                    chart1.Series["Total"].Points.AddXY(GetName(district), districttotal); //add point to graph
                    chart1.Series["Total"].Points[chart1.Series["Total"].Points.Count() - 1].AxisLabel = GetName(district); // add axislabel 
                    if (ShowYOnTotal == true)
                    {
                        chart1.Series["Total"].Points[chart1.Series["Total"].Points.Count() - 1].Label = districttotal.ToString(); // add value to it
                    }
                }
            }
            chart1.ChartAreas[0].AxisX.Maximum = SelectedDisticts.Count() + 1; //make axis as big as the number of points + 1
        }

        public int GetInt(string value) // Gets string, returns it as integer, returns 0 if not converable 
        {
            int returnvalue;
            Boolean isNumeric = int.TryParse(value, out returnvalue);
            return returnvalue;
        }

        public string GetName(int district) // gets name out of district number, returns ""  when no name avable, 
        {
            string returnname = "";
            int index = FullDistrictList.IndexOf(district);
            returnname = FullDistrictNames[index]; // dangerous for errors: be allert
            return returnname;
        }
        //#######################################################################

        private void button_District3_Click(object sender, EventArgs e) // one of the district buttons
        {
            bool Selected = ChangeDistrict(3); //adds or remove 3 by function: gets false if removed, true if added
            if (Selected == true) // gives proper colour
            {
                button_District3.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District3.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }
 // etc: buttons are the same as above
        private void button_District5_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(5);
            if (Selected == true)
            {
                button_District5.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District5.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void button_District6_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(6);
            if (Selected == true)
            {
                button_District6.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District6.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void button_District9_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(9);
            if (Selected == true)
            {
                button_District9.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District9.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void button_District10_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(10);
            if (Selected == true)
            {
                button_District10.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District10.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void button_District12_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(4);
            if (Selected == true)
            {
                button_District12.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District12.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }
        private void chart1_Click(object sender, EventArgs e)
        {


        }

        private void Locations_Load(object sender, EventArgs e)
        {

        }
// showing the graph stuff
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // show straatroof on chart
        {
            if (checkBox1.Checked) // show straatroof
            {
                checkBox4.Enabled = true;
                ShowStraatroof = true;
                loadgraph();
            }
            else // if straatroof is not checked set showstraatroof to false
            {
                ShowStraatroof = false;
                checkBox4.Enabled = false;
                loadgraph();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) // toggle y-as on straatroof
        {
            if (checkBox4.Checked)
            {
                ShowYOnStraatroof = true;
                loadgraph();
            }
            else
            {
                ShowYOnStraatroof = false;
                loadgraph();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // show straatroof on chart
        {
            if (checkBox2.Checked) // show straatroof
            {
                checkBox3.Enabled = true;
                ShowFietsdiefstal = true;
                loadgraph();
            }
            else // if straatroof is not checked set showstraatroof to false
            {
                ShowFietsdiefstal = false;
                checkBox3.Enabled = false;
                loadgraph();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) // toggle y-as on straatroof
        {
            if (checkBox3.Checked)
            {
                ShowYOnFietsdiefstal = true;
                loadgraph();
            }
            else
            {
                ShowYOnFietsdiefstal = false;
                loadgraph();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) // show total on chart
        {
            if (checkBox5.Checked) // show straatroof
            {
                checkBox6.Enabled = true;
                ShowTotal = true;
                loadgraph();
            }
            else // if straatroof is not checked set showstraatroof to false
            {
                ShowTotal = false;
                checkBox6.Enabled = false;
                loadgraph();
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e) // toggle y-as on total
        {
            if (checkBox6.Checked)
            {
                ShowYOnTotal = true;
                loadgraph();
            }
            else
            {
                ShowYOnTotal = false;
                loadgraph();
            }
        }
    }
}
