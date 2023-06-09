using CourseProject.Logic;
using CourseProjectUpdated.StudentVisual.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProjectUpdated.TeacherVisual.Pages
{
    /// <summary>
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        private List<TableStudents> tableToItemControl;
        private int classCode { get; set; }
        private TeacherMainWindow teacherMainWindow { get; set; }
        public JournalPage(int classCode, TeacherMainWindow teacherMainWindow)
        {
            tableToItemControl = new List<TableStudents>();
            this.classCode = classCode;
            this.teacherMainWindow = teacherMainWindow;

            InitializeComponent();

            using (var context = new course_projectEntities())
            {
                var teacher = context.Teacher
                    .Where(b => b.teacher_code == InformationOfUser.id)
                    .Single();
                try
                {
                    var students = context.Student
                        .Where(b => b.class_code == classCode)
                        .Select(b => new
                        {
                            StudentCode = b.student_code,
                            StudentName = b.nameStudent,
                            StudentSurname = b.surname,
                            StudentMiddlename = b.middlename
                        })
                        .ToList();

                    foreach (var student in students)
                    {
                        try
                        {
                            List<Mark> marks = new List<Mark>();
                            var markTmp = context.StudentTeacherItem
                                .Where(b => b.student_code == student.StudentCode)
                                .Where(b => b.item_code == teacher.item_code)
                                .Select(b => new
                                {
                                    MarkText = b.mark,
                                    MarkId = b.MarkID,
                                })
                                .ToList(); //по предмету учителя сделать

                            foreach (var m in markTmp)
                            {
                                marks.Add(new Mark(m.MarkText.Replace(" ", ""), m.MarkId, student.StudentCode));
                            }

                            if (marks.Count < 19)
                            {
                                for (int i = marks.Count; i < 24; i++)
                                {
                                    marks.Add(new Mark(" ", 0, student.StudentCode));
                                }
                            }

                            tableToItemControl.Add(new TableStudents(student.StudentCode, student.StudentName,student.StudentSurname,
                                student.StudentMiddlename, marks));
                        }
                        catch (Exception ex)
                        {
                            tableToItemControl.Add(new TableStudents(student.StudentCode, student.StudentName,
                                student.StudentSurname,student.StudentMiddlename, 24));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("В ");
                }
            }

            //string s = null;
            //foreach (TableStudents item in tableToItemControl)
            //{
            //    s += item.StudentName;
            //    foreach (Mark mark in item.marks)
            //    {
            //        s += " " + mark.MarkText.Replace(" ", "");
            //    }
            //}
            //MessageBox.Show(s);

            MainControl.ItemsSource = tableToItemControl;
        }

        private void MarkButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            var item = button.DataContext as Mark;
            MarkWindow mw = new MarkWindow(item.MarkId, item.StudentCode,teacherMainWindow, classCode);
            mw.Show();
        }
    }
}
