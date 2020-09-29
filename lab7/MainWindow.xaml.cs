using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace lab7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Scanners scanners;
        Scanners forBubble;
        Scanners forSelection;
        Scanners forInclusion;
        Scanners forShaker;
        Scanners forShell;

        int timeBubbleSort = 0;
        int timeSelectionSort = 0;
        int timeInclusionSort = 0;
        int timeShakerSort = 0;
        int timeShellSort = 0;

        string result = "";
        string Scanners = "";
        string Bubble = "";
        string Selection = "";
        string Inclusion = "";
        string Shaker = "";
        string Shell = "";

        string OnlyNumbersScanners = "";
        string OnlyNumbersBubble = "";
        string OnlyNumbersSelection = "";
        string OnlyNumbersInclusion = "";
        string OnlyNumbersShaker = "";
        string OnlyNumbersShell = "";
        private string ScannersToString(Scanners scanners)
        {
            string str = "";

            for(int i = 0; i < scanners.Lenght; i++)
            {
                str += $"Элемент {i+1}:\n" +
                    $"Firm: {scanners[i].Firm}\n" +
                    $"Number: {scanners[i].Number}\n" +
                    $"Scanner type: {scanners[i].ScannerType}\n" +
                    $"Max resolution: {scanners[i].MaxResolution}\n\n";
            }
            return str;
        }

        private string NumbersToString(Scanners scanners)
        {
            string str = "[";
            foreach(Scanner s in scanners)
            {
                str += $"{s.Number}, ";
            }
            str += "]";
            return str;
        }

        private void EnterArray_Click(object sender, RoutedEventArgs e)
        {
            EnterSizeWindow enterSizeWindow = new EnterSizeWindow();
            enterSizeWindow.ShowDialog();
            if(enterSizeWindow.DialogResult == true)
            {
               if(enterSizeWindow.IsRandom)
               {
                    scanners = new Scanners(enterSizeWindow.SizeArray);
                    scanners.RandomNumbers();
               }
               else
               {
                    Scanners newScanners = new Scanners(enterSizeWindow.SizeArray);
                    for(int i = 0; i < newScanners.Lenght ; i++)
                    {
                        EnterScanner enterScanner = new EnterScanner();
                        enterScanner.Title = $"Введите элемент {i+1}";
                        enterScanner.ShowDialog();
                        if(enterScanner.DialogResult == true)
                        {
                            newScanners[i] = enterScanner.ReturnScanner();
                        }
                        else
                        {
                            return;
                        } 
                    }
                    scanners = newScanners;
                }
                forBubble = (Scanners)scanners.Clone();
                forSelection = (Scanners)scanners.Clone();
                forInclusion = (Scanners)scanners.Clone();
                forShaker = (Scanners)scanners.Clone();
                forShell = (Scanners)scanners.Clone();
                Scanners = ScannersToString(scanners);
                ArraysToString();
                ComboBox.SelectedIndex = 1;
                SetText();
            }
        }

        private void ArraysToString()
        {
            Scanners = ScannersToString(scanners);
            Bubble = ScannersToString(forBubble);
            Selection = ScannersToString(forSelection);
            Inclusion = ScannersToString(forInclusion);
            Shaker = ScannersToString(forShaker);
            Shell = ScannersToString(forShell);

            OnlyNumbersScanners = NumbersToString(scanners);
            OnlyNumbersBubble = NumbersToString(forBubble);
            OnlyNumbersSelection = NumbersToString(forSelection);
            OnlyNumbersInclusion = NumbersToString(forInclusion);
            OnlyNumbersShaker = NumbersToString(forShaker);
            OnlyNumbersShell = NumbersToString(forShell);
        }

        private void SortArray_Click(object sender, RoutedEventArgs e)
        {
            if(scanners != null)
            {
                Stopwatch timer = new Stopwatch();

                timer.Start();
                forBubble.BubbleSort();
                timer.Stop();
                timeBubbleSort = Convert.ToInt32(timer.ElapsedMilliseconds);

                timer.Reset();
                timer.Start();
                forSelection.SelectionSort();
                timer.Stop();
                timeSelectionSort = Convert.ToInt32(timer.ElapsedMilliseconds);

                timer.Reset();
                timer.Start();
                forInclusion.InclusionSort();
                timer.Stop();
                timeInclusionSort = Convert.ToInt32(timer.ElapsedMilliseconds);

                timer.Reset();
                timer.Start();
                forShaker.ShakerSort();
                timer.Stop();
                timeShakerSort = Convert.ToInt32(timer.ElapsedMilliseconds); 

                timer.Reset();
                timer.Start();
                forShell.ShellSort();
                timer.Stop();
                timeShellSort = Convert.ToInt32(timer.ElapsedMilliseconds);

                result = $"Cортировка пузырьком: {timeBubbleSort} ms\n" +
                    $"Сортировка массива методом прямого выбора: {timeSelectionSort} ms\n" +
                    $"Сортировка прямыми включениями: {timeInclusionSort} ms\n" +
                    $"Шейкерная сортировка: {timeShakerSort} ms\n" +
                    $"Сортировка методом Шелла: {timeShellSort} ms\n";
                ArraysToString();
                SetText();
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { SetText(); }

        private void SetText()
        {
            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    text.Text = result;
                    break;
                case 1:
                    if (IsOnlyNumbers.IsChecked)
                    { text.Text = OnlyNumbersScanners; }
                    else
                    { text.Text = Scanners; }
                    break;
                case 2:
                    if (IsOnlyNumbers.IsChecked)
                    { text.Text = OnlyNumbersBubble; }
                    else
                    { text.Text = Bubble; }
                    break;
                case 3:
                    if (IsOnlyNumbers.IsChecked)
                    { text.Text = OnlyNumbersSelection; }
                    else
                    { text.Text = Selection; }
                    break;
                case 4:
                    if (IsOnlyNumbers.IsChecked)
                    { text.Text = OnlyNumbersInclusion; }
                    else
                    { text.Text = Inclusion; }
                    break;
                case 5:
                    if (IsOnlyNumbers.IsChecked)
                    { text.Text = OnlyNumbersShaker; }
                    else
                    { text.Text = Shaker; }
                    break;
                case 6:
                    if (IsOnlyNumbers.IsChecked)
                    { text.Text = OnlyNumbersShell; }
                    else
                    { text.Text = Shell; }
                    break;
            }
        }
        private void IsOnlyNumbers_Click(object sender, RoutedEventArgs e)
        { SetText(); }
    }
}
