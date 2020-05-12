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
    /// Interaction logic for StageLineUpWindow.xaml
    /// </summary>
    public partial class StageLineUpWindow : Window
    {
        public StageLineUpWindow()
        {
            InitializeComponent();
        }

        //TODO: zorg dat onderstaande code werkt, volgens richtlijnen opgave
        public void DisableEvents()
        {
            throw new NotImplementedException("staat hier code?");
        }

        //TODO: zorg dat onderstaande code werkt, volgens richtlijnen opgave
        public void EnableEvents()
        {
            throw new NotImplementedException("staat hier code?");
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO:hier het juist item verwijderen uit de lijst.

            //tip om de getoonde lijst te updaten.
            performListBox.Items.Refresh();
        }
    }
}
