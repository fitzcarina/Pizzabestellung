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
using System.Windows.Shapes;

namespace test_aufbau
{
    /// <summary>
    /// Interaktionslogik für loeschen.xaml
    /// </summary>
    public partial class loeschen : Window
    {

    public string geben { get; set; }
        public string gericht { get; set; }
        public loeschen()
        {
            InitializeComponent();
            string benutzer = Environment.UserName;
            using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select Nummer, Besteller,Gericht from tbl_Galodoro where Besteller='"+benutzer+"'", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                //string gericht = "";
                while (reader.Read())
                {
                    Mitarbeiter.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                    gericht = reader[2].ToString();
                }
                reader.Close();

            }

        }
       
        private void löschen(object sender, RoutedEventArgs e)
        {

                if(Mitarbeiter.SelectedItem == null)
                {

                    MessageBox.Show("Es wurde kein Gericht zum löschen ausgewählt");
                }
                else
                {
                    geben = Mitarbeiter.SelectedItem.ToString();

                    Window richtigloeschen = new richtigloeschen(geben, gericht);
                    richtigloeschen.ShowDialog();
                   
                }

    }

    }

}
