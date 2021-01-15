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
    public partial class Player : Form
    {
        public string player1 = null;
        public string player2 = null;

        public Player()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            player1 = player1TextBox.Text;
            player2 = player2TextBox.Text;

            if (player1 != "" && player2 != "")
            {
                if (player1 != player2)
                {
                    Tabel tabel = new Tabel(player1, player2);
                    this.Hide();
                    tabel.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nu pot exista doi jucatori identici!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Introduceti numele jucatorilor!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
