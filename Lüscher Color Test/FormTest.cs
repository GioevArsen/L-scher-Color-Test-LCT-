using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Lüscher_Color_Test
{
    public partial class FormTest : System.Windows.Forms.Form
    {

        int Stage1Level = 1;
        int Stage2Level = 1;
        int Stage2CardsLeft = 8;

        Label Stage1Header = new Label();
        Label Stage2Header = new Label();

        Button ButtonCard1_1 = new Button();
        Button ButtonCard1_2 = new Button();

        Button ButtonCard2_1 = new Button();
        Button ButtonCard2_2 = new Button();
        Button ButtonCard2_3 = new Button();
        Button ButtonCard2_4 = new Button();
        Button ButtonCard2_5 = new Button();
        Button ButtonCard2_6 = new Button();
        Button ButtonCard2_7 = new Button();
        Button ButtonCard2_8 = new Button();

        PictureBox loadingIMAGE = new PictureBox();

        Label loadingTEXT = new Label();

        Timer loadingTIMER = new Timer() { Enabled = true };

        Random rnd = new Random();

        List<Color> COLORS = new List<Color>();

        string[] colorsSTAGE1;

        int BRIGHTcounter = 0;
        int DIMcounter = 0;
        int BLACKcounter = 0;
        int GRAYcounter = 0;
        int BROWNcounter = 0;
        int BLUEcounter = 0;
        int GREENcounter = 0;
        int REDcounter = 0;
        int PURPLEcounter = 0;
        int YELLOWcounter = 0;

        bool ClosedCorreclty = true;

        private void IsTestRetry()
        {
            StreamReader srTestRetry = new StreamReader("TestRetryState.txt");
            string s = srTestRetry.ReadToEnd();
            /*StreamReader srClosedCorrectly = new StreamReader("ClosedCorrectly.txt");
            string s2 = srClosedCorrectly.ReadToEnd();*/
            if (s == "true")
            {
                StreamWriter srClosedCorrectly = new StreamWriter("ClosedCorrectly.txt", false);
                srClosedCorrectly.Write("false");
                srClosedCorrectly.Close();
                Stage1();
            }
            srTestRetry.Close();
        }

        private void IsClosedCorrectly()
        {
            StreamReader srTestRetry = new StreamReader("ClosedCorrectly.txt", false);
            string s = srTestRetry.ReadToEnd();
            if(s == "false")
            {
                ClosedCorreclty = false;
            }
            srTestRetry.Close();
        }

        private void ButtonsColorsStage1()
        {
            StreamReader sr = new StreamReader("LCTcolors1.txt");
            string s = "";
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                if (s.Contains(Stage1Level.ToString()))
                {
                    break;
                }
            }
            string[] words = s.Split();
            colorsSTAGE1 = new string[words.Length];
            colorsSTAGE1[0] = words[1];
            colorsSTAGE1[1] = words[2];

            ButtonCard1_1.BackColor = Color.FromName(colorsSTAGE1[0]);
            ButtonCard1_2.BackColor = Color.FromName(colorsSTAGE1[1]);

            sr.Close();
        }

        private void ButtonsColorsStage2()
        {
            StreamReader sr = new StreamReader("LCTcolors2.txt");
            string s = "";
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                if (s.Contains(Stage2Level.ToString()))
                {
                    break;
                }
            }
            string[] words = s.Split();
            string[] colors = new string[words.Length];
            for (int i = 1; i < colors.Length; i++)
            {
                colors[i - 1] = words[i];
            }

            //исправить этот позор!?
            ButtonCard2_1.BackColor = Color.FromName(colors[0]);
            ButtonCard2_2.BackColor = Color.FromName(colors[1]);
            ButtonCard2_3.BackColor = Color.FromName(colors[2]);
            ButtonCard2_4.BackColor = Color.FromName(colors[3]);
            ButtonCard2_5.BackColor = Color.FromName(colors[4]);
            ButtonCard2_6.BackColor = Color.FromName(colors[5]);
            ButtonCard2_7.BackColor = Color.FromName(colors[6]);
            ButtonCard2_8.BackColor = Color.FromName(colors[7]);

            sr.Close();
        }

        private void Stage1()
        {
            Size Stage1Size = new Size(150, 200);
            labelGreetingText.Dispose();
            labelExplanations.Dispose();
            buttonStartLCT.Dispose();

            Stage1Header.Size = new Size(720, 40);
            Stage1Header.Location = new Point(240, 55);
            Stage1Header.Text = "Этап 1. Выберите наиболее привлекательный Вам цвет.";
            Stage1Header.TextAlign = ContentAlignment.MiddleCenter; 
            Stage1Header.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            this.Controls.Add(Stage1Header);

            ButtonCard1_1.Size = Stage1Size;
            ButtonCard1_1.Location = new Point(350, 150);
            ButtonCard1_1.Click += new EventHandler(ButtonCard1_1_Click);
            this.Controls.Add(ButtonCard1_1);

            ButtonCard1_2.Size = Stage1Size;
            ButtonCard1_2.Location = new Point(675, 150);
            ButtonCard1_2.Click += new EventHandler(ButtonCard1_2_Click);
            this.Controls.Add(ButtonCard1_2);

            ButtonsColorsStage1();
        }


        private void Stage2()
        {
            Size Stage2Size = new Size(100, 150);

            Stage2Header.Size = new Size(880, 40);
            Stage2Header.Location = new Point(160, 55);
            Stage2Header.Text = "Этап 2. По очереди выбирайте наиболее привлекательный Вам цвет.";
            Stage2Header.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            this.Controls.Add(Stage2Header);

            ButtonCard2_1.Size = Stage2Size;
            ButtonCard2_1.Location = new Point(60, 175);
            ButtonCard2_1.Click += new EventHandler(AnyButton_Click);  //исправить, сократив эти 8 блоков во что-то поменьше!?
            this.Controls.Add(ButtonCard2_1);

            ButtonCard2_2.Size = Stage2Size;
            ButtonCard2_2.Location = new Point(197, 175);
            ButtonCard2_2.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_2);

            ButtonCard2_3.Size = Stage2Size;
            ButtonCard2_3.Location = new Point(334, 175);
            ButtonCard2_3.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_3);

            ButtonCard2_4.Size = Stage2Size;
            ButtonCard2_4.Location = new Point(471, 175);
            ButtonCard2_4.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_4);

            ButtonCard2_5.Size = Stage2Size;
            ButtonCard2_5.Location = new Point(608, 175);
            ButtonCard2_5.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_5);

            ButtonCard2_6.Size = Stage2Size;
            ButtonCard2_6.Location = new Point(745, 175);
            ButtonCard2_6.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_6);

            ButtonCard2_7.Size = Stage2Size;
            ButtonCard2_7.Location = new Point(882, 175);
            ButtonCard2_7.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_7);

            ButtonCard2_8.Size = Stage2Size;
            ButtonCard2_8.Location = new Point(1015, 175);
            ButtonCard2_8.Click += new EventHandler(AnyButton_Click);
            this.Controls.Add(ButtonCard2_8);

            ButtonsColorsStage2();
        }

        private void Stage2ButtonsRegeneration()
        {
            Size Stage2Size = new Size(100, 150);
                                                    //исправить, сократив эти 8 блоков во что-то поменьше!?
            this.Controls.Add(ButtonCard2_1);
            this.Controls.Add(ButtonCard2_2);
            this.Controls.Add(ButtonCard2_3);
            this.Controls.Add(ButtonCard2_4);
            this.Controls.Add(ButtonCard2_5);
            this.Controls.Add(ButtonCard2_6);
            this.Controls.Add(ButtonCard2_7);
            this.Controls.Add(ButtonCard2_8);

            //ButtonsColorsStage2();
        }
        
        private void LoadingScreen()
        {
            this.Controls.Clear();
            
            this.BackColor = Color.White;

            loadingTEXT.Text = "Подготовка результатов";
            loadingTEXT.TextAlign = ContentAlignment.MiddleCenter;
            loadingTEXT.Size = new Size(250, 50);
            loadingTEXT.Location = new Point(475, 175);
            loadingTEXT.Font = new Font("Times New Roman", 13, FontStyle.Bold);
            this.Controls.Add(loadingTEXT);

            loadingIMAGE.Location = new Point(550, 225);
            loadingIMAGE.Size = new Size(75, 75);
            loadingIMAGE.SizeMode = PictureBoxSizeMode.CenterImage;
            loadingIMAGE.Image = Lüscher_Color_Test.Properties.Resources.loadingIMAGE;
            this.Controls.Add(loadingIMAGE);

            loadingTIMER.Interval = rnd.Next(3, 6) * 1000;
            loadingTIMER.Tick += new EventHandler(timer_tick);
        }

        void timer_tick(object sender, EventArgs e)
        {
            (sender as Timer).Enabled = false;

            StreamWriter fwr = new StreamWriter("TEST123");
            for(int i = 0; i < COLORS.Count; i++)
            {
                fwr.Write(COLORS[i] + " ");
            }
            fwr.Close();
            ResultsStage();
            this.Close();
        }


        public void ResultsStage() //исправить во что-то пограмотнее!!
        {
            List<Color> BRIGHTcolors = new List<Color>() { Color.White, Color.Silver, Color.Red, Color.Blue, Color.Fuchsia, Color.Lime, Color.Yellow, Color.Aqua };
            List<Color> DIMcolors = new List<Color>() { Color.Black, Color.Gray, Color.Maroon, Color.Navy, Color.Purple, Color.Green, Color.Olive, Color.Teal };

            List<Color> BLACKcolors = new List<Color>() { Color.White, Color.Black };
            List<Color> GRAYcolors = new List<Color>() { Color.Silver, Color.Gray };
            List<Color> BROWNcolors = new List<Color>() { Color.Teal, Color.Olive };
            List<Color> BLUEcolors = new List<Color>() { Color.Blue, Color.Navy };
            List<Color> GREENcolors = new List<Color>() { Color.Lime, Color.Green };
            List<Color> REDcolors = new List<Color>() { Color.Red, Color.Maroon };
            List<Color> PURPLEcolors = new List<Color>() { Color.Fuchsia, Color.Purple };
            List<Color> YELLOWcolors = new List<Color>() {Color.Yellow, Color.Aqua };


            for (int i = 0; i < COLORS.Count; i++)
            {
                if (BRIGHTcolors.Contains(COLORS[i]))
                {
                    BRIGHTcounter++;
                }
                if (DIMcolors.Contains(COLORS[i]))
                {
                    DIMcounter++;
                }

                if (BLACKcolors.Contains(COLORS[i]))
                {
                    BLACKcounter++;
                }
                if (GRAYcolors.Contains(COLORS[i]))
                {
                    GRAYcounter++;
                }
                if (BROWNcolors.Contains(COLORS[i]))
                {
                    BROWNcounter++;
                }
                if (BLUEcolors.Contains(COLORS[i]))
                {
                    BLUEcounter++;
                }
                if (GREENcolors.Contains(COLORS[i]))
                {
                    GREENcounter++;
                }
                if (REDcolors.Contains(COLORS[i]))
                {
                    REDcounter++;
                }
                if (PURPLEcolors.Contains(COLORS[i]))
                {
                    PURPLEcounter++;
                }
                if (YELLOWcolors.Contains(COLORS[i]))
                {
                    YELLOWcounter++;
                }
            }

            //MessageBox.Show(BLACKcounter + " " + GRAYcounter + " " + BROWNcounter + " " + BLUEcounter + " " + GREENcounter + " " + REDcounter + " " + PURPLEcounter + " " + YELLOWcounter);
        }
        
        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonStartLCT_Click(object sender, EventArgs e)
        {
            Stage1();
        }

        private void ButtonCard1_1_Click(object sender, EventArgs e)
        {
            COLORS.Add(ButtonCard1_1.BackColor);
            Stage1Level++;
            ButtonsColorsStage1();
            if (Stage1Level > 32)
            {
                this.Controls.Clear();
                Stage2();
            }
        }

        private void ButtonCard1_2_Click(object sender, EventArgs e)
        {
            COLORS.Add(ButtonCard1_2.BackColor);
            Stage1Level++;
            ButtonsColorsStage1();
            if (Stage1Level > 32)
            {
                this.Controls.Clear();
                Stage2();
            }
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(sender as Button);
            COLORS.Add((sender as Button).BackColor);
            Stage2CardsLeft--;
            if (Stage2CardsLeft == 0)
            {
                if(Stage2Level < 4)
                {
                    Stage2ButtonsRegeneration();
                    Stage2CardsLeft = 8;
                    Stage2Level++;
                    ButtonsColorsStage2();
                }
                else
                {
                    DialogResult EndTest = MessageBox.Show(" Тест завершен. После недолгой обработки Ваших ответов Вам будет представлен результат.\n" +
                        "Если Вы где-то поспешили с выбором или случайно выбрали не ту карточку, " +
                        "советуем Вам перепройти тест, так как это может влиять на конечный результат.\n\n" +
                        "Вы уверены, что Вы готовы завершить тест?", "Тест завершен", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (EndTest == DialogResult.Yes)
                    {
                        StreamWriter srTestRetry = new StreamWriter("TestRetryState.txt", false);
                        srTestRetry.Write("false");
                        srTestRetry.Close();
                        LoadingScreen();
                    }
                    else
                    {
                        StreamWriter srTestRetry = new StreamWriter("TestRetryState.txt", false);
                        srTestRetry.Write("true");
                        srTestRetry.Close();
                        Application.Restart();
                    }
                }
            }
        }


        private void FormTest_Load(object sender, EventArgs e)
        {
            IsClosedCorrectly();
            if (ClosedCorreclty == false)
            {
                IsTestRetry();
                StreamWriter srTestRetry = new StreamWriter("TestRetryState.txt", false);
                srTestRetry.Write("false");
                srTestRetry.Close();
            }
        }
    }
}
