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
    public partial class AI4x4 : Form
    {

        public enum Player
        {
            X, O //инициализируем два компонетка
        }

        public AI4x4()
        {
            InitializeComponent();
            resetGame();
        }

        Player curretPlayer;
        List<Button> buttons; //заносим в коолекцию кнопки
        Random rand = new Random();
        int playerWins = 0; //очки побед игрока
        int computerWins = 0;// очки побед компьютера
        int nec = 0;

        private void loadbuttons() // загрузка кнопок из коллекции (по умолчанию)
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16 };
        }
        private void resetGame() //пересчёт кнопок на заполнение
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button)
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).Text = "";
                    ((Button)X).BackColor = default(Color);
                }
            }
          
            loadbuttons();// вызов загрузки уровня
        }

        private void Check()// проверка на комбинации кнопок
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" && button4.Text == "X" ||
               button7.Text == "X" && button5.Text == "X" && button6.Text == "X" && button8.Text == "X" ||
               button9.Text == "X" && button10.Text == "X" && button11.Text == "X" && button12.Text == "X" ||
               button13.Text == "X" && button14.Text == "X" && button15.Text == "X" && button16.Text == "X" ||
               button1.Text == "X" && button8.Text == "X" && button12.Text == "X" && button16.Text == "X" ||
               button2.Text == "X" && button7.Text == "X" && button11.Text == "X" && button15.Text == "X" ||
               button3.Text == "X" && button6.Text == "X" && button10.Text == "X" && button14.Text == "X" ||
               button4.Text == "X" && button5.Text == "X" && button9.Text == "X" && button13.Text == "X" ||
               button1.Text == "X" && button7.Text == "X" && button10.Text == "X" && button13.Text == "X" ||
               button4.Text == "X" && button6.Text == "X" && button11.Text == "X" && button16.Text == "X"
               )
            {
                AITimer.Stop();// остановка таймера компьютера
                MessageBox.Show("Игрок победил!");
                playerWins++;// прибавление к Игроку 1 победы
                label4.Text = "" + playerWins;//вывод в Label
                resetGame();// автоперезапуск уровня
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O" && button4.Text == "O" ||
               button7.Text == "O" && button5.Text == "O" && button6.Text == "O" && button8.Text == "O" ||
               button9.Text == "O" && button10.Text == "O" && button11.Text == "O" && button12.Text == "O" ||
               button13.Text == "O" && button14.Text == "O" && button15.Text == "O" && button16.Text == "O" ||
               button1.Text == "O" && button8.Text == "O" && button12.Text == "O" && button16.Text == "O" ||
               button2.Text == "O" && button7.Text == "O" && button11.Text == "O" && button15.Text == "O" ||
               button3.Text == "O" && button6.Text == "O" && button10.Text == "O" && button14.Text == "O" ||
               button4.Text == "O" && button5.Text == "O" && button9.Text == "O" && button13.Text == "O" ||
               button1.Text == "O" && button7.Text == "O" && button10.Text == "O" && button13.Text == "O" ||
               button4.Text == "O" && button6.Text == "O" && button11.Text == "O" && button16.Text == "O")
            {
                AITimer.Stop();
                MessageBox.Show("Компьютер победил!");
                computerWins++;// прибавление к Компьютеру 1 победы
                label5.Text = "" + computerWins;
                // resetGame();// см. выше
            }
            else if (!(button1.Text == "X" && button2.Text == "X" && button3.Text == "X" && button4.Text == "X" ||
               button7.Text == "X" && button5.Text == "X" && button6.Text == "X" && button8.Text == "X" ||
               button9.Text == "X" && button10.Text == "X" && button11.Text == "X" && button12.Text == "X" ||
               button13.Text == "X" && button14.Text == "X" && button15.Text == "X" && button16.Text == "X" ||
               button1.Text == "X" && button8.Text == "X" && button12.Text == "X" && button16.Text == "X" ||
               button2.Text == "X" && button7.Text == "X" && button11.Text == "X" && button15.Text == "X" ||
               button3.Text == "X" && button6.Text == "X" && button10.Text == "X" && button14.Text == "X" ||
               button4.Text == "X" && button5.Text == "X" && button9.Text == "X" && button13.Text == "X" ||
               button1.Text == "X" && button7.Text == "X" && button10.Text == "X" && button13.Text == "X" ||
               button4.Text == "X" && button6.Text == "X" && button11.Text == "X" && button16.Text == "X") &&
               !(button1.Text == "O" && button2.Text == "O" && button3.Text == "O" && button4.Text == "O" ||
               button7.Text == "O" && button5.Text == "O" && button6.Text == "O" && button8.Text == "O" ||
               button9.Text == "O" && button10.Text == "O" && button11.Text == "O" && button12.Text == "O" ||
               button13.Text == "O" && button14.Text == "O" && button15.Text == "O" && button16.Text == "O" ||
               button1.Text == "O" && button8.Text == "O" && button12.Text == "O" && button16.Text == "O" ||
               button2.Text == "O" && button7.Text == "O" && button11.Text == "O" && button15.Text == "O" ||
               button3.Text == "O" && button6.Text == "O" && button10.Text == "O" && button14.Text == "O" ||
               button4.Text == "O" && button5.Text == "O" && button9.Text == "O" && button13.Text == "O" ||
               button1.Text == "O" && button7.Text == "O" && button10.Text == "O" && button13.Text == "O" ||
               button4.Text == "O" && button6.Text == "O" && button11.Text == "O" && button16.Text == "O"))
            {
              
               

            }

            

        }

        private void playerClick(object sender, EventArgs e)// проверк анажатий на кнопки
        {
            var button = (Button)sender;
            curretPlayer = Player.X;
            button.Text = curretPlayer.ToString();//установка параметра отображения на кнопки
            button.Enabled = false;
            buttons.Remove(button);
            Check();
            AITimer.Start();
        }

        private void AI4x4_Load(object sender, EventArgs e)
        {

        }

        private void AITimer_Tick(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Enabled = false;
                curretPlayer = Player.O;
                buttons[index].Text = curretPlayer.ToString();
                buttons.RemoveAt(index);
                Check();
                AITimer.Stop();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label3.Text = "0";
            draw_count.Text = "0";
            label2.Text = "0";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            resetGame();
        }
    }
}
