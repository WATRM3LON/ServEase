using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public partial class Rating : UserControl
    {
        private int rating = 0;
        private readonly int starCount = 5;
        private readonly Rectangle[] starRects;

        public Rating()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            starRects = new Rectangle[starCount];

            this.Resize += (s, e) => this.Invalidate();
        }

        public void CLientApp(string Name, string FLocation)
        {
            UserRegistlabel.Text = "Appointment Date: ";
            UserNamelabel.Text = "Facility Name:";
            UserNametext.Text = Name;
        }
        public void ClientInfo(string Status, string Regist)
        {
            UserRegisttext.Text = Regist;
        }
        public void FacilityApp(string Name, string FLocation)
        {
            UserRegistlabel.Text = "Appointment Date: ";
            UserNamelabel.Text = "Client Name:";
            UserNametext.Text = Name;
        }
    }
}
