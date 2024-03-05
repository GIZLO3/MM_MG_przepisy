using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MM_MG_przepisy.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string CookingTime { get; set; }
        public int Rate { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        [XmlIgnore]
        public Uri Image { get; set; }
        public string ImageSource { get; set; }
    }
}
