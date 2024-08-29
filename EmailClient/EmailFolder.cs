using System;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace EmailClient
{
    [Serializable]
    public class EmailFolder : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<EmailFolder> _subFolders;
        private ObservableCollection<Email> _emails;

        private string _category;

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        private string subject;
        public string Subject
        {
            get => subject;
            set
            {
                if (subject != value)
                {
                    subject = value;
                    OnPropertyChanged(nameof(Subject));
                }
            }
        }

        private string _body;
        public string Body
        {
            get => _body;
            set
            {
                if (_body != value)
                {
                    _body = value;
                    OnPropertyChanged(nameof(Body));  
                }
            }
        }

        private string _sender;
        public string Sender
        {
            get => _sender;
            set
            {
                if (_sender != value)
                {
                    _sender = value;
                    OnPropertyChanged(nameof(Sender));
                }
            }
        }

        private string _iconPath;
        public string IconPath
        {
            get => _iconPath;
            set
            {
                if (_iconPath != value)
                {
                    _iconPath = value;
                    OnPropertyChanged(nameof(IconPath));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ObservableCollection<EmailFolder> SubFolders
        {
            get => _subFolders;
            set
            {
                if (_subFolders != value)
                {
                    _subFolders = value;
                    OnPropertyChanged(nameof(SubFolders));
                }
            }
        }



        public ObservableCollection<Email> Emails
        {
            get => _emails;
            set
            {
                if (_emails != value)
                {
                    _emails = value;
                    OnPropertyChanged(nameof(Emails));
                }
            }
        }

        public EmailFolder()
        {
            SubFolders = new ObservableCollection<EmailFolder>();
            Emails = new ObservableCollection<Email>();

        }

        public void AddMessage(Email message)
        {
            Emails.Add(message);
            OnPropertyChanged("Emails");
        }




    }
}
