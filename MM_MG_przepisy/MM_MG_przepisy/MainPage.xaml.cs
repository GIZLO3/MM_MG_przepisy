﻿using MM_MG_przepisy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MM_MG_przepisy
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void RecipeItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
