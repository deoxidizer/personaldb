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
            //TextboxID.Text = selectedEintrag.ID.ToString();
            //TextboxInterpret.Text = selectedEintrag.Interpretname.ToString();
            //ComboboxTyp.Text = selectedEintrag.Typ.ToString();
            //TextboxDate.Text = selectedEintrag.Gründungsdatum.ToString();
            //ComboboxGenre.Text = selectedEintrag.Genre.ToString();
            //TextboxLand.Text = selectedEintrag.Land.ToString();
            //ComboboxLabel.Text = selectedEintrag.Label.ToString();
            //TextboxISRC.Text = selectedEintrag.ISRC.ToString();
            //TextboxName.Text = selectedEintrag.Name.ToString();
            //TextboxLänge.Text = selectedEintrag.Länge.ToString();
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
