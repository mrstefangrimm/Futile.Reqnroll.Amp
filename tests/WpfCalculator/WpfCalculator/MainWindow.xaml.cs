using System.Windows;
using WpfCalculator;

namespace FlaUI.WpfCalculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(string commandLineArgs)
    {
        InitializeComponent();

        if (!string.IsNullOrEmpty(commandLineArgs))
        {
            Welcome.Content = commandLineArgs;
        }

        AboutBox.OnClose += (sender, args) => { chk1.IsChecked = false; };
    }

    private void OnAddClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) + double.Parse(Second.Text)):0.00}";
    }

    private void OnSubtractClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) - double.Parse(Second.Text)):0.00}";
    }

    private void OnMultiplyClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) * double.Parse(Second.Text)):0.00}";
    }

    private void OnDivideClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) / double.Parse(Second.Text)):0.00}";
    }

    private void OnAboutClick(object sender, RoutedEventArgs e)
    {
        //var popupContent = new AboutBox();
        //    popupContent.CloseRequested += (s, args) => MyPopup.IsOpen = false;

        //    MyPopup.Child = popupContent;
        //    MyPopup.IsOpen = true;
    }
}
