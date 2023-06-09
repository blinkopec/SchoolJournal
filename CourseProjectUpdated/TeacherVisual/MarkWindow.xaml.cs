using CourseProject.Logic;
using CourseProjectUpdated.TeacherVisual.Pages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для MarkWindow.xaml
    /// </summary>
    public partial class MarkWindow : Window
    {
        private int MarkCode{ get; set; }
        private int StudentCode {get; set; }
        private TeacherMainWindow teacherMainWindow { get; set; }
        private int ClassCode { get; set; }

        //У всех оценок с нулевых идентификатором нет привязки в бд
        public MarkWindow(int MarkCode, int StudentCode, TeacherMainWindow teacherMainWindow, int ClassCode)
        {
            this.MarkCode = MarkCode;
            this.StudentCode = StudentCode;
            this.teacherMainWindow = teacherMainWindow;
            this.ClassCode = ClassCode;

            InitializeComponent();

            string[] marksNumbers = new string[5] { "N", "2", "3", "4", "5" };
            MarkBox.ItemsSource = marksNumbers;

            InsertDataToWindow();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MarkCode != 0)
            {
                using (var context = new course_projectEntities())
                {
                    foreach (var mark in context.StudentTeacherItem)
                    {
                        if (mark.MarkID == MarkCode)
                        {
                            //context.Entry(mark).State = EntityState.Deleted;
                            context.StudentTeacherItem.Remove(mark);
                        }
                    }
                    context.SaveChanges();
                }
                
                teacherMainWindow.MainFrame.Navigate(new JournalPage(ClassCode, teacherMainWindow));
                this.Close();
            }
            else
            {
                teacherMainWindow.MainFrame.Navigate(new JournalPage(ClassCode, teacherMainWindow));
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int item_code = 0;
            using (var context = new course_projectEntities())
            {
                item_code = (int)context.Teacher
                    .Where(b => b.teacher_code == InformationOfUser.id)
                    .Select(b => b.item_code)
                    .Single();
            }

            if (MarkCode != 0)
            {
                using (var context = new course_projectEntities())
                {
                    foreach (var mark in context.StudentTeacherItem)
                    {
                        if (mark.MarkID == MarkCode)
                        {
                            mark.mark = MarkBox.Text;
                            mark.dateMark = DateTime.Parse(DateBox.Text);
                            mark.description = DescriptionMarkBox.Text;

                            
                        }
                    }
                    context.SaveChanges();
                }
                teacherMainWindow.MainFrame.Navigate(new JournalPage(ClassCode, teacherMainWindow));
                this.Close();
            }
            else
            {
                try
                {
                    StudentTeacherItem sti = new StudentTeacherItem()
                    {
                        teacher_code = InformationOfUser.id,
                        student_code = StudentCode,
                        item_code = item_code,
                        mark = MarkBox.Text,
                        dateMark = DateTime.Parse(DateBox.Text),
                        description = DescriptionMarkBox.Text
                    };
                    course_projectEntities.GetContext().StudentTeacherItem.Add(sti);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    course_projectEntities.GetContext().SaveChanges();
                    teacherMainWindow.MainFrame.Navigate(new JournalPage(ClassCode, teacherMainWindow));
                    this.Close();
                }
            }
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            teacherMainWindow.MainFrame.Navigate(new JournalPage(ClassCode, teacherMainWindow));
            this.Close();
        }

        public void InsertDataToWindow()
        {
            try
            {
                if (MarkCode != 0)
                    using (var context = new course_projectEntities())
                    {
                        var blank = context.StudentTeacherItem
                            .Where(b => b.MarkID == MarkCode)
                             .Single();
                        DateBox.Text = Convert.ToDateTime(blank.dateMark).ToString("dd-MM-yyyy");
                        MarkBox.Text = blank.mark.Replace(" ", "");
                        DescriptionMarkBox.Text = blank.description;
                    }
                else
                {
                    DateBox.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
