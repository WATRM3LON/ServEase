namespace OOP2
{
    partial class ServiceOffered
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
            ServiceName = new System.Windows.Forms.Label();
            ServiceDes = new System.Windows.Forms.Label();
            ServicePrice = new System.Windows.Forms.Label();
            Serviceduration = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ServiceName
            // 
            ServiceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ServiceName.AutoSize = true;
            ServiceName.BackColor = System.Drawing.Color.FromArgb(245, 208, 220);
            ServiceName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ServiceName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ServiceName.Location = new System.Drawing.Point(0, 0);
            ServiceName.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            ServiceName.Name = "ServiceName";
            ServiceName.Size = new System.Drawing.Size(168, 100);
            ServiceName.TabIndex = 57;
            ServiceName.Text = "ServiceName";
            ServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServiceDes
            // 
            ServiceDes.AutoSize = true;
            ServiceDes.BackColor = System.Drawing.Color.FromArgb(245, 208, 220);
            ServiceDes.Dock = System.Windows.Forms.DockStyle.Fill;
            ServiceDes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ServiceDes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ServiceDes.Location = new System.Drawing.Point(176, 0);
            ServiceDes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ServiceDes.Name = "ServiceDes";
            ServiceDes.Size = new System.Drawing.Size(423, 100);
            ServiceDes.TabIndex = 58;
            ServiceDes.Text = "Service Description";
            ServiceDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServicePrice
            // 
            ServicePrice.AutoSize = true;
            ServicePrice.BackColor = System.Drawing.Color.FromArgb(245, 208, 220);
            ServicePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            ServicePrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ServicePrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ServicePrice.Location = new System.Drawing.Point(607, 0);
            ServicePrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ServicePrice.Name = "ServicePrice";
            ServicePrice.Size = new System.Drawing.Size(121, 100);
            ServicePrice.TabIndex = 59;
            ServicePrice.Text = "PHP 1,000.00";
            ServicePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Serviceduration
            // 
            Serviceduration.AutoSize = true;
            Serviceduration.BackColor = System.Drawing.Color.FromArgb(245, 208, 220);
            Serviceduration.Dock = System.Windows.Forms.DockStyle.Fill;
            Serviceduration.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Serviceduration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            Serviceduration.Location = new System.Drawing.Point(736, 0);
            Serviceduration.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            Serviceduration.Name = "Serviceduration";
            Serviceduration.Size = new System.Drawing.Size(126, 100);
            Serviceduration.TabIndex = 60;
            Serviceduration.Text = "60 mins";
            Serviceduration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(254, 241, 245);
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(Serviceduration, 3, 0);
            tableLayoutPanel1.Controls.Add(ServicePrice, 2, 0);
            tableLayoutPanel1.Controls.Add(ServiceName, 0, 0);
            tableLayoutPanel1.Controls.Add(ServiceDes, 1, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(862, 100);
            tableLayoutPanel1.TabIndex = 61;
            // 
            // ServiceOffered
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(254, 241, 245);
            Controls.Add(tableLayoutPanel1);
            Name = "ServiceOffered";
            Size = new System.Drawing.Size(865, 103);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label ServiceName;
        private System.Windows.Forms.Label ServiceDes;
        private System.Windows.Forms.Label ServicePrice;
        private System.Windows.Forms.Label Serviceduration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
