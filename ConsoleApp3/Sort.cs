using MoreLinq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    class Sort
    {
        public static List<Data> Sorted(List<Data> people) {

            List<Data> peopleNames = new List<Data>();


            var sortedPeople1 = from p in people
                                orderby p.firstname
                                select p;

            people = sortedPeople1.DistinctBy(m => new { m.firstname, m.lastname }).ToList();

            var sortedPeople = from p in people
                                orderby p.registrationDate
                                select p;

            people = sortedPeople.ToList();

            //foreach (var i in people) {
            //    Console.Write(i.firstname);
            //    Console.Write(i.lastname);
            //    Console.Write(i.registrationDate);
            //    Console.WriteLine(i.from);
            //}
            //Console.WriteLine(people.Count());

            //foreach (var i in sortedPeople1) {
            //    Console.Write(i.firstname);
            //    Console.Write(i.lastname);
            //    Console.Write(i.registrationDate);
            //    Console.WriteLine(i.from);
            //}
            //Console.WriteLine(sortedPeople1.Count());

            return people;
        }
       
    }
}
