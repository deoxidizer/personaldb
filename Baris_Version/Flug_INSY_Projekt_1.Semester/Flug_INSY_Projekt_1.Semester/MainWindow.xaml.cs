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
            
            MySqlCommand cmd = new MySqlCommand("Select * from 4AHIT", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PersonalundBerechtigung f = new PersonalundBerechtigung();
                f.id = rdr.GetInt32(0);
                f.Vorname = rdr.GetString(1);
                f.Nachname = rdr.GetString(2);
                f.Geburtsdatum = rdr.GetString(3).Substring(0, 10);
                Eintraege.Add(f);

            }
            dataPersonalundBerechtigung.ItemsSource = Eintraege;
            rdr.Close();
            //cmd = new MySqlCommand("Select count(*) from freunde", conn);
            //long anz = (long) cmd.ExecuteScalar();
            //label1.Content = anz + "Datensätze";
        }

        

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menudelete_Click(object sender, RoutedEventArgs e)
        {
            PersonalundBerechtigung selectedPersonalundBerechtigung = dataPersonalundBerechtigung.SelectedItem as PersonalundBerechtigung;

            string SQLCommand = string.Format("DELETE from freunde WHERE PersID='{0}'", selectedPersonalundBerechtigung.PersID);
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
            if (dataPersonalundBerechtigung.SelectedItems.Count > 0)
            {
                menudelete.IsEnabled = true;
            }
            else
            {
                menudelete.IsEnabled = false;
            }
        }

        private void dataPersonalundBerechtigung_MouseDoubleClick(object sender, MouseButtonEventArgs e) //Edit
        {
            PersonalundBerechtigung selectedPersonalundBerechtigung = dataPersonalundBerechtigung.SelectedItem as PersonalundBerechtigung;
            Window1 dlg = new Window1 (selectedPersonalundBerechtigung);
            if (dlg.ShowDialog() == false) return;

            try
            {
                string SQLCommand = string.Format("UPDATE database SET Geschlecht='{0}',Rolle='{1}',Vorname='{2}',Nachname='{3}',Geburtstagsdatum='{4}',Adresse='{5}',Telefonnummer='{6}',BID='{7}',darfarbeitenin='{8}',Ausbildung='{9}'", dlg.TextBoxID, dlg.ComboGeschlecht, dlg.ComboRolle, dlg.TexBoxVorname, dlg.TextBoxNachname, dlg.TextBoxGeburtsdatum, dlg.TextBoxAdresse, dlg.TextBoxTel, dlg.TextBoxBID,dlg.TextBoxdarfarbeitenin,dlg.TextBoxAusbildung);   //Verbesserung nötig
                MessageBox.Show(SQLCommand);
                MySqlCommand cmd = new MySqlCommand(SQLCommand, conn);
                cmd.ExecuteNonQuery();
                laden();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Update Crashed"+ex.Message);
            }
            }
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

        private void MenuDisconnect_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
