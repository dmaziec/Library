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
    public class EditBookArgs : EventArgs
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        private string author;
        private string title;
        private string year;


    }
    public class EditBookViewModel
    {
        public EditBookViewModel(string author_edit, string title_edit, string year_edit)
        {
            Author_block = author_edit;
            Title_block = title_edit;
            
            selected_year= new Combobox_values(year_edit);

            values = new ObservableCollection<Combobox_values>();
            values.Add(new Combobox_values(""));
            for (int i = DateTime.Now.Year; i > 1700; i--)
            {
                values.Add(new Combobox_values(i.ToString()));

                if (String.Equals(year_edit, i.ToString())) Selected_year = values.ElementAt(2020- i);
            }
            
          
            button = "Edit";
            title_window = "Edit book";
            Modification = new Command(Edit_Book);
            CloseWindow = new Command(Close_Window);
        }

        

        public string Author_block
        {
            get
            {
                return author_edit;
            }
            set
            {
                if (author_edit != value)
                {

                    author_edit = value;
                    RaisePropertyChanged("Author_block");
                    
                }
            }
        }

        public string Title_block
        {
            get { return title_edit; }
            set
            {
                if (title_edit != value)
                {
                    title_edit = value;
                    RaisePropertyChanged("Title_block");
                }
            }
        }

        public Combobox_values Selected_year
        {
            get { return selected_year; }
            set
            {
                if (selected_year != value)
                {
                    selected_year = value;
                   Combobox_values h= value as Combobox_values;
                    RaisePropertyChanged("Selected_year");
                }
            }
        }

        public string Button
        {
            get
            {
                return button;
            }
            set
            {
                if(button!=value)
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

        private string author_edit;
        private string title_edit;
        private string title_window;
        private Combobox_values selected_year;
        private string button;
        public ObservableCollection<Combobox_values> values { get; set; }
        public Command CloseWindow { get; set; }
        public Command Modification { get; set; }
        private void Edit_Book()
        {
            if (BookEdited != null)
            {
                OnBookEdited();
            }
        }
        private void Close_Window()
        {
            if (WindowClosed != null)
            {
                OnWindowClosed();
            }
        }

        protected virtual void OnBookEdited()
        {
            if (Author_block != null && Title_block != null && Selected_year != null)
            {
                BookEdited(this, new EditBookArgs { Author = Author_block, Title = Title_block, Year = Selected_year.Number.ToString()});
            }
        }

        protected virtual void OnWindowClosed()
        {
            if (WindowClosed != null)

            {
                Author_block = " ";
                Title_block = " ";
                Selected_year = null;
                WindowClosed(this, EventArgs.Empty);
            }
        }
       

        public event EventHandler<EditBookArgs> BookEdited;
        public event EventHandler<EventArgs> WindowClosed;



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
