using System.Windows;

namespace AUTOO
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            Title = "Статистика автопредприятия";
            Width = 600;
            Height = 400;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
    }
}