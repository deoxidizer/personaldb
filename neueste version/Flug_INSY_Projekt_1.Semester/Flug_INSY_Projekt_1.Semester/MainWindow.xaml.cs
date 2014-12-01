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

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuConnect_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "Server=84.115.51.33;Database=4AHIT;Uid=root;Pwd=INSY_htl14-leszko_4ahitn";
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
        private void detailgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PersonalundBerechtigung selectedEintrag = (PersonalundBerechtigung)detailgrid.SelectedItem;
                detailedview Detailview = new detailedview(selectedEintrag, conn);
                Detailview.ShowDialog();
                if (Detailview.DialogResult == true)
                {
                    string SQLCommand1 = string.Format("UPDATE Personal SET PersID='{0}',Geschlecht='{1}',Rolle='{2}',Vorname='{3}',Nachname='{4}',Geburtstagsdatum='{5}',Adresse='{6}',Telefonnummer='{7}' WHERE id='{8}'", Detailview.TextBoxID.Text, Detailview.ComboGeschlecht.Text, Detailview.ComboRolle.Text, Detailview.TextBoxVorname.Text, Detailview.TextBoxNachname.Text, Detailview.TextBoxGeburtsdatum.Text, Detailview.TextBoxAdresse.Text, Detailview.TextBoxTel, selectedEintrag.PersID);
                    MySqlCommand cmd1 = new MySqlCommand(SQLCommand1, conn);
                    cmd1.ExecuteNonQuery();
                    //string SQLCommand2 = string.Format("UPDATE Berechtigung SET ISRC='{0}',Name='{1}',Länge='{2}' WHERE ISRC='{3}'", Detailview.TextboxISRC.Text, Detailview.TextboxName.Text, Detailview.TextboxLänge.Text, selectedEintrag.ISRC);
                    //MySqlCommand cmd2 = new MySqlCommand(SQLCommand2, conn);
                    //cmd2.ExecuteNonQuery();
                    laden();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry something crashed: \r\n" + ex.Message);
            }
        }
        private void detailgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (detailgrid.SelectedItems.Count > 0)
            {
                Menu_Delete.IsEnabled = true;
            }
            else
            {
                Menu_Delete.IsEnabled = false;
            }
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            PersonalundBerechtigung selectedPersonalundBerechtigung = detailgrid.SelectedItem as PersonalundBerechtigung;

            string SQLCommand = string.Format("DELETE from 4AHITN WHERE PersID='{0}'", selectedPersonalundBerechtigung.PersID);
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

        private void Menu_Insert_Click(object sender, RoutedEventArgs e)
        {
           detailedview Detailview = new detailedview();
           Detailview.ShowDialog();
           if (Detailview.DialogResult == true)
           {
                    
                    try
                    {
                        //umschreiben
                        //----------------------
                        //string SQLCommand = string.Format("INSERT INTO interpret VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", Detailview.TextboxID.Text, Detailview.TextboxInterpret.Text, Detailview.ComboboxTyp.Text, Detailview.TextboxDate.Text, Detailview.ComboboxGenre.Text, Detailview.TextboxLand.Text, Detailview.ComboboxLabel.Text);
                        //MySqlCommand cmd = new MySqlCommand(SQLCommand, conn);
                        //cmd.ExecuteNonQuery();
                        //string SQLCommand2 = string.Format("INSERT INTO aufnahmen VALUES('{0}','{1}','{2}','{3}');", Detailview.TextboxISRC.Text, Detailview.TextboxName.Text, Detailview.TextboxLänge.Text, Detailview.TextboxID.Text);
                        //MySqlCommand cmd2= new MySqlCommand(SQLCommand2, conn);
                        //cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An Error occured:\r\n" + ex.Message);
                    }
                    laden();
           }
        }

        private void Menu_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PersonalDB v0.9 \nProgramm zum Anzeigen der Personaldaten ihres Flugzeugpersonals \nEntwickelt von Kevin Deo, Baris Senkal und Alexander Tomasiak\r\n");
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
