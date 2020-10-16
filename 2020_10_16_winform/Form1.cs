﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020_10_16_winform
{
    public partial class Form1 : Form
    {
        Thread thread;
        int left = 0, right = 0;
        string oper = "+";

        public void ColorRan()
        {
            Random random = new Random();

            while (true)
            {
                int R = random.Next(0, byte.MaxValue);
                int G = random.Next(0, byte.MaxValue);
                int B = random.Next(0, byte.MaxValue);

                button15.BackColor = Color.FromArgb(R, G, B);
                Thread.Sleep(100);
            }
        }

        public Form1()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(ColorRan));
            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void num_button_Click(object sender, EventArgs e)
        {
            ldl_cal.Text += ((Button)sender).Text;
        }

        private void oper_button_Click(object sender, EventArgs e)
        {
            operate_do();
            right = 0;
            oper = ((Button)sender).Text;
            ldl_temp.Text = left.ToString() + oper;

        }

        private void operate_do()
        {
            right = int.Parse(ldl_cal.Text);
            ldl_cal.Text = "";
            switch (oper)
            {
                case "+":
                    left = left + right;
                    break;
                case "-":
                    left = left - right;
                    break;
                case "*":
                    left = left * right;
                    break;
                case "/":
                    left = left / right;
                    break;
            }
        }

        private void c_button_Click(object sender, EventArgs e)
        {
            ldl_cal.Text = null;
            ldl_temp.Text = null;
            oper = "+";
            left = 0;
            right = 0;
        }

        private void eql_button_Click(object sender, EventArgs e)
        {
            operate_do();
            ldl_cal.Text = left.ToString();
            ldl_temp.Text = null;
            oper = "+";
            left = 0;
            right = 0;
        }

            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
    }
}
