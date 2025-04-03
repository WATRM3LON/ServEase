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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersPanel));
            UserEmailtext = new System.Windows.Forms.Label();
            UserNametext = new System.Windows.Forms.Label();
            panel58 = new System.Windows.Forms.Panel();
            UserNamelabel = new System.Windows.Forms.Label();
            UserEmaillabel = new System.Windows.Forms.Label();
            ViewDetailsButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // UserEmailtext
            // 
            UserEmailtext.AutoSize = true;
            UserEmailtext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserEmailtext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserEmailtext.Location = new System.Drawing.Point(271, 58);
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
            UserNametext.Location = new System.Drawing.Point(273, 27);
            UserNametext.Name = "UserNametext";
            UserNametext.Size = new System.Drawing.Size(135, 23);
            UserNametext.TabIndex = 35;
            UserNametext.Text = "Jessica Gonzales";
            // 
            // panel58
            // 
            panel58.BackColor = System.Drawing.Color.Transparent;
            panel58.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel58.BackgroundImage");
            panel58.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            panel58.Location = new System.Drawing.Point(50, 15);
            panel58.Name = "panel58";
            panel58.Size = new System.Drawing.Size(83, 74);
            panel58.TabIndex = 54;
            // 
            // UserNamelabel
            // 
            UserNamelabel.AutoSize = true;
            UserNamelabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserNamelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserNamelabel.Location = new System.Drawing.Point(210, 28);
            UserNamelabel.Name = "UserNamelabel";
            UserNamelabel.Size = new System.Drawing.Size(56, 20);
            UserNamelabel.TabIndex = 55;
            UserNamelabel.Text = "Name: ";
            // 
            // UserEmaillabel
            // 
            UserEmaillabel.AutoSize = true;
            UserEmaillabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserEmaillabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserEmaillabel.Location = new System.Drawing.Point(160, 58);
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
            ViewDetailsButton.Location = new System.Drawing.Point(671, 27);
            ViewDetailsButton.Name = "ViewDetailsButton";
            ViewDetailsButton.Size = new System.Drawing.Size(159, 51);
            ViewDetailsButton.TabIndex = 57;
            ViewDetailsButton.Text = "View Details";
            ViewDetailsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ViewDetailsButton.UseVisualStyleBackColor = false;
            ViewDetailsButton.Click += button45_Click;
            // 
            // UsersPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(ViewDetailsButton);
            Controls.Add(UserEmaillabel);
            Controls.Add(UserNamelabel);
            Controls.Add(panel58);
            Controls.Add(UserEmailtext);
            Controls.Add(UserNametext);
            Name = "UsersPanel";
            Size = new System.Drawing.Size(855, 103);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label UserEmailtext;
        private System.Windows.Forms.Label UserNametext;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.Label UserNamelabel;
        private System.Windows.Forms.Label UserEmaillabel;
        private System.Windows.Forms.Button ViewDetailsButton;
    }
}
