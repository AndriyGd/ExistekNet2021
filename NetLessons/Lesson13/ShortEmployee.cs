namespace Lesson13
{
    public class ShortEmployee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nSalary: {Salary}\n";
        }
    }
}
