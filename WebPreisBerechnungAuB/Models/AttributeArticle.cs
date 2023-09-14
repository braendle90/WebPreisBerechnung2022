using System;
using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models
{
    public class AttributeArticle
    {

        public AttributeArticle(string nameOfAttribute, string text) 
        {

            NameOfAttribute = nameOfAttribute;  
            Text = text;    
        
        }   


        public int Id { get; set; }

        public string NameOfAttribute { get; set; }

        public string Text { get; set; }

        public static implicit operator List<object>(AttributeArticle v)
        {
            throw new NotImplementedException();
        }
    }
}
