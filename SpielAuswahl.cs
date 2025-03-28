using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpielParadies
{
    public partial class SpielAuswahl : Form
    {
        Form1 parent;
        public SpielAuswahl(Form1 parent)
        {
            InitializeComponent();
            label1.Text = "Chose your Game";
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new TicTacToe(this).Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2(this).Show();
            this.Hide();
        }

        private void SpielAuswahl_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
    }
}
