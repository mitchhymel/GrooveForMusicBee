namespace GrooveApiSample
{
    partial class Sample
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
            this.GetTracksButton = new System.Windows.Forms.Button();
            this.TrackListBox = new System.Windows.Forms.ListBox();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputTextLabel = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TracksTabPage = new System.Windows.Forms.TabPage();
            this.GetAlbumsButton = new System.Windows.Forms.Button();
            this.GetStreamButton = new System.Windows.Forms.Button();
            this.PlaylistTabPage = new System.Windows.Forms.TabPage();
            this.PlaylistTrackListBox = new System.Windows.Forms.ListBox();
            this.GetPlaylistsButton = new System.Windows.Forms.Button();
            this.PlaylistListBox = new System.Windows.Forms.ListBox();
            this.ArtistArtPictureBox = new System.Windows.Forms.PictureBox();
            this.StreamTextBox = new System.Windows.Forms.RichTextBox();
            this.TabControl.SuspendLayout();
            this.TracksTabPage.SuspendLayout();
            this.PlaylistTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtistArtPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(13, 13);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(590, 52);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // GetTracksButton
            // 
            this.GetTracksButton.Enabled = false;
            this.GetTracksButton.Location = new System.Drawing.Point(6, 6);
            this.GetTracksButton.Name = "GetTracksButton";
            this.GetTracksButton.Size = new System.Drawing.Size(255, 91);
            this.GetTracksButton.TabIndex = 2;
            this.GetTracksButton.Text = "Get Tracks";
            this.GetTracksButton.UseVisualStyleBackColor = true;
            this.GetTracksButton.Click += new System.EventHandler(this.GetTracksButton_Click);
            // 
            // TrackListBox
            // 
            this.TrackListBox.DisplayMember = "Artists.First().Name";
            this.TrackListBox.FormattingEnabled = true;
            this.TrackListBox.ItemHeight = 25;
            this.TrackListBox.Location = new System.Drawing.Point(268, 6);
            this.TrackListBox.Name = "TrackListBox";
            this.TrackListBox.Size = new System.Drawing.Size(1304, 1279);
            this.TrackListBox.TabIndex = 4;
            this.TrackListBox.SelectedIndexChanged += new System.EventHandler(this.onSelectedItemChange);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.OutputTextBox.Location = new System.Drawing.Point(14, 99);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(589, 1264);
            this.OutputTextBox.TabIndex = 7;
            this.OutputTextBox.Text = "";
            this.OutputTextBox.WordWrap = false;
            // 
            // OutputTextLabel
            // 
            this.OutputTextLabel.AutoSize = true;
            this.OutputTextLabel.Location = new System.Drawing.Point(12, 68);
            this.OutputTextLabel.Name = "OutputTextLabel";
            this.OutputTextLabel.Size = new System.Drawing.Size(392, 25);
            this.OutputTextLabel.TabIndex = 8;
            this.OutputTextLabel.Text = "All output will be displayed in box below";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.PlaylistTabPage);
            this.TabControl.Controls.Add(this.TracksTabPage);
            this.TabControl.Location = new System.Drawing.Point(609, 13);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1594, 1350);
            this.TabControl.TabIndex = 9;
            // 
            // TracksTabPage
            // 
            this.TracksTabPage.Controls.Add(this.GetAlbumsButton);
            this.TracksTabPage.Controls.Add(this.GetStreamButton);
            this.TracksTabPage.Controls.Add(this.GetTracksButton);
            this.TracksTabPage.Controls.Add(this.TrackListBox);
            this.TracksTabPage.Location = new System.Drawing.Point(8, 39);
            this.TracksTabPage.Name = "TracksTabPage";
            this.TracksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TracksTabPage.Size = new System.Drawing.Size(1578, 1303);
            this.TracksTabPage.TabIndex = 0;
            this.TracksTabPage.Text = "Tracks";
            this.TracksTabPage.UseVisualStyleBackColor = true;
            // 
            // GetAlbumsButton
            // 
            this.GetAlbumsButton.Enabled = false;
            this.GetAlbumsButton.Location = new System.Drawing.Point(8, 199);
            this.GetAlbumsButton.Name = "GetAlbumsButton";
            this.GetAlbumsButton.Size = new System.Drawing.Size(254, 106);
            this.GetAlbumsButton.TabIndex = 10;
            this.GetAlbumsButton.Text = "Get Albums";
            this.GetAlbumsButton.UseVisualStyleBackColor = true;
            this.GetAlbumsButton.Click += new System.EventHandler(this.GetAlbumsButton_Click);
            // 
            // GetStreamButton
            // 
            this.GetStreamButton.Enabled = false;
            this.GetStreamButton.Location = new System.Drawing.Point(7, 103);
            this.GetStreamButton.Name = "GetStreamButton";
            this.GetStreamButton.Size = new System.Drawing.Size(255, 90);
            this.GetStreamButton.TabIndex = 9;
            this.GetStreamButton.Text = "Get Stream";
            this.GetStreamButton.UseVisualStyleBackColor = true;
            this.GetStreamButton.Click += new System.EventHandler(this.GetStreamButton_Click);
            // 
            // PlaylistTabPage
            // 
            this.PlaylistTabPage.Controls.Add(this.StreamTextBox);
            this.PlaylistTabPage.Controls.Add(this.ArtistArtPictureBox);
            this.PlaylistTabPage.Controls.Add(this.PlaylistTrackListBox);
            this.PlaylistTabPage.Controls.Add(this.GetPlaylistsButton);
            this.PlaylistTabPage.Controls.Add(this.PlaylistListBox);
            this.PlaylistTabPage.Location = new System.Drawing.Point(8, 39);
            this.PlaylistTabPage.Name = "PlaylistTabPage";
            this.PlaylistTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PlaylistTabPage.Size = new System.Drawing.Size(1578, 1303);
            this.PlaylistTabPage.TabIndex = 1;
            this.PlaylistTabPage.Text = "Playlists";
            this.PlaylistTabPage.UseVisualStyleBackColor = true;
            // 
            // PlaylistTrackListBox
            // 
            this.PlaylistTrackListBox.DisplayMember = "Artists.First().Name";
            this.PlaylistTrackListBox.FormattingEnabled = true;
            this.PlaylistTrackListBox.ItemHeight = 25;
            this.PlaylistTrackListBox.Location = new System.Drawing.Point(6, 484);
            this.PlaylistTrackListBox.Name = "PlaylistTrackListBox";
            this.PlaylistTrackListBox.Size = new System.Drawing.Size(255, 804);
            this.PlaylistTrackListBox.TabIndex = 11;
            this.PlaylistTrackListBox.SelectedIndexChanged += new System.EventHandler(this.OnPlaylistEntrySelected);
            // 
            // GetPlaylistsButton
            // 
            this.GetPlaylistsButton.Enabled = false;
            this.GetPlaylistsButton.Location = new System.Drawing.Point(6, 6);
            this.GetPlaylistsButton.Name = "GetPlaylistsButton";
            this.GetPlaylistsButton.Size = new System.Drawing.Size(255, 90);
            this.GetPlaylistsButton.TabIndex = 9;
            this.GetPlaylistsButton.Text = "Get Playlists";
            this.GetPlaylistsButton.UseVisualStyleBackColor = true;
            this.GetPlaylistsButton.Click += new System.EventHandler(this.GetPlaylistsButton_Click);
            // 
            // PlaylistListBox
            // 
            this.PlaylistListBox.DisplayMember = "Name";
            this.PlaylistListBox.FormattingEnabled = true;
            this.PlaylistListBox.ItemHeight = 25;
            this.PlaylistListBox.Location = new System.Drawing.Point(6, 109);
            this.PlaylistListBox.Name = "PlaylistListBox";
            this.PlaylistListBox.Size = new System.Drawing.Size(255, 354);
            this.PlaylistListBox.TabIndex = 10;
            this.PlaylistListBox.SelectedIndexChanged += new System.EventHandler(this.OnPlaylistSelected);
            // 
            // ArtistArtPictureBox
            // 
            this.ArtistArtPictureBox.Location = new System.Drawing.Point(267, 6);
            this.ArtistArtPictureBox.Name = "ArtistArtPictureBox";
            this.ArtistArtPictureBox.Size = new System.Drawing.Size(1305, 1207);
            this.ArtistArtPictureBox.TabIndex = 12;
            this.ArtistArtPictureBox.TabStop = false;
            // 
            // StreamTextBox
            // 
            this.StreamTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.StreamTextBox.Location = new System.Drawing.Point(268, 1219);
            this.StreamTextBox.Name = "StreamTextBox";
            this.StreamTextBox.Size = new System.Drawing.Size(1304, 68);
            this.StreamTextBox.TabIndex = 13;
            this.StreamTextBox.Text = "";
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2215, 1375);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.OutputTextLabel);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.LoginButton);
            this.Name = "Sample";
            this.Text = "Sample";
            this.Load += new System.EventHandler(this.Sample_Load);
            this.TabControl.ResumeLayout(false);
            this.TracksTabPage.ResumeLayout(false);
            this.PlaylistTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArtistArtPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button GetTracksButton;
        private System.Windows.Forms.ListBox TrackListBox;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.Label OutputTextLabel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TracksTabPage;
        private System.Windows.Forms.TabPage PlaylistTabPage;
        private System.Windows.Forms.Button GetStreamButton;
        private System.Windows.Forms.ListBox PlaylistTrackListBox;
        private System.Windows.Forms.Button GetPlaylistsButton;
        private System.Windows.Forms.ListBox PlaylistListBox;
        private System.Windows.Forms.Button GetAlbumsButton;
        private System.Windows.Forms.PictureBox ArtistArtPictureBox;
        private System.Windows.Forms.RichTextBox StreamTextBox;
    }
}

