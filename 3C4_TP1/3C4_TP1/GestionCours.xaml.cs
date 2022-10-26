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

        public void updateOnAddEva()
        {
            comboboxEva.Items.Clear();
            foreach (Evaluation eva in currentCourse.Evaluations)
            {
                comboboxEva.Items.Add(eva);
            }
        }



        private void updateOnExam()
        {
            students.Clear();
            listStud.Items.Clear();
            Ponde.Text = currentEva.Value.ToString();

            nbExam = 0;
            totalExam = 0;
            if (currentEva.StudentResults.Count > 0)
            {
                foreach (var s in currentEva.StudentResults)
                {
                    StudentResult studentResult = new StudentResult();
                    studentResult.Id = s.Key;
                    studentResult.FirstName = App.Current.Students[s.Key].FirstName;
                    studentResult.LastName = App.Current.Students[s.Key].LastName;
                    studentResult.result = s.Value;

                    students.Add(App.Current.Students[s.Key]);
                    listStud.Items.Add(studentResult);

                    totalExam = studentResult.result;
                    nbExam++;
                }
                currentStudent = students[0];
                listStud.SelectedIndex = 0;
                Moyen.Text = (totalExam / nbExam).ToString();
            }
            else
            {
                Moyen.Text = "";
            }

            updateOnStudent();
        }

        private class StudentResult
        {
            public int Id;
            public string FirstName = "";
            public string LastName = "";
            public int result = 0;

            public override string ToString()
            {
                return Id + " - " + LastName + ", " + FirstName + " - " + result;
            }
        }

        private void updateOnStudent()
        {
            if (currentEva.StudentResults.Count()>0)
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
                    if (eva.StudentResults.Count() > 0)
                    {

                        foreach (var s in eva.StudentResults)
                        {
                                total += s.Value;
                                nb++;
                        }

                        try 
                        {
                            totalResult += eva.StudentResults[currentStudent.Id];
                            totalMoyen += (total / nb);
                            totalPond += eva.Value;

                            moyen = (total / nb).ToString();

                            resultStr += eva.Name + "\t" + eva.StudentResults[currentStudent.Id] + "/" + eva.Value + "\t Moyenne : " + moyen + "\n";
                        }
                        catch
                        {}
                    }

                }
                resultStr += "Total\t" + totalResult + "/" + totalPond + "\t Moyenne : " + totalMoyen;

                result.Text = resultStr;
            }
            else
            {
                Prenom.Text = "";
                Nom.Text = "";
                Iden.Text = "";
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
            window.Owner = this;
            window.Show();
        }

        private void addResult_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddResult(currentCourse, currentEva);
            window.Owner = this;
            window.Show();
        }
    }
}
