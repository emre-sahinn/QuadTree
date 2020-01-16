namespace QuadTreeAlgorithm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Picture = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.randomPhoto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            // 
            // Picture
            // 
            this.Picture.AutoSize = true;
            this.Picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Picture.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Picture.Location = new System.Drawing.Point(221, 9);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(95, 29);
            this.Picture.TabIndex = 1;
            this.Picture.Text = "Picture";
            this.Picture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resetButton.Location = new System.Drawing.Point(411, 540);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(101, 29);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // randomPhoto
            // 
            this.randomPhoto.AutoSize = true;
            this.randomPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.randomPhoto.Location = new System.Drawing.Point(12, 546);
            this.randomPhoto.Name = "randomPhoto";
            this.randomPhoto.Size = new System.Drawing.Size(185, 29);
            this.randomPhoto.TabIndex = 3;
            this.randomPhoto.Text = "Random Photo";
            this.randomPhoto.UseVisualStyleBackColor = true;
            this.randomPhoto.CheckedChanged += new System.EventHandler(this.RandomPhoto_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(532, 575);
            this.Controls.Add(this.randomPhoto);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Quad Tree";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label Picture;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.CheckBox randomPhoto;
    }
}

