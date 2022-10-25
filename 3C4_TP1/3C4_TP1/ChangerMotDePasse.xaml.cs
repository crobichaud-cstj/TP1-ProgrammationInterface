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
    public partial class ChangerMotDePasse : Window
    {
        public ChangerMotDePasse()
        {
            InitializeComponent();

        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if(App.Current.LoggedInUser.Password == OldpassBox.Password.ToString())
            {
                if (newPassBox.Password.ToString() == confPassBox.Password.ToString() && newPassBox.Password.ToString() != null && confPassBox.Password.ToString() != null)
                {
                    if (MessageBox.Show("Are you sure you want to change the password, the old password will be lost?",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        App.Current.LoggedInUser.Password = newPassBox.Password.ToString();
                        Close();
                    }                 
                }
                else
                {

                MessageBox.Show("Password arn't matching", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show( "Password arn't matching", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
