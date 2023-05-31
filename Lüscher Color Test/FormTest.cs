using System;
using System.CodeDom.Compiler;
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

        List<string> COLORS = new List<string>();

        string[] colorsSTAGE1;

        //for ResultStage
        string[] tonesNames = { "Bright", "Dim" };
        string[] counterNames = { "Black", "Gray", "Brown", "Blue", "Green", "Red", "Purple", "Yellow" };
        int[] colorCounters = new int[8];
        int[] toneCounters = new int[2];

        //for ResultsStage
        string[] BRIGHTcolors;
        string[] DIMcolors;
        string[] BLACKcolors;
        string[] GRAYcolors;
        string[] BROWNcolors;
        string[] BLUEcolors;
        string[] GREENcolors;
        string[] REDcolors;
        string[] PURPLEcolors;
        string[] YELLOWcolors;

        string FAVOURITEcolor_1;
        string FAVOURITEcolor_2;
        string FAVOURITEtone;

        bool ClosedCorreclty = true;


        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// </summary>



        private void IsTestRetry()
        {
            StreamReader srTestRetry = new StreamReader("TextFiles\\TestRetryState.txt");
            string s = srTestRetry.ReadToEnd();
            if (s == "true")
            {
                StreamWriter srClosedCorrectly = new StreamWriter("TextFiles\\ClosedCorrectly.txt", false);
                srClosedCorrectly.Write("false");
                srClosedCorrectly.Close();
                Stage1();
            }
            srTestRetry.Close();
        }

        private void IsClosedCorrectly()
        {
            StreamReader srTestRetry = new StreamReader("TextFiles\\ClosedCorrectly.txt", false);
            string s = srTestRetry.ReadToEnd();
            if (s == "false")
            {
                ClosedCorreclty = false;
            }
            srTestRetry.Close();
        }

        private void ButtonsColorsStage1()
        {
            StreamReader sr = new StreamReader("TextFiles\\LCTcolors1.txt");
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
            StreamReader sr = new StreamReader("TextFiles\\LCTcolors2.txt");
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

            loadingTIMER.Interval = rnd.Next(3, 9) * 1000;
            loadingTIMER.Tick += new EventHandler(timer_tick);
        }

        void timer_tick(object sender, EventArgs e)
        {
            (sender as Timer).Enabled = false;

            StreamWriter fwr = new StreamWriter("TEST123");
            for (int i = 0; i < COLORS.Count; i++)
            {
                fwr.Write(COLORS[i] + " ");
            }
            fwr.Close();
            ResultsStage();
        }

        private string ColorToString(string x)
        {
            char[] chars = { '[', ']' };
            string[] ss = x.Split();
            string result = ss[1].Trim(chars);
            return result;
        }


        public void ResultsStage() //исправить во что-то пограмотнее!!
        {
            StreamReader resSTR = new StreamReader("TextFiles\\ResultColorGroups.txt");
            string s = "";
            while (!resSTR.EndOfStream)
            {
                s = resSTR.ReadLine();

                if (s.Contains("BRIGHT"))
                {
                    BRIGHTcolors = s.Split();
                }
                if (s.Contains("DIM"))
                {
                    DIMcolors = s.Split();
                }
                if (s.Contains("0"))
                {
                    BLACKcolors = s.Split();
                }
                if (s.Contains("1"))
                {
                    GRAYcolors = s.Split();
                }
                if (s.Contains("2"))
                {
                    BROWNcolors = s.Split();
                }
                if (s.Contains("3"))
                {
                    BLUEcolors = s.Split();
                }
                if (s.Contains("4"))
                {
                    GREENcolors = s.Split();
                }
                if (s.Contains("5"))
                {
                    REDcolors = s.Split();
                }
                if (s.Contains("6"))
                {
                    PURPLEcolors = s.Split();
                }
                if (s.Contains("7"))
                {
                    YELLOWcolors = s.Split();
                }
            }

            resSTR.Close();

            ///////////////////////////////////////////////////////////////////////

            int temp = 8;

            for (int i = 0; i < COLORS.Count; i++)
            {
                if(temp == 0)
                {
                    temp = 8;
                }

                if (BRIGHTcolors.Contains(COLORS[i]))
                {
                    toneCounters[0]++;
                }
                if (DIMcolors.Contains(COLORS[i]))
                {
                    toneCounters[1]++;
                }
                if (BLACKcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[0]++;
                    }
                    else
                    {
                        colorCounters[0] += temp;
                        temp--;
                    }
                }
                if (GRAYcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[1]++;
                    }
                    else
                    {
                        colorCounters[1] += temp;
                        temp--;
                    }
                }
                if (BROWNcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[2]++;
                    }
                    else
                    {
                        colorCounters[2] += temp;
                        temp--;
                    }
                }
                if (BLUEcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[3]++;
                    }
                    else
                    {
                        colorCounters[3] += temp;
                        temp--;
                    }
                }
                if (GREENcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[4]++;
                    }
                    else
                    {
                        colorCounters[4] += temp;
                        temp--;
                    }
                }
                if (REDcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[5]++;
                    }
                    else
                    {
                        colorCounters[5] += temp;
                        temp--;
                    }
                }
                if (PURPLEcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[6]++;
                    }
                    else
                    {
                        colorCounters[6] += temp;
                        temp--;
                    }
                }
                if (YELLOWcolors.Contains(COLORS[i]))
                {
                    if (i < 32)
                    {
                        colorCounters[7]++;
                    }
                    else
                    {
                        colorCounters[7] += temp;
                        temp--;
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////

            int maxColorIndex1 = 0;
            int maxColorIndex2 = 0;
            int maxToneIndex = 0;
            if (toneCounters[1] > toneCounters[0])
            {
                maxToneIndex = 1;
            }
            for (int i = 1; i < colorCounters.Length; i++)
            {
                if (colorCounters[i] >= colorCounters[i - 1])
                {
                    maxColorIndex1 = i;
                }
            }
            for (int i = 1; i < colorCounters.Length; i++)
            {
                if (colorCounters[i] > colorCounters[i - 1] && i != maxColorIndex1)
                {
                    maxColorIndex2 = i;
                }
            }


            FAVOURITEcolor_1 = counterNames[maxColorIndex1];
            FAVOURITEcolor_2 = counterNames[maxColorIndex2];
            FAVOURITEtone = tonesNames[maxToneIndex];

            ShowResults();
        }

        private void ShowResults()
        {
            this.Controls.Clear();

            Label ResultHeader = new Label();
            ResultHeader.Size = new Size(720, 40);
            ResultHeader.Location = new Point(240, 0);
            ResultHeader.Text = "Тест пройден! Ознакомьтесь с результатом.";
            ResultHeader.TextAlign = ContentAlignment.MiddleCenter;
            ResultHeader.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            this.Controls.Add(ResultHeader);

            Label ResultColor_1 = new Label();
            ResultColor_1.Location = new Point(15, 90);
            ResultColor_1.Size = new Size(1150, 180);
            ResultColor_1.TextAlign = ContentAlignment.TopLeft;
            ResultColor_1.Font = new Font("Times New Roman", 14, FontStyle.Italic);
            ResultColor_1.BorderStyle = BorderStyle.FixedSingle;
            ResultColor_1.Text = "";
            this.Controls.Add(ResultColor_1);

            Label ResultColor_2 = new Label();
            ResultColor_2.Location = new Point(15, 310);
            ResultColor_2.Size = new Size(1150, 180);
            ResultColor_2.TextAlign = ContentAlignment.TopLeft;
            ResultColor_2.Font = new Font("Times New Roman", 14, FontStyle.Italic);
            ResultColor_2.BorderStyle = BorderStyle.FixedSingle;
            ResultColor_2.Text = "";
            this.Controls.Add(ResultColor_2);

            StreamReader sr1 = new StreamReader("ResultsFiles\\" + FAVOURITEcolor_1 + "Result.txt");
            string s1 = "";
            while (!sr1.EndOfStream)
            {
                for (int i = 0; i < 3; i++)
                {
                    s1 = sr1.ReadLine();
                    ResultColor_1.Text += s1 + "\n\n";
                }
            }
            sr1.Close();

            StreamReader sr2 = new StreamReader("ResultsFiles\\" + FAVOURITEcolor_2 + "Result.txt");
            string s2 = "";
            while (!sr2.EndOfStream)
            {
                for (int i = 0; i < 3; i++)
                {
                    s2 = sr2.ReadLine();
                    ResultColor_2.Text += s2 + "\n\n";
                }
            }
            sr2.Close();
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
            COLORS.Add(colorsSTAGE1[0]);
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
            COLORS.Add(colorsSTAGE1[1]);
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
            COLORS.Add(ColorToString((sender as Button).BackColor.ToString()));
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
                        StreamWriter srTestRetry = new StreamWriter("TextFiles\\TestRetryState.txt", false);
                        srTestRetry.Write("false");
                        srTestRetry.Close();
                        LoadingScreen();
                    }
                    else
                    {
                        StreamWriter srTestRetry = new StreamWriter("TextFiles\\TestRetryState.txt", false);
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
                StreamWriter srTestRetry = new StreamWriter("TextFiles\\TestRetryState.txt", false);
                srTestRetry.Write("false");
                srTestRetry.Close();
            }
        }
    }
}