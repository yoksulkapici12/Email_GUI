using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace EmailClient
{
    public partial class SettingsWindow : Window
    {


        private EmailClientViewModel viewModel;

        public SettingsWindow(EmailClientViewModel sharedViewModel)
        {
            InitializeComponent();
            viewModel = sharedViewModel;
            categoriesList.ItemsSource = viewModel.Categories;

        }

        private ObservableCollection<string> categories;

        public SettingsWindow()
        {
            InitializeComponent();
            categories = new ObservableCollection<string>(GetCategories());
            categoriesList.ItemsSource = categories;
        }

        private List<string> GetCategories()
        {
            var settings = Properties.Settings.Default.Categories;
            return new List<string>(settings.Split(';'));
        }

        private void SaveCategories()
        {
            Properties.Settings.Default.Categories = string.Join(";", viewModel.Categories);
            Properties.Settings.Default.Save();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InputDialog("Add Category");
            if (dialog.ShowDialog() == true)
            {
                var newCategory = dialog.ResponseText;
                if (!string.IsNullOrWhiteSpace(newCategory) && !viewModel.Categories.Contains(newCategory))
                {
                    viewModel.Categories.Add(newCategory);
                    SaveCategories();
                }
                else
                {
                    MessageBox.Show("Invalid or duplicate category name.");
                }
            }
        }
        private void SaveBackupSettings_Click(object sender, RoutedEventArgs e)
        {
            viewModel.BackupEnabled = chkEnableBackup.IsChecked ?? false;
            viewModel.BackupInterval = int.Parse(txtBackupInterval.Text);
        }


        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (categoriesList.SelectedItem != null)
            {
                var currentCategory = categoriesList.SelectedItem.ToString();
                var dialog = new InputDialog("Edit Category", currentCategory);
                if (dialog.ShowDialog() == true)
                {
                    var newCategory = dialog.ResponseText;
                    if (!string.IsNullOrWhiteSpace(newCategory) && !viewModel.Categories.Contains(newCategory))
                    {
                        int index = viewModel.Categories.IndexOf(currentCategory);
                        viewModel.Categories[index] = newCategory;
                        SaveCategories();
                    }
                    else
                    {
                        MessageBox.Show("Invalid or duplicate category name.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to edit.");
            }
        }


        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (categoriesList.SelectedItem != null)
            {
                viewModel.Categories.Remove(categoriesList.SelectedItem as string);
                SaveCategories(); 
            }
        }

    }
}
