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
    /// Логика взаимодействия для InfoNotebook.xaml
    /// </summary>
    public partial class InfoNotebook : Page
    {
        private Client thisClient = new Client();
        private Noutbook selectNotebok = new Noutbook();
        private bool isKorzine = false;
        public InfoNotebook(int idCkient, int idNotebook, bool isKorzine)
        {
            InitializeComponent();
            thisClient = App.Context.Client.ToList().Where(x => x.id == idCkient).Last();
            selectNotebok = App.Context.Noutbook.ToList().Where(x => x.id == idNotebook).Last();
            ShowInfoNotebook();
            this.isKorzine = isKorzine;
            if (isKorzine)
            {
                btn.Content = "Удалить из корзины";

            }
            else
            {
                btn.Content = "В корзину";
            }
        }
        private void ShowInfoNotebook()
        {
            name.Text = selectNotebok.Name;
            firm.Text = App.Context.Firm.ToArray().Where(x => x.id == selectNotebok.Firm).Select(x => x.Name).Last();
            diagonal.Text = selectNotebok.Diagonal.ToString();
            color.Text = selectNotebok.Color;
            price.Text = selectNotebok.Price.ToString();
            jadra.Text = App.Context.Processor.ToArray().Where(x => x.id == selectNotebok.Processor).Select(x => x.Jadra).Last().ToString();
            potoki.Text = App.Context.Processor.ToArray().Where(x => x.id == selectNotebok.Processor).Select(x => x.Potoki).Last().ToString();
            ozu.Text = selectNotebok.OZUGB.ToString();
            disk.Text = App.Context.Disk.ToArray().Where(x => x.id == selectNotebok.DisckType).Select(x => x.Type).Last().ToString();
            valueDisk.Text = selectNotebok.Value.ToString();
            videokart.Text = App.Context.Videokarta.ToArray().Where(x => x.id == selectNotebok.Videokarta).Select(x => x.Name).Last().ToString();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow Win = (MainWindow)Window.GetWindow(this);
            Win.InformationPage.Content = null;
            Win.UpdateKorzin();
            
        }

        private void AddAndDeleteInKorzin(object sender, RoutedEventArgs e)
        {
            if (isKorzine)
            {
                Korzina korzin = (from k in App.Context.Korzina.ToList()
                                  where k.idNiutbook == selectNotebok.id
                                  select k).Last();
                App.Context.Korzina.Remove(korzin);
                App.Context.SaveChanges();
            }
            else
            {
                Korzina korzin = new Korzina();
                korzin.idKlient = thisClient.id;
                korzin.idNiutbook = selectNotebok.id;
                App.Context.Korzina.Add(korzin);
                App.Context.SaveChanges();
            }
            isKorzine = !isKorzine;

            if (isKorzine)
            {
                btn.Content = "Удалить из корзины";

            }
            else
            {
                btn.Content = "В корзину";
            }
        }
    }
}
