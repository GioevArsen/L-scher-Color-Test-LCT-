namespace Lüscher_Color_Test
{
    partial class FormTest
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.labelGreetingText = new System.Windows.Forms.Label();
            this.labelExplanations = new System.Windows.Forms.Label();
            this.buttonStartLCT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelGreetingText
            // 
            this.labelGreetingText.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGreetingText.Location = new System.Drawing.Point(270, 55);
            this.labelGreetingText.Name = "labelGreetingText";
            this.labelGreetingText.Size = new System.Drawing.Size(660, 40);
            this.labelGreetingText.TabIndex = 0;
            this.labelGreetingText.Text = "Добро пожаловать в цветовой тест Люшера!";
            // 
            // labelExplanations
            // 
            this.labelExplanations.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExplanations.Location = new System.Drawing.Point(12, 145);
            this.labelExplanations.Name = "labelExplanations";
            this.labelExplanations.Size = new System.Drawing.Size(1160, 196);
            this.labelExplanations.TabIndex = 1;
            this.labelExplanations.Text = resources.GetString("labelExplanations.Text");
            // 
            // buttonStartLCT
            // 
            this.buttonStartLCT.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartLCT.Location = new System.Drawing.Point(450, 420);
            this.buttonStartLCT.Name = "buttonStartLCT";
            this.buttonStartLCT.Size = new System.Drawing.Size(300, 50);
            this.buttonStartLCT.TabIndex = 2;
            this.buttonStartLCT.Text = "Начать тестирование";
            this.buttonStartLCT.UseVisualStyleBackColor = true;
            this.buttonStartLCT.Click += new System.EventHandler(this.buttonStartLCT_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 511);
            this.Controls.Add(this.buttonStartLCT);
            this.Controls.Add(this.labelExplanations);
            this.Controls.Add(this.labelGreetingText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lüscher Color Test";
            this.Load += new System.EventHandler(this.FormGreeting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelGreetingText;
        private System.Windows.Forms.Label labelExplanations;
        private System.Windows.Forms.Button buttonStartLCT;
    }
}

