using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    class Data
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime registrationDate { get; set; }
        public string from { get; set; }

        public Data (string firstname, string lastname, DateTime registrationDate, string from) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.registrationDate = registrationDate;
            this.from = from;
        }

        public Data () {

        }
       
    }

    [XmlRoot("Participant")]
    public class Participant
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime RegisterDate { get; set; }
        public string from { get; set; }

        public Participant (string firstname, string lastname, DateTime registrationDate, string from) {
            this.Name = firstname;
            this.Surname = lastname;
            this.RegisterDate = registrationDate;
            this.from = from;
        }
        public Participant () {

        }
    }
}
