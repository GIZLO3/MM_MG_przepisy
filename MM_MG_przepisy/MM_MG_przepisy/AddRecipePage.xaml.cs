using MM_MG_przepisy.Models;
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
            label.FontSize = 16;
            label.VerticalOptions = LayoutOptions.Center;
            Steps.Children.Add(label);

            var entry = new Entry();
            Grid.SetRow(entry, stepsEntriesList.Count());
            Grid.SetColumn(entry, 1);
            entry.Placeholder = "Krok";
            Steps.Children.Add(entry);

            stepsEntriesList.Add(entry);
        }

        private void AddStepsEntry(object sender, EventArgs e)
        {
            AddStepsEntry();
        }

        private void AddRecipe(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(RecipeImage.Text) && !string.IsNullOrEmpty(RecipeName.Text) && !string.IsNullOrEmpty(CookingTime.Text) && !string.IsNullOrEmpty(RecipeRate.Text))
            {
                var recipe = new Recipe();

                var ingredients = new List<Ingredient>();
                foreach(var entryList in ingredientEntriesList)
                {
                    if (!string.IsNullOrEmpty(entryList[0].Text) && !string.IsNullOrEmpty(entryList[0].Text) && !string.IsNullOrEmpty(entryList[0].Text))
                    {
                        var ingredient = new Ingredient();
                        ingredient.Name = entryList[0].Text;
                        ingredient.Amount = int.Parse(entryList[1].Text);
                        ingredient.Unit = entryList[2].Text;

                        ingredients.Add(ingredient);
                    }
                }

                var steps = new List<string>();
                foreach(var step in stepsEntriesList)
                {
                    if (!string.IsNullOrEmpty(step.Text))
                    {
                        steps.Add(step.Text);
                    }
                }

                recipe.Ingredients = ingredients;
                recipe.Steps = steps;

                recipe.ImageSource = "https://cdn.galleries.smcloud.net/t/galleries/gf-hHjs-dYzQ-DWsb_soczysta-pieczen-wieprzowa-664x442-nocrop.jpg";
                recipe.Name = RecipeName.Text;
                recipe.CookingTime = CookingTime.Text;
                recipe.Rate = int.Parse(RecipeRate.Text);

                MainPage.recipes.Add(recipe);
                XmlService.SaveRecipes(MainPage.recipes);

                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Błąd", "Wypełnij pola", "OK");
            }
        }
    }
}