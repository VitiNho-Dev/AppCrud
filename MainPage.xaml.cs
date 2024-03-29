using AppCrud.ViewsModels;

namespace AppCrud
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }  
    }
}