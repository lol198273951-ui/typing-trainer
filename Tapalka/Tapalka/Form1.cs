using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tapalka
{
    public partial class Form1 : Form
    {
        private List<string> words1 = new List<string>
        {
            "кот", "дом", "лес", "река", "гора", "машина", "компьютер",
            "программа", "код", "разработка", "скорость", "печать", "текст",
            "клавиатура", "мышь", "экран", "окно", "кнопка", "файл", "папка"
        };
        private List<string> words2 = new List<string>
        {
            "кот", "дом", "лес", "река", "гора", "машина", "компьютер",
            "программа", "код", "разработка", "скорость", "печать", "текст",
            "клавиатура", "мышь", "экран", "окно", "кнопка", "файл", "папка"
        };
        private List<string> words3 = new List<string>
        {
            "кот", "дом", "лес", "река", "гора", "машина", "компьютер",
            "программа", "код", "разработка", "скорость", "печать", "текст",
            "клавиатура", "мышь", "экран", "окно", "кнопка", "файл", "папка"
        };

        private Random random = new Random();
        private string currentWord;
        private int score = 0;
        private int timeLeft = 30;
        private bool isGameActive = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Нажмите СТАРТ";
            button2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void StartGame()
        {
            score = 0;
            timeLeft = 30;
            isGameActive = true;

            label2.Text = "Правильно: 0 слов";
            label3.Text = "Осталось: " + timeLeft + " сек";

            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Clear();
            textBox1.Focus();

            NextWord();

            timer1.Start();
        }
        private void NextWord()
        {
            currentWord = words1[random.Next(words1.Count)];
            label1.Text = currentWord;
            textBox1.Clear();
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isGameActive) return;

            if (textBox1.Text.Trim().ToLower() == currentWord.ToLower())
            {
                score++;
                label2.Text = $"Правильно: {score} слов";
            }

            NextWord();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            label3.Text = $"Осталось: {timeLeft} сек";

            if (timeLeft <= 0)
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            timer1.Stop();
            isGameActive = false;

            MessageBox.Show($"Время вышло!\nПравильно введено слов: {score}\nСкорость: {score} WPM",
                          "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = false;
            label1.Text = "Нажмите СТАРТ";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
