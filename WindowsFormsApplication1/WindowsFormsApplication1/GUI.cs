﻿using System;
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
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hours_Chart hours = new Hours_Chart();
            this.Hide();
            hours.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Locations_Chart locations = new Locations_Chart();
            this.Hide();
            locations.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Months_Chart month = new Months_Chart();
            this.Hide();
            month.ShowDialog();
        }
    }
}
