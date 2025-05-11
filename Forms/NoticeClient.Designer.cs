namespace OOP2
{
    partial class NoticeClient
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeClient));
            CancelBox = new System.Windows.Forms.PictureBox();
            Headinglabel = new System.Windows.Forms.Label();
            CloseButton = new System.Windows.Forms.Button();
            ConButton = new System.Windows.Forms.Button();
            Reasontextbox = new System.Windows.Forms.TextBox();
            ReasonLabel = new System.Windows.Forms.Label();
            Titlelabel = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)CancelBox).BeginInit();
            SuspendLayout();
            // 
            // CancelBox
            // 
            CancelBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            CancelBox.Image = (System.Drawing.Image)resources.GetObject("CancelBox.Image");
            CancelBox.Location = new System.Drawing.Point(80, 11);
            CancelBox.Name = "CancelBox";
            CancelBox.Size = new System.Drawing.Size(403, 326);
            CancelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            CancelBox.TabIndex = 127;
            CancelBox.TabStop = false;
            // 
            // Headinglabel
            // 
            Headinglabel.AutoSize = true;
            Headinglabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Headinglabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            Headinglabel.Location = new System.Drawing.Point(18, 6);
            Headinglabel.Name = "Headinglabel";
            Headinglabel.Size = new System.Drawing.Size(217, 23);
            Headinglabel.TabIndex = 128;
            Headinglabel.Text = "Appointment Confirmation";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseButton.Image = (System.Drawing.Image)resources.GetObject("CloseButton.Image");
            CloseButton.Location = new System.Drawing.Point(519, 2);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(63, 63);
            CloseButton.TabIndex = 126;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ConButton
            // 
            ConButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ConButton.BackColor = System.Drawing.Color.FromArgb(105, 227, 49);
            ConButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ConButton.FlatAppearance.BorderSize = 0;
            ConButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ConButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ConButton.Location = new System.Drawing.Point(353, 278);
            ConButton.Name = "ConButton";
            ConButton.Size = new System.Drawing.Size(180, 46);
            ConButton.TabIndex = 125;
            ConButton.Text = "Confirm Cancellation";
            ConButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ConButton.UseVisualStyleBackColor = false;
            ConButton.Click += ConButton_Click;
            // 
            // Reasontextbox
            // 
            Reasontextbox.Location = new System.Drawing.Point(58, 153);
            Reasontextbox.Multiline = true;
            Reasontextbox.Name = "Reasontextbox";
            Reasontextbox.Size = new System.Drawing.Size(462, 110);
            Reasontextbox.TabIndex = 124;
            // 
            // ReasonLabel
            // 
            ReasonLabel.AutoSize = true;
            ReasonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ReasonLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ReasonLabel.Location = new System.Drawing.Point(35, 101);
            ReasonLabel.Name = "ReasonLabel";
            ReasonLabel.Size = new System.Drawing.Size(377, 25);
            ReasonLabel.TabIndex = 123;
            ReasonLabel.Text = "Please enter the reason for the cancellation.";
            // 
            // Titlelabel
            // 
            Titlelabel.AutoSize = true;
            Titlelabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Titlelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            Titlelabel.Location = new System.Drawing.Point(35, 53);
            Titlelabel.Name = "Titlelabel";
            Titlelabel.Size = new System.Drawing.Size(250, 31);
            Titlelabel.TabIndex = 122;
            Titlelabel.Text = "Cancel Appointment ?";
            // 
            // NoticeClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(219, 247, 210);
            ClientSize = new System.Drawing.Size(583, 345);
            Controls.Add(CancelBox);
            Controls.Add(Headinglabel);
            Controls.Add(CloseButton);
            Controls.Add(ConButton);
            Controls.Add(Reasontextbox);
            Controls.Add(ReasonLabel);
            Controls.Add(Titlelabel);
            ForeColor = System.Drawing.SystemColors.ControlLight;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "NoticeClient";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "NoticeClient";
            ((System.ComponentModel.ISupportInitialize)CancelBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox CancelBox;
        private System.Windows.Forms.Label Headinglabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ConButton;
        private System.Windows.Forms.TextBox Reasontextbox;
        private System.Windows.Forms.Label ReasonLabel;
        private System.Windows.Forms.Label Titlelabel;
        private System.Windows.Forms.Timer timer1;
    }
}