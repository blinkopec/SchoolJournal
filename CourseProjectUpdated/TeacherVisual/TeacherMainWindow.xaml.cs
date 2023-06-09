using CourseProject.Logic;
using CourseProject;
using CourseProjectUpdated.TeacherVisual.Pages;
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

namespace CourseProjectUpdated.TeacherVisual
{
    /// <summary>
    /// Логика взаимодействия для TeacherMainWindow.xaml
    /// </summary>
    public partial class TeacherMainWindow : Window
    {
        public TeacherMainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ButtonPanel.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
        }

        private void TeacherTimeTable_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TImeTableTeacher());
        }

        private void Journal_Button_Click(object sender, RoutedEventArgs e)
        {
            SelectClassWindow scw = new SelectClassWindow(this);
            scw.Show();
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
            MainFrame.Navigate(new TeacherUserPage());
        }
    }
}
