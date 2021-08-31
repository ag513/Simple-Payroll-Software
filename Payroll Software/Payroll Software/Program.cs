using System;
using System.Collections.Generic;
using System.IO;

namespace Payroll_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Staff
    {
        private float hourlyRate;
        private int hWorked;

        // Auto implemented properties
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nhourlyRate = " + hourlyRate + "\nhWorked = " + hWorked
                + "\nBasicPay = " + BasicPay + "\n\nTotalPay = " + TotalPay;

        }
    }

    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 0;

            if (HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate = "
              + managerHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = "
              + BasicPay + "\nAllowance = " + Allowance + "\n\nTotalPay = " + TotalPay;

        }
    }

    class Admin : Staff
    {
        private const float overtimeRate = 15.5;
        private const float adminHourlyRate = 30;
        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay = BasicPay + Overtime;
            }
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                 + "\nadminHourlyRate = " + adminHourlyRate + "\nHoursWorked = " + HoursWorked
                 + "\nBasicPay = " + BasicPay + "\nOvertime = " + Overtime
                 + "\n\nTotalPay = " + TotalPay;

        }
    }

    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else if (result[1] == "Admin")
                            myStaff.Add(new Admin(result[0]));
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("Error: File does not exist");
            }

            return myStaff;
        }

    }
}
