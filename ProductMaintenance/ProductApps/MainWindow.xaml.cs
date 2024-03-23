using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Calculate total payment
                if (double.TryParse(priceTextBox.Text, out double price) &&
                    int.TryParse(quantityTextBox.Text, out int quantity))
                {
                    double totalPayment = price * quantity;
                    totalPaymentTextBlock.Text = totalPayment.ToString();
                    // Adding delivery charge
                    double totalPaymentWithCharge = totalPayment + 25;
                    totalChargeTextBox.Text = totalPaymentWithCharge.ToString();

                    double totalPaymentWithWrapCharge = totalPaymentWithCharge + 5;
                    totalWrapTextBox.Text = totalPaymentWithWrapCharge.ToString();
                }
                else
                {
                    MessageBox.Show("Please enter valid price and quantity.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear all textboxes
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBox.Text = "";
            totalWrapTextBox.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}
