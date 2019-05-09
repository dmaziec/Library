using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfApp3.Model
{
    //public class Book : INotifyPropertyChanged
    //{
    //    public Book()
    //    {
    //    }

    //    private string author;
    //    private string title;
    //    private string year;

    //  public event PropertyChangedEventHandler PropertyChanged;

    //    public string Author
    //    {
    //        get { return author; }
    //        set
    //        {
    //            if (author != value)
    //            {
    //                author = value;
    //               RaisePropertyChanged("Author");
    //            }
    //        }
    //    }
    //    public string Title
    //    {
    //        get { return title; }
    //        set

    //        {
    //            if (title != value)
    //            {
    //                title = value;
    //                RaisePropertyChanged("Title");
    //            }
    //        }
    //    }
    //    public string Year
    //    {
    //        get { return year; }
    //        set
    //        {
    //            if (year != value)
    //            {
    //                year = value;
    //                RaisePropertyChanged("Year");
    //            }
    //        }
    //    }

    //    private void RaisePropertyChanged(string property)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(property));

    //        }
    //    }
    //}
    public class source_library
    {

        public source_library()
        {
            try
            {

                string connectionstring = @"Data Source=KOMPUTER\SQL2014;Initial Catalog=Library;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(connectionstring);
                sqlcon.Open();
                /// MessageBox.Show("Connection OPen!");
                SqlCommand cmd = new SqlCommand("SELECT * FROM egui2");
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM egui2", sqlcon);
                dtb1 = new DataTable();
                sqlDa.Fill(dtb1);
                sqlcon.Close();

                /// SqlCommand cmd2 = new SqlCommand("DECLARE @id INT;SET @id = 0;UPDATE egui2;SET @id = id = @id + 100;GO",sqlcon);
                string updatestring = "DECLARE @id INT" + "SET @id=0" + "UPDATE egui2" + "SET @id=id= id+@id+100" + "GO";
                //SqlCommand cmd2 = new SqlCommand(updatestring,sqlcon);
                //cmd2.Connection = sqlcon;
                //sqlcon.Open();
                //cmd2.CommandType = CommandType.Text;
                //int i=cmd2.ExecuteNonQuery();
                //sqlcon.Close();
                //MessageBox.Show(i.ToString());





                //SqlDataAdapter sqlDa1 = new SqlDataAdapter(cmd2, sqlcon);

                // DataGrid1.ItemsSource = dtb1.DefaultView;
                // sqlDa.Fill(dtb1);
            }
            catch
            {
            }
        }
        public DataTable dtb1;
        public DataTable dtb2;


        public void insert_book(int id, string author, string title, string year)
        {
            string connectionstring = @"Data Source=KOMPUTER\SQL2014;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("INSERT INTO egui2 (Id,Author,Title,Year) VALUES (@Id,@Author,@Title,@Year)");
            cmd.Parameters.Add("@Id", id.ToString());
            cmd.Parameters.Add("@Author", author);
            cmd.Parameters.Add("@Title", title);
            cmd.Parameters.Add("@Year", year);
            cmd.Connection = sqlcon;
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();

        }
        public void edit_book(int id, string author, string title, string year)
        {
            string connectionstring = @"Data Source=KOMPUTER\SQL2014;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("UPDATE egui2 SET id=@Id, Author=@Author, Title=@Title, Year=@Year WHERE id=@Id");
            cmd.Parameters.Add("@Id", id.ToString());
            cmd.Parameters.Add("@Author", author);
            cmd.Parameters.Add("@Title", title);
            cmd.Parameters.Add("@Year", year);
            cmd.Connection = sqlcon;
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        public void delete_book(int id)
        {
            string connectionstring = @"Data Source=KOMPUTER\SQL2014;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("DELETE FROM egui2 WHERE id=@Id");
            cmd.Parameters.Add("@Id", id.ToString());
            cmd.Connection = sqlcon;
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();

        }

        public void clear()
        {
            string connectionstring = @"Data Source=KOMPUTER\SQL2014;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("DELETE FROM egui2 ");
            cmd.Connection = sqlcon;
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        
    }
}

         


    














