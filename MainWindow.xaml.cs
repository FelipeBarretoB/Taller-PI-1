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
        public MainWindow()
        {
            muni = new List<Municipios>();
            InitializeComponent();
            
           
        }

        private void ButtonGenerateReportCLick(object sender, RoutedEventArgs e)
        {
            char x;
            for(int i = 65; i <= 90; i++)
            {
                x = Convert.ToChar(i);
                combobox.Items.Add(x.ToString());
            }

        }

        private void ButtonSearchCLick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("cualquier mensaje");
            List<Municipios> tem = new List<Municipios>();
            string name;
            string cb;
            string str;
            string x;
            

            for (int i = 0; i < 1/*muni.Count*/; i++)
            {
                
                str = muni[i].NameMuni;
                name = str[0].ToString();
                cb = combobox.SelectionBoxItemStringFormat;
                test.Content = cb;

                if (string.Equals(name, cb, StringComparison.OrdinalIgnoreCase))
                {
                    /*if(muni[i] == null)
                    {
                        i = 99999;
                        test.Content = "null";
                    }*/
                    tem.Add(muni[i]);
                    x = Convert.ToString(tem.Count);
                    //test.Content = x;
                }
                else
                {
                    
                    //test.Content = "not equals";
                }
            }
            tabla.ItemsSource = tem;
        }

        private void ButtonImportFile(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true) { 
               
               
            }
            //List<Municipios> muni = new List<Municipios>();
            using (var reader = new StreamReader(openFileDialog.FileName))
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

        public string NameDep { get; set; }

        public string NameMuni { get; set; }

        public string Type { get; set; }
        
    }
    
}
