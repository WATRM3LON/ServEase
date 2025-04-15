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
    public partial class TimeSlots : UserControl
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
        public TimeSlots()
        {
            InitializeComponent();
        }

        public void SetData(string startime, string endtime)
        {
            Startime.Text = startime; Startime.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Startime.Width, Startime.Height, 10, 10));
            Endtime.Text = endtime; Endtime.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Endtime.Width, Endtime.Height, 10, 10));
        }
    }
}
