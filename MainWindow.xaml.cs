using System;
using System.Collections.Generic;
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
using LiveCharts;
using LiveCharts.Wpf;
using System.IO;
using Microsoft.Win32;

namespace Taller_PI_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Municipios> muni;

        String fileName;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public MainWindow()
        {
            muni = new List<Municipios>();
            InitializeComponent();

            char x;
            for (int i = 65; i <= 90; i++)
            {
                x = Convert.ToChar(i);
                combobox.Items.Add(x.ToString());
            }
            
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Tipos",
                    Values = new ChartValues<double> { 0, 0, 0}
                }
            };


            Labels = new[] { "Municipio", "Isla", "Area no municipal" };
            Formatter = value => value.ToString("N");

            DataContext = this;

            



        }
        int c = 10;
        private void ButtonGenerateReportCLick(object sender, RoutedEventArgs e)
        {
           
            if(!combobox.Text.Equals("")) { 
                char[] comboText= combobox.Text.ToUpper().ToCharArray();
                List<Municipios> temp = new List<Municipios>();
                foreach(Municipios name in muni)
                {
                    
                    char[] compare = name.NameMuni.ToCharArray();
                    
                    if (comboText[0].CompareTo(compare[0])==0)
                    {
                        temp.Add(name);
                    }
                    
                    
                }
                tabla.ItemsSource = null;
                tabla.ItemsSource = temp;
                test.Content = "Datos filtrados";

                int numMuni = 0;
                int numIsla = 0;
                int numAr = 0;
               
                foreach(Municipios type in temp)
                {
                    if (type.Type.Equals("Municipio"))
                    {
                        numMuni++;
                    }else if (type.Type.Equals("Isla"))
                    {
                        numIsla++;
                    }
                    else
                    {
                        numAr++;
                    }
                }
                SeriesCollection[0] = new RowSeries
                {
                    Title = "Tipos",
                    Values = new ChartValues<double> { numMuni, numIsla, numAr }
                };

                Labels = new[] { "Maria", "Susan", "Charles" };
                Formatter = value => value.ToString("N");

                DataContext = this;
            }
            else
            {
         
                
             
                tabla.ItemsSource = null;
                tabla.ItemsSource = muni;
                test.Content = "Selecione una letra";
            }

            //combobox.Items.Add("A");
        }




        private void ButtonImportFile(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true) { 
               
               
            }
            fileName = openFileDialog.FileName;
            //List<Municipios> muni = new List<Municipios>();
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    String[] lines = line.Split(',');
                    //test.Content = line;
                    muni.Add(new Municipios() { Code = lines[0], CodeMuni=lines[1], NameDep=lines[2], NameMuni=lines[3], Type=lines[4]});
                }
            

            }
            tabla.ItemsSource = muni;
        }
    }


    public class Municipios
    {
        public String Code { get; set; }
        
        public String CodeMuni { get; set; }

        public String NameDep { get; set; }

        public String NameMuni { get; set; }

        public String Type { get; set; }
        
    }
    
}
