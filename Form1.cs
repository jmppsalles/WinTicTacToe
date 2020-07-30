using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTicTacToe
{
    public partial class Form1 : Form
    {

        bool turn = true;  // true -> X turn || false -> O turn
        int turncount = 0; //contagem das rodadas


        public Form1()
        {
            InitializeComponent();
        }

        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turncount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.BackColor = Color.Silver;
                    btn.Enabled = true;
                    btn.Text = "";
                }//end foreach
            }//end try
            catch { }

        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criado por João Marcos Salles", "Sobre Jogo da Velha");
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (turn)
            {
                btn.BackColor = Color.Aquamarine;
                btn.Text = "X";
            }
            else
            {
                btn.BackColor = Color.DeepPink;
                btn.Text = "O";
            }
            turn = !turn;
            btn.Enabled = false;
            turncount++;    

            checarVencedor();
        }

        private void checarVencedor()
        {
            bool vencedor = false;

            // checa na horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    vencedor = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    vencedor = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    vencedor = true;

            // checa na vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                    vencedor = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                    vencedor = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                    vencedor = true;

            // checa na diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                vencedor = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                vencedor = true;


            if (vencedor)
            {
                disabBtn();

                String venceu = "";
                if (turn)
                    venceu = "O";
                else
                    venceu = "X";

                MessageBox.Show(venceu + " Venceu a partida!!!", "Uhuulll!!!");
            }// end if
            else
            {
                if (turncount == 9)
                    MessageBox.Show("Foi empate!!!", "Que pena!");
            }

        } // fim de checarVencedor

        private void disabBtn ()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = false;
                }//end foreach
            }//end try
            catch { }
        }


    }
}
