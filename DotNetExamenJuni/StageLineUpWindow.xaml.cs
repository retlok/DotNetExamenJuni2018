using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace DotNetExamenJuni
{
    
    /// <summary>
    /// Interaction logic for StageLineUpWindow.xaml
    /// </summary>

    public partial class StageLineUpWindow : Window
    {
        private string filePath = "";
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

        private void Open_MenuItem_Cick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string startFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.InitialDirectory = startFolder;
            openFileDialog.Filter = "text file|*.txt";
            
            
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                StreamReader streamReader = File.OpenText(openFileDialog.FileName);
                string line = streamReader.ReadLine();
                List<Performer> performers = new List<Performer>();
                while (line != null)
                {
                    char[] separator = { ',' };
                    string[] items = line.Split(separator);
                    if (items[0] == "B"){
                        int[] techinical = { Convert.ToInt32(items[6]), Convert.ToInt32(items[7]) };
                        List<string> rider = new List<string>();
                        for (int i = 8; i < items.Length; i++)
                        {
                            rider.Add(items[i]);
                        }

                        Band band = new Band(Convert.ToInt32(items[1]), items[2], Convert.ToInt32(items[3]), items[4], items[5], techinical, rider);
                        performers.Add(band);
                    }
                    else
                    {
                        int[] techinical = { Convert.ToInt32(items[6]), Convert.ToInt32(items[7]) };
                        List<string> rider = new List<string>();
                        for (int i = 8; i < items.Length; i++)
                        {
                            rider.Add(items[i]);
                        }

                        Solo solo = new Solo(items[1] , items[2], Convert.ToInt32(items[3]), items[4], items[5], techinical, rider);
                        performers.Add(solo);
                    }
                    line = streamReader.ReadLine();

                }
                for (int i = 0; i < performers.Count; i++)
                {
                    performListBox.Items.Add(performers[i].ToString());
                    
                }
                addButton.IsEnabled = true;
                removeButton.IsEnabled = true;
                save_MenuItem.IsEnabled = true;
            }
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter streamWriter = File.CreateText(filePath);

            streamWriter.WriteLine();
        }

        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
