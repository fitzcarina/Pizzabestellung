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
    /// Interaktionslogik für richtigloeschen.xaml
    /// </summary>
    public partial class richtigloeschen : Window
    {
        public string geben;
        public string gericht;

        public richtigloeschen(string geben, string gericht)
        {
            InitializeComponent();
            this.geben = geben;
            ueberschrift.Content = "Sind Sie sicher das Sie das Gericht : "+gericht;
            ueberschrift2.Content = "unwiederruflich löschen möchten?";
        }

        private void Ja(object sender, RoutedEventArgs e)
        {
           
            string text = "";
          // string  text = geben;
            string Nachname = "";
            string ID = "";


            //Nachname.Text = nach;
            using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
            {
                conn.Open();
                // var Vorname = Nachname.Text.ToString();
                string[] authorlist = geben.Split(" ");
                string test = authorlist[1];
                int nudelntest = Convert.ToInt32(authorlist[0]);

                int[] nudeln = { 0,15,16,17,18,19,20,21,22,23,24,86,87,88,89,90 };
                for(int i =  1; i<nudeln.Length; i++)
                {
                    if (nudelntest == nudeln[i])
                    {

                    }
                }
                // Vornames.Text = authorlist[1];
                ID = authorlist[2];
                string benutzer = Environment.UserName;
                SqlCommand cmd = new SqlCommand("Delete  from tbl_Galodoro where Gericht='" + test + "' AND Besteller='"+benutzer+"'", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                }
                reader.Close();


            }



                       MessageBox.Show("User wurde unwiedeerruflich gelöscht !");
                   }
            
            private void Nein(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
    }


}
    
