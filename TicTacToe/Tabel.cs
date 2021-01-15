using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Tabel : Form
    {
        string turn = "0";
        int win0 = 0;
        int winX = 0;
        int number_buttons = 0;

        public Tabel(string player1, string player2)
        {
            InitializeComponent();

            name1Label.Text = player1;
            name2Label.Text = player2;

            resetButton();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            this.Hide();
            player.ShowDialog();
            this.Close();
        }

        private void playagainButton_Click(object sender, EventArgs e)
        {
           
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (turn == "X")
                turn = "0";
            else if (turn == "0")
                turn = "X";

            button.Text = turn;
            number_buttons++;
            button.Enabled = false;

            ForWinner();
        }

        private void ForWinner()
        {
            bool win = false;
            string winner = "";

            // ORIZONTAL
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A1.Text != ""))
            {
                win = true;
                winner = A1.Text;
            }
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Text != ""))
            {
                win = true;
                winner = B1.Text;
            }
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C1.Text != ""))
            {
                win = true;
                winner = C1.Text;
            }

            // VERTICAL
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (A1.Text != ""))
            {
                win = true;
                winner = A1.Text;
            }
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (A2.Text != ""))
            {
                win = true;
                winner = A2.Text;
            }
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (A3.Text != ""))
            {
                win = true;
                winner = A3.Text;
            }

            // DIAGONAL
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (A1.Text == C3.Text) && (A1.Text != ""))
            {
                win = true;
                winner = A1.Text;
            }
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (A3.Text == C1.Text) && (A3.Text != ""))
            {
                win = true;
                winner = A3.Text;
            }

            if (win)
            {
                if (winner == "X")
                {
                    winX++;
                    MessageBox.Show(name1Label.Text + " win the round", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    score1Label.Text = Convert.ToString(Int32.Parse(score1Label.Text) + 1);
                }
                else if (winner == "0")
                {
                    win0++;
                    MessageBox.Show(name2Label.Text + " win the round", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    score2Label.Text = Convert.ToString(Int32.Parse(score2Label.Text) + 1);
                }

                resetButton();
            }

            if (number_buttons == 9)
            {
                resetButton();
                number_buttons = 0;
            }
        }

        private void resetButton()
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";

            B1.Text = "";
            B2.Text = "";
            B3.Text = "";

            C1.Text = "";
            C2.Text = "";
            C3.Text = "";

            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;

            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;

            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;

            turn = "0";
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            if (winX > win0)
            {
                MessageBox.Show(name1Label.Text + " win the battle!!!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(winX < win0)
            {
                MessageBox.Show(name2Label.Text + " win the battle!!!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(name1Label.Text + " and " + name2Label.Text + " are equal", "Draw!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Close();
        }
    }
}
