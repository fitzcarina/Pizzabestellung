using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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


namespace test_aufbau
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void liste(object sender, RoutedEventArgs e)
        {
           
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                using (SqlConnection conn = new SqlConnection("server=lt-080120\\Sqlexpress01;database=schnupp; trusted_connection=yes"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select Besteller, Nummer, Wunsch, Preis from tbl_Galodoro ", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    string[] Besteller = new string[5000];
                    string[] Nummer = new string[5000];
                    string[] Wunsch = new string[5000];
                    string[] Preis = new string[5000];
                    string[] Preis_string = new string[5000];


                    for (int i = 0; reader.Read(); i++)
                    {
                        Besteller[i] = reader[0].ToString();

                        Nummer[i] = reader[1].ToString();
                        Wunsch[i] = reader[2].ToString();
                        Preis_string[i] = reader[3].ToString();
                        Preis[i] = reader[3].ToString();
                  



                    }
                    reader.Close();
                    //Preis_string[]= Convert.ToDouble(Preis[]);
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;

                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    worksheet.Range["A1"].Text = "Besteller";

                    worksheet.Range["B1"].Text = "Nummer";
                    worksheet.Range["C1"].Text = "Wunsch";
                    worksheet.Range["D1"].Text = "Preis";
                   
                    double ergebnis = 0;
                    double end_ergebnis = 0;

                    for (int i = 0; i < Besteller.Length; i++)
                    {
                        string a = "A" + (i + 2);
                        worksheet.Range[a].Text = Besteller[i];


                        string b = "B" + (i + 2);
                        worksheet.Range[b].Text = Nummer[i];

                        string c = "C" + (i + 2);
                        worksheet.Range[c].Text = Wunsch[i];
                        //for(int j =0; j< Preis_string.Length; j++)
                        //{

                        worksheet["D"+(i+2)].First().Value =Preis_string[i];
                         ergebnis= Convert.ToDouble(Preis_string[i]);
                        end_ergebnis = end_ergebnis + Convert.ToDouble(ergebnis);
                     

                    }
                    worksheet.Range["F2"].Text = "Gesamtbetrag";
                    worksheet.Range["G2"].Text = Convert.ToString(end_ergebnis);
                    workbook.SaveAs("Pizzabestellung.xlsx");
                    this.Close();
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(@"C:\Users\c.fitz\source\repos\Pizzabestellung\test aufbau - Kopie - Kopie\test aufbau\bin\Debug\net6.0-windows\Pizzabestellung.xlsx")
                    {
                        UseShellExecute = true
                    };
                    p.Start();

                }

            }

        }
    

    private void hinzufügen(object sender, RoutedEventArgs e)
        {


            Window Hinzufügen = new Hinzufügen();
            Hinzufügen.ShowDialog();


        }
       

        private void bearbeiten(object sender, RoutedEventArgs e)
        {
            Window Bearbeitenneu = new Bearbeitenneu();
            Bearbeitenneu.ShowDialog();


        }

        private void löschen(object sender, RoutedEventArgs e)
        {
            Window loeschen = new loeschen();
            loeschen.ShowDialog();


        }

        private void Speiseplan_löschen(object sender, RoutedEventArgs e)
        {


            Window speiseplan_löschen = new speiseplan_löschen();
            speiseplan_löschen.ShowDialog();




        }

        private void verändern(object sender, RoutedEventArgs e)
        {


            Window verändern = new verändern();
            verändern.ShowDialog();


        }
    }
}
