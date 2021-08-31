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
        public float TotalPay { 
            get 
            {
                return TotalPay;
            }
            protected set 
            {
                TotalPay = value;
            } 
        }
        public float BasicPay
        {
            get
            {
                return BasicPay;
            }
            private set 
            {
                BasicPay = value;
            }
        }
        public string NameOfStaff { get; set; }
        public float HoursWOrked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (HoursWOrked > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }
}
