using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Win32;
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
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Window
    {
        private readonly BucketOps bucketOps;
        public Upload()
        {
            InitializeComponent();
            bucketOps = new BucketOps();


            // Attach an event handler for the ComboBox's drop-down opened event
            BucketComboBox.DropDownOpened += async (sender, e) => await PopulateBucketComboBox();
            BucketComboBox.SelectionChanged += async (sender, e) => await LoadBucketContents();
        }

        private async Task PopulateBucketComboBox()
        {
            try
            {
                List<CreateBucketResponse> buckets = await bucketOps.GetBucketList();
                BucketComboBox.ItemsSource = buckets;
                BucketComboBox.DisplayMemberPath = "BucketName";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bucket list: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadBucketContents()
        {
            try
            {
                if (BucketComboBox.SelectedItem != null)
                {
                    string selectedBucketName = ((CreateBucketResponse)BucketComboBox.SelectedItem).BucketName;

                    List<S3Object> objects = await bucketOps.GetBucketObjects(selectedBucketName);
                    ObjectGrid.ItemsSource = objects.Select(obj => new
                    {
                        ObjectName = obj.Key,
                        Size = obj.Size
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bucket contents: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Buttons
        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ObjectPathTextBox.Text = selectedFilePath;
            }
        }

        //Logic to upload to object to bucket
        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedObjectPath = ObjectPathTextBox.Text;

                if (BucketComboBox.SelectedItem != null)
                {
                    string selectedBucketName = ((CreateBucketResponse)BucketComboBox.SelectedItem).BucketName;

                    var fileTransferUtility = new TransferUtility(Helper.s3Client);

                    await fileTransferUtility.UploadAsync(selectedObjectPath, selectedBucketName);
                    Console.WriteLine("Upload completed");

                    MessageBox.Show("Object uploaded successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ObjectPathTextBox.Text = "";
                    await LoadBucketContents();
                }
                else
                {
                    MessageBox.Show("Please select a bucket before uploading.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"Error encountered on server. Message: '{ex.Message}' when writing an object", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unknown error. Message: '{ex.Message}' when writing an object", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new MainWindow());
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
