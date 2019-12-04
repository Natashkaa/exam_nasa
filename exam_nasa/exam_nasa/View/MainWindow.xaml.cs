using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exam_nasa.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            //MainWin.CloseWindow(sender, e);
            MainWin.Close();
        }

        private void Video_MediaEnded(object sender, RoutedEventArgs e)
        {
            Video.Position = TimeSpan.FromMilliseconds(1);
            if (Video.IsLoaded)
            {
                Video.Play();

            }
        }
        private void MainWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Video.Stop();
        }
    }
}
