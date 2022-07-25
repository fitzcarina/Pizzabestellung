using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzabestellung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tbl_Pizzabestellungen", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Speisekarte.Items.Add(reader[0].ToString() + " Bezeichnung" + reader[1].ToString() + " Preis: " + reader[2].ToString()+" €");
                }
                reader.Close();
            }
        
        }

        private void Hinzufügen_Click(object sender, RoutedEventArgs e)
        {
            gewählt.Content= Speisekarte.SelectedItem.ToString();





            var[] authorlist = gewählt.Content.Split(" ");
            Nachname.Text = authorlist[0];
            Vornames.Text = authorlist[1];
            string IDs = authorlist[2];

            string vorname = Vorname.Text;
            int s;
            bool vorname_p = Int32.TryParse(Vorname.Text, out s);
            string nachname = Nachname.Text;
            bool nachname_p = Int32.TryParse(Nachname.Text, out s);
            bool durchwahl_p = Int32.TryParse(Durchwahl.Text, out s);


            string sql_hilfe = "Insert";
            string handy = Handy.Text;
            int n;

            bool kurzwahl_p = Int32.TryParse(Kurzwahl.Text, out n);
            string durchwahl_string = Durchwahl.Text;
            string kurzwahl_string = Kurzwahl.Text;
            string id = "";


            if (Class1.pruefen(id, sql_hilfe, vorname, vorname_p, nachname_p, nachname, handy, kurzwahl_p, n, durchwahl_string, kurzwahl_string, durchwahl_p) == true)
            {
                Class1.sqlInsert(id, sql_hilfe, vorname, vorname_p, nachname_p, nachname, handy, kurzwahl_p, n, durchwahl_string, kurzwahl_string, durchwahl_p);
            }

        }
    }
}
