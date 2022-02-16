
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

            // Json files

            using (StreamReader file = File.OpenText("participants.json")) {
                JsonSerializer serializer = new JsonSerializer();
                peopleJson = (List<Data>)serializer.Deserialize(file, typeof(List<Data>));
            }
            foreach (Data i in peopleJson) {
                i.from = "json";
            }

            // Xml files

            XmlSerializer formatter = new XmlSerializer(typeof(List<Participant>));
            using (StreamReader fs = File.OpenText("participants.xml")) {
                peopleXml = (List<Participant>)formatter.Deserialize(fs);
            }
            foreach (Participant i in peopleXml) {
                i.from = "Xml";
                peopleJson.Add(new Data(i.Name, i.Surname, i.RegisterDate, i.from));
            }
         
            // csv files

            using (StreamReader fs = File.OpenText("participants.csv")) {

                string line;

                while ((line = fs.ReadLine()) != null) {
                    string[] subs = line.Split(',');
                    peopleCsv.Add( new Data(subs[0], subs[1], DateTime.Parse(subs[2]), "csv") ); 
                }
            }

            peopleJson.AddRange(peopleCsv);

            return peopleJson;

        }
    }
}
