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

namespace SimpleDataBindingApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Set DataContext to our ViewModel
        DataContext = new DataViewModel();
    }

    /// <summary>
    /// Handle explicit update for the slider with UpdateSourceTrigger=Explicit
    /// </summary>
    private void UpdateProgress_Click(object sender, RoutedEventArgs e)
    {
        // Get the binding expression for the slider
        BindingExpression? bindingExpression = ProgressSlider.GetBindingExpression(Slider.ValueProperty);
        
        // Update the source explicitly
        bindingExpression?.UpdateSource();
    }
}