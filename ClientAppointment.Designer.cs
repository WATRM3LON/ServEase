namespace OOP2
{
    partial class ClientAppointment
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
            ClientSO = new System.Windows.Forms.TableLayoutPanel();
            SODuration = new System.Windows.Forms.Label();
            SOPrice = new System.Windows.Forms.Label();
            SOService = new System.Windows.Forms.Label();
            ClientSO.SuspendLayout();
            SuspendLayout();
            // 
            // ClientSO
            // 
            ClientSO.ColumnCount = 3;
            ClientSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            ClientSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            ClientSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            ClientSO.Controls.Add(SODuration, 2, 0);
            ClientSO.Controls.Add(SOPrice, 1, 0);
            ClientSO.Controls.Add(SOService, 0, 0);
            ClientSO.Dock = System.Windows.Forms.DockStyle.Fill;
            ClientSO.Location = new System.Drawing.Point(0, 0);
            ClientSO.Name = "ClientSO";
            ClientSO.RowCount = 1;
            ClientSO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            ClientSO.Size = new System.Drawing.Size(380, 56);
            ClientSO.TabIndex = 0;
            // 
            // SODuration
            // 
            SODuration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SODuration.AutoSize = true;
            SODuration.BackColor = System.Drawing.Color.WhiteSmoke;
            SODuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            SODuration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            SODuration.Location = new System.Drawing.Point(269, 0);
            SODuration.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            SODuration.Name = "SODuration";
            SODuration.Size = new System.Drawing.Size(111, 56);
            SODuration.TabIndex = 41;
            SODuration.Text = "60 mins";
            SODuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SOPrice
            // 
            SOPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SOPrice.AutoSize = true;
            SOPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            SOPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            SOPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            SOPrice.Location = new System.Drawing.Point(155, 0);
            SOPrice.Name = "SOPrice";
            SOPrice.Size = new System.Drawing.Size(108, 56);
            SOPrice.TabIndex = 40;
            SOPrice.Text = "P500.00";
            SOPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SOService
            // 
            SOService.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SOService.AutoSize = true;
            SOService.BackColor = System.Drawing.Color.WhiteSmoke;
            SOService.Font = new System.Drawing.Font("Segoe UI", 9F);
            SOService.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            SOService.Location = new System.Drawing.Point(0, 0);
            SOService.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            SOService.Name = "SOService";
            SOService.Size = new System.Drawing.Size(149, 56);
            SOService.TabIndex = 39;
            SOService.Text = " Service Name";
            SOService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClientAppointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(ClientSO);
            Name = "ClientAppointment";
            Size = new System.Drawing.Size(380, 56);
            ClientSO.ResumeLayout(false);
            ClientSO.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ClientSO;
        private System.Windows.Forms.Label SODuration;
        private System.Windows.Forms.Label SOPrice;
        private System.Windows.Forms.Label SOService;
    }
}
