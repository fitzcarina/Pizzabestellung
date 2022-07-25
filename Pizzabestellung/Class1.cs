using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pizzabestellung
{
    internal class Class1
    {



    }

  public static void sqlInsert(string id, string sql_hilfe, string vorname, bool vorname_p, bool nachname_p, string nachname, string handy, bool kurzwahl_p, int n, string durchwahl_string, string kurzwahl_string, bool durchwahl_p)
{
    System.Data.SqlClient.SqlConnection sqlConnection1 =
                           new System.Data.SqlClient.SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes");

    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
    cmd.CommandType = System.Data.CommandType.Text;

    //if (kurzwahl_string == "" && durchwahl_string == "")

    //{
    cmd.CommandText = " Insert tbl_Telefonnummern (Vorname, Nachname, DW, Kurzw ,Handy) VALUES ('" + vorname + "','" + nachname + "','" + durchwahl_string + "','" + kurzwahl_string + "','" + handy + "')";
    cmd.Connection = sqlConnection1;
    sqlConnection1.Open();
    cmd.ExecuteNonQuery();
    sqlConnection1.Close();
    MessageBox.Show("Die Telefonnummern wurden erfolgreich Hinzugefügt");
}

}