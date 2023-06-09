using CourseProject.Logic;
using CourseProject.StudentVisual.Pages;
using CourseProjectUpdated.StudentVisual.Pages;
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
using System.Windows.Shapes;

namespace CourseProject.StudentVisual
{
    /// <summary>
    /// Логика взаимодействия для StudentMainWindow.xaml
    /// </summary>
    public partial class StudentMainWindow : Window
    {
        public StudentMainWindow()
        {
            InitializeComponent();
            
            ButtonPanel.Background = new SolidColorBrush(Color.FromRgb(235,235,235));
        }

        private void TimeTableButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TimeTablePage());
        }

        private void MarksButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MarksPage());
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            InformationOfUser.id = 0;
            InformationOfUser.type = TypeUserEnum.None;
            mw.Show();
            this.Close();
        }

        private void userClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentUserPage());
        }
    }
}
