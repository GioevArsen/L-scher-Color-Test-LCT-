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
    public partial class FormStage2 : Form
    {

        int Stage2Level = 1;
        private void ButtonsColors()
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

            //исправить этот позор!
            buttonCard1.BackColor = Color.FromName(colors[0]);
            buttonCard2.BackColor = Color.FromName(colors[1]);
            buttonCard3.BackColor = Color.FromName(colors[2]);
            buttonCard4.BackColor = Color.FromName(colors[3]);
            buttonCard5.BackColor = Color.FromName(colors[4]);
            buttonCard6.BackColor = Color.FromName(colors[5]);
            buttonCard7.BackColor = Color.FromName(colors[6]);
            buttonCard8.BackColor = Color.FromName(colors[7]);

            sr.Close();
        }


        private void AnyButton_Click(object sender, EventArgs e)
        {
            //(sender as Button).BackColor = Color.White;
            //(sender as Button).Text = "X";
            //(sender as Button).Enabled = false;
            (sender as Button).Dispose();
        }

        public FormStage2()
        {
            InitializeComponent();
            ButtonsColors();
        }

    }
}
