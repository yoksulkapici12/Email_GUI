using System.Windows;

namespace EmailClient
{
    public partial class InputDialog : Window
    {
        public string ResponseText
        {
            get { return inputTextBox.Text; }
            set { inputTextBox.Text = value; }
        }

        public InputDialog(string title, string defaultText = "")
        {
            InitializeComponent();
            Title = title;
            inputTextBox.Text = defaultText;
            inputTextBox.SelectAll();
            inputTextBox.Focus();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
