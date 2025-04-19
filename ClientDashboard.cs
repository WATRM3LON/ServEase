using Microsoft.VisualBasic;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
        string locs = "", Ems = "", selectedTime = "";
        int facid, newClientId = 0, Appid;
        int clientId;
        public ClientDashboard()
        {
            InitializeComponent();
            InfoGetter();
            Loaders(); HiLabel.Text = $"Hi {FName},";
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
            FacilityProPanel2.Visible = false; ASReasontext.Visible = false; ASReasonlabel.Visible = false;
            PIEButton.Visible = false; FillEM.Visible = false; BookAppbutton.Visible = false;
            EditPIPanel.Visible = false; CnumberExisted.Visible = false; CnumberInvalid.Visible = false;
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


            //button60.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button60.Width, button60.Height, 10, 10));
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

        public void InfoGetter()
        {
            EmailAddress = ClientLogin.EmailAddress;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT [First Name], [Last Name], [Birth Date], Sex, [Contact Number], Location, Password FROM Clients WHERE [Email Address] = @Email";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("@Email", EmailAddress);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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
                        MessageBox.Show("Invalid birthdate format.");
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
                    newClientId = Convert.ToInt32(result);
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
                        MessageBox.Show("Invalid birthdate format.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@sex", PIESextext.Text);
                    cmd.Parameters.AddWithValue("@cnumber", PIECnumbertext.Text);
                    cmd.Parameters.AddWithValue("@address", PIEAddresstext.Text);
                    cmd.Parameters.AddWithValue("@Email", PIEEmailtext.Text);

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
            panel3.Visible = true;
            HiLabel.Visible = true; HiLabel.Text = $"Hi {ClientLogin.EmailAddress},";
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
            CalendarAppointmentPanel.Visible = true; PopulateCalendarPanel();
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
            LoadHistory();
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
            InfoGetter();
            Loaders();
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
            DialogResult results = MessageBox.Show("Are you sure you want to permanently delete this account? This action cannot be undone.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            clientId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Client not found.");
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
                            MessageBox.Show("Deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No matching email found. Deletion failed.");
                            return;
                        }
                    }

                    string adminUpdateQuery = "UPDATE [Admin (Clients)] SET Status = ?, [Date Deleted] = ? WHERE Client_ID = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(adminUpdateQuery, myConn))
                    {
                        updateCmd.Parameters.AddWithValue("?", "Deleted");
                        updateCmd.Parameters.AddWithValue("?", DateTime.Today);
                        updateCmd.Parameters.AddWithValue("?", clientId);

                        updateCmd.ExecuteNonQuery();
                    }
                }

                this.Hide();
                ClientLogin clientLogin = new ClientLogin();
                clientLogin.ShowDialog();
            }
            else
            {
                MessageBox.Show("You clicked No!");
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

        public void LoadFacilities()
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

                string sql = "SELECT Facility_ID, [Facility Name], [Working Hours Start], [Working Hours End], [Ratings], [Email Address] FROM [Service Facilities] WHERE [Service Category] = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", sercat);

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
                            //facilityPanel.Loaders();
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
            PopulateCalendarPanel();
        }

        private void ATCNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(+1);
            PopulateCalendar();
            PopulateCalendarPanel();
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!SelectedServices.Any())
            {
                MessageBox.Show("Please select at least one service.");
                return;
            }

            if (selectedAppointmentDate == null || selectedTimeSlotLabel == null)
            {
                MessageBox.Show("Please select a date and timeslot.");
                return;
            }

            EmailAddress = ClientLogin.EmailAddress;
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

                string insertAppointment = "INSERT INTO Appointments ([Client_ID], [Facility_ID], [Appointment Status], [Appointment Date], [Date Booked], [Start Time], [End Time], [Estimated Price], [Estimated Duration], Reason) " +
                           "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand cmd = new OleDbCommand(insertAppointment, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newClientId);
                    cmd.Parameters.AddWithValue("?", facid);
                    cmd.Parameters.AddWithValue("?", "Pending");

                    string dateTimeString = $"{selectedAppointmentDate:dd MM yyyy}";
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    cmd.Parameters.AddWithValue("?", dateTimeString);

                    string[] timeParts = selectedTimeSlotLabel.Text.Split('-');
                    string startTimeText = timeParts[0].Trim();
                    string endTimeText = timeParts[1].Trim();

                    DateTime startTime = DateTime.Parse($"{startTimeText: hh:mm tt}");
                    DateTime endTime = DateTime.Parse($"{endTimeText: hh:mm tt}");
                    string bookeddate = DateTime.Now.ToString("dd MM yyyy");
                    cmd.Parameters.AddWithValue("?", bookeddate);
                    cmd.Parameters.AddWithValue("?", startTimeText);
                    cmd.Parameters.AddWithValue("?", endTimeText);

                    cmd.Parameters.AddWithValue("?", EPrice);

                    string durationString = $"{EDuration} mins";
                    cmd.Parameters.AddWithValue("?", durationString);
                    cmd.Parameters.AddWithValue("?", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                int AppointmentId = 0;
                string getAppointmentIdQuery = "SELECT MAX(Appointment_ID) FROM [Appointments] WHERE Facility_ID = ?";

                using (OleDbCommand getServiceIdsCmd = new OleDbCommand(getAppointmentIdQuery, myConn))
                {
                    getServiceIdsCmd.Parameters.AddWithValue("?", facid);

                    using (OleDbDataReader reader = getServiceIdsCmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            AppointmentId = reader.GetInt32(0);
                        }
                    }
                }
                foreach (var service in SelectedServices)
                {
                    string insertServiceQuery = "INSERT INTO [Appointment Services] ([Appointment_ID], [Service_ID]) " +
                                                "VALUES (@appid, @serviceid)";

                    using (OleDbCommand cmd = new OleDbCommand(insertServiceQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("@appid", AppointmentId);
                        cmd.Parameters.AddWithValue("@serviceid", service.ServiceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Updated successfully!");
        }

        public void LoadHistory()
        {
            AppointmentsPanel.Controls.Clear();
            EmailAddress = ClientLogin.EmailAddress;
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

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", newClientId);
                    object result = cmd.ExecuteScalar();

                    int count = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                    if (count > 0)
                    {
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
                                            FacName = readers.IsDBNull(readers.GetOrdinal("Facility Name")) ? "" : readers["Facility Name"].ToString();
                                            FLocation = readers.IsDBNull(readers.GetOrdinal("Facility Location")) ? "" : readers["Facility Location"].ToString();
                                        }
                                    }
                                }

                                UsersPanel usersPanel = new UsersPanel();
                                usersPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));
                                usersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;


                                usersPanel.Location = new Point(10, margin);
                                margin += usersPanel.Height + 10;

                                usersPanel.ViewDetailsClicked += (s, e) =>
                                {
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
                                            string status = adminReader.GetString(adminReader.GetOrdinal("Appointment Status"));
                                            string dateapp = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");
                                            string datebooked = adminReader.IsDBNull(2) ? "" : adminReader.GetDateTime(2).ToString("dd MMM yyyy");

                                            usersPanel.ClientInfo(status, dateapp); usersPanel.CLientApp(FacName, datebooked);
                                        }
                                    }
                                }


                                AppointmentsPanel.Controls.Add(usersPanel);
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        public void ViewDets(int ID, int Faid, int Clid)
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
                            }
                            else
                            {
                                ASstattext.ForeColor = Color.Red;
                                ASReasonlabel.Visible = true; ASReasontext.Visible = true;
                                ASReasontext.Text = reason;
                                ReschedButton.Visible = false;
                            }
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

        void PopulateCalendarPanel()
        {
            CAC3.Controls.Clear();
            CAC3.SuspendLayout();

            DateTime firstDay = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            int startCol = (int)firstDay.DayOfWeek;

            int row = 0;
            int col = startCol;

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime thisDate = new DateTime(currentMonth.Year, currentMonth.Month, day);
                DayOfWeek dayOfWeek = thisDate.DayOfWeek;

                Label dayLabel = new Label
                {
                    Text = day.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopRight,
                    Margin = new(5, 5, 5, 5),
                    BorderStyle = BorderStyle.None,
                    Font = new Font("Segoe UI", 10),
                    Tag = thisDate
                };

                if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Saturday)
                {
                    dayLabel.ForeColor = Color.DimGray;
                    dayLabel.BackColor = Color.WhiteSmoke;
                }

                dayLabel.Cursor = Cursors.Hand;
                dayLabel.Click += DayLabel_Click;


                if (thisDate.Date == DateTime.Today.Date)
                {
                    dayLabel.BackColor = ColorTranslator.FromHtml("#d9faf5");
                }

                CAC3.Controls.Add(dayLabel, col, row);

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

                        MessageBox.Show("Appointment cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
