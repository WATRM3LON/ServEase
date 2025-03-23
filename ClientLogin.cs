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
using System.Data.OleDb;
using System.Collections;

namespace OOP2
{
    public partial class ClientLogin : Form
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;

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

        public ClientLogin()
        {
            InitializeComponent();
            Loaders();
        }
        public void Loaders()
        {
            LogInPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogInPanel.Width, LogInPanel.Height, 20, 20));
            LoginButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LoginButton.Width, LoginButton.Height, 10, 10));
            ServiceFacilityButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ServiceFacilityButton.Width, ServiceFacilityButton.Height, 10, 10));
            LogButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogButton.Width, LogButton.Height, 10, 10));
            SignButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SignButton.Width, SignButton.Height, 10, 10));
            SigninPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SigninPanel.Width, SigninPanel.Height, 20, 20));
            FnamePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, FnamePanel.Width, FnamePanel.Height, 10, 10));
            LnamePanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LnamePanel.Width, LnamePanel.Height, 10, 10));
            EmailSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EmailSPanel.Width, EmailSPanel.Height, 10, 10));
            CNumberPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CNumberPanel.Width, CNumberPanel.Height, 10, 10));
            PasswordSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PasswordSPanel.Width, PasswordSPanel.Height, 10, 10));
            ConfirmSPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ConfirmSPanel.Width, ConfirmSPanel.Height, 10, 10));
            EmailAddLPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, EmailAddLPanel.Width, EmailAddLPanel.Height, 10, 10));
            PasswordLPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PasswordLPanel.Width, PasswordLPanel.Height, 10, 10));
            SignInButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SignInButton.Width, SignInButton.Height, 10, 10));
            
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

        private void SignButton_Click(object sender, EventArgs e)
        {
            SigninPanel.Visible = true;
            LogInPanel.Visible = false;
            LogButton.BackColor = ColorTranslator.FromHtml("#69e331");
            LogButton.ForeColor = Color.White;
            SignButton.BackColor = ColorTranslator.FromHtml("#f7fff3");
            SignButton.ForeColor = Color.Black;
            Loaders();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            SigninPanel.Visible = false;
            LogInPanel.Visible = true;
            LogButton.BackColor = ColorTranslator.FromHtml("#f7fff3");
            LogButton.ForeColor = Color.Black;
            SignButton.BackColor = ColorTranslator.FromHtml("#69e331");
            SignButton.ForeColor = Color.White;
            Loaders();
        }

        private void ServiceFacilityButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServiceFacilityLogin serviceFacilityLogin = new ServiceFacilityLogin();
            serviceFacilityLogin.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientDashboard clientDashboard = new ClientDashboard();
            clientDashboard.ShowDialog();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {

            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\OOP2 Database - Copy.accdb");
            ds = new DataSet();
            myConn.Open();
            System.Windows.Forms.MessageBox.Show("Connected successfully!");
            myConn.Close();

            using (OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\OOP2 Database - Copy.accdb"))
            {
                string query = "INSERT INTO Client_Sign_In ([First Name], [Last Name], [Email Address], [Contact Number], [Password]) " +
                               "VALUES (@FName, @LName, @EmailAdd, @CNumber, @Password)";

                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("@FName", FNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@LName", LNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@EmailAdd", EmailSTextBox.Text);
                    cmd.Parameters.AddWithValue("@CNumber", CNumberSTextBox.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordSTextBox.Text);

                    myConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            this.Hide();
            Admin admin = new Admin();
            admin.ShowDialog();
        }
    }
}
