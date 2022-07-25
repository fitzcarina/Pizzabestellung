using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace test_aufbau
{
    internal class Class1 : Hinzufügen
    {

        



        public static void sqlGerichtHinzufügen(string nummer, string gericht, string preis_d)
        {
           
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                               new System.Data.SqlClient.SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = " Insert  tbl_Pizzabestellungen (Nummer,Gericht, Preis) VALUES ('" + nummer + "','" + gericht + "','" + preis_d + "')";
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Das Gericht wurde erfolgreich Hinzugefügt");
            
           
        }
        public static void sqlInsert(string besteller, string gericht, string nummer, string wunsch, double preis_d)
        {

            //preis = Convert.ToString(preis_d);
            
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                                   new System.Data.SqlClient.SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            //if (kurzwahl_string == "" && durchwahl_string == "")

            //{
            cmd.CommandText = " Insert  tbl_Galodoro (Besteller,Nummer,Gericht, Preis, Wunsch ) VALUES ('" + besteller + "','"+nummer+"','"+gericht+"','"+preis_d+"','"+wunsch+"')";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Das Gericht wurde erfolgreich Hinzugefügt");
        }

        public static void wunsch(string wunsch, string benutzer, string gericht, string gericht_bz)
        {

        }
        public static void sqlabfrage(string id, string sql_hilfe, string vorname, bool vorname_p, bool nachname_p, string nachname, string handy, bool kurzwahl_p, int n, string durchwahl_string, string kurzwahl_string, bool durchwahl_p)

        {

         
            if (sql_hilfe == "update")
            {
                
                using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
                {


                    using (SqlCommand cmd = new SqlCommand(@"UPDATE tbl_Telefonnummern set   Handy=" + handy + ", Nachname= '" + nachname + "', DW= " + durchwahl_string + ", kurzw =" + kurzwahl_string + "where ID =" + id, conn))

                    {
                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Telefonnummer wurde erfolgreich bearbeitet ");
                    }
                }
            }
            else
            {
                System.Data.SqlClient.SqlConnection sqlConnection1 =
                                    new System.Data.SqlClient.SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                //if (kurzwahl_string == "" && durchwahl_string == "")

                //{
                cmd.CommandText = sql_hilfe + " tbl_Telefonnummern (Vorname, Nachname, DW, Kurzw ,Handy) VALUES ('" + vorname + "','" + nachname + "','" + durchwahl_string + "','" + kurzwahl_string + "','" + handy + "')";
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Die Telefonnummern wurden erfolgreich Hinzugefügt");
            }
                }
            }
        }

        

                
