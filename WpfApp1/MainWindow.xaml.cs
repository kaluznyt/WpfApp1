using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            myDataGrid.ItemsSource = LoadCollectionData();

            myDataGrid.BeginningEdit += MyDataGrid_BeginningEdit;
            myDataGrid.SelectionChanged += MyDataGrid_SelectionChanged;
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRelatedFieldConstraints();
        }

        private void UpdateRelatedFieldConstraints()
        {
            foreach (var item in myDataGrid.Items)
            {
                if (item is AuthorWrapper author)
                {
                    if (author.MyIsReadOnly)
                    {
                        author.Description = null;
                    }
                }
            }
        }

        private void MyDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (string.Equals(e.Column.Header.ToString(), 
                nameof(Author.Description), 
                StringComparison.InvariantCultureIgnoreCase)
                && e.Row.DataContext is AuthorWrapper author)
            {
                e.Cancel = author.MyIsReadOnly;
            }
        }

        private List<AuthorWrapper> LoadCollectionData()
        {
            List<AuthorWrapper> authors = new List<AuthorWrapper>();
            authors.Add(
                new AuthorWrapper(
                new Author()
            {
                ID = 101,
                Name = "Mahesh Chand",
                BookTitle = "Graphics Programming with GDI+",
                DOB = new DateTime(1975, 2, 23),
                IsMVP = false,
                MyIsReadOnly = true
            }));

            authors.Add(
                new AuthorWrapper(new Author()
            {
                ID = 201,
                Name = "Mike Gold",
                BookTitle = "Programming C#",
                DOB = new DateTime(1982, 4, 12),
                IsMVP = true
            }));

            authors.Add(new AuthorWrapper(new Author()
            {
                ID = 244,
                Name = "Mathew Cochran",
                BookTitle = "LINQ in Vista",
                DOB = new DateTime(1985, 9, 11),
                IsMVP = true
            }));

            return authors;
        }
    }
}
