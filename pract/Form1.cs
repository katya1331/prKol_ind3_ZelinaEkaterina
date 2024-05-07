using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pract
{
    public partial class Form1 : Form
    {
        Mus d = new Mus();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Номер диска";
            dataGridView1.Columns[1].HeaderText = "Песня";
            dataGridView1.Columns[2].HeaderText = "Автор";
            File.Delete("1.txt");
            d.disknames = new Hashtable();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && numericUpDown1.Value != 0)
            {
                int xer = (int)numericUpDown1.Value;
                d.disknum = xer;
                d.song = textBox1.Text;
                d.autor = textBox2.Text;
                string str = ',' + d.song + ',' + d.autor;
                if(d.AddDisk(xer, str))
                {
                    dataGridView1.Rows.Add(d.disknum, d.song, d.autor);
                    numericUpDown1.Value = 0;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else MessageBox.Show("Disk exist!!!!");
            }
            else MessageBox.Show("Поля заполните!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int delnum = (int)numericUpDown1.Value;
            for(int i=0;i<dataGridView1.RowCount;i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == delnum)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    d.disknames.Remove(delnum);
                    File.Delete("1.txt");
                    foreach (string line in d.disknames)
                    {
                        File.AppendAllText("1.txt",line + "\n");
                    }               
                }
            }
            numericUpDown1.Value = 0;
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string re = textBox3.Text;
            dataGridView1.Rows.Clear();
            int i = 0;
            StreamReader sr = new StreamReader("1.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] str = line.Split(',');
                if (str[2].Contains(re))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = int.Parse(str[0]);
                    dataGridView1.Rows[i].Cells[1].Value = str[1];
                    dataGridView1.Rows[i].Cells[2].Value = str[2];
                    i++;
                }
            }
            sr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string re = textBox3.Text;
            dataGridView1.Rows.Clear();
            int i = 0;
            StreamReader sr = new StreamReader("1.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] str = line.Split(',');
                if (str[1].Contains(re))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = int.Parse(str[0]);
                    dataGridView1.Rows[i].Cells[1].Value = str[1];
                    dataGridView1.Rows[i].Cells[2].Value = str[2];
                    i++;
                }
            }
            sr.Close();
        }
    }
}
