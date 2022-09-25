
namespace GraphicsLab1
{
    partial class Form1
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
            this.selectedFigure = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.figureForm = new System.Windows.Forms.ListBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.blinking = new System.Windows.Forms.Button();
            this.floating_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFigure)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedFigure
            // 
            this.selectedFigure.BackColor = System.Drawing.Color.White;
            this.selectedFigure.Location = new System.Drawing.Point(225, 0);
            this.selectedFigure.Name = "selectedFigure";
            this.selectedFigure.Size = new System.Drawing.Size(675, 500);
            this.selectedFigure.TabIndex = 0;
            this.selectedFigure.TabStop = false;
            this.selectedFigure.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // figureForm
            // 
            this.figureForm.FormattingEnabled = true;
            this.figureForm.Items.AddRange(new object[] {
            "Traiangle",
            "Square",
            "Circle"});
            this.figureForm.Location = new System.Drawing.Point(16, 21);
            this.figureForm.Name = "figureForm";
            this.figureForm.Size = new System.Drawing.Size(192, 43);
            this.figureForm.TabIndex = 2;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(16, 70);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(192, 59);
            this.drawButton.TabIndex = 10;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // blinking
            // 
            this.blinking.Location = new System.Drawing.Point(16, 135);
            this.blinking.Name = "blinking";
            this.blinking.Size = new System.Drawing.Size(192, 59);
            this.blinking.TabIndex = 11;
            this.blinking.Text = "Blinking";
            this.blinking.UseVisualStyleBackColor = true;
            this.blinking.Click += new System.EventHandler(this.button2_Click);
            // 
            // floating_button
            // 
            this.floating_button.Location = new System.Drawing.Point(16, 200);
            this.floating_button.Name = "floating_button";
            this.floating_button.Size = new System.Drawing.Size(192, 53);
            this.floating_button.TabIndex = 12;
            this.floating_button.Text = "Floating";
            this.floating_button.UseVisualStyleBackColor = true;
            this.floating_button.Click += new System.EventHandler(this.floating_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 500);
            this.Controls.Add(this.floating_button);
            this.Controls.Add(this.blinking);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.figureForm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedFigure);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectedFigure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox selectedFigure;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox figureForm;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button blinking;
        private System.Windows.Forms.Button floating_button;
    }
}

