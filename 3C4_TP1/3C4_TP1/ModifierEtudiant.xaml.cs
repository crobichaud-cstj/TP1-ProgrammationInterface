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

        Student currentStudent = new Student();
        public ModifierEtudiant()
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



            foreach (KeyValuePair<int, Student> entry in App.Current.Students)
            {
                listStud.Items.Add(entry.Value);
            }
            
        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string txtOrig = recherche.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var stuFiltered = from stu in App.Current.Students
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
            currentStudent = (Student)listStud.SelectedItem;
        }

        private void ajout_Click(object sender, RoutedEventArgs e)
        {
            var window = new NouvelEtu();
            window.Owner = this;
            window.Show();
        }

        private void supp_Click(object sender, RoutedEventArgs e)
        {
            foreach (var c in App.Current.Courses)
            {
                foreach (var id in c.StudentIds)
                {
                    if (currentStudent.Id == id)
                    {
                        if (MessageBox.Show("Are you sure you want to delete the student '" + currentStudent.Id + "' -'" + currentStudent.FirstName + " " + currentStudent.LastName + "'",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (MessageBox.Show("Attention : The student will be deleted from all of his classes and all his evaluation will be lost. This operation isn't reversable. Do you want to delete this student",
                        "Delet Student", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                App.Current.Students.Remove(currentStudent.Id);
                                updateLsit();
                                return;
                                
                            }

                            MessageBox.Show("The student '" + currentStudent.Id + "'has been deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            Close();
                        }
                    }
                }
            }
        }


    }
}


