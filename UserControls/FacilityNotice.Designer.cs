namespace OOP2
{
    partial class FacilityNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacilityNotice));
            Titlelabel = new System.Windows.Forms.Label();
            ReasonLabel = new System.Windows.Forms.Label();
            Reasontextbox = new System.Windows.Forms.TextBox();
            ConButton = new System.Windows.Forms.Button();
            CloseButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // Titlelabel
            // 
            Titlelabel.AutoSize = true;
            Titlelabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Titlelabel.Location = new System.Drawing.Point(32, 28);
            Titlelabel.Name = "Titlelabel";
            Titlelabel.Size = new System.Drawing.Size(250, 31);
            Titlelabel.TabIndex = 0;
            Titlelabel.Text = "Cancel Appointment ?";
            // 
            // ReasonLabel
            // 
            ReasonLabel.AutoSize = true;
            ReasonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ReasonLabel.Location = new System.Drawing.Point(32, 78);
            ReasonLabel.Name = "ReasonLabel";
            ReasonLabel.Size = new System.Drawing.Size(377, 25);
            ReasonLabel.TabIndex = 1;
            ReasonLabel.Text = "Please enter the reason for the cancellation.";
            // 
            // Reasontextbox
            // 
            Reasontextbox.Location = new System.Drawing.Point(56, 117);
            Reasontextbox.Multiline = true;
            Reasontextbox.Name = "Reasontextbox";
            Reasontextbox.Size = new System.Drawing.Size(462, 110);
            Reasontextbox.TabIndex = 2;
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
            ConButton.Location = new System.Drawing.Point(354, 248);
            ConButton.Name = "ConButton";
            ConButton.Size = new System.Drawing.Size(180, 46);
            ConButton.TabIndex = 110;
            ConButton.Text = "Confirm Cancellation";
            ConButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ConButton.UseVisualStyleBackColor = false;
            ConButton.Click += ASCompleteButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseButton.Image = (System.Drawing.Image)resources.GetObject("CloseButton.Image");
            CloseButton.Location = new System.Drawing.Point(515, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(63, 63);
            CloseButton.TabIndex = 111;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // FacilityNotice
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(254, 241, 245);
            Controls.Add(CloseButton);
            Controls.Add(ConButton);
            Controls.Add(Reasontextbox);
            Controls.Add(ReasonLabel);
            Controls.Add(Titlelabel);
            Name = "FacilityNotice";
            Size = new System.Drawing.Size(578, 316);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Titlelabel;
        private System.Windows.Forms.Label ReasonLabel;
        private System.Windows.Forms.TextBox Reasontextbox;
        private System.Windows.Forms.Button ConButton;
        private System.Windows.Forms.Button CloseButton;
    }
}
