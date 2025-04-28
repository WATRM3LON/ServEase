using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.IO;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using System.Collections;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;
using ZXing.QrCode;
using ZXing.Common;
using System.Net.Mail;
using System.Net;
using System.Configuration.Provider;

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

        string formattedWorHours = "", service = "";
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
        public string SpeCat { get; set; }
        public DateTime WorHours { get; set; }
        public string WorDays { get; set; }
        public string Ratings { get; set; }
        public string AppStatus { get; set; }
        public string ExceptionDay { get; set; }
        public string Tags { get; set; }
        public DateTime workingstart;
        public DateTime workingend;
        DateTime currentMonth = DateTime.Today;
        List<DateTime> exceptionDays = new List<DateTime>();

        string filter1 = "", filter2 = "", locs = " ", Ems = " ", Conum = " ";
        public ServiceFacilitycs()
        {
            InitializeComponent();
            InfoGetter();
            Loaders();
            LoadFacilityData(); LoadHistory(AppointmentId, FacilityiId, ClientId);
            HiLabel.Text = $"Hi {Facname},";
            DashboardPanel.Visible = true;
            DashboardPanel2.Visible = false;
            AppointmentsPanel.Visible = false;
            ViewdetailsPanel.Visible = false;
            CalendarAppointmentPanel.Visible = false;
            CalendarPanel.Visible = false;
            AppointmentPanel.Visible = true;
            panel11.Visible = true;
            panel45.Visible = true;
            DashboardButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            Dbutton.BackColor = ColorTranslator.FromHtml("#f0246e");
            AppDetsbutton.Visible = false;
            SerButton.Visible = false; AnalyticsPanel.Visible = false;
            panel44.Visible = false; UFilebutton.Visible = false; UploadfilesPanel.Visible = false;
            NotificationPanel.Visible = false; ASReasonlabel.Visible = false; ASReasontext.Visible = false; DimPanel.Visible = false;
            ASConfrimButton.Visible = false; ASCancelButton.Visible = false;
            ASCompleteButton.Visible = false; ASnoShoButton.Visible = false;
            ProfilePanel.Visible = false; FIESpeCatlabel.Visible = false; FIESpeCattext.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false; EATPanel.Visible = false; EATButton.Visible = false;
            ATButton.Visible = false;
            ServicesOfferedPanel.Visible = false; SOEerrorm.Visible = false; Exceptionpanel.Visible = false;
            SettingsPanel.Visible = false;
            FIEButton.Visible = false; FillEM.Visible = false; ESerOffPanel.Visible = false; EditSOButton.Visible = false;
            EditFIPanel.Visible = false; CnumberExisted.Visible = false; CnumberInvalid.Visible = false;
            Startime1.ForeColor = Startime2.ForeColor = Startime3.ForeColor = Startime4.ForeColor = Startime5.ForeColor = SystemColors.InactiveCaption;
            Endtime1.ForeColor = Endtime2.ForeColor = Endtime3.ForeColor = Endtime4.ForeColor = Endtime5.ForeColor = SystemColors.InactiveCaption;
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
            Startime1.ForeColor = Startime2.ForeColor = Startime3.ForeColor = Startime4.ForeColor = Startime5.ForeColor = SystemColors.InactiveCaption;
            Endtime1.ForeColor = Endtime2.ForeColor = Endtime3.ForeColor = Endtime4.ForeColor = Endtime5.ForeColor = SystemColors.InactiveCaption;
            MessagePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MessagePanel.Width, MessagePanel.Height, 10, 10));
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
            ASConfrimButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ASConfrimButton.Width, ASConfrimButton.Height, 10, 10));
            ASCancelButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ASCancelButton.Width, ASCancelButton.Height, 10, 10));
            ASCompleteButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ASCompleteButton.Width, ASCompleteButton.Height, 10, 10));
            ASnoShoButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ASnoShoButton.Width, ASnoShoButton.Height, 10, 10));
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
            Cconfirmbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Cconfirmbutton.Width, Cconfirmbutton.Height, 10, 10));
            filesbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, filesbutton.Width, filesbutton.Height, 10, 10));
            Filespanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Filespanel.Width, Filespanel.Height, 10, 10));
            //SERVICES OFFRED
            //SOTable.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 10, 10));
            ATdatetime.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATdatetime.Width, ATdatetime.Height, 10, 10));
            ATtimeslot.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATtimeslot.Width, ATtimeslot.Height, 10, 10));
            EditButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EditButton.Width, EditButton.Height, 10, 10));
            EditButton2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EditButton2.Width, EditButton2.Height, 10, 10));
            EATdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EATdate.Width, EATdate.Height, 10, 10));
            EATtimeslot.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EATtimeslot.Width, EATtimeslot.Height, 10, 10));
            ATCPrev.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATCPrev.Width, ATCPrev.Height, 10, 10));
            ATCNext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATCNext.Width, ATCNext.Height, 10, 10));
            Exceptionpanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Exceptionpanel.Width, Exceptionpanel.Height, 10, 10));
            EATIns.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EATIns.Width, EATIns.Height, 10, 10));
            Filesubmitbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Filesubmitbutton.Width, Filesubmitbutton.Height, 10, 10));
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
            EATConfrimbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EATConfrimbutton.Width, EATConfrimbutton.Height, 10, 10));
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
            if (AppStatus == "Pending")
            {
                FIStatus.Text = FIEStatus.Text = AppStatus; FIStatus.ForeColor = FIEStatus.ForeColor = Color.Gold;
            }
            else if (AppStatus == "Approved")
            {
                FIStatus.Text = FIEStatus.Text = AppStatus; FIStatus.ForeColor = FIEStatus.ForeColor = ColorTranslator.FromHtml("#69e331");
            }
            else
            {
                FIStatus.Text = FIEStatus.Text = AppStatus; FIStatus.ForeColor = FIEStatus.ForeColor = Color.Red;
            }

            FISpeCattext.Text = FIESpeCattext.Text = SpeCat;
            FITagstext.Text = FIETagstext.Text = Tags;
            ATCToday.Text = "Today: " + DateTime.Now.ToString("dd, MMMM yyyy");
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
                NotificationPanel.BringToFront();
                LoadFacilityNotifications(FacilityiId);
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            AnalyticsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            UFilebutton.Visible = false; UploadfilesPanel.Visible = false;
            //SOAPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            EATButton.Visible = false; EATPanel.Visible = false;
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
            CalendarButton.BackColor = ColorTranslator.FromHtml("#f0246e"); PopulateCalendarPanel(AppointmentId, FacilityiId, ClientId); LoadHistory(AppointmentId, FacilityiId, ClientId);
            CButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.System;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.Flat;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            AnalyticsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            EATButton.Visible = false; EATPanel.Visible = false;
            UFilebutton.Visible = false; UploadfilesPanel.Visible = false;
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
            AppointmentsPanel.Visible = true; LoadHistory(AppointmentId, FacilityiId, ClientId);
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
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
            AppDetsbutton.Visible = true;
            AppointmentsPanel.Visible = false;
            CalendarAppointmentPanel.Visible = false;
            ViewdetailsPanel.Visible = true;
            if (AppStatus == "Pending")
            {
                ASConfrimButton.Visible = true; ASCancelButton.Visible = true;
                ASCompleteButton.Visible = false; ASnoShoButton.Visible = false;
            }
            else if (AppStatus == "Confirmed")
            {
                ASConfrimButton.Visible = false; ASCancelButton.Visible = false;
                ASCompleteButton.Visible = true; ASnoShoButton.Visible = true;
            }
            else
            {
                ASConfrimButton.Visible = false; ASCancelButton.Visible = false;
                ASCompleteButton.Visible = false; ASnoShoButton.Visible = false;
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                //StatusPanel.Visible = true;
                status = true;
            }
            else
            {
                //StatusPanel.Visible = false;
                status = false;
            }
        }

        private void AppDetsbutton_Click(object sender, EventArgs e)
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
            AppointmentsPanel.Visible = true; LoadHistory(AppointmentId, FacilityiId, ClientId);
            appointmentsbutton.FlatStyle = FlatStyle.System;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            AppDetsbutton.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsPanel.Visible = true; LoadAppointmentPieChart(); LoadRevenueLineChart(); LoadCustomerGrowthChart(); LoadFacilityAnalyticsSummary();
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            EATButton.Visible = false; EATPanel.Visible = false;
            UFilebutton.Visible = false; UploadfilesPanel.Visible = false;
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
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            BFButton.FlatStyle = FlatStyle.System; BFButton.BackColor = Color.White;
            CGRButton.FlatStyle = FlatStyle.System; CGRButton.BackColor = ColorTranslator.FromHtml("#ed82a9");
            PSButton.FlatStyle = FlatStyle.System; PSButton.BackColor = Color.White;
            LoadCustomerGrowthChart();
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
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            BFButton.FlatStyle = FlatStyle.System; BFButton.BackColor = Color.White;
            CGRButton.FlatStyle = FlatStyle.System; CGRButton.BackColor = Color.White;
            PSButton.FlatStyle = FlatStyle.System; PSButton.BackColor = ColorTranslator.FromHtml("#ed82a9");
            LoadPopularServicesChart();
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
        private void BFButton_Click(object sender, EventArgs e)
        {
            AnalyticsButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            BFButton.FlatStyle = FlatStyle.System; BFButton.BackColor = ColorTranslator.FromHtml("#ed82a9");
            CGRButton.FlatStyle = FlatStyle.System; CGRButton.BackColor = Color.White;
            PSButton.FlatStyle = FlatStyle.System; PSButton.BackColor = Color.White;
            LoadPopularTimeslotsChart();
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            AnalyticsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            EATButton.Visible = false; EATPanel.Visible = false;
            UFilebutton.Visible = false; UploadfilesPanel.Visible = false;
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
            InfoGetter();
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
            LoadFacilityData();
            PopulateCalendar();
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            EATButton.Visible = false; EATPanel.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            AnalyticsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            PButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //ANALYTICS
            AnalyticsButton.BackColor = Color.White;
            SButton.BackColor = Color.White;
            AnalyticsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            ServicesOfferedPanel.Visible = false;
            SOButton.Visible = false;
            ATPanel.Visible = false;
            ATButton.Visible = false;
            EditFIPanel.Visible = false; FIEButton.Visible = false;
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            EATButton.Visible = false; EATPanel.Visible = false;
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

                string sql = "SELECT [Facility_ID], [Facility Name], [Facility Location], [Owner First Name], [Owner Last Name], [Contact Number], [Password], [Service Category], [Specific Category], [Working Hours Start], [Working Hours End], [Working Days], [Exception Day (Closed)], Ratings, [Approval Status], Tags FROM [Service Facilities] WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@Email", EmailAddress);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FacilityiId = Convert.ToInt32(reader["Facility_ID"]);
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
                            SpeCat = reader["Specific Category"].ToString();
                            ExceptionDay = reader["Exception Day (Closed)"].ToString();
                            AppStatus = reader["Approval Status"].ToString();
                            Tags = reader["Tags"].ToString();

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

                string sql = "UPDATE [Service Facilities] SET [Facility Name] = ?, [Facility Location] = ?, [Owner First Name] = ?, [Owner Last Name] = ?, [Contact Number] = ?, [Service Category] = ?, [Specific Category] = ?, [Working Hours Start] = ?, [Working Hours End] = ?, [Working Days] = ?, [Tags] = ? WHERE [Email Address] = EmailAddress";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", FIEFacnametext.Text);
                    cmd.Parameters.AddWithValue("?", FIELoctext.Text);
                    cmd.Parameters.AddWithValue("?", FIEOFnametext.Text);
                    cmd.Parameters.AddWithValue("?", FIEOLnametext.Text);
                    cmd.Parameters.AddWithValue("?", FIECnumbertext.Text);

                    service = FIESerCatList.GetItemText(FIESerCatList.SelectedItem);
                    cmd.Parameters.AddWithValue("?", service);

                    SpeCat = FIESpeCattext.GetItemText(FIESpeCattext.SelectedItem);
                    cmd.Parameters.AddWithValue("?", SpeCat);

                    cmd.Parameters.AddWithValue("?", FIEStarttext.Text);
                    cmd.Parameters.AddWithValue("?", FIEEndtext.Text);
                    cmd.Parameters.AddWithValue("?", FIEWordaystext.Text);
                    cmd.Parameters.AddWithValue("?", FIETagstext.Text);
                    cmd.Parameters.AddWithValue($"{EmailAddress}", FIEEmailaddtext.Text);

                    cmd.ExecuteNonQuery();
                }

                int newFacilityId = 0;
                using (OleDbCommand getIdCmd = new OleDbCommand("SELECT @@IDENTITY", myConn))
                {
                    object result = getIdCmd.ExecuteScalar();
                    newFacilityId = Convert.ToInt32(result);
                }

                string AdminQuery = "UPDATE [Admin (Service Facilities)] SET [Facility Name] = @FacilityName, [Facility Location] = @FLocation, [Owner First Name] = @OFName, [Owner Last Name] = @OLName, [Contact Number] = @CNumber, [Service Category] = @Servicecategory, [Specific Category] = @Specificcategory, [Working Hours Start] = @Workinghoursstart, [Working Hours End] = @Workinghoursend, [Working Days] = @Workingdays WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(AdminQuery, myConn))
                {
                    cmd.Parameters.AddWithValue("@FacilityName", FIEFacnametext.Text);
                    cmd.Parameters.AddWithValue("@FLocation", FIELoctext.Text);
                    cmd.Parameters.AddWithValue("@OFName", FIEOFnametext.Text);
                    cmd.Parameters.AddWithValue("@OLName", FIEOLnametext.Text);
                    cmd.Parameters.AddWithValue("@CNumber", FIECnumbertext.Text);
                    service = FIESerCatList.GetItemText(FIESerCatList.SelectedItem);
                    cmd.Parameters.AddWithValue("@Servicecategory", service);
                    SpeCat = FIESpeCattext.GetItemText(FIESpeCattext.SelectedItem);
                    cmd.Parameters.AddWithValue("@Specificcategory", SpeCat);
                    cmd.Parameters.AddWithValue("@Workinghoursstart", FIEStarttext.Text);
                    cmd.Parameters.AddWithValue("@Workinghoursend", FIEEndtext.Text);
                    cmd.Parameters.AddWithValue("@Workingdays", FIEWordaystext.Text);
                    cmd.Parameters.AddWithValue("@Email", FIEEmailaddtext.Text);
                    cmd.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();
                }
                System.Windows.Forms.MessageBox.Show("Updated successfully!");
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

            if (FIELoctext.Text.Length != 0 && FIEFacnametext.Text.Length != 0 && FIEWordaystext.Text.Length != 0 && FIEStarttext.Text.Length != 0 && FIEEndtext.Text.Length != 0 && cnumberValid && FIETagstext.Text.Length != 0 && FIESpeCattext.Text.Length != 0)
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
            DialogResult results = System.Windows.Forms.MessageBox.Show("Are you sure you want to permanently delete this account? This action cannot be undone.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            System.Windows.Forms.MessageBox.Show("Facility not found.");
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
                            System.Windows.Forms.MessageBox.Show("Deleted successfully!");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("No matching email found. Deletion failed.");
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
                System.Windows.Forms.MessageBox.Show("You clicked No!");
            }

        }

        public void ServiceGetter()
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
                        System.Windows.Forms.MessageBox.Show("Facility not found.");
                        return;
                    }
                }

                List<int> serviceIds = new List<int>();

                string getServiceIdsQuery = "SELECT Service_ID FROM [Facility Services] WHERE Facility_ID = ?";

                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getServiceIdsQuery, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", newFacilityId);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                serviceIds.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }

                TextBox[] serviceNames = { Service1, Service2, Service3 };
                TextBox[] descriptions = { Description1, Description2, Description3 };
                TextBox[] prices = { Price1, Price2, Price3 };
                TextBox[] durations = { Duration1, Duration2, Duration3 };

                for (int i = 0; i < 3; i++)
                {
                    string sql = "SELECT [Service Name] , [Description], [Price], [Duration] FROM [Facility Services] WHERE Service_ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", serviceIds[i]);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                serviceNames[i].Text = reader.IsDBNull(reader.GetOrdinal("Service Name")) ? "Add Service Name" : reader["Service Name"].ToString();
                                descriptions[i].Text = reader.IsDBNull(reader.GetOrdinal("Description")) ? "Add Description" : reader["Description"].ToString();
                                prices[i].Text = reader.IsDBNull(reader.GetOrdinal("Price")) ? "Price" : reader["Price"].ToString();
                                durations[i].Text = reader.IsDBNull(reader.GetOrdinal("Duration")) ? "Add Duration" : reader["Duration"].ToString();

                            }
                        }
                    }
                }
            }
        }
        public void ServiceOfferedUpdater()
        {
            bool checks = Checker();


            if (Service1.Text.Length != 0 && Description1.Text.Length != 0 && Price1.Text.Length != 0 && Duration1.Text.Length != 0 &&
                Service2.Text.Length != 0 && Description2.Text.Length != 0 && Price2.Text.Length != 0 && Duration2.Text.Length != 0 &&
                Service3.Text.Length != 0 && Description3.Text.Length != 0 && Price3.Text.Length != 0 && Duration3.Text.Length != 0)
            {
                if (!checks)
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
                                System.Windows.Forms.MessageBox.Show("Facility not found.");
                                return;
                            }
                        }

                        List<int> serviceIds = new List<int>();

                        string getServiceIdsQuery = "SELECT Service_ID FROM [Facility Services] WHERE Facility_ID = ?";

                        using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getServiceIdsQuery, myConn))
                        {
                            getServiceIdsCmd.Parameters.AddWithValue("?", newFacilityId);

                            using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0))
                                    {
                                        serviceIds.Add(reader.GetInt32(0));
                                    }
                                }
                            }
                        }

                        TextBox[] serviceNames = { Service1, Service2, Service3 };
                        TextBox[] descriptions = { Description1, Description2, Description3 };
                        TextBox[] prices = { Price1, Price2, Price3 };
                        TextBox[] durations = { Duration1, Duration2, Duration3 };

                        for (int i = 0; i < 3; i++)
                        {
                            string sql = "UPDATE [Facility Services] SET [Service Name] = ?, [Description] = ?, [Price] = ?, [Duration] = ? WHERE Service_ID = ?";

                            using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                            {
                                cmd.Parameters.AddWithValue("?", serviceNames[i].Text);
                                cmd.Parameters.AddWithValue("?", descriptions[i].Text);
                                cmd.Parameters.AddWithValue("?", Convert.ToDecimal(prices[i].Text));
                                cmd.Parameters.AddWithValue("?", durations[i].Text);
                                cmd.Parameters.AddWithValue("?", serviceIds[i]);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    System.Windows.Forms.MessageBox.Show("Successfully updated!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SOEerrorm.Visible = true;
                }
            }

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ServiceOfferedUpdater();
        }

        private void EditButton2_Click(object sender, EventArgs e)
        {
            EditSOButton.Visible = true; ESerOffPanel.Visible = true;
            ServicesOfferedPanel.Visible = false; SOButton.Visible = false;
            ServiceGetter();
        }

        private void EditSOButton_Click(object sender, EventArgs e)
        {
            EditSOButton.Visible = false; ESerOffPanel.Visible = false;
            ServicesOfferedPanel.Visible = true; SOButton.Visible = true;
            LoadFacilityData();
        }

        private void Service1_Click(object sender, EventArgs e)
        {
            Service1.ForeColor = Description1.ForeColor = Price1.ForeColor = Duration1.ForeColor = Color.Black;
            SOEerrorm.Visible = false;
        }

        private void Service2_Click(object sender, EventArgs e)
        {
            Service2.ForeColor = Description2.ForeColor = Price2.ForeColor = Duration2.ForeColor = Color.Black;
            SOEerrorm.Visible = false;
        }

        private void Service3_Click(object sender, EventArgs e)
        {
            Service3.ForeColor = Description3.ForeColor = Price3.ForeColor = Duration3.ForeColor = Color.Black;
            SOEerrorm.Visible = false;
        }

        private void LoadFacilityData()
        {
            SerOffPanel.Controls.Clear();
            ATtimeslots.Controls.Clear();

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
                        System.Windows.Forms.MessageBox.Show("Facility not found.");
                        return;
                    }
                }

                string sql = "SELECT [Service Name], Description, Price, Duration FROM [Facility Services] WHERE Facility_ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newFacilityId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;

                        while (reader.Read())
                        {
                            string serviceName = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            string description = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            decimal price = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            string duration = reader.IsDBNull(3) ? "" : reader.GetValue(3).ToString();

                            ServiceOffered serviceOffered = new ServiceOffered();
                            serviceOffered.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, serviceOffered.Width, serviceOffered.Height, 10, 10));

                            serviceOffered.SetData(serviceName, description, price, duration);
                            serviceOffered.Location = new Point(0, margin - 7);
                            margin += serviceOffered.Height + 10;

                            SerOffPanel.Controls.Add(serviceOffered);
                        }
                    }
                }

                string timeslots = "SELECT [Start Time], [End Time], Status FROM [Facility Timeslots] WHERE Facility_ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(timeslots, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newFacilityId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;

                        while (reader.Read())
                        {
                            DateTime startime = reader.IsDBNull(reader.GetOrdinal("Start Time")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Start Time"));
                            DateTime endtime = reader.IsDBNull(reader.GetOrdinal("End Time")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("End Time"));
                            string startm = startime == DateTime.MinValue ? " " : $"{startime:hh\\:mm tt}";
                            string endtm = endtime == DateTime.MinValue ? " " : $"{endtime:hh\\:mm tt}";
                            string status = reader.IsDBNull(reader.GetOrdinal("Status")) ? " " : reader["Status"].ToString();

                            TimeSlots timeSlots = new TimeSlots();
                            timeSlots.SetData(startm, endtm);
                            timeSlots.Location = new Point(0, margin - 7);
                            margin += timeSlots.Height + 10;

                            ATtimeslots.Controls.Add(timeSlots);
                        }
                    }
                }

            }

        }
        public bool Checker()
        {
            int counter = 0;
            if (Service2.Text == "Add Service Name") { counter++; }
            if (Description2.Text == "Add Descritption") { counter++; }
            if (Price2.Text == "Add Price") { counter++; }
            if (Duration1.Text == "Add Duration") { counter++; }
            if (Service3.Text == "Add Service Name") { counter++; }
            if (Description3.Text == "Add Descritption") { counter++; }
            if (Price3.Text == "Add Price") { counter++; }
            if (Duration3.Text == "Add Duration") { counter++; }

            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TimeslotUpdater()
        {
            bool checks = Checker();
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
                        System.Windows.Forms.MessageBox.Show("Facility not found.");
                        return;
                    }
                }

                List<int> timeslotids = new List<int>();

                string getServiceIdsQuery = "SELECT Timeslot_ID FROM [Facility Timeslots] WHERE Facility_ID = ?";

                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getServiceIdsQuery, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", newFacilityId);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                timeslotids.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }

                TextBox[] stratimes = { Startime1, Startime2, Startime3, Startime4, Startime5 };
                TextBox[] endtimes = { Endtime1, Endtime2, Endtime3, Endtime4, Endtime5 };


                for (int i = 0; i < 5; i++)
                {
                    string sql = "UPDATE [Facility Timeslots] SET [Start Time] = ?, [End Time] = ?, [Status] = ? WHERE Timeslot_ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    {
                        if (stratimes[i].Text == "Add Time" || endtimes[i].Text == "Add Time")
                        {
                            cmd.Parameters.AddWithValue("?", DBNull.Value);
                            cmd.Parameters.AddWithValue("?", DBNull.Value);
                            cmd.Parameters.AddWithValue("?", DBNull.Value);
                            cmd.Parameters.AddWithValue("?", timeslotids[i]);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("?", stratimes[i].Text);
                            cmd.Parameters.AddWithValue("?", endtimes[i].Text);
                            cmd.Parameters.AddWithValue("?", "Available");
                            cmd.Parameters.AddWithValue("?", timeslotids[i]);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                string exceptionDaysCsv = string.Join(",", exceptionDays.Select(d => d.ToString("yyyy-MM-dd")));

                string updateFacilitySql = "UPDATE [Service Facilities] SET [Exception Day (Closed)] = ? WHERE Facility_ID = ?";

                using (OleDbCommand exceptionCmd = new OleDbCommand(updateFacilitySql, myConn))
                {
                    exceptionCmd.Parameters.AddWithValue("?", exceptionDaysCsv);
                    exceptionCmd.Parameters.AddWithValue("?", newFacilityId);

                    exceptionCmd.ExecuteNonQuery();
                }
            }
            System.Windows.Forms.MessageBox.Show("Successfully updated!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void TimeslotGetter()
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
                        System.Windows.Forms.MessageBox.Show("Facility not found.");
                        return;
                    }
                }

                List<int> timeslotids = new List<int>();

                string getServiceIdsQuery = "SELECT Timeslot_ID FROM [Facility Timeslots] WHERE Facility_ID = ?";

                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getServiceIdsQuery, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", newFacilityId);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                timeslotids.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }

                TextBox[] stratimes = { Startime1, Startime2, Startime3, Startime4, Startime5 };
                TextBox[] endtimes = { Endtime1, Endtime2, Endtime3, Endtime4, Endtime5 };

                for (int i = 0; i < 5; i++)
                {
                    string sql = "SELECT [Start Time], [End Time] FROM [Facility Timeslots] WHERE Timeslot_ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", timeslotids[i]);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime startime = reader.IsDBNull(reader.GetOrdinal("Start Time")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Start Time"));
                                DateTime endtime = reader.IsDBNull(reader.GetOrdinal("End Time")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("End Time"));
                                string startm = startime == DateTime.MinValue ? "Add Time" : $"{startime:hh\\:mm tt}";
                                string endtm = endtime == DateTime.MinValue ? "Add Time" : $"{endtime:hh\\:mm tt}";
                                stratimes[i].Text = startm; stratimes[i].ForeColor = SystemColors.InactiveCaption;
                                endtimes[i].Text = endtm; endtimes[i].ForeColor = SystemColors.InactiveCaption;
                            }
                        }
                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            InfoGetter();
            ATPanel.Visible = false; ATButton.Visible = false;
            EATButton.Visible = true; EATPanel.Visible = true;
            Loaders();
            TimeslotGetter();
            PopulateCalendar();
        }

        private void EATButton_Click(object sender, EventArgs e)
        {
            InfoGetter();
            ATPanel.Visible = true; ATButton.Visible = true;
            EATButton.Visible = false; EATPanel.Visible = false;
            LoadFacilityData();
            PopulateCalendar();
        }

        private void Startime1_TextChanged(object sender, EventArgs e)
        {
            Startime1.ForeColor = Color.Black; Endtime1.ForeColor = Color.Black;
        }

        private void Startime2_TextChanged(object sender, EventArgs e)
        {
            Startime2.ForeColor = Color.Black; Endtime2.ForeColor = Color.Black;
        }

        private void Startime3_TextChanged(object sender, EventArgs e)
        {
            Startime3.ForeColor = Color.Black; Endtime3.ForeColor = Color.Black;
        }

        private void Startime4_TextChanged(object sender, EventArgs e)
        {
            Startime4.ForeColor = Color.Black; Endtime4.ForeColor = Color.Black;
        }

        private void Startime5_TextChanged(object sender, EventArgs e)
        {
            Startime5.ForeColor = Color.Black; Endtime5.ForeColor = Color.Black;
        }

        private void EATConfrimbutton_Click(object sender, EventArgs e)
        {
            TimeslotUpdater();
        }

        private void FIESerCatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FIESpeCatlabel.Visible = true; FIESpeCattext.Visible = true;
            service = FIESerCatList.SelectedItem.ToString();
            FIESpeCattext.Items.Clear();

            Dictionary<string, string[]> subCategories = new Dictionary<string, string[]>
            {
                { "Personal Care & Beauty Services", new[] {
                    "Barbershops",
                    "Hair Salons",
                    "Nail Salons",
                    "Spa & Massage Centers",
                    "Tattoo and Piercing Parlors"
                }},
                { "Health & Medical Services", new[] {
                    "Animal Clinics",
                    "Dentists",
                    "Dermatologists",
                    "Hospitals",
                    "Laboratories",
                    "Pharmacies",
                    "Psychologists"
                }},
                { "Fitness & Sports Services", new[] {
                    "Dance Studios",
                    "Gyms",
                    "Sports Centers"
                }},
                { "Education & Tutoring Services", new[] {
                    "Schools",
                    "Tutoring Centers"
                }},
                { "Repair & Technical Services", new[] {
                    "Appliance Repair",
                    "Car Wash",
                    "Car / Motorcycle Repair Shops",
                    "Electronics Repair"
                }},
                { "Food & Beverages Services", new[] {
                    "Bakeries",
                    "Bars",
                    "Cafes & Coffee Shops",
                    "Mini Mart",
                    "Restaurants",
                    "Supermarkets / Grocery Stores"
                }},
                { "Miscellaneous Services", new[] {
                    "Funeral Homes",
                    "Hotels",
                    "Laundry Shops",
                    "Tailoring Services"
                }},
            };

            if (subCategories.ContainsKey(service))
            {
                FIESpeCattext.Items.AddRange(subCategories[service]);
            }
        }
        List<DayOfWeek> ParseWorkingDays(string dayRange)
        {
            var workingDays = new List<DayOfWeek>();

            if (string.IsNullOrWhiteSpace(dayRange)) return workingDays;

            string[] parts = dayRange.Split('-');
            if (parts.Length != 2) return workingDays;

            if (Enum.TryParse(parts[0], true, out DayOfWeek startDay) &&
                Enum.TryParse(parts[1], true, out DayOfWeek endDay))
            {
                int start = (int)startDay;
                int end = (int)endDay;

                for (int i = start; ; i = (i + 1) % 7)
                {
                    workingDays.Add((DayOfWeek)i);
                    if (i == end) break;
                }
            }

            return workingDays;
        }
        List<DateTime> ParseWorkDays(string exceptionclosed)
        {
            var exceptionDates = new List<DateTime>();

            if (string.IsNullOrWhiteSpace(exceptionclosed)) return exceptionDates;

            string[] parts = exceptionclosed.Split(',');

            foreach (var dateStr in parts)
            {
                if (DateTime.TryParse(dateStr.Trim(), out DateTime parsedDate))
                {
                    exceptionDates.Add(parsedDate.Date);
                }
            }

            return exceptionDates;
        }

        void PopulateCalendar()
        {
            if (ATPanel.Visible == true)
            {
                ATC3.Controls.Clear();
                ATC3.SuspendLayout();

                List<DayOfWeek> workingDays = ParseWorkingDays(WorDays);
                List<DateTime> workDays = ParseWorkDays(ExceptionDay);

                DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
                int startCol = (int)firstDayOfMonth.DayOfWeek;

                int row = 0;
                int col = startCol;

                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime thisDate = new DateTime(currentMonth.Year, currentMonth.Month, day);
                    DayOfWeek dayOfWeek = thisDate.DayOfWeek;

                    Label dayLabel = new Label { Text = day.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 9), Tag = thisDate };

                    if (!workingDays.Contains(dayOfWeek))
                    {
                        dayLabel.ForeColor = Color.DimGray;
                        dayLabel.BackColor = Color.WhiteSmoke;
                    }

                    if (workDays.Any(d => d.Date == thisDate.Date))
                    {
                        dayLabel.ForeColor = Color.DimGray;
                        dayLabel.BackColor = Color.WhiteSmoke;
                    }
                    if (thisDate.Date == DateTime.Today)
                    {
                        dayLabel.BackColor = ColorTranslator.FromHtml("#f0246e");
                        dayLabel.ForeColor = Color.White;
                        dayLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }

                    ATC3.Controls.Add(dayLabel, col, row);

                    col++;
                    if (col == 7)
                    {
                        col = 0;
                        row++;
                    }
                }

                ATCmonth.Text = currentMonth.ToString("MMMM yyyy");
                ATC3.ResumeLayout();

            }
            else
            {
                EATC3.Controls.Clear(); EATC3.SuspendLayout();

                List<DayOfWeek> workingDays = ParseWorkingDays(WorDays);
                List<DateTime> workDays = ParseWorkDays(ExceptionDay);

                DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
                int startCol = (int)firstDayOfMonth.DayOfWeek;

                int row = 0;
                int col = startCol;

                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime thisDate = new DateTime(currentMonth.Year, currentMonth.Month, day);
                    DayOfWeek dayOfWeek = thisDate.DayOfWeek;

                    Label dayLabel = new Label { Text = day.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 9), Tag = thisDate };

                    if (!workingDays.Contains(dayOfWeek))
                    {
                        dayLabel.ForeColor = Color.DimGray;
                        dayLabel.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        if (workDays.Any(d => d.Date == thisDate.Date))
                        {
                            dayLabel.ForeColor = Color.DimGray;
                            dayLabel.BackColor = Color.WhiteSmoke;
                        }
                        if (exceptionDays.Contains(thisDate.Date))
                        {
                            dayLabel.BackColor = Color.IndianRed;
                            dayLabel.ForeColor = Color.White;
                        }
                        DateTime Date = (DateTime)dayLabel.Tag;

                        if (Date.Date >= DateTime.Today)
                        {
                            dayLabel.Cursor = Cursors.Hand;
                            dayLabel.Click += DayLabel_Click;
                        }

                    }

                    if (thisDate.Date == DateTime.Today.Date)
                    {
                        dayLabel.BackColor = ColorTranslator.FromHtml("#f0246e");
                    }
                    EATC3.Controls.Add(dayLabel, col, row);

                    col++;
                    if (col == 7)
                    {
                        col = 0;
                        row++;
                    }
                }
                EATCmonth.Text = currentMonth.ToString("MMMM yyyy"); EATC3.ResumeLayout();
            }
        }
        private void DayLabel_Click(object sender, EventArgs e)
        {
            Exceptionpanel.Visible = true;
            Label clickedLabel = sender as Label;

            if (clickedLabel != null && clickedLabel.Tag is DateTime selectedDate)
            {
                selectedDate = selectedDate.Date;

                if (exceptionDays.Contains(selectedDate))
                {
                    exceptionDays.Remove(selectedDate);
                }
                else
                {
                    exceptionDays.Add(selectedDate);
                }

                PopulateCalendar();

                if (exceptionDays.Count > 0)
                {
                    Exceptionpanel.Visible = true;
                    EATException.Text = "Exception Days: " +
                        string.Join(", ", exceptionDays.Select(d => d.ToString("dddd, dd MMMM yyyy")));
                }
                else
                {
                    Exceptionpanel.Visible = false;
                    EATException.Text = string.Empty;
                }

            }
        }
        private void ATCPrev_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            PopulateCalendar();
            PopulateCalendarPanel(AppointmentId, FacilityiId, ClientId);
        }

        private void ATCNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(+1);
            PopulateCalendar();
            PopulateCalendarPanel(AppointmentId, FacilityiId, ClientId);
        }
        int FacilityiId, AppointmentId, ClientId;
        public void LoadHistory(int ID, int Faid, int Clid,
                        string statusFilter = "",
                        DateTime? dateBookedFilter = null,
                        DateTime? appointmentDateFilter = null)
        {
            AppointmentsPanel.Controls.Clear();
            int facid = 0;
            EmailAddress = ServiceFacilityLogin.EmailAddress;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getclientid = "SELECT Facility_ID FROM [Service Facilities] WHERE [Email Address] = ?";

                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getclientid, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", EmailAddress);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            facid = reader.GetInt32(0);
                        }
                    }
                }
                string sql = "SELECT Client_ID, Appointment_ID FROM Appointments WHERE Facility_ID = ?";
                if (!string.IsNullOrEmpty(statusFilter))
                    sql += " AND [Appointment Status] = ?";
                if (dateBookedFilter.HasValue)
                    sql += " AND [Date Booked] = ?";
                if (appointmentDateFilter.HasValue)
                    sql += " AND [Appointment Date] = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", facid);
                    if (!string.IsNullOrEmpty(statusFilter))
                        cmd.Parameters.AddWithValue("?", statusFilter);
                    if (dateBookedFilter.HasValue)
                        cmd.Parameters.AddWithValue("?", dateBookedFilter.Value.Date);
                    if (appointmentDateFilter.HasValue)
                        cmd.Parameters.AddWithValue("?", appointmentDateFilter.Value.Date);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;

                        while (reader.Read())
                        {
                            int cleid = reader.GetInt32(reader.GetOrdinal("Client_ID"));
                            int appid = reader.GetInt32(reader.GetOrdinal("Appointment_ID"));
                            string ClientName = "", Clientems = "";

                            string getFacility = "SELECT [First Name], [Last Name], [Email Address] FROM [Clients] WHERE [Client_ID] = ?";
                            using (OleDbCommand facility = new OleDbCommand(getFacility, myConn))
                            {
                                facility.Parameters.AddWithValue("?", cleid);

                                using (OleDbDataReader readers = facility.ExecuteReader())
                                {
                                    if (readers.Read())
                                    {
                                        string namefirst = readers.IsDBNull(readers.GetOrdinal("First Name")) ? "" : readers["First Name"].ToString();
                                        string namelast = readers.IsDBNull(readers.GetOrdinal("Last Name")) ? "" : readers["Last Name"].ToString();
                                        ClientName = namefirst + " " + namelast;
                                        Clientems = readers.IsDBNull(readers.GetOrdinal("Email Address")) ? "" : readers["Email Address"].ToString();
                                    }
                                }
                            }

                            UsersPanel usersPanel = new UsersPanel();
                            //usersPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));
                            usersPanel.Width = AppointmentsPanel.ClientSize.Width - 20;
                            usersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                            usersPanel.Location = new Point(0, margin);
                            margin += usersPanel.Height + 10;

                            usersPanel.ViewDetailsClicked += (s, e) =>
                            {
                                AppointmentId = appid;
                                FacilityiId = facid;
                                ClientId = cleid;
                                ViewDets(appid, facid, cleid);
                            };

                            string adminQuery = "SELECT [Appointment Status], [Appointment Date], [Date Booked] FROM Appointments WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Appointment_ID] = ?";
                            using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                            {
                                adminCmd.Parameters.AddWithValue("?", cleid);
                                adminCmd.Parameters.AddWithValue("?", facid);
                                adminCmd.Parameters.AddWithValue("?", appid);

                                using (OleDbDataReader adminReader = adminCmd.ExecuteReader())
                                {
                                    if (adminReader.Read())
                                    {
                                        string status = adminReader.GetString(adminReader.GetOrdinal("Appointment Status"));
                                        string dateapp = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");
                                        string datebooked = adminReader.IsDBNull(2) ? "" : adminReader.GetDateTime(2).ToString("dd MMM yyyy");

                                        usersPanel.AppInfo(status, dateapp); usersPanel.DataClient(ClientName, datebooked);
                                    }
                                }
                            }
                            PopulateCalendarPanel(appid, facid, cleid);

                            AppointmentsPanel.Controls.Add(usersPanel);
                        }
                    }

                }
            }
        }
        void PopulateCalendarPanel(int ID, int Faid, int Clid)
        {
            CAC3.Controls.Clear();
            CAC3.SuspendLayout();

            DateTime firstDay = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            int startCol = (int)firstDay.DayOfWeek;

            int row = 0;
            int col = startCol;

            Dictionary<DateTime, int> appointmentCounts = new Dictionary<DateTime, int>();
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();
                string query = "SELECT [Appointment Date] FROM Appointments WHERE [Facility_ID] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Faid);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                DateTime date = reader.GetDateTime(0).Date;
                                if (appointmentCounts.ContainsKey(date))
                                    appointmentCounts[date]++;
                                else
                                    appointmentCounts[date] = 1;
                            }
                        }
                    }
                }
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime thisDate = new DateTime(currentMonth.Year, currentMonth.Month, day);
                DayOfWeek dayOfWeek = thisDate.DayOfWeek;

                Panel cellPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Margin = new Padding(5) };

                Label dayLabel = new Label { Text = day.ToString(), Dock = DockStyle.Top, TextAlign = ContentAlignment.TopRight, AutoSize = false, Height = 20, Font = new Font("Segoe UI", 9), Tag = thisDate, BackColor = Color.Transparent };

                if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday)
                {
                    cellPanel.ForeColor = Color.DimGray;
                    cellPanel.BackColor = Color.WhiteSmoke;
                }

                if (thisDate.Date == DateTime.Today.Date)
                {
                    cellPanel.BackColor = ColorTranslator.FromHtml("#d5fcef");
                }

                if (appointmentCounts.ContainsKey(thisDate.Date))
                {
                    int count = appointmentCounts[thisDate.Date];

                    Label appLabel = new Label { Text = $" ● {count} Appointment/s", AutoEllipsis = true, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, ForeColor = ColorTranslator.FromHtml("#f0246e"), Font = new Font("Segoe UI", 8), Tag = thisDate };

                    cellPanel.Controls.Add(appLabel);
                    cellPanel.Cursor = Cursors.Hand;
                    appLabel.Tag = thisDate;
                    appLabel.Click += CellPanel_Click;
                    cellPanel.BackColor = ColorTranslator.FromHtml("#fef1f5");
                }



                cellPanel.Controls.Add(dayLabel);
                CAC3.Controls.Add(cellPanel, col, row);

                col++;
                if (col == 7)
                {
                    col = 0;
                    row++;
                }
            }

            CACmonth.Text = currentMonth.ToString("MMMM yyyy");
            CAC3.ResumeLayout();
        }
        private void CellPanel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel?.Tag is DateTime selectedDate)
            {
                CalendarPanel.Visible = false;
                CalendarAppointmentPanel.Visible = true;
                AppointmentsPanel.Visible = true;
                appointmentsbutton.FlatStyle = FlatStyle.System;
                appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
                calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
                calendarsButton.FlatStyle = FlatStyle.Flat;
                FilterDateBox.Visible = true;
                AppSearch.Visible = true;
                AppSerchtext.Text = selectedDate.ToString("yyyy-MM-dd");

                LoadHistory(AppointmentId, FacilityiId, ClientId, appointmentDateFilter: selectedDate);
            }
        }
        private void FilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter1 = FilterBox.SelectedItem.ToString();
            if (filter1 == "Date")
            {
                FilterDateBox.Visible = true; FilterBox.Visible = false; filter1 = null;
            }
            else if (filter1 == "Status")
            {
                FilterStatusBox.Visible = true; FilterBox.Visible = false; filter1 = null;
            }
            else if (filter1 == "Facility")
            {
                AppSearch.Visible = true;
            }
        }
        private void FilterDateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter2 = FilterDateBox.SelectedItem.ToString();
            AppSearch.Visible = true;
            AppSerchtext.Text = "eg. yyyy-MM-dd";


            if (filter2 == "--Back--")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId);
                FilterDateBox.Visible = false; FilterBox.Visible = true; AppSearch.Visible = false;
                filter2 = null;
            }
        }

        private void FilterStatusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter2 = FilterStatusBox.SelectedItem.ToString();

            if (filter2 == "Pending")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId, statusFilter: "Pending");
            }
            else if (filter2 == "Confirmed")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId, statusFilter: "Confirmed");
            }
            else if (filter2 == "Cancelled")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId, statusFilter: "Cancelled");
            }
            else if (filter2 == "Completed")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId, statusFilter: "Completed");
            }
            else if (filter2 == "No Show")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId, statusFilter: "No Show");
            }
            else if (filter2 == "--Back--")
            {
                LoadHistory(AppointmentId, FacilityiId, ClientId);
                FilterDateBox.Visible = false; FilterBox.Visible = true; AppSearch.Visible = false;
                filter2 = null;
            }
        }
        private Timer debounceTimer = new Timer();

        private void AppSercht_TextChanged(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Interval = 400;
            debounceTimer.Tick += (s, args) =>
            {
                debounceTimer.Stop();
                //HandleSearchTextChange();
            };
            debounceTimer.Start();
        }

        private void AppSerchtext_TextChanged(object sender, EventArgs e)
        {
            string input = AppSerchtext.Text.Trim();
            if (string.IsNullOrWhiteSpace(input) || input == "eg. yyyy-MM-dd")
                return;

            if (FilterDateBox.Visible)
            {
                if (DateTime.TryParse(input, out DateTime date))
                {
                    if (filter2 == "Appointment Date")
                    {
                        LoadHistory(AppointmentId, FacilityiId, ClientId, appointmentDateFilter: date);
                    }
                    else if (filter2 == "Date Booked")
                    {
                        LoadHistory(AppointmentId, FacilityiId, ClientId, dateBookedFilter: date);
                    }
                }
            }
        }
        string clientname = "", appdate = "", apptime = "", clientemail = "";
        public void ViewDets(int ID, int Faid, int Clid)
        {
            NotificationPanel.Visible = false;
            WelcomeLabel.Visible = false;
            AppDetsbutton.Visible = true;
            AppointmentsPanel.Visible = false;
            CalendarAppointmentPanel.Visible = false;
            ViewdetailsPanel.Visible = true;

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getFacility = "SELECT [First Name], [Last Name], Sex, Location, [Contact Number], [Email Address] FROM [Clients] WHERE [Client_ID] = ?";
                using (OleDbCommand facility = new OleDbCommand(getFacility, myConn))
                {
                    facility.Parameters.AddWithValue("?", Clid);

                    using (OleDbDataReader readers = facility.ExecuteReader())
                    {
                        if (readers.Read())
                        {
                            string namefirst = readers.IsDBNull(readers.GetOrdinal("First Name")) ? "" : readers["First Name"].ToString();
                            string namelast = readers.IsDBNull(readers.GetOrdinal("Last Name")) ? "" : readers["Last Name"].ToString();
                            clientname = ASLastName.Text = namelast; ASFirstName.Text = namefirst;
                            clientemail = ASEMStext.Text = readers.IsDBNull(readers.GetOrdinal("Email Address")) ? "" : readers["Email Address"].ToString();
                            ASsextext.Text = readers.IsDBNull(readers.GetOrdinal("Sex")) ? "" : readers["Sex"].ToString();
                            ASConumtext.Text = readers.IsDBNull(readers.GetOrdinal("Contact Number")) ? "" : readers["Contact Number"].ToString();
                            ASLoctext.Text = readers.IsDBNull(readers.GetOrdinal("Location")) ? "" : readers["Location"].ToString();
                        }
                    }
                }

                string selectAppointment = "SELECT [Appointment Status], [Appointment Date], [Date Booked],[Start Time], [End Time], [Estimated Price], [Estimated Duration] " +
                           "FROM Appointments WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Appointment_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(selectAppointment, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Clid);
                    cmd.Parameters.AddWithValue("?", Faid);
                    cmd.Parameters.AddWithValue("?", ID);

                    using (OleDbDataReader adminReader = cmd.ExecuteReader())
                    {
                        if (adminReader.Read())
                        {
                            string status = adminReader.GetString(adminReader.GetOrdinal("Appointment Status"));
                            string dateapp = adminReader.IsDBNull(adminReader.GetOrdinal("Appointment Date"))
                                ? ""
                                : adminReader.GetDateTime(adminReader.GetOrdinal("Appointment Date")).ToString("dd MMM yyyy");
                            string datebooked = adminReader.IsDBNull(adminReader.GetOrdinal("Date Booked"))
                                ? ""
                                : adminReader.GetDateTime(adminReader.GetOrdinal("Date Booked")).ToString("dd MMM yyyy");

                            string startTimeStr = adminReader["Start Time"].ToString();
                            string endTimeStr = adminReader["End Time"].ToString();
                            DateTime startTime = DateTime.Parse(startTimeStr);
                            DateTime endTime = DateTime.Parse(endTimeStr);
                            string formattedStart = startTime.ToString("hh:mm tt");
                            string formattedEnd = endTime.ToString("hh:mm tt");

                            string price = adminReader["Estimated Price"].ToString();
                            string duration = adminReader["Estimated Duration"].ToString();

                            ASdatetext.Text = dateapp + " ,    " + formattedStart + " - " + formattedEnd;
                            ASpricetext.Text = "PHP " + price + ".00";
                            ASdtext.Text = duration;
                            ASstattext.Text = status; ASbookedtext.Text = datebooked;

                            if (status == "Confirmed")
                            {
                                ASstattext.ForeColor = Color.LawnGreen;
                                ASConfrimButton.Visible = false; ASCancelButton.Visible = false;
                                ASCompleteButton.Visible = true; ASnoShoButton.Visible = true;
                            }
                            else if (status == "Pending")
                            {
                                ASstattext.ForeColor = Color.Gold;
                                ASConfrimButton.Visible = true; ASCancelButton.Visible = true;
                                ASCompleteButton.Visible = false; ASnoShoButton.Visible = false;
                            }
                            else if (status == "Completed")
                            {
                                ASstattext.ForeColor = ColorTranslator.FromHtml("#69e331");
                            }
                            else
                            {
                                ASstattext.ForeColor = Color.Red;
                                ASConfrimButton.Visible = false; ASCancelButton.Visible = false;
                                ASCompleteButton.Visible = false; ASnoShoButton.Visible = false;
                            }
                            appdate = dateapp; apptime = formattedStart;
                        }
                    }
                }
                ASserpanel.Controls.Clear();

                string serviceQuery = "SELECT [Service_ID] FROM [Appointment Services] WHERE [Appointment_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(serviceQuery, myConn))
                {
                    cmd.Parameters.AddWithValue("?", ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string serviceId = reader["Service_ID"].ToString();

                            string serviceInfoQuery = "SELECT [Service Name], [Duration] FROM [Facility Services] WHERE [Service_ID] = ?";
                            using (OleDbCommand serviceCmd = new OleDbCommand(serviceInfoQuery, myConn))
                            {
                                serviceCmd.Parameters.AddWithValue("?", serviceId);

                                using (OleDbDataReader serviceReader = serviceCmd.ExecuteReader())
                                {
                                    if (serviceReader.Read())
                                    {
                                        string serviceName = serviceReader["Service Name"].ToString();
                                        string duration = serviceReader["Duration"].ToString();

                                        ServiceDuration serviceDuration = new ServiceDuration();
                                        serviceDuration.SetInfo(serviceName, duration);
                                        ASserpanel.Controls.Add(serviceDuration);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void ASCompleteButton_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.CompletePanel();
            notice.ShowDialog();
            if (notice.Yes == "Complete")
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();
                    string updateQuery = "UPDATE Appointments SET [Appointment Status] = ? WHERE [Appointment_ID] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", "Completed");
                        cmd.Parameters.AddWithValue("?", AppointmentId);

                        cmd.ExecuteNonQuery();
                    }
                    SendCompleteEmail(AppointmentId, clientemail, clientname, appdate, apptime, Facname);
                    string senders = "Facility", titles = "Appointment Updated", messages = "Your appointment was updated.";
                    DateTime now = DateTime.Now;
                    SaveNotification(ClientId, FacilityiId, senders, titles, messages, now, AppointmentId);
                    System.Windows.Forms.MessageBox.Show("Appointment completed successfully.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SendCompleteEmail(int appointmentId, string clientEmail, string clientName, string appointmentDate, string appointmentTime, string providerName)
        {
            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Appointment Completed.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate)
                                     .Replace("{AppointmentTime}", appointmentTime);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("vaughanash02@gmail.com");
                message.Subject = "Appointment Cancellation Notice";
                message.Body = emailBody;
                message.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("snmcorporation.dlic@gmail.com", "kgap arcn qkvq ktgx");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        private void ASCancelButton_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.CancelPanel();
            if (notice.ShowDialog() == DialogResult.OK || !string.IsNullOrWhiteSpace(notice.Reason))
            {
                string reason = notice.Reason;
                if (!string.IsNullOrWhiteSpace(reason))
                {
                    using (OleDbConnection myConn = new OleDbConnection(connection))
                    {
                        myConn.Open();
                        string updateQuery = "UPDATE Appointments SET [Appointment Status] = ?, [Reason] = ? WHERE [Appointment_ID] = ?";

                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                        {
                            cmd.Parameters.AddWithValue("?", "Cancelled");
                            cmd.Parameters.AddWithValue("?", reason);
                            cmd.Parameters.AddWithValue("?", AppointmentId);

                            cmd.ExecuteNonQuery();
                        }

                        SendCancelEmail(AppointmentId, clientemail, clientname, appdate, apptime, Facname, reason);
                        string senders = "Facility", titles = "Appointment Updated", messages = "Your appointment was updated.";
                        DateTime now = DateTime.Now;
                        SaveNotification(ClientId, FacilityiId, senders, titles, messages, now, AppointmentId);
                        System.Windows.Forms.MessageBox.Show("Appointment cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void SendCancelEmail(int appointmentId, string clientEmail, string clientName, string appointmentDate, string appointmentTime, string providerName, string Reason)
        {
            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Appointment Cancellation by Facility.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate)
                                     .Replace("{AppointmentTime}", appointmentTime)
                                     .Replace("{Reasonbyfacility}", Reason);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("vaughanash02@gmail.com");
                message.Subject = "Appointment Cancellation Notice";
                message.Body = emailBody;
                message.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("snmcorporation.dlic@gmail.com", "kgap arcn qkvq ktgx");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        private void ASConfrimButton_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.ConfirmPanel();
            notice.ShowDialog();
            if (notice.Yes == "Confirm")
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();
                    string updateQuery = "UPDATE Appointments SET [Appointment Status] = ? WHERE [Appointment_ID] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", "Confirmed");
                        cmd.Parameters.AddWithValue("?", AppointmentId);

                        cmd.ExecuteNonQuery();
                    }
                    SendConfirmEmail(AppointmentId, clientemail, clientname, appdate, apptime, Facname);
                    string senders = "Facility", titles = "Appointment Updated", messages = "Your appointment was updated.";
                    DateTime now = DateTime.Now;
                    SaveNotification(ClientId, FacilityiId, senders, titles, messages, now, AppointmentId);
                    System.Windows.Forms.MessageBox.Show("Appointment confirmed successfully.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SendConfirmEmail(int appointmentId, string clientEmail, string clientName, string appointmentDate, string appointmentTime, string providerName)
        {
            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Appointment Confirmed.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate)
                                     .Replace("{AppointmentTime}", appointmentTime);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("vaughanash02@gmail.com");
                message.Subject = "Appointment Cancellation Notice";
                message.Body = emailBody;
                message.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("snmcorporation.dlic@gmail.com", "kgap arcn qkvq ktgx");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        private void ASnoShoButton_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.NoshowPanel();
            notice.ShowDialog();
            if (notice.Yes == "No Show")
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();
                    string updateQuery = "UPDATE Appointments SET [Appointment Status] = ? WHERE [Appointment_ID] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", "No Show");
                        cmd.Parameters.AddWithValue("?", AppointmentId);

                        cmd.ExecuteNonQuery();
                    }

                    SendNoshowEmail(AppointmentId, clientemail, clientname, appdate, apptime, Facname);
                    string senders = "Facility", titles = "Appointment Updated", messages = "Your appointment was updated.";
                    DateTime now = DateTime.Now;
                    SaveNotification(ClientId, FacilityiId, senders, titles, messages, now, AppointmentId);
                    System.Windows.Forms.MessageBox.Show("Appointment confirmed successfully.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SendNoshowEmail(int appointmentId, string clientEmail, string clientName, string appointmentDate, string appointmentTime, string providerName)
        {
            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Appointment Noshow.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate)
                                     .Replace("{AppointmentTime}", appointmentTime);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("vaughanash02@gmail.com");
                message.Subject = "Appointment Cancellation Notice";
                message.Body = emailBody;
                message.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("snmcorporation.dlic@gmail.com", "kgap arcn qkvq ktgx");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        private void filesbutton_Click(object sender, EventArgs e)
        {
            UFilebutton.Visible = true; UploadfilesPanel.Visible = true;
            WelcomeLabel.Visible = false; ProfilePanel.Visible = false;
        }

        private void UFilebutton_Click(object sender, EventArgs e)
        {
            UFilebutton.Visible = false; UploadfilesPanel.Visible = false; WelcomeLabel.Visible = true;
            ProfilePanel.Visible = true;
        }

        byte[] businessRegistrationBytes = null;
        byte[] governmentIdBytes = null;
        byte[] facilityPhotosBytes = null;
        byte[] serviceLicensesBytes = null;
        byte[] proofOfAddressBytes = null;
        byte[] taxDocumentsBytes = null;
        byte[] insuranceComplianceBytes = null;

        private void File1button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Business Registration Document";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                businessRegistrationBytes = File.ReadAllBytes(ofd.FileName);
                File1Fname.Visible = true; File1Fname.Text = Path.GetFileName(ofd.FileName); File1button.BackColor = Color.White;
                File1button.ForeColor = ColorTranslator.FromHtml("#69e331"); Allfiles.Visible = false;
                Notice notice = new Notice();
                notice.UploadPanel();
            }
        }

        private void File2button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Government-issued ID";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                governmentIdBytes = File.ReadAllBytes(ofd.FileName);
                File2Fname.Visible = true; File2Fname.Text = Path.GetFileName(ofd.FileName); File2button.BackColor = Color.White;
                File2button.ForeColor = ColorTranslator.FromHtml("#69e331"); Allfiles.Visible = false;
                Notice notice = new Notice();
                notice.UploadPanel();
            }
        }

        private void File3button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Images (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    byte[] fileData = File.ReadAllBytes(filePath);
                    using (OleDbConnection myConn = new OleDbConnection(connection))
                    {
                        myConn.Open();
                        using (OleDbCommand cmd = new OleDbCommand("INSERT INTO [Facility Photos] (Facility_ID, Photos, [Uploaded Date]) VALUES (?, ?, ?)", myConn))
                        {
                            cmd.Parameters.AddWithValue("?", FacilityiId);
                            cmd.Parameters.AddWithValue("?", fileData);
                            cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("dd MMM yyyy"));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                File3Fname.Visible = true; File3Fname.Text = "Photos Uploaded";
                File3button.ForeColor = ColorTranslator.FromHtml("#69e331"); File3button.BackColor = Color.White;
                Notice notice = new Notice(); Allfiles.Visible = false;
                notice.UploadPanel();
            }
        }

        private void File4button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Service Licenses / Certifications";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                serviceLicensesBytes = File.ReadAllBytes(ofd.FileName);
                File4Fname.Visible = true; File4Fname.Text = Path.GetFileName(ofd.FileName); Allfiles.Visible = false;
                File4button.ForeColor = ColorTranslator.FromHtml("#69e331"); File4button.BackColor = Color.White;
                Notice notice = new Notice();
                notice.UploadPanel();
            }
        }

        private void File5button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Proof of Address";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                proofOfAddressBytes = File.ReadAllBytes(ofd.FileName);
                File5Fname.Visible = true; File5Fname.Text = Path.GetFileName(ofd.FileName); Allfiles.Visible = false;
                File5button.ForeColor = ColorTranslator.FromHtml("#69e331"); File5button.BackColor = Color.White;
                Notice notice = new Notice();
                notice.UploadPanel();
            }
        }

        private void File6button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Tax Documents";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                taxDocumentsBytes = File.ReadAllBytes(ofd.FileName);
                File6Fname.Visible = true; File6Fname.Text = Path.GetFileName(ofd.FileName); Allfiles.Visible = false;
                File6button.ForeColor = ColorTranslator.FromHtml("#69e331"); File6button.BackColor = Color.White;
                Notice notice = new Notice();
                notice.UploadPanel();
            }
        }

        private void File7button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Insurance or Safety Compliance";
            ofd.Filter = "All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                insuranceComplianceBytes = File.ReadAllBytes(ofd.FileName);
                File7Fname.Visible = true; File7Fname.Text = Path.GetFileName(ofd.FileName); Allfiles.Visible = false;
                File7button.ForeColor = ColorTranslator.FromHtml("#69e331"); File7button.BackColor = Color.White;
                Notice notice = new Notice();
                notice.UploadPanel();
            }
        }

        private void Filesubmitbutton_Click(object sender, EventArgs e)
        {
            if (FacilityiId == 0)
            {
                System.Windows.Forms.MessageBox.Show("Facility ID is not valid.");
                return;
            }
            if (File1Fname.Text != "No file uploaded." && File2Fname.Text != "No file uploaded." && File3Fname.Text != "No file uploaded." && File4Fname.Text != "No file uploaded." && File5Fname.Text != "No file uploaded." && File6Fname.Text != "No file uploaded." && File7Fname.Text != "No file uploaded.")
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();

                    string facilityfiles = "INSERT INTO [Facility Files] " +
                        "(Facility_ID, [Business Registration], [Valid Government-issued ID]," +
                        "[Service Licenses / Certifications], [Proof of Address], [Tax Documents], [Insurance or Safety Compliance], [Uploaded Date]) " +
                        "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(facilityfiles, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", FacilityiId);
                        cmd.Parameters.AddWithValue("?", (object)businessRegistrationBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("?", (object)governmentIdBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("?", (object)serviceLicensesBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("?", (object)proofOfAddressBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("?", (object)taxDocumentsBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("?", (object)insuranceComplianceBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("dd MMM yyyy"));

                        cmd.ExecuteNonQuery();
                        System.Windows.Forms.MessageBox.Show("Facility files uploaded successfully!");
                    }
                }
            }
            else
            {
                if (File1Fname.Text == "No file uploaded.")
                {
                    File1button.BackColor = Color.MistyRose; File1button.ForeColor = Color.Red;
                }
                else if (File2Fname.Text == "No file uploaded.")
                {
                    File2button.BackColor = Color.MistyRose; File2button.ForeColor = Color.Red;
                }
                else if (File3Fname.Text == "No file uploaded.")
                {
                    File3button.BackColor = Color.MistyRose; File3button.ForeColor = Color.Red;
                }
                else if (File4Fname.Text == "No file uploaded.")
                {
                    File4button.BackColor = Color.MistyRose; File4button.ForeColor = Color.Red;
                }
                else if (File5Fname.Text == "No file uploaded.")
                {
                    File5button.BackColor = Color.MistyRose; File5button.ForeColor = Color.Red;
                }
                else if (File6Fname.Text == "No file uploaded.")
                {
                    File6button.BackColor = Color.MistyRose; File6button.ForeColor = Color.Red;
                }
                else if (File7Fname.Text == "No file uploaded.")
                {
                    File7button.BackColor = Color.MistyRose; File7button.ForeColor = Color.Red;
                }
                Allfiles.Visible = true;
            }
        }

        Dictionary<string, int> GetAppointmentStatusCounts(int facilityId)
        {
            var statusCounts = new Dictionary<string, int>();

            string query = "SELECT [Appointment Status], COUNT(*) AS Total " +
                           "FROM Appointments WHERE [Facility_ID] = ? GROUP BY [Appointment Status]";

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", facilityId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["Appointment Status"].ToString();
                            int count = Convert.ToInt32(reader["Total"]);
                            statusCounts[status] = count;
                        }
                    }
                }
            }

            return statusCounts;
        }

        private void LoadAppointmentPieChart()
        {
            Dictionary<string, int> appointmentStatusCounts = GetAppointmentStatusCounts(FacilityiId);

            PlotModel pieModel = new PlotModel { };
            var pieSeries = new PieSeries
            {
                StrokeThickness = 1.5,
                InsideLabelPosition = 0.8,
                InsideLabelFormat = "{1}: {0}",
                AngleSpan = 360,
                StartAngle = 0,
                FontSize = 10,
                InsideLabelColor = OxyColors.White,
            };

            var colors = new[]
            {
                OxyColor.FromRgb(219, 0, 0),//Cancelled
                OxyColor.FromRgb(137,243,54),//Completed
                OxyColor.FromRgb(0,127,255),//confirmed
                OxyColor.FromRgb(127, 0, 255), // noshow
                OxyColor.FromRgb(255, 228, 54) //pending
            };

            int i = 0;
            foreach (var entry in appointmentStatusCounts)
            {
                pieSeries.Slices.Add(new PieSlice(entry.Key, entry.Value)
                {
                    Fill = colors[i % colors.Length]
                });
                i++;
            }

            pieModel.Series.Add(pieSeries);
            AppointmentsPieChart.Model = pieModel;
        }

        Dictionary<DateTime, double> GetDailyRevenue(int FacilityiId)
        {
            var revenuePerDay = new Dictionary<DateTime, double>();

            string query = "SELECT [Appointment Date], SUM([Estimated Price]) AS Revenue " +
                           "FROM Appointments WHERE [Facility_ID] = ? AND [Appointment Status] = 'Completed' " +
                           "GROUP BY [Appointment Date] ORDER BY [Appointment Date]";

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", FacilityiId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = Convert.ToDateTime(reader["Appointment Date"]);
                            double revenue = Convert.ToDouble(reader["Revenue"]);
                            revenuePerDay[date] = revenue;
                        }
                    }
                }
            }

            return revenuePerDay;
        }

        private void LoadRevenueLineChart()
        {
            Analytics2Title.Text = "Revenue by Appointment";
            Dictionary<DateTime, double> revenueData = GetDailyRevenue(FacilityiId);

            var model = new PlotModel { };

            var xAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "MMM-dd",
                Title = "Date",
                IntervalType = DateTimeIntervalType.Days,
                MinorIntervalType = DateTimeIntervalType.Days,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                MinimumPadding = 0.2,
                MaximumPadding = 0.2,
                AbsoluteMinimum = 0
            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Revenue (₱)",
                MinimumPadding = 0.2,
                MaximumPadding = 0.2,
                AbsoluteMinimum = 0
            };

            model.Axes.Add(xAxis);
            model.Axes.Add(yAxis);

            var series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColor.FromRgb(240, 36, 110),
                Color = OxyColor.FromRgb(240, 36, 110),
                StrokeThickness = 2
            };

            foreach (var entry in revenueData)
            {
                series.Points.Add(DateTimeAxis.CreateDataPoint(entry.Key, entry.Value));
            }

            model.Series.Add(series);
            Analytics2.Model = model;
        }

        Dictionary<string, int> GetPopularServices(int facilityId)
        {
            var serviceCounts = new Dictionary<string, int>();

            string query = @"
            SELECT [Facility Services].[Service Name], COUNT(*) AS BookingCount
            FROM [Facility Services]
            INNER JOIN (Appointments 
            INNER JOIN [Appointment Services] 
            ON Appointments.Appointment_ID = [Appointment Services].Appointment_ID)
            ON [Facility Services].Service_ID = [Appointment Services].Service_ID
            WHERE Appointments.[Facility_ID] = @FacilityId
            AND Appointments.[Appointment Status] = @Status
            GROUP BY [Facility Services].[Service Name]
            ORDER BY BookingCount DESC";

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FacilityId", facilityId);
                    cmd.Parameters.AddWithValue("@Status", "Completed");
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string service = reader["Service Name"] as string ?? "Unknown Service";
                            int count = reader["BookingCount"] != DBNull.Value ? Convert.ToInt32(reader["BookingCount"]) : 0;
                            serviceCounts[service] = count;
                        }
                    }
                }
            }

            return serviceCounts;
        }

        private void LoadPopularServicesChart()
        {
            Analytics1Title.Text = "Popular Services";
            Dictionary<string, int> serviceData = GetPopularServices(FacilityiId);

            var model = new PlotModel { };

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Service",
                GapWidth = 0.3
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Number of Bookings",
                MinimumPadding = 0.2,
                MaximumPadding = 0.2,
                AbsoluteMinimum = 0
            };

            var series = new BarSeries
            {
                ItemsSource = serviceData.Select(kv => new BarItem { Value = kv.Value }).ToList(),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                FillColor = OxyColor.FromRgb(240, 36, 110)
            };

            foreach (var service in serviceData.Keys)
                categoryAxis.Labels.Add(service);

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            model.Series.Add(series);

            Analytics1.Model = model;
        }


        void LoadPopularTimeslotsChart()
        {
            Analytics1Title.Text = "Popular Timeslots";

            PlotModel model = new PlotModel { };

            var lineSeries = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                StrokeThickness = 2,
                Color = OxyColors.DodgerBlue,
                CanTrackerInterpolatePoints = false
            };

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                GapWidth = 0.5
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                MinimumPadding = 0.2,
                MaximumPadding = 0.2,
                AbsoluteMinimum = 0
            };

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                string query = @"SELECT FORMAT([Appointment Date], 'hh AM/PM') AS HourSlot, COUNT(*) AS BookingCount
                         FROM [Appointments]
                         WHERE [Facility_ID] = ? AND [Appointment Status] = 'Completed'
                         GROUP BY FORMAT([Appointment Date], 'hh AM/PM')
                         ORDER BY MIN([Appointment Date]) ASC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", FacilityiId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int index = 0;
                        while (reader.Read())
                        {
                            string hourSlot = reader["HourSlot"].ToString();
                            double bookingCount = Convert.ToDouble(reader["BookingCount"]);

                            lineSeries.Points.Add(new DataPoint(index, bookingCount));
                            categoryAxis.Labels.Add(hourSlot);
                            index++;
                        }
                    }
                }
            }

            model.Series.Add(lineSeries);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            Analytics1.Model = model;
        }



        private void LoadCustomerGrowthChart()
        {
            Analytics1Title.Text = "Customer Growth";
            PlotModel model = new PlotModel { Title = "Customer Growth" };

            LineSeries lineSeries = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Blue,
                Color = OxyColors.Blue,
                StrokeThickness = 2,
            };

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                string query = @"
                            SELECT [Appointment Date], COUNT(*) AS UniqueClients
                            FROM (
                                SELECT [Appointment Date], [Client_ID]
                                FROM Appointments
                                WHERE [Facility_ID] = ?
                                GROUP BY [Appointment Date], [Client_ID]
                            ) AS Subquery
                            GROUP BY [Appointment Date]
                            ORDER BY [Appointment Date];
                            ";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", FacilityiId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime appointmentDate = Convert.ToDateTime(reader["Appointment Date"]);
                            int uniqueClients = Convert.ToInt32(reader["UniqueClients"]);

                            lineSeries.Points.Add(DateTimeAxis.CreateDataPoint(appointmentDate, uniqueClients));
                        }
                    }
                }
            }

            model.Series.Add(lineSeries);

            model.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "MMM dd",
                Title = "Date",
                IntervalType = DateTimeIntervalType.Days,
                MinorIntervalType = DateTimeIntervalType.Days,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                MinimumPadding = 0.2,
                MaximumPadding = 0.2,
                AbsoluteMinimum = 0
            });

            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Unique Clients",
                MinimumPadding = 0.2,
                MaximumPadding = 0.2,
                AbsoluteMinimum = 0
            });

            Analytics1.Model = model;
        }

        void LoadFacilityAnalyticsSummary()
        {
            decimal totalRevenue = 0;
            int totalCustomers = 0;
            int totalAppointments = 0;

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                string revenueQuery = @"SELECT SUM([Estimated Price]) FROM [Appointments] WHERE [Facility_ID] = ? AND [Appointment Status] = ?";
                using (OleDbCommand cmd = new OleDbCommand(revenueQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", FacilityiId);
                    cmd.Parameters.AddWithValue("?", "Completed");
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        totalRevenue = Convert.ToDecimal(result);
                }

                string customerQuery = @"
                                    SELECT COUNT(*) AS UniqueClients
                                    FROM (
                                        SELECT [Client_ID]
                                        FROM [Appointments]
                                        WHERE [Facility_ID] = ? 
                                        AND [Appointment Status] = ?
                                        GROUP BY [Client_ID]
                                    ) AS UniqueClientsTable";

                using (OleDbCommand cmd = new OleDbCommand(customerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", FacilityiId);
                    cmd.Parameters.AddWithValue("?", "Completed");

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                        totalCustomers = Convert.ToInt32(result);
                }

                string appointmentQuery = @"SELECT COUNT(*) FROM [Appointments] WHERE [Facility_ID] = ?";
                using (OleDbCommand cmd = new OleDbCommand(appointmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", FacilityiId);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        totalAppointments = Convert.ToInt32(result);
                }
            }

            TotalRevenutext.Text = $"₱ {totalRevenue:N2}";
            TotalCGtext.Text = $"{totalCustomers}";
            TotalAppstext.Text = $"{totalAppointments}";
        }

        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;

        private void StartCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                //videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No camera detected.");
            }
        }

        /*private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader barcodeReader = new BarcodeReader();

            var reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true
            };

            var result = reader.Decode(bitmap);

            if (result != null)
            {
                string qrContent = result.Text;

                string[] parts = qrContent.Split('|');
                if (parts.Length == 3)
                {
                    int appointmentId = int.Parse(parts[0]);
                    int facilityId = int.Parse(parts[1]);
                    int clientId = int.Parse(parts[2]);

                    if (videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                    }

                    Invoke(new Action(() =>
                    {
                        ViewDets(appointmentId, facilityId, clientId);
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Invalid QR code format.");
                    }));
                }
            }
            QRBox.Image = bitmap;
        }*/

        private void QRbutton_Click(object sender, EventArgs e)
        {
            if (QRBox.Visible == true)
            {
                QRBox.Visible = false;
            }
            else
            {
                QRBox.Visible = true;
            }

        }
        private void MessageBox_Click(object sender, EventArgs e)
        {
            Messagerpanel.Visible = true; Messagerpanel.BringToFront();
            LoadChatMessages(ClientId, FacilityiId);
        }
        private void Messengerclose_Click(object sender, EventArgs e)
        {
            Messagerpanel.Visible = false;
        }
        private void LoadChatMessages(int clientId, int facilityId)
        {
            NotificationPanel.Visible = false;
            MessagePanel.Controls.Clear();

            using (OleDbConnection con = new OleDbConnection(connection))
            {
                con.Open();
                string query = @"SELECT [Sender], [Messages], [Date and Time]
                 FROM Messenger
                 WHERE [Client_ID] = ? AND [Facility_ID] = ?
                 ORDER BY [Date and Time] ASC";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ClientId", clientId);
                    cmd.Parameters.AddWithValue("@FacilityId", facilityId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string senderType = reader["Sender"].ToString();
                            string message = reader["Messages"].ToString();
                            DateTime time = Convert.ToDateTime(reader["Date and Time"]);

                            AddMessageBubble(senderType, message, time);
                        }
                    }
                }
            }
        }

        private void SaveMessageToDatabase(int clientId, int facilityId, string senderType, string message)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();
                string query = @"INSERT INTO Messenger (Client_ID, Facility_ID, Sender, Messages, [Date and Time])
                 VALUES (@ClientId, @FacilityId, @Sender, @Message, @DateAndTime)";

                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.Add("@ClientId", OleDbType.Integer).Value = clientId;
                    cmd.Parameters.Add("@FacilityId", OleDbType.Integer).Value = facilityId;
                    cmd.Parameters.Add("@Sender", OleDbType.VarWChar).Value = senderType;
                    cmd.Parameters.Add("@Message", OleDbType.VarWChar).Value = message;
                    cmd.Parameters.Add("@DateAndTime", OleDbType.Date).Value = DateTime.Now;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void EnterMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Messengertext.Text))
            {
                string senderType = "Client";
                string message = Messengertext.Text.Trim();

                int clientI = ClientId;
                int facilityId = FacilityiId;

                DateTime now = DateTime.Now;

                SaveMessageToDatabase(clientI, facilityId, senderType, message);
                string senders = "Facility", titles = "New Message", messages = "Facility sent you a message!";
                SaveNotificationMessage(clientI, facilityId, senders, titles, messages, now);
                AddMessageBubble(senderType, message, now);

                Messengertext.Clear();
            }
        }

        private void AddMessageBubble(string senderType, string message, DateTime time)
        {
            Panel panel = new Panel();
            panel.AutoSize = true;
            panel.Padding = new Padding(10);
            panel.BackColor = senderType == "Client" ? SystemColors.GradientInactiveCaption : Color.LightGray;
            panel.Margin = new Padding(5);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblMessage.MaximumSize = new Size(250, 0);

            Label lblTime = new Label();
            lblTime.Text = time.ToString("hh:mm tt");
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblTime.ForeColor = Color.DarkGray;
            lblTime.Margin = new Padding(0, 5, 0, 0);

            panel.Controls.Add(lblMessage);
            panel.Controls.Add(lblTime);

            lblTime.Location = new Point(0, lblMessage.Bottom + 5);

            MessagePanel.Controls.Add(panel);
        }

        private void SaveNotification(int clientId, int facilityId, string sender, string title, string message, DateTime now, int appointmentId)
        {
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                string query = $@"INSERT INTO Notifications (Client_ID, Facility_ID, Sender, Title, Message, [Date and Time], [View Status], Appointment_ID)
                                    VALUES ({clientId}, {facilityId}, '{sender}', '{title}', '{message}', '{now}', FALSE, {appointmentId})";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    /*cmd.Parameters.AddWithValue("@ClientId", clientId);
                    cmd.Parameters.AddWithValue("@FacilityId", facilityId);
                    cmd.Parameters.AddWithValue("@Sender", sender);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Message", message);
                    cmd.Parameters.AddWithValue("@DateAndTime", now);
                    cmd.Parameters.AddWithValue("@IsRead", "No");
                    cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);*/

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveNotificationMessage(int clientId, int facilityId, string sender, string title, string message, DateTime now)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connection))
                {
                    conn.Open();
                    string query = $@"INSERT INTO Notifications (Client_ID, Facility_ID, Sender, Title, Message, [Date and Time], [View Status], Appointment_ID)
                                    VALUES ({clientId}, {facilityId}, '{sender}', '{title}', '{message}', '{now}', FALSE, NULL)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        /*cmd.Parameters.AddWithValue("@ClientId", clientId);
                        cmd.Parameters.AddWithValue("@FacilityId", facilityId);
                        cmd.Parameters.AddWithValue("@Sender", sender);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Message", message);
                        cmd.Parameters.AddWithValue("@DateAndTime", now);
                        cmd.Parameters.AddWithValue("@IsRead", false);
                        cmd.Parameters.AddWithValue("@AppointmentId", DBNull.Value);*/

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine($"Database error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        private void AddNotification(string title, string message, DateTime notifTime, int? appointmentId, int appointmentRealId, int facilityId, int clientId, bool isViewed)
        {
            Panel notifPanel = new Panel();
            notifPanel.BackColor = isViewed ? Color.Gainsboro : Color.Snow;
            notifPanel.BorderStyle = BorderStyle.FixedSingle;
            notifPanel.Padding = new Padding(10);
            notifPanel.Margin = new Padding(5);
            notifPanel.Width = 300;
            notifPanel.AutoSize = true;
            notifPanel.Cursor = appointmentId.HasValue ? Cursors.Hand : Cursors.Default;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(0, 3);

            Label lblTime = new Label();
            lblTime.Text = notifTime.ToString("hh:mm tt");
            lblTime.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblTime.ForeColor = Color.Gray;
            lblTime.AutoSize = true;
            lblTime.Location = new Point(notifPanel.Width - 70, 5);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 10);
            lblMessage.AutoSize = true;
            lblMessage.MaximumSize = new Size(300, 0);
            lblMessage.Location = new Point(2, lblTitle.Bottom + 5);

            void HandleClick()
            {
                FacilityiId = facilityId;
                ClientId = clientId;
                if (!isViewed)
                {
                    using (OleDbConnection myConn = new OleDbConnection(connection))
                    {
                        myConn.Open();
                        if (appointmentId.HasValue)
                        {
                            string updateQuery = "UPDATE Notifications SET [View Status] = ? WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Date and Time] = ?";

                            using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                            {
                                cmd.Parameters.AddWithValue("?", true);
                                cmd.Parameters.AddWithValue("?", clientId);
                                cmd.Parameters.AddWithValue("?", facilityId);
                                cmd.Parameters.AddWithValue("?", notifTime);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            DateTime now = notifTime;
                            string updateQuery = "UPDATE Notifications SET [View Status] = ? WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Date and Time] = ?";

                            using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                            {
                                cmd.Parameters.AddWithValue("?", true);
                                cmd.Parameters.AddWithValue("?", clientId);
                                cmd.Parameters.AddWithValue("?", facilityId);
                                cmd.Parameters.AddWithValue("?", $"{notifTime}");

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                        
                    notifPanel.BackColor = Color.Gainsboro;
                    isViewed = true;
                }

                if (appointmentId.HasValue)
                {
                    ViewDets(appointmentRealId, facilityId, clientId);
                }
                else
                {
                    Messagerpanel.Visible = true;
                    Messagerpanel.BringToFront();
                    LoadChatMessages(clientId, facilityId);
                }
            }

            notifPanel.Click += (s, e) => HandleClick();
            /*if (appointmentId.HasValue)
            {
                
                notifPanel.Click += (s, e) => ViewDets(appointmentRealId, facilityId, clientId); 
                foreach (Control control in new Control[] { lblTitle, lblMessage, lblTime })
                {
                    control.Click += (s, e) => ViewDets(appointmentRealId, facilityId, clientId); 
                }
                
            }
            else
            {
                FacilityiId = facilityId;
                ClientId = clientId;
                notifPanel.Click += (s, e) =>
                {
                    Messagerpanel.Visible = true;
                    Messagerpanel.BringToFront();
                    
                    LoadChatMessages(clientId, facilityId);
                };
                foreach (Control control in new Control[] { lblTitle, lblMessage, lblTime })
                {
                    control.Click += (s, e) =>
                    {
                        Messagerpanel.Visible = true;
                        Messagerpanel.BringToFront();
                        
                        LoadChatMessages(clientId, facilityId);
                    };
                }
                
            }*/

            notifPanel.Controls.Add(lblTitle);
            notifPanel.Controls.Add(lblTime);
            notifPanel.Controls.Add(lblMessage);

            NotifyPanel.Controls.Add(notifPanel);
        }


        private void LoadFacilityNotifications(int facid)
        {
            NotifyPanel.Controls.Clear();
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                string query = @"SELECT Title, Message, [Date and Time], Appointment_ID, Facility_ID, Client_ID, [View Status]
                         FROM Notifications
                         WHERE Facility_ID = ? AND Sender = ?
                         ORDER BY [Date and Time] DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", facid);
                    cmd.Parameters.AddWithValue("?", "Client");

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            string message = reader["Message"].ToString();
                            DateTime time = Convert.ToDateTime(reader["Date and Time"]);

                            int? appointmentId = reader["Appointment_ID"] != DBNull.Value ? Convert.ToInt32(reader["Appointment_ID"]) : (int?)null;
                            int facilityId = reader["Facility_ID"] != DBNull.Value ? Convert.ToInt32(reader["Facility_ID"]) : 0;
                            int clientId = reader["Client_ID"] != DBNull.Value ? Convert.ToInt32(reader["Client_ID"]) : 0;
                            bool isViewed = reader["View Status"] != DBNull.Value ? Convert.ToBoolean(reader["View Status"]) : false;

                            AddNotification(title, message, time, appointmentId, appointmentId ?? 0, facilityId, clientId, isViewed);
                        }
                    }
                }
            }
        }

    }
}
