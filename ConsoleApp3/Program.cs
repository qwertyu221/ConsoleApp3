using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {

        static void Main (string[] args) {

            //Participant data;

            List <Data> users = FileReader.Read();

            users = Sort.Sorted(users);
            Controller.Work(users);

            
           
        }
    }
}
