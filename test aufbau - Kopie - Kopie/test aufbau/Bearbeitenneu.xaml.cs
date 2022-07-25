using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace test_aufbau
{
    /// <summary>
    /// Interaktionslogik für Bearbeitenneu.xaml
    /// </summary>
    public partial class Bearbeitenneu : Window
    {
        public Bearbeitenneu()
        {
            //Ausgabe Der Vorname, Nachname und ID in der Listbox beim Klicken auf den Button Bearbeiten
            //try
            //{
            InitializeComponent();
            //Ueberschrift.Content = "Bitte wählen Sie den Mitarbeiter, den Sie bearbeiten möchten";
            //using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("Select Nachname,Vorname,ID from tbl_Telefonnummern where Nachname IS NOT NULL AND Nachname != ' '", conn);

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Mitarbeiter.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            //    }
            //    reader.Close();
            //}


            //}
            //catch
            //{

            //    MessageBox.Show("Es gab einen Fehler beim Laden der Mitarbeiter und deren Telfonnummern");
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////Vom der Ausgewählten ID deren Vorherige Einträge werden in die Textbox geschrieben



            //Ueberschrift.Content = "Bitte legen Sie ein neues Gericht an";


            //int s;
            //bool nummer_p = Int32.TryParse(Nummer.Text, out s);
            ////string nachname = Nachname.Text;
            ////bool nachname_p = Int32.TryParse(Nachname.Text, out s);
            ////bool durchwahl_p = Int32.TryParse(Durchwahl.Text, out s);


            ////string sql_hilfe = "Insert";
            ////string handy = Handy.Text;
            ////int n;

            ////bool kurzwahl_p = Int32.TryParse(Kurzwahl.Text, out n);
            ////string durchwahl_string = Durchwahl.Text;
            ////string kurzwahl_string = Kurzwahl.Text;
            ////string id = "";
            //if (nummer_p == true && Nummer.Text != "")
            //{
            //    Class1.sqlGerichtHinzufügen(Nummer.Text, Gericht.Text, Preis.Text);
            //}






        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Vom der Ausgewählten ID deren Vorherige Einträge werden in die Textbox geschrieben



            Ueberschrift.Content = "Bitte legen Sie ein neues Gericht an";


            int s;
            bool nummer_p = Int32.TryParse(Nummer.Text, out s);
            //string nachname = Nachname.Text;
            //bool nachname_p = Int32.TryParse(Nachname.Text, out s);
            //bool durchwahl_p = Int32.TryParse(Durchwahl.Text, out s);


            //string sql_hilfe = "Insert";
            //string handy = Handy.Text;
            //int n;

            //bool kurzwahl_p = Int32.TryParse(Kurzwahl.Text, out n);
            //string durchwahl_string = Durchwahl.Text;
            //string kurzwahl_string = Kurzwahl.Text;
            //string id = "";
            if (nummer_p == true && Nummer.Text != "")
            {
                Class1.sqlGerichtHinzufügen(Nummer.Text, Gericht.Text, Preis.Text);
            }













            // string vorname = Vornames.Text;
            // int s;
            // bool vorname_p = Int32.TryParse(Vornames.Text, out s);

            // string nachname = Nachname.Text;
            // bool nachname_p = Int32.TryParse(Nachname.Text, out s);
            // bool durchwahl_p = Int32.TryParse(Durchwahl.Text, out s);


            // string sql_hilfe = "update";
            // string handy = Handy.Text;
            // int n;

            // bool kurzwahl_p = Int32.TryParse(Kurzwahl.Text, out n);
            // string durchwahl_string = Durchwahl.Text;
            // string kurzwahl_string = Kurzwahl.Text;
            // string id = ID.Text;

            //// Class1.pruefen(id, sql_hilfe, vorname, vorname_p, nachname_p, nachname, handy, kurzwahl_p, n, durchwahl_string, kurzwahl_string, durchwahl_p);



        }
    }

                            }

