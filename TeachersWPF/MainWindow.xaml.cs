using System.Windows;
using TeachersWPF.BL;

namespace TeachersWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Logical();
        }


    }
}
