using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TICTAK
{
    public partial class Form3 : Form
    {
       
        bool turn = true; //true=x; false=y turn
        int turn_count = 0;
     

        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
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
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            //вертикально
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            //диагональ 
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
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
                if (turn_count == 9)
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

        private void button2_Click(object sender, EventArgs e)
        {
          
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
          
            Application.Exit();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Игроки по очереди ставят на свободные клетки поля 3х3 знаки (один всегда крестики, другой всегда нолики).\nПервый, выстроивший в ряд 3 своих фигуры по вертикали, горизонтали или диагонали, выигрывает.\nПервый ход делает игрок, ставящий крестики.\n\nВ полях Игрок 1 и Игрок 2 можно указать свои имена.\n\nХорошей игры!!!", "Подсказка");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            pictureBox9.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           
            pictureBox8.Visible = true;
            pictureBox9.Visible = false;
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
          
            pictureBox9.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
