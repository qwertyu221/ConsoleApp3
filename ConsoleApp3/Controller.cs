using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Controller
    {
        

        public static void Work (List<Data> people) {

            bool flag = true;
            while (flag == true) {

                Console.WriteLine("Меню");
                Console.WriteLine("page, exit, search");

                string? name = Console.ReadLine();

                switch (name) {
                    case "page":
                        Console.WriteLine("Введите номер страницы");
                        int num = int.Parse(Console.ReadLine());
                        Page(num,people);
                        break;

                    case "search":
                        Console.WriteLine("Введите символы для поиска");
                        name = Console.ReadLine();
                        Search(name,people);
                        break;

                    case "exit" or "1":
                        flag = false;
                        break;

                    case "full":
                        foreach (var i in people) {
                            Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-10}", i.firstname, i.lastname, i.registrationDate, i.from);
                        }
                        break;

                    default:
                        Console.WriteLine("none");
                        break;
                }
                
            }

        }

        public static void Page (int number, List<Data> people) {
            people = people.Skip(number*5).Take(5).ToList();

            foreach (var i in people) {
                Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-10}", i.firstname, i.lastname, i.registrationDate, i.from);
            }

        }

        public static void Search (string name, List<Data> people) {

            var selectedPeopleName = from person in people
                                 where (person.firstname.Contains(name))
                                 select person;
            var selectedPeopleSurname = from person in people
                                 where (person.lastname.Contains(name))
                                 select person;

            foreach (var i in selectedPeopleName) {
                Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-10}", i.firstname, i.lastname, i.registrationDate, i.from);
            }
            foreach (var i in selectedPeopleSurname) {
                Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-10}", i.firstname, i.lastname, i.registrationDate, i.from);
            }
        }
    }
}
