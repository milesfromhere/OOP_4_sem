namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lengthTextBox = new TextBox();
            calculateButton = new Button();
            resultLabel = new Label();
            widthTextBox = new TextBox();
            lengthLabel = new Label();
            widthLabel = new Label();
            result = new Label();
            SuspendLayout();
            // 
            // lengthTextBox
            // 
            lengthTextBox.Location = new Point(152, 20);
            lengthTextBox.Name = "lengthTextBox";
            lengthTextBox.Size = new Size(277, 27);
            lengthTextBox.TabIndex = 2;
            lengthTextBox.TextChanged += lengthTextBox_TextChanged;
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(152, 103);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(277, 30);
            calculateButton.TabIndex = 4;
            calculateButton.Text = "Рассчитать";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += CalculateButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(101, 146);
            resultLabel.MaximumSize = new Size(500, 0);
            resultLabel.MinimumSize = new Size(100, 0);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(100, 20);
            resultLabel.TabIndex = 5;
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new Point(152, 60);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new Size(277, 27);
            widthTextBox.TabIndex = 3;
            // 
            // lengthLabel
            // 
            lengthLabel.AutoSize = true;
            lengthLabel.Location = new Point(12, 20);
            lengthLabel.Name = "lengthLabel";
            lengthLabel.Size = new Size(115, 20);
            lengthLabel.TabIndex = 0;
            lengthLabel.Text = "Длина (метры):";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Location = new Point(12, 60);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(129, 20);
            widthLabel.TabIndex = 1;
            widthLabel.Text = "Ширина (метры):";
            // 
            // result
            // 
            result.AutoSize = true;
            result.Location = new Point(12, 146);
            result.Name = "result";
            result.Size = new Size(78, 20);
            result.TabIndex = 6;
            result.Text = "Результат:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 301);
            Controls.Add(result);
            Controls.Add(widthLabel);
            Controls.Add(lengthLabel);
            Controls.Add(widthTextBox);
            Controls.Add(resultLabel);
            Controls.Add(calculateButton);
            Controls.Add(lengthTextBox);
            Name = "Form1";
            Text = "Калькулятор стройматериалов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lengthTextBox;
        private Button calculateButton;
        private Label resultLabel;
        private TextBox widthTextBox;
        private Label lengthLabel;
        private Label widthLabel;
        private Label result;
    }
}