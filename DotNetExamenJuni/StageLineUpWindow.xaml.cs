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
        private List<Performer> performers = new List<Performer>();
        private MainWindow mainWindow;

        public List<Performer> Performers { get => performers; set => performers = value; }

        public StageLineUpWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            
            this.mainWindow = mainWindow;
            Closing += Window_Closing;
            performListBox.SelectionChanged += RemoveButton_Click;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }

        //TODO: zorg dat onderstaande code werkt, volgens richtlijnen opgave
        public void DisableEvents()
        {
            addButton.Click -= AddButton_Click;
            removeButton.Click -= RemoveButton_Click;
            exit_MenuItem.Click -= Exit_MenuItem_Click;
            save_MenuItem.Click -= Save_MenuItem_Click;
            open_MenuItem.Click -= Open_MenuItem_Cick;

        }

        //TODO: zorg dat onderstaande code werkt, volgens richtlijnen opgave
        public void EnableEvents()
        {
            addButton.Click += AddButton_Click;
            removeButton.Click += RemoveButton_Click;
            exit_MenuItem.Click += Exit_MenuItem_Click;
            save_MenuItem.Click += Save_MenuItem_Click;
            open_MenuItem.Click += Open_MenuItem_Cick;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            performListBox.Items.Remove(performListBox.SelectedItem);
            performListBox.Items.Refresh();
            
        }

        private void Open_MenuItem_Cick(object sender, RoutedEventArgs e)
        {
            performListBox.Items.Clear();

            performers.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string startFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.InitialDirectory = startFolder;
            openFileDialog.Filter = "text file|*.txt";
            
            
            if (openFileDialog.ShowDialog() == true)
            {
                char[] namesep = {'\\'};
                filePath = openFileDialog.FileName;
                stageTextBlock.Text = filePath.Split(namesep)[filePath.Split(namesep).Length - 1].Substring(0, filePath.Split(namesep)[filePath.Split(namesep).Length - 1].Length - 4);
                StreamReader streamReader = File.OpenText(openFileDialog.FileName);
                string line = streamReader.ReadLine();
                
                while (line != null)
                {
                    line.Trim();
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
                // for (int i = 0; i < performers.Count; i++)
                //{
                //    performListBox.Items.Add(performers[i].ToString());

                //}
                performListBox.ItemsSource = performers;
                addButton.IsEnabled = true;
                removeButton.IsEnabled = true;
                save_MenuItem.IsEnabled = true;
                streamReader.Close();
            }
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter streamWriter = File.CreateText(filePath);
            for (int i = 0; i < performers.Count; i++)
            {
                if (performers[i] as Band != null)
                {
                    Band band = (Band) performers[i];
                    string output = "B,";
                    output += band.MemberCount;
                    output += "," + band.Name;
                    output += "," + band.ReservationNumber + ",";
                    output += band.StartTime.ToString("hh\\:mm") + ",";
                    output += band.EndTime.ToString("hh\\:mm") + ",";
                    output += band.TechnicalSupplies[0] + ",";
                    output += band.TechnicalSupplies[1];
                    for (int j =0; j < band.Rider.Count; j++)
                    {
                        output += $",{band.Rider[j]}";
                    }
                    streamWriter.WriteLine(output);
                }
                else
                {
                    Solo solo = (Solo)performers[i];
                    string output = "S,";
                    output += solo.Type;
                    output += "," + solo.Name;
                    output += ", " + solo.ReservationNumber + ",";
                    output += solo.StartTime.ToString("hh\\:mm") + ",";
                    output += solo.EndTime.ToString("hh\\:mm") + ",";
                    output += solo.TechnicalSupplies[0] + ",";
                    output += solo.TechnicalSupplies[1];
                    for (int j = 0; j < solo.Rider.Count; j++)
                    {
                        output += $",{solo.Rider[j]}";
                    }
                    streamWriter.WriteLine(output);
                }
            }
            streamWriter.Close();
        }

        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DisableEvents();
            NewActWindow newActWindow = new NewActWindow(this);
            newActWindow.Show();
        }
    }
}
