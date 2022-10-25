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
                comboboxEva.Items.Add(eva);
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
                    str += App.Current.Students[s].LastName + ", ";
                    str += App.Current.Students[s].FirstName + " - ";
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
            if (currentStudent != null)
            {


                Iden.Text = currentStudent.Id.ToString();
                Nom.Text = currentStudent.LastName;
                Prenom.Text = currentStudent.FirstName;
                string resultStr = "";



                int totalResult = 0;
                int totalPond = 0;
                int totalMoyen = 0;

                foreach (Evaluation eva in currentCourse.Evaluations)
                {
                    int total = 0;
                    int nb = 0;
                    string moyen = "";
                    foreach (var s in currentCourse.StudentIds)
                    {
                        if (eva.StudentResults[s] != null)
                        {
                            total += eva.StudentResults[s];
                            nb++;
                        }
                    }
                    totalResult += eva.StudentResults[currentStudent.Id];
                    totalMoyen += (total / nb);
                    totalPond += eva.Value;

                    moyen = (total / nb).ToString();

                    resultStr += eva.Name + "\t" + eva.StudentResults[currentStudent.Id] + "/" + eva.Value + "\t Moyenne : " + moyen + "\n";

                }
                resultStr += "Total\t" + totalResult + "/" + totalPond + "\t Moyenne : " + totalMoyen;

                result.Text = resultStr;
            }
            else
            {
                Prenom.Text = "";
                Nom.Text = "";
                result.Text = "";
            }
        }

        private void comboboxEva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Evaluation eva in currentCourse.Evaluations )
            {
                if (eva == comboboxEva.SelectedItem)
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
                string strId = listStud.SelectedItem.ToString().Substring(0, 8);
                if (stu.Id.ToString() == strId )
                {
                    currentStudent = stu;
                }
            }
            updateOnStudent();
        }

        private void Iden_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool exist = false;
            foreach (Student stu in students)
            {
                if (stu.Id.ToString() == Iden.Text)
                {
                    currentStudent = stu;
                    exist = true;
                }
            }
            if (!exist)
            {
                currentStudent = null;
            }
            updateOnStudent();
        }

        private void Ponde_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Course course in App.Current.Courses)
            {
                if (course == currentCourse)
                {
                    foreach (Evaluation evaluation in course.Evaluations)
                    {
                        if (evaluation == currentEva && Ponde.Text.Count() <3)
                        {
                            if (Ponde.Text.Count() == 0)
                            {
                                Ponde.Text = "0";
                            }
                            currentEva = evaluation;
                            evaluation.Value = Int32.Parse(Ponde.Text);
                            
                        }
                        
                    }
                }
            }
            
            updateOnExam();
            updateOnStudent();
        }

        private void addEva_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddEva(currentCourse);
            window.Show();
        }

        private void addResult_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddResult();
            window.Show();
        }
    }
}
