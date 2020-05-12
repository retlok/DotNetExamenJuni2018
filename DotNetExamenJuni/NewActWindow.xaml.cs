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
using System.Windows.Shapes;

namespace DotNetExamenJuni
{
    /// <summary>
    /// Interaction logic for NewActWindow.xaml
    /// </summary>
    public partial class NewActWindow : Window
    {
        public NewActWindow()
        {
            InitializeComponent();
        }



        private void BandRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (typeCountLabel != null)
            {
                typeCountLabel.Content = "Members";
            }

        }

        private void SoloRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (typeCountLabel != null)
            {
                typeCountLabel.Content = "Type of artist";
            }
                
        }
    }
}
