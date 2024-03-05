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
    public partial class RecipeDetails : ContentPage
    {
        public RecipeDetails(Recipe recipe)
        {
            InitializeComponent();

            Title = recipe.Name;
            RecipeRate.Text = recipe.Rate + " / 5";
            RecipeImage.Source = recipe.Image;
            RecipeCookingTime.Text = recipe.CookingTime;

            IngredientsList.ItemsSource = recipe.Ingredients;
            StepsList.ItemsSource = recipe.Steps;
        }
    }
}