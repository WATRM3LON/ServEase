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
    
    public partial class Form1 : Form
    {
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet ds;

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
        public Form1()
        {
            InitializeComponent();
            Size clientSize = this.ClientSize;
            int width = clientSize.Width;
            int height = clientSize.Height;
        }

        public void Loaders()
        {
            ContinueButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ContinueButton.Width, ContinueButton.Height, 30, 30));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Loaders();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#69e331");
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientLogin clientLogin = new ClientLogin();
            clientLogin.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientLogin clientLogin = new ClientLogin();
            clientLogin.ShowDialog();
        }

    }
}
