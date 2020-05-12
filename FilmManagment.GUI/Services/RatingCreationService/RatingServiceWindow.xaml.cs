using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FilmManagment.GUI.Services.RatingCreationService
{
    /// <summary>
    /// Interaction logic for RatingServiceWindow.xaml
    /// </summary>
    public partial class RatingServiceWindow : Window
    {
        public RatingServiceWindow()
        {
            InitializeComponent();
        }

        private void Close_window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
