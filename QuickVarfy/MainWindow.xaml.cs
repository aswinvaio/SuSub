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
using OfficeOpenXml;
using System.Data;

namespace QuickVarfy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string col_Name = "A";
        string col_File = "B";
        int row_Start = 2;
        int row_End = -1;
        bool col_configManually = false;
        bool row_configManually = false;

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
            if (txtFile.Text != "" && txtDir.Text != "")
                searchDirectory(txtFile.Text, txtDir.Text);

            //Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
        }

        private bool searchDirectory(string fileName, string DirName)
        {
            //try
            //{
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(fileName)))
                {
                    ExcelWorksheet myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                    int totalRows = myWorksheet.Dimension.End.Row;
                    int totalColumns = myWorksheet.Dimension.End.Column;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name");
                    dt.Columns.Add("File");
                    for (int i = row_Start; i <= totalRows; i++)
                    {

                        dt.Rows.Add(myWorksheet.Cells[i, 1].Text, myWorksheet.Cells[i, 2].Text);
                    }
                    List<string> listMIssedFiles = new List<string>();
                    listMIssedFiles.Add("Found : ");
                    int found = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        string filepath = DirName + "\\" + dr[1].ToString();
                        if (!File.Exists(filepath))
                        {
                            listMIssedFiles.Add(dr[0].ToString() + " : " + dr[1].ToString() + " is missing ");
                        }
                        else
                        {
                            found++;
                        }
                    }
                    listMIssedFiles[0] += found;
                    lbResult.ItemsSource = listMIssedFiles;
                }
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return false;
            //}
            return true;
        }

        private void btnExcelConfig_Click(object sender, RoutedEventArgs e)
        {
            ExcelConfig ec = new ExcelConfig();
            ec.Owner = this;
            ec.ShowDialog();
        }
    }
}
