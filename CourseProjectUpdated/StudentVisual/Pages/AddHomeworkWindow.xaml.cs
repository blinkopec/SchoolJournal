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

namespace CourseProjectUpdated.StudentVisual.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddHomeworkWindow.xaml
    /// </summary>
    public partial class AddHomeworkWindow : Window
    {
        private int code_timetable { get; set; }
        private DateTime date { get; set; }
        private string desc { get; set; }
        public AddHomeworkWindow(int code_timetable,DateTime date, string desc)
        {
            this.code_timetable = code_timetable;
            this.date = date;
            this.desc = desc;
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            DateLabel.Content = date.ToString("dd-MM-yyyy");
            DescBox.Text = desc;
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveDescButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new course_projectEntities())
            {
                foreach(var table in context.TimeTable)
                {
                    if (table.id_timetable == code_timetable)
                    {
                        table.description_of_item = DescBox.Text;
                    }
                }
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
