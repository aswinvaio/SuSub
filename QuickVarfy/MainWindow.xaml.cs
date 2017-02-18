using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using System.Threading;

namespace QuickVarfy
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog m = new OpenFileDialog();
            m.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls";
            if (m.ShowDialog() == true)
                txtFile.Text = m.FileName;
        }

        private void btnBrowseDir_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if(result.ToString()=="OK"){
                    txtDir.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;



            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
        }
    }
}
