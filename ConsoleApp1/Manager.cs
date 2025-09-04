namespace EmployeeManagement
{
    class Manager : Person
    {
        public double Bonus { get; set; }
        public int TeamSize { get; set; }

        public Manager(string name, int age, double bonus, int teamSize)
            : base(name, age)
        {
            Bonus = bonus;
            TeamSize = teamSize;
        }

        public override void ShowInfo()
        {
            System.Console.WriteLine($"[Manager] Name: {Name}, Age: {Age}, Bonus: {Bonus}, Team Size: {TeamSize}");
        }
    }
}
