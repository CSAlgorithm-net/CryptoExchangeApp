using System.Windows;

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
                var symbol = "BTCUSDT"; // Example for the Bitcoin/USDT pair
                var price = await _apiClient.GetMarketDataAsync(symbol);
                PriceTextBox.Text = price; // Display the price in the TextBox in the new format
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}