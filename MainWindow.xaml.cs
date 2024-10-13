using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoExchangeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExchangeApiClient _apiClient;

        public MainWindow()
        {
            InitializeComponent();
            _apiClient = new ExchangeApiClient();
        }

        private async void GetPriceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var symbol = "BTCUSDT";  // Example for Bitcoin to USDT
                var price = await _apiClient.GetMarketDataAsync(symbol);
                PriceTextBox.Text = price;  // Display the price in the TextBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}