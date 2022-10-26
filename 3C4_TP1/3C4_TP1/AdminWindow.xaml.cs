﻿using System;
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
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

        }

        private void modifEtu_Click(object sender, RoutedEventArgs e)
        {
            var window = new ModifierEtudiant();
            window.Show();
        }

        private void modifEnsei_Click(object sender, RoutedEventArgs e)
        {
            var window = new ModifierEnseignant();
            window.Show();
        }

        private void bonus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            Close();

        }
    }
}

