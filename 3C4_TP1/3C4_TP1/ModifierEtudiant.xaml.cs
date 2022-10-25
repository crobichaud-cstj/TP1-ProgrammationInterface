using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _3C4_TP1
{

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class ModifierEtudiant : Window
    {

        public ModifierEtudiant()
        {
            InitializeComponent();

            foreach (var s in App.Current.Students)
            {
                listStud.Items.Add(s.Value.ToString());
            }

        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listStud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ajout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void supp_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}


