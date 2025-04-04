using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public interface ClientInfo
    {
        string FName { get; set; }
        string LName { get; set; }
        DateTime Birthdate { get; set; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        string ContactNumber { get; set; }
        string LocationAddress { get; set; }
        int count {  get; set; }
    }

    public interface FacilityInfo
    {
        string Facname { get; set; }
        string SerCat {  get; set; }
        DateTime WorHours { get; set; }
        string WorDays { get; set; }
        string Ratings { get; set; }   
        string AppStatus { get; set; }

    }
    public abstract class Baseform
    {
        public abstract void Loaders();
        public abstract void InfoGetter();
        public abstract void UpdateInfo();
        public abstract bool CNumberChecker();
    }
}
