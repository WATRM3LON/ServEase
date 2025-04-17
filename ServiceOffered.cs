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
    public partial class ServiceOffered : UserControl
    {
        public ServiceOffered()
        {
            InitializeComponent();
        }

        public void SetData(string Servicename, string Descritpion, decimal Price, string Duration)
        {
            ServiceName.Text = Servicename;
            ServiceDes.Text = Descritpion;
            ServicePrice.Text = Convert.ToString(Price);
            Serviceduration.Text = Duration;
        }
    }
}
