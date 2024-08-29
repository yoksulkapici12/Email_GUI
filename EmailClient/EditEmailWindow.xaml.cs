using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EmailClient
{
    public partial class EditEmailWindow : Window
    {
        public Email CurrentEmail { get; private set; } 
        private List<string> attachedFiles = new List<string>(); 


        public EditEmailWindow(Email emailToEdit, bool isEditable)
        {
            InitializeComponent();
            this.CurrentEmail = emailToEdit;  
            this.DataContext = this.CurrentEmail;  

            txtReceiver.IsReadOnly = !isEditable;
            txtSubject.IsReadOnly = !isEditable;
            txtBody.IsReadOnly = !isEditable;
            CcRecpt.IsReadOnly = !isEditable;
            atach.IsEnabled = isEditable;
            LoadAttachments();
        }

        private void LoadAttachments()
        {
            lstAttachedFiles.Items.Clear();  
            foreach (var attachment in CurrentEmail.Attachments)
            {
                lstAttachedFiles.Items.Add(System.IO.Path.GetFileName(attachment));  
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        

        private void AttachFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Enable selecting multiple files
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    attachedFiles.Add(filePath); // Add file paths to the list
                    lstAttachedFiles.Items.Add(System.IO.Path.GetFileName(filePath)); // Display file names in the ListBox
                }
            }
        }
    }
}
