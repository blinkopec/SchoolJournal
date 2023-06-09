using CourseProject.Logic;
using CourseProjectUpdated;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject.StudentVisual.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarksPage.xaml
    /// </summary>
    public partial class MarksPage : Page
    {
        List<InformationOfMarksForItemsControl> itemsContolList;
       

        public MarksPage()
        {
            itemsContolList = new List<InformationOfMarksForItemsControl>();


            InitializeComponent();
            using (var context = new course_projectEntities())
            {
                var class_code = context.Student
                    .Where(b => b.student_code == InformationOfUser.id)
                    .Select(b => b.class_code) 
                    .Single();

                var actualItems = context.TeacherClass
                    .Where(b => b.class_code == class_code)
                    .Select(b => b.Teacher.Item.name)
                    .ToList();

                var itemNames = context.StudentTeacherItem
                    .Where(b => b.student_code == InformationOfUser.id)
                    .Select(b => b.Item.name)
                    .Distinct()
                    .ToList();

                List<string> strings = new List<string>();
                foreach (var item in actualItems)
                {
                    int tmp = 0;
                    foreach (var itemName in itemNames)
                    {
                        if (item.Replace(" ", "") == itemName.Replace(" ", ""))
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 0)
                        strings.Add(item);
                }

                foreach (var item in actualItems)
                {
                    itemsContolList.Add(new InformationOfMarksForItemsControl(item, 25));
                }

                foreach (var item in itemNames)
                {
                    List<Mark> marksForItemsControl = new List<Mark>();

                    var tmp = context.StudentTeacherItem
                        .Where(b => b.Item.name == item)
                        .Where(b => b.student_code == InformationOfUser.id)
                        .Select(b => new
                        {
                            MarkText = b.mark,
                            MarkId = b.MarkID
                        })
                        .ToList();

                    foreach (var s in tmp)
                    {
                        marksForItemsControl.Add(new Mark(s.MarkText.Replace(" ", ""),s.MarkId, InformationOfUser.id));
                    }
                    if (marksForItemsControl.Count < 25)
                    {
                        for (int i = marksForItemsControl.Count; i < 25; i++)
                        {
                            marksForItemsControl.Add(new Mark(" ", 0, InformationOfUser.id));
                        }
                    }
                    itemsContolList.Add(new InformationOfMarksForItemsControl(item, marksForItemsControl));
                }

               

                

                myItemControl.ItemsSource = itemsContolList;
            }
        }

        private void MarkButton_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            if (button == null)
                return;

            var item = button.DataContext as Mark;

            if (item.MarkId != 0)
            {
                MarkDescription md = new MarkDescription(item.MarkId);
                md.Show();
            }
        }
    }
}
