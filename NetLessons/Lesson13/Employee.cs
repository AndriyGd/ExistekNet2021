namespace Lesson13
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public double GetPercent()
        {
            var p = (Salary * 0.25) / 100;
            return p;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nSalary: {Salary}\n";
        }
    }
}
