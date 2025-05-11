using Microsoft.VisualBasic;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Configuration.Provider;
using OOP2.Forms;

namespace OOP2
{
    public partial class ClientDashboard : Form, ClientInfo, FacilityInfo
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

        string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\OOP2 Database - Copy.accdb";

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
        string formattedBirthdate, sercat = "";
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

        string locs = "", Ems = "", selectedTime = "", filter1 = "", filter2 = "", appdate = "", apptime = "";
        int facid, Appid;
        int clientId;
        Timer slideshowTimer = new Timer();
        List<Image> images = new List<Image>();
        int currentImageIndex = 0;
        public ClientDashboard()
        {
            InitializeComponent();
            InfoGetter(); LoadHistory(Appid, facid, clientId); LoadUpcomingHistory(Appid, facid, clientId);
            Loaders(); LoadTopFacilities(); 
            HiLabel.Text = $"Hi {FName},";
            AppSerchtext.TextChanged += AppSerchtext_TextChanged;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            ProfilePanel.Visible = false;
            NotificationPanel.Visible = false;
            SettingPanel.Visible = false;
            panel44.Visible = false;
            FacilityProPanel.Visible = false; AppSearch.Visible = false;
            FPButton.Visible = false; FilterBox.Visible = false; FilterDateBox.Visible = false; FilterStatusBox.Visible = false;
            FacilityProPanel2.Visible = false; ASReasontext.Visible = false; ASReasonlabel.Visible = false;
            PIEButton.Visible = false; FillEM.Visible = false; BookAppbutton.Visible = false;
            EditPIPanel.Visible = false; CnumberExisted.Visible = false; CnumberInvalid.Visible = false;

            images.Add(Image.FromFile(@"D:\\OOP2\\HTML\\Ads1.jpg"));
            images.Add(Image.FromFile(@"D:\\OOP2\\HTML\\Ads2.jpg"));
            images.Add(Image.FromFile(@"D:\\OOP2\\HTML\\Ads3.jpg"));

            AdsBox.SizeMode = PictureBoxSizeMode.StretchImage;
            slideshowTimer.Interval = 2000;
            slideshowTimer.Tick += SlideshowTimer_Tick;
            slideshowTimer.Start();
        }
        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            if (images.Count == 0) return;

            AdsBox.Image = images[currentImageIndex];
            currentImageIndex++;

