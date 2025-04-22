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
    public partial class NoticeClient : Form
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
        public NoticeClient()
        {
            InitializeComponent();
            ConButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ConButton.Width, ConButton.Height, 10, 10));
            CancelBox.Visible = false;
        }

        public void CancelPanel()
        {
            Titlelabel.Visible = true; ReasonLabel.Visible = true; Reasontextbox.Visible = true; ConButton.Visible = true;
            Headinglabel.Text = "Appointment Cancellation"; Headinglabel.Visible = true;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConButton_Click(object sender, EventArgs e)
        {
            ShowPicture();       
            if (string.IsNullOrWhiteSpace(Reasontextbox.Text))
            {
                MessageBox.Show("Please enter a reason before proceeding.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reason = "Cancelled by Client: " + Reasontextbox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private Timer hideTimer = new Timer();
        private void ShowPicture()
        {
            CancelBox.Visible = true;
           
            hideTimer.Interval = 3000;
            hideTimer.Tick += HideTimer_Tick;
            hideTimer.Start();
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            CancelBox.Visible = false;
            
            hideTimer.Stop();
            hideTimer.Tick -= HideTimer_Tick;
            this.Close();
        }
    }
}
