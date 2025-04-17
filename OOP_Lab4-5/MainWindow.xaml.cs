using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOP_Lab4_5
{
    public partial class MainWindow : Window
    {
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
            {
                if (e.Delta > 0)
                {
                    scrollViewer.LineUp();
                }
                else
                {
                    scrollViewer.LineDown();
                }
                e.Handled = true;
            }
        }

        public MainWindow()
        {
            DataContext = new MainViewModel();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            var currentExpander = sender as Expander;

            // Находим родительский контейнер, в котором находятся все Expander'ы
            var container = currentExpander.Parent as Panel; // или другой тип контейнера

            if (container != null)
            {
                foreach (var child in container.Children)
                {
                    if (child is Expander expander && expander != currentExpander)
                    {
                        expander.IsExpanded = false;
                    }
                }
            }
        }

    }
}