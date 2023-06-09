using CourseProject.Logic;
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

namespace CourseProjectUpdated.TeacherVisual.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectClassWindow.xaml
    /// </summary>
    public partial class SelectClassWindow : Window
    {
        private TeacherMainWindow teacherMainWindow { get; set; }
        public SelectClassWindow(TeacherMainWindow teacherMainWindow)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            MainGrid.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
            this.teacherMainWindow = teacherMainWindow;
            using (var context = new course_projectEntities())
            {
                List<InfoClassForItemControl> infoClasses = new List<InfoClassForItemControl>();
                var classes = context.TeacherClass
                    .Where(b => b.teacher_code == InformationOfUser.id)
                    .Select(b => new
                    {
                        ClassCode = b.class_code,
                        ClassName = b.Class.name,
                    })
                    .ToList();

                foreach (var cls in classes)
                {
                    infoClasses.Add(new InfoClassForItemControl(cls.ClassCode, cls.ClassName));
                }

                ClassItemControl.ItemsSource = infoClasses;
            }

        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            var item = button.DataContext as InfoClassForItemControl;

            teacherMainWindow.MainFrame.Navigate(new JournalPage(item.ClassCode, teacherMainWindow));
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
