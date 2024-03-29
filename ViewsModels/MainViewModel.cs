using AppCrud.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.Json;



using System.Windows.Input;

namespace AppCrud.ViewsModels
{
    public partial class MainViewModel : ObservableObject
    {
        HttpClient httpClient;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "http://localhost:5282";

        [ObservableProperty]
        public int _productId;
        [ObservableProperty]
        public string _productName;
        [ObservableProperty]
        public double _productPrice;
        [ObservableProperty]
        public Product _product;
        [ObservableProperty]
        public ObservableCollection<Product> _products;

        public MainViewModel()
        {
            httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Products = new ObservableCollection<Product>();
        }

        public ICommand GetAllProduct => new Command(async () => await LoadProductAsync());

        private async Task LoadProductAsync()
        {
            var url = $"{baseUrl}/ProductController";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ObservableCollection<Product>>(responseStream);
                    Products = data;
                }
            }
        }
    }
}
