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
    /// Interaktionslogik für speiseplan_löschen.xaml
    /// </summary>
    public partial class speiseplan_löschen : Window
    {
        public speiseplan_löschen()
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

            if (Speiseplan.SelectedItem == null)
            {

                MessageBox.Show("Bitte wählen Sie ein Gericht aus ");
            }
            else
            {
                string[] nummer = Speiseplan.SelectedItem.ToString().Split(" ");


                using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from tbl_Pizzabestellungen where Nummer='" + nummer[0]+"'", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                    }
                    reader.Close();
                    MessageBox.Show("Das Gericht wurde gelöscht");
                }

            }

            }
    }
}
