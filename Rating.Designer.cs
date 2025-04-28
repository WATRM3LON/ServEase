namespace OOP2
{
    partial class Rating
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
            UserNamelabel = new System.Windows.Forms.Label();
            UserNametext = new System.Windows.Forms.Label();
            UserRegisttext = new System.Windows.Forms.Label();
            UserRegistlabel = new System.Windows.Forms.Label();
            SerStorePP1 = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // UserNamelabel
            // 
            UserNamelabel.AutoSize = true;
            UserNamelabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserNamelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserNamelabel.Location = new System.Drawing.Point(122, 19);
            UserNamelabel.Name = "UserNamelabel";
            UserNamelabel.Size = new System.Drawing.Size(52, 20);
            UserNamelabel.TabIndex = 57;
            UserNamelabel.Text = "Name:";
            // 
            // UserNametext
            // 
            UserNametext.AutoSize = true;
            UserNametext.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            UserNametext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserNametext.Location = new System.Drawing.Point(180, 19);
            UserNametext.Name = "UserNametext";
            UserNametext.Size = new System.Drawing.Size(135, 23);
            UserNametext.TabIndex = 56;
            UserNametext.Text = "Jessica Gonzales";
            // 
            // UserRegisttext
            // 
            UserRegisttext.AutoSize = true;
            UserRegisttext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserRegisttext.ForeColor = System.Drawing.Color.Black;
            UserRegisttext.Location = new System.Drawing.Point(246, 52);
            UserRegisttext.Name = "UserRegisttext";
            UserRegisttext.Size = new System.Drawing.Size(81, 20);
            UserRegisttext.TabIndex = 62;
            UserRegisttext.Text = "2 Apr 2025";
            // 
            // UserRegistlabel
            // 
            UserRegistlabel.AutoSize = true;
            UserRegistlabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            UserRegistlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            UserRegistlabel.Location = new System.Drawing.Point(122, 52);
            UserRegistlabel.Name = "UserRegistlabel";
            UserRegistlabel.Size = new System.Drawing.Size(123, 20);
            UserRegistlabel.TabIndex = 63;
            UserRegistlabel.Text = "Date Registered: ";
            // 
            // SerStorePP1
            // 
            SerStorePP1.BackColor = System.Drawing.Color.FromArgb(210, 247, 193);
            SerStorePP1.Location = new System.Drawing.Point(19, 10);
            SerStorePP1.Name = "SerStorePP1";
            SerStorePP1.Size = new System.Drawing.Size(70, 70);
            SerStorePP1.TabIndex = 64;
            // 
            // Rating
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 252, 247);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(SerStorePP1);
            Controls.Add(UserRegisttext);
            Controls.Add(UserRegistlabel);
            Controls.Add(UserNamelabel);
            Controls.Add(UserNametext);
            Name = "Rating";
            Size = new System.Drawing.Size(365, 91);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label UserNamelabel;
        private System.Windows.Forms.Label UserNametext;
        private System.Windows.Forms.Label UserRegisttext;
        private System.Windows.Forms.Label UserRegistlabel;
        private System.Windows.Forms.Panel SerStorePP1;
    }
}
