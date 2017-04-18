using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Locations : Form
    {
        public List<int> SelectedDisticts = new List<int>();

        public Locations()
        {
            InitializeComponent();
        }

        public bool ChangeDistrict(int district) // True = added, False = Removed
        {
            if (SelectedDisticts.Find(x => x == district) == 0)
            {
                SelectedDisticts.Add(district);
                return false;
            }
            else
            {
                SelectedDisticts.Remove(district);
                return true;
            }

        }

        private void button_District1_Click_1(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(1);
            if (Selected == true)
            {
                button_District1.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District1.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void button_District2_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(2);
            if (Selected == true)
            {
                button_District2.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District2.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void button_District3_Click(object sender, EventArgs e)
        {
            bool Selected = ChangeDistrict(3);
            if (Selected == true)
            {
                button_District3.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District3.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

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
            bool Selected = ChangeDistrict(12);
            if (Selected == true)
            {
                button_District12.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                button_District12.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void Locations_Load(object sender, EventArgs e)
        {

        }


    }
}
