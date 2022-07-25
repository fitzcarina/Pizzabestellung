using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaktionslogik für Hinzufügen.xaml
    /// </summary>
    public partial class Hinzufügen : Window
    {
        public Hinzufügen()
        {


            InitializeComponent();
            //Ueberschrift.Content = "Bitte wählen Sie den Mitarbeiter, den Sie bearbeiten möchten";
            using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select  * from tbl_Pizzabestellungen", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Speisekarte.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                }
                reader.Close();

              
            }
        }
     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {



            if (Speisekarte.SelectedItem == null)
            {

                MessageBox.Show("Bitte wählen Sie ein Gericht aus ");
            }
            else
            {
                string speise = Convert.ToString(Speisekarte.SelectedItem);
                bestelltes.Content = speise;
                string[] spalten = speise.Split(" ");
                // string[] spalten = speise.Split(" ");
                int[] Nudelgerichte = { 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 86, 87, 88, 89, 90 };
                int berechnen = spalten.Length;
                string benutzer = Environment.UserName;
                int länge = spalten.Length;
                //string preis = spalten[länge-1];
                double preis_d = Convert.ToDouble(spalten[länge - 1]);
                for (int i = 0; i < Nudelgerichte.Length; i++)
                {
                 

                    int spalten_nudeln = Convert.ToInt32(spalten[0]);
                    if (spalten_nudeln == Nudelgerichte[i])
                    {

                        //Nudelart.Visibility = Visibility.Collapsed;
                        if (Nudelart.Text.ToString() != "Rigatoni" && Nudelart.Text.ToString() != "Spaghetti" && Nudelart.Text.ToString() != "Tagliatelle")
                        {

                            MessageBox.Show("Bitte geben Sie eine Nudelart an: Rigationi, Spaghetti, Tagliatelle");
                        }
                        else
                        {


                        }
                    }
                }


                string wunsch = Nudelart.Text.ToString();
                string[] gespalten_wunsch = wunsch.Split(" ");
                for(int h= 0; h<gespalten_wunsch.Length; h++)
                {
                    if (gespalten_wunsch[0] == "ohne" || gespalten_wunsch[0] == "Ohne" || gespalten_wunsch[0] == "nicht " || gespalten_wunsch[0] == "Nicht" || gespalten_wunsch[0] == "")
                    {
                        preis_d = preis_d;
                    }
                    else
                    {

                        if (gespalten_wunsch[h]== "mit" || gespalten_wunsch[h] == "Mit" || gespalten_wunsch[h] == "Bitte" || gespalten_wunsch[h] == "bitte")
                        {

                        }
                        else
                        {
                            preis_d = preis_d + 0.5;
                        }
                      
                    }
                }

                // MessageBox.Show(spalten[j]);
                Class1.sqlInsert(benutzer, spalten[2], spalten[0], Nudelart.Text.ToString(), preis_d);

            }
              
       

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bestelltes.Content = Convert.ToString(Speisekarte.SelectedItem);
        }
    }

     
        
    }



