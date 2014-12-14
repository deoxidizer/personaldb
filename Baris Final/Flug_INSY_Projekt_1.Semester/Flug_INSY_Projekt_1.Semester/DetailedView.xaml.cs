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
            Combodai.Text = selectedEintrag.darfarbeitin.ToString();
            Versicherung.Text = selectedEintrag.VerNr.ToString();
        }

        private void comboenumtyp()
        {
            ComboGeschlecht.Items.Add("Männlich");
            ComboGeschlecht.Items.Add("Weiblich");
            ComboRolle.Items.Add("Pilot");
            ComboRolle.Items.Add("Kopilot");
            ComboRolle.Items.Add("Flugbegleiter");
            Combodai.Items.Add("Airbus 318-100");
            Combodai.Items.Add("Boeing 777-300");
            Combodai.Items.Add("Boeing 777-300ER");
            Combodai.Items.Add("Boeing 777-200 retrofit");
            Combodai.Items.Add("The Emirates A380");
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
