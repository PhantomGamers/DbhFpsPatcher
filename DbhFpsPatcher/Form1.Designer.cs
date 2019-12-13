namespace DbhFpsPatcher
{
    partial class Form1
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.GameExecutableLabel = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PatchButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.Label();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PatchWorker = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(23, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(300, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Detroit Become Human Fps Patcher by PhantomGamers";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(42, 22);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(130, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Change the max FPS limit!";
            // 
            // GameExecutableLabel
            // 
            this.GameExecutableLabel.AutoSize = true;
            this.GameExecutableLabel.Location = new System.Drawing.Point(23, 50);
            this.GameExecutableLabel.Name = "GameExecutableLabel";
            this.GameExecutableLabel.Size = new System.Drawing.Size(94, 13);
            this.GameExecutableLabel.TabIndex = 2;
            this.GameExecutableLabel.Text = "Game Executable:";
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(123, 47);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(172, 20);
            this.PathBox.TabIndex = 3;
            this.PathBox.TextChanged += new System.EventHandler(this.PathBox_TextChanged);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(301, 44);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PatchButton
            // 
            this.PatchButton.Enabled = false;
            this.PatchButton.Location = new System.Drawing.Point(382, 44);
            this.PatchButton.Name = "PatchButton";
            this.PatchButton.Size = new System.Drawing.Size(75, 23);
            this.PatchButton.TabIndex = 5;
            this.PatchButton.Text = "Patch";
            this.PatchButton.UseVisualStyleBackColor = true;
            this.PatchButton.Click += new System.EventHandler(this.PatchButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatusLabel.Location = new System.Drawing.Point(18, 97);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Status:";
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.ForeColor = System.Drawing.Color.Blue;
            this.StatusText.Location = new System.Drawing.Point(65, 97);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(52, 13);
            this.StatusText.TabIndex = 7;
            this.StatusText.Text = "Waiting...";
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Location = new System.Drawing.Point(24, 75);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(93, 13);
            this.FPSLabel.TabIndex = 8;
            this.FPSLabel.Text = "Desired FPS Limit:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 133);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(426, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 10;
            // 
            // PatchWorker
            // 
            this.PatchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PatchWorker_DoWork);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(123, 73);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Set to 0 for no limit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.FPSLabel);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PatchButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.GameExecutableLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Form1";
            this.Text = "Generic Fps Patcher";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label GameExecutableLabel;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button PatchButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker PatchWorker;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}

