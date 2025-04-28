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
    public partial class FacilityPanel : UserControl
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

        public event EventHandler ViewProfileClicked;
        public FacilityPanel()
        {
            InitializeComponent();
        }

        public void SetData(string Servicename, string ratings, string workinghours, string pricerange)
        {
            SerStoreButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SerStoreButton.Width, SerStoreButton.Height, 10, 10));
            FacilityName.Text = Servicename;
            Ratings.Text = ratings + " Ratings";
            WorkingHoursText.Text = workinghours;
            Pricerangetext.Text = pricerange;
        }

        private void SerStoreButton_Click(object sender, EventArgs e)
        {
            ViewProfileClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
