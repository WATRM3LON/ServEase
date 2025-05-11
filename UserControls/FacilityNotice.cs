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
    public partial class FacilityNotice : UserControl
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
        public FacilityNotice()
        {
            InitializeComponent();
            ConButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ConButton.Width, ConButton.Height, 10, 10));
        }

        private void ASCompleteButton_Click(object sender, EventArgs e)
        {
            Reason = Reasontextbox.Text;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
        }
    }
}
