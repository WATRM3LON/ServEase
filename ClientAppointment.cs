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
        public event EventHandler ServiceClicked;
        public ClientAppointment()
        {
            InitializeComponent();
            SOService.Click += (s, e) => this.OnClick(e);
            SOPrice.Click += (s, e) => this.OnClick(e);
            SODuration.Click += (s, e) => this.OnClick(e);
        }

        public void SetData(int serviceId, string name, decimal price, string duration)
        {
            SOService.Text = "  " + name; SOService.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOService.Width, SOService.Height, 10, 10));
            SOPrice.Text = Convert.ToString(price); SOPrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SOPrice.Width, SOPrice.Height, 10, 10));
            SODuration.Text = duration; SODuration.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SODuration.Width, SODuration.Height, 10, 10));
            ServiceName = name; Price = price; DurationMinutes = int.TryParse(duration.Replace(" mins", "").Trim(), out int d) ? d : 0; ServiceId = serviceId;
        }
        public bool IsSelected { get; private set; } = false;
        public int ServiceId { get; private set; }
        public string ServiceName { get; private set; }
        public decimal Price { get; private set; }
        public int DurationMinutes { get; private set; }


        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ToggleSelection();
        }

        private void ToggleSelection()
        {
            IsSelected = !IsSelected;
            SOService.BackColor = SOPrice.BackColor = SODuration.BackColor = IsSelected ? Color.FromArgb(105, 227, 49) : Color.White;

            ServiceClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
