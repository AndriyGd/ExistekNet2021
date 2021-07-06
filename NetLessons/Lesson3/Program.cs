using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            RunLesson4_3();

            Console.ReadKey();
        }

        public static void RunLesson4_3()
        {
            
            try
            {
                Console.Write("Print A: ");

                string a = Console.ReadLine();

                int input = int.Parse(a);

                //var f = input / 0;
                //Console.WriteLine(f);
                //int input = int.Parse(null);

                var h = new Human
                {
                    Name = "Petro"
                };

                h.Birthday = new DateTime(1900, 4, 27);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Не вірний формат даних!");
                Console.WriteLine();
                Console.WriteLine(e);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Пусте значеня не можна перетворити в число!");
                Console.WriteLine();
                Console.WriteLine(e);
            }
            catch(HumanException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void RunLesson4_2()
        {
            Animal animal = new Dog();
            Pitbull pitbull = new Pitbull();
            Cat cat = new Cat();
            Animal h = new Huskies();

            Print(animal);
            Print(pitbull);
            Print(cat);
            Print(h);

            Console.WriteLine();

            animal = pitbull;
            Print(animal);
        }

        public static void RunLesson4()
        {
            Employee h = new Employee
            {
                Name = "Ihor",
                LastName = "Lomn",
                Birthday = new DateTime(1993, 5, 21),
                //Sound = "Lenguage",
                CardId = 5555
            };

            Console.WriteLine(h);

            var age = h.GetAge();
            Console.WriteLine(age);

            Human tom = new Employee
            {
                Name = "Tom",
                LastName = "Fort",
                CardId = 5666,
                Birthday = new DateTime(1990, 5, 20)
            };

            var age2 = tom.GetAge();
            Console.WriteLine(age2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Manager m = new Manager("Mmfg", "Golt", new DateTime(1990, 4, 26), 10456);

            Print(h);
            Print(tom);
            Print(m);

            Console.ReadKey();
        }

        public static void RunLesson3()
        {
            Employee employee = new Employee();
            employee.Name = "Tom";
            employee.LastName = "Fort";
            employee.CardId = 5666;
            employee.Birthday = new DateTime(1990, 5, 20);
            //Console.WriteLine(employee);

            //Console.WriteLine(employee.Name);
            //Console.WriteLine(employee.GetAge());

            Employee employee1 = new Employee
            {
                Name = "John",
                LastName = "Nort",
                Birthday = new DateTime(1992, 10, 24),
                CardId = 8934
            };

            //Console.WriteLine(employee1);

            Manager m = new Manager("Mmfg", "Golt", new DateTime(1990, 4, 26), 10456);

            Console.WriteLine(m.Salary);

            var top = new TopManager();
            Console.WriteLine(top.Employees.Count);


            var lst = new List<Employee> { employee };
            lst.Add(employee1);

            Console.WriteLine();
            var top2 = new TopManager("John", "Gold", new DateTime(), 25678, lst);
            top2.PrintInfo();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Human h = new Employee
            {
                Name = "Ihor",
                LastName = "Lomn",
                Birthday = new DateTime(1993, 5, 21),
                //Sound = "Lenguage",
                CardId = 5555
            };

            Console.WriteLine(h.Name);

            Employee ihor = (Employee)h;
            Console.WriteLine(ihor.CardId);

            Console.WriteLine();

            var ihor2 = h as Employee;
            ihor2.CardId = 7777;
            h.Name = "Petro";
            Console.WriteLine(ihor2.CardId);
            Console.WriteLine(ihor.CardId);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(h.Name);
            Console.WriteLine(ihor2.Name);
            Console.WriteLine(ihor.Name);

            Print(h);
            Print(ihor2);
            Print(m);

            Human hm = m;

            Console.WriteLine(hm.Name);

            Console.ReadKey();
        }

        public static void Print(Human human)
        {
            Console.WriteLine(human.Name);
            Console.WriteLine(human.LastName);
            Console.WriteLine(human.Birthday);

            if(human is Employee employee)
            {
                Console.WriteLine($"CardId: {employee.CardId}");
            }

            if(human is Manager manager)
            {
                Console.WriteLine($"Salary: {manager.Salary}");
            }

            human.PrintMessage();

            Console.WriteLine($"GetAge: {human.GetAge()}");
        }

        public static void Print(Animal animal)
        {
            Console.WriteLine(animal.Sound());
        }
    }
}
