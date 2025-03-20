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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OOP2
{
    public partial class ClientDashboard : Form
    {
        bool dbp1 = false, dbp2 = false;
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
        public ClientDashboard()
        {
            InitializeComponent();
            Loaders();
            dbp1 = true;
            dbp2 = false;
            DashboardPanel.Visible = true;
            DashboardPanel2.Visible = false;
            DashboardButton.BackColor = ColorTranslator.FromHtml("#69e331");
            Dbutton.BackColor = ColorTranslator.FromHtml("#69e331");
            ServicesPanel.Visible = false;
            SerPanel.Visible = false;
            SerButton.Visible = false;
        }

        public void Loaders()
        {
            //DASHBOARD
            DashboardPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardPanel.Width, DashboardPanel.Height, 20, 20));
            DashboardPanel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardPanel2.Width, DashboardPanel2.Height, 20, 20));
            DashboardButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardButton.Width, DashboardButton.Height, 10, 10));
            Dbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Dbutton.Width, Dbutton.Height, 20, 20));
            ServicesButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ServicesButton.Width, ServicesButton.Height, 10, 10));
            SButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SButton.Width, SButton.Height, 20, 20));
            CalendarButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CalendarButton.Width, CalendarButton.Height, 10, 10));
            CButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CButton.Width, CButton.Height, 20, 20));
            ProfileButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProfileButton.Width, ProfileButton.Height, 10, 10));
            PButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PButton.Width, PButton.Height, 20, 20));
            SettingsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SettingsButton.Width, SettingsButton.Height, 10, 10));
            StButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, StButton.Width, StButton.Height, 20, 20));
            HelpButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HelpButton.Width, HelpButton.Height, 10, 10));
            HButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HButton.Width, HButton.Height, 20, 20));
            LogoutButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogoutButton.Width, LogoutButton.Height, 10, 10));
            LButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LButton.Width, LButton.Height, 20, 20));
            SearchButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SearchButton.Width, SearchButton.Height, 10, 10));
            SearchPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SearchPanel.Width, SearchPanel.Height, 10, 10));
            LogoButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogoButton.Width, LogoButton.Height, 10, 10));
            LogosButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogosButton.Width, LogosButton.Height, 10, 10));
            AppointmentPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppointmentPanel.Width, AppointmentPanel.Height, 10, 10));
            MonthPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MonthPanel.Width, MonthPanel.Height, 10, 10));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 10, 10));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 10, 10));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 10, 10));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 10, 10));
            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 10, 10));
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 10, 10));
            panel10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel10.Width, panel10.Height, 10, 10));
            panel12.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel12.Width, panel12.Height, 30, 30));
            panel14.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel14.Width, panel14.Height, 30, 30));
            panel16.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel16.Width, panel16.Height, 30, 30));
            panel11.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel11.Width, panel11.Height, 10, 10));
            panel13.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel13.Width, panel13.Height, 10, 10));
            panel15.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel15.Width, panel15.Height, 10, 10));
            SignInButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SignInButton.Width, SignInButton.Height, 10, 10));
            button11.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button11.Width, button11.Height, 10, 10));
            button12.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button12.Width, button12.Height, 10, 10));
            //SERVICES
            ServicesPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ServicesPanel.Width, ServicesPanel.Height, 10, 10));
            BeautySPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BeautySPanel.Width, BeautySPanel.Height, 10, 10));
            HealthSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HealthSPanel.Width, HealthSPanel.Height, 10, 10));
            FitnessSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FitnessSPanel.Width, FitnessSPanel.Height, 10, 10));
            EduSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EduSPanel.Width, EduSPanel.Height, 10, 10));
            RepairSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, RepairSPanel.Width, RepairSPanel.Height, 10, 10));
            FoodSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FoodSPanel.Width, FoodSPanel.Height, 10, 10));
            MisSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MisSPanel.Width, MisSPanel.Height, 10, 10));
            button13.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button13.Width, button13.Height, 10, 10));
            button15.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button15.Width, button15.Height, 10, 10));
            button17.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button17.Width, button17.Height, 10, 10));
            button19.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button19.Width, button19.Height, 10, 10));
            button23.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button23.Width, button23.Height, 10, 10));
            button21.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button21.Width, button21.Height, 10, 10));
            button25.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button25.Width, button25.Height, 10, 10));
            //SERVICES 2
            SerPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SerPanel.Width, SerPanel.Height, 10, 10));

        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseHover(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.BackColor = ColorTranslator.FromHtml("#f7fff3");
        }

        private void MaximizeButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#81eedf");
        }

        private void MaximizeButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#f7fff3");
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            Loaders();

        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Loaders();
        }

        private void MinimizeButton_MouseHover(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#81eedf");
        }

        private void LogoButton_Click(object sender, EventArgs e)
        {
            dbp1 = false;
            dbp2 = true;
            DashboardPanel.Visible = false;
            panel1.Visible = false;
            DashboardPanel2.Visible = true;
            HeaderPanel.Location = new Point(90,44);
            //HiLabel.Location = new Point(105, 51);
            //WelcomeLabel.Location = new Point(102, 76);
        }

        private void LogosButton_Click(object sender, EventArgs e)
        {
            dbp1 = true;
            dbp2 = false;
            DashboardPanel.Visible = true;
            panel1.Visible = true;
            DashboardPanel2.Visible = false;
            HeaderPanel.Location = new Point(193, 44);
            //HiLabel.Location = new Point(272, 51);
            //WelcomeLabel.Location = new Point(269, 76);

        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = ColorTranslator.FromHtml("#d9faf5");
            panel4.BackColor = Color.White;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            panel4.BackColor = ColorTranslator.FromHtml("#d2f7c1");
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = ColorTranslator.FromHtml("#d9faf5");
            panel6.BackColor = Color.White;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.White;
            panel6.BackColor = ColorTranslator.FromHtml("#d2f7c1");
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            panel7.BackColor = ColorTranslator.FromHtml("#d9faf5");
            panel8.BackColor = Color.White;
        }
        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.White;
            panel8.BackColor = ColorTranslator.FromHtml("#d2f7c1");
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientLogin clientLogin = new ClientLogin();
            clientLogin.ShowDialog();
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientLogin clientLogin = new ClientLogin();
            clientLogin.ShowDialog();
        }

        private void ServicesButton_Click(object sender, EventArgs e)
        {
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Text = "Services";
            ServicesPanel.Visible = true;
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            ServicesButton.BackColor = ColorTranslator.FromHtml("#69e331");
            SButton.BackColor = ColorTranslator.FromHtml("#69e331");
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            AppointmentPanel.Visible = true;
            panel3.Visible = true;
            HiLabel.Visible = true;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Welcome ServEase!";
            //SERVICES
            ServicesPanel.Visible = false;
            DashboardButton.BackColor = ColorTranslator.FromHtml("#69e331");
            Dbutton.BackColor = ColorTranslator.FromHtml("#69e331");
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = false;
            SerButton.Visible = true;
            SerPanel.Visible = true;
            ServicesPanel.Visible = false;
        }

        private void SerButton_Click(object sender, EventArgs e)
        {
            SerPanel.Visible = false;
            SerButton.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible= true;
            WelcomeLabel.Text = "Services";
            ServicesPanel.Visible = true;
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            ServicesButton.BackColor = ColorTranslator.FromHtml("#69e331");
            SButton.BackColor = ColorTranslator.FromHtml("#69e331");
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#f7fff3");
        }

    }
}
