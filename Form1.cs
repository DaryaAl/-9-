using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_6;

namespace Практическая_работа__9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Кнопка О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заполнить таблицу на 5 предметов с полями: предмет, ФИО лектора, номер аудитории, кол - во часов в семестре." +
                "Вывести результат на экран.Вывести список лекторов работающих в заданной аудитории.");
        }

        //Кнопка Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        Lessons[] lessons;

        //Начальные значения при загрузке формы
        private void Form1_Shown(object sender, EventArgs e)
        {
            lessons = new Lessons[6];
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 6;
            numericUpDown1.Value = 1;
            dataGridView1[0, 0].Value = "Предмет";
            dataGridView1[1, 0].Value = "Лектор";
            dataGridView1[2, 0].Value = "Аудитория";
            dataGridView1[3, 0].Value = "Кол-во часов";
        }

        //Кнопка Добавить
        private void button1_Click(object sender, EventArgs e)
        {
            int pos = (int)numericUpDown1.Value;

            lessons[pos].Subject = textBox1.Text;
            lessons[pos].Lecturer = textBox2.Text;

            dataGridView1[0, pos].Value = textBox1.Text;
            dataGridView1[1, pos].Value = textBox2.Text;

            //Проверка номера аудитории
            if (Int32.TryParse(textBox3.Text, out int n1))
            {
                if (n1 >= 0)
                {
                    lessons[pos].Auditorium = Convert.ToInt32(textBox3.Text);
                    dataGridView1[2, pos].Value = textBox3.Text;
                }
                else
                {
                    MessageBox.Show("Номер аудитории задан неправильно");
                }
            }
            //Проверка количества часов
            if (Int32.TryParse(textBox4.Text, out int n2))
            {
                if (n2 > 0)
                {
                    lessons[pos].Hours = Convert.ToInt32(textBox4.Text);
                    dataGridView1[3, pos].Value = textBox4.Text;
                }
                else
                {
                    MessageBox.Show("Количество часов задано неправильно");
                }
            }    
        }

        //Кнопка Найти
        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            int auditorium = Convert.ToInt32(textBox5.Text);
            for(int i=1;i<dataGridView1.RowCount; i++)
            {
                if (auditorium == lessons[i].Auditorium)
                {
                    textBox6.Text = textBox6.Text + " " + lessons[i].Lecturer.ToString();
                }
            }
        }

        //Кнопка Очистить
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 6;
            numericUpDown1.Value = 1;
            textBox6.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            for (int i = 1; i < 6; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    dataGridView1[j,i].Value="";
                }
            }
        }
    }
}
