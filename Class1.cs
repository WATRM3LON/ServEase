using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public abstract class BaseForm : Form
    {
        public string EmailAddress { get; set; }
        public abstract void Loaders();
    }
}