            if (currentImageIndex >= images.Count)
                currentImageIndex = 0;
        }

        public void Loaders()
        {
            NotificationPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, NotificationPanel.Width, NotificationPanel.Height, 10, 10));
            MessagePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MessagePanel.Width, MessagePanel.Height, 10, 10));
            RateButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, RateButton.Width, RateButton.Height, 10, 10));
            RecomdPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, RecomdPanel.Width, RecomdPanel.Height, 10, 10));

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

            //SERVICES
            ServicesPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ServicesPanel.Width, ServicesPanel.Height, 10, 10));
            BeautySPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BeautySPanel.Width, BeautySPanel.Height, 10, 10));
            HealthSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HealthSPanel.Width, HealthSPanel.Height, 10, 10));
            FitnessSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FitnessSPanel.Width, FitnessSPanel.Height, 10, 10));
            EduSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EduSPanel.Width, EduSPanel.Height, 10, 10));
            RepairSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, RepairSPanel.Width, RepairSPanel.Height, 10, 10));
            FoodSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FoodSPanel.Width, FoodSPanel.Height, 10, 10));
            MisSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MisSPanel.Width, MisSPanel.Height, 10, 10));
            FitnessSbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FitnessSbutton.Width, FitnessSbutton.Height, 10, 10));
            HealthSbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HealthSbutton.Width, HealthSbutton.Height, 10, 10));
            BeautySbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BeautySbutton.Width, BeautySbutton.Height, 10, 10));
            RepairSbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, RepairSbutton.Width, RepairSbutton.Height, 10, 10));
            EduSbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EduSbutton.Width, EduSbutton.Height, 10, 10));
            FoodSbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FoodSbutton.Width, FoodSbutton.Height, 10, 10));
            MisSbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, MisSbutton.Width, MisSbutton.Height, 10, 10));

            //SERVICES 2
            SerPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SerPanel.Width, SerPanel.Height, 10, 10));
            FacProPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FacProPanel.Width, FacProPanel.Height, 10, 10));
            FacSerOPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FacSerOPanel.Width, FacSerOPanel.Height, 10, 10));
            EditButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EditButton.Width, EditButton.Height, 10, 10));
            BaASerpanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BaASerpanel.Width, BaASerpanel.Height, 10, 10));
            BaADTPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BaADTPanel.Width, BaADTPanel.Height, 10, 10));
            SOTable.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOTable.Width, SOTable.Height, 10, 10));
            FPBookAppButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FPBookAppButton.Width, FPBookAppButton.Height, 10, 10));

            //Calendar
            CalendarPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CalendarPanel.Width, CalendarPanel.Height, 10, 10));
            calendarsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, calendarsButton.Width, calendarsButton.Height, 10, 10));
            CACnext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CACnext.Width, CACnext.Height, 10, 10));
            CACprev.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CACprev.Width, CACprev.Height, 10, 10));

            //Appointment
            AppointmentsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppointmentsPanel.Width, AppointmentsPanel.Height, 10, 10));
            appointmentsbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, appointmentsbutton.Width, appointmentsbutton.Height, 10, 10));

            //APPOINTMENT DETAILS
            AstoreproPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AstoreproPanel.Width, AstoreproPanel.Height, 10, 10));
            AstatPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AstatPanel.Width, AstatPanel.Height, 10, 10));
            ReschedButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ReschedButton.Width, ReschedButton.Height, 10, 10));
            BaASerpanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BaASerpanel.Width, BaASerpanel.Height, 10, 10));
            BaADTPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BaADTPanel.Width, BaADTPanel.Height, 10, 10));
            ATCPrev.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATCPrev.Width, ATCPrev.Height, 10, 10));
            ATCNext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ATCNext.Width, ATCNext.Height, 10, 10));

            //PROFILE
            ProPicPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProPicPanel.Width, ProPicPanel.Height, 10, 10));
            PIPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIPanel.Width, PIPanel.Height, 10, 10));
            GPPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, GPPanel.Width, GPPanel.Height, 10, 10));
            PIEditButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIEditButton.Width, PIEditButton.Height, 10, 10));
            button48.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button48.Width, button48.Height, 10, 10));
            button49.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button49.Width, button49.Height, 10, 10));
            CUIButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CUIButton.Width, CUIButton.Height, 10, 10));
            PIEprofilepanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIEprofilepanel.Width, PIEprofilepanel.Height, 10, 10));
            PIEpanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PIEpanel.Width, PIEpanel.Height, 10, 10));
            DeleteAccButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DeleteAccButton.Width, DeleteAccButton.Height, 10, 10));

            //SETTINGS
            GeneralPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, GeneralPanel.Width, GeneralPanel.Height, 10, 10));
            AppearancePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AppearancePanel.Width, AppearancePanel.Height, 10, 10));
            NotsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, NotsPanel.Width, NotsPanel.Height, 10, 10));
            AccsPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AccsPanel.Width, AccsPanel.Height, 10, 10));
            PrivPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PrivPanel.Width, PrivPanel.Height, 10, 10));
            AccessPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AccessPanel.Width, AccessPanel.Height, 10, 10));
            AboutPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AboutPanel.Width, AboutPanel.Height, 10, 10));
            HelpPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, HelpPanel.Width, HelpPanel.Height, 10, 10));
            AdsBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AdsBox.Width, AdsBox.Height, 10, 10));

            //INFOSETTER
            PPClientName.Text = PIEname.Text = FName + " " + LName; PIEFnametext.Text = FName; PIELnametext.Text = LName;
            ClientNamePI.Text = FName + LName;
            BirthDatePI.Text = PIEBirthtext.Text = formattedBirthdate;
            int age;
            if (BirthDatePI.Text.Length == 1)
            {
                AgePI.Text = PIEAgetext.Text = " ";
            }
            else
            {
                age = DateTime.Now.Year - Birthdate.Year; AgePI.Text = PIEAgetext.Text = age.ToString();
            }
            ContactNumberPI.Text = PIECnumbertext.Text = ContactNumber;
            EmailAddressPI.Text = PIEEmailtext.Text = EmailAddress;
            PIEAddresstext.Text = LocationAddress;
            SexPI.Text = PIESextext.Text = Sex;
        }
        //
        ///CONTROLS
        //
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
        //
        ///DASHBOARD
        //
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
                NotificationPanel.BringToFront();
                LoadFacilityNotifications(clientId);
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

        public void InfoGetter()
        {
            EmailAddress = ClientLogin.EmailAddress;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT [Client_ID], [First Name], [Last Name], [Birth Date], Sex, [Contact Number], Location, Password FROM Clients WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@Email", EmailAddress);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clientId = Convert.ToInt32(reader["Client_ID"]);
                            FName = reader["First Name"].ToString();
                            LName = reader["Last Name"].ToString();
                            Birthdate = reader.IsDBNull(reader.GetOrdinal("Birth Date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Birth Date"));
                            formattedBirthdate = Birthdate == DateTime.MinValue ? " " : Birthdate.ToString("dd MMMM yyyy");
                            Sex = reader["Sex"].ToString();
                            Password = reader["Password"].ToString();
                            ContactNumber = reader["Contact Number"].ToString();
                            LocationAddress = reader.IsDBNull(reader.GetOrdinal("Location")) ? " " : reader["Location"].ToString();

                        }
                    }
                }
            }

        }

        public void UpdateInfo()
        {
            EmailAddress = ClientLogin.EmailAddress;

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "UPDATE Clients SET [First Name] = @fname, [Last Name] = @lname, [Birth Date] = @datebirth, Sex = @sex, [Contact Number] = @cnumber, Location = @address WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@fname", PIEFnametext.Text);
                    cmd.Parameters.AddWithValue("@lname", PIELnametext.Text);

                    DateTime birthdate;
                    if (DateTime.TryParse(PIEBirthtext.Text, out birthdate))
                    {
                        cmd.Parameters.AddWithValue("@datebirth", birthdate);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid birthdate format.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@sex", PIESextext.Text);
                    cmd.Parameters.AddWithValue("@cnumber", PIECnumbertext.Text);
                    cmd.Parameters.AddWithValue("@address", PIEAddresstext.Text);
                    cmd.Parameters.AddWithValue("@Email", PIEEmailtext.Text);

                    cmd.ExecuteNonQuery();


                }

                using (OleDbCommand getIdCmd = new OleDbCommand("SELECT @@IDENTITY", myConn))
                {
                    object result = getIdCmd.ExecuteScalar();
                    int newClientId = Convert.ToInt32(result);
                }

                string AdminQuery = "UPDATE [Admin (Clients)] SET [First Name] = @fname, [Last Name] = @lname, [Birth Date] = @datebirth, Sex = @sex, [Contact Number] = @cnumber, Location = @address WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(AdminQuery, myConn))
                {
                    cmd.Parameters.AddWithValue("@fname", PIEFnametext.Text);
                    cmd.Parameters.AddWithValue("@lname", PIELnametext.Text);

                    DateTime birthdate;
                    if (DateTime.TryParse(PIEBirthtext.Text, out birthdate))
                    {
                        cmd.Parameters.AddWithValue("@datebirth", birthdate);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid birthdate format.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@sex", PIESextext.Text);
                    cmd.Parameters.AddWithValue("@cnumber", PIECnumbertext.Text);
                    cmd.Parameters.AddWithValue("@address", PIEAddresstext.Text);
                    cmd.Parameters.AddWithValue("@Email", PIEEmailtext.Text);

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

                    if (count > 1)
                    {
                        CnumberExisted.Visible = true;
                        PIECnumbertext.BackColor = Color.MistyRose;
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

                    if (count > 0)
                    {
                        CnumberExisted.Visible = true;
                        PIECnumbertext.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        valid++;
                    }
                }
            }
            if (PIECnumbertext.Text.Length != 11 || !PIECnumbertext.Text.StartsWith("09") || !PIECnumbertext.Text.All(char.IsDigit))
            {
                CnumberExisted.Visible = false; CnumberInvalid.Visible = true;
                PIECnumbertext.BackColor = Color.MistyRose;
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
        private void ServicesButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Services";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            SearchPanel.Visible = true;
            AdsBox.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White; EditPIPanel.Visible = false; PIEButton.Visible = false;
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
            InfoGetter();
            Loaders();
            //DASHBOARD
            AppointmentPanel.Visible = true;
            RecomdPanel.Visible = true;
            HiLabel.Visible = true; HiLabel.Text = $"Hi {ClientLogin.EmailAddress},";
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Welcome ServEase!";
            DashboardButton.BackColor = ColorTranslator.FromHtml("#69e331");
            Dbutton.BackColor = ColorTranslator.FromHtml("#69e331");
            SearchPanel.Visible = false;
            AdsBox.Visible = true;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White; EditPIPanel.Visible = false; PIEButton.Visible = false;
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
        private void SerStoreButton1_Click(object sender, EventArgs e)
        {
            //PROFILE
            FacilityProPanel.Visible = true;
            FPButton.Visible = true;
            FacilityProPanel2.Visible = false;
            SerButton.Visible = false;
            SerPanel.Visible = false;
            BookAppbutton.Visible = false;
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
        private void FPBookAppButton_Click(object sender, EventArgs e)
        {
            FacilityProPanel.Visible = false;
            FacilityProPanel2.Visible = true;
            FPButton.Visible = false;
            BookAppbutton.Visible = true;
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
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Services";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            AdsBox.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White; EditPIPanel.Visible = false; PIEButton.Visible = false;
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
            sercat = null;
        }
        private void CalendarButton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            SearchPanel.Visible = false;
            AdsBox.Visible = false;
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
            CalendarAppointmentPanel.Visible = true; PopulateCalendarPanel(Appid, facid, clientId); LoadHistory(Appid, facid, clientId);
            CalendarPanel.Visible = true;
            CalendarButton.BackColor = ColorTranslator.FromHtml("#69e331");
            CButton.BackColor = ColorTranslator.FromHtml("#69e331");
            calendarsButton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style | FontStyle.Bold);
            calendarsButton.FlatStyle = FlatStyle.System;
            //Appointment
            AppointmentsPanel.Visible = false;
            appointmentsbutton.FlatStyle = FlatStyle.Flat;
            appointmentsbutton.Font = new Font(calendarsButton.Font, calendarsButton.Font.Style & ~FontStyle.Bold);
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White; EditPIPanel.Visible = false; PIEButton.Visible = false;
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
            FilterBox.Visible = false; FilterDateBox.Visible = false; FilterStatusBox.Visible = false; AppSearch.Visible = false;
        }

        private void appointmentsbutton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            AdsBox.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White; EditPIPanel.Visible = false; PIEButton.Visible = false;
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
            FilterBox.Visible = true; FilterDateBox.Visible = false; FilterStatusBox.Visible = false; AppSearch.Visible = false;
            LoadHistory(Appid, facid, clientId);
        }
        private void AppDetsbutton_Click(object sender, EventArgs e)
        {
            //DASHBOARD
            AppointmentPanel.Visible = false;
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Calendar";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            AdsBox.Visible = false;
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
            AppDetsbutton.Visible = false;
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
            FilterBox.Visible = true; FilterDateBox.Visible = false; FilterStatusBox.Visible = false; AppSearch.Visible = false;
        }
        private void ProfileButton_Click(object sender, EventArgs e)
        {
            InfoGetter();
            Loaders();
            //DASHBOARD
            AppointmentPanel.Visible = false;
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Profile";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            AdsBox.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = true;
            ProfileButton.BackColor = ColorTranslator.FromHtml("#69e331");
            PButton.BackColor = ColorTranslator.FromHtml("#69e331");
            EditPIPanel.Visible = false; PIEButton.Visible = false;
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
            RecomdPanel.Visible = false;
            HiLabel.Visible = false;
            WelcomeLabel.Visible = true;
            WelcomeLabel.Text = "Settings";
            DashboardButton.BackColor = Color.White;
            Dbutton.BackColor = Color.White;
            AdsBox.Visible = false;
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
            AppDetsbutton.Visible = false;
            ViewdetailsPanel.Visible = false;
            //PROFILE
            ProfilePanel.Visible = false;
            ProfileButton.BackColor = Color.White;
            PButton.BackColor = Color.White;
            EditPIPanel.Visible = false; PIEButton.Visible = false;
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
        private void PIEditButton_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = false;
            PIEButton.Visible = true; ProfilePanel.Visible = false; EditPIPanel.Visible = true;
        }

        private void PIEButton_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible = true;
            PIEButton.Visible = false; ProfilePanel.Visible = true; EditPIPanel.Visible = false;
            InfoGetter();
            Loaders();
        }

        private void PIECnumbertext_Click(object sender, EventArgs e)
        {
            CnumberExisted.Visible = false; CnumberInvalid.Visible = false;
            PIECnumbertext.BackColor = Color.WhiteSmoke;
        }

        private void CUIButton_Click(object sender, EventArgs e)
        {
            FillEM.Visible = false;
            bool cnumberValid = CNumberChecker(PIECnumbertext.Text, connection);

            if (PIEFnametext.Text.Length != 0 && PIELnametext.Text.Length != 0 && PIEBirthtext.Text.Length != 0 && PIEAddresstext.Text.Length != 0 && cnumberValid && PIESextext.Text.Length != 0)
            {
                UpdateInfo();
            }
            else if (PIEFnametext.Text.Length == 0 && PIELnametext.Text.Length == 0 && PIEBirthtext.Text.Length == 0 && PIEAddresstext.Text.Length == 0)
            {
                FillEM.Visible = true;
            }
        }
        private void DeleteAccButton_Click(object sender, EventArgs e)
        {
            DialogResult results = System.Windows.Forms.MessageBox.Show("Are you sure you want to permanently delete this account? This action cannot be undone.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int newClientId = 0;
            if (results == DialogResult.Yes)
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();


                    string getIdQuery = "SELECT Client_ID FROM Clients WHERE [Email Address] = ?";
                    using (OleDbCommand getIdCmd = new OleDbCommand(getIdQuery, myConn))
                    {
                        getIdCmd.Parameters.AddWithValue("?", EmailAddress);
                        object result = getIdCmd.ExecuteScalar();

                        if (result != null)
                        {
                            newClientId = Convert.ToInt32(result);
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Client not found.");
                            return;
                        }
                    }

                    string deleteQuery = "DELETE FROM Clients WHERE [Email Address] = ?";
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

                    string adminUpdateQuery = "UPDATE [Admin (Clients)] SET Status = ?, [Date Deleted] = ? WHERE Client_ID = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(adminUpdateQuery, myConn))
                    {
                        updateCmd.Parameters.AddWithValue("?", "Deleted");
                        updateCmd.Parameters.AddWithValue("?", DateTime.Today);
                        updateCmd.Parameters.AddWithValue("?", newClientId);

                        updateCmd.ExecuteNonQuery();
                    }
                }

                this.Hide();
                ClientLogin clientLogin = new ClientLogin();
                clientLogin.ShowDialog();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You clicked No!");
            }
        }
        private void BeautySbutton_Click(object sender, EventArgs e)
        {
            sercat = "Personal Care & Beauty Services";
            WelcomeLabel.Visible = false;
            SerButton.Visible = true; SerButton.Text = "  Personal Care and Beauty Services";
            SerPanel.Visible = true;
            ServicesPanel.Visible = false;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
            LoadFacilities();
        }
        private void HealthSbutton_Click(object sender, EventArgs e)
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
            sercat = "Health & Medical Services";
            SerButton.Text = "  Health and Medical Services";
            LoadFacilities();
        }

        private void FitnessSbutton_Click(object sender, EventArgs e)
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
            sercat = "Fitness & Sports Services";
            SerButton.Text = "  Fitness and Sports Services";
            LoadFacilities();
        }

        private void EduSbutton_Click(object sender, EventArgs e)
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
            sercat = "Education & Tutoring Services";
            SerButton.Text = "  Education and Tutoring Services";
            LoadFacilities();
        }

        private void RepairSbutton_Click(object sender, EventArgs e)
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
            sercat = "Repair & Technical Services";
            SerButton.Text = "  Repair and Technical Services";
            LoadFacilities();
        }

        private void FoodSbutton_Click(object sender, EventArgs e)
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
            sercat = "Food & Beverages Services";
            SerButton.Text = "  Food and Beverages Services";
            LoadFacilities();
        }

        private void MisSbutton_Click(object sender, EventArgs e)
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
            sercat = "Miscellaneous Services";
            SerButton.Text = "  Miscellaneous Services";
            LoadFacilities();
        }
        public void LoadFacilities(string searchText = "")
        {
            int margin = 10;
            int padding = 5;
            int panelWidth = 250;
            int panelHeight = 190;
            int columns = 3;

            int currentRow = 0;
            int currentCol = 0;

            SerPanel.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT Facility_ID, [Facility Name], [Working Hours Start], [Working Hours End], [Ratings], [Email Address], [Tags], [Service Category] " +
                             "FROM [Service Facilities] " +
                             "WHERE [Approval Status] = ?";

                bool isSearching = !string.IsNullOrWhiteSpace(searchText);

                if (isSearching)
                {
                    sql += " AND ([Facility Name] LIKE ? OR [Tags] LIKE ?)";
                }
                else
                {
                    sql += " AND [Service Category] = ?";
                }

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", "Approved");

                    if (isSearching)
                    {
                        cmd.Parameters.AddWithValue("?", "%" + searchText + "%");
                        cmd.Parameters.AddWithValue("?", "%" + searchText + "%");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("?", sercat);
                    }

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> searchTags = new List<string>();
                        if (isSearching)
                        {
                            searchTags = searchText
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(tag => tag.Trim().ToLower())
                                .ToList();
                        }

                        while (reader.Read())
                        {
                            int facilityId = reader.GetInt32(reader.GetOrdinal("Facility_ID"));
                            string fName = reader["Facility Name"].ToString();
                            DateTime workingstart = reader.IsDBNull(reader.GetOrdinal("Working Hours Start")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours Start"));
                            DateTime workingend = reader.IsDBNull(reader.GetOrdinal("Working Hours End")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours End"));
                            string formattedWorHours = (workingstart == DateTime.MinValue || workingend == DateTime.MinValue) ? " " : $"{workingstart:hh\\:mm tt} - {workingend:hh\\:mm tt}";
                            string ratings = reader["Ratings"].ToString();
                            string tagsFromDb = reader["Tags"]?.ToString() ?? "";
                            string facilityCategory = reader["Service Category"].ToString();

                            List<string> facilityTags = tagsFromDb
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(tag => tag.Trim().ToLower())
                                .ToList();

                            bool matchesSearch = true;
                            if (isSearching)
                            {
                                bool nameMatches = fName.ToLower().Contains(searchText.ToLower());
                                bool tagsMatch = searchTags.Intersect(facilityTags).Any();
                                matchesSearch = nameMatches || tagsMatch;
                            }

                            if (!matchesSearch)
                            {
                                continue;
                            }
                            decimal minPrice = 0, maxPrice = 0;
                            using (OleDbCommand priceCmd = new OleDbCommand("SELECT MIN(Price), MAX(Price) FROM [Facility Services] WHERE Facility_ID = ?", myConn))
                            {
                                priceCmd.Parameters.AddWithValue("?", facilityId);
                                using (OleDbDataReader priceReader = priceCmd.ExecuteReader())
                                {
                                    if (priceReader.Read())
                                    {
                                        minPrice = priceReader.IsDBNull(0) ? 0 : priceReader.GetDecimal(0);
                                        maxPrice = priceReader.IsDBNull(1) ? 0 : priceReader.GetDecimal(1);
                                    }
                                }
                            }

                            string priceRange = $"₱{minPrice} - ₱{maxPrice}";

                            FacilityPanel facilityPanel = new FacilityPanel();
                            facilityPanel.SetData(fName, ratings, formattedWorHours, priceRange);
                            facilityPanel.Width = panelWidth;
                            facilityPanel.Height = panelHeight;
                            facilityPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelWidth, panelHeight, 10, 10));

                            int x = margin + currentCol * (panelWidth + padding);
                            int y = margin + currentRow * (panelHeight + padding);
                            facilityPanel.Location = new Point(x, y);

                            facilityPanel.ViewProfileClicked += (s, e) =>
                            {
                                ViewFacDets(facilityId);
                            };

                            SerPanel.Controls.Add(facilityPanel);

                            currentCol++;
                            if (currentCol >= columns)
                            {
                                currentCol = 0;
                                currentRow++;
                            }
                        }
                    }
                }
            }
        }

        public void LoadTopFacilities()
        {
            int margin = 10;
            int padding = 5;
            int panelWidth = 250;
            int panelHeight = 190;
            int columns = 3;

            int currentRow = 0;
            int currentCol = 0;

            RecodPanel.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT Facility_ID, [Facility Name], [Working Hours Start], [Working Hours End], [Ratings], [Email Address], [Tags], [Service Category] " +
                             "FROM [Service Facilities] " +
                             "WHERE [Approval Status] = ?" +
                             "ORDER BY Ratings DESC";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", "Approved");


                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int facilityId = reader.GetInt32(reader.GetOrdinal("Facility_ID"));
                            string fName = reader["Facility Name"].ToString();
                            DateTime workingstart = reader.IsDBNull(reader.GetOrdinal("Working Hours Start")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours Start"));
                            DateTime workingend = reader.IsDBNull(reader.GetOrdinal("Working Hours End")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours End"));
                            string formattedWorHours = (workingstart == DateTime.MinValue || workingend == DateTime.MinValue) ? " " : $"{workingstart:hh\\:mm tt} - {workingend:hh\\:mm tt}";
                            string ratings = reader["Ratings"].ToString();
                            string tagsFromDb = reader["Tags"]?.ToString() ?? "";
                            string facilityCategory = reader["Service Category"].ToString();

                            decimal minPrice = 0, maxPrice = 0;
                            using (OleDbCommand priceCmd = new OleDbCommand("SELECT MIN(Price), MAX(Price) FROM [Facility Services] WHERE Facility_ID = ?", myConn))
                            {
                                priceCmd.Parameters.AddWithValue("?", facilityId);
                                using (OleDbDataReader priceReader = priceCmd.ExecuteReader())
                                {
                                    if (priceReader.Read())
                                    {
                                        minPrice = priceReader.IsDBNull(0) ? 0 : priceReader.GetDecimal(0);
                                        maxPrice = priceReader.IsDBNull(1) ? 0 : priceReader.GetDecimal(1);
                                    }
                                }
                            }

                            string priceRange = $"₱{minPrice} - ₱{maxPrice}";

                            FacilityPanel facilityPanel = new FacilityPanel();
                            facilityPanel.SetData(fName, ratings, formattedWorHours, priceRange);
                            facilityPanel.Width = panelWidth;
                            facilityPanel.Height = panelHeight;
                            facilityPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelWidth, panelHeight, 10, 10));

                            int x = margin + currentCol * (panelWidth + padding);
                            int y = margin + currentRow * (panelHeight + padding);
                            facilityPanel.Location = new Point(x, y);

                            facilityPanel.ViewProfileClicked += (s, e) =>
                            {
                                ViewFacDets(facilityId);
                            };

                            RecodPanel.Controls.Add(facilityPanel);

                            currentCol++;
                            if (currentCol >= columns)
                            {
                                currentCol = 0;
                                currentRow++;
                            }
                        }
                    }
                }
            }
        }
        public void ViewFacDets(int ID)
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


            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT [Facility Location], [Facility Name], [Working Hours Start], [Working Hours End], [Ratings], [Email Address], [Working Days], [Contact Number], [Exception Day (Closed)] FROM [Service Facilities] WHERE [Facility_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Facname = reader["Facility Name"].ToString();
                            locs = reader["Facility Location"].ToString();
                            Ems = reader["Email Address"].ToString();
                            string contnumb = reader["Contact Number"].ToString();
                            DateTime workingstart = reader.IsDBNull(reader.GetOrdinal("Working Hours Start")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours Start"));
                            DateTime workingend = reader.IsDBNull(reader.GetOrdinal("Working Hours End")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours End"));
                            string formattedWorHours = (workingstart == DateTime.MinValue || workingend == DateTime.MinValue) ? " " : $"{workingstart:hh\\:mm tt} - {workingend:hh\\:mm tt}";
                            WorDays = reader.IsDBNull(reader.GetOrdinal("Working Days")) ? "" : reader.GetString(reader.GetOrdinal("Working Days"));
                            Ratings = reader["Ratings"].ToString();
                            ExceptionDay = reader["Exception Day (Closed)"].ToString();

                            FaciName.Text = Facname; WorkingHoursText.Text = formattedWorHours; WorDaystext.Text = WorDays; Loctext.Text = locs; Conumtext.Text = contnumb; EMStext.Text = Ems;
                            Ratinglabel.Text = Ratings + " Ratings";
                        }
                    }
                }
            }
            facid = ID;
            LoadFacilityData(ID);
        }
        private void LoadFacilityData(int ID)
        {
            ClientSopanel.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT [Service Name], Description, Price, Duration FROM [Facility Services] WHERE Facility_ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 3;

                        while (reader.Read())
                        {
                            string serviceName = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            string description = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            decimal price = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            string duration = reader.IsDBNull(3) ? "" : reader.GetValue(3).ToString();

                            ClientSO clientSO = new ClientSO();
                            clientSO.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, clientSO.Width, clientSO.Height, 10, 10));

                            clientSO.SetData(serviceName, description, price, duration);
                            clientSO.Location = new Point(0, margin);
                            margin += clientSO.Height + 3;

                            ClientSopanel.Controls.Add(clientSO);
                        }
                    }
                }
            }

            BaASer2.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT Service_ID, [Service Name], Price, Duration FROM [Facility Services] WHERE Facility_ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int marginbottom = 5;

                        while (reader.Read())
                        {
                            int serviceId = Convert.ToInt32(reader["Service_ID"]);
                            string serviceName = reader.IsDBNull("Service Name") ? "" : reader.GetString("Service Name");
                            decimal price = reader.IsDBNull("Price") ? 0 : reader.GetDecimal("Price");
                            string duration = reader.IsDBNull("Duration") ? "" : reader.GetString("Duration");

                            ClientAppointment clientAppointment = new ClientAppointment();

                            clientAppointment.SetData(serviceId, serviceName, price, duration);
                            clientAppointment.Location = new Point(0, marginbottom);
                            marginbottom += clientAppointment.Height + 5;

                            clientAppointment.ServiceClicked += (s, e) => UpdateBookingSummary();

                            BaASer2.Controls.Add(clientAppointment);
                        }
                    }
                }
            }
            PopulateCalendar(); BaADTlabel1.Visible = false; BookingSumlabel.Visible = false; BookingSumpanel.Visible = false;
            BSservices.Text = null; BSdatetime.Text = null; BStotalprice.Text = null; BSduration.Text = null; BSdatetime1.Text = null;
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
        private DateTime? selectedAppointmentDate = null;

        void PopulateCalendar()
        {
            ATC3.Controls.Clear();
            ATC3.SuspendLayout();

            List<DayOfWeek> workingDays = ParseWorkingDays(WorDays);
            List<DateTime> exceptionDates = ParseWorkDays(ExceptionDay);

            DateTime firstDay = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            int startCol = (int)firstDay.DayOfWeek;

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
                    if (exceptionDates.Any(d => d.Date == thisDate.Date))
                    {
                        dayLabel.ForeColor = Color.DimGray;
                        dayLabel.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        if (thisDate.Date > DateTime.Today.Date)
                        {
                            dayLabel.Cursor = Cursors.Hand;
                            dayLabel.Click += DayLabel_Click;
                        }
                    }
                    if (selectedAppointmentDate.HasValue && thisDate.Date == selectedAppointmentDate.Value)
                    {
                        dayLabel.BackColor = ColorTranslator.FromHtml("#69e331");
                        dayLabel.ForeColor = Color.White;
                        LoadTimeSlotsFromDatabase(facid, selectedAppointmentDate.Value);
                    }
                    if (thisDate.Date < DateTime.Today.Date)
                    {
                        dayLabel.ForeColor = Color.DimGray;
                    }
                }
                if (thisDate.Date == DateTime.Today.Date)
                {
                    dayLabel.BackColor = ColorTranslator.FromHtml("#d9faf5");
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

        private void DayLabel_Click(object sender, EventArgs e)
        {
            BookingSumlabel.Visible = true; BookingSumpanel.Visible = true;
            Label clickedLabel = sender as Label;

            if (clickedLabel?.Tag is DateTime selectedDate)
            {
                selectedAppointmentDate = selectedDate.Date;

                PopulateCalendar();

                BSdatetime.Text = "Date and Time:  " + selectedAppointmentDate?.ToString("dddd, dd MMMM yyyy") + ",";
            }

        }

        private void ATCPrev_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            PopulateCalendar();
            PopulateCalendarPanel(Appid, facid, clientId);
        }

        private void ATCNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(+1);
            PopulateCalendar();
            PopulateCalendarPanel(Appid, facid, clientId);
        }

        void LoadTimeSlotsFromDatabase(int facilityId, DateTime selectedDate)
        {
            BaADTlabel1.Visible = true;
            TimeslotPanel.Controls.Clear();
            TimeslotPanel.SuspendLayout();

            int rows = 2, cols = 3;
            TimeslotPanel.RowCount = rows;
            TimeslotPanel.ColumnCount = cols;

            List<(string start, string end, bool isAvailable)> slots = new List<(string, string, bool)>();

            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                conn.Open();
                string sql = @"SELECT [Start Time], [End Time], [Status]
                       FROM [Facility Timeslots]
                       WHERE Facility_ID = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", facilityId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string start = reader.IsDBNull(0) ? "" : reader.GetDateTime(0).ToString("hh:mm tt");
                            string end = reader.IsDBNull(1) ? "" : reader.GetDateTime(1).ToString("hh:mm tt");
                            string status = reader.IsDBNull(2) ? "" : reader.GetString(2);

                            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                            {
                                bool available = status.Equals("Available", StringComparison.OrdinalIgnoreCase);
                                slots.Add((start, end, available));
                            }

                            if (slots.Count >= 6) break;
                        }
                    }
                }
            }

            while (slots.Count < 6)
            {
                slots.Add(("", "", false));
            }

            for (int i = 0; i < 6; i++)
            {
                string slotText = string.IsNullOrEmpty(slots[i].start) ? "Unavailable" : $"{slots[i].start} - {slots[i].end}";

                Label slotLabel = new Label
                {
                    Text = slotText,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Segoe UI", 8),
                    Margin = new(0, 0, 0, 5),
                    Cursor = slots[i].isAvailable ? Cursors.Hand : Cursors.Default,
                    BackColor = slots[i].isAvailable ? Color.White : Color.LightGray,
                    ForeColor = slots[i].isAvailable ? Color.Black : Color.DarkGray,
                    Tag = slots[i]
                };

                if (slots[i].isAvailable)
                    slotLabel.Click += TimeSlotLabel_Click;

                int row = i / cols;
                int col = i % cols;
                TimeslotPanel.Controls.Add(slotLabel, col, row);
            }

            TimeslotPanel.ResumeLayout();
        }

        Label selectedTimeSlotLabel = null;

        private void TimeSlotLabel_Click(object sender, EventArgs e)
        {
            if (selectedTimeSlotLabel != null)
            {
                selectedTimeSlotLabel.BackColor = Color.White;
                selectedTimeSlotLabel.ForeColor = Color.Black;
            }

            selectedTimeSlotLabel = sender as Label;
            if (selectedTimeSlotLabel != null)
            {
                selectedTimeSlotLabel.BackColor = Color.FromArgb(105, 227, 49);
                selectedTimeSlotLabel.ForeColor = Color.White;

                selectedTime = selectedTimeSlotLabel.Text;
            }
            BSdatetime1.Text = selectedTime;
        }
        private List<ClientAppointment> SelectedServices => BaASer2.Controls.OfType<ClientAppointment>().Where(c => c.IsSelected).ToList();
        public List<int> SelectedServiceIds { get; private set; } = new List<int>();

        int EPrice, EDuration;
        private void UpdateBookingSummary()
        {
            BookingSumlabel.Visible = true; BookingSumpanel.Visible = true;
            var selected = SelectedServices;

            if (selected.Any() && selectedAppointmentDate != null && selectedTimeSlotLabel != null)
            {
                var totalPrice = selected.Sum(s => s.Price);
                var totalDuration = selected.Sum(s => s.DurationMinutes);
                var selectedIds = selected.Select(s => s.ServiceId).ToList();
                SelectedServiceIds = selected.Select(s => s.ServiceId).ToList();

                BSservices.Text = "Services: " + string.Join(", ", selected.Select(s => s.ServiceName));
                BStotalprice.Text = "Estimated Price: ₱" + totalPrice;
                BSduration.Text = "Estimated Duration: " + totalDuration + " mins";
                EPrice = (int)totalPrice; EDuration = totalDuration;
                SelectedServiceIds = selectedIds;
            }
            else
            {
                BSservices.Text = "Select services to see summary.";
                BSdatetime.Text = "";
                BStotalprice.Text = "";
                BSduration.Text = "";
            }
        }

        public void GenerateAndSaveQrCodeAndSendEmail(int appointmentId, int facid, int clid, string clientEmail, string clientName, DateTime appointmentDate, string appointmentTime, string providerName)
        {
            string qrContent = $"{appointmentId}|{facid}|{clid}";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap qrBitmap = qrCode.GetGraphic(5, Color.Black, Color.White, true))
            {
                byte[] qrBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    qrBitmap.Save(ms, ImageFormat.Png);
                    qrBytes = ms.ToArray();
                }

                using (OleDbConnection conn = new OleDbConnection(connection))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Appointments SET [QR Code] = ? WHERE [Appointment_ID] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", qrBytes);
                        cmd.Parameters.AddWithValue("?", appointmentId);

                        cmd.ExecuteNonQuery();
                    }
                }

                SendBookingEmail(appointmentId, clientEmail, clientName, appointmentDate, appointmentTime, providerName, qrBytes);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!SelectedServices.Any())
            {
                System.Windows.Forms.MessageBox.Show("Please select at least one service.");
                return;
            }

            if (selectedAppointmentDate == null || selectedTimeSlotLabel == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select a date and timeslot.");
                return;
            }

            bool IsOverlappingConflict(DateTime date, DateTime startTime, DateTime endTime, int clientId, int facilityId)
            {
                using (OleDbConnection conn = new OleDbConnection(connection))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM Appointments 
                     WHERE [Appointment Date] = ? 
                     AND ([Client_ID] = ? OR [Facility_ID] = ?)
                     AND (? < [End Time] AND ? > [Start Time])";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", date.Date.ToString("dd MM yyyy"));
                        cmd.Parameters.AddWithValue("?", clientId);
                        cmd.Parameters.AddWithValue("?", facilityId);
                        cmd.Parameters.AddWithValue("?", startTime.ToString("hh:mm tt"));
                        cmd.Parameters.AddWithValue("?", endTime.ToString("hh:mm tt"));

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }

            DateTime selectedDate = selectedAppointmentDate.Value.Date;
            string[] timeParts = selectedTimeSlotLabel.Text.Split('-');
            DateTime startTime = DateTime.Parse(timeParts[0].Trim());
            DateTime endTime = DateTime.Parse(timeParts[1].Trim());

            if (IsOverlappingConflict(selectedDate, startTime, endTime, clientId, facid))
            {
                System.Windows.Forms.MessageBox.Show("Time conflict detected. Please choose another time slot.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EmailAddress = ClientLogin.EmailAddress;
            int newClientId = 0;

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getclientid = "SELECT Client_ID FROM [Clients] WHERE [Email Address] = ?";
                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getclientid, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", EmailAddress);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                            newClientId = reader.GetInt32(0);
                    }
                }

                string insertAppointment = @"
    INSERT INTO Appointments 
    ([Client_ID], [Facility_ID], [Appointment Status], [Appointment Date], [Start Time], [End Time], [Date Booked], [Estimated Price], [Estimated Duration], [Reason])
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand cmd = new OleDbCommand(insertAppointment, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newClientId);
                    cmd.Parameters.AddWithValue("?", facid);
                    cmd.Parameters.AddWithValue("?", "Pending");

                    string dateTimeString = $"{selectedAppointmentDate:dd MM yyyy}";
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    cmd.Parameters.AddWithValue("?", dateTimeString);

                    DateTime start = DateTime.Parse($"{startTime: hh:mm tt}");
                    DateTime end = DateTime.Parse($"{endTime: hh:mm tt}");
                    string bookeddate = DateTime.Now.ToString("dd MM yyyy");

                    cmd.Parameters.AddWithValue("?", start.ToString("hh:mm tt"));
                    cmd.Parameters.AddWithValue("?", end.ToString("hh:mm tt"));
                    cmd.Parameters.AddWithValue("?", bookeddate);
                    cmd.Parameters.AddWithValue("?", EPrice);

                    string durationString = $"{EDuration} mins";
                    cmd.Parameters.AddWithValue("?", durationString);
                    cmd.Parameters.AddWithValue("?", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                int AppointmentId = 0;
                string getAppointmentIdQuery = "SELECT MAX(Appointment_ID) FROM [Appointments] WHERE [Facility_ID] = ?";
                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getAppointmentIdQuery, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", facid);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                            AppointmentId = reader.GetInt32(0);
                    }
                }

                foreach (var service in SelectedServices)
                {
                    string insertServiceQuery = "INSERT INTO [Appointment Services] ([Appointment_ID], [Service_ID]) VALUES (?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertServiceQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", AppointmentId);
                        cmd.Parameters.AddWithValue("?", service.ServiceId);
                        cmd.ExecuteNonQuery();
                    }
                }

                string clientEmail = EmailAddress;
                string clientName = FName + " " + LName;
                string providerName = Facname;
                GenerateAndSaveQrCodeAndSendEmail(AppointmentId, facid, newClientId, clientEmail, clientName, selectedDate, startTime.ToString("hh:mm tt"), providerName);
                string senders = "Client", titles = "Appointment Booked", messages = "A new appointment was booked!";
                DateTime now = DateTime.Now;
                SaveNotification(clientId, facid, senders, titles, messages, now, AppointmentId);
            }

            System.Windows.Forms.MessageBox.Show("Appointment booked successfully!");
        }

        private void SendBookingEmail(int appointmentId, string clientEmail, string clientName, DateTime appointmentDate, string appointmentTime, string providerName, byte[] qrCodeImage)
        {
            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Booked Pending.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate.ToString("MMMM dd, yyyy"))
                                     .Replace("{AppointmentTime}", appointmentTime);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("vaughanash02@gmail.com");
                message.Subject = "Appointment Booking Confirmation";
                message.Body = emailBody;
                message.IsBodyHtml = true;

                var qrAttachment = new Attachment(new MemoryStream(qrCodeImage), "qr_code.png");
                qrAttachment.ContentDisposition.Inline = true;
                qrAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                qrAttachment.ContentId = "qr_code";
                message.Attachments.Add(qrAttachment);

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

            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Appointment Request.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate.ToString("MMMM dd, yyyy"))
                                     .Replace("{AppointmentTime}", appointmentTime);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("snmcorporation.dlic@gmail.com");
                message.Subject = "Appointment Booking Request";
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


        public void LoadHistory(int ID, int Faid, int Clid,
                        string statusFilter = "",
                        DateTime? dateBookedFilter = null,
                        DateTime? appointmentDateFilter = null,
                        int? facilityIdFilter = null)
        {
            AppointmentsPanel.Controls.Clear();
            EmailAddress = ClientLogin.EmailAddress;
            int newClientId = 0;

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getclientid = "SELECT Client_ID FROM [Clients] WHERE [Email Address] = ?";
                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getclientid, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", EmailAddress);
                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            newClientId = reader.GetInt32(0);
                        }
                    }
                }

                string sql = "SELECT Facility_ID, Appointment_ID FROM Appointments WHERE Client_ID = ?";
                if (!string.IsNullOrEmpty(statusFilter))
                    sql += " AND [Appointment Status] = ?";
                if (dateBookedFilter.HasValue)
                    sql += " AND [Date Booked] = ?";
                if (appointmentDateFilter.HasValue)
                    sql += " AND [Appointment Date] = ?";
                if (facilityIdFilter.HasValue)
                    sql += " AND [Facility_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newClientId);
                    if (!string.IsNullOrEmpty(statusFilter))
                        cmd.Parameters.AddWithValue("?", statusFilter);
                    if (dateBookedFilter.HasValue)
                        cmd.Parameters.AddWithValue("?", dateBookedFilter.Value.Date);
                    if (appointmentDateFilter.HasValue)
                        cmd.Parameters.AddWithValue("?", appointmentDateFilter.Value.Date);
                    if (facilityIdFilter.HasValue)
                        cmd.Parameters.AddWithValue("?", facilityIdFilter.Value);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;
                        while (reader.Read())
                        {
                            int newFacilityId = reader.GetInt32(reader.GetOrdinal("Facility_ID"));
                            int appointmentId = reader.GetInt32(reader.GetOrdinal("Appointment_ID"));

                            string FacName = "", FLocation = "";
                            string getFacility = "SELECT [Facility Name], [Facility Location] FROM [Service Facilities] WHERE [Facility_ID] = ?";
                            using (OleDbCommand facility = new OleDbCommand(getFacility, myConn))
                            {
                                facility.Parameters.AddWithValue("?", newFacilityId);
                                using (OleDbDataReader readers = facility.ExecuteReader())
                                {
                                    if (readers.Read())
                                    {
                                        FacName = readers.IsDBNull(0) ? "" : readers.GetString(0);
                                        FLocation = readers.IsDBNull(1) ? "" : readers.GetString(1);
                                    }
                                }
                            }

                            UsersPanel usersPanel = new UsersPanel();
                            usersPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));
                            usersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                            usersPanel.Width = AppointmentsPanel.ClientSize.Width - 20;
                            usersPanel.Location = new Point(0, margin);
                            margin += usersPanel.Height + 10;

                            usersPanel.ViewDetailsClicked += (s, e) =>
                            {
                                Appid = appointmentId;
                                facid = newFacilityId;
                                clientId = newClientId;
                                ViewDets(appointmentId, newFacilityId, newClientId);
                            };

                            string adminQuery = "SELECT [Appointment Status], [Appointment Date], [Date Booked] FROM Appointments WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Appointment_ID] = ?";
                            using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                            {
                                adminCmd.Parameters.AddWithValue("?", newClientId);
                                adminCmd.Parameters.AddWithValue("?", newFacilityId);
                                adminCmd.Parameters.AddWithValue("?", appointmentId);

                                using (OleDbDataReader adminReader = adminCmd.ExecuteReader())
                                {
                                    if (adminReader.Read())
                                    {
                                        string status = adminReader.GetString(0);
                                        string dateapp = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");
                                        string datebooked = adminReader.IsDBNull(2) ? "" : adminReader.GetDateTime(2).ToString("dd MMM yyyy");

                                        usersPanel.ClientInfo(status, dateapp);
                                        usersPanel.CLientApp(FacName, datebooked);
                                    }
                                }
                            }
                            PopulateCalendarPanel(appointmentId, newFacilityId, newClientId);

                            AppointmentsPanel.Controls.Add(usersPanel);
                        }
                    }
                }
            }
        }

        public void LoadUpcomingHistory(int ID, int Faid, int Clid)
        {
            Upcomingpanel.Controls.Clear();
            EmailAddress = ClientLogin.EmailAddress;
            int newClientId = 0;

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getclientid = "SELECT Client_ID FROM [Clients] WHERE [Email Address] = ?";
                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getclientid, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", EmailAddress);
                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            newClientId = reader.GetInt32(0);
                        }
                    }
                }

                string sql = "SELECT Facility_ID, Appointment_ID FROM Appointments WHERE Client_ID = ? AND [Appointment Status] IN (?, ?)";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newClientId);
                    cmd.Parameters.AddWithValue("?", "Pending");
                    cmd.Parameters.AddWithValue("?", "Confirmed");

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;
                        while (reader.Read())
                        {
                            int newFacilityId = reader.GetInt32(reader.GetOrdinal("Facility_ID"));
                            int appointmentId = reader.GetInt32(reader.GetOrdinal("Appointment_ID"));

                            string FacName = "", FLocation = "";
                            string getFacility = "SELECT [Facility Name], [Facility Location] FROM [Service Facilities] WHERE [Facility_ID] = ?";
                            using (OleDbCommand facility = new OleDbCommand(getFacility, myConn))
                            {
                                facility.Parameters.AddWithValue("?", newFacilityId);
                                using (OleDbDataReader readers = facility.ExecuteReader())
                                {
                                    if (readers.Read())
                                    {
                                        FacName = readers.IsDBNull(0) ? "" : readers.GetString(0);
                                        FLocation = readers.IsDBNull(1) ? "" : readers.GetString(1);
                                    }
                                }
                            }
                            Rating rating = new Rating();

                            UsersPanel usersPanel = new UsersPanel();
                            rating.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));
                            rating.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                            rating.Width = Upcomingpanel.ClientSize.Width - 20;
                            rating.Location = new Point(10, margin);
                            margin += rating.Height + 10;

                            string adminQuery = "SELECT [Appointment Status], [Appointment Date], [Date Booked] FROM Appointments WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Appointment_ID] = ?";
                            using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                            {
                                adminCmd.Parameters.AddWithValue("?", newClientId);
                                adminCmd.Parameters.AddWithValue("?", newFacilityId);
                                adminCmd.Parameters.AddWithValue("?", appointmentId);

                                using (OleDbDataReader adminReader = adminCmd.ExecuteReader())
                                {
                                    if (adminReader.Read())
                                    {
                                        string status = adminReader.GetString(0);
                                        string dateapp = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");
                                        string datebooked = adminReader.IsDBNull(2) ? "" : adminReader.GetDateTime(2).ToString("dd MMM yyyy");

                                        rating.ClientInfo(status, dateapp);
                                        rating.CLientApp(FacName, datebooked);
                                    }
                                }
                            }

                            Upcomingpanel.Controls.Add(rating);
                        }
                    }
                }
            }
        }

        public void ViewDets(int ID, int Faid, int Clid)
        {
            WelcomeLabel.Visible = false;
            AppDetsbutton.Visible = true;
            AppointmentsPanel.Visible = false;
            CalendarAppointmentPanel.Visible = false;
            ViewdetailsPanel.Visible = true;
            AppSearch.Visible = false; FilterBox.Visible = false; FilterDateBox.Visible = false; FilterStatusBox.Visible = false;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
            Appid = ID;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT [Facility Location], [Facility Name], [Working Hours Start], [Working Hours End], [Ratings], [Email Address], [Working Days], [Contact Number], [Exception Day (Closed)] FROM [Service Facilities] WHERE [Facility_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Faid);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Facname = reader["Facility Name"].ToString();
                            locs = reader["Facility Location"].ToString();
                            Ems = reader["Email Address"].ToString();
                            string contnumb = reader["Contact Number"].ToString();
                            DateTime workingstart = reader.IsDBNull(reader.GetOrdinal("Working Hours Start")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours Start"));
                            DateTime workingend = reader.IsDBNull(reader.GetOrdinal("Working Hours End")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours End"));
                            string formattedWorHours = (workingstart == DateTime.MinValue || workingend == DateTime.MinValue) ? " " : $"{workingstart:hh\\:mm tt} - {workingend:hh\\:mm tt}";
                            WorDays = reader.IsDBNull(reader.GetOrdinal("Working Days")) ? "" : reader.GetString(reader.GetOrdinal("Working Days"));
                            Ratings = reader["Ratings"].ToString();
                            ExceptionDay = reader["Exception Day (Closed)"].ToString();

                            ASFaciName.Text = Facname; ASWorkingHoursText.Text = formattedWorHours; ASWorDaystext.Text = WorDays; ASLoctext.Text = locs; ASConumtext.Text = contnumb; ASEMStext.Text = Ems;

                        }
                    }
                }

                string selectAppointment = "SELECT [Appointment Status], [Appointment Date], [Date Booked],[Start Time], [End Time], [Estimated Price], [Estimated Duration], Reason " +
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
                            string reason = adminReader["Reason"].ToString();

                            ASdatetext.Text = dateapp + " ,    " + formattedStart + " - " + formattedEnd;
                            ASpricetext.Text = "PHP " + price + ".00";
                            ASdtext.Text = duration;
                            ASstattext.Text = status; ASbookedtext.Text = datebooked;

                            if (status == "Confirmed")
                            {
                                ASstattext.ForeColor = Color.DodgerBlue;
                            }
                            else if (status == "Pending")
                            {
                                ASstattext.ForeColor = Color.Gold;
                            }
                            else if (status == "Completed")
                            {
                                ASstattext.ForeColor = ColorTranslator.FromHtml("#69e331");
                                RateButton.Visible = true;
                            }
                            else
                            {
                                ASstattext.ForeColor = Color.Red;
                                ASReasonlabel.Visible = true; ASReasontext.Visible = true;
                                ASReasontext.Text = reason;
                                ReschedButton.Visible = false;
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

        /*void PopulateCalendarPanel(int ID, int Faid, int Clid)
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
                string query = "SELECT [Appointment Date] FROM Appointments WHERE [Client_ID] = ? AND [Appointment Status] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("?", clientId);
                    cmd.Parameters.AddWithValue("?", "Pending" || "Confirmed");

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
                    cellPanel.BackColor = ColorTranslator.FromHtml("#d9faf5");
                }

                if (appointmentCounts.ContainsKey(thisDate.Date))
                {
                    int count = appointmentCounts[thisDate.Date];

                    Label appLabel = new Label { Text = $" ● {count} Appointment/s", AutoEllipsis = true, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, ForeColor = ColorTranslator.FromHtml("#69e331"), Font = new Font("Segoe UI", 8), Tag = thisDate };

                    cellPanel.Controls.Add(appLabel);
                    cellPanel.Cursor = Cursors.Hand;
                    appLabel.Tag = thisDate;
                    appLabel.Click += CellPanel_Click;
                    cellPanel.BackColor = ColorTranslator.FromHtml("#E1F9D7");
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
        }*/
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

                string query = "SELECT [Appointment Date], COUNT(*) FROM Appointments WHERE [Client_ID] = ? AND [Appointment Status] IN (?, ?) GROUP BY [Appointment Date]";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Clid);
                    cmd.Parameters.AddWithValue("?", "Pending");
                    cmd.Parameters.AddWithValue("?", "Confirmed");

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                DateTime date = reader.GetDateTime(0).Date;
                                int count = reader.GetInt32(1);
                                appointmentCounts[date] = count;
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
                    cellPanel.BackColor = ColorTranslator.FromHtml("#d9faf5");
                }

                if (appointmentCounts.ContainsKey(thisDate.Date))
                {
                    int count = appointmentCounts[thisDate.Date];

                    Label appLabel = new Label { Text = $" ● {count} Appointment/s", AutoEllipsis = true, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, ForeColor = ColorTranslator.FromHtml("#69e331"), Font = new Font("Segoe UI", 8), Tag = thisDate };

                    cellPanel.Controls.Add(appLabel);
                    cellPanel.Cursor = Cursors.Hand;
                    appLabel.Tag = thisDate;
                    appLabel.Click += CellPanel_Click;
                    cellPanel.BackColor = ColorTranslator.FromHtml("#E1F9D7");
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

                LoadHistory(Appid, facid, clientId, appointmentDateFilter: selectedDate);
            }
        }


        private void AstoreproPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReschedButton_Click(object sender, EventArgs e)
        {
            NoticeClient noticeclient = new NoticeClient();
            noticeclient.CancelPanel();
            if (noticeclient.ShowDialog() == DialogResult.OK || !string.IsNullOrWhiteSpace(noticeclient.Reason))
            {
                string reason = noticeclient.Reason;
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
                            cmd.Parameters.AddWithValue("?", Appid);

                            cmd.ExecuteNonQuery();
                        }
                        string clientName = FName + " " + LName;
                        SendCancelEmail(Appid, EmailAddress, clientName, appdate, apptime, Facname, reason);
                        string senders = "Client", titles = "Appointment Updated", messages = "Your appointment was updated.";
                        DateTime now = DateTime.Now;
                        SaveNotification(clientId, facid, senders, titles, messages, now, Appid);
                        System.Windows.Forms.MessageBox.Show("Appointment cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void SendCancelEmail(int appointmentId, string clientEmail, string clientName, string appointmentDate, string appointmentTime, string providerName, string Reason)
        {
            try
            {
                string emailTemplatePath = @"D:\\OOP2\\HTML\\Appointment Cancellation by Client.html";
                string emailBody = File.ReadAllText(emailTemplatePath);

                emailBody = emailBody.Replace("{ClientName}", clientName)
                                     .Replace("{FacilityName}", providerName)
                                     .Replace("{AppointmentDate}", appointmentDate)
                                     .Replace("{AppointmentTime}", appointmentTime)
                                     .Replace("{Reasonbyclient}", Reason);

                var message = new MailMessage();
                message.From = new MailAddress("snmcorporation.dlic@gmail.com");
                message.To.Add("snmcorporation.dlic@gmail.com");
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
                LoadHistory(Appid, facid, clientId);
                FilterDateBox.Visible = false; FilterBox.Visible = true; AppSearch.Visible = false;
                filter2 = null;
            }
        }

        private void FilterStatusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter2 = FilterStatusBox.SelectedItem.ToString();

            if (filter2 == "Pending")
            {
                LoadHistory(Appid, facid, clientId, statusFilter: "Pending");
            }
            else if (filter2 == "Confirmed")
            {
                LoadHistory(Appid, facid, clientId, statusFilter: "Confirmed");
            }
            else if (filter2 == "Cancelled")
            {
                LoadHistory(Appid, facid, clientId, statusFilter: "Cancelled");
            }
            else if (filter2 == "Completed")
            {
                LoadHistory(Appid, facid, clientId, statusFilter: "Completed");
            }
            else if (filter2 == "No Show")
            {
                LoadHistory(Appid, facid, clientId, statusFilter: "No Show");
            }
            else if (filter2 == "--Back--")
            {
                LoadHistory(Appid, facid, clientId);
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
                        LoadHistory(Appid, facid, clientId, appointmentDateFilter: date);
                    }
                    else if (filter2 == "Date Booked")
                    {
                        LoadHistory(Appid, facid, clientId, dateBookedFilter: date);
                    }
                }
            }
            else if (filter1 == "Facility")
            {
                if (int.TryParse(input, out int facilityId))
                {
                    LoadHistory(Appid, facid, clientId, facilityIdFilter: facilityId);
                }
                else
                {
                    //LoadHistory(Appid, facid, clientId, facilityNameLike: input);
                }
            }
        }

        private void MessageBox_Click(object sender, EventArgs e)
        {
            Messagerpanel.Visible = true; Messagerpanel.BringToFront();
            LoadChatMessages(clientId, facid);
        }

        private void Messengerclose_Click(object sender, EventArgs e)
        {
            Messagerpanel.Visible = false;
        }

        private void LoadChatMessages(int clientId, int facilityId)
        {
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

                int clientI = clientId;
                int facilityId = facid;

                DateTime now = DateTime.Now;

                SaveMessageToDatabase(clientId, facilityId, senderType, message);

                AddMessageBubble(senderType, message, now);
                string senders = "Client", titles = "New Message", messages = "Client sent you a message!";
                SaveNotificationMessage(clientI, facilityId, senders, titles, messages, now);

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

            if (appointmentId.HasValue)
            {
                notifPanel.Click += (s, e) => ViewDets(appointmentRealId, facilityId, clientId);
                foreach (Control control in new Control[] { lblTitle, lblMessage, lblTime })
                {
                    control.Click += (s, e) => ViewDets(appointmentRealId, facilityId, clientId);
                }

            }
            else
            {
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

            }

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
                         WHERE Client_ID = ? AND Sender = ?
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

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = NameTextBox.Text.Trim();
            LoadFacilities(searchText);

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = NameTextBox.Text.Trim();
            SerButton.Visible = true;
            SerPanel.Visible = true;
            ServicesPanel.Visible = false;
            if (notify == true)
            {
                NotificationPanel.Visible = false;
                NotifyButton.BackColor = ColorTranslator.FromHtml("#cff1c4");
                notify = false;
            }
            SerButton.Text = "  Search Facility";
            LoadFacilities(searchText);
        }

        private void NameTextBox_Click(object sender, EventArgs e)
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
            SerButton.Text = "  Search Facility";
        }

        private void RateButton_Click(object sender, EventArgs e)
        {
            Rates rates = new Rates();
            rates.SubmitButtonClicked += (s, ev) =>
            {
                int userRating = rates.Ratings;
                UpdateFacilityRating(facid, userRating);
                rates.Close();
            };

            rates.ShowDialog();
        }

        private void UpdateFacilityRating(int facilityId, int newRating)
        {
            try
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();

                    double oldRating = 0;

                    string selectSql = "SELECT [Ratings] FROM [Service Facilities] WHERE [Facility_ID] = ?";
                    using (OleDbCommand selectCmd = new OleDbCommand(selectSql, myConn))
                    {
                        selectCmd.Parameters.AddWithValue("?", facilityId);

                        object result = selectCmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            double.TryParse(result.ToString(), out oldRating);
                        }
                    }

                    double averageRating = (oldRating + newRating) / 2.0;

                    string updateSql = "UPDATE [Service Facilities] SET [Ratings] = ? WHERE [Facility_ID] = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateSql, myConn))
                    {
                        updateCmd.Parameters.AddWithValue("?", averageRating);
                        updateCmd.Parameters.AddWithValue("?", facilityId);

                        updateCmd.ExecuteNonQuery();
                    }

                    string updateadmin = "UPDATE [Admin (Service Facilities)] SET [Ratings] = ? WHERE [Facility_ID] = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateadmin, myConn))
                    {
                        updateCmd.Parameters.AddWithValue("?", averageRating);
                        updateCmd.Parameters.AddWithValue("?", facilityId);

                        updateCmd.ExecuteNonQuery();
                    }
                }

                System.Windows.Forms.MessageBox.Show("Thank you for rating! Your rating has been submitted.", "Rating Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error while submitting rating:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Adminbutton_Click(object sender, EventArgs e)
        {
            Messagerpanel.Visible = true; Messagerpanel.BringToFront();
            facid = 2;
            LoadChatMessages(clientId, facid);
        }

        private void RecomdPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
