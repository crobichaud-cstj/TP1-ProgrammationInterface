using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class GestionCours : Window
    {
        Course currentCourse = new Course();
        Evaluation currentEva = new Evaluation();
        Student currentStudent = new Student();

        List<Student> students = new List<Student>();   

        int totalExam = 0;
        int nbExam = 0;
        public GestionCours(Course course)
        {
            InitializeComponent();

            currentEva = course.Evaluations[0];
            currentCourse = course;

            foreach (Evaluation eva in currentCourse.Evaluations)
            {
                comboboxEva.Items.Add(eva.Name);
            }
            comboboxEva.SelectedIndex = 0;

            updateOnExam();
            
        }



        private void updateOnExam()
        {
            students.Clear();
            listStud.Items.Clear();
            Ponde.Text = currentEva.Value.ToString();

            nbExam = 0;
            totalExam = 0;

            foreach (var s in currentCourse.StudentIds)
            {
                if (currentEva.StudentResults[s] != null)
                {
                    students.Add(App.Current.Students[s]);
                    string str = s.ToString() + " - ";
                    str += App.Current.Students[s].FirstName + ", ";
                    str += App.Current.Students[s].LastName + " ";
                    str += App.Current.Students[s].LastName + " - ";
                    str += +currentEva.StudentResults[s];
                    totalExam += currentEva.StudentResults[s];
                    nbExam++;
                    listStud.Items.Add(str);
                }
                
            }
            currentStudent = students[0];
            listStud.SelectedIndex = 0;

            Moyen.Text = (totalExam / nbExam).ToString();

            updateOnStudent();
        }

        private void updateOnStudent()
        {
            Iden.Text = currentStudent.Id.ToString();
            Nom.Text = currentStudent.LastName;
            Prenom.Text = currentStudent.FirstName;
        }

        private void comboboxEva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Evaluation eva in currentCourse.Evaluations )
            {
                if (eva.Name == comboboxEva.SelectedItem)
                {
                    currentEva = eva;
                }
            }
            updateOnExam();
        }

        private void listStud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Student stu in students)
            {
                if (stu.Id.ToString() == listStud.SelectedItem.ToString().Take(8))
                {
                    currentStudent = stu;
                }
            }
            updateOnStudent();
        }
    }
}
