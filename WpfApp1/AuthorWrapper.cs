using System;
using System.ComponentModel;

namespace WpfApp1
{
    public class AuthorWrapper : INotifyPropertyChanged
    {
        public AuthorWrapper(Author author)
        {
            Author = author;
        }

        public Author Author { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public string Description
        {
            get
            {
                return Author.Description;
            }
            set
            {
                Author.Description = value;
                OnPropertyRaised(nameof(Author.Description));
            }
        }

        public int ID
        {
            get
            {
                return Author.ID;
            }
            set
            {
                Author.ID = value;
                OnPropertyRaised(nameof(Author.ID));
            }
        }
        public string Name
        {
            get
            {
                return Author.Name;
            }
            set
            {
                Author.Name = value;
                OnPropertyRaised(nameof(Author.Name));
            }
        }
        public DateTime DOB
        {
            get
            {
                return Author.DOB;
            }
            set
            {
                Author.DOB = value;
                OnPropertyRaised(nameof(Author.DOB));
            }
        }
        public string BookTitle
        {
            get
            {
                return Author.BookTitle;
            }
            set
            {
                Author.BookTitle = value;
                OnPropertyRaised(nameof(Author.BookTitle));
            }
        }
        public bool IsMVP
        {
            get
            {
                return Author.IsMVP;
            }
            set
            {
                Author.IsMVP = value;
                OnPropertyRaised(nameof(Author.IsMVP));
            }
        }

        public bool MyIsReadOnly
        {
            get
            {
                return Author.MyIsReadOnly;
            }
            set
            {
                Author.MyIsReadOnly = value;
                OnPropertyRaised(nameof(Author.MyIsReadOnly));
            }
        }
    }
}
