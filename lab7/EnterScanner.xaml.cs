using System;
using System.Windows;
namespace lab7
{
    public partial class EnterScanner : Window
    {
        public EnterScanner()
        {
            InitializeComponent();
            Number.Maximum = int.MaxValue;
            Number.Minimum = int.MinValue;
            width.Maximum = int.MaxValue;
            height.Maximum = int.MaxValue;
        }

        public string ScannerFirm = "";
        public int ScannerNumber;
        public string ScannerType;
        public Resolution MaxResolution;
        public Scanner ReturnScanner()
        {
            Scanner scanner = new Scanner(ScannerFirm, ScannerType, MaxResolution);
            scanner.Number = ScannerNumber;
            return scanner;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            ScannerFirm = Firm.Text;
            ScannerNumber = Convert.ToInt32(Number.Value);
            ScannerType = Type.Text;
            MaxResolution = new Resolution(Convert.ToInt32(width.Value), Convert.ToInt32(height.Value));
            DialogResult = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Не создавать массив?", "Не создавать массив?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DialogResult = false;
                Close();
            }
        }
    }
}
