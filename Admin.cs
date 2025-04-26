using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
using Image = System.Drawing.Image;

namespace OOP2
{
    public partial class Admin : Form
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

        string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\OOP2 Database - Copy.accdb";
        bool Client = true, Facility = false, File1 = false, File2 = false, File3 = false, File4 = false, File5 = false, File6 = false, File7 = false;
        int clientId, facilityId;

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
        public Admin()
        {
            InitializeComponent();
            ViewDetpanel.Visible = false; CViewDetailspanel.Visible = false; AppHistPanel.Visible = false; FViewDetailspanel.Visible = false;
            Loaders();
        }
        string Fname, Lname; int Facility_ID;
        public void Loaders()
        {
            DashboardPanel.Visible = true;
            DashboardPanel2.Visible = NotificationPanel.Visible = false;
            ManageButton.BackColor = SButton.BackColor = ColorTranslator.FromHtml("#22B0E5");
            LoadFacilityData();

            //DASHBOARD
            DashboardPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardPanel.Width, DashboardPanel.Height, 20, 20));
            DashboardPanel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DashboardPanel2.Width, DashboardPanel2.Height, 20, 20));
            //MANAGE
            ManageButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ManageButton.Width, ManageButton.Height, 10, 10));
            SButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SButton.Width, SButton.Height, 10, 10));
            ClientsButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ClientsButton.Width, ClientsButton.Height, 10, 10));
            SerFacbutton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SerFacbutton.Width, SerFacbutton.Height, 10, 10));
            //PROFILE
            CProPicPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CProPicPanel.Width, CProPicPanel.Height, 10, 10));
            CPIPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CPIPanel.Width, CPIPanel.Height, 10, 10));
            DeAccButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, DeAccButton.Width, DeAccButton.Height, 10, 10));
            StatusText.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, StatusText.Width, StatusText.Height, 10, 10));
            File1Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File1Approved.Width, File1Approved.Height, 10, 10));
            File1Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File1Reject.Width, File1Reject.Height, 10, 10));
            File2Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File2Approved.Width, File2Approved.Height, 10, 10));
            File2Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File2Reject.Width, File2Reject.Height, 10, 10));
            File3Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File3Approved.Width, File3Approved.Height, 10, 10));
            File3Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File3Reject.Width, File3Reject.Height, 10, 10));
            File4Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File4Approved.Width, File4Approved.Height, 10, 10));
            File4Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File4Reject.Width, File4Reject.Height, 10, 10));
            File5Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File5Approved.Width, File5Approved.Height, 10, 10));
            File5Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File5Reject.Width, File5Reject.Height, 10, 10));
            File6Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File6Approved.Width, File6Approved.Height, 10, 10));
            File6Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File6Reject.Width, File6Reject.Height, 10, 10));
            File7Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File7Approved.Width, File7Approved.Height, 10, 10));
            File7Reject.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File7Reject.Width, File7Reject.Height, 10, 10));
            File1Approved.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, File1Approved.Width, File1Approved.Height, 10, 10));
            ConfirmButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ConfirmButton.Width, ConfirmButton.Height, 10, 10));
        }
        public void UpdateInfo() { }
        public bool CNumberChecker(string cNumber, string connection)
        {

            return true;
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
            CloseButton.BackColor = ColorTranslator.FromHtml("#e8f5e9");
        }

        private void MaximizeButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#81eedf");
        }

        private void MaximizeButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#e8f5e9");
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                UsersPanel usersPanel = new UsersPanel();
                usersPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                LoadFacilityData();
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                UsersPanel usersPanel = new UsersPanel();
                usersPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                LoadFacilityData();
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
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#e8f5e9");
        }

        private void LogoButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            DashboardPanel2.Visible = true;
            HeaderPanel.Location = new Point(75, 44);
        }

        private void LogosButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = true;
            DashboardPanel2.Visible = false;
            HeaderPanel.Location = new Point(190, 44);
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

        private void LoadFacilityData()
        {
            ProfilePanel.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                if (Client)
                {
                    string sql = "SELECT Client_ID, [First Name], [Last Name], [Email Address] FROM [Admin (Clients)] WHERE [Email Address] <> 'admin12345'";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;

                        while (reader.Read())
                        {
                            int actualClientId = reader.GetInt32(reader.GetOrdinal("Client_ID"));

                            string fName = reader.IsDBNull(reader.GetOrdinal("First Name")) ? "" : reader.GetString(reader.GetOrdinal("First Name"));
                            string lName = reader.IsDBNull(reader.GetOrdinal("Last Name")) ? "" : reader.GetString(reader.GetOrdinal("Last Name"));
                            string fullName = fName + " " + lName;

                            string email = reader.IsDBNull(reader.GetOrdinal("Email Address")) ? "" : reader.GetString(reader.GetOrdinal("Email Address"));

                            UsersPanel usersPanel = new UsersPanel();
                            usersPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));
                            usersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                            usersPanel.SetDataClient(fullName, email);

                            usersPanel.ClientId = actualClientId;
                            usersPanel.ViewDetailsClicked += (s, e) =>
                            {
                                clientId = actualClientId;
                                ViewDets(actualClientId);
                            };


                            usersPanel.Location = new Point(10, margin - 7);
                            margin += usersPanel.Height + 10;

                            string adminQuery = "SELECT Status, [Date Registered] FROM [Admin (Clients)] WHERE [Client_ID] = ?";
                            using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                            {
                                adminCmd.Parameters.AddWithValue("?", actualClientId);

                                using (OleDbDataReader adminReader = adminCmd.ExecuteReader())
                                {
                                    if (adminReader.Read())
                                    {
                                        string status = adminReader.GetString(adminReader.GetOrdinal("Status"));
                                        string dateRegistered = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");

                                        usersPanel.SetInfo(status, dateRegistered);
                                    }
                                }
                            }

                            ProfilePanel.Controls.Add(usersPanel);

                        }
                    }
                }
                else
                {
                    string sql = "SELECT Facility_ID, [Facility Name], [Approval Status] FROM [Admin (Service Facilities)] WHERE [Email Address] <> 'admin12345'";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int margin = 10;

                        while (reader.Read())
                        {
                            int facilityId = reader.GetInt32(reader.GetOrdinal("Facility_ID"));
                            string Name = reader.IsDBNull(reader.GetOrdinal("Facility Name")) ? "" : reader.GetString(reader.GetOrdinal("Facility Name"));
                            string email = reader.IsDBNull(reader.GetOrdinal("Approval Status")) ? "" : reader.GetString(reader.GetOrdinal("Approval Status"));

                            UsersPanel usersPanel = new UsersPanel();
                            usersPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));

                            usersPanel.SetDataFacility(Name, email);
                            usersPanel.ViewDetailsClicked += (s, e) =>
                            {
                                Facility_ID = facilityId;
                                ViewDets(facilityId);
                            };

                            usersPanel.Location = new Point(10, margin - 7);
                            margin += usersPanel.Height + 10;

                            string adminQuery = "SELECT Status, [Date Registered] FROM [Admin (Service Facilities)] WHERE [Facility_ID] = ?";
                            using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                            {
                                adminCmd.Parameters.AddWithValue("?", facilityId);

                                using (OleDbDataReader adminReader = adminCmd.ExecuteReader())
                                {
                                    if (adminReader.Read())
                                    {
                                        string status = adminReader.GetString(adminReader.GetOrdinal("Status"));
                                        string dateRegistered = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");

                                        usersPanel.SetInfo(status, dateRegistered);
                                    }
                                }
                            }

                            ProfilePanel.Controls.Add(usersPanel);
                        }
                    }
                }
            }
        }
        public void InfoGetter()
        {
            if (Client)
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();

                    string sql = "SELECT [First Name], [Last Name], [Birth Date], Sex, [Contact Number], Location, [Email Address], Password, Status, [Date Registered], [Date Deleted] FROM [Admin (Clients)] WHERE Client_ID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", clientId);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string CFName = reader["First Name"].ToString();
                                string CLName = reader["Last Name"].ToString();
                                string emailaddress = reader["Email Address"].ToString();
                                DateTime Birthdate = reader.IsDBNull(reader.GetOrdinal("Birth Date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Birth Date"));
                                string formattedBirthdate = Birthdate == DateTime.MinValue ? " " : Birthdate.ToString("dd MMMM yyyy");
                                string Sex = reader["Sex"].ToString();
                                string Password = reader["Password"].ToString();
                                string ContactNumber = reader["Contact Number"].ToString();
                                string LocationAddress = reader.IsDBNull(reader.GetOrdinal("Location")) ? " " : reader["Location"].ToString();
                                string Status = reader["Status"].ToString();
                                DateTime dateregist = reader.IsDBNull(reader.GetOrdinal("Date Registered")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date Registered"));
                                string regist = dateregist == DateTime.MinValue ? " " : dateregist.ToString("dd MMMM yyyy");
                                DateTime datedelete = reader.IsDBNull(reader.GetOrdinal("Date Deleted")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date Deleted"));
                                string deleted = datedelete == DateTime.MinValue ? " " : datedelete.ToString("dd MMMM yyyy");

                                PPClientName.Text = ClientNamePI.Text = CFName + CLName;
                                BirthDatePI.Text = formattedBirthdate; SexPI.Text = Sex; ContactNumberPI.Text = ContactNumber; EmailAddressPI.Text = emailaddress;
                                LocText.Text = LocationAddress; dateregisttext.Text = regist; datedeletetext.Text = deleted;



                                int age;
                                if (BirthDatePI.Text.Length == 1)
                                {
                                    AgePI.Text = " ";
                                }
                                else
                                {
                                    age = DateTime.Now.Year - Birthdate.Year; AgePI.Text = age.ToString();
                                }

                                if (Status == "Active")
                                {
                                    StatusText.ForeColor = ColorTranslator.FromHtml("#69e331"); StatusText.Text = Status;
                                }
                                else if (Status == "Deactivated")
                                {
                                    StatusText.ForeColor = Color.Gold; StatusText.Text = Status;
                                }
                                else
                                {
                                    StatusText.ForeColor = Color.Red; StatusText.Text = Status;
                                }


                            }
                        }


                    }
                }
            }
            else
            {
                using (OleDbConnection myConn = new OleDbConnection(connection))
                {
                    myConn.Open();
                    string sql = "SELECT [Email Address], [Facility Name], [Facility Location], [Owner First Name], [Owner Last Name], [Contact Number], [Status], [Service Category], [Specific Category], [Working Hours Start], [Working Hours End], [Working Days], [Date Registered], Ratings, [Approval Status], [Date Deleted] FROM [Admin (Service Facilities)] WHERE [Facility_ID] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", Facility_ID);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FIEmailtext.Text = reader["Email Address"].ToString();
                                FIFnameTitle.Text = reader["Facility Name"].ToString();
                                string FName = reader["Owner First Name"].ToString();
                                string LName = reader["Owner Last Name"].ToString();
                                FIFnametext.Text = Fname + " " + Lname;
                                DateTime workingstart = reader.IsDBNull(reader.GetOrdinal("Working Hours Start")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours Start"));
                                DateTime workingend = reader.IsDBNull(reader.GetOrdinal("Working Hours End")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Working Hours End"));
                                string formattedWorHours = (workingstart == DateTime.MinValue || workingend == DateTime.MinValue) ? " " : $"{workingstart:hh\\:mm tt} - {workingend:hh\\:mm tt}";
                                FIWorhourstext.Text = formattedWorHours;
                                FIWordaystext.Text = reader["Working Days"].ToString();
                                FICnumbertext.Text = reader["Contact Number"].ToString();
                                FILoctext.Text = reader.IsDBNull(reader.GetOrdinal("Facility Location")) ? " " : reader["Facility Location"].ToString();
                                FISerCattext.Text = reader["Service Category"].ToString();
                                FISpecific.Text = reader["Specific Category"].ToString();
                                string AppStatus = reader["Approval Status"].ToString();
                                string Status = reader["Status"].ToString();
                                DateTime dateregist = reader.IsDBNull(reader.GetOrdinal("Date Registered")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date Registered"));
                                string regist = dateregist == DateTime.MinValue ? " " : dateregist.ToString("dd MMMM yyyy");
                                FIregisttext.Text = regist;
                                DateTime datedelete = reader.IsDBNull(reader.GetOrdinal("Date Deleted")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date Deleted"));
                                string delete = datedelete == DateTime.MinValue ? " " : datedelete.ToString("dd MMMM yyyy");
                                FIdeletetext.Text = delete;

                                if (Status == "Active")
                                {
                                    FIStatus.ForeColor = ColorTranslator.FromHtml("#69e331"); FIStatus.Text = Status;
                                }
                                else if (Status == "Deactivated")
                                {
                                    FIStatus.ForeColor = Color.Gold; FIStatus.Text = Status;
                                }
                                else
                                {
                                    FIStatus.ForeColor = Color.Red; FIStatus.Text = Status;
                                }

                                if (AppStatus == "Approved")
                                {
                                    FIAppStatus.ForeColor = ColorTranslator.FromHtml("#69e331"); FIAppStatus.Text = AppStatus;
                                }
                                else if (AppStatus == "Pending")
                                {
                                    FIAppStatus.ForeColor = Color.Gold; FIAppStatus.Text = AppStatus;
                                }
                                else
                                {
                                    FIAppStatus.ForeColor = Color.Red; FIAppStatus.Text = AppStatus;
                                }
                            }
                        }
                    }
                    string getLatestFiles = @"
                        SELECT * 
                        FROM [Facility Files] 
                        WHERE [Uploaded Date] = (
                            SELECT MAX([Uploaded Date]) 
                            FROM [Facility Files] 
                            WHERE Facility_ID = ?
                        ) 
                        AND Facility_ID = ?
                    ";

                    using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", Facility_ID);
                        cmd.Parameters.AddWithValue("?", Facility_ID);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string businessRegistrationName = !reader.IsDBNull(reader.GetOrdinal("Business Registration")) ? "Business Registration Uploaded" : "No File";
                                string governmentIdName = !reader.IsDBNull(reader.GetOrdinal("Valid Government-issued ID")) ? "Government ID Uploaded" : "No File";
                                string serviceLicensesName = !reader.IsDBNull(reader.GetOrdinal("Service Licenses / Certifications")) ? "Service Licenses Uploaded" : "No File";
                                string proofOfAddressName = !reader.IsDBNull(reader.GetOrdinal("Proof of Address")) ? "Proof of Address Uploaded" : "No File";
                                string taxDocumentsName = !reader.IsDBNull(reader.GetOrdinal("Tax Documents")) ? "Tax Documents Uploaded" : "No File";
                                string insuranceComplianceName = !reader.IsDBNull(reader.GetOrdinal("Insurance or Safety Compliance")) ? "Insurance Compliance Uploaded" : "No File";

                                File1Fname.Text = businessRegistrationName;
                                File2Fname.Text = governmentIdName;
                                File4Fname.Text = serviceLicensesName;
                                File5Fname.Text = proofOfAddressName;
                                File6Fname.Text = taxDocumentsName;
                                File7Fname.Text = insuranceComplianceName;
                            }
                        }
                    }


                }
            }
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            SerFacbutton.Font = new Font(SerFacbutton.Font, SerFacbutton.Font.Style & ~FontStyle.Bold);
            SerFacbutton.FlatStyle = FlatStyle.Flat;

            ClientsButton.FlatStyle = FlatStyle.System;
            ClientsButton.Font = new Font(ClientsButton.Font, ClientsButton.Font.Style | FontStyle.Bold);
            Client = true; Facility = false;
            LoadFacilityData();
        }

        private void SerFacbutton_Click(object sender, EventArgs e)
        {
            ClientsButton.Font = new Font(ClientsButton.Font, ClientsButton.Font.Style & FontStyle.Regular);
            ClientsButton.FlatStyle = FlatStyle.Flat;

            SerFacbutton.FlatStyle = FlatStyle.System;
            SerFacbutton.Font = new Font(SerFacbutton.Font, SerFacbutton.Font.Style | FontStyle.Bold);
            Client = false; Facility = true;
            LoadFacilityData();
        }

        public void ViewDets(int IdClient)
        {
            InfoGetter();
            CalendarAppointmentPanel.Visible = false; ProfilePanel.Visible = false; HiLabel.Visible = false; WelcomeLabel.Visible = false;
            AccountButton.Visible = true;
            if (Client)
            {
                ViewDetpanel.Visible = true; CViewDetailspanel.Visible = true;
                AccountButton.Text = " Client's Account";
                InfoGetter();
            }
            else
            {
                FViewDetailspanel.Visible = true;
                AccountButton.Text = " Facility's Account";
                
            }
        }
        private void AccountButton_Click(object sender, EventArgs e)
        {
            CalendarAppointmentPanel.Visible = true; ProfilePanel.Visible = true; HiLabel.Visible = true; WelcomeLabel.Visible = true;
            ViewDetpanel.Visible = false; CViewDetailspanel.Visible = false; AccountButton.Visible = false; AppHistPanel.Visible = false;
            ApphisButton.Font = new Font(ApphisButton.Font, ApphisButton.Font.Style & ~FontStyle.Bold);
            ApphisButton.FlatStyle = FlatStyle.Flat;

            Personalbutton.FlatStyle = FlatStyle.System;
            Personalbutton.Font = new Font(Personalbutton.Font, Personalbutton.Font.Style | FontStyle.Bold);
        }

        private void Personalbutton_Click(object sender, EventArgs e)
        {
            ApphisButton.Font = new Font(ApphisButton.Font, ApphisButton.Font.Style & ~FontStyle.Bold);
            ApphisButton.FlatStyle = FlatStyle.Flat; CViewDetailspanel.Visible = true;

            Personalbutton.FlatStyle = FlatStyle.System; AppHistPanel.Visible = false;
            Personalbutton.Font = new Font(Personalbutton.Font, Personalbutton.Font.Style | FontStyle.Bold);
        }

        private void ApphisButton_Click(object sender, EventArgs e)
        {
            Personalbutton.Font = new Font(Personalbutton.Font, Personalbutton.Font.Style & ~FontStyle.Bold);
            Personalbutton.FlatStyle = FlatStyle.Flat; CViewDetailspanel.Visible = false;

            ApphisButton.FlatStyle = FlatStyle.System; AppHistPanel.Visible = true;
            ApphisButton.Font = new Font(ApphisButton.Font, ApphisButton.Font.Style | FontStyle.Bold);
            LoadHistory();
        }

        public void LoadHistory()
        {
            AppHistPanel.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();
                string sql = "SELECT Facility_ID, Appointment_ID FROM Appointments WHERE Client_ID = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", clientId);

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


                                usersPanel.Location = new Point(10, margin - 7);
                                margin += usersPanel.Height + 10;

                                string adminQuery = "SELECT [Appointment Status], [Appointment Date], [Date Booked] FROM Appointments WHERE [Client_ID] = ? AND [Facility_ID] = ? AND [Appointment_ID] = ?";
                                using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                                {
                                    adminCmd.Parameters.AddWithValue("?", clientId);
                                    adminCmd.Parameters.AddWithValue("?", newFacilityId);
                                    adminCmd.Parameters.AddWithValue("?", appointmentId);

                                    using (OleDbDataReader adminReader = adminCmd.ExecuteReader())
                                    {
                                        if (adminReader.Read())
                                        {
                                            string status = adminReader.GetString(adminReader.GetOrdinal("Appointment Status"));
                                            string dateapp = adminReader.IsDBNull(1) ? "" : adminReader.GetDateTime(1).ToString("dd MMM yyyy");
                                            string datebooked = adminReader.IsDBNull(2) ? "" : adminReader.GetDateTime(2).ToString("dd MMM yyyy");

                                            usersPanel.SetInfo(status, dateapp); usersPanel.SetAppHistory(FacName, datebooked);
                                        }
                                    }
                                }


                                AppHistPanel.Controls.Add(usersPanel);
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void NotePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VFilesbutton_Click(object sender, EventArgs e)
        {
            InfoGetter();
            FViewDetailspanel.Visible = true; AccountButton.Visible = true;
            AccountButton.Text = " Facility's Account";
            VFilesbutton.Visible = false; VFilespanel.Visible = false;
            File1name.Font = File2name.Font = File3name.Font = File4name.Font = File5name.Font = File6name.Font = File7name.Font = new Font(File1name.Font, FontStyle.Regular); File1name.ForeColor = Color.Black;
            File1name.ForeColor = File2name.ForeColor = File3name.ForeColor = File4name.ForeColor = File5name.ForeColor = File6name.ForeColor = File7name.ForeColor = Color.Black;
        }

        private void FilesButton_Click(object sender, EventArgs e)
        {
            FViewDetailspanel.Visible = false; AccountButton.Visible = false;
            VFilesbutton.Visible = true; VFilespanel.Visible = true;
        }

        private void Photoclose_Click(object sender, EventArgs e)
        {
            Photopanel.Visible = false;
        }

        private void File1Fname_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestFiles = @"
                                SELECT * 
                                FROM [Facility Files] 
                                WHERE [Uploaded Date] = (
                                    SELECT MAX([Uploaded Date]) 
                                    FROM [Facility Files] 
                                    WHERE Facility_ID = ?
                                ) 
                                AND Facility_ID = ?
                            ";

                using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Business Registration")))
                            {
                                byte[] imageBytes = (byte[])reader["Business Registration"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Photobox.Image = Image.FromStream(ms);
                                    Photopanel.Visible = true;

                                }
                            }
                        }
                    }
                }
                VFilespanel.SendToBack();
            }
        }

        private void File2Fname_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestFiles = @"
                                SELECT * 
                                FROM [Facility Files] 
                                WHERE [Uploaded Date] = (
                                    SELECT MAX([Uploaded Date]) 
                                    FROM [Facility Files] 
                                    WHERE Facility_ID = ?
                                ) 
                                AND Facility_ID = ?
                            ";

                using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Valid Government-issued ID")))
                            {
                                byte[] imageBytes = (byte[])reader["Valid Government-issued ID"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Photobox.Image = Image.FromStream(ms);
                                    Photopanel.Visible = true;
                                }
                            }
                        }
                    }
                }
                VFilespanel.SendToBack();
            }
        }

        private void File4Fname_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestFiles = @"
                    SELECT * 
                    FROM [Facility Files] 
                    WHERE [Uploaded Date] = (
                        SELECT MAX([Uploaded Date]) 
                        FROM [Facility Files] 
                        WHERE Facility_ID = ?
                    ) 
                    AND Facility_ID = ?
                ";

                using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Service Licenses / Certifications")))
                            {
                                byte[] imageBytes = (byte[])reader["Service Licenses / Certifications"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Photobox.Image = Image.FromStream(ms);
                                    Photopanel.Visible = true;
                                }
                            }
                        }
                    }
                }
                VFilespanel.SendToBack();
            }
        }

        private void File5Fname_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestFiles = @"
                    SELECT * 
                    FROM [Facility Files] 
                    WHERE [Uploaded Date] = (
                        SELECT MAX([Uploaded Date]) 
                        FROM [Facility Files] 
                        WHERE Facility_ID = ?
                    ) 
                    AND Facility_ID = ?
                ";

                using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Proof of Address")))
                            {
                                byte[] imageBytes = (byte[])reader["Proof of Address"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Photobox.Image = Image.FromStream(ms);
                                    Photopanel.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            VFilespanel.SendToBack();
        }

        private void File6Fname_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestFiles = @"
                    SELECT * 
                    FROM [Facility Files] 
                    WHERE [Uploaded Date] = (
                        SELECT MAX([Uploaded Date]) 
                        FROM [Facility Files] 
                        WHERE Facility_ID = ?
                    ) 
                    AND Facility_ID = ?
                ";

                using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Tax Documents")))
                            {
                                byte[] imageBytes = (byte[])reader["Tax Documents"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Photobox.Image = Image.FromStream(ms);
                                    Photopanel.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            VFilespanel.SendToBack();
        }

        private void File7Fname_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestFiles = @"
                    SELECT * 
                    FROM [Facility Files] 
                    WHERE [Uploaded Date] = (
                        SELECT MAX([Uploaded Date]) 
                        FROM [Facility Files] 
                        WHERE Facility_ID = ?
                    ) 
                    AND Facility_ID = ?
                ";

                using (OleDbCommand cmd = new OleDbCommand(getLatestFiles, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Insurance or Safety Compliance")))
                            {
                                byte[] imageBytes = (byte[])reader["Insurance or Safety Compliance"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Photobox.Image = Image.FromStream(ms);
                                    Photopanel.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            VFilespanel.SendToBack();
        }

        private void File1Approved_Click(object sender, EventArgs e)
        {
            File1 = true;
            File1name.Font = new Font(File1name.Font, FontStyle.Bold);
            File1name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File1Reject_Click(object sender, EventArgs e)
        {
            File1 = false;
            File1name.Font = new Font(File1name.Font, FontStyle.Bold);
            File1name.ForeColor = Color.Red;
            NotePanel.Visible = true;
        }

        private void File2Approved_Click(object sender, EventArgs e)
        {
            File2 = true;
            File2name.Font = new Font(File2name.Font, FontStyle.Bold);
            File2name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File2Reject_Click(object sender, EventArgs e)
        {
            File2 = false;
            File2name.Font = new Font(File2name.Font, FontStyle.Bold);
            File2name.ForeColor = Color.Red;
        }

        private void File3Approved_Click(object sender, EventArgs e)
        {
            File3 = true;
            File3name.Font = new Font(File3name.Font, FontStyle.Bold);
            File3name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File3Reject_Click(object sender, EventArgs e)
        {
            File3 = false;
            File3name.Font = new Font(File3name.Font, FontStyle.Bold);
            File3name.ForeColor = Color.Red;
        }

        private void File4Approved_Click(object sender, EventArgs e)
        {
            File4 = true;
            File4name.Font = new Font(File4name.Font, FontStyle.Bold);
            File4name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File4Reject_Click(object sender, EventArgs e)
        {
            File4 = false;
            File4name.Font = new Font(File4name.Font, FontStyle.Bold);
            File4name.ForeColor = Color.Red; NotePanel.Visible = true;
        }

        private void File5Approved_Click(object sender, EventArgs e)
        {
            File5 = true;
            File5name.Font = new Font(File5name.Font, FontStyle.Bold);
            File5name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File5Reject_Click(object sender, EventArgs e)
        {
            File5 = false;
            File5name.Font = new Font(File5name.Font, FontStyle.Bold);
            File5name.ForeColor = Color.Red; NotePanel.Visible = true;
        }

        private void File6Approved_Click(object sender, EventArgs e)
        {
            File6 = true;
            File6name.Font = new Font(File6name.Font, FontStyle.Bold);
            File6name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File6Reject_Click(object sender, EventArgs e)
        {
            File6 = false;
            File6name.Font = new Font(File6name.Font, FontStyle.Bold);
            File6name.ForeColor = Color.Red; NotePanel.Visible = true;
        }

        private void File7Approved_Click(object sender, EventArgs e)
        {
            File7 = true;
            File7name.Font = new Font(File7name.Font, FontStyle.Bold);
            File7name.ForeColor = Color.Lime;
            if (File1 != false && File2 != false && File3 != false && File4 != false && File5 != false && File6 != false && File7 != false)
            {
                NotePanel.Visible = false;
            }
        }

        private void File7Reject_Click(object sender, EventArgs e)
        {
            File7 = false;
            File7name.Font = new Font(File7name.Font, FontStyle.Bold);
            File7name.ForeColor = Color.Red; NotePanel.Visible = true;
        }

        private void ClosePFbutton_Click(object sender, EventArgs e)
        {
            FPhotosPanel.Visible = false;
        }

        private void File3Fname_Click(object sender, EventArgs e)
        {
            PhotosFlowLayoutPanel.Controls.Clear();
            FPhotosPanel.Visible = true;
            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string getLatestDateQuery = "SELECT MAX([Uploaded Date]) FROM [Facility Files] WHERE Facility_ID = ?";
                DateTime? latestUploadDate = null;

                using (OleDbCommand latestDateCmd = new OleDbCommand(getLatestDateQuery, myConn))
                {
                    latestDateCmd.Parameters.AddWithValue("?", Facility_ID);

                    object result = latestDateCmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        latestUploadDate = Convert.ToDateTime(result);
                    }
                }

                if (latestUploadDate == null)
                {
                    MessageBox.Show("No uploaded facility files found.");
                    return;
                }
                string getPhotos = "SELECT Photos FROM [Facility Photos] WHERE Facility_ID = ? AND [Uploaded Date] = ?";

                using (OleDbCommand cmd = new OleDbCommand(getPhotos, myConn))
                {
                    cmd.Parameters.AddWithValue("?", Facility_ID);
                    cmd.Parameters.AddWithValue("?", latestUploadDate);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                byte[] photoData = (byte[])reader["Photos"];
                                using (MemoryStream ms = new MemoryStream(photoData))
                                {
                                    PictureBox pic = new PictureBox();
                                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                                    pic.Image = Image.FromStream(ms);
                                    pic.Width = 200;
                                    pic.Height = 200;
                                    pic.Margin = new Padding(10);
                                    pic.Cursor = Cursors.Hand;

                                    PhotosFlowLayoutPanel.Controls.Add(pic);
                                }
                            }
                        }
                    }
                }
                VFilespanel.SendToBack();
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Reason.Visible = false;
            if (File1 == false ||  File2 == false || File3 == false || File4 == false || File5 == false || File6 == false || File7 == false)
            {
                if (Reasontext.Text.Length == 0)
                {
                    Reason.Visible = true;
                    return;
                }
                else
                {
                    using (OleDbConnection myConn = new OleDbConnection(connection))
                    {
                        myConn.Open();

                        string sql = "UPDATE [Service Facilities] SET [Approval Status] = ? WHERE [Facility_ID] = ?";

                        using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                        {
                            cmd.Parameters.AddWithValue("?", "Rejected");
                            cmd.Parameters.AddWithValue("?", Facility_ID);

                            cmd.ExecuteNonQuery();
                        }
                        string admin = "UPDATE [Admin (Service Facilities)] SET [Approval Status] = ? WHERE [Facility_ID] = ?";

                        using (OleDbCommand cmd = new OleDbCommand(admin, myConn))
                        {
                            cmd.Parameters.AddWithValue("?", "Rejected");
                            cmd.Parameters.AddWithValue("?", Facility_ID);

                            cmd.ExecuteNonQuery();
                        }
                        string files = "UPDATE [Facility Files] SET [Note] = ? WHERE [Facility_ID] = ?";

                        using (OleDbCommand cmd = new OleDbCommand(files, myConn))
                        {
                            cmd.Parameters.AddWithValue("?", Reasontext.Text);
                            cmd.Parameters.AddWithValue("?", Facility_ID);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Facility files rejected!");
                    return;
                }
            }

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "UPDATE [Service Facilities] SET [Approval Status] = ? WHERE [Facility_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                {
                    cmd.Parameters.AddWithValue("?", "Approved");
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    cmd.ExecuteNonQuery();
                }
                string admin = "UPDATE [Admin (Service Facilities)] SET [Approval Status] = ? WHERE [Facility_ID] = ?";

                using (OleDbCommand cmd = new OleDbCommand(admin, myConn))
                {
                    cmd.Parameters.AddWithValue("?", "Approved");
                    cmd.Parameters.AddWithValue("?", Facility_ID);

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Facility files approved successfully!");
        }
    }
}
