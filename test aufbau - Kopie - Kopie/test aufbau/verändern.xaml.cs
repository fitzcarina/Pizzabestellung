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
    /// Interaktionslogik für verändern.xaml
    /// </summary>
    public partial class verändern : Window
    {
        public verändern()
        {
            
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select  * from tbl_Pizzabestellungen", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Speiseplan.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                }
                reader.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nummer = Nummer.Text;
            string gericht = Gericht.Text;
            string preis = Preis.Text;


         

                using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
                {


                    using (SqlCommand cmd = new SqlCommand(@"UPDATE tbl_Pizzabestellungen set   Preis='" + preis + "'", conn))

                    {
                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Telefonnummer wurde erfolgreich bearbeitet ");
                    }
                }
            

        }

        private void auswählen(object sender, RoutedEventArgs e)
        {
            string[] auswahl = Speiseplan.SelectedItem.ToString().Split(" ");

            using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select  * from tbl_Pizzabestellungen where Nummer=" + auswahl[0], conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nummer.Text = reader[0].ToString();
                    Gericht.Text= reader[1].ToString();

                 Preis.Text=reader[2].ToString();
                }
                reader.Close();
                
            }
            

          



        }
    }

}
