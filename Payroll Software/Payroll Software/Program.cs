using System;

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
        public float TotalPay { get, protected set; }
        public float BasicPay { get,private set; }
        public string NameOfStaff { get; private set; }

        public float HoursWOrked
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

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nhourlyRate = " + hourlyRate + "\nhWorked = " + hWorked
                + "\nBasicPay = " + BasicPay + "\n\nTotalPay = " + TotalPay;

        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }
    }
