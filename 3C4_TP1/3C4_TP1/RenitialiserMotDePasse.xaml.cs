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
    public partial class RenitialiserMotDePasse : Window
    {
        public RenitialiserMotDePasse()
        {
            InitializeComponent();


        }

        private void res_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.LoggedInUser.Id.ToString() == IdBox.Text && App.Current.LoggedInUser.FirstName == nameBox.Text && App.Current.LoggedInUser.LastName == famNameBox.Text)
            {
                    if (MessageBox.Show("Are you sure you want to renitialize the password, the old password will be lost?",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                    string Fname = App.Current.LoggedInUser.FirstName;
                    string resPass = (Fname.Substring(0, 1) + App.Current.LoggedInUser.LastName).ToLower();
                    App.Current.LoggedInUser.Password = resPass;
                    
                        Close();
                    }
            }
            else
            {
                MessageBox.Show("Informations arn't matching", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

