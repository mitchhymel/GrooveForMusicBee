namespace GrooveForMusicBee
{
    partial class SyncPlaylistsWindow
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.SyncGroupBox = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ToGrooveRadioButton = new System.Windows.Forms.RadioButton();
            this.FromGrooveRadioButton = new System.Windows.Forms.RadioButton();
            this.SyncButton = new System.Windows.Forms.Button();
            this.RadioButtonGroupBox = new System.Windows.Forms.GroupBox();
            this.LocalPlaylistListBox = new System.Windows.Forms.ListBox();
            this.LocalPlaylistsLabel = new System.Windows.Forms.Label();
            this.GroovePlaylistListBox = new System.Windows.Forms.ListBox();
            this.GroovePlaylistsLabel = new System.Windows.Forms.Label();
            this.LocalPlaylistCheckBox = new System.Windows.Forms.CheckBox();
            this.GroovePlaylistCheckBox = new System.Windows.Forms.CheckBox();
            this.SyncGroupBox.SuspendLayout();
            this.RadioButtonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(13, 13);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(172, 72);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.OutputTextBox.Location = new System.Drawing.Point(192, 13);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(928, 72);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.Text = "Please Log in";
            // 
            // SyncGroupBox
            // 
            this.SyncGroupBox.Controls.Add(this.GroovePlaylistCheckBox);
            this.SyncGroupBox.Controls.Add(this.LocalPlaylistCheckBox);
            this.SyncGroupBox.Controls.Add(this.GroovePlaylistsLabel);
            this.SyncGroupBox.Controls.Add(this.GroovePlaylistListBox);
            this.SyncGroupBox.Controls.Add(this.LocalPlaylistsLabel);
            this.SyncGroupBox.Controls.Add(this.LocalPlaylistListBox);
            this.SyncGroupBox.Location = new System.Drawing.Point(13, 92);
            this.SyncGroupBox.Name = "SyncGroupBox";
            this.SyncGroupBox.Size = new System.Drawing.Size(1107, 917);
            this.SyncGroupBox.TabIndex = 2;
            this.SyncGroupBox.TabStop = false;
            this.SyncGroupBox.Text = "Set up sync";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 1081);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1107, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // ToGrooveRadioButton
            // 
            this.ToGrooveRadioButton.AutoSize = true;
            this.ToGrooveRadioButton.Checked = true;
            this.ToGrooveRadioButton.Location = new System.Drawing.Point(179, 14);
            this.ToGrooveRadioButton.Name = "ToGrooveRadioButton";
            this.ToGrooveRadioButton.Size = new System.Drawing.Size(169, 29);
            this.ToGrooveRadioButton.TabIndex = 4;
            this.ToGrooveRadioButton.TabStop = true;
            this.ToGrooveRadioButton.Text = "-> To Groove";
            this.ToGrooveRadioButton.UseVisualStyleBackColor = true;
            // 
            // FromGrooveRadioButton
            // 
            this.FromGrooveRadioButton.AutoSize = true;
            this.FromGrooveRadioButton.Location = new System.Drawing.Point(370, 14);
            this.FromGrooveRadioButton.Name = "FromGrooveRadioButton";
            this.FromGrooveRadioButton.Size = new System.Drawing.Size(193, 29);
            this.FromGrooveRadioButton.TabIndex = 5;
            this.FromGrooveRadioButton.TabStop = true;
            this.FromGrooveRadioButton.Text = "<- From Groove";
            this.FromGrooveRadioButton.UseVisualStyleBackColor = true;
            // 
            // SyncButton
            // 
            this.SyncButton.Enabled = false;
            this.SyncButton.Location = new System.Drawing.Point(852, 1015);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(267, 58);
            this.SyncButton.TabIndex = 6;
            this.SyncButton.Text = "Sync";
            this.SyncButton.UseVisualStyleBackColor = true;
            // 
            // RadioButtonGroupBox
            // 
            this.RadioButtonGroupBox.Controls.Add(this.ToGrooveRadioButton);
            this.RadioButtonGroupBox.Controls.Add(this.FromGrooveRadioButton);
            this.RadioButtonGroupBox.Location = new System.Drawing.Point(13, 1016);
            this.RadioButtonGroupBox.Name = "RadioButtonGroupBox";
            this.RadioButtonGroupBox.Size = new System.Drawing.Size(833, 57);
            this.RadioButtonGroupBox.TabIndex = 7;
            this.RadioButtonGroupBox.TabStop = false;
            this.RadioButtonGroupBox.Text = "Sync Direction";
            // 
            // LocalPlaylistListBox
            // 
            this.LocalPlaylistListBox.FormattingEnabled = true;
            this.LocalPlaylistListBox.ItemHeight = 25;
            this.LocalPlaylistListBox.Location = new System.Drawing.Point(7, 78);
            this.LocalPlaylistListBox.Name = "LocalPlaylistListBox";
            this.LocalPlaylistListBox.Size = new System.Drawing.Size(535, 829);
            this.LocalPlaylistListBox.TabIndex = 0;
            // 
            // LocalPlaylistsLabel
            // 
            this.LocalPlaylistsLabel.AutoSize = true;
            this.LocalPlaylistsLabel.Location = new System.Drawing.Point(6, 50);
            this.LocalPlaylistsLabel.Name = "LocalPlaylistsLabel";
            this.LocalPlaylistsLabel.Size = new System.Drawing.Size(148, 25);
            this.LocalPlaylistsLabel.TabIndex = 1;
            this.LocalPlaylistsLabel.Text = "Local playlists";
            // 
            // GroovePlaylistListBox
            // 
            this.GroovePlaylistListBox.FormattingEnabled = true;
            this.GroovePlaylistListBox.ItemHeight = 25;
            this.GroovePlaylistListBox.Location = new System.Drawing.Point(566, 78);
            this.GroovePlaylistListBox.Name = "GroovePlaylistListBox";
            this.GroovePlaylistListBox.Size = new System.Drawing.Size(535, 829);
            this.GroovePlaylistListBox.TabIndex = 2;
            // 
            // GroovePlaylistsLabel
            // 
            this.GroovePlaylistsLabel.AutoSize = true;
            this.GroovePlaylistsLabel.Location = new System.Drawing.Point(566, 50);
            this.GroovePlaylistsLabel.Name = "GroovePlaylistsLabel";
            this.GroovePlaylistsLabel.Size = new System.Drawing.Size(168, 25);
            this.GroovePlaylistsLabel.TabIndex = 3;
            this.GroovePlaylistsLabel.Text = "Groove Playlists";
            // 
            // LocalPlaylistCheckBox
            // 
            this.LocalPlaylistCheckBox.AutoSize = true;
            this.LocalPlaylistCheckBox.Location = new System.Drawing.Point(408, 43);
            this.LocalPlaylistCheckBox.Name = "LocalPlaylistCheckBox";
            this.LocalPlaylistCheckBox.Size = new System.Drawing.Size(134, 29);
            this.LocalPlaylistCheckBox.TabIndex = 4;
            this.LocalPlaylistCheckBox.Text = "Select All";
            this.LocalPlaylistCheckBox.UseVisualStyleBackColor = true;
            // 
            // GroovePlaylistCheckBox
            // 
            this.GroovePlaylistCheckBox.AutoSize = true;
            this.GroovePlaylistCheckBox.Location = new System.Drawing.Point(967, 43);
            this.GroovePlaylistCheckBox.Name = "GroovePlaylistCheckBox";
            this.GroovePlaylistCheckBox.Size = new System.Drawing.Size(134, 29);
            this.GroovePlaylistCheckBox.TabIndex = 5;
            this.GroovePlaylistCheckBox.Text = "Select All";
            this.GroovePlaylistCheckBox.UseVisualStyleBackColor = true;
            // 
            // SyncPlaylistsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 1116);
            this.Controls.Add(this.RadioButtonGroupBox);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.SyncGroupBox);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.LoginButton);
            this.Name = "SyncPlaylistsWindow";
            this.Text = "SyncPlaylistsWindow";
            this.SyncGroupBox.ResumeLayout(false);
            this.SyncGroupBox.PerformLayout();
            this.RadioButtonGroupBox.ResumeLayout(false);
            this.RadioButtonGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.GroupBox SyncGroupBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton ToGrooveRadioButton;
        private System.Windows.Forms.RadioButton FromGrooveRadioButton;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.GroupBox RadioButtonGroupBox;
        private System.Windows.Forms.Label LocalPlaylistsLabel;
        private System.Windows.Forms.ListBox LocalPlaylistListBox;
        private System.Windows.Forms.ListBox GroovePlaylistListBox;
        private System.Windows.Forms.Label GroovePlaylistsLabel;
        private System.Windows.Forms.CheckBox LocalPlaylistCheckBox;
        private System.Windows.Forms.CheckBox GroovePlaylistCheckBox;
    }
}