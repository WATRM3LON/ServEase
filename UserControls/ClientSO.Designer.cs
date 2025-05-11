namespace OOP2
{
    partial class ClientSO
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            Serviceduration = new System.Windows.Forms.Label();
            Serviceprice = new System.Windows.Forms.Label();
            Servicedesc = new System.Windows.Forms.Label();
            Servicename = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(Serviceduration, 3, 0);
            tableLayoutPanel1.Controls.Add(Serviceprice, 2, 0);
            tableLayoutPanel1.Controls.Add(Servicedesc, 1, 0);
            tableLayoutPanel1.Controls.Add(Servicename, 0, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(871, 67);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Serviceduration
            // 
            Serviceduration.AutoSize = true;
            Serviceduration.BackColor = System.Drawing.Color.WhiteSmoke;
            Serviceduration.Dock = System.Windows.Forms.DockStyle.Fill;
            Serviceduration.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Serviceduration.Location = new System.Drawing.Point(743, 0);
            Serviceduration.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            Serviceduration.Name = "Serviceduration";
            Serviceduration.Size = new System.Drawing.Size(123, 67);
            Serviceduration.TabIndex = 3;
            Serviceduration.Text = "Price";
            Serviceduration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Serviceprice
            // 
            Serviceprice.AutoSize = true;
            Serviceprice.BackColor = System.Drawing.Color.WhiteSmoke;
            Serviceprice.Dock = System.Windows.Forms.DockStyle.Fill;
            Serviceprice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Serviceprice.Location = new System.Drawing.Point(613, 0);
            Serviceprice.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            Serviceprice.Name = "Serviceprice";
            Serviceprice.Size = new System.Drawing.Size(120, 67);
            Serviceprice.TabIndex = 2;
            Serviceprice.Text = "Price";
            Serviceprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Servicedesc
            // 
            Servicedesc.AutoSize = true;
            Servicedesc.BackColor = System.Drawing.Color.WhiteSmoke;
            Servicedesc.Dock = System.Windows.Forms.DockStyle.Fill;
            Servicedesc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Servicedesc.Location = new System.Drawing.Point(222, 0);
            Servicedesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            Servicedesc.Name = "Servicedesc";
            Servicedesc.Size = new System.Drawing.Size(381, 67);
            Servicedesc.TabIndex = 1;
            Servicedesc.Text = "Service Description";
            Servicedesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Servicename
            // 
            Servicename.AutoSize = true;
            Servicename.BackColor = System.Drawing.Color.WhiteSmoke;
            Servicename.Dock = System.Windows.Forms.DockStyle.Fill;
            Servicename.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Servicename.Location = new System.Drawing.Point(5, 0);
            Servicename.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            Servicename.Name = "Servicename";
            Servicename.Size = new System.Drawing.Size(207, 67);
            Servicename.TabIndex = 0;
            Servicename.Text = "Service Name";
            Servicename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClientSO
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ClientSO";
            Size = new System.Drawing.Size(871, 73);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Servicename;
        private System.Windows.Forms.Label Servicedesc;
        private System.Windows.Forms.Label Serviceduration;
        private System.Windows.Forms.Label Serviceprice;
    }
}
