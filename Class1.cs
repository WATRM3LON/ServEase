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
        public abstract void Loaders();
        public abstract bool EmailChecker(string email, string connection);
        public abstract bool CNumberChecker(string Cnumber, string connection);
        
    }
}
