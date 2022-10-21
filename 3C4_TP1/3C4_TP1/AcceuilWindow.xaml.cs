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
    public partial class AcceuilWindow : Window
    {
        

        public AcceuilWindow()
        {

            InitializeComponent();
            PrenomNom.Text = App.Current.LoggedInUser.FirstName + " " + App.Current.LoggedInUser.LastName;
            ComboBoxSemester.Items.Clear();
            
            foreach (var d in Enum.GetValues(typeof (Semester)))
            {
                ComboBoxSemester.Items.Add(d);
            }
            ComboBoxSemester.SelectedIndex = 0;

            updateCombox();

            Horaire.Click += Horaire_Click;
            ChangerMDP.Click += ChangerMDP_Click;
            ResMDP.Click += ResMDP_Click;
            Quit.Click += Quit_Click;



        }



        private void ComboBoxSemester_SelectionCanged(object sender, SelectionChangedEventArgs e)
        {
            updateCombox();
        }

        private void Horaire_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
           
            var window = new MainWindow();
            window.Show();
            Close();
        }
        private void ChangerMDP_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ResMDP_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void updateCombox()
        {
            ListView1.Items.Clear();
            foreach (var d in App.Current.Courses)
            {
                if (d.TeacherId == App.Current.LoggedInUser.Id)
                {
                    if (d.Semester.ToString() == ComboBoxSemester.SelectedValue.ToString())
                    {
                        ListView1.Items.Add(d.Id);
                    }

                }
            }
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var c in App.Current.Courses)
            {
                if (c.Id == ListView1.SelectedItem)
                {
                    var window = new GestionCours(c);
                    window.Show();
                }
            }
            
        }
    }
}
