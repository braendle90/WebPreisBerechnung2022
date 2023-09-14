using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models
{
    public class ArticelMain
    {

        public ArticelMain() { }
        public ArticelMain(string name, string brand, string articelNumber) 
        {

            Name = name;
            Brand = brand;
            ArticelNumber = articelNumber;

        }

        public int Id { get; set; }

        public List<File> file { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }   

        public string ArticelNumber { get; set; }   
    }
}
