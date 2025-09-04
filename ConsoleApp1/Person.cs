namespace EmployeeManagement
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name.Trim();
            Age = age > 0 ? age : 18;
        }

        public virtual void ShowInfo()
        {
            System.Console.WriteLine($"[Person] Name: {Name}, Age: {Age}");
        }
    }
}
