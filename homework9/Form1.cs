using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Random;

namespace homework9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int num;
        public int index = 0;
        public string word;
        public string meaning;
        public int correct = 0;

        private void vocabularies(string voca_path)
        {
            StreamReader sr = new StreamReader(voca_path, Encoding.Default);
            string str;
            while ((str = sr.ReadLine()) != null)
            {

            }
            sr.Close();
        }

        private void next_vocabulary(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = (index + 1).ToString();

            Random rd = new Random();
            int every = rd.Next(0, i);

            string[] temp = new string[3];
            temp = str1[every].Split(new Char[] { '\t', '\t', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            word = temp[0];
            meaning = temp[1];

            Chinese.Text = meaning;

            index++;

            button_next.Text = "跳过";

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            button_next.Enabled = true;
            Chinese.Text = "";
            num = (int)vocab_num.Value;
            this.next_vocabulary(sender, e);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (button_next.Text == "跳过")
            {
                textBox1.Text = word;
                textBox1.Enabled = false;
                if (index == num)
                {
                    MessageBox.Show("总共答对" + correct + "个单词");
                    button_next.Enabled = false;
                }
                button_next.Text = "下一题";
            }
            else
            {
                textBox1.Enabled = true;
                this.next_vocabulary(sender, e);
            }
        }

        private void vocabulary(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox1.Text == word)
                {
                    correct++;
                    MessageBox.Show("正确");
                    this.next_vocabulary(sender, e);
                }
                else
                {
                    MessageBox.Show("错误");
                }
            }
        }

        string[] str1 = new string[1409];
        public int i = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            button_next.Enabled = false;
            StreamReader sr = new StreamReader("Vocabulary.txt", Encoding.Default);
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                str1[i] = str;
                i++;
            }

            string[] temp = new string[3];
            temp = str1[0].Split(new Char[] { '\t', '\t', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
