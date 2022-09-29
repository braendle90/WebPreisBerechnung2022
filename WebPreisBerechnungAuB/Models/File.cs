using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPreisBerechnungAuB.Models
{
    public class File
    {

        public int Id { get; set; }

        [DisplayName("Datei Name")]

        public string Name { get; set; }
        public string FilePath { get; set; }

        [NotMapped]
        [DisplayName("Datei hochladen")]
        public IFormFile FileData { get; set; }

    }
}
