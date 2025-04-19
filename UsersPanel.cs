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
        public void SetDataClient(string Name, string Emailaddress)
        {
            UserRegistlabel.Text = "Date Registered: "; UserRegistlabel.Location = new Point(375, 45);
            UserNamelabel.Location = new Point(79, 26);
            UserNamelabel.Text = "Name:";
            UserEmaillabel.Text = "Email Addres:";
            UserNametext.Text = Name;
            UserEmailtext.Text = Emailaddress; ViewDetailsButton.Visible = true;
            ViewDetailsButton.BackColor = ColorTranslator.FromHtml("#69e331");
            ViewDetailsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ViewDetailsButton.Width, ViewDetailsButton.Height, 10, 10));
        }
        
        public void SetDataFacility(string Name, string Emailaddress)
        {
            UserRegistlabel.Text = "Date Registered: "; UserRegistlabel.Location = new Point(375, 45);
            UserNamelabel.Location = new Point(39, 26);
            UserNamelabel.Text = "Facility Name:";
            UserEmaillabel.Text = "Email Addres:";
            UserNametext.Text = Name;
            UserEmailtext.Text = Emailaddress; ViewDetailsButton.Visible = true;
            ViewDetailsButton.BackColor = ColorTranslator.FromHtml("#f3508b");
            ViewDetailsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ViewDetailsButton.Width, ViewDetailsButton.Height, 10, 10));
        }

        //ADMIN//
        public void SetAppHistory(string Name, string FLocation)
        {
            UserRegistlabel.Text = "Appointment Date: "; UserRegistlabel.Location = new Point(360, 45);
            UserNamelabel.Location = new Point(39, 26);
            UserNamelabel.Text = "Facility Name:";
            UserNametext.Text = Name;
            UserEmaillabel.Location = new Point(43, 45);
            UserEmaillabel.Text = "Date Booked: ";
            UserEmailtext.Text = FLocation; ViewDetailsButton.Visible = false;
            ViewDetailsButton.BackColor = ColorTranslator.FromHtml("#22b0e5");
        }
        public void SetInfo(string Status, string Regist)
        {
            UserStatustext.Text = Status;
            if (Status == "Confirmed")
            {
                UserStatustext.ForeColor = Color.LawnGreen;
            }
            else if (Status == "Pending")
            {
                UserStatustext.ForeColor = Color.Gold;
            }
            else if (Status == "Completed")
            {
                UserStatustext.ForeColor = ColorTranslator.FromHtml("#69e331");
            }
            else if (Status == "Cancelled")
            {
                UserStatustext.ForeColor = Color.Red;
            }
            else
            {
                UserStatustext.ForeColor = Color.Red;
            }
            UserRegisttext.Text = Regist;
        }

        //CLIENT//
        public void CLientApp(string Name, string FLocation)
        {
            UserRegistlabel.Text = "Appointment Date: "; UserRegistlabel.Location = new Point(360, 45);
            UserNamelabel.Location = new Point(39, 26);
            UserNamelabel.Text = "Facility Name:";
            UserNametext.Text = Name;
            UserEmaillabel.Location = new Point(43, 45);
            UserEmaillabel.Text = "Date Booked: ";
            UserEmailtext.Text = FLocation; ViewDetailsButton.Visible = true;
            ViewDetailsButton.BackColor = ColorTranslator.FromHtml("#d9faf5");
            ViewDetailsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ViewDetailsButton.Width, ViewDetailsButton.Height, 10, 10));
        }
        public void ClientInfo(string Status, string Regist)
        {
            UserStatustext.Text = Status;
            if (Status == "Confirmed")
            {
                UserStatustext.ForeColor = Color.LawnGreen;
            }
            else if (Status == "Pending")
            {
                UserStatustext.ForeColor = Color.Gold;
            }
            else if (Status == "Completed")
            {
                UserStatustext.ForeColor = ColorTranslator.FromHtml("#69e331");
            }
            else if (Status == "Cancelled")
            {
                UserStatustext.ForeColor = Color.Red;
            }
            else
            {
                UserStatustext.ForeColor = Color.Red;
            }
            UserRegisttext.Text = Regist;
        }

        //FACILITY//
        public void DataClient(string Name, string Emailaddress)
        {
            UserRegistlabel.Text = "Appointment Date: "; UserRegistlabel.Location = new Point(360, 45);
            UserNamelabel.Location = new Point(50, 26);
            UserNamelabel.Text = "Name:";
            UserNametext.Text = Name;
            UserEmaillabel.Location = new Point(43, 45);
            UserEmaillabel.Text = "Date Booked: ";
            UserEmailtext.Text = Emailaddress; ViewDetailsButton.Visible = true;
            ViewDetailsButton.BackColor = ColorTranslator.FromHtml("#d5fcef");
            ViewDetailsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ViewDetailsButton.Width, ViewDetailsButton.Height, 10, 10));
        }
        public void AppInfo(string Status, string Regist)
        {
            UserStatustext.Text = Status;
            if (Status == "Confirmed")
            {
                UserStatustext.ForeColor = Color.LawnGreen;
            }
            else if (Status == "Pending")
            {
                UserStatustext.ForeColor = Color.Gold;
            }
            else if (Status == "Completed")
            {
                UserStatustext.ForeColor = ColorTranslator.FromHtml("#69e331");
            }
            else if (Status == "Cancelled")
            {
                UserStatustext.ForeColor = Color.Red;
            }
            else
            {
                UserStatustext.ForeColor = Color.Red;
            }
            UserRegisttext.Text = Regist;
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
