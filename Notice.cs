using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public partial class Notice : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeft,
            int nTop,
            int nRight,
            int rBottom,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public string Reason { get; set; }
        public string Yes { get; set; }
        public Notice()
        {
            InitializeComponent();
            ConButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ConButton.Width, ConButton.Height, 10, 10));
            Title1label.Visible = false; YesButton.Visible = false; NoButton.Visible = false;
            Titlelabel.Visible = false; ReasonLabel.Visible = false; Reasontextbox.Visible = false; ConButton.Visible = false;
            ConfirmBox.Visible = false;
        }
        public void CancelPanel()
        {
            Titlelabel.Visible = true; ReasonLabel.Visible = true; Reasontextbox.Visible = true; ConButton.Visible = true;
        }
        public void ConfirmPanel()
        {
            Titlelabel.Text = "Confirm Appointment ?";
            Title1label.Visible = true; YesButton.Visible = true; NoButton.Visible = true;
        }
        public void CompletePanel()
        {
            Titlelabel.Text = "Complete Appointment ?";
            Title1label.Visible = true; YesButton.Visible = true; NoButton.Visible = true;
        }
        private void ConButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Reasontextbox.Text))
            {
                MessageBox.Show("Please enter a reason before proceeding.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reason = "Cancelled by Facility: " + Reasontextbox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            Yes = "Confirm";
            ShowPictureTemporarily();
        }
        private Timer hideTimer = new Timer();

        private void ShowPictureTemporarily()
        {
            ConfirmBox.Visible = true;

            hideTimer.Interval = 3000;
            hideTimer.Tick += HideTimer_Tick;
            hideTimer.Start();
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            ConfirmBox.Visible = false;
            hideTimer.Stop(); 
            hideTimer.Tick -= HideTimer_Tick;
            this.Close();
        }
    }
}
