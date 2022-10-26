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
    public partial class NouvelEtu : Window
    {
        public NouvelEtu()
        {
            InitializeComponent();
            int maxId = 0;
            foreach (var c in App.Current.Students)
            {
                
                    if (c.Value.Id > maxId)
                    {
                        maxId = c.Value.Id + 1;
                    }
                
            }
            Id.Text = maxId.ToString();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            foreach (var c in App.Current.Courses)
            {
                foreach (var id in c.StudentIds)
                {
                    if (Id.Text == id.ToString())
                    {
                        MessageBox.Show("The student with the id '" + Id.Text + "' alredy exist" , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            string Fname = firstName.Text;
            string Pass = (Fname.Substring(0, 1) + lastName.Text).ToLower();
            if (MessageBox.Show("Are you sure you want to add the student '" + Id.Text + "' -'" + firstName.Text + " " + lastName.Text + "'",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                App.Current.Students.Add(Int32.Parse(Id.Text),new Student() { Id = Int32.Parse(Id.Text), FirstName = firstName.Text, LastName = lastName.Text, Password = Pass });


                MessageBox.Show("The student has been created", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ((ModifierEtudiant)this.Owner).updateLsit();
                Close();
            }
            


        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
