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

namespace SuSub
{
    /// <summary>
    /// by sourath.
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbNorm.IsChecked = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtUserIn_txtChnged()
        {
            string userIn = txtUserIn.Text;
            if (rbSub.IsChecked == true)
            {
                userIn = userIn.Insert(userIn.Length - 2, "0");
            }
            else if (rbSup.IsChecked == true)
            {
            }
            txtUserIn.Text = userIn;
            txtUserPreview.Text = userIn;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text += txtUserIn.Text;
            txtOutput.Text += "\n";
            txtUserIn.Text = "";
            txtUserPreview.Text = "";
            rbNorm.IsChecked = true;
        }

        private void Window_keyUp(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Enter:
                    btnAdd_Click(null, null);
                    break;
                case Key.Up:
                    rbSup.IsChecked = true;
                    break;
                case Key.Down:
                    rbSub.IsChecked = true;
                    break;
                case Key.Left:
                    rbNorm.IsChecked = true;
                    e.Handled = true;
                    break;
                case Key.Right:
                    rbNorm.IsChecked = true;
                    break;
            }
        }

        private void txtUserIn_keyUp(object sender, KeyEventArgs e)
        {
            txtUserIn_txtChnged();
            //txtUserIn.po
        }

        private void txtUserIn_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.Enter:
            //    case Key.Up:
            //    case Key.Down:
            //    case Key.Left:
            //    case Key.Right:
            //        e.Handled = true;
            //        break;
            //}
        }

        private void txtUserIn_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                
                case Key.Up:
                    rbSup.IsChecked = true;
                    e.Handled = true;
                    break;
                case Key.Down:
                    rbSub.IsChecked = true;
                    e.Handled = true;
                    break;
                case Key.Left:
                    rbNorm.IsChecked = true;
                    e.Handled = true;
                    break;
                case Key.Right:
                    rbNorm.IsChecked = true;
                    e.Handled = true;
                    break;
            }

        }
    }
}
