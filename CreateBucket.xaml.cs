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
using System.Windows.Shapes;


namespace Lab1_AWS_S3
{
    /// <summary>
    /// Interaction logic for CreateBucket.xaml
    /// </summary>
    public partial class CreateBucket : Window
    {
        public CreateBucket()
        {
            InitializeComponent();
            Loaded += CreateBucket_Loaded;
        }

        //Buttons 
        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new MainWindow());            
        }

        private async void CreateBucket_Loaded(object sender, RoutedEventArgs e)
        {
            await DisplayBucketList();
        }

        private async void CreateBucket_Click(object sender, RoutedEventArgs e)
        {
            BucketOps op = new BucketOps();
            string bucketName = bucketNameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(bucketName) && IsValidBucketName(bucketName))
            {
                if (!await BucketExists(bucketName))
                {
                    validationMessage.Text = "";
                    await op.CreateBucket(bucketName);
                    MessageBox.Show($"Bucket '{bucketName}' created successfully!");
                    await DisplayBucketList();
                }
                else
                {
                    MessageBox.Show($"Bucket '{bucketName}' already exists. Please choose a different name.");
                }
            }
            else
            {
                validationMessage.Text = "Bucket name must not contain uppercase characters and white space.";
            }
        }

        //Logic to check if bucket name is valid
        private bool IsValidBucketName(string bucketName)
        {
            return !bucketName.Any(char.IsUpper) && !bucketName.Contains(" ");
        }

        private async Task<bool> BucketExists(string bucketName)
        {
            // Logic to check if the bucket already exists
            BucketOps op = new BucketOps();
            var bucketList = await op.GetBucketList();
            return bucketList.Any(b => b.BucketName.Equals(bucketName, StringComparison.OrdinalIgnoreCase));
        }

        private async Task DisplayBucketList() 
        {
            BucketOps op = new BucketOps();
            var bucketList = await op.GetBucketList();
            existingBucketsDataGrid.ItemsSource = bucketList;

        }

        //Helper functions
        private void ShowWindow(Window window)
        {
            window.Show();
            CloseWindow();
        }

        private void CloseWindow()
        {
            this.Close();
        }
                
    }
}
