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
    }
}