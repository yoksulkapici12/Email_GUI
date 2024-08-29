using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Windows.Media.Animation;


namespace EmailClient
{

    public class BooleanToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
            {
                return Brushes.LightGoldenrodYellow; 
            }
            return Brushes.Transparent; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MainWindow : Window
    {
        public EmailClientViewModel ViewModel { get; set; }
        public MainWindow()
        {

            InitializeComponent();
            ViewModel = new EmailClientViewModel();
            DataContext = ViewModel;



        }

        private void HandleReply(bool replyAll)
        {
            if (emailList.SelectedItem is Email selectedEmail)
            {
                var composeWindow = new ComposeWindow(ViewModel);
                composeWindow.PrepareEmailForReply(selectedEmail, replyAll);
                composeWindow.Show();
            }
        }

        private void HandleForward()
        {
            if (emailList.SelectedItem is Email selectedEmail)
            {
                var composeWindow = new ComposeWindow(ViewModel);
                composeWindow.PrepareEmailForForward(selectedEmail);
                composeWindow.Show();
            }
        }

        private void Reply_Click(object sender, RoutedEventArgs e)
        {
            HandleReply(false);
        }

        private void ReplyAll_Click(object sender, RoutedEventArgs e)
        {
            HandleReply(true);
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            HandleForward();
        }




        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                ViewModel.LoadEmails(openFileDialog.FileName);
                // Update UI or refresh data views if necessary
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                ViewModel.SaveEmails(saveFileDialog.FileName);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            EmailClientViewModel vm = (EmailClientViewModel)this.DataContext; // Adjusted to correct class name
            vm.StartRotation(); // This method must exist in EmailClientViewModel
            Storyboard storyboard = this.FindResource("RotateAnimation") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Completed += (s, args) =>
                {
                    // Reset the angle to start position for next use
                    RotateTransform transform = FindRotateTransform(sender as UIElement);
                    if (transform != null)
                    {
                        transform.Angle = 0;
                    }
                };
                storyboard.Begin(this);
            }
        }

        private RotateTransform FindRotateTransform(UIElement element)
        {
            if (element != null && element.RenderTransform is RotateTransform)
            {
                return element.RenderTransform as RotateTransform;
            }
            return null;
        }







        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btndel_Click(object sender, RoutedEventArgs e)
        {
            if (emailList.SelectedItem is Email selectedEmail && ViewModel.SelectedFolder != null)
            {
                // Retrieve the Storyboard from resources
                Storyboard storyboard = this.FindResource("FadeOutStoryboard") as Storyboard;

                if (storyboard != null)
                {
                    // Clone the storyboard to avoid affecting the original resource
                    Storyboard clonedStoryboard = storyboard.Clone();

                    // Configure the storyboard to target the selected item's UI element in the ListView
                    ListViewItem listViewItem = emailList.ItemContainerGenerator.ContainerFromItem(selectedEmail) as ListViewItem;
                    if (listViewItem != null)
                    {
                        Storyboard.SetTarget(clonedStoryboard, listViewItem);

                        // When the animation completes, remove the item
                        clonedStoryboard.Completed += (s, args) =>
                        {
                            MoveOrDeleteEmail(selectedEmail);
                        };

                        // Start the animation
                        clonedStoryboard.Begin();
                    }
                    else
                    {
                        // If the UI element is not available, delete immediately
                        MoveOrDeleteEmail(selectedEmail);
                    }
                }
            }
            else
            {
                MessageBox.Show("No email selected.");
            }
        }

        private void MoveOrDeleteEmail(Email email)
        {
            if (ViewModel.SelectedFolder.Name == "Trash")
            {
                ViewModel.SelectedFolder.Emails.Remove(email);
                MessageBox.Show("Email permanently deleted.");
            }
            else
            {
                var trashFolder = ViewModel.Folders.SelectMany(f => f.SubFolders).FirstOrDefault(sf => sf.Name == "Trash");
                if (trashFolder != null)
                {
                    ViewModel.SelectedFolder.Emails.Remove(email);
                    trashFolder.Emails.Add(email);
                    MessageBox.Show("Email moved to Trash.");
                }
                else
                {
                    MessageBox.Show("Trash folder not found.");
                }
            }
        }

        private void OnMouseEnterHandler(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            StackPanel detailPanel = FindDetailPanel(border); // Implement this method to find the detail panel
            if (detailPanel != null)
            {
                DoubleAnimation animation = new DoubleAnimation(100, TimeSpan.FromSeconds(0.3));
                detailPanel.BeginAnimation(StackPanel.HeightProperty, animation);
            }
        }

        private void OnMouseLeaveHandler(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            StackPanel detailPanel = FindDetailPanel(border); // Implement this method to find the detail panel
            if (detailPanel != null)
            {
                DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
                detailPanel.BeginAnimation(StackPanel.HeightProperty, animation);
            }
        }

        // Utility method to find the detail panel within the visual tree
        private StackPanel FindDetailPanel(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                // If the child is the StackPanel we're looking for, return it
                if (child is StackPanel panel && panel.Name == "detailPanel")
                {
                    return panel;
                }

                // Recursively search the child's children
                var result = FindDetailPanel(child);
                if (result != null)
                    return result;
            }

            // If no matching child is found, return null
            return null;
        }






        private void MailboxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TreeViewItem item && item.DataContext is EmailFolder folder)
            {
                
                if (folder.Name == "Inbox" || folder.Name == "Sent" || folder.Name == "Drafts" || folder.Name == "Trash" || folder.Name == "Important")
                {
                    
                    ViewModel.SelectedFolder = folder;
                }
            }
        }


        private void EmailList_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (emailList.SelectedItem is Email selectedEmail)
            {
                EditEmailWindow editWindow = new EditEmailWindow(selectedEmail, false);
                editWindow.ShowDialog();
            }
        }


        private void New_Click(object sender, RoutedEventArgs e)
        {
            var composeWindow = new ComposeWindow("someMailbox@sabanciuniv.edu", ViewModel);
            composeWindow.Show();
        }


        private void Compose_Click(object sender, RoutedEventArgs e)
        {
            var composeWindow = new ComposeWindow("someMailbox@sabanciuniv.edu", ViewModel);
            composeWindow.Show();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow(ViewModel); 
            settingsWindow.ShowDialog();
        }

        private void EmailSearchControl_SearchChanged(object sender, EmailSearchControl.SearchEventArgs e)
        {
            
        }

        private void EmailSearchControl_ResetSearch(object sender, EventArgs e)
        {
            
        }

        private void emailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
