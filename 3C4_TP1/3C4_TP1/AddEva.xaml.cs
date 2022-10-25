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
        int courId = 0;
        public AddEva(Course course)
        {

            courId = Int16(course.Id);


            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Courses[courId]
        }

        private void abort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
