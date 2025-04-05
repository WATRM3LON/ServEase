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

        public void SetData(string Name, string Emailaddress)
        {
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
        private void button45_Click(object sender, EventArgs e)
        {

        }
    }
}
