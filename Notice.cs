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
        public string AppStat { get; set; }
        public string Yes { get; set; }
        public Notice()
        {
            InitializeComponent();
            ConButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ConButton.Width, ConButton.Height, 10, 10));
            Title1label.Visible = false; YesButton.Visible = false; NoButton.Visible = false;
            Titlelabel.Visible = false; ReasonLabel.Visible = false; Reasontextbox.Visible = false; ConButton.Visible = false; NoshowBox.Visible = false;
            ConfirmBox.Visible = false; Headinglabel.Visible = false; Captionlabel.Visible = false; CompleteBox.Visible = false; CancelBox.Visible = false;
        }
        public void CancelPanel()
        {
            Titlelabel.Visible = true; ReasonLabel.Visible = true; Reasontextbox.Visible = true; ConButton.Visible = true;
            Headinglabel.Text = "Appointment Cancellation"; Headinglabel.Visible= true; AppStat = "Cancel";
        }
        public void ConfirmPanel()
        {
            Titlelabel.Text = "Confirm Appointment ?"; Headinglabel.Text = "Appointment Confirmation"; Captionlabel.Text = "You are about to confirm this appointment.\r\nThis action cannot be undone.";
            Title1label.Visible = true; YesButton.Visible = true; NoButton.Visible = true; Headinglabel.Visible = true; Captionlabel.Visible = true;
            AppStat = "Confirm";
        }
        public void CompletePanel()
        {
            Titlelabel.Text = "Complete Appointment ?"; Headinglabel.Text = "Confirm Appointment Completion"; Captionlabel.Text = "This action will mark the appointment as completed.\r\nContinue?";
            Title1label.Visible = true; YesButton.Visible = true; NoButton.Visible = true; Headinglabel.Visible = true; Captionlabel.Visible = true;
            AppStat = "Complete";
        }
        public void NoshowPanel()
        {
            Titlelabel.Text = "Mark as No-Show ?"; Headinglabel.Text = "Client No-Show"; Captionlabel.Text = "This will mark the appointment as Client No-Show.\r\nDo you want to proceed?";
            Title1label.Visible = true; YesButton.Visible = true; NoButton.Visible = true; Headinglabel.Visible = true; Captionlabel.Visible = true;
            AppStat = "No Show";
        }
        private void ConButton_Click(object sender, EventArgs e)
        {
            ShowPictureTemporarily();
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
            Yes= AppStat;
            ShowPictureTemporarily();
        }
        private Timer hideTimer = new Timer();

        private void ShowPictureTemporarily()
        {
            if (AppStat == "Confirm")
            {
                ConfirmBox.Visible = true;
            }else if(AppStat == "Complete")
            {
                CompleteBox.Visible = true;
            }else if(AppStat == "Cancel")
            {
                CancelBox.Visible = true;
            }else if(AppStat == "No Show")
            {
                NoshowBox.Visible = true;
            }
            

            hideTimer.Interval = 3000;
            hideTimer.Tick += HideTimer_Tick;
            hideTimer.Start();
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            if (AppStat == "Confirm")
            {
                ConfirmBox.Visible = false;
            }
            else if (AppStat == "Complete")
            {
                CompleteBox.Visible = false;
            }
            else if (AppStat == "Cancel")
            {
                CancelBox.Visible = false;
            }
            else if (AppStat == "No Show")
            {
                NoshowBox.Visible = false;
            }

            hideTimer.Stop(); 
            hideTimer.Tick -= HideTimer_Tick;
            this.Close();
        }
    }
}
