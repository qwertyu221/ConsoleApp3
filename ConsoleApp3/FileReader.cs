using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace ConsoleApp3
{
    class FileReader
    {
        public static void Read () {

            List<Data> peopleJson = new List<Data>();
            List<Participant> peopleXml = new List<Participant>();
            

            using (StreamReader file = File.OpenText("participants.json")) {
                JsonSerializer serializer = new JsonSerializer();
                peopleJson = (List<Data>)serializer.Deserialize(file, typeof(List<Data>));
            }
            foreach (Data i in peopleJson) {
                i.from = "json";
            }
            foreach (Data i in peopleJson) {

                Console.WriteLine(i.firstname);
                Console.WriteLine(i.lastname);
                Console.WriteLine(i.registrationDate);
                Console.WriteLine(i.from);
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<Participant>));

            using (StreamReader fs = File.OpenText("participants.xml")) {

                peopleXml = (List<Participant>)formatter.Deserialize(fs);
            }




            foreach (Participant i in peopleXml) {
                i.from = "Xml";
            }
            foreach (Participant i in peopleXml) {

                Console.WriteLine(i.Name);
                Console.WriteLine(i.Surname);
                Console.WriteLine(i.RegisterDate);
                Console.WriteLine(i.from);
            }



        }
    }
}
