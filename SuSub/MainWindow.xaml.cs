using System;
using System.Collections.Generic;
using System.Globalization;
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

        int[] prefix = new int[5000];
        // 0 Normal 
        // 1 Superscript 
        // 2 Subscript


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
            string toPreview = "";
            for (int i = 0; i < userIn.Length; i++)
            {
                switch (prefix[i])
                {
                    case 1: toPreview += "^^";
                        break;
                    case 2: toPreview += "^v";
                        break;
                }
                toPreview += userIn[i];
            }

            txtUserPreview.Text = toPreview;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserIn.Text))
            {
                txtOutput.Text += txtUserPreview.Text;
                txtOutput.Text += "\n";
                txtUserIn.Text = "";
                txtUserPreview.Text = "";
                rbNorm.IsChecked = true;
            }
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
                    break;
                case Key.Right:
                    rbNorm.IsChecked = true;
                    break;
            }
        }

        private void txtUserIn_keyUp(object sender, KeyEventArgs e)
        {
            txtUserIn_txtChnged(); 
        }

        private void txtUserIn_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtUserIn_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int lenght = txtUserIn.Text.Length;
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
                case Key.Back :
                    prefix[lenght] = 0;
                    break;
                default: prefix[lenght] = getCharMode();
                    break;
            }
        }
        public int getCharMode()
        {
            if (rbNorm.IsChecked==true) return 0;
            if (rbSup.IsChecked==true) return 1;
            if (rbSub.IsChecked == true) return 2;
            return -1;
        }

        private void btnClearInput_Click(object sender, RoutedEventArgs e)
        {
            txtUserIn.Text = "";
        }

        private void btnClearOutput_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "";
        }

        private void btnCopyOutput_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
        }
    }
}
