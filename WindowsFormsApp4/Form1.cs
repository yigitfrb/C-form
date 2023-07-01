using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public string[] questions;
        public string[] answers;
        public int currentQuestionIndex;
        public int score;
        public string harf;
        public string[] harfler;
        public int indis;
        public double zaman = 60.0;
        List<int> previousGuesses = new List<int>();
        public Form1()
        {
            InitializeComponent();

            questions = new string[]
            {
                "What is the capital of France?",
                "Which country is known as the 'Land of the Rising Sun'?",
                "What is the tallest mountain in the world?",
                "How many continents are there?"
            };

            answers = new string[]
            {
                "Paris",
                "Japan",
                "mounteverest",
                "7"
            };

            

            currentQuestionIndex = 0;
            score = 0;


            // Set up the form
            label3.Text = questions[currentQuestionIndex];
            label2.Text = $"Score: {score}";
            labelaktar();
        }
        void labelaktar()
        {
            label1.Text = "";
            for (int i = 0; i < answers[currentQuestionIndex].Length; i++)
            {
                label1.Text += "_ ";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string userAnswer = textBox1.Text.Trim();
        //    string correctAnswer = answers[currentQuestionIndex];

        //    // Check if the answer is correct
        //    if (string.Equals(userAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase))
        //    {
        //        score+=10*(answers[currentQuestionIndex].Length-previousGuesses.Count());
        //        currentQuestionIndex++;
        //        previousGuesses.Clear();
        //        // Move to the next question or end the game
        //        if (currentQuestionIndex < questions.Length)
        //        {
        //            label3.Text = questions[currentQuestionIndex];
        //            label2.Text = $"Score: {score}";
        //            labelaktar();
        //            textBox1.Text = string.Empty;
        //        }
        //        else
        //        {
        //            // Show the final score
        //            label3.Text = "Game Over!";
        //            label2.Text = $"Final Score: {score}";

        //            textBox1.Enabled = false;
        //            button1.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        score-=10;
        //        // Move to the next question or end the game
        //        if (currentQuestionIndex < questions.Length)
        //        {
        //            label3.Text = questions[currentQuestionIndex];
        //            label2.Text = $"Score: {score}";
        //            textBox1.Text = string.Empty;
        //        }
        //        else
        //        {
        //            // Show the final score
        //            label3.Text = "Game Over!";
        //            label2.Text = $"Final Score: {score}";

        //            textBox1.Enabled = false;
        //            button1.Enabled = false;
        //        }
        //    }
        //}
        static string yazdir(string metin, int indis, string yenideger)
        {
            metin = metin.Remove(indis, 2);
            return metin.Insert(indis, yenideger + " ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            indis = rnd.Next(0, answers[currentQuestionIndex].Length);
            if (previousGuesses.Count == 0)
            {
                indis *= 2;
                previousGuesses.Add(indis);
                harf = answers[currentQuestionIndex].Substring(indis / 2, 1);
                label1.Text = yazdir(label1.Text, indis, harf);
                score -= 10;
                label2.Text = $"Score: {score}";
            }
            else
            {
                for (int i = 0; i < previousGuesses.Count; i++)
                {
                    if (previousGuesses[i] == indis * 2)
                    {
                        indis = rnd.Next(0, answers[currentQuestionIndex].Length);
                        i = -1;
                    }
                }
                indis *= 2;
                previousGuesses.Add(indis);
                harf = answers[currentQuestionIndex].Substring(indis / 2, 1);
                label1.Text = yazdir(label1.Text, indis, harf);
                score -= 10;
                label2.Text = $"Score: {score}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            score += 10 * (answers[currentQuestionIndex].Length - previousGuesses.Count());
            previousGuesses.Clear();

            if (currentQuestionIndex < questions.Length)
            {
                label3.Text = questions[currentQuestionIndex];
                label2.Text = $"Score: {score}";
            }
            else
            {
                label3.Text = "Game Over!";
                label2.Text = $"Final Score: {score}";
            }
            label1.Text = answers[currentQuestionIndex];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            score -= 10 * (answers[currentQuestionIndex].Length - previousGuesses.Count());
            
            if (currentQuestionIndex < questions.Length)
            {
                label3.Text = questions[currentQuestionIndex];
                label2.Text = $"Score: {score}";

            }
            else
            {
                
                label3.Text = "Game Over!";
                label2.Text = $"Final Score: {score}";
            }
        }
        void surehak()
        {
            label4.Text ="KALAN SÜRE : "+ + Math.Round(zaman,1);
            
        }
        void oyunBitti()
        {
            if (zaman <= 0)
            {
                timer1.Stop();
                MessageBox.Show("OYUN BİTTİ! KELİMEYİ BULAMADIN");

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            oyunBitti();
            surehak();
            if (zaman > 0)
            {
                zaman-=0.1;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentQuestionIndex++;
            previousGuesses.Clear();

            if (currentQuestionIndex < questions.Length)
            {
                label3.Text = questions[currentQuestionIndex];
                label2.Text = $"Score: {score}";
                labelaktar();
                timer1.Start();

            }
            else
            {

                label3.Text = "Game Over!";
                label2.Text = $"Final Score: {score}";
            }
        }
    }
}
