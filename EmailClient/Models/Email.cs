using System.Collections.Generic;
using System;
using System.ComponentModel;

[Serializable]
public class Email 
{
    public string Sender { get; set; }
   // public string Receiver { get; set; }
    public string CcRecipients { get; set; }
    public string Subject { get; set; }
   // public string Body { get; set; }
    //public List<string> Attachments { get; set; }
    public DateTime SentDate { get; set; }
    public bool IsDraft { get; set; }

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

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    private List<string> attachments = new List<string>();
    public List<string> Attachments => attachments;

    public void AddAttachment(string filePath)
    {
        // Check if the file path already exists in the list
        if (attachments.Contains(filePath))
        {
            throw new ArgumentException("This attachment has already been added.");
        }
        attachments.Add(filePath);
    }

    private string receiver;
    public string Receiver
    {
        get => receiver;
        set
        {
            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email address.");
            receiver = value;
        }
    }

    // Validation method for email
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    string _body;
    public string Body
    {
        get => _body;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Body cannot be empty.");
            }

            _body = value;

        }
    }


    public Email()
    {

        
        //Attachments = new List<string>();
    }
}
