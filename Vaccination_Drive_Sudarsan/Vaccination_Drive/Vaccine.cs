using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Drive
{
    /// <summary>
    /// This Vaccine class help to store Dose and Date of the Benificier.
    /// </summary>
    public enum VaccineType
    {
        Covishield=1,Covaccine=2
    }
    class Vaccine
    {
        
        public DateTime VaccinatedDate { get; set; }
        public int Dosage { get; set; }

    }
}
