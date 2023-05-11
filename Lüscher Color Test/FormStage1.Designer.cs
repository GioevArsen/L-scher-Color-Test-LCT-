namespace Lüscher_Color_Test
{
    partial class FormStage1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelStage1 = new System.Windows.Forms.Label();
            this.buttonCard1 = new System.Windows.Forms.Button();
            this.buttonCard2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStage1
            // 
            this.labelStage1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStage1.Location = new System.Drawing.Point(240, 55);
            this.labelStage1.Name = "labelStage1";
            this.labelStage1.Size = new System.Drawing.Size(720, 40);
            this.labelStage1.TabIndex = 0;
            this.labelStage1.Text = "Этап 1.  Выберите наиболее привлекательный Вам цвет.";
            this.labelStage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCard1
            // 
            this.buttonCard1.Location = new System.Drawing.Point(350, 150);
            this.buttonCard1.Name = "buttonCard1";
            this.buttonCard1.Size = new System.Drawing.Size(150, 200);
            this.buttonCard1.TabIndex = 1;
            this.buttonCard1.UseVisualStyleBackColor = true;
            this.buttonCard1.Click += new System.EventHandler(this.buttonCard1_Click);
            // 
            // buttonCard2
            // 
            this.buttonCard2.Location = new System.Drawing.Point(650, 150);
            this.buttonCard2.Name = "buttonCard2";
            this.buttonCard2.Size = new System.Drawing.Size(150, 200);
            this.buttonCard2.TabIndex = 2;
            this.buttonCard2.UseVisualStyleBackColor = true;
            this.buttonCard2.Click += new System.EventHandler(this.buttonCard2_Click);
            // 
            // FormStage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCard2);
            this.Controls.Add(this.buttonCard1);
            this.Controls.Add(this.labelStage1);
            this.MaximizeBox = false;
            this.Name = "FormStage1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lüscher Color Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelStage1;
        private System.Windows.Forms.Button buttonCard1;
        private System.Windows.Forms.Button buttonCard2;
    }
}