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
    /// Логика взаимодействия для MarkDescription.xaml
    /// </summary>
    public partial class MarkDescription : Window
    {
        private int MarkId { get; set; }
        public MarkDescription(int MarkId)
        {
            this.MarkId = MarkId;
            InitializeComponent();

            using (var context = new course_projectEntities())
            {
                foreach (var mark in context.StudentTeacherItem)
                {
                    if (mark.MarkID == MarkId)
                    {
                        DateLabel.Content = Convert.ToDateTime(mark.dateMark).ToString("dd-MM-yyyy");
                        MarkLabel.Content = mark.mark;
                        DescBlock.Text = mark.description;
                    }
                }
            }    
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
