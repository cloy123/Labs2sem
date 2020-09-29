using lab6;
using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab7
{
    /// <summary>
    /// Логика взаимодействия для EnterScanner.xaml
    /// </summary>
    public partial class EnterScanner : Window
    {
        public EnterScanner()
        {
            InitializeComponent();
            Number.Maximum = int.MaxValue;
            Number.Minimum = int.MinValue;
            Width.Maximum = int.MaxValue;
            Height.Maximum = int.MaxValue;
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
            MaxResolution = new Resolution(Convert.ToInt32(Width.Value), Convert.ToInt32(Height.Value));
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
