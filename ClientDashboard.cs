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
        //ClientLogin.EmailAddress;

        bool dbp1 = false, dbp2 = false, notify = false, dashboard, services, ser, profile, calendar;
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
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            AppointmentsPanel.Visible = false;
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            ProfilePanel.Visible = false;
            NotificationPanel.Visible = false;
            SettingPanel.Visible = false;
            panel44.Visible = false;
            FacilityProPanel.Visible = false;
            FPButton.Visible = false;
            FacilityProPanel2.Visible = false;
        }

        public void Loaders()
        {
            NotificationPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, NotificationPanel.Width, NotificationPanel.Height, 10, 10));
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
            panel48.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel48.Width, panel48.Height, 10, 10));
            panel47.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel47.Width, panel47.Height, 10, 10));
            EditButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EditButton.Width, EditButton.Height, 10, 10));
            BAPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BAPanel.Width, BAPanel.Height, 10, 10));
            panel93.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel93.Width, panel93.Height, 10, 10));
            panel71.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel71.Width, panel71.Height, 10, 10));
            //Calendar
            CalendarPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CalendarPanel.Width, CalendarPanel.Height, 10, 10));
            calendarsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, calendarsButton.Width, calendarsButton.Height, 10, 10));
            //Appointment
            AppointmentsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppointmentsPanel.Width, AppointmentsPanel.Height, 10, 10));
            appointmentsbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, appointmentsbutton.Width, appointmentsbutton.Height, 10, 10));
            button43.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button43.Width, button43.Height, 10, 10));
            button44.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button44.Width, button44.Height, 10, 10));
            button45.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button45.Width, button45.Height, 10, 10));
            panel39.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel39.Width, panel39.Height, 10, 10));
            panel40.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel40.Width, panel40.Height, 10, 10));
            panel41.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel41.Width, panel41.Height, 10, 10));
            panel42.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel42.Width, panel42.Height, 10, 10));
            panel43.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel43.Width, panel43.Height, 10, 10));
            panel38.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel38.Width, panel38.Height, 10, 10));
            panel44.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel44.Width, panel44.Height, 10, 10));
            //APPOINTMENT DETAILS
            AstoreproPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AstoreproPanel.Width, AstoreproPanel.Height, 10, 10));
            AstatPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AstatPanel.Width, AstatPanel.Height, 10, 10));
            ReschedButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ReschedButton.Width, ReschedButton.Height, 10, 10));
            AproPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AproPanel.Width, AproPanel.Height, 10, 10));
            //PROFILE
            ProPicPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProPicPanel.Width, ProPicPanel.Height, 10, 10));
            PIPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIPanel.Width, PIPanel.Height, 10, 10));
            GPPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, GPPanel.Width, GPPanel.Height, 10, 10));
            PIEditButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIEditButton.Width, PIEditButton.Height, 10, 10));
            button48.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button48.Width, button48.Height, 10, 10));
            button49.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button49.Width, button49.Height, 10, 10));
            button60.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button60.Width, button60.Height, 10, 10));
            //SETTINGS
            GeneralPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, GeneralPanel.Width, GeneralPanel.Height, 10, 10));
            AppearancePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppearancePanel.Width, AppearancePanel.Height, 10, 10));
            NotsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, NotsPanel.Width, NotsPanel.Height, 10, 10));
            AccsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AccsPanel.Width, AccsPanel.Height, 10, 10));
            PrivPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PrivPanel.Width, PrivPanel.Height, 10, 10));
            AccessPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AccessPanel.Width, AccessPanel.Height, 10, 10));
            AboutPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AboutPanel.Width, AboutPanel.Height, 10, 10));
            HelpPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HelpPanel.Width, HelpPanel.Height, 10, 10));
            panel45.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel45.Width, panel45.Height, 10, 10));

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
            CloseButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
        }

        private void MaximizeButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#81eedf");
        }

        private void MaximizeButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
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
        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
        }

        private void LogoButton_Click(object sender, EventArgs e)
        {
            dbp1 = false;
            dbp2 = true;
            DashboardPanel.Visible = false;
            panel1.Visible = true;
            DashboardPanel2.Visible = true;
            HeaderPanel.Location = new Point(75, 44);
            panel44.Visible = true;
        }

        private void LogosButton_Click(object sender, EventArgs e)
        {
            dbp1 = true;
            dbp2 = false;
            DashboardPanel.Visible = true;
            panel1.Visible = true;
            DashboardPanel2.Visible = false;
            HeaderPanel.Location = new Point(190, 44);
            panel44.Visible = false;
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
        private void NotifyButton_Click(object sender, EventArgs e)
        {

            if (notify == false)
            {
                NotificationPanel.Visible = true;
                NotifyButton.BackColor = Color.White;
                notify = true;
            }
            else
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }

        }
        private void NotiCloseButton_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = false;
            notify = false;
        }

        private void ServicesButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Services";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            SearchPanel.Visible = true;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = true;
            ServicesButton.BackColor = ColorTranslator.FromHtml("#69e331");
            SButton.BackColor = ColorTranslator.FromHtml("#69e331");
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = Color.White;
            CButton.BackColor = Color.White;
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.System;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.Flat;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = true;
            panel3.Visible = true;
            HiLabel.Visible = true;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Welcome ServEase!";
            DashboardButton.BackColor = ColorTranslator.FromHtml("#69e331");
            Dbutton.BackColor = ColorTranslator.FromHtml("#69e331");
            SearchPanel.Visible = true;
            panel45.Visible = true;
            //SERVICES
            ServicesPanel.Visible = false;
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = Color.White;
            CButton.BackColor = Color.White;
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.System;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.Flat;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = false;
            SerButton.Visible = true;
            SerPanel.Visible = true;
            ServicesPanel.Visible = false;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void DashboardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SerStoreButton1_Click(object sender, EventArgs e)
        {
            //PROFILE
            FacilityProPanel.Visible = true;
            FPButton.Visible = true;
            FacilityProPanel2.Visible = false;
            SerButton.Visible = false;
            SerPanel.Visible = false;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void FPButton_Click(object sender, EventArgs e)
        {
            //PROFILE
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            SerButton.Visible = true;
            SerPanel.Visible = true;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void label152_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = true;
            FPButton.Visible = true;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void SerButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Services";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = true;
            ServicesButton.BackColor = ColorTranslator.FromHtml("#69e331");
            SButton.BackColor = ColorTranslator.FromHtml("#69e331");
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            AppointmentsPanel.Visible = false;
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            SearchPanel.Visible = false;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = false;
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = true;
            CalendarPanel.Visible = true;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#69e331");
            CButton.BackColor = ColorTranslator.FromHtml("#69e331");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.System;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.Flat;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void appointmentsbutton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = false;
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = true;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#69e331");
            CButton.BackColor = ColorTranslator.FromHtml("#69e331");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.Flat;
            //Appointment
            AppointmentsPanel.Visible = true;
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = false;
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = true;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#69e331");
            CButton.BackColor = ColorTranslator.FromHtml("#69e331");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.Flat;
            //Appointment
            AppointmentsPanel.Visible = true;
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = false;
            button41.Visible = true;
            AppointmentsPanel.Visible = false;
            CalendarAppointmentPanel.Visible = false;
            ViewdetailsPanel.Visible = true;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }


        private void ProfileButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Profile";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = false;
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = Color.White;
            CButton.BackColor = Color.White;
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.Flat;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#69e331");
            PButton.BackColor = ColorTranslator.FromHtml("#69e331");
            //SETTINGS
            SettingPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel3.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Settings";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            panel45.Visible = false;
            //SERVICES
            ServicesPanel.Visible = false;
            ServicesButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //SERVICES2
            SerButton.Visible = false;
            SerPanel.Visible = false;
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = false;
            FPButton.Visible = false;
            //CALENDAR
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = Color.White;
            CButton.BackColor = Color.White;
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.Flat;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SETTINGS
            SettingPanel.Visible = true;
            SettingsButton.BackColor = ColorTranslator.FromHtml("#69e331");
            StButton.BackColor = ColorTranslator.FromHtml("#69e331");
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void HiLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
