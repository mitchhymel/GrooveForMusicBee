namespace GrooveForMusicBee
{
    partial class SyncProgressWindow
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
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.PreparationProgressBar = new System.Windows.Forms.ProgressBar();
            this.PreparationLabel = new System.Windows.Forms.Label();
            this.SyncProgressLabel = new System.Windows.Forms.Label();
            this.ProgressGroupBox = new System.Windows.Forms.GroupBox();
            this.SyncProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(18, 163);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(947, 685);
            this.OutputTextBox.TabIndex = 0;
            this.OutputTextBox.Text = "";
            this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // PreparationProgressBar
            // 
            this.PreparationProgressBar.Location = new System.Drawing.Point(11, 55);
            this.PreparationProgressBar.Name = "PreparationProgressBar";
            this.PreparationProgressBar.Size = new System.Drawing.Size(930, 23);
            this.PreparationProgressBar.TabIndex = 1;
            // 
            // PreparationLabel
            // 
            this.PreparationLabel.AutoSize = true;
            this.PreparationLabel.Location = new System.Drawing.Point(6, 27);
            this.PreparationLabel.Name = "PreparationLabel";
            this.PreparationLabel.Size = new System.Drawing.Size(215, 25);
            this.PreparationLabel.TabIndex = 3;
            this.PreparationLabel.Text = "Preparation Progress";
            // 
            // SyncProgressLabel
            // 
            this.SyncProgressLabel.AutoSize = true;
            this.SyncProgressLabel.Location = new System.Drawing.Point(6, 81);
            this.SyncProgressLabel.Name = "SyncProgressLabel";
            this.SyncProgressLabel.Size = new System.Drawing.Size(152, 25);
            this.SyncProgressLabel.TabIndex = 4;
            this.SyncProgressLabel.Text = "Sync Progress";
            // 
            // ProgressGroupBox
            // 
            this.ProgressGroupBox.Controls.Add(this.SyncProgressBar);
            this.ProgressGroupBox.Controls.Add(this.PreparationLabel);
            this.ProgressGroupBox.Controls.Add(this.SyncProgressLabel);
            this.ProgressGroupBox.Controls.Add(this.PreparationProgressBar);
            this.ProgressGroupBox.Location = new System.Drawing.Point(18, 13);
            this.ProgressGroupBox.Name = "ProgressGroupBox";
            this.ProgressGroupBox.Size = new System.Drawing.Size(947, 144);
            this.ProgressGroupBox.TabIndex = 5;
            this.ProgressGroupBox.TabStop = false;
            // 
            // SyncProgressBar
            // 
            this.SyncProgressBar.Location = new System.Drawing.Point(7, 110);
            this.SyncProgressBar.Name = "SyncProgressBar";
            this.SyncProgressBar.Size = new System.Drawing.Size(934, 23);
            this.SyncProgressBar.TabIndex = 5;
            // 
            // SyncProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 860);
            this.Controls.Add(this.ProgressGroupBox);
            this.Controls.Add(this.OutputTextBox);
            this.Name = "SyncProgressWindow";
            this.Text = "SyncProgressWindow";
            this.ProgressGroupBox.ResumeLayout(false);
            this.ProgressGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.ProgressBar PreparationProgressBar;
        private System.Windows.Forms.Label PreparationLabel;
        private System.Windows.Forms.Label SyncProgressLabel;
        private System.Windows.Forms.GroupBox ProgressGroupBox;
        private System.Windows.Forms.ProgressBar SyncProgressBar;
    }
}