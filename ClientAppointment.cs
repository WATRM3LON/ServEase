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
    public partial class ClientAppointment : UserControl
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
        public ClientAppointment()
        {
            InitializeComponent();
        }

        public void SetData(string ServiceName, decimal Price, string Duration)
        {
            SOService.Text = "  " + ServiceName; SOService.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOService.Width, SOService.Height, 10, 10));
            SOPrice.Text = Convert.ToString(Price); SOPrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOPrice.Width, SOPrice.Height, 10, 10));
            SODuration.Text = Duration; SODuration.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SODuration.Width, SODuration.Height, 10, 10));
        }
    }
}
