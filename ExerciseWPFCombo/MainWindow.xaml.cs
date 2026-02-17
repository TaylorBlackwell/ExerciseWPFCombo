using System.IO;
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

namespace ExerciseWPFCombo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboboxWithText();
        }

        private void CmdHamta_Click(object sender, RoutedEventArgs e)
        {
            string? valdDessert = null;
            if (rbAlternativ1.IsChecked == true)
            {
                valdDessert = rbAlternativ1.Content.ToString();
            }
            else if (rbAlternativ2.IsChecked == true)
            {
                valdDessert = rbAlternativ2.Content.ToString();
            }
            else if (rbAlternativ3.IsChecked == true)
            {
                valdDessert = rbAlternativ3.Content.ToString();
            }
            MessageBox.Show("Du har valt " + valdDessert);
        }

        private void FillComboboxWithText()
        {
            try
            {
                using StreamReader sr = new(@"D:\AAUtbildning\C#\Vecka 8\dessert.txt");
                string? line = sr.ReadLine();
                while (line != null)
                {
                    cmbEfterratt.Items.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void cmbEfterratt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? valdDessert = null; if (cmbEfterratt.SelectedIndex > -1) 
        { 
                valdDessert = cmbEfterratt.SelectedItem.ToString(); 
        }
            txtResultat.Text = "You voted for " + valdDessert;
        }
    }
}