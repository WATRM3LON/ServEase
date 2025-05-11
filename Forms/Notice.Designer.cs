namespace OOP2
{
    partial class Notice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notice));
            CloseButton = new System.Windows.Forms.Button();
            ConButton = new System.Windows.Forms.Button();
            Reasontextbox = new System.Windows.Forms.TextBox();
            ReasonLabel = new System.Windows.Forms.Label();
            Titlelabel = new System.Windows.Forms.Label();
            Title1label = new System.Windows.Forms.Label();
            YesButton = new System.Windows.Forms.Button();
            NoButton = new System.Windows.Forms.Button();
            ConfirmBox = new System.Windows.Forms.PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            Headinglabel = new System.Windows.Forms.Label();
            Captionlabel = new System.Windows.Forms.Label();
            CompleteBox = new System.Windows.Forms.PictureBox();
            CancelBox = new System.Windows.Forms.PictureBox();
            NoshowBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)ConfirmBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CompleteBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CancelBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NoshowBox).BeginInit();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseButton.Image = (System.Drawing.Image)resources.GetObject("CloseButton.Image");
            CloseButton.Location = new System.Drawing.Point(536, 2);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(63, 63);
            CloseButton.TabIndex = 116;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ConButton
            // 
            ConButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ConButton.BackColor = System.Drawing.Color.FromArgb(243, 80, 139);
            ConButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ConButton.FlatAppearance.BorderSize = 0;
            ConButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ConButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ConButton.Location = new System.Drawing.Point(367, 279);
            ConButton.Name = "ConButton";
            ConButton.Size = new System.Drawing.Size(180, 46);
            ConButton.TabIndex = 115;
            ConButton.Text = "Confirm Cancellation";
            ConButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ConButton.UseVisualStyleBackColor = false;
            ConButton.Click += ConButton_Click;
            // 
            // Reasontextbox
            // 
            Reasontextbox.Location = new System.Drawing.Point(52, 152);
            Reasontextbox.Multiline = true;
            Reasontextbox.Name = "Reasontextbox";
            Reasontextbox.Size = new System.Drawing.Size(462, 110);
            Reasontextbox.TabIndex = 114;
            // 
            // ReasonLabel
            // 
            ReasonLabel.AutoSize = true;
            ReasonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ReasonLabel.Location = new System.Drawing.Point(29, 100);
            ReasonLabel.Name = "ReasonLabel";
            ReasonLabel.Size = new System.Drawing.Size(377, 25);
            ReasonLabel.TabIndex = 113;
            ReasonLabel.Text = "Please enter the reason for the cancellation.";
            // 
            // Titlelabel
            // 
            Titlelabel.AutoSize = true;
            Titlelabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Titlelabel.Location = new System.Drawing.Point(29, 52);
            Titlelabel.Name = "Titlelabel";
            Titlelabel.Size = new System.Drawing.Size(250, 31);
            Titlelabel.TabIndex = 112;
            Titlelabel.Text = "Cancel Appointment ?";
            // 
            // Title1label
            // 
            Title1label.AutoSize = true;
            Title1label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Title1label.Location = new System.Drawing.Point(165, 79);
            Title1label.Name = "Title1label";
            Title1label.Size = new System.Drawing.Size(268, 31);
            Title1label.TabIndex = 117;
            Title1label.Text = "Confirm Appointment ?";
            Title1label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YesButton
            // 
            YesButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            YesButton.BackColor = System.Drawing.Color.FromArgb(243, 80, 139);
            YesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            YesButton.FlatAppearance.BorderSize = 0;
            YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            YesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            YesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            YesButton.Location = new System.Drawing.Point(337, 227);
            YesButton.Name = "YesButton";
            YesButton.Size = new System.Drawing.Size(69, 46);
            YesButton.TabIndex = 118;
            YesButton.Text = "Yes";
            YesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            YesButton.UseVisualStyleBackColor = false;
            YesButton.Click += YesButton_Click;
            // 
            // NoButton
            // 
            NoButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NoButton.BackColor = System.Drawing.Color.FromArgb(252, 232, 238);
            NoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            NoButton.FlatAppearance.BorderSize = 0;
            NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NoButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            NoButton.ForeColor = System.Drawing.Color.Red;
            NoButton.Location = new System.Drawing.Point(180, 227);
            NoButton.Name = "NoButton";
            NoButton.Size = new System.Drawing.Size(69, 46);
            NoButton.TabIndex = 119;
            NoButton.Text = "No";
            NoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            NoButton.UseVisualStyleBackColor = false;
            // 
            // ConfirmBox
            // 
            ConfirmBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ConfirmBox.Image = (System.Drawing.Image)resources.GetObject("ConfirmBox.Image");
            ConfirmBox.Location = new System.Drawing.Point(94, 12);
            ConfirmBox.Name = "ConfirmBox";
            ConfirmBox.Size = new System.Drawing.Size(403, 326);
            ConfirmBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ConfirmBox.TabIndex = 120;
            ConfirmBox.TabStop = false;
            // 
            // Headinglabel
            // 
            Headinglabel.AutoSize = true;
            Headinglabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Headinglabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            Headinglabel.Location = new System.Drawing.Point(12, 5);
            Headinglabel.Name = "Headinglabel";
            Headinglabel.Size = new System.Drawing.Size(217, 23);
            Headinglabel.TabIndex = 121;
            Headinglabel.Text = "Appointment Confirmation";
            // 
            // Captionlabel
            // 
            Captionlabel.AutoSize = true;
            Captionlabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Captionlabel.Location = new System.Drawing.Point(125, 142);
            Captionlabel.Name = "Captionlabel";
            Captionlabel.Size = new System.Drawing.Size(346, 46);
            Captionlabel.TabIndex = 122;
            Captionlabel.Text = "You are about to confirm this appointment. \r\nThis action cannot be undone.";
            Captionlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompleteBox
            // 
            CompleteBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            CompleteBox.Image = (System.Drawing.Image)resources.GetObject("CompleteBox.Image");
            CompleteBox.Location = new System.Drawing.Point(94, 12);
            CompleteBox.Name = "CompleteBox";
            CompleteBox.Size = new System.Drawing.Size(403, 326);
            CompleteBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            CompleteBox.TabIndex = 123;
            CompleteBox.TabStop = false;
            // 
            // CancelBox
            // 
            CancelBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            CancelBox.Image = (System.Drawing.Image)resources.GetObject("CancelBox.Image");
            CancelBox.Location = new System.Drawing.Point(94, 12);
            CancelBox.Name = "CancelBox";
            CancelBox.Size = new System.Drawing.Size(403, 326);
            CancelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            CancelBox.TabIndex = 124;
            CancelBox.TabStop = false;
            // 
            // NoshowBox
            // 
            NoshowBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            NoshowBox.Image = (System.Drawing.Image)resources.GetObject("NoshowBox.Image");
            NoshowBox.Location = new System.Drawing.Point(94, 12);
            NoshowBox.Name = "NoshowBox";
            NoshowBox.Size = new System.Drawing.Size(403, 326);
            NoshowBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            NoshowBox.TabIndex = 125;
            NoshowBox.TabStop = false;
            // 
            // Notice
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(254, 241, 245);
            ClientSize = new System.Drawing.Size(601, 350);
            Controls.Add(ConfirmBox);
            Controls.Add(NoshowBox);
            Controls.Add(CancelBox);
            Controls.Add(CompleteBox);
            Controls.Add(Captionlabel);
            Controls.Add(Headinglabel);
            Controls.Add(NoButton);
            Controls.Add(YesButton);
            Controls.Add(Title1label);
            Controls.Add(CloseButton);
            Controls.Add(ConButton);
            Controls.Add(Reasontextbox);
            Controls.Add(ReasonLabel);
            Controls.Add(Titlelabel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Notice";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Notice";
            ((System.ComponentModel.ISupportInitialize)ConfirmBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)CompleteBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)CancelBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NoshowBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ConButton;
        private System.Windows.Forms.TextBox Reasontextbox;
        private System.Windows.Forms.Label ReasonLabel;
        private System.Windows.Forms.Label Titlelabel;
        private System.Windows.Forms.Label Title1label;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.PictureBox ConfirmBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Headinglabel;
        private System.Windows.Forms.Label Captionlabel;
        private System.Windows.Forms.PictureBox CompleteBox;
        private System.Windows.Forms.PictureBox CancelBox;
        private System.Windows.Forms.PictureBox NoshowBox;
    }
}