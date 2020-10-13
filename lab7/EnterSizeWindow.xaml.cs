using System;
using System.Windows;

namespace lab7
{
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
