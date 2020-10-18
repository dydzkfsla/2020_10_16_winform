using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test01;
namespace _2020_10_16_winform
{
    public partial class Form2 : Form
    {
        PMath pMath = new PMath();
        Choose choose = new Choose();
        Random random = new Random();
        int Seccse = 0;
        int score = 0;
        int opportunity = 10;
        int success = 0;
        char oper;
        private static Form2 form2 = null;

        private Form2()
        {
            InitializeComponent();
        }

        public static void NewFrom()
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
                form2.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            label4.Text = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value -= 5;
            if (progressBar1.Value <= 0)
            {
                progressBar1.Value = 100;
                Run();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Run();
            }
        }

        private void 초급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            SetDefault();
            choose = Choose.One; 
            SetLabel();
        }

        private void 중급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            SetDefault();
            choose = Choose.Two; 
            SetLabel();
        }

        private void 고급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            SetDefault();
            choose = Choose.Three;
            SetLabel();
        }

        private void SetLabel()
        {
            Seccse = pMath.Make(choose, out oper);
            label4.Text = pMath.X.ToString() + oper + pMath.Y.ToString();
        }

        private void SetDefault()
        {
            timer1.Interval = 500;
            success = 0;
            opportunity = 10;
            label1.Text = score.ToString();
            label2.Text = opportunity.ToString(); ;
            label4.Text = "";
            progressBar1.Value = 100;
            timer1.Stop();
            textBox1.Enabled = true;
        }

        private void Run()
        {
            int temp = 999999;
            int.TryParse(textBox1.Text,out temp);
            if (Seccse == temp)
            {
                score += 100;
                label1.Text = score.ToString();
                success++;
            }
            else
            {
                opportunity -= 1;
                label2.Text = opportunity.ToString();
            }
            textBox1.Text = "";
            progressBar1.Value = 100;

            if (success % 2 == 0)
            {
                timer1.Interval -= 20;
            }

            if (opportunity == 0)
            {
                SetDefault();
                textBox1.Enabled = false;
                success = 0;
            }

            Seccse = pMath.Make(choose, out oper);
            label4.Text = pMath.X.ToString() + oper + pMath.Y.ToString();
        }
    }
}
