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
    public partial class Form5 : Form
    {
        public enum Player
        {
            X, O //инициализируем два компонетка
        }

        public Form5()
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
        Button n=new Button() ;
       

        private void loadbuttons() // загрузка кнопок из коллекции (по умолчанию)
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
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
            button10.Text = " Заново"; // не заморачивался, почему "Заново" постоянно сбрасывалось, поэтому ввел здесь на постоянную
            loadbuttons();// вызов загрузки уровня
        }

        private void Check()// проверка на комбинации кнопок
        {
            curretPlayer = Player.X;
  
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
               button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
               button7.Text == "X" && button9.Text == "X" && button8.Text == "X" ||
               button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
               button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
               button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
               button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
               button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                AITimer.Stop();// остановка таймера компьютера
                MessageBox.Show("Игрок победил!");
                playerWins++;// прибавление к Игроку 1 победы
                label3.Text = "" + playerWins;//вывод в Label
                resetGame();// автоперезапуск уровня
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
            
                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
               button7.Text == "O" && button9.Text == "O" && button8.Text == "O" ||
               button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
               button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
               button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
               button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
               button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                AITimer.Stop();
                MessageBox.Show("Компьютер победил!");
                computerWins++;// прибавление к Компьютеру 1 победы
                label2.Text = "" + computerWins;
                resetGame();// см. выше
            }
            else if ((curretPlayer.ToString())/*&& (!(button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||

                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
               button7.Text == "O" && button9.Text == "O" && button8.Text == "O" ||
               button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
               button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
               button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
               button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
               button3.Text == "O" && button5.Text == "O" && button7.Text == "O"))&&(
               !(button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
               button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
               button7.Text == "X" && button9.Text == "X" && button8.Text == "X" ||
               button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
               button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
               button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
               button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
               button3.Text == "X" && button5.Text == "X" && button7.Text == "X"))*/)
            {

                MessageBox.Show("ничья");
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

        private void AI_Load(object sender, EventArgs e)
        {

        }

    

        private void AITimer_Tick_1(object sender, EventArgs e)
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

        private void button10_Click_1(object sender, EventArgs e)
        {
            resetGame();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f2 = new Form6();
            f2.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игроки по очереди ставят на свободные клетки поля 3х3 знаки (один всегда крестики, другой всегда нолики).\nПервый, выстроивший в ряд 3 своих фигуры по вертикали, горизонтали или диагонали, выигрывает.\nПервый ход делает игрок, ставящий крестики.\n\nХорошей игры!!!", "Подсказка");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label3.Text = "0";
            draw_count.Text = "0";
            label2.Text = "0";
        }
    }
}
