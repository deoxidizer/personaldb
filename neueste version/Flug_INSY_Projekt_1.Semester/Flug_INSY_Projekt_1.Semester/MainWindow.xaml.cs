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
            
        private void laden()
        {
            try
            {
                Eintraege = new ObservableCollection<PersonalundBerechtigung>();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Personal join Berechtigung USING(PersID)", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PersonalundBerechtigung Eintrag = new PersonalundBerechtigung();
                    Eintrag.PersID = rdr.GetInt16(0);
                    Eintrag.Geschlecht = rdr.GetString(1);
                    Eintrag.Rolle = rdr.GetString(2);
                    Eintrag.Vorname = rdr.GetString(3);
                    Eintrag.Nachname = rdr.GetString(4);
                    Eintrag.Geburtstagsdatum = rdr.GetString(5);
                    Eintrag.Adresse = rdr.GetString(6);
                    Eintrag.Telefonnummer = rdr.GetString(7);
                    Eintrag.BID = rdr.GetInt16(8);
                    Eintrag.darfarbeitin = rdr.GetString(9);
                    Eintrag.Ausbildung = rdr.GetString(10);
                    
                    Eintraege.Add(Eintrag);
                }
                detailgrid.ItemsSource = Eintraege;
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured:\r\n" + ex.Message);
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
            PersonalundBerechtigung selectedPersonalundBerechtigung = dataPersonalundBerechtigung.SelectedItem as PersonalundBerechtigung;

            string SQLCommand = string.Format("DELETE from freunde WHERE PersID='{0}'", selectedPersonalundBerechtigung.id);
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQLCommand, conn);
                cmd.ExecuteNonQuery();
                laden();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Delete crashed" + ex.Message);
            }
        }

        private void dataPersonalundBerechtigung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataPersonalundBerechtigung_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        public class PersonalundBerechtigung
        {
            public int PersID { get; set; }
            public string Geschlecht { get; set; }
            public string Rolle { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public string Geburtstagsdatum { get; set; }
            public string Adresse { get; set; }
            public string Telefonnummer { get; set; }
            //------------------------------------------
            public int BID { get; set; }
            public string darfarbeitin { get; set;}
            public string Ausbildung { get; set; }

        }
    }
}
