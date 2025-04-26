namespace OOP2
{
    partial class UsersPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserEmailtext = new System.Windows.Forms.Label();
            UserNametext = new System.Windows.Forms.Label();
            UserNamelabel = new System.Windows.Forms.Label();
            UserEmaillabel = new System.Windows.Forms.Label();
            ViewDetailsButton = new System.Windows.Forms.Button();
            UserStatuslabel = new System.Windows.Forms.Label();
            UserStatustext = new System.Windows.Forms.Label();
            UserRegistlabel = new System.Windows.Forms.Label();
            UserRegisttext = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // UserEmailtext
            // 
            UserEmailtext.AutoSize = true;
            UserEmailtext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserEmailtext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserEmailtext.Location = new System.Drawing.Point(153, 58);
            UserEmailtext.Name = "UserEmailtext";
            UserEmailtext.Size = new System.Drawing.Size(195, 20);
            UserEmailtext.TabIndex = 36;
            UserEmailtext.Text = "jessicagonzales@gmail.com";
            // 
            // UserNametext
            // 
            UserNametext.AutoSize = true;
            UserNametext.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            UserNametext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserNametext.Location = new System.Drawing.Point(153, 26);
            UserNametext.Name = "UserNametext";
            UserNametext.Size = new System.Drawing.Size(135, 23);
            UserNametext.TabIndex = 35;
            UserNametext.Text = "Jessica Gonzales";
            // 
            // UserNamelabel
            // 
            UserNamelabel.AutoSize = true;
            UserNamelabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserNamelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserNamelabel.Location = new System.Drawing.Point(95, 26);
            UserNamelabel.Name = "UserNamelabel";
            UserNamelabel.Size = new System.Drawing.Size(52, 20);
            UserNamelabel.TabIndex = 55;
            UserNamelabel.Text = "Name:";
            // 
            // UserEmaillabel
            // 
            UserEmaillabel.AutoSize = true;
            UserEmaillabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserEmaillabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserEmaillabel.Location = new System.Drawing.Point(42, 58);
            UserEmaillabel.Name = "UserEmaillabel";
            UserEmaillabel.Size = new System.Drawing.Size(106, 20);
            UserEmaillabel.TabIndex = 56;
            UserEmaillabel.Text = "Email Address:";
            // 
            // ViewDetailsButton
            // 
            ViewDetailsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ViewDetailsButton.BackColor = System.Drawing.Color.FromArgb(34, 176, 229);
            ViewDetailsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ViewDetailsButton.FlatAppearance.BorderSize = 0;
            ViewDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ViewDetailsButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ViewDetailsButton.Location = new System.Drawing.Point(700, 27);
            ViewDetailsButton.Name = "ViewDetailsButton";
            ViewDetailsButton.Size = new System.Drawing.Size(130, 51);
            ViewDetailsButton.TabIndex = 57;
            ViewDetailsButton.Text = "View Details";
            ViewDetailsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ViewDetailsButton.UseVisualStyleBackColor = false;
            ViewDetailsButton.Click += ViewDetailsButton_Click;
            // 
            // UserStatuslabel
            // 
            UserStatuslabel.AutoSize = true;
            UserStatuslabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserStatuslabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserStatuslabel.Location = new System.Drawing.Point(485, 26);
            UserStatuslabel.Name = "UserStatuslabel";
            UserStatuslabel.Size = new System.Drawing.Size(52, 20);
            UserStatuslabel.TabIndex = 59;
            UserStatuslabel.Text = "Status:";
            // 
            // UserStatustext
            // 
            UserStatustext.AutoSize = true;
            UserStatustext.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            UserStatustext.ForeColor = System.Drawing.Color.LawnGreen;
            UserStatustext.Location = new System.Drawing.Point(552, 26);
            UserStatustext.Name = "UserStatustext";
            UserStatustext.Size = new System.Drawing.Size(51, 20);
            UserStatustext.TabIndex = 58;
            UserStatustext.Text = "Active";
            // 
            // UserRegistlabel
            // 
            UserRegistlabel.AutoSize = true;
            UserRegistlabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserRegistlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserRegistlabel.Location = new System.Drawing.Point(428, 58);
            UserRegistlabel.Name = "UserRegistlabel";
            UserRegistlabel.Size = new System.Drawing.Size(123, 20);
            UserRegistlabel.TabIndex = 61;
            UserRegistlabel.Text = "Date Registered: ";
            // 
            // UserRegisttext
            // 
            UserRegisttext.AutoSize = true;
            UserRegisttext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserRegisttext.ForeColor = System.Drawing.Color.Black;
            UserRegisttext.Location = new System.Drawing.Point(552, 58);
            UserRegisttext.Name = "UserRegisttext";
            UserRegisttext.Size = new System.Drawing.Size(81, 20);
            UserRegisttext.TabIndex = 60;
            UserRegisttext.Text = "2 Apr 2025";
            // 
            // UsersPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(UserRegisttext);
            Controls.Add(UserRegistlabel);
            Controls.Add(UserStatuslabel);
            Controls.Add(UserStatustext);
            Controls.Add(ViewDetailsButton);
            Controls.Add(UserEmaillabel);
            Controls.Add(UserNamelabel);
            Controls.Add(UserEmailtext);
            Controls.Add(UserNametext);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "UsersPanel";
            Size = new System.Drawing.Size(855, 103);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label UserEmailtext;
        private System.Windows.Forms.Label UserNametext;
        private System.Windows.Forms.Label UserNamelabel;
        private System.Windows.Forms.Label UserEmaillabel;
        private System.Windows.Forms.Button ViewDetailsButton;
        private System.Windows.Forms.Label UserStatuslabel;
        private System.Windows.Forms.Label UserStatustext;
        private System.Windows.Forms.Label UserRegistlabel;
        private System.Windows.Forms.Label UserRegisttext;
    }
}
