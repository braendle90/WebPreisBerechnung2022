namespace WebPreisBerechnungAuB.Services
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.Elfie.Serialization;
    using System;
    using WebPreisBerechnungAuB.Models;

    public class ProductService
    {
        public List<Product> ImportProductsFromCsv(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvHelper.CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";", // Adjust if your CSV uses a different delimiter
                    MissingFieldFound = null, // Adjust this to handle missing fields
                    
                }))
                {
                    var records = csv.GetRecords<Product>();
                    return new List<Product>(records);
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw;
            }
        }
    }

}
