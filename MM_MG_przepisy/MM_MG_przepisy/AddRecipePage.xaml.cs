using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MM_MG_przepisy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipePage : ContentPage
    {
        private List<List<Entry>> IngredientEntriesList = new List<List<Entry>>();
        private List<Entry> StepsEntriesList = new List<Entry>();
        public AddRecipePage()
        {
            InitializeComponent();
        }

        private void AddIngredientEntry()
        {
            var entryList = new List<Entry>();
            Ingredients.RowDefinitions.Add(new RowDefinition());

            for(int i=0; i<3; i++)
            {
                var entry = new Entry();
                Grid.SetRow(entry, IngredientEntriesList.Count());
                Grid.SetColumn(entry, i);

                entryList.Add(entry);
                Ingredients.Children.Add(entry);
            }
        }
    }
}