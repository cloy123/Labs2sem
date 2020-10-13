using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace lab7
{
    public partial class MainWindow : Window
    {
        Scanners scanners;
        Scanners Bubble;
        Scanners Selection;
        Scanners Inclusion;
        Scanners Shaker;
        Scanners Shell;
        List<Result> Results;

        public MainWindow()
        {
            InitializeComponent();
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
                Bubble = (Scanners)scanners.Clone();
                Selection = (Scanners)scanners.Clone();
                Inclusion = (Scanners)scanners.Clone();
                Shaker = (Scanners)scanners.Clone();
                Shell = (Scanners)scanners.Clone();
                ComboBox.SelectedIndex = 1;
                dataGrid.ItemsSource = scanners;
            }
        }

        private void SortArray_Click(object sender, RoutedEventArgs e)
        {
            Results = new List<Result>();
            ComboBox.SelectedIndex = 0;
            if (scanners != null)
            {
                Stopwatch timer = new Stopwatch();

                timer.Start();
                Bubble.BubbleSort();
                timer.Stop();
                Results.Add(new Result("Пузырьком", Convert.ToInt32(timer.ElapsedMilliseconds).ToString()));

                timer.Reset();
                timer.Start();
                Selection.SelectionSort();
                timer.Stop();
                Results.Add(new Result("Прямым выбором", Convert.ToInt32(timer.ElapsedMilliseconds).ToString()));

                timer.Reset();
                timer.Start();
                Inclusion.InclusionSort();
                timer.Stop();
                Results.Add(new Result("Прямыми включениями", Convert.ToInt32(timer.ElapsedMilliseconds).ToString()));

                timer.Reset();
                timer.Start();
                Shaker.ShakerSort();
                timer.Stop();
                Results.Add(new Result("Шейкерная сортировка", Convert.ToInt32(timer.ElapsedMilliseconds).ToString()));

                timer.Reset();
                timer.Start();
                Shell.ShellSort();
                timer.Stop();
                Results.Add(new Result("Методом Шелла", Convert.ToInt32(timer.ElapsedMilliseconds).ToString()));
            }
            ComboBox.SelectedIndex = 0;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (scanners != null)
            {
                switch (ComboBox.SelectedIndex)
                {
                    case 0:
                        dataGrid.ItemsSource = Results;
                        break;
                    case 1:
                        dataGrid.ItemsSource = (Scanners)scanners.Clone();
                        break;
                    case 2:
                        dataGrid.ItemsSource = (Scanners)Bubble.Clone();
                        break;
                    case 3:
                        dataGrid.ItemsSource = (Scanners)Selection.Clone();
                        break;
                    case 4:
                        dataGrid.ItemsSource = (Scanners)Inclusion.Clone();
                        break;
                    case 5:
                        dataGrid.ItemsSource = (Scanners)Shaker.Clone();
                        break;
                    case 6:
                        dataGrid.ItemsSource = (Scanners)Shell.Clone();
                        break;
                }
            }
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }
    }
}
