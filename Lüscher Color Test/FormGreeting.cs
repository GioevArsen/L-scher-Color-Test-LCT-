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
        Button ButtonCard1 = new Button();
        Button ButtonCard2 = new Button();

        private void ButtonsColors()
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

            ButtonCard1.BackColor = Color.FromName(color1);
            ButtonCard2.BackColor = Color.FromName(color2);

            sr.Close();
        }

        private void Stage1()
        {
            int width = 150;
            int height = 200;
            Size Stage1Size = new Size(width, height);
            labelGreetingText.Dispose();
            labelExplanations.Dispose();
            buttonStartLCT.Dispose();

            ButtonCard1.Size = Stage1Size;
            ButtonCard1.Location = new Point(350, 150);
            ButtonCard1.Click += new EventHandler(ButtonCard1_Click);
            this.Controls.Add(ButtonCard1);

            ButtonCard2.Size = Stage1Size;
            ButtonCard2.Location = new Point(650, 150);
            ButtonCard2.Click += new EventHandler(ButtonCard2_Click);
            this.Controls.Add(ButtonCard2);

            ButtonsColors();
        }
        
        
        public FormGreeting()
        {
            InitializeComponent();
        }

        private void buttonStartLCT_Click(object sender, EventArgs e)
        {
            //this.Close();
            Stage1();
        }

        private void ButtonCard1_Click(object sender, EventArgs e)
        {
            Stage1Level++;
            ButtonsColors();
            if (Stage1Level > 32)
            {
                this.Close();
            }
        }

        private void ButtonCard2_Click(object sender, EventArgs e)
        {
            Stage1Level++;
            ButtonsColors();
            if (Stage1Level > 32)
            {
                this.Close();
            }
        }

        private void FormGreeting_Load(object sender, EventArgs e)
        {

        }
    }
}
