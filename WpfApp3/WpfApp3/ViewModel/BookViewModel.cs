using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp3.Model;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Windows.Data;
using WpfApp3.ViewModel.Commands;
using WpfApp3.Views;
using System.Windows;

namespace WpfApp3.ViewModel
{
    #region Book 
    public class Book : INotifyPropertyChanged
    {
        public Book()
        { }

        private string author;
        private string title;
        private string year;
        private bool selected;
        private int id;
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (author != value)
                {
                    author = value;
                    RaisePropertyChanged("Author");
                }
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        public string Year
        {
            get { return year; }
            set
            {
                if (year != value)
                {
                    year = value;
                    RaisePropertyChanged("Year");
                }
            }
        }


        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {

                    selected = value;

                    RaisePropertyChanged("Selected");
                }
            }
        }
     


        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }
    }

    #endregion
    /////////////////////////////
    public class BookViewModel : INotifyPropertyChanged

    {

        public BookViewModel()
        {
            source_library model = new source_library();
            dtb1 = model.dtb1;
            ////
            collection = new ObservableCollection<Book>();
            selected_item = new Book();
            _selected = new Combobox_values("");
            Author_block ="";
            Title_block = "";
            foreach (DataRow dr in dtb1.Rows)
            {
                int index = dtb1.Rows.IndexOf(dr);
                int id = (int)dtb1.Rows[index][0];
                string addauthor = dtb1.Rows[index][1].ToString();
                string addtitle = dtb1.Rows[index][2].ToString();
                string addyear = dtb1.Rows[index][3].ToString();
                Collection.Add(new Book { Id=id, Author = addauthor, Title = addtitle, Year = addyear, Selected = false });
            }
            

            this._Book = CollectionViewSource.GetDefaultView(Collection);
            FilterCommand = new Command(filter);
            ClearCommand = new Command(clear);
            DeleteCommand = new Command(delete_selected);
            AddnewbookCommand = new Command(add_book);
            EditnewbookCommand = new Command(edit_book);
            values = new ObservableCollection<Combobox_values>();
            values.Add(new Combobox_values(""));
           todelete= new ObservableCollection<Book>();
            for (int i = DateTime.Now.Year; i > 1700; i--)
            {
                values.Add(new Combobox_values(i.ToString()));
            }

            allselected = false;
            child_addbook = new AddBookViewModel();
            
            add_edit_view = new edit_add_dialog();

            child_addbook.BookAdded += this.OnBookAdded;
            child_addbook.WindowClosed += this.Close_childwindow;

        }

        public Command FilterCommand { get; set; }
        public Command ClearCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command AddnewbookCommand { get; set; }
        public Command EditnewbookCommand { get; set; }
        public ICollectionView _Book { get; set; }
        private source_library model;
        public DataTable dtb1;
        private string author_block;
        private string title_block;
        public ObservableCollection<Combobox_values> values { get; set; }
        private ObservableCollection<Book> collection;
        private Book selected_item;
        private Combobox_values _selected;
        private bool allselected;
        private AddBookViewModel child_addbook;
        private EditBookViewModel child_editbook;
        edit_add_dialog add_edit_view;
        public IList remove_list;
        public ObservableCollection<Book> todelete;
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

        public bool Allselected
        {
            get
            {
                return allselected;
            }
            set
            {

                allselected = value;
                foreach (Book book in this._Book)
                    book.Selected = value;
                RaisePropertyChanged("Allselected");
            }
        }


        public Combobox_values _Selected
        {
            get { return _selected; }
            set { _selected = value;  RaisePropertyChanged("_Selected"); }
        }
        

        public ObservableCollection<Book> Collection
        {
            get
            {
                return collection;
            }
            set
            {

            }

        }

        public Book Selected_item
        {
            get
            {
                return selected_item;
            }
            set
            {
                
                selected_item = value;
                
                RaisePropertyChanged("Selected_item");

            }

        }
        public string Author_block
        {
            get
            {
                
                return author_block; }
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
        public void filter()
        {

            this._Book.Filter = user_filter;
        }
        public void clear()
        {

            Author_block = "";
            Title_block = "";
            Allselected = false;
            _Selected = values.ElementAt(0);
            this._Book.Filter = clear_filter;
        }

        private bool user_filter(object item)
        {
            
            var itemm = (Book)item;
            if ((itemm.Author.Contains(Author_block)) && (itemm.Title.Contains(Title_block)) && (itemm.Year.Contains(_Selected.Number))) return true;
            return false;
        }

        private bool clear_filter(object item)
        {

            var itemm = (Book)item;
            if (itemm.Author.Contains("")) return true;
            return false;
        }


        public void delete_selected()
        {
            if (todelete.Count() == 0 || todelete==null) MessageBox.Show("No items to delete.");
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete selected items?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (var b in todelete)
                    {
                        int idd = b.Id;
                        model = new source_library();
                        model.delete_book(b.Id);
                        bool z = Collection.Remove(collection.Where(i => i.Id == b.Id).Single());
                        if (z == true) model.delete_book(b.Id);
                    }
                    for (int i = 0; i <= (Collection.Count() - 1); i++)
                    {
                        Collection.ElementAt(i).Id = i + 1;
                    }

                    model.clear();

                    foreach (var b in Collection)
                    {
                        model.insert_book(b.Id, b.Author, b.Title, b.Year);
                    }
                   todelete = new ObservableCollection<Book>();

                }
            }
            
        }

        public void add_book()
        {
            add_edit_view = new edit_add_dialog();
            add_edit_view.DataContext = child_addbook;
            add_edit_view.ShowDialog();
        }
        public void edit_book()
        {
            if (Selected_item==null || string.IsNullOrWhiteSpace(Selected_item.Author)) MessageBox.Show("Press the item to delete.");
            else
            {
                child_editbook = new EditBookViewModel(Selected_item.Author, Selected_item.Title, Selected_item.Year);
                add_edit_view = new edit_add_dialog();
                child_editbook.WindowClosed += this.Close_childwindow;
                child_editbook.BookEdited += this.Edit_selectedBook;
                add_edit_view.DataContext = child_editbook;
                add_edit_view.ShowDialog();
            }
        }
        public void OnBookAdded(object source, NewBookArgs new_book)
        {
            int index = collection.Count()+1;
            new_book.Book.Id = index;
            Collection.Add(new_book.Book);
            model = new source_library();
            model.insert_book(new_book.Book.Id, new_book.Book.Author, new_book.Book.Title, new_book.Book.Year);
            add_edit_view.Hide();
        } 

        public void Close_childwindow(object source, EventArgs args)
        {
            
            add_edit_view.Hide();
        }

        public void Edit_selectedBook(object source, EditBookArgs args)
        {
            Selected_item.Author = args.Author;
            Selected_item.Title = args.Title;
            Selected_item.Year = args.Year;
            Book edited = Selected_item;
            int id = Selected_item.Id;
            id--;
            Collection.RemoveAt(id);
            Collection.Insert(id, edited);
            Selected_item = edited;
            model = new source_library();
            model.edit_book(selected_item.Id, selected_item.Author, selected_item.Title, selected_item.Year);
            add_edit_view.Hide();
        }
       
    }

    
    public class Combobox_values
    {
        private string number;
        public Combobox_values(string num)
        {
            number = num;
        }
        public string Number { get { return number; } set { } }

    }

}

