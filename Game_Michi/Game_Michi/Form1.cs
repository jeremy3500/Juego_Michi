using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Game_Michi
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        string turn = ""; 
        ArrayList lista = new ArrayList();
        bool[] jug_play = new bool[9]; bool game = true, victory;
        private void Form1_Load(object sender, EventArgs e)
        {
            btn_01.Text = null; btn_02.Text = null; btn_03.Text = null; btn_04.Text = null;
            btn_05.Text = null; btn_06.Text = null; btn_07.Text = null; btn_08.Text = null; btn_09.Text = null;

            turn = "player";
            lblName.Text = turn;
            
        }
        public void verify_turn(Button btn, int num)
        {
            if (turn == "player")
            {
                turn = "bot"; btn.BackColor = Color.FromArgb(47, 74, 157); btn.Enabled = false; // COLOR azul
                jug_play[num - 1] = true; verify_victory();
            }
            else
            {
                turn = "player"; btn.BackColor = Color.FromArgb(145, 31, 39); btn.Enabled = false; // COLOR red 
            }
            if (game) { lblName.Text = turn; wait(1000); }
        }
        public void turno_bot()
        {
            if (game)
            {
                if (turn == "bot" && lista.Count < 9)
                {
                    bool repet = false; int n;
                    do
                    {
                        repet = false;
                        Random rnd = new Random();
                        n = rnd.Next(1, 10);
                        foreach (int i in lista)
                        {
                            if (i == n) { repet = true; break; }
                            Thread.Sleep(100);
                        }
                    } while (repet);
                    switch (n)
                    {
                        case 1: btn_01.PerformClick(); break;
                        case 2: btn_02.PerformClick(); break;
                        case 3: btn_03.PerformClick(); break;
                        case 4: btn_04.PerformClick(); break;
                        case 5: btn_05.PerformClick(); break;
                        case 6: btn_06.PerformClick(); break;
                        case 7: btn_07.PerformClick(); break;
                        case 8: btn_08.PerformClick(); break;
                        case 9: btn_09.PerformClick(); break;
                    }
                }
            }
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer"); 
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer"); 
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        public void verify_victory()
        {
            if (jug_play[0] && jug_play[1] && jug_play[2]) victory = true;
            if (jug_play[3] && jug_play[4] && jug_play[5]) victory = true;
            if (jug_play[6] && jug_play[7] && jug_play[8]) victory = true;

            if (jug_play[0] && jug_play[3] && jug_play[6]) victory = true;
            if (jug_play[1] && jug_play[4] && jug_play[7]) victory = true;
            if (jug_play[2] && jug_play[5] && jug_play[8]) victory = true;

            if (jug_play[0] && jug_play[4] && jug_play[8]) victory = true;
            if (jug_play[2] && jug_play[4] && jug_play[6]) victory = true;

            if (victory) { game = false; MessageBox.Show("\tGanaste\t\t"); }
        }
        private void btn_01_Click(object sender, EventArgs e) { lista.Add(1); verify_turn(btn_01, 1); turno_bot(); }
        private void btn_02_Click(object sender, EventArgs e) { lista.Add(2); verify_turn(btn_02, 2); turno_bot(); }
        private void btn_03_Click(object sender, EventArgs e) { lista.Add(3); verify_turn(btn_03, 3); turno_bot(); }
        private void btn_04_Click(object sender, EventArgs e) { lista.Add(4); verify_turn(btn_04, 4); turno_bot(); }
        private void btn_05_Click(object sender, EventArgs e) { lista.Add(5); verify_turn(btn_05, 5); turno_bot(); }
        private void btn_06_Click(object sender, EventArgs e) { lista.Add(6); verify_turn(btn_06, 6); turno_bot(); }
        private void btn_07_Click(object sender, EventArgs e) { lista.Add(7); verify_turn(btn_07, 7); turno_bot(); }
        private void btn_08_Click(object sender, EventArgs e) { lista.Add(8); verify_turn(btn_08, 8); turno_bot(); }
        private void btn_09_Click(object sender, EventArgs e) { lista.Add(9); verify_turn(btn_09, 9); turno_bot(); }
    }
}
