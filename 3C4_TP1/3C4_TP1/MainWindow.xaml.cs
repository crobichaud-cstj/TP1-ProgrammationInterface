using System;
using System.Collections.Generic;
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

namespace _3C4_TP1
{

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Débuter avec un user non connecté
            App.Current.LoggedInUser = null;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            // TODO: effectuer la connexion ici par le bouton ou par la touche Enter
            if ((bool)teacherRadio.IsChecked)
            {
                foreach (var teacher in App.Current.Teachers)
                {
                    if (teacher.Value.Id.ToString() == usernameBox.Text.ToString())
                    {
                        if (teacher.Value.Password.ToString() == passwordBox.Password.ToString())
                        {
                            App.Current.LoggedInUser = teacher.Value;
                            var window = new AcceuilWindow();
                            Close();
                            window.Show();
                            return;
                        }
                    }
                }
                MessageBox.Show("Erreur", "Mauvais mot de passe ou non d'utilisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if ((bool)teacherRadio.IsChecked)
            {
                foreach (var student in App.Current.Students)
                {
                    if (student.Value.Id.ToString() == usernameBox.Text.ToString())
                    {
                        if (student.Value.Password.ToString() == passwordBox.Password.ToString())
                        {
                            App.Current.LoggedInUser = student.Value;
                            var window = new AcceuilWindow();
                            window.Show();

                            return;
                        }
                    }
                }
            }
            else
            {
                var admin = App.Current.Admin;
                if (admin.LastName == usernameBox.Text.ToString() || "admin" == usernameBox.Text.ToString())
                {
                    if (admin.LastName.ToLower() == passwordBox.Password.ToString())
                    {
                        App.Current.LoggedInUser = admin;
                        var window = new AdminWindow();
                        window.Show();

                        return;
                    }
                }

                MessageBox.Show("Erreur", "Mauvais mot de passe ou non d'utilisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }
    }
}
