namespace EmployeeManagement
{
    class Employee : Person
    {
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, int age, double salary, string department)
            : base(name, age)
        {
            Salary = salary;
            Department = string.IsNullOrWhiteSpace(department) ? "General" : department.Trim();
        }

        public override void ShowInfo()
        {
            System.Console.WriteLine($"[Employee] Name: {Name}, Age: {Age}, Salary: {Salary}, Department: {Department}");
        }
    }
}
