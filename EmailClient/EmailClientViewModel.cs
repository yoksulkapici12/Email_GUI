using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Threading.Tasks;




namespace EmailClient
{

   
    

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }

    public class EmailClientViewModel : INotifyPropertyChanged
    {

        private double _angle;
        public double Angle
        {
            get { return _angle; }
            set
            {
                if (_angle != value)
                {
                    _angle = value;
                    OnPropertyChanged(nameof(Angle));
                }
            }
        }



        public void StartRotation()
        {
            // Using Application.Current.Dispatcher to ensure UI thread is used, as UI updates should be on the UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                double targetAngle = 360;
                double step = 10;
                while (Angle < targetAngle)
                {
                    Angle += step; // Increment the angle
                    if (Angle > targetAngle)
                    {
                        Angle = targetAngle; // Correct overshooting
                    }
                    await Task.Delay(50); // Delay to slow down the animation
                }
            });
        }





        private bool _backupEnabled;
        public bool BackupEnabled
        {
            get => _backupEnabled;
            set
            {
                if (_backupEnabled != value)
                {
                    _backupEnabled = value;
                    OnPropertyChanged(nameof(BackupEnabled));
                }
            }
        }

        private int _backupInterval;
        public int BackupInterval
        {
            get => _backupInterval;
            set
            {
                if (_backupInterval != value)
                {
                    _backupInterval = value;
                    OnPropertyChanged(nameof(BackupInterval));
                }
            }
        }




        private ObservableCollection<string> _categories = new ObservableCollection<string>();
        public ObservableCollection<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }



        public void LoadCategoriesFromSettings()
        {
            Categories = new ObservableCollection<string>(Properties.Settings.Default.Categories.Split(';'));
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        private string _selectedSender;
        public ObservableCollection<string> AvailableSenders { get; set; } = new ObservableCollection<string> {
            "Dummy_42@sabanciuniv.edu",
            "ceza_sago_42@sabanciuniv.edu"
        };

        public ICommand EditCommand { get; private set; }

        public ObservableCollection<EmailFolder> Folders { get; set; } = new ObservableCollection<EmailFolder>();

        private EmailFolder _selectedFolder;
        public EmailFolder SelectedFolder
        {
            get => _selectedFolder;
            set
            {
                if (_selectedFolder != value)
                {
                    _selectedFolder = value;
                    OnPropertyChanged(nameof(SelectedFolder));
                    OnPropertyChanged(nameof(CurrentEmails));  

                }
            }
        }

        public string SelectedSender
        {
            get => _selectedSender;
            set
            {
                if (_selectedSender != value)
                {
                    _selectedSender = value;
                    OnPropertyChanged(nameof(SelectedSender));
                }
            }
        }


        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    PerformSearch(); 
                }
            }
        }

        private string _selectedSearchCategory;
        public string SelectedSearchCategory
        {
            get => _selectedSearchCategory;
            set
            {
                if (_selectedSearchCategory != value)
                {
                    _selectedSearchCategory = value;
                    OnPropertyChanged(nameof(SelectedSearchCategory));
                    PerformSearch();
                }
            }
        }

        public ICommand ResetSearchCommand { get; }

        private Email _selectedEmail;
        public Email SelectedEmail
        {
            get => _selectedEmail;
            set
            {
                if (_selectedEmail != value)
                {
                    _selectedEmail = value;
                    OnPropertyChanged(nameof(SelectedEmail));
                }
            }
        }

        

        public ObservableCollection<Email> CurrentEmails => SelectedFolder?.Emails;
        private DispatcherTimer backupTimer;
        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            PerformBackup();
        }

        public void PerformBackup()
        {
            if (!BackupEnabled)
            {
                return; 
            }

            string backupFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EmailBackup.xml");
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<EmailFolder>));
                using (FileStream fileStream = new FileStream(backupFilePath, FileMode.Create))
                {
                    serializer.Serialize(fileStream, Folders);
                }
                MessageBox.Show("Backup completed successfully to " + backupFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to perform backup: " + ex.Message);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

   


        public EmailClientViewModel()
        {

            backupTimer = new DispatcherTimer();
            backupTimer.Tick += BackupTimer_Tick;
            backupTimer.Interval = TimeSpan.FromMinutes(BackupInterval);


            EditCommand = new RelayCommand(
         execute: ExecuteEditEmailCommand,
         canExecute: CanExecuteEditEmailCommand);

            EditCommand = new RelayCommand(ExecuteEditEmailCommand);
            ResetSearchCommand = new RelayCommand(ResetSearch);
            SelectedSender = AvailableSenders.FirstOrDefault();  


            // to show yarakkafa.xml works properly in an advanced exported and while demo will be imported
            PopulateFolders();
            AvailableSenders = new ObservableCollection<string>
    {
        "Dummy_42@sabanciuniv.edu",
        "ceza_sago_42@sabanciuniv.edu"
    };

            LoadCategoriesFromSettings();
        }

       
        private void ResetSearch()
        {
            SearchQuery = string.Empty; // Reset the search query
        }

        private void PerformSearch()
        {
        }

        private bool CanExecuteEditEmailCommand()
        {
            // Return true if an email is selected, false otherwise
            return SelectedEmail != null;
        }

        private void ExecuteEditEmailCommand()
        {
            if (SelectedEmail != null)
            {
                // Determine if the email is editable based on its folder
                bool isEditable = SelectedFolder?.Name == "Drafts";
                var editWindow = new EditEmailWindow(SelectedEmail, isEditable);
                if (editWindow.ShowDialog() == true)
                {
                    RefreshEmails(); 
                }
            }
        }



        public void RefreshEmails()
        {
            OnPropertyChanged(nameof(CurrentEmails));  
        }



        public void SaveEmails(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<EmailFolder>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fileStream, Folders.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data: " + ex.Message);
            }
        }


        public void LoadEmails(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<EmailFolder>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var folders = (List<EmailFolder>)serializer.Deserialize(fileStream);
                    Folders = new ObservableCollection<EmailFolder>(folders);
                }
                OnPropertyChanged(nameof(Folders));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }

        private void PopulateFolders()
        {
            var folder1 = new EmailFolder { Name = "Dummy_42@sabanciuniv.edu", IconPath = "Resources/folder.png" };
            folder1.SubFolders.Add(new EmailFolder { Name = "Inbox", IconPath = "Resources/inbox.png" });
            folder1.SubFolders.Add(new EmailFolder { Name = "Sent", IconPath = "Resources/forward.png" });
            folder1.SubFolders.Add(new EmailFolder { Name = "Drafts", IconPath = "Resources/new.png" });
            folder1.SubFolders.Add(new EmailFolder { Name = "Trash", IconPath = "Resources/deleted.png" });

            var folder2 = new EmailFolder { Name = "ceza_sago_42@sabanciuniv.edu", IconPath = "Resources/folder.png" };
            folder2.SubFolders.Add(new EmailFolder { Name = "Inbox", IconPath = "Resources/inbox.png" });
            folder2.SubFolders.Add(new EmailFolder { Name = "Sent", IconPath = "Resources/forward.png" });
            folder2.SubFolders.Add(new EmailFolder { Name = "Drafts", IconPath = "Resources/new.png" });
            folder2.SubFolders.Add(new EmailFolder { Name = "Trash", IconPath = "Resources/deleted.png" });


            Folders.Add(folder1);
            Folders.Add(folder2);

            var sentFolder = folder1.SubFolders.FirstOrDefault(f => f.Name == "Sent");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Dummy_42@sabanciuniv.edu",
                    Receiver = "you@example.com",
                    CcRecipients = "anna@example.com",
                    Subject = "Sending Test",
                    Body = "This is a sending test.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }
             sentFolder = folder1.SubFolders.FirstOrDefault(f => f.Name == "Sent");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Dummy_42@sabanciuniv.edu",
                    Receiver = "ru@le.com",
                    CcRecipients = "aa@example.com",
                    Subject = "Coming ",
                    Body = "Hellot.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }

            sentFolder = folder2.SubFolders.FirstOrDefault(f => f.Name == "Sent");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Ben42@sabanciuniv.edu",
                    Receiver = "aru@f.com",
                    CcRecipients = "aa@example.com",
                    Subject = "dddd ",
                    Body = "Het.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }
            sentFolder = folder2.SubFolders.FirstOrDefault(f => f.Name == "Trash");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "wer@sabanciuniv.edu",
                    Receiver = "aru@f.com",
                    CcRecipients = "aa@example.com",
                    Subject = "ddassdddd ",
                    Body = "Hedfdt.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }

            sentFolder = folder2.SubFolders.FirstOrDefault(f => f.Name == "Drafts");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Ben42@sabanciuniv.edu",
                    Receiver = "aru@f.com",
                    CcRecipients = "aa@example.com",
                    Subject = "dddd ",
                    Body = "Het.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }
            sentFolder = folder1.SubFolders.FirstOrDefault(f => f.Name == "Drafts");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Besdfn42@sabanciuniv.edu",
                    Receiver = "adddru@f.com",
                    CcRecipients = "aa@example.com",
                    Subject = "dsdkkfsdkmf23232ddd ",
                    Body = "H233523et.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }

            sentFolder = folder1.SubFolders.FirstOrDefault(f => f.Name == "Trash");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Ben42@sabanciuniv.edu",
                    Receiver = "aru@sssf.com",
                    CcRecipients = "asssa@example.com",
                    Subject = "33323ddd ",
                    Body = "H2e2eet.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }

            sentFolder = folder2.SubFolders.FirstOrDefault(f => f.Name == "Trash");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Ben42@siv.edu",
                    Receiver = "aru@f.com",
                    CcRecipients = "aa@ele.com",
                    Subject = "deliidddd ",
                    Body = "Hliiet.",
                    SentDate = DateTime.Now,
                    IsDraft = false
                });
            }
            sentFolder = folder2.SubFolders.FirstOrDefault(f => f.Name == "Inbox");
            if (sentFolder != null)
            {
                sentFolder.Emails.Add(new Email
                {
                    Sender = "Beewdn42@siv.edu",
                    Receiver = "aruasdas@f.com",
                    CcRecipients = "asssa@ele.com",
                    Subject = "deliidddd ",
                    Body = "Hliiaksdmsakld333et.",
                    SentDate = DateTime.Now,
                    IsDraft = false,
                    Category = "Important"
                }) ;
            }

        }


        public void SaveAsDraft(Email email)
        {
            // Find the Drafts folder and add the email
            var draftFolder = SelectedFolder.SubFolders.FirstOrDefault(f => f.Name == "Drafts");
            if (draftFolder != null)
            {
                draftFolder.Emails.Add(email);
                OnPropertyChanged("Emails");
            }
        }






        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (propertyName == "BackupEnabled")
            {
                if (BackupEnabled)
                {
                    backupTimer.Start();
                }
                else
                {
                    backupTimer.Stop();
                }
            }

            if (propertyName == "BackupInterval")
            {
                backupTimer.Interval = TimeSpan.FromMinutes(BackupInterval);
            }
        }

    }
}
