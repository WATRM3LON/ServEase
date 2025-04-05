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

namespace OOP2
{
    public partial class Admin : Form
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

        string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\OOP2 Database - Copy.accdb";

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
            Loaders();
        }
        string Fname, Lname;
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
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#e8f5e9");
        }

        private void LoadFacilityData()
        {
            ProfilePanel.Controls.Clear();

            using (OleDbConnection myConn = new OleDbConnection(connection))
            {
                myConn.Open();

                string sql = "SELECT Client_ID, [First Name], [Last Name], [Email Address] FROM [Admin (Clients)] WHERE [Email Address] <> 'admin12345'";

                using (OleDbCommand cmd = new OleDbCommand(sql, myConn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    int margin = 10;

                    while (reader.Read())
                    {
                        int clientId = reader.GetInt32(reader.GetOrdinal("Client_ID"));

                        string fName = reader.IsDBNull(reader.GetOrdinal("First Name")) ? "" : reader.GetString(reader.GetOrdinal("First Name"));
                        string lName = reader.IsDBNull(reader.GetOrdinal("Last Name")) ? "" : reader.GetString(reader.GetOrdinal("Last Name"));
                        string fullName = fName + " " + lName;

                        string email = reader.IsDBNull(reader.GetOrdinal("Email Address")) ? "" : reader.GetString(reader.GetOrdinal("Email Address"));

                        UsersPanel usersPanel = new UsersPanel();
                        usersPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, usersPanel.Width, usersPanel.Height, 10, 10));

                        usersPanel.SetData(fullName, email);
                        usersPanel.Loaders();

                        usersPanel.Location = new Point(10, margin - 7);
                        margin += usersPanel.Height + 10;

                        string adminQuery = "SELECT Status, [Date Registered] FROM [Admin (Clients)] WHERE [Client_ID] = ?";
                        using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, myConn))
                        {
                            adminCmd.Parameters.AddWithValue("?", clientId);

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
}
