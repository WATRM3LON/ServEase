namespace OOP2
{
    partial class FacilityPanel
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
            WorkingHoursText = new System.Windows.Forms.Label();
            SerStoreButton = new System.Windows.Forms.Button();
            FacilityName = new System.Windows.Forms.Label();
            SerStorePP1 = new System.Windows.Forms.Panel();
            Workinhourslabel = new System.Windows.Forms.Label();
            Pricerangetext = new System.Windows.Forms.Label();
            PricerangeLabel = new System.Windows.Forms.Label();
            Ratings = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // WorkingHoursText
            // 
            WorkingHoursText.AutoSize = true;
            WorkingHoursText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            WorkingHoursText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            WorkingHoursText.Location = new System.Drawing.Point(32, 136);
            WorkingHoursText.Name = "WorkingHoursText";
            WorkingHoursText.Size = new System.Drawing.Size(93, 20);
            WorkingHoursText.TabIndex = 43;
            WorkingHoursText.Text = "10:00 - 12:00";
            // 
            // SerStoreButton
            // 
            SerStoreButton.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SerStoreButton.BackColor = System.Drawing.Color.FromArgb(129, 238, 223);
            SerStoreButton.FlatAppearance.BorderSize = 0;
            SerStoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SerStoreButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            SerStoreButton.Location = new System.Drawing.Point(13, 183);
            SerStoreButton.Name = "SerStoreButton";
            SerStoreButton.Size = new System.Drawing.Size(258, 51);
            SerStoreButton.TabIndex = 42;
            SerStoreButton.Text = "View Profile";
            SerStoreButton.UseVisualStyleBackColor = false;
            // 
            // FacilityName
            // 
            FacilityName.AutoSize = true;
            FacilityName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            FacilityName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            FacilityName.Location = new System.Drawing.Point(110, 40);
            FacilityName.Name = "FacilityName";
            FacilityName.Size = new System.Drawing.Size(62, 23);
            FacilityName.TabIndex = 41;
            FacilityName.Text = "Store 1";
            // 
            // SerStorePP1
            // 
            SerStorePP1.BackColor = System.Drawing.Color.FromArgb(210, 247, 193);
            SerStorePP1.Location = new System.Drawing.Point(14, 16);
            SerStorePP1.Name = "SerStorePP1";
            SerStorePP1.Size = new System.Drawing.Size(78, 78);
            SerStorePP1.TabIndex = 40;
            // 
            // Workinhourslabel
            // 
            Workinhourslabel.AutoSize = true;
            Workinhourslabel.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Workinhourslabel.ForeColor = System.Drawing.Color.Gray;
            Workinhourslabel.Location = new System.Drawing.Point(20, 114);
            Workinhourslabel.Name = "Workinhourslabel";
            Workinhourslabel.Size = new System.Drawing.Size(101, 17);
            Workinhourslabel.TabIndex = 45;
            Workinhourslabel.Text = "Working Hours";
            // 
            // Pricerangetext
            // 
            Pricerangetext.AutoSize = true;
            Pricerangetext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Pricerangetext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            Pricerangetext.Location = new System.Drawing.Point(164, 136);
            Pricerangetext.Name = "Pricerangetext";
            Pricerangetext.Size = new System.Drawing.Size(95, 20);
            Pricerangetext.TabIndex = 44;
            Pricerangetext.Text = "P500 - P1500";
            // 
            // PricerangeLabel
            // 
            PricerangeLabel.AutoSize = true;
            PricerangeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            PricerangeLabel.ForeColor = System.Drawing.Color.Gray;
            PricerangeLabel.Location = new System.Drawing.Point(152, 114);
            PricerangeLabel.Name = "PricerangeLabel";
            PricerangeLabel.Size = new System.Drawing.Size(79, 17);
            PricerangeLabel.TabIndex = 46;
            PricerangeLabel.Text = "Price Range";
            // 
            // Ratings
            // 
            Ratings.AutoSize = true;
            Ratings.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Ratings.ForeColor = System.Drawing.Color.Gray;
            Ratings.Location = new System.Drawing.Point(116, 65);
            Ratings.Name = "Ratings";
            Ratings.Size = new System.Drawing.Size(53, 17);
            Ratings.TabIndex = 47;
            Ratings.Text = "Ratings";
            // 
            // FacilityPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(Ratings);
            Controls.Add(PricerangeLabel);
            Controls.Add(Workinhourslabel);
            Controls.Add(Pricerangetext);
            Controls.Add(WorkingHoursText);
            Controls.Add(SerStoreButton);
            Controls.Add(FacilityName);
            Controls.Add(SerStorePP1);
            Name = "FacilityPanel";
            Size = new System.Drawing.Size(283, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label WorkingHoursText;
        private System.Windows.Forms.Button SerStoreButton;
        private System.Windows.Forms.Label FacilityName;
        private System.Windows.Forms.Panel SerStorePP1;
        private System.Windows.Forms.Label Workinhourslabel;
        private System.Windows.Forms.Label Pricerangetext;
        private System.Windows.Forms.Label PricerangeLabel;
        private System.Windows.Forms.Label Ratings;
    }
}
