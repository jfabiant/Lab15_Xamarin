using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

using Lab15_Xamarin.models;
using Lab15_Xamarin.views;

using Newtonsoft.Json;

namespace Lab15_Xamarin.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private async void btnAddProduct(object sender, EventArgs e)
        {

            // Encapsuling new product
            ProductModel product = new ProductModel();
            product.Nombre = "Producto Test";
            product.Descripcion = "Descripcion Test";
            product.Precio = "30";

            HttpClient client = new HttpClient();
            string url = "http://ec2-18-219-74-140.us-east-2.compute.amazonaws.com:5005/products/create";

            string jsonProduct = JsonConvert.SerializeObject(product);


            var results = await client.PostAsync(url, new StringContent(jsonProduct));

            var json = results.Content.ReadAsStringAsync().Result;

            System.Diagnostics.Debug.WriteLine("######## RESULTS ########");
            System.Diagnostics.Debug.WriteLine(results);

            await DisplayAlert("Informacion", json, "Ok");
            
        }
    }
}