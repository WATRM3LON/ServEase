namespace OOP2
{
    partial class Rates
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
            SubmitButton = new System.Windows.Forms.Button();
            Exellentlabel = new System.Windows.Forms.Label();
            Badlabel = new System.Windows.Forms.Label();
            Ratelabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // SubmitButton
            // 
            SubmitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            SubmitButton.Location = new System.Drawing.Point(117, 154);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new System.Drawing.Size(94, 30);
            SubmitButton.TabIndex = 7;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // Exellentlabel
            // 
            Exellentlabel.AutoSize = true;
            Exellentlabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            Exellentlabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            Exellentlabel.Location = new System.Drawing.Point(238, 148);
            Exellentlabel.Name = "Exellentlabel";
            Exellentlabel.Size = new System.Drawing.Size(68, 20);
            Exellentlabel.TabIndex = 6;
            Exellentlabel.Text = "Excellent";
            Exellentlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Badlabel
            // 
            Badlabel.AutoSize = true;
            Badlabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            Badlabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            Badlabel.Location = new System.Drawing.Point(41, 148);
            Badlabel.Name = "Badlabel";
            Badlabel.Size = new System.Drawing.Size(35, 20);
            Badlabel.TabIndex = 5;
            Badlabel.Text = "Bad";
            Badlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Ratelabel
            // 
            Ratelabel.AutoSize = true;
            Ratelabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Ratelabel.Location = new System.Drawing.Point(71, 20);
            Ratelabel.Name = "Ratelabel";
            Ratelabel.Size = new System.Drawing.Size(199, 56);
            Ratelabel.TabIndex = 4;
            Ratelabel.Text = "How do you rate this \r\nService Facility?";
            Ratelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rates
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 252, 247);
            ClientSize = new System.Drawing.Size(346, 203);
            Controls.Add(SubmitButton);
            Controls.Add(Exellentlabel);
            Controls.Add(Badlabel);
            Controls.Add(Ratelabel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Rates";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Rates";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label Exellentlabel;
        private System.Windows.Forms.Label Badlabel;
        private System.Windows.Forms.Label Ratelabel;
    }
}