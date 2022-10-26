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
    public partial class GestionCoursStudent : Window
    {
        public GestionCoursStudent(Course course)
        {
            InitializeComponent();
            Iden.Text = App.Current.LoggedInUser.Id.ToString();
            Nom.Text = App.Current.LoggedInUser.LastName;
            Prenom.Text = App.Current.LoggedInUser.FirstName;

            int total = 0;
            int totalMoyen = 0;
            int totalPond = 0;
            foreach (Evaluation evaluation in course.Evaluations)
            {
                total += evaluation.StudentResults[App.Current.LoggedInUser.Id];
                int moyen = (evaluation.StudentResults.Skip(1).Sum(x => x.Value) / evaluation.StudentResults.Count) * 100;
                totalMoyen += moyen;
                totalPond += evaluation.Value;

                listExam.Items.Add(evaluation.Name + " - " + evaluation.StudentResults[App.Current.LoggedInUser.Id]+ " / " + evaluation.Value+" - Moyenne : "+moyen);
            }
            listExam.Items.Add("Total - " + total + " / " + totalPond + " - Moyenne : " + totalMoyen);
            
        }

        
    }
}
