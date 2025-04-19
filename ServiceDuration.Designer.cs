namespace OOP2
{
    partial class ServiceDuration
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
            ASdurtext = new System.Windows.Forms.Label();
            ASsertext = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ASdurtext
            // 
            ASdurtext.AutoEllipsis = true;
            ASdurtext.AutoSize = true;
            ASdurtext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            ASdurtext.ForeColor = System.Drawing.SystemColors.ControlText;
            ASdurtext.Location = new System.Drawing.Point(243, 10);
            ASdurtext.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            ASdurtext.Name = "ASdurtext";
            ASdurtext.Size = new System.Drawing.Size(124, 23);
            ASdurtext.TabIndex = 92;
            ASdurtext.Text = "Select Timeslot";
            // 
            // ASsertext
            // 
            ASsertext.AutoEllipsis = true;
            ASsertext.AutoSize = true;
            ASsertext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            ASsertext.ForeColor = System.Drawing.SystemColors.ControlText;
            ASsertext.Location = new System.Drawing.Point(23, 10);
            ASsertext.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            ASsertext.Name = "ASsertext";
            ASsertext.Size = new System.Drawing.Size(124, 23);
            ASsertext.TabIndex = 91;
            ASsertext.Text = "Select Timeslot";
            // 
            // ServiceDuration
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(ASdurtext);
            Controls.Add(ASsertext);
            Name = "ServiceDuration";
            Size = new System.Drawing.Size(400, 41);
            Load += ServiceDuration_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label ASdurtext;
        private System.Windows.Forms.Label ASsertext;
    }
}
