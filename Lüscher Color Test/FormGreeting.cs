using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lüscher_Color_Test
{
    public partial class FormGreeting : System.Windows.Forms.Form
    {

        int Stage1Level = 1;
        int Stage2Level = 1;

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

        private void ButtonsColorsStage1()
        {
            StreamReader sr = new StreamReader("LCTcolors1.txt");
            string s = "";
            string color1, color2;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                if (s.Contains(Stage1Level.ToString()))
                {
                    break;
                }
            }
            string[] words = s.Split(' ');
            color1 = words[1];
            color2 = words[2];

            ButtonCard1_1.BackColor = Color.FromName(color1);
            ButtonCard1_2.BackColor = Color.FromName(color2);

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
            string[] words = s.Split(' ');
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
            ButtonCard1_2.Location = new Point(650, 150);
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
        
        
        public FormGreeting()
        {
            InitializeComponent();
        }

        private void buttonStartLCT_Click(object sender, EventArgs e)
        {
            Stage1();
        }

        private void ButtonCard1_1_Click(object sender, EventArgs e)
        {
            Stage1Level++;
            ButtonsColorsStage1();
            if (Stage1Level > 32)
            {
                ButtonCard1_1.Dispose();
                ButtonCard1_2.Dispose();
                Stage1Header.Dispose();
                Stage2();
            }
        }

        private void ButtonCard1_2_Click(object sender, EventArgs e)
        {
            Stage1Level++;
            ButtonsColorsStage1();
            if (Stage1Level > 32)
            {
                ButtonCard1_1.Dispose();
                ButtonCard1_2.Dispose();
                Stage1Header.Dispose();
                Stage2();
            }
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Dispose();
        }

        private void FormGreeting_Load(object sender, EventArgs e)
        {

        }
    }
}
