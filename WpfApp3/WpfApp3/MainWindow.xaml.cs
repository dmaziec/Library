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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.ViewModel;
using System.Data.SqlClient;
using System.Data;
using WpfApp3.Model;
using System.Collections.ObjectModel;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            baseclass= new BookViewModel();
            base.DataContext = baseclass;
      
        }
        BookViewModel baseclass;

        private void Mylibrary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Book> selected = new ObservableCollection<Book>();
           baseclass.todelete = new ObservableCollection<Book>();
                foreach (var item in mylibrary.SelectedItems)
            {
                Book ook = item as Book;
                baseclass.todelete.Add(new Book { Author = ook.Author.ToString(), Title = ook.Title.ToString(), Year = ook.Year.ToString(), Id=(int)ook.Id, Selected=(bool)ook.Selected });
               
            }
           
           



        }
    }
    }

