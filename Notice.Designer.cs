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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notice));
            CloseButton = new System.Windows.Forms.Button();
            ConButton = new System.Windows.Forms.Button();
            Reasontextbox = new System.Windows.Forms.TextBox();
            ReasonLabel = new System.Windows.Forms.Label();
            Titlelabel = new System.Windows.Forms.Label();
            Title1label = new System.Windows.Forms.Label();
            YesButton = new System.Windows.Forms.Button();
            NoButton = new System.Windows.Forms.Button();
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
            ConButton.Location = new System.Drawing.Point(375, 250);
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
            Reasontextbox.Location = new System.Drawing.Point(53, 119);
            Reasontextbox.Multiline = true;
            Reasontextbox.Name = "Reasontextbox";
            Reasontextbox.Size = new System.Drawing.Size(462, 110);
            Reasontextbox.TabIndex = 114;
            // 
            // ReasonLabel
            // 
            ReasonLabel.AutoSize = true;
            ReasonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ReasonLabel.Location = new System.Drawing.Point(29, 80);
            ReasonLabel.Name = "ReasonLabel";
            ReasonLabel.Size = new System.Drawing.Size(377, 25);
            ReasonLabel.TabIndex = 113;
            ReasonLabel.Text = "Please enter the reason for the cancellation.";
            // 
            // Titlelabel
            // 
            Titlelabel.AutoSize = true;
            Titlelabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Titlelabel.Location = new System.Drawing.Point(29, 30);
            Titlelabel.Name = "Titlelabel";
            Titlelabel.Size = new System.Drawing.Size(250, 31);
            Titlelabel.TabIndex = 112;
            Titlelabel.Text = "Cancel Appointment ?";
            // 
            // Title1label
            // 
            Title1label.AutoSize = true;
            Title1label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Title1label.Location = new System.Drawing.Point(165, 85);
            Title1label.Name = "Title1label";
            Title1label.Size = new System.Drawing.Size(268, 31);
            Title1label.TabIndex = 117;
            Title1label.Text = "Confirm Appointment ?";
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
            YesButton.Location = new System.Drawing.Point(317, 167);
            YesButton.Name = "YesButton";
            YesButton.Size = new System.Drawing.Size(69, 46);
            YesButton.TabIndex = 118;
            YesButton.Text = "Yes";
            YesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            YesButton.UseVisualStyleBackColor = false;
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
            NoButton.Location = new System.Drawing.Point(189, 167);
            NoButton.Name = "NoButton";
            NoButton.Size = new System.Drawing.Size(69, 46);
            NoButton.TabIndex = 119;
            NoButton.Text = "No";
            NoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            NoButton.UseVisualStyleBackColor = false;
            // 
            // Notice
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(254, 241, 245);
            ClientSize = new System.Drawing.Size(601, 318);
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
    }
}