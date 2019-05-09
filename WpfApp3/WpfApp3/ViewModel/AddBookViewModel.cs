using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp3.ViewModel.Commands;

namespace WpfApp3.ViewModel
{
    public class NewBookArgs : EventArgs
    {
        public Book Book { get; set; }
    }

    public class AddBookViewModel : INotifyPropertyChanged
    {
        public AddBookViewModel()
        {
            title_window = "Add new book";
            values = new ObservableCollection<Combobox_values>();
            values.Add(new Combobox_values(""));
            for (int i = DateTime.Now.Year; i > 1700; i--)
            {
                values.Add(new Combobox_values(i.ToString()));
            }

            button = "Add";
            Modification = new Command(Add_Book);
            CloseWindow = new Command(Close_Window);
        }

        private string title_window;
        private string author_block;
        private string title_block;
        private Combobox_values selected_year;
        public Command CloseWindow { get; set; }
        public Command Modification { get; set; }
        public ObservableCollection<Combobox_values> values { get; set; }

        private string button;

        public string Author_block
        {
            get { return author_block; }
            set
            {
                if (author_block != value)
                {
                    author_block = value;
                    RaisePropertyChanged("Author_block");
                }
            }
        }

        public string Title_block
        {
            get { return title_block; }
            set
            {
                if (title_block != value)
                {
                    title_block = value;
                    RaisePropertyChanged("Title_block");
                }
            }
        }

        public Combobox_values Selected_year
        {
            get { return selected_year; }
            set { selected_year = value; RaisePropertyChanged("Selected_year"); }
        }

        public string Button
        {
            get { return button; }
            set
            {
                if (button != value)
                {
                    button = value;
                    RaisePropertyChanged("Button");
                }
            }
        }

        public string Title_window
        {
            get { return title_window; }
            set
            {
                if (title_window != value)
                {
                    title_window = value;
                    RaisePropertyChanged("Title_window");
                }
            }
        }
        

        public event EventHandler<NewBookArgs> BookAdded;
        public event EventHandler<EventArgs> WindowClosed;
        protected virtual void OnBookAdded()
        {
            if (BookAdded != null)
            {
                Book newBook = new Book();
                if (Author_block != null && Title_block != null && Selected_year!= null)
                {
                    newBook.Author = Author_block;
                    newBook.Title = Title_block;
                    newBook.Year = Selected_year.Number;
                    Author_block = "";
                    Title_block = "";
                    Selected_year = null;
                    BookAdded(this, new NewBookArgs() { Book = newBook });
                    
                }
                else MessageBox.Show("You should pass every parameter.");
            }
        }
        
        public void Add_Book()
        {
            if (BookAdded != null)
            {
               
                    OnBookAdded();
            }
            
        }

        protected virtual void OnWindowClosed()
        {
            if(WindowClosed!=null)
            {
                
                    Author_block = " ";
                    Title_block = " ";
                    Selected_year = null;
                    WindowClosed(this, EventArgs.Empty);
                
            }
        }

        public void Close_Window()
        {
            if(WindowClosed!=null)
            {
                OnWindowClosed();
            }
        }
        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }
        #endregion


       
    }
}
