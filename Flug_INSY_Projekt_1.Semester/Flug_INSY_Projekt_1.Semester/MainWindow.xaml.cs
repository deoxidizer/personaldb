using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Flug_INSY_Projekt_1.Semester
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<PersonalundBerechtigung> Eintraege = new ObservableCollection<PersonalundBerechtigung>();
        MySqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuConnect_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "Server=84.115.51.33;Database=4AHIT;Uid=4AHIT;Pwd=4AHIT_klasse_INSY_1337";
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                laden();
            }
            catch (Exception s)
            {
                MessageBox.Show("Connection Error\r\n" + s.ToString());
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menudelete_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
