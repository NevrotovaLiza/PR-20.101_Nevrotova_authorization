using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PR_20._101_Nevrotova_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            KR_NevrotovaEntities bd = new KR_NevrotovaEntities();
            var authorization = bd.User;
            var role = bd.Role;
            var user = authorization.Where(x => x.Login == login && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                if (user.ID_Role == 1)
                {
                    MessageBox.Show("Добро пожаловать! Ваша роль клиент");
                }
                if (user.ID_Role == 2)
                {
                    MessageBox.Show("Добро пожаловать! Ваша роль менеджер");
                }
                if (user.ID_Role == 3)
                {
                    MessageBox.Show("Добро пожаловать! Ваша роль администратор");
                }
            }
            else
            {
                MessageBox.Show("Неверно введены логин или пароль!");
            }
        }
    }
}