using CsvHelper;
using CsvHelper.Configuration;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace ConsoleApp3
{
    class FileReader
    {
        public static List<Data> Read () {

            List<Data> peopleJson = new List<Data>();
            List<Participant> peopleXml = new List<Participant>();
            List<Data> peopleCsv = new List<Data>();

            using (StreamReader file = File.OpenText("participants.json")) {
                JsonSerializer serializer = new JsonSerializer();
                peopleJson = (List<Data>)serializer.Deserialize(file, typeof(List<Data>));
            }
            
            foreach (Data i in peopleJson) {
                i.from = "json";
            }
            foreach (Data i in peopleJson) {
                Console.Write(i.firstname);
                Console.Write(i.lastname);
                Console.Write(i.registrationDate);
                Console.WriteLine(i.from);
            }

            Console.WriteLine();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Participant>));
            using (StreamReader fs = File.OpenText("participants.xml")) {
                peopleXml = (List<Participant>)formatter.Deserialize(fs);
            }

            foreach (Participant i in peopleXml) {
                i.from = "Xml";
                peopleJson.Add(new Data(i.Name, i.Surname, i.RegisterDate, i.from));
            }
            foreach (Participant i in peopleXml) {
                Console.Write(i.Name);
                Console.Write(i.Surname);
                Console.Write(i.RegisterDate);
                Console.WriteLine(i.from);
            }

            Console.WriteLine();

            using (StreamReader fs = File.OpenText("participants.csv")) {

                string line;

                while ((line = fs.ReadLine()) != null) {
                    string[] subs = line.Split(',');
                    peopleCsv.Add( new Data(subs[0], subs[1], DateTime.Parse(subs[2]), "csv") ); 
                }

                foreach (var i in peopleCsv) {
                    Console.Write(i.firstname);
                    Console.Write(i.lastname);
                    Console.Write(i.registrationDate);
                    Console.WriteLine(i.from);
                }
            }

            Console.WriteLine();

            peopleJson.AddRange(peopleCsv);

            foreach (Data i in peopleJson) {
                Console.Write(i.firstname);
                Console.Write(i.lastname);
                Console.Write(i.registrationDate);
                Console.WriteLine(i.from);
            }

            return peopleJson;

        }
    }
}
