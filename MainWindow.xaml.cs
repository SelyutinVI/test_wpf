using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF_TEST.Models;

namespace WPF_TEST
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Company> CompList;
        private BindingList<MyUsers> UsersList;
        private AppDB db;
        public MainWindow()
        {
            db = new AppDB();
            DBcontent.initial(db);
            InitializeComponent();
            CompList = new BindingList<Company>();
            foreach (Company e in db.Companies)
                CompList.Add(e);
            UsersList = new BindingList<MyUsers>();
            foreach (MyUsers e in db.Users)
                UsersList.Add(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {        
            dg1.ItemsSource = CompList;
            dg2.ItemsSource = UsersList;
            List<String> a = new List<String>{ "Ещё не заключен", "Заключен", "Расторгнут" };
            cb1.ItemsSource = a;            
            cb1.SelectedIndex = 1;
            cb2.ItemsSource = CompList;
            cb2.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tb1.Text!= null)
            {
                Company t = new Company() { Name = tb1.Text, Status = cb1.Text };
                db.Companies.Add(t);
                db.SaveChanges();
                CompList.Add(t);
                dg1.ItemsSource = CompList;
            }
        }

        private void dg1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            db.SaveChanges();         
        }

        private void dg2_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            db.SaveChanges();
        }

        private void dg1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Company c = CompList[dg1.SelectedIndex];
                db.Companies.Remove(c);
                db.SaveChanges();
            }
        }

        private void dg2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                MyUsers c = UsersList[dg2.SelectedIndex];
                db.Users.Remove(c);
                db.SaveChanges();
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (tb2.Text != null && tb3.Text != null && tb4.Text != null)
            {
                MyUsers t = new MyUsers() { Name = tb2.Text, Login = tb3.Text, Password = tb4.Text, Company = db.Companies.FirstOrDefault(c => c.Name == cb2.Text)};
                db.Users.Add(t);
                db.SaveChanges();
                UsersList.Add(t);
                dg2.ItemsSource = UsersList;
            }
        }
    }
}
