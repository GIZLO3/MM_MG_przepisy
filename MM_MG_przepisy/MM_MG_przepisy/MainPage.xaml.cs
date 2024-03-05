﻿using MM_MG_przepisy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MM_MG_przepisy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RecipeItemTapped(object sender, ItemTappedEventArgs e)
        {
            var recipe = e.Item as Recipe;

            if (recipe != null)
            {
                Navigation.PushAsync(new RecipeDetails(recipe));
            }
        }

        private void GoToAddRecipePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRecipePage());
        }
    }
}
