# Simple-Payroll-Software

This application consists of six classes.

Staff
Manager : Staff
Admin : Staff
FileReader
PaySlip
Program

The Staff class contains information about each staff in the company. It
also contains a virtual method called CalculatePay() that calculates the
pay of each staff.

The Manager and Admin classes inherit the Staff class and override the
CalculatePay() method.

The FileReader class contains a simple method that reads from a .txt file
and creates a list of Staff objects based on the contents in the .txt file.

The PaySlip class generates the pay slip of each employee in the company.

The Program class contains the Main() method.
