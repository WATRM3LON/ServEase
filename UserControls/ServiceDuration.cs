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
    public partial class ServiceDuration : UserControl
    {
        public ServiceDuration()
        {
            InitializeComponent();
        }

        public void SetInfo(string serviceName, string duration)
        {
            ASsertext.Text = serviceName;
            ASdurtext.Text = duration;
        }
        private void ServiceDuration_Load(object sender, EventArgs e)
        {

        }
    }
}
