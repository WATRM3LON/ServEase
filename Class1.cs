using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public interface Info
    {
        string FName { get; set; }
        string LName { get; set; }
        DateTime Birthdate { get; set; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        string ContactNumber { get; set; }
        string LocationAddress { get; set; }
    }
}
