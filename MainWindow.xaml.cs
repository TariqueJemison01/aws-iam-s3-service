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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1_AWS_S3
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

        //Buttons that navigates to create bucket, upload files and exit window
        private void CreateBucket_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new CreateBucket());            
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {            
            ShowWindow(new Upload());            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void ShowWindow(Window window) { 
            window.Show();
            CloseWindow();
        }

        private void CloseWindow() {
            this.Close();
        }
    }
}
