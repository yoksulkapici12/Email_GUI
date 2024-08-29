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

namespace EmailClient
{
   
    public partial class EmailSearchControl : UserControl
    {
        public event EventHandler<SearchEventArgs> SearchChanged;
        public event EventHandler ResetSearch;

        public EmailSearchControl()
        {
            InitializeComponent();
            txtSearch.TextChanged += (s, e) => OnSearchChanged();
            cmbCategory.SelectionChanged += (s, e) => OnSearchChanged();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchEventArgs args = new SearchEventArgs
            {
                SearchText = txtSearch.Text,
                Category = cmbCategory.Text
            };
            SearchChanged?.Invoke(this, args);
        }


        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = -1;
            ResetSearch?.Invoke(this, EventArgs.Empty);
        }

        public class SearchEventArgs : EventArgs
        {
            public string SearchText { get; set; }
            public string Category { get; set; }
        }

        private void OnSearchChanged()
        {
            SearchChanged?.Invoke(this, new SearchEventArgs
            {
                SearchText = txtSearch.Text,
                Category = cmbCategory.Text
            });
        }
    }

}
