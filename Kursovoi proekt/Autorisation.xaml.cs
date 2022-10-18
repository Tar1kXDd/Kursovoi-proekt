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
using System.Windows.Shapes;

namespace Kursovoi_proekt
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idCkient = isRightLoginPassword();
            if (idCkient != 0)
            {
                MainWindow Win = new MainWindow(idCkient);
                Win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private int isRightLoginPassword()
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            
            foreach (var item in App.Context.Client.ToList())
            {
                if (item.Nickname == login)
                {
                    if (item.Password == password)
                    {
                        return item.id;
                    }
                }
            }
            return 0;
        }
    }
}
