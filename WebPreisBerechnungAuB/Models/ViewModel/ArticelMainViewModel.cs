using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class ArticelMainViewModel
    {


        public ArticelMainViewModel() { }
        public ArticelMainViewModel(string name, string brand, string articelNumber)
        {

            Name = name;
            Brand = brand;
            ArticelNumber = articelNumber;

        }

        public int Id { get; set; }

        public List<File> file { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public List<string> BrandListUnique { get; set; }

        public string ArticelNumber { get; set; }
    }



}
