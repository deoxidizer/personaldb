using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Flug_INSY_Projekt_1.Semester
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class detailedview : Window
    {
        public detailedview()
        {
            InitializeComponent();
            comboenumtyp();
        }

        public detailedview(Flug_INSY_Projekt_1.Semester.MainWindow.PersonalundBerechtigung selectedEintrag,MySqlConnection Connection)
        {
            InitializeComponent();
            comboenumtyp();
            TextBoxID.Text = selectedEintrag.PersID.ToString();
            ComboGeschlecht.Text = selectedEintrag.Geschlecht.ToString();
            ComboRolle.Text = selectedEintrag.Rolle.ToString();
            TextBoxVorname.Text = selectedEintrag.PVorname.ToString();
            TextBoxNachname.Text = selectedEintrag.PNachname.ToString();
            TextBoxGeburtsdatum.Text = selectedEintrag.GeburtsDatum.ToString();
            TextBoxAdresse.Text = selectedEintrag.PAdresse.ToString();
            TextBoxTel.Text = selectedEintrag.PTelNr.ToString();
            TextBoxBID.Text = selectedEintrag.BID.ToString();
            TextBoxAusbildung.Text = selectedEintrag.Ausbildung.ToString();
            TextBoxBer.Text = selectedEintrag.darfarbeitin.ToString();
        }

        private void comboenumtyp()
        {
            //ComboboxTyp.Items.Add("Band");
            //ComboboxTyp.Items.Add("Solo");
            //ComboboxGenre.Items.Add("Alternative");
            //ComboboxGenre.Items.Add("Blues");
            //ComboboxGenre.Items.Add("Classic");
            //ComboboxGenre.Items.Add("Country");
            //ComboboxGenre.Items.Add("Dance");
            //ComboboxGenre.Items.Add("Electronic");
            //ComboboxGenre.Items.Add("Folk");
            //ComboboxGenre.Items.Add("Hip-Hop/Rap");
            //ComboboxGenre.Items.Add("Instrumental");
            //ComboboxGenre.Items.Add("Jazz");
            //ComboboxGenre.Items.Add("Pop");
            //ComboboxGenre.Items.Add("R&B/Soul");
            //ComboboxGenre.Items.Add("Reggae");
            //ComboboxGenre.Items.Add("Rock");
            //ComboboxGenre.Items.Add("Singer/Songwriter");
            //ComboboxLabel.Items.Add("WMG");
            //ComboboxLabel.Items.Add("CST");
            //ComboboxLabel.Items.Add("OLE");
        }

        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

    }
}
