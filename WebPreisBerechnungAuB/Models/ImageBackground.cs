﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class ImageBackground
    {


        public int Id { get; set; }

        public string RemoveColorRGB { get; set; }

        [DisplayName("Datei Name")]
        public string Name { get; set; }
        public string FilePath { get; set; }

        [NotMapped]
        public string ImageBase64 { get; set; }


        [NotMapped]
        [DisplayName("Datei hochladen")]
        public IFormFile FileData { get; set; } 
    }
}