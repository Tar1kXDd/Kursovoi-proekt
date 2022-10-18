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

namespace Kursovoi_proekt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client thisClient = new Client();
        public MainWindow(int idCkient)
        {
            InitializeComponent();
            thisClient = App.Context.Client.ToList().Where(x=>x.id == idCkient).Last();
            var data = from n in App.Context.Noutbook.ToList()
                       select n;
            DataGridNotebook.ItemsSource = data;
            UpdateKorzin();
        }

        private void AddInKorzin(object sender, RoutedEventArgs e)
        {
            Korzina korzin = new Korzina();
            korzin.idKlient = thisClient.id;
            korzin.idNiutbook = (DataGridNotebook.SelectedItem as Noutbook).id;
            korzin.IsZakaz = 0;
            App.Context.Korzina.Add(korzin);
            App.Context.SaveChanges();
        }

        private void ShowInfoNotebook(object sender, MouseButtonEventArgs e)
        {
            InfoNotebook Page = new InfoNotebook(thisClient.id, (DataGridNotebook.SelectedItem as Noutbook).id, false);
            InformationPage.Content = Page;
        }

        private void DeleteInKorzin(object sender, RoutedEventArgs e)
        {
            Noutbook noutbook = (sender as Button).DataContext as Noutbook;
            Korzina korzin = (from k in App.Context.Korzina.ToList()
                             where k.idNiutbook == noutbook.id
                             select k).Last();
            
            App.Context.Korzina.Remove(korzin);
            App.Context.SaveChanges();
            UpdateKorzin();
            UpdateDostav();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateKorzin();
            UpdateDostav();
        }
        public void UpdateKorzin()
        {
            var dataKorzin = from k in App.Context.Korzina.ToList()
                             join n in App.Context.Noutbook.ToList() on k.idNiutbook equals n.id
                             where k.idKlient == thisClient.id && (k.IsZakaz == 0|| k.IsZakaz == null)
                             select n;
            DataGridNotebookKorzin.ItemsSource = dataKorzin;
        }
        public void UpdateDostav()
        {
            var dataDostav = from z in App.Context.Zakaz.ToList()
                            
                             select z;
            DataGridNotebookDostav.ItemsSource = dataDostav;
        }

        private void ShowInfoNotebookKorzin(object sender, MouseButtonEventArgs e)
        {
            InfoNotebook Page = new InfoNotebook(thisClient.id, (DataGridNotebookKorzin.SelectedItem as Noutbook).id, true);
            InformationPage.Content = Page;
        }

        private void AddZakaz(object sender, RoutedEventArgs e)
        {
            string adres = "";
            AddAdresWin win = new AddAdresWin();
            win.ShowDialog();
            adres=win.GetAdres();
            Zakaz zakaz = new Zakaz();
            zakaz.idKorzina = (from k in App.Context.Korzina.ToList()
                             where k.idKlient == thisClient.id
                             select k.id).Last();
            zakaz.StatusZakaz = 1;//ожидается
            zakaz.Adres = adres;
            var korzineItem = from k in App.Context.Korzina.ToList()
                              where k.idKlient==thisClient.id
                              select k;
            foreach (var item in korzineItem)
            {
                item.IsZakaz = 1;
            }
            App.Context.Zakaz.Add(zakaz);
            App.Context.SaveChanges();
            UpdateKorzin();
        }

        private void ShowInfoZakaz(object sender, MouseButtonEventArgs e)
        {
            InfoNotebook Page = new InfoNotebook(thisClient.id, (DataGridNotebookDostav.SelectedItem as Zakaz).id, true);
            InformationPage.Content = Page;
        }
    }
}
