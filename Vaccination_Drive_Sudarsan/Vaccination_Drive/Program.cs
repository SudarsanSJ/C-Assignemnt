using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Drive
{
    class Program
    {
        //Enum Declaration
        public enum Gender
        {
            MALE = 1, FEMALE = 2, OTHERS = 3
        }
        static List<Benificiary> Benificiaries = new List<Benificiary>();
        static void Main(string[] args)
        {
            Program p = new Program();
            var data1 = new Benificiary("Sudarsan", 24, "Erode", "MALE", 1, 7558183970,"CoviShield");
            var data2 = new Benificiary("SreeRam", 23, "Salem", "MALE", 2, 9080805854,"Covaccine");
            Benificiaries.Add(data1);
            Benificiaries.Add(data2);
            int MainChoice;
            string choice;
            // this do While allow the user to pick the option to Perform.
            do
            {
                Console.WriteLine("Welcome for the Vaccination Drive");
                Console.WriteLine("Press \n1.Beneficiery Registration \n2.Vaccination \n3.Exit ");
                MainChoice = int.Parse(Console.ReadLine());
                switch (MainChoice)
                {
                    case 1:
                        p.BenificiaryRegistration();
                        break;
                    case 2:
                        p.Vaccination();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Enter the Valid Input...");
                        break;

                }
                Console.WriteLine("Do you want go to main menu- Yes / No?");
                choice = Console.ReadLine().ToLower();

            } while (choice == "yes");

        }
        //This method is for New Benificier Registeration.
        public void BenificiaryRegistration()
        {
            string name, city, gender;
            int age, x, temp;
            long mobileno;
            Console.WriteLine("Enter your Name ");
            name = Console.ReadLine();
            Console.WriteLine("Enter your Age");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your City ");
            city = Console.ReadLine();
            Console.WriteLine("Enter Your PhoneNumber ");
            mobileno = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Gender \n1.Male \n2.Female \n3.Others");
            x = int.Parse(Console.ReadLine());
            //Using enum to Identify the gender.
            switch (x)
            {
                case 1:
                    gender = Gender.MALE.ToString();
                    var data = new Benificiary(name, age, city, gender, 0, mobileno,"");
                    Benificiaries.Add(data);
                    break;
                case 2:
                    gender = Gender.FEMALE.ToString();
                    var data1 = new Benificiary(name, age, city, gender, 0, mobileno,"");
                    Benificiaries.Add(data1);
                    break;
                case 3:
                    gender = Gender.FEMALE.ToString();
                    var data2 = new Benificiary(name, age, city, gender, 0, mobileno,"");
                    Benificiaries.Add(data2);
                    break;
                default:
                    Console.WriteLine("Enter The Valid Option");
                    break;
            }
            //It Display the Registration number For the benificial using mobileno because it will be unique.
            foreach (var benficier in Benificiaries)
            {
                if (benficier.PhoneNo == mobileno)
                {
                    temp = benficier.RegNo;
                    Console.WriteLine($"Hi {benficier.Name}, you are successfully Registered");
                    Console.WriteLine($"Please Note your Registration Number is : {temp}  ");
                }
            }
        }
        //This method takes the user to the vaccination process;
        public void Vaccination()
        {
            string type;
            int RegId, Choice,i=0;
            Console.WriteLine("Enter the Registration ID:");
            RegId = int.Parse(Console.ReadLine());
            foreach (var ben in Benificiaries)
            {
                if (ben.RegNo == RegId)
                {
                    i++;
                    //Here we allow the user to Select a Option to perform.
                    //such as To apply Vaccination,
                    //To Show Vaccination History of the specific Beneficier,
                    //And to shoe the Next due date for the Benificier.
                    Console.WriteLine($"Welcome {ben.Name}");
                    Console.WriteLine("Enter Your Choice: \n1.Take Vaccination \n2.Vaccination History \n3.Next due Date \n4.Exit");
                    Choice = int.Parse(Console.ReadLine());
                    switch (Choice)
                    {//case 1 is to apply a specific vaccination.
                        case 1:
                            Console.WriteLine("Enter your Choice of Vaccine\n1.Covishield \n2.Covaxin");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    if (ben.obj.Dosage < 2)
                                    { 
                                        type = VaccineType.Covishield.ToString();
                                        ben.obj.Dosage++;
                                        ben.Vaccination(ben.RegNo, ben.Name, ben.Age, ben.City, ben.Gender, ben.obj.Dosage, ben.PhoneNo, type);
                                    }
                                    else if (ben.obj.Dosage >= 2)
                                    {
                                        Console.WriteLine("You have completed the vaccination course");
                                        Console.WriteLine("Thanks for your participation in the vaccination drive");
                                    }
                                    break;
                                case 2:
                                    if (ben.obj.Dosage < 2)
                                    {
                                        type = VaccineType.Covaccine.ToString();
                                        ben.obj.Dosage++;
                                        ben.Vaccination(ben.RegNo, ben.Name, ben.Age, ben.City, ben.Gender, ben.obj.Dosage,ben.PhoneNo, type);
                                    }
                                    else if (ben.obj.Dosage >= 2)
                                    {
                                        Console.WriteLine("You have completed the vaccination course");
                                        Console.WriteLine("Thanks for your participation in the vaccination drive");
                                    }
                                    break;
                            }
                            break;
                    //case 2 is to display the Benificier History.
                        case 2:
                            Console.WriteLine("Name of the Benificier is : {0}", ben.Name);
                            Console.WriteLine("Gender of the Benificier is : {0}", ben.Gender);
                            Console.WriteLine("Age of the Benificier is : {0}", ben.Age);
                            Console.WriteLine("Dosage of the Benificier is : {0}", ben.obj.Dosage);
                            Console.WriteLine("Type of Vaccine of the Benificier is : {0}",ben.Type );
                            Console.WriteLine("Vaccine Issued Date is :{0}", ben.obj.VaccinatedDate);
                             break;
                    //case 3 take us to the method which displays the Next Due Day of the Benificier.
                        case 3:
                            ben.NextDueDate(ben.RegNo, ben.Name,ben.obj.VaccinatedDate, ben.obj.Dosage);
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("You have entered wrong Choice");
                            break;

                    }


                }
                if(i==0)
                {
                    Console.WriteLine("Such Registration ID is not found");
                }
            }

        }
    }
}
