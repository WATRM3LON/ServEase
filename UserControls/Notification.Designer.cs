namespace OOP2
{
    partial class Notification
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
            NotifTitle = new System.Windows.Forms.Label();
            NotifDesc = new System.Windows.Forms.Label();
            NotifTime = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // NotifTitle
            // 
            NotifTitle.AutoSize = true;
            NotifTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            NotifTitle.Location = new System.Drawing.Point(27, 10);
            NotifTitle.Name = "NotifTitle";
            NotifTitle.Size = new System.Drawing.Size(49, 25);
            NotifTitle.TabIndex = 0;
            NotifTitle.Text = "Title";
            // 
            // NotifDesc
            // 
            NotifDesc.AutoSize = true;
            NotifDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            NotifDesc.Location = new System.Drawing.Point(47, 37);
            NotifDesc.Name = "NotifDesc";
            NotifDesc.Size = new System.Drawing.Size(85, 20);
            NotifDesc.TabIndex = 1;
            NotifDesc.Text = "Description";
            // 
            // NotifTime
            // 
            NotifTime.AutoSize = true;
            NotifTime.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            NotifTime.ForeColor = System.Drawing.Color.DarkGray;
            NotifTime.Location = new System.Drawing.Point(310, 6);
            NotifTime.Name = "NotifTime";
            NotifTime.Size = new System.Drawing.Size(53, 17);
            NotifTime.TabIndex = 2;
            NotifTime.Text = "1m ago";
            // 
            // Notification
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            Controls.Add(NotifTime);
            Controls.Add(NotifDesc);
            Controls.Add(NotifTitle);
            Name = "Notification";
            Size = new System.Drawing.Size(370, 74);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label NotifTitle;
        private System.Windows.Forms.Label NotifDesc;
        private System.Windows.Forms.Label NotifTime;
    }
}
