using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace WpfCalculator;

/// <summary>
/// Interaction logic for AboutBox.xaml
/// </summary>
public partial class AboutBox : UserControl
{
    public static event EventHandler OnClose;

    public AboutBox()
    {
        InitializeComponent();
    }

    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
        OnClose?.Invoke(this, EventArgs.Empty);
        //Window.GetWindow(this).Close();
    }
}
