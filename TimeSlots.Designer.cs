namespace OOP2
{
    partial class TimeSlots
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
            Startime = new System.Windows.Forms.Label();
            Endtime = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.4444427F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.4444427F));
            tableLayoutPanel1.Controls.Add(Endtime, 2, 0);
            tableLayoutPanel1.Controls.Add(Startime, 0, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(257, 50);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // Startime
            // 
            Startime.AutoSize = true;
            Startime.BackColor = System.Drawing.SystemColors.ControlLight;
            Startime.Dock = System.Windows.Forms.DockStyle.Fill;
            Startime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Startime.Location = new System.Drawing.Point(8, 13);
            Startime.Margin = new System.Windows.Forms.Padding(8, 13, 8, 13);
            Startime.Name = "Startime";
            Startime.Size = new System.Drawing.Size(98, 24);
            Startime.TabIndex = 0;
            Startime.Text = "12:00 am";
            Startime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Endtime
            // 
            Endtime.AutoSize = true;
            Endtime.BackColor = System.Drawing.SystemColors.ControlLight;
            Endtime.Dock = System.Windows.Forms.DockStyle.Fill;
            Endtime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Endtime.Location = new System.Drawing.Point(150, 13);
            Endtime.Margin = new System.Windows.Forms.Padding(8, 13, 8, 13);
            Endtime.Name = "Endtime";
            Endtime.Size = new System.Drawing.Size(99, 24);
            Endtime.TabIndex = 2;
            Endtime.Text = "12:00 am";
            Endtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeSlots
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "TimeSlots";
            Size = new System.Drawing.Size(260, 50);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Startime;
        private System.Windows.Forms.Label Endtime;
    }
}
