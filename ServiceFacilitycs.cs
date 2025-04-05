using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OOP2
{
    public partial class ServiceFacilitycs : Form, ClientInfo, FacilityInfo
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

        string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\OOP2 Database - Copy.accdb";

        bool status = false, notify = false;
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

        string formattedWorHours = "";
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string LocationAddress { get; set; }
        public string Sex { get; set; }
        public int count { get; set; }
        public string Facname { get; set; }
        public string SerCat { get; set; }
        public DateTime WorHours { get; set; }
        public string WorDays { get; set; }
        public string Ratings { get; set; }
        public string AppStatus { get; set; }
        public DateTime workingstart;
        public DateTime workingend;

        public ServiceFacilitycs()
        {
            InitializeComponent();
            InfoGetter();
            Loaders();
            HiLabel.Text = $"Hi {Facname},";
            DashboardPanel.Visible = true;
            DashboardPanel2.Visible = false;
            AppointmentsPanel.Visible = false;
            ViewdetailsPanel.Visible = false;
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            StatusPanel.Visible = false;
            AppointmentPanel.Visible = true;
            panel11.Visible = true;
            panel45.Visible = true;
            DashboardButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            Dbutton.BackColor = ColorTranslator.FromHtml("#f0246e");
            button41.Visible = false;
            SerButton.Visible = false;
            panel44.Visible = false;
            NotificationPanel.Visible = false;
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel2.Visible = false;
            AnalyticPannel1.Visible = false;
            ProfilePanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            ServicesOfferedPanel.Visible = false;
            SettingsPanel.Visible = false;
            FIEButton.Visible = false; FillEM.Visible = false; ESerOffPanel.Visible = false; EditSOButton.Visible = false;
            EditFIPanel.Visible = false; CnumberExisted.Visible = false; CnumberInvalid.Visible = false;
        }

        public void Loaders()
        {
            //SIDEBAR
            NotificationPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, NotificationPanel.Width, NotificationPanel.Height, 10, 10));
            DashboardPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardPanel.Width, DashboardPanel.Height, 20, 20));
            DashboardPanel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardPanel2.Width, DashboardPanel2.Height, 20, 20));
            DashboardButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardButton.Width, DashboardButton.Height, 10, 10));
            Dbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Dbutton.Width, Dbutton.Height, 20, 20));
            AnalyticsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AnalyticsButton.Width, AnalyticsButton.Height, 10, 10));
            SButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SButton.Width, SButton.Height, 20, 20));
            CalendarButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CalendarButton.Width, CalendarButton.Height, 10, 10));
            CButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CButton.Width, CButton.Height, 20, 20));
            ProfileButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProfileButton.Width, ProfileButton.Height, 10, 10));
            PButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PButton.Width, PButton.Height, 20, 20));
            SettingsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SettingsButton.Width, SettingsButton.Height, 10, 10));
            StButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, StButton.Width, StButton.Height, 20, 20));
            LogoutButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogoutButton.Width, LogoutButton.Height, 10, 10));
            LButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LButton.Width, LButton.Height, 20, 20));
            LogoButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogoButton.Width, LogoButton.Height, 10, 10));
            LogosButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogosButton.Width, LogosButton.Height, 10, 10));
            //DASHBOARD
            AppointmentPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppointmentPanel.Width, AppointmentPanel.Height, 10, 10));
            MonthPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MonthPanel.Width, MonthPanel.Height, 10, 10));
            panel9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel9.Width, panel9.Height, 10, 10));
            panel10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel10.Width, panel10.Height, 10, 10));
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 10, 10));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 10, 10));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 10, 10));
            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 10, 10));
            panel45.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel45.Width, panel45.Height, 10, 10));
            panel11.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel11.Width, panel11.Height, 10, 10));
            //CALENDAR
            CalendarPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CalendarPanel.Width, CalendarPanel.Height, 10, 10));
            calendarsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, calendarsButton.Width, calendarsButton.Height, 10, 10));
            //APPOINTMENT
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
            StatusPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, StatusPanel.Width, StatusPanel.Height, 10, 10));
            DownButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DownButton.Width, DownButton.Height, 10, 10));
            //ANALYTICS
            AnalyticPannel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AnalyticPannel1.Width, AnalyticPannel1.Height, 10, 10));
            AnalyticPannel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AnalyticPannel2.Width, AnalyticPannel2.Height, 10, 10));
            //PROFILE
            ProPicPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProPicPanel.Width, ProPicPanel.Height, 10, 10));
            FIStatus.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FIStatus.Width, FIStatus.Height, 10, 10));
            FIEProfilepanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FIEProfilepanel.Width, FIEProfilepanel.Height, 10, 10));
            FIEPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FIEPanel.Width, FIEPanel.Height, 10, 10));
            FIEStatus.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FIEStatus.Width, FIEStatus.Height, 10, 10));
            CUIButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CUIButton.Width, CUIButton.Height, 10, 10));
            PIPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIPanel.Width, PIPanel.Height, 10, 10));
            SOAPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOAPanel.Width, SOAPanel.Height, 10, 10));
            ServicesOfferedPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ServicesOfferedPanel.Width, ServicesOfferedPanel.Height, 10, 10));
            SOView.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOView.Width, SOView.Height, 10, 10));
            ATView.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATView.Width, ATView.Height, 10, 10));
            button8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 10, 10));
            button8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 10, 10));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 10, 10));
            //SERVICES OFFRED
            //SOTable.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 10, 10));
            panel32.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel32.Width, panel32.Height, 10, 10));
            panel31.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel31.Width, panel31.Height, 10, 10));
            EditButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EditButton.Width, EditButton.Height, 10, 10));
            EditButton2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EditButton2.Width, EditButton2.Height, 10, 10));
            //SETTINGS
            GeneralPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, GeneralPanel.Width, GeneralPanel.Height, 10, 10));
            AppearancePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppearancePanel.Width, AppearancePanel.Height, 10, 10));
            NotsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, NotsPanel.Width, NotsPanel.Height, 10, 10));
            AccsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AccsPanel.Width, AccsPanel.Height, 10, 10));
            PrivPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PrivPanel.Width, PrivPanel.Height, 10, 10));
            AccessPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AccessPanel.Width, AccessPanel.Height, 10, 10));
            AboutPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AboutPanel.Width, AboutPanel.Height, 10, 10));
            HelpPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HelpPanel.Width, HelpPanel.Height, 10, 10));
            DeleteAccButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DeleteAccButton.Width, DeleteAccButton.Height, 10, 10));
            //panel45.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel45.Width, panel45.Height, 10, 10));
            //INFOSETTER
            FIFnameTitle.Text = FIEFnameTitle.Text = FIEFacnametext.Text = FIEFacnametext.Text = FIFnametext.Text = Facname;
            FIRatingstext.Text = FIERatingstext.Text = Ratings;
            FILoctext.Text = FIELoctext.Text = LocationAddress;
            FIEOFnametext.Text = FName; FIEOLnametext.Text = LName;
            FISerCattext.Text = SerCat; FIWorhourstext.Text = formattedWorHours; FIEStarttext.Text = workingstart == DateTime.MinValue ? "" : workingstart.ToString("hh:mm tt");
            FIEEndtext.Text = workingend == DateTime.MinValue ? "" : workingend.ToString("hh:mm tt");
            FIWordaystext.Text = FIEWordaystext.Text = WorDays;
            FICnumbertext.Text = FIECnumbertext.Text = ContactNumber;
            FIEmailtext.Text = FIEEmailaddtext.Text = EmailAddress;
            FIStatus.Text = FIEStatus.Text = AppStatus;
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
            CloseButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
        }

        private void MaximizeButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#81eedf");
        }

        private void MaximizeButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
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
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
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
                NotifyButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
                notify = false;
            }

        }
        private void NotiCloseButton_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = false;
            notify = false;
        }

        private void LogoButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            panel1.Visible = true;
            DashboardPanel2.Visible = true;
            HeaderPanel.Location = new Point(75, 44);
            panel44.Visible = true;
        }

        private void LogosButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = true;
            panel1.Visible = true;
            DashboardPanel2.Visible = false;
            HeaderPanel.Location = new Point(190, 44);
            panel44.Visible = false;
        }


        private void DashboardButton_Click(object sender, EventArgs e)
        {
            InfoGetter();
            Loaders();
            //DASHBOARD
            AppointmentPanel.Visible = true;
            panel11.Visible = true;
            panel45.Visible = true;
            HiLabel.Visible = true; HiLabel.Text = $"Hi {Facname},";
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Welcome ServEase!";
            DashboardButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            Dbutton.BackColor = ColorTranslator.FromHtml("#f0246e");
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
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticPannel2.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            //SOAPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
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
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            //CALENDAR
            CalendarAppointmentPanel.Visible = true;
            CalendarPanel.Visible = true;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            CButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.System;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.Flat;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticPannel2.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
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
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            //CALENDAR
            CalendarAppointmentPanel.Visible = true;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            CButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.Flat;
            //Appointment
            AppointmentsPanel.Visible = true;
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticPannel2.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
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
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                StatusPanel.Visible = true;
                status = true;
            }
            else
            {
                StatusPanel.Visible = false;
                status = false;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            //CALENDAR
            CalendarAppointmentPanel.Visible = true;
            CalendarPanel.Visible = false;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            CButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.Flat;
            //Appointment
            AppointmentsPanel.Visible = true;
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            button41.Visible = false;
            ViewdetailsPanel.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void AnalyticsButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Analytics";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
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
            //ANALYTICS
            AnalyticsMenuPanel.Visible = true;
            AnalyticPannel1.Visible = true;
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold); BFButton.FlatStyle = FlatStyle.System;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.Flat;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); PSButton.FlatStyle = FlatStyle.Flat;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void CGRButton_Click(object sender, EventArgs e)
        {
            AnalyticsMenuPanel.Visible = true;
            AnalyticPannel1.Visible = false;
            AnalyticPannel2.Visible = true;
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); BFButton.FlatStyle = FlatStyle.Flat;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.System;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); PSButton.FlatStyle = FlatStyle.Flat;
            //SETTINGS
            SettingsPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void PSButton_Click(object sender, EventArgs e)
        {
            AnalyticsMenuPanel.Visible = true;
            AnalyticPannel1.Visible = true;
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); BFButton.FlatStyle = FlatStyle.Flat;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.Flat;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold); PSButton.FlatStyle = FlatStyle.System;
            //SETTINGS
            SettingsPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            InfoGetter();
            Loaders();
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Profile";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
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
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); BFButton.FlatStyle = FlatStyle.Flat;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.Flat;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); PSButton.FlatStyle = FlatStyle.Flat;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }


        private void SOView_Click(object sender, EventArgs e)
        {
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = true;
            WelcomeLabel.Visible = false;
            SOButton.Visible = true;
            ATPanel.Visible = false;
            ATButton.Visible = false;

        }

        private void ATView_Click(object sender, EventArgs e)
        {
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            WelcomeLabel.Visible = false;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = true;
            ATButton.Visible = true;
        }

        private void SOButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Profile";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
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
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); BFButton.FlatStyle = FlatStyle.Flat;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.Flat;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); PSButton.FlatStyle = FlatStyle.Flat;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
            SettingsButton.BackColor = Color.White;
            StButton.BackColor = Color.White;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void ATButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Profile";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
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
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); BFButton.FlatStyle = FlatStyle.Flat;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.Flat;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); PSButton.FlatStyle = FlatStyle.Flat;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = false;
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
            panel11.Visible = false;
            panel45.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Settings";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
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
            //ANALYTICS
            AnalyticsMenuPanel.Visible = false;
            AnalyticPannel1.Visible = false;
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            BFButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); BFButton.FlatStyle = FlatStyle.Flat;
            CGRButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); CGRButton.FlatStyle = FlatStyle.Flat;
            PSButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold); PSButton.FlatStyle = FlatStyle.Flat;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            //SETTINGS
            SettingsPanel.Visible = true;
            SettingsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            StButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServiceFacilityLogin serviceFacilityLogin = new ServiceFacilityLogin();
            serviceFacilityLogin.ShowDialog();
        }

        private void ServiceFacilitycs_Load(object sender, EventArgs e)
        {

        }

        public void InfoGetter()
        {
            EmailAddress = ServiceFacilityLogin.EmailAddress;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT [Facility Name], [Facility Location], [Owner First Name], [Owner Last Name], [Contact Number], [Password], [Service Category], [Working Hours Start], [Working Hours End], [Working Days], Ratings, [Approval Status] FROM [Service Facilities] WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@Email", EmailAddress);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Facname = reader["Facility Name"].ToString();
                            FName = reader["Owner First Name"].ToString();
                            LName = reader["Owner Last Name"].ToString();
                            workingstart = reader.IsDBNull(reader.GetOrdinal("Working Hours Start")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours Start"));
                            workingend = reader.IsDBNull(reader.GetOrdinal("Working Hours End")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours End"));
                            formattedWorHours = (workingstart == DateTime.MinValue || workingend == DateTime.MinValue) ? " " : $"{workingstart:hh\\:mm tt} - {workingend:hh\\:mm tt}";
                            WorDays = reader["Working Days"].ToString();
                            Password = reader["Password"].ToString();
                            ContactNumber = reader["Contact Number"].ToString();
                            LocationAddress = reader.IsDBNull(reader.GetOrdinal("Facility Location")) ? " " : reader["Facility Location"].ToString();
                            SerCat = reader["Service Category"].ToString();
                            AppStatus = reader["Approval Status"].ToString();

                        }
                    }
                }
            }

        }

        public void UpdateInfo()
        {
            EmailAddress = ServiceFacilityLogin.EmailAddress;

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "UPDATE [Service Facilities] SET [Facility Name] = @FacilityName, [Facility Location] = @FLocation, [Owner First Name] = @OFName, [Owner Last Name] = @OLName, [Contact Number] = @CNumber, [Service Category] = @Servicecategory, [Working Hours Start] = @Workinghoursstart, [Working Hours End] = @Workinghoursend, [Working Days] = @Workingdays WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@FacilityName", FIEFacnametext.Text);
                    cmd.Parameters.AddWithValue("@FLocation", FIELoctext.Text);
                    cmd.Parameters.AddWithValue("@OFName", FIEOFnametext.Text);
                    cmd.Parameters.AddWithValue("@OLName", FIEOLnametext.Text);
                    cmd.Parameters.AddWithValue("@CNumber", FIECnumbertext.Text);
                    string service = FIESerCatList.GetItemText(FIESerCatList.SelectedItem);
                    cmd.Parameters.AddWithValue("@Servicecategory", service);
                    cmd.Parameters.AddWithValue("@Workinghoursstart", FIEStarttext.Text);
                    cmd.Parameters.AddWithValue("@Workinghoursend", FIEEndtext.Text);
                    cmd.Parameters.AddWithValue("@Workingdays", FIEWordaystext.Text);
                    cmd.Parameters.AddWithValue("@Email", FIEEmailaddtext.Text);
                    cmd.ExecuteNonQuery();

                }

                int newFacilityId = 0;
                using (OleDbCommand getIdCmd = new OleDbCommand("SELECT @@IDENTITY", myConn))
                {
                    object result = getIdCmd.ExecuteScalar();
                    newFacilityId = Convert.ToInt32(result);
                }

                string AdminQuery = "UPDATE [Admin (Service Facilities)] SET [Facility Name] = @FacilityName, [Facility Location] = @FLocation, [Owner First Name] = @OFName, [Owner Last Name] = @OLName, [Contact Number] = @CNumber, [Service Category] = @Servicecategory, [Working Hours Start] = @Workinghoursstart, [Working Hours End] = @Workinghoursend, [Working Days] = @Workingdays WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(AdminQuery, myConn))
                {
                    cmd.Parameters.AddWithValue("@FacilityName", FIEFacnametext.Text);
                    cmd.Parameters.AddWithValue("@FLocation", FIELoctext.Text);
                    cmd.Parameters.AddWithValue("@OFName", FIEOFnametext.Text);
                    cmd.Parameters.AddWithValue("@OLName", FIEOLnametext.Text);
                    cmd.Parameters.AddWithValue("@CNumber", FIECnumbertext.Text);
                    string service = FIESerCatList.GetItemText(FIESerCatList.SelectedItem);
                    cmd.Parameters.AddWithValue("@Servicecategory", service);
                    cmd.Parameters.AddWithValue("@Workinghoursstart", FIEStarttext.Text);
                    cmd.Parameters.AddWithValue("@Workinghoursend", FIEEndtext.Text);
                    cmd.Parameters.AddWithValue("@Workingdays", FIEWordaystext.Text);
                    cmd.Parameters.AddWithValue("@Email", FIEEmailaddtext.Text);
                    cmd.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Updated successfully!");
            }
        }

        public bool CNumberChecker(string Cnumber, string connection)
        {
            int valid = 0;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT COUNT(*) FROM Clients WHERE [Contact Number] = @cnumber";
                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@cnumber", Cnumber);
                    count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        CnumberExisted.Visible = true;
                        FIECnumbertext.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        valid++;
                    }
                }
            }
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT COUNT(*) FROM [Service Facilities] WHERE [Contact Number] = @cnumber";
                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@cnumber", Cnumber);
                    count = (int)cmd.ExecuteScalar();

                    if (count > 1)
                    {
                        CnumberExisted.Visible = true;
                        FIECnumbertext.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        valid++;
                    }
                }
            }
            if (FIECnumbertext.Text.Length != 11 || !FIECnumbertext.Text.StartsWith("09") || !FIECnumbertext.Text.All(char.IsDigit))
            {
                CnumberExisted.Visible = false; CnumberInvalid.Visible = true;
                FIECnumbertext.BackColor = Color.MistyRose;
            }
            else
            {
                valid++;
            }

            if (valid == 3)
            {
                return true;
            }
            else { return false; }
        }

        private void CUIButton_Click(object sender, EventArgs e)
        {
            FillEM.Visible = false;
            bool cnumberValid = CNumberChecker(FIECnumbertext.Text, connection);

            if (FIELoctext.Text.Length != 0 && FIEFacnametext.Text.Length != 0 && FIEWordaystext.Text.Length != 0 && FIEStarttext.Text.Length != 0 && FIEEndtext.Text.Length != 0 && cnumberValid)
            {
                UpdateInfo();
            }
            else if (FIELoctext.Text.Length == 0 && FIEFacnametext.Text.Length == 0 && FIEWordaystext.Text.Length == 0 && FIEStarttext.Text.Length == 0 && FIEEndtext.Text.Length == 0)
            {
                FillEM.Visible = true;
            }
        }

        private void FIEditButton_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = false;
            FIEButton.Visible = true; ProfilePanel.Visible = false; EditFIPanel.Visible = true;
        }

        private void FIEButton_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = true;
            FIEButton.Visible = false; ProfilePanel.Visible = true; EditFIPanel.Visible = false;
            InfoGetter();
            Loaders();
        }

        private void DeleteAccButton_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Are you sure you want to permanently delete this account? This action cannot be undone.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (results == DialogResult.Yes)
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();

                    int newFacilityId = 0;

                    string getIdQuery = "SELECT Facility_ID FROM [Service Facilities] WHERE [Email Address] = ?";
                    using (OleDbCommand getIdCmd = new OleDbCommand(getIdQuery, myConn))
                    {
                        getIdCmd.Parameters.AddWithValue("?", EmailAddress);
                        object result = getIdCmd.ExecuteScalar();

                        if (result != null)
                        {
                            newFacilityId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Facility not found.");
                            return;
                        }
                    }

                    string deleteQuery = "DELETE FROM [Service Facilities] WHERE [Email Address] = ?";
                    using (OleDbCommand deleteCmd = new OleDbCommand(deleteQuery, myConn))
                    {
                        deleteCmd.Parameters.AddWithValue("?", EmailAddress);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No matching email found. Deletion failed.");
                            return;
                        }
                    }

                    string adminUpdateQuery = "UPDATE [Admin (Service Facilities)] SET Status = ?, [Date Deleted] = ? WHERE Facility_ID = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(adminUpdateQuery, myConn))
                    {
                        updateCmd.Parameters.AddWithValue("?", "Deleted");
                        updateCmd.Parameters.AddWithValue("?", DateTime.Today);
                        updateCmd.Parameters.AddWithValue("?", newFacilityId);

                        updateCmd.ExecuteNonQuery();
                    }
                }

                this.Hide();
                ServiceFacilityLogin serviceFacilityLogin = new ServiceFacilityLogin();
                serviceFacilityLogin.ShowDialog();
            }
            else
            {
                MessageBox.Show("You clicked No!");
            }

        }
        public void ServiceOfferedUpdater()
        {
            if (Service1.Text.Length != 0 && Description1.Text.Length != 0 && Price1.Text.Length != 0 && Duration1.Text.Length != 0 &&
                Service2.Text.Length != 0 && Description2.Text.Length != 0 && Price2.Text.Length != 0 && Duration2.Text.Length != 0 &&
                Service3.Text.Length != 0 && Description3.Text.Length != 0 && Price3.Text.Length != 0 && Duration3.Text.Length != 0)
            {


            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {

        }

        private void EditButton2_Click(object sender, EventArgs e)
        {
            EditSOButton.Visible = true; ESerOffPanel.Visible = true;
        }
    }
}
