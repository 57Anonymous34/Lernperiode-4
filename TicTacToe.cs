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

    public partial class TicTacToe : Form
    {

        public int spieler = 2;
        public int zug = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;

        bool IsDraw()
        {
            if ((zug == 9) && (IsWinner() == false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        bool IsWinner()
        {
            //horizontal
            if ((A00.Text == A01.Text) && (A01.Text == A02.Text) && A00.Text != "")
                return true;
            if ((A10.Text == A11.Text) && (A11.Text == A12.Text) && A10.Text != "")
                return true;
            if ((A20.Text == A21.Text) && (A21.Text == A22.Text) && A20.Text != "")
                return true;

            //vertikal
            if ((A00.Text == A01.Text) && (A01.Text == A02.Text) && A00.Text != "")
                return true;

            if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && A01.Text != "")
                return true;

            if ((A02.Text == A12.Text) && (A12.Text == A22.Text) && A02.Text != "")
                return true;

            // diagonal
            if ((A00.Text == A11.Text) && (A11.Text == A22.Text) && A00.Text != "")
                return true;
            if ((A02.Text == A11.Text) && (A11.Text == A20.Text) && A02.Text != "")
                return true;
            else
                return false;


        }

        SpielAuswahl parent;
        public TicTacToe(SpielAuswahl parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            lbl_x.Text = "X: " + s1;
            lbl_O.Text = "O: " + s1;
            lbl_draw.Text = "Draw: " + s1;
        }

        private void buttonsClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            if (spieler % 2 == 0)
            {
                button.Text = "x";
                button.ForeColor = Color.Red;
                button.Font = new Font("Arial", 25, FontStyle.Bold);
                BackColor = Color.LightCoral;


                spieler++;
                zug++;
            }
            else
            {
                button.Text = "o";
                button.ForeColor = Color.Blue;
                button.Font = new Font("Arial", 25, FontStyle.Bold);
                BackColor = Color.LightBlue;

                spieler++;
                zug++;
            }

            if (IsDraw() == true)
            {
                MessageBox.Show("Unentschieden");
                sd++;
                NeuesSpiel();
                BackColor = Color.Gray;
            }

            if (IsWinner() == true)
            {
                if (button.Text == "x")
                {
                    MessageBox.Show("X hat gewonnen");



                    s1++;
                    NeuesSpiel();
                }
                else
                {
                    MessageBox.Show("O hat gewonnen");
                    s2++;
                    NeuesSpiel();
                }
            }
        }
        //Reset
        private void button11_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            NeuesSpiel();
        }

        //New Game
        private void button2_Click(object sender, EventArgs e)
        {
            NeuesSpiel();
        }

        public void NeuesSpiel()
        {
            spieler = 2;
            zug = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";

            lbl_x.Text = "X: " + s1;
            lbl_O.Text = "O: " + s2;
            lbl_draw.Text = "Draw: " + sd;
        }

        private void lbl_draw_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
