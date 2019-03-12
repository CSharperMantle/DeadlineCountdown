using System.Windows;
using System.Windows.Input;

namespace DeadlineCountdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isFullScreen = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F11:
                    if (isFullScreen)
                    {
                        WindowState = WindowState.Normal;
                        WindowStyle = WindowStyle.SingleBorderWindow;
                        
                    }
                    else
                    {
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                    }
                    isFullScreen = !isFullScreen;
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
