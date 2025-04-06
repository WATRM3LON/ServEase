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
    public partial class UsersPanel : UserControl
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
        public UsersPanel()
        {
            InitializeComponent();
        }

        public void Loaders()
        {
            ViewDetailsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ViewDetailsButton.Width, ViewDetailsButton.Height, 10, 10));
        }

        public void SetDataClient(string Name, string Emailaddress)
        {
            UserNamelabel.Location = new Point(79, 26);
            UserNamelabel.Text = "Name:";
            UserNametext.Text = Name;
            UserEmailtext.Text = Emailaddress;
        }
        public void SetInfo(string Status, string Regist)
        {
            UserStatustext.Text = Status;
            if (Status == "Active")
            {
                UserStatustext.ForeColor = Color.LawnGreen;
            }
            else
            {
                UserStatustext.ForeColor = Color.Red;
            }
            UserRegisttext.Text = Regist;
        }
        public void SetDataFacility(string Name, string Emailaddress)
        {
            UserNamelabel.Location = new Point(39, 26);
            UserNamelabel.Text = "Facility Name:";
            UserNametext.Text = Name;
            UserEmailtext.Text = Emailaddress;
        }
        public event EventHandler ViewDetailsClicked;

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            ViewDetailsClicked?.Invoke(this, EventArgs.Empty);
        }
        public int ClientId { get; set; }
        public int FacilityId { get; set; }
    }
}
