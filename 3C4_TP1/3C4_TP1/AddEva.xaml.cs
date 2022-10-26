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
    public partial class AddEva : Window
    {
        object currentCourse;
        public AddEva(Course course)
        {
           currentCourse = course;

            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var eva = new Evaluation();
            if (nameBox.Text != "" && pondBox.Text != "")
            {
                eva.Name = nameBox.Text;
                try
                {
                    eva.Value = Convert.ToInt32(pondBox.Text);
                }
                catch
                {
                    MessageBox.Show("Pondération non valide", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
            foreach (Course course in App.Current.Courses)
            {
                if (course == currentCourse && MessageBox.Show("Voulez vous vraiment ajouter l'évaluation", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    course.Evaluations.Add(eva);
                    ((GestionCours)this.Owner).updateOnAddEva();
                    Close();
                }

            }
            }
        }

        private void abort_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
