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
    public partial class GestionCours : Window
    {
        public GestionCours(Course course)
        {
            InitializeComponent();

            Evaluation evaCurrent = course.Evaluations[0];

            foreach (Evaluation eva in course.Evaluations)
            {
                comboboxEva.Items.Add(eva.Name);
            }
            comboboxEva.SelectedIndex = 0;

            Ponde.Text = evaCurrent.Value.ToString();


            

        }

        
    }
}
