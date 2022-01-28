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
        
        public MainWindow()
        {
            
            InitializeComponent();
           
        }

        private void ButtonGenerateReportCLick(object sender, RoutedEventArgs e)
        {
            combobox.Items.Add("A");
        }

        private void ButtonImportFile(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true) { 
               
               
            }
            List<Municipios> muni = new List<Municipios>();
            using (var reader = new StreamReader(openFileDialog.FileName))
            {
                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    String[] lines = line.Split(',');
                    test.Content = line;
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
