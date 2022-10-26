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
    public partial class ModifierEnseignant : Window
    {

        Teacher currentTeacher = new Teacher();
        public ModifierEnseignant()
        {
            InitializeComponent();

            updateLsit();

        }

        public void updateLsit()
        {
            recherche.Text = "";
            listStud.ItemsSource = null;
            listStud.Items.Clear();


            listStud.SelectedIndex = 0;



            foreach (KeyValuePair<int, Teacher> entry in App.Current.Teachers)
            {
                listStud.Items.Add(entry.Value);
            }

        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {

            string txtOrig = recherche.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var stuFiltered = from stu in App.Current.Teachers
                              let ename = stu.Value.ToString()
                              where
                               ename.Contains(txtOrig)
                              select stu.Value;

            listStud.ItemsSource = null;
            listStud.Items.Clear();

            listStud.ItemsSource = stuFiltered;
  

        }

        private void listStud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTeacher = (Teacher)listStud.SelectedItem;
        }

        private void ajout_Click(object sender, RoutedEventArgs e)
        {
            var window = new NouvelEns();
            window.Owner = this;
            window.Show();
        }

        private void supp_Click(object sender, RoutedEventArgs e)
        {
            foreach (var c in App.Current.Courses)
            {
                
                    if (currentTeacher.Id == c.TeacherId)
                    {
                        if (MessageBox.Show("Are you sure you want to delete the teacher '" + currentTeacher.Id + "' -'" + currentTeacher.FirstName + " " + currentTeacher.LastName + "'",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (MessageBox.Show("Attention : The teacher will be deleted from all of his classes and all his evaluation will be lost. This operation isn't reversable. Do you want to delete this teacher",
                        "Delet Teacher", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                App.Current.Teachers.Remove(currentTeacher.Id);
                                updateLsit();
                                return;

                            }

                            MessageBox.Show("The teacher '" + currentTeacher.Id + "'has been deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                            Close();
                        }
                    }
                
            }
        }


    }
}


