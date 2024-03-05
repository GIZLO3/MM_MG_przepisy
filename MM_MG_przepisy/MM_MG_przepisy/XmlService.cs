using MM_MG_przepisy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MM_MG_przepisy
{
    public class XmlService
    {
        private static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "recipes2.xml");
        private static XmlSerializer XmlSerializer = new XmlSerializer(typeof(ObservableCollection<Recipe>));

        public static void SaveRecipes(ObservableCollection<Recipe> recipes)
        {
            var sw = new StreamWriter(path);
            XmlSerializer.Serialize(sw, recipes);
            sw.Close();
        }

        public static ObservableCollection<Recipe> GetRecipes()
        {
            var recpies = new ObservableCollection<Recipe>();

            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                recpies = (ObservableCollection<Recipe>)XmlSerializer.Deserialize(sr);
                sr.Close();

                foreach (var recipe in recpies)
                {
                    recipe.Image = new Uri(recipe.ImageSource);
                }
            }

            return recpies;
        }
    }
}
