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
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            pictureBox3.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            this.Hide();
            Form6 f1 = new Form6();
            f1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            pictureBox3.Visible = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Visible = true;
            pictureBox3.Visible = false;

        }
    }
}
