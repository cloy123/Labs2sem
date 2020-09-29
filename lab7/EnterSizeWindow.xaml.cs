using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EnterSizeWindow.xaml
    /// </summary>
    public partial class EnterSizeWindow : Window
    {
        public EnterSizeWindow()
        {
            InitializeComponent();
            Size.Maximum = int.MaxValue;
        }

        public int SizeArray = 1;
        public bool IsRandom = false;

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SizeArray = Convert.ToInt32(Size.Value);
            IsRandom = IsRnd.IsChecked.Value;
            DialogResult = true;
        }
    }
}
