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
        private List<List<Entry>> ingredientEntriesList = new List<List<Entry>>();
        private List<Entry> stepsEntriesList = new List<Entry>();
        public AddRecipePage()
        {
            InitializeComponent();
            AddIngredientEntry();
        }

        private void AddIngredientEntry()
        {
            var entryList = new List<Entry>();
            Ingredients.RowDefinitions.Add(new RowDefinition());

            for(int i=0; i<3; i++)
            {
                var entry = new Entry();
                Grid.SetRow(entry, ingredientEntriesList.Count());
                Grid.SetColumn(entry, i);

                entryList.Add(entry);
                Ingredients.Children.Add(entry);
            }

            entryList[0].Placeholder = "Składnik";
            entryList[1].Placeholder = "Ilość";
            entryList[1].Keyboard = Keyboard.Numeric;
            entryList[2].Placeholder = "Jednostka";

            ingredientEntriesList.Add(entryList);
        }

        private void AddIngredientEntry(object sender, EventArgs e)
        {
            AddIngredientEntry();
        }

        private void AddStepsEntry()
        {
            Steps.RowDefinitions.Add(new RowDefinition());

            var label = new Label();
            label.Text = (stepsEntriesList.Count() + 1).ToString();
            Grid.SetRow(label, stepsEntriesList.Count());
            Grid.SetColumn(label, 0);
            Steps.Children.Add(label);

            var entry = new Entry();
            Grid.SetRow(entry, stepsEntriesList.Count());
            Grid.SetColumn(entry, 1);
            entry.Placeholder = "Krok";
            Steps.Children.Add(entry);

            stepsEntriesList.Add(entry);
        }
    }
}