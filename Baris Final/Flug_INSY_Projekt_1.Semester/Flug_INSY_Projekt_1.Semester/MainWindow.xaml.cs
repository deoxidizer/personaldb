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
                MessageBox.Show("Successfully Connected!");
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PersonalundBerechtigung Eintrag = new PersonalundBerechtigung();
                    Eintrag.PersID = rdr.GetInt16(0);
                    Eintrag.Geschlecht = rdr.GetString(1);
                    Eintrag.GeburtsDatum = rdr.GetString(2);
                    Eintrag.PVorname = rdr.GetString(3);
                    Eintrag.PNachname = rdr.GetString(4);
                    Eintrag.VerNr = rdr.GetString(5);
                    Eintrag.PAdresse = rdr.GetString(6);
                    Eintrag.PTelNr = rdr.GetString(7);
                    Eintrag.Rolle = rdr.GetString(8);
                    Eintrag.BID = rdr.GetInt16(9);
                    Eintrag.darfarbeitin = rdr.GetString(10);
                    Eintrag.Ausbildung = rdr.GetString(11);
                    

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
                    string SQLCommand1 = string.Format("UPDATE Personal SET Geschlecht='{0}',GeburtsDatum='{1}',PVorname='{2}',PNachname='{3}',PersID='{4}',VerNr='{5}',PAdresse='{6}',PTelNr='{7}', Rolle='{8}' WHERE PersID='{9}'", Detailview.ComboGeschlecht.Text, Detailview.TextBoxGeburtsdatum.Text, Detailview.TextBoxVorname.Text, Detailview.TextBoxNachname.Text, Detailview.TextBoxID.Text, Detailview.Versicherung.Text, Detailview.TextBoxAdresse.Text, Detailview.TextBoxTel.Text, Detailview.ComboRolle.Text, selectedEintrag.PersID);
                    MySqlCommand cmd1 = new MySqlCommand(SQLCommand1, conn);
                    cmd1.ExecuteNonQuery();
                    //string SQLCommand2 = string.Format("UPDATE Berechtigung SET BID='{0}',darfarbeitin='{1}',Ausbildung='{2}' WHERE PersID='{3}'", Detailview.TextBoxBID.Text, Detailview.Combodai.Text, Detailview.TextBoxAusbildung.Text, selectedEintrag.BID);
                    //MySqlCommand cmd2 = new MySqlCommand(SQLCommand2, conn);
                    //cmd2.ExecuteNonQuery();
                    //laden();
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

            string SQLCommand = string.Format("DELETE from Personal WHERE PersID='{0}'", selectedPersonalundBerechtigung.PersID);
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
                        string SQLCommand18 = string.Format("INSERT INTO Personal VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", Detailview.ComboGeschlecht.Text, Detailview.TextBoxGeburtsdatum.Text, Detailview.TextBoxVorname.Text, Detailview.TextBoxNachname.Text, Detailview.TextBoxID.Text, Detailview.Versicherung.Text, Detailview.TextBoxAdresse.Text, Detailview.TextBoxTel.Text, Detailview.ComboRolle.Text);
                        MySqlCommand cmd18 = new MySqlCommand(SQLCommand18, conn);
                        cmd18.ExecuteNonQuery();

                        string SQLCommand19 = string.Format("INSERT INTO Berechtigung VALUES('{0}','{1}','{2}','{3}')", Detailview.TextBoxID.Text, Detailview.TextBoxBID.Text, Detailview.Combodai.Text, Detailview.TextBoxAusbildung.Text);
                        MySqlCommand cmd19 = new MySqlCommand(SQLCommand18, conn);
                        cmd19.ExecuteNonQuery();
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
            public string GeburtsDatum { get; set; }
            public string PVorname { get; set; }
            public string PNachname { get; set; }
            public string VerNr { get; set; }
            public string PAdresse { get; set; }
            public string PTelNr { get; set; }
            public string Rolle { get; set; }
            //-----------------------------------
            public int BID { get; set; }
            public string darfarbeitin { get; set;}
            public string Ausbildung { get; set; }
            

        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Close();
                MessageBox.Show("Database disconnected");
                detailgrid.ItemsSource = null;
            }
            catch (Exception s)
            {
                MessageBox.Show("Connection Error\r\n" + s.ToString());
            }
        }


    }
}
