using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lab15_Xamarin.models;
using Lab15_Xamarin.views;
using Newtonsoft.Json;

namespace Lab15_Xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            requestWithMethodGet();
        }

        private async void requestWithMethodGet()
        {
            HttpClient client = new HttpClient();
            string url = "http://ec2-18-219-74-140.us-east-2.compute.amazonaws.com:5005/products/list";
            var results = await client.GetAsync(url);
            var json = results.Content.ReadAsStringAsync().Result;
            //ProductModel model = ProductModel.FromJson(json);

            var objects = JsonConvert.DeserializeObject<List<ProductModel>>(json);

            listOfProducts.ItemsSource = objects;

        }

        private async void btnAddNewProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProduct());
        }
    }
}
