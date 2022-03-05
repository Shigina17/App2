using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace App2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start("https://uchitel.pro/история-россии-предмет/");
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new string[3] { textBox1.Text, textBox2.Text, textBox3.Text });
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                StreamReader sr = new StreamReader("data.txt");
                string[] lines = sr.ReadToEnd().Trim().Split(Convert.ToChar("\n"));
                foreach (string str in lines)
                {
                    dataGridView1.Rows.Add(str.Split('$'));
                }
                sr.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter("data.txt");
            string data = "";
            foreach (DataGridViewRow line in dataGridView1.Rows)
            {
                if (line.Cells[0].Value != null && line.Cells[1].Value != null && line.Cells[2].Value != null)
                {
                    data += line.Cells[0].Value.ToString() + "$" + line.Cells[1].Value.ToString() + "$" + line.Cells[2].Value.ToString() + "\n";
                }
            }
            sw.Write(data); 
            sw.Close();
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this, textBox1.Enabled);
            form.Show();
        }

        public void Turn(bool value)
        {
            textBox1.Enabled = value;
            textBox2.Enabled = value;
            textBox3.Enabled = value;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == tabControl1.TabPages.Count - 1)
            {
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Text = "Новая вкладка";
                tabControl1.TabPages.Add(new TabPage());
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Text = "+";
            }
        }
    }
}
