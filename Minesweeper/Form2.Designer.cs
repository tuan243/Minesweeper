namespace Minesweeper
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.beginnerRdBtn = new System.Windows.Forms.RadioButton();
            this.intermediateRdBtn = new System.Windows.Forms.RadioButton();
            this.advancedRdBtn = new System.Windows.Forms.RadioButton();
            this.customRdBtn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Height (9-24):";
            // 
            // beginnerRdBtn
            // 
            this.beginnerRdBtn.AutoSize = true;
            this.beginnerRdBtn.Location = new System.Drawing.Point(35, 33);
            this.beginnerRdBtn.Name = "beginnerRdBtn";
            this.beginnerRdBtn.Size = new System.Drawing.Size(84, 43);
            this.beginnerRdBtn.TabIndex = 1;
            this.beginnerRdBtn.TabStop = true;
            this.beginnerRdBtn.Text = "Beginner\r\n10 mines\r\n9 x 9 tile grid";
            this.beginnerRdBtn.UseVisualStyleBackColor = true;
            // 
            // intermediateRdBtn
            // 
            this.intermediateRdBtn.AutoSize = true;
            this.intermediateRdBtn.Location = new System.Drawing.Point(35, 91);
            this.intermediateRdBtn.Name = "intermediateRdBtn";
            this.intermediateRdBtn.Size = new System.Drawing.Size(96, 43);
            this.intermediateRdBtn.TabIndex = 2;
            this.intermediateRdBtn.TabStop = true;
            this.intermediateRdBtn.Text = "Intermediate\r\n40 mines\r\n16 x 16 tile grid";
            this.intermediateRdBtn.UseVisualStyleBackColor = true;
            // 
            // advancedRdBtn
            // 
            this.advancedRdBtn.AutoSize = true;
            this.advancedRdBtn.Location = new System.Drawing.Point(35, 151);
            this.advancedRdBtn.Name = "advancedRdBtn";
            this.advancedRdBtn.Size = new System.Drawing.Size(96, 43);
            this.advancedRdBtn.TabIndex = 3;
            this.advancedRdBtn.TabStop = true;
            this.advancedRdBtn.Text = "Advanced\r\n99 mines\r\n16 x 30 tile grid";
            this.advancedRdBtn.UseVisualStyleBackColor = true;
            // 
            // customRdBtn
            // 
            this.customRdBtn.AutoSize = true;
            this.customRdBtn.Location = new System.Drawing.Point(179, 46);
            this.customRdBtn.Name = "customRdBtn";
            this.customRdBtn.Size = new System.Drawing.Size(60, 17);
            this.customRdBtn.TabIndex = 4;
            this.customRdBtn.TabStop = true;
            this.customRdBtn.Text = "Custom";
            this.customRdBtn.UseVisualStyleBackColor = true;
            this.customRdBtn.CheckedChanged += new System.EventHandler(this.customRdBtn_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Width (9-30):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mines (10-668):";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(271, 73);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(271, 103);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(271, 133);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            668,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown3.TabIndex = 5;
            this.numericUpDown3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(179, 233);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(261, 232);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 274);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.customRdBtn);
            this.Controls.Add(this.advancedRdBtn);
            this.Controls.Add(this.intermediateRdBtn);
            this.Controls.Add(this.beginnerRdBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton beginnerRdBtn;
        private System.Windows.Forms.RadioButton intermediateRdBtn;
        private System.Windows.Forms.RadioButton advancedRdBtn;
        private System.Windows.Forms.RadioButton customRdBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}