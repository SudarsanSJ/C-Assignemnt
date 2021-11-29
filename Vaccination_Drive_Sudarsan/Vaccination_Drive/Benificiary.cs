using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This Benificary class help to store Details of the Benificier.
/// </summary>

namespace Vaccination_Drive
{
    class Benificiary
    {
        public Vaccine obj = new Vaccine();

        private static int id = 1001;

        public List<object> VaccinationDetail = new List<object>();
        public int RegNo;

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }

        public long PhoneNo { get; set; }
        
        public string Type { get; set; }
        //This Constructor is for the assigned Benificier by our own.
        public Benificiary(string name, int age, string city, string gender, int dosage, long phno,string type)
        {
            Name = name;
            Age = age;
            City = city;
            PhoneNo = phno;
            Gender = gender;
            RegNo = id;
            obj.Dosage = dosage;
            Type = type;
            id++;
        }
        //This Constructor is for the User input Benificier.
        public Benificiary(int reg,string name,int age,string city,string gender,int dose,long phno,string type,DateTime date)
        {
            Name = name;
            Age = age;
            City = city;
            PhoneNo = phno;
            Gender = gender;
            RegNo = reg;
            obj.Dosage = dose;
            Type = type;
            obj.VaccinatedDate = date;
        }
        //This method is used for Storing Benificial Details.
        public void Vaccination(int reg, string name, int age, string city, string  gender, int dose, long phno, string type)
        {
            DateTime d = DateTime.Today;
            var data = new Benificiary(reg, name, age, city, gender, dose, phno, type,d);
            VaccinationDetail.Add(data);
        }
        //This method is used to Show the Next Due Day For the Benificier.
        public void NextDueDate(int reg, string name,DateTime date,int dose)
        {
            Console.WriteLine("The Name of the Benifier is {0}", name);
            Console.WriteLine("Your ID is {0}", reg);
            if (dose<=1)
            {
                Console.WriteLine("Your Next Due Date is {0}", date.AddDays(30).ToString("d"));
            }
            else
            {
                Console.WriteLine("You have completed the vaccination course");
                Console.WriteLine("Thanks for your participation in the vaccination drive");
            }


        }
    }
}
