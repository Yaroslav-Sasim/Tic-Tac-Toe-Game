using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TICTAK
{
    public partial class _5x5Man : Form
    {
        public _5x5Man()
        {
            InitializeComponent();
        }
        bool turn = true; //true=x; false=y turn
        int turn_count = 0;

        private void newGame_Click(object sender, EventArgs e)
        {
            {
                turn = true;
                turn_count = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }//end try
                    catch { }
                }//end foreach
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkFormWinner();
        }

        private void checkFormWinner()
        {
            bool there_is_a_winner = false;
            //горизонтальны
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A3.Text == A4.Text) &&(A4.Text==A5.Text)&& (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B3.Text == B4.Text) && (B4.Text==B5.Text)&&(!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C3.Text == C4.Text) &&(C4.Text==C5.Text)&& (!C1.Enabled))
                there_is_a_winner = true;
            else if ((E1.Text == E2.Text) && (E2.Text == E3.Text) && (E3.Text == E4.Text) && (E4.Text==E5.Text)&&(!E1.Enabled))
                there_is_a_winner = true;
            else if ((D1.Text == D2.Text) && (D2.Text == D3.Text) && (D3.Text == D4.Text) && (D4.Text == D5.Text) && (!D1.Enabled))
                there_is_a_winner = true;
            //вертикально
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (C1.Text == E1.Text) &&(E1.Text==D1.Text)&& (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (C2.Text == E2.Text) &&(E2.Text==D2.Text)&& (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (C3.Text == E3.Text) &&(E3.Text==D3.Text)&& (!A3.Enabled))
                there_is_a_winner = true;
            else if ((A4.Text == B4.Text) && (B4.Text == C4.Text) && (C4.Text == E4.Text) &&(E4.Text==D4.Text)&& (!A4.Enabled))
                there_is_a_winner = true;
            else if ((A5.Text == B5.Text) && (B5.Text == C5.Text) && (C5.Text == E5.Text) && (E5.Text == D5.Text) && (!A5.Enabled))
                there_is_a_winner = true;
            //диагональ 
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (C3.Text == E4.Text) &&(E4.Text==D5.Text)&& (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A5.Text == B4.Text) && (B4.Text == C3.Text) && (C3.Text == E2.Text) &&(E2.Text==A1.Text)&& (!E1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disableButtons();
                String winner = "";
                if (turn)
                {
                    winner = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }

                else
                {
                    winner = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(" Победитель -  " + winner, "Ура!");
                // newGame.PerformClick();
            }
            else
            {
                if (turn_count == 25)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Ничья!", "Упс!");
                }
            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }//end if
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }//end if
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";

            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end try
                catch { }
            }//end foreach
        }
    }
}
