using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows;
using System.Linq;
using System.Collections.Generic;

namespace EmailClient
{




    public partial class ComposeWindow : Window 
    {
        public string DefaultSender { get; set; }
        private Email currentEmail = new Email();
        private EmailClientViewModel viewModel;

        private List<string> attachedFiles = new List<string>();


        public ComposeWindow(EmailClientViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel; 
            DataContext = this.viewModel; 
        }

        public ComposeWindow(string selectedMailbox, EmailClientViewModel viewModel)
        {
            InitializeComponent();
            if (viewModel == null)
            {
                this.viewModel = new EmailClientViewModel();
            }
            else
            {
                this.viewModel = viewModel;
            }

            DefaultSender = selectedMailbox;
            this.DataContext = this.viewModel;
        }


        public void PrepareEmailForReply(Email email, bool replyAll)
        {
            
            txtTo.Text = email.Sender; 
            if (replyAll)
            {
                CcRecpt.Text = email.CcRecipients; // Include Cc recipients if reply all
            }
            txtSubject.Text = "Re: " + email.Subject;
            txtBody.Text = $"\n\nOn {email.SentDate}, {email.Sender} wrote:\n{email.Body}";
        }

        public void PrepareEmailForForward(Email email)
        {
            txtSubject.Text = "Fwd: " + email.Subject;
            txtBody.Text = $"\n\nForwarded message:\nOn {email.SentDate}, {email.Sender} wrote:\n{email.Body}";
        }


        private void btnDraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentEmail.Sender = cmbSender.SelectedItem as string;
                currentEmail.Receiver = txtTo.Text;
                currentEmail.CcRecipients = CcRecpt.Text;
                currentEmail.Subject = txtSubject.Text;
                currentEmail.Body = txtBody.Text;
                currentEmail.SentDate = DateTime.Now;
                currentEmail.IsDraft = true;

                // Find the draft folder for the current sender
                var senderFolder = viewModel.Folders.FirstOrDefault(folder => folder.Name == currentEmail.Sender);
                if (senderFolder != null)
                {
                    
                    var draftsFolder = senderFolder.SubFolders.FirstOrDefault(sf => sf.Name == "Drafts");
                    if (draftsFolder != null)
                    {
                        draftsFolder.Emails.Add(currentEmail);
                        MessageBox.Show("Draft saved.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Drafts folder not found.");
                       
                    }
                }
                else
                {
                    MessageBox.Show("Sender's folder not found.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentEmail.Sender = cmbSender.Text;
                currentEmail.Receiver = txtTo.Text;
                currentEmail.CcRecipients = txtTo.Text;
                currentEmail.Subject = txtSubject.Text;
                currentEmail.Body = txtBody.Text;
                currentEmail.SentDate = DateTime.Now;
                currentEmail.IsDraft = true;
                var senderFolder = viewModel.Folders.FirstOrDefault(folder => folder.Name == currentEmail.Sender);


                if (senderFolder != null)
                {

                    var draftsFolder = senderFolder.SubFolders.FirstOrDefault(sf => sf.Name == "Sent");
                    if (draftsFolder != null)
                    {
                        draftsFolder.Emails.Add(currentEmail);
                        MessageBox.Show($"Sending Email:\nFrom: {currentEmail.Sender}\nTo: {currentEmail.Receiver}\nSubject: {currentEmail.Subject}\nBody: {currentEmail.Body}\nCategory: {currentEmail.Category} ");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Sent folder not found.");

                    }
                }
                else
                {
                    MessageBox.Show("Sender's folder not found.");
                }
               
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnAt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Multiselect = true;  
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        currentEmail.AddAttachment(filePath);
                        attachedFiles.Add(filePath); 
                        totalAttachedFiles.Items.Add(System.IO.Path.GetFileName(filePath)); 
                    }

                    MessageBox.Show("Attachments added successfully.");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCategory.SelectedItem != null)
            {
                currentEmail.Category = cmbCategory.SelectedItem.ToString();
            }
        }

    }
}
