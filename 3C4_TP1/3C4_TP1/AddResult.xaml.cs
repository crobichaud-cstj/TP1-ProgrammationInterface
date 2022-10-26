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
    public partial class AddResult : Window
    {
        Course currentCourse;
        Evaluation currentEvaluation;
        public AddResult(Course course,Evaluation evaluation)
        {
            currentCourse = course;
            currentEvaluation = evaluation;

            InitializeComponent();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            bool exist = false;
            foreach (var id in currentCourse.StudentIds)
            {
                try { 
                    if (id == Convert.ToInt32(identBox.Text))
                    {
                        exist = true;
                        break;
                    }
                }
                catch
                {
                    identBox.Text = "0";
                    break;
                }
            }
            if (exist)
            {
                try
                {
                    foreach (var stu in currentEvaluation.StudentResults)
                    {
                        if (stu.Key == Convert.ToInt32(identBox.Text))
                        {
                            if(MessageBox.Show("Voulez vous remplacer le résultat " +stu.Value+ " par " + resultBox.Text, "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                currentEvaluation.StudentResults[Convert.ToInt32(identBox.Text)] = Convert.ToInt32(resultBox.Text);
                                ((GestionCours)this.Owner).updateOnAddEva();
                                Close();
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    
                    currentEvaluation.StudentResults.Add(Convert.ToInt32(identBox.Text), Convert.ToInt32(resultBox.Text));
                    ((GestionCours)this.Owner).updateOnAddEva();
                    Close();
                    return;
                }
                catch
                {
                    MessageBox.Show("Résulta non valide" + identBox.Text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                MessageBox.Show("L'étudiant avec l'id" + identBox.Text + " n'existe pas" , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void abort_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
