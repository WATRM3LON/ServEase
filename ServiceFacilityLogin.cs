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
    public partial class ServiceFacilityLogin : Form
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

        public ServiceFacilityLogin()
        {
            InitializeComponent();
            Loaders();
        }
        public void Loaders()
        {
            LogInPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogInPanel.Width, LogInPanel.Height, 20, 20));
            LoginButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LoginButton.Width, LoginButton.Height, 10, 10));
            ClientButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ClientButton.Width, ClientButton.Height, 10, 10));
            LogButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, LogButton.Width, LogButton.Height, 10, 10));
            SignButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SignButton.Width, SignButton.Height, 10, 10));
            SigninPanel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SigninPanel.Width, SigninPanel.Height, 20, 20));
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 10, 10));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 10, 10));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 10, 10));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 10, 10));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 10, 10));
            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 10, 10));
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
            CloseButton.BackColor = ColorTranslator.FromHtml("#f0246e");
        }

        private void MaximizeButton_MouseHover(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
        }

        private void MaximizeButton_MouseLeave(object sender, EventArgs e)
        {
            MaximizeButton.BackColor = ColorTranslator.FromHtml("#f0246e");
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
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = ColorTranslator.FromHtml("#f0246e");
        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            SigninPanel.Visible = true;
            LogInPanel.Visible = false;
            LogButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            LogButton.ForeColor = Color.White;
            SignButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
            SignButton.ForeColor = Color.Black;
            Loaders();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            SigninPanel.Visible = false;
            LogInPanel.Visible = true;
            LogButton.BackColor = ColorTranslator.FromHtml("#fef1f5");
            LogButton.ForeColor = Color.Black;
            SignButton.BackColor = ColorTranslator.FromHtml("#f0246e");
            SignButton.ForeColor = Color.White;
            Loaders();
        }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientLogin clientLogin = new ClientLogin();
            clientLogin.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServiceFacilitycs serviceFacilitycs = new ServiceFacilitycs();
            serviceFacilitycs.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignInButton_Click(object sender, EventArgs e)
        {

        }

        private void SignInButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
