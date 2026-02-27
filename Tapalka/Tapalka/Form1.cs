using System;
using System.Collections.Generic;
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
            "машина", "компьютер", "программа", "клавиатура", "монитор", "телефон",
            "телевизор", "холодильник", "микроволновка", "стиральная", "посудомойка",
            "библиотека", "университет", "школа", "магазин", "больница", "аптека",
            "ресторан", "кафе", "столовая", "парк", "сквер", "площадь", "улица"
        };
        private List<string> words3 = new List<string>
        {
            "программирование", "администрирование", "конфигурирование", "инкапсуляция",
            "наследование", "полиморфизм", "деструктор", "конструктор", "интерфейс",
            "абстракция", "делегирование", "сериализация", "десериализация", "многопоточность",
            "синхронизация", "асинхронность", "параллелизм", "конкурентность", "оптимизация",
            "рефакторинг", "документирование", "тестирование", "отладка", "дебаггинг"
        };

        private List<string> currentWords;
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
        private void NextWord()
        {
            if (currentWords != null)
            {
                currentWord = currentWords[random.Next(currentWords.Count)];
                label1.Text = currentWord;
                textBox1.Clear();
                textBox1.Focus();
            }
        }
        private void StartGame()
        {
            if (radioButton2.Checked)
            {
                currentWords = words2;
                timeLeft = 45;
            }
            else if (radioButton3.Checked)
            {
                currentWords = words3;
                timeLeft = 30;
            }
            else
            {
                currentWords = words1;
                timeLeft = 60;
            }

            score = 0;
            isGameActive = true;

            label2.Text = "Правильно: 0 слов";
            label3.Text = "Осталось: " + timeLeft + " сек";

            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = true;

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;

            textBox1.Clear();
            textBox1.Focus();

            NextWord();

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
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

        private void EndGame2()
        {
            timer1.Stop();
            isGameActive = false;

            MessageBox.Show($"Время вышло!\nПравильно введено слов: {score}\nСкорость: {score} WPM",
                          "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = false;
            label1.Text = "Нажмите СТАРТ";

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isGameActive) return;

            if (textBox1.Text.Trim().ToLower() == currentWord.ToLower())
            {
                score++;
                label2.Text = $"Правильно: {score} слов";

                NextWord();
            }
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EndGame2();
        }
    }
}
