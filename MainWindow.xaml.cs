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
            String filePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true) { 
                filePath= openFileDialog.FileName;
                test.Content = openFileDialog.FileName;
            }

            using (var reader = new StreamReader("D:\\Perfil\\DescargasDIVIPOLA-_C_digos_municipios.csv"))
            {
                test.Content = reader.ReadLine();
            }
        }
    }
    /*
    public class Municipios
    {
        public String Code { get; set; }

        public String CodeMuni { get; set; }

        public string NameDep { get; set; }

        public string NameMuni { get; set; }

        public string Type { get; set; }
    }
    */
}
