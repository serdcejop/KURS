using AUTOO.ViewModels;
using System.Windows;

namespace AUTOO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  // Эта строка должна быть первой!
            DataContext = new MainViewModel();
        }
    }
}