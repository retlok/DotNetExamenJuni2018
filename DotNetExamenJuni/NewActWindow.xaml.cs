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
        private StageLineUpWindow stageLine;
        public NewActWindow(StageLineUpWindow window)
        {
            InitializeComponent();
            stageLine = window;
            Closing += Clocing_EvenHandler;
        }

        private void Clocing_EvenHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            stageLine.EnableEvents();
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
        // checken als alles ingevuld is
        private void AddActButton_Click(object sender, RoutedEventArgs e)
        {
            char[] sep = { ' ' };
            char[] sep2 = { ',' };
            int[] technical = { Convert.ToInt32(technicalTextBox.Text.Split(sep)[0]), Convert.ToInt32(technicalTextBox.Text.Split(sep)[1]) };
            string[] strrider = riderTextBox.Text.Split(sep2);
            List<string> listRider = new List<string>();
            for (int i = 0; i < strrider.Length; i++)
            {
                listRider.Add(strrider[i]);
            }
            
            
            if ((bool)bandRadioButton.IsChecked)
            {
                Band band = new Band(Convert.ToInt32(typeCountTextBox.Text), nameTextBox.Text, Convert.ToInt32(numberTextBox.Text), startHourTextBox.Text, endHourTextBox.Text, technical, listRider);
                for (int i = 0; i < stageLine.Performers.Count; i++)
                {
                    if (band.EndTime < stageLine.Performers[i].StartTime)
                    {
                        if (band.StartTime <= stageLine.Performers[i + 1].EndTime)
                        {
                            throw new FestivalException("Vorig optreden is nog niet beëindigd");
                        }
                        else
                        {
                            stageLine.Performers.Insert(i, band);
                        }
                    }
                }
            }
            else
            {
                
                Solo solo = new Solo(typeCountTextBox.Text, nameTextBox.Text, Convert.ToInt32(numberTextBox.Text), startHourTextBox.Text, endHourTextBox.Text, technical, listRider);
                for (int i = 0; i < stageLine.Performers.Count; i++)
                {
                    if (solo.EndTime < stageLine.Performers[i].StartTime)
                    {
                        if (i == 0)
                        {
                            stageLine.Performers.Insert(i, solo);
                            break;
                        }
                        else
                        {
                            if (solo.StartTime <= stageLine.Performers[i - 1].EndTime)
                            {
                                throw new FestivalException("Vorig optreden is nog niet beëindigd");
                            }
                            else
                            {
                                stageLine.Performers.Insert(i, solo);
                                break;
                            }
                        }
                    }
                }
                

            }
            
            stageLine.performListBox.Items.Refresh();
            stageLine.EnableEvents();
            Close();
        }
    }
}
