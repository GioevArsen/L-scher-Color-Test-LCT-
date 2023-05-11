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

namespace Lüscher_Color_Test
{
    public partial class FormStage1 : Form
    {

        int Stage1Level = 1;

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

            buttonCard1.BackColor = Color.FromName(color1);
            buttonCard2.BackColor = Color.FromName(color2);

            sr.Close();
        }

        public FormStage1()
        {
            InitializeComponent();
            ButtonsColors();
        }

        private void buttonCard1_Click(object sender, EventArgs e)
        {
            Stage1Level++;
            ButtonsColors();
            if(Stage1Level > 32)
            {
                this.Close();
            }
        }

        private void buttonCard2_Click(object sender, EventArgs e)
        {
            Stage1Level++;
            ButtonsColors();
            if (Stage1Level > 32)
            {
                this.Close();
            }
        }
    }
}
