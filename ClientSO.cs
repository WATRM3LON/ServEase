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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OOP2
{
    public partial class ClientSO : UserControl
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
        public ClientSO()
        {
            InitializeComponent();
        }

        public void SetData(string ServiceName, string Descritpion, decimal Price, string Duration)
        {
            Servicename.Text = ServiceName; Servicename.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Servicename.Width, Servicename.Height, 10, 10));
            Servicedesc.Text = Descritpion; Servicedesc.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Servicedesc.Width, Servicedesc.Height, 10, 10));
            Serviceprice.Text = Convert.ToString(Price); Serviceprice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Serviceprice.Width, Serviceprice.Height, 10, 10));
            Serviceduration.Text = Duration; Serviceduration.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Serviceduration.Width, Serviceduration.Height, 10, 10));
        }
    }
}
