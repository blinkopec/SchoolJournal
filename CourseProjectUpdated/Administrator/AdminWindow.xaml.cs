using CourseProject.Logic;
using CourseProjectUpdated;
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

namespace CourseProject.Administrator
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private bool _isStudent;
        private bool _isAdmin;
        private bool _isTeacher;
        private bool _isClass;
        private bool _isTeacherClass;
        private bool _isStudentTeacherItem;
        private bool _isItem;
        private bool _isTimeTable;

        public AdminWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            MainGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            ButtonPanel.Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
        }

        #region SaveAndDeleteClicks
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (_isAdmin)
            {
                Administrators tmp = dg.SelectedItem as Administrators;
                if (tmp != null)
                {
                    tmp = RemoveSpaces(tmp, Tables.Admin) as Administrators;
                    if (tmp.id_admin == 0)
                        course_projectEntities.GetContext().Administrators.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<Administrators> admins = course_projectEntities.GetContext().Administrators.ToList();
                    List<Administrators> updatetAdmins = new List<Administrators>();
                    foreach (Administrators tcs in admins)
                    {
                        updatetAdmins.Add(RemoveSpaces(tcs, Tables.Admin) as Administrators);
                    }
                    dg.ItemsSource = updatetAdmins;
                }
            }
            if (_isClass)
            {
                Class tmp = dg.SelectedItem as Class;
                if (tmp != null)
                {
                    tmp = RemoveSpaces(tmp, Tables.Class) as Class;
                    if (tmp.class_code == 0)
                        course_projectEntities.GetContext().Class.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<Class> classes = course_projectEntities.GetContext().Class.ToList();
                    List<Class> updatetedClasses = new List<Class>();
                    foreach (Class cls in classes)
                    {
                        updatetedClasses.Add(RemoveSpaces(cls, Tables.Class) as Class);
                    }
                    dg.ItemsSource = updatetedClasses;
                    dg.Columns[3].MaxWidth = 0;
                    dg.Columns[4].MaxWidth = 0;
                }
            }
            if (_isItem)
            {
                Item tmp = dg.SelectedItem as Item;
                if (tmp != null)
                {
                    tmp = RemoveSpaces(tmp, Tables.Item) as Item;
                    if (tmp.item_code == 0)
                        course_projectEntities.GetContext().Item.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<Item> items = course_projectEntities.GetContext().Item.ToList();
                    List<Item> updatetItems = new List<Item>();
                    foreach (Item tcs in items)
                    {
                        updatetItems.Add(RemoveSpaces(tcs, Tables.Item) as Item);
                    }
                    dg.ItemsSource = updatetItems;
                    dg.Columns[2].MaxWidth = 0;
                    dg.Columns[3].MaxWidth = 0;
                }
            }
            if (_isStudent)
            {
                Student tmp = dg.SelectedItem as Student;
                if (tmp != null)
                {
                    tmp = RemoveSpaces(tmp, Tables.Student) as Student;
                    if (tmp.student_code == 0)
                        course_projectEntities.GetContext().Student.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<Student> students = course_projectEntities.GetContext().Student.ToList();
                    List<Student> updatetedStudents = new List<Student>();
                    foreach (Student stud in students)
                    {
                        updatetedStudents.Add(RemoveSpaces(stud, Tables.Student) as Student);
                    }
                    dg.ItemsSource = updatetedStudents;
                    dg.Columns[7].MaxWidth = 0;
                    dg.Columns[8].MaxWidth = 0;
                }
            }
            if (_isStudentTeacherItem)
            {
                StudentTeacherItem tmp = dg.SelectedItem as StudentTeacherItem;
                if (tmp != null)
                {
                    if (tmp.MarkID == 0)
                        course_projectEntities.GetContext().StudentTeacherItem.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<StudentTeacherItem> stis = course_projectEntities.GetContext().StudentTeacherItem.ToList();
                    dg.ItemsSource = stis;
                    dg.Columns[6].MaxWidth = 0;
                    dg.Columns[7].MaxWidth = 0;
                    dg.Columns[8].MaxWidth = 0;
                }
            }
            if (_isTeacher)
            {
                Teacher tmp = dg.SelectedItem as Teacher;
                if (tmp != null)
                {
                    tmp = RemoveSpaces(tmp, Tables.Teacher) as Teacher;
                    if (tmp.teacher_code == 0)
                        course_projectEntities.GetContext().Teacher.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<Teacher> teachers = course_projectEntities.GetContext().Teacher.ToList();
                    List<Teacher> updatetedTeachers = new List<Teacher>();
                    foreach (Teacher teach in teachers)
                    {
                        updatetedTeachers.Add(RemoveSpaces(teach, Tables.Teacher) as Teacher);
                    }
                    dg.ItemsSource = updatetedTeachers;
                    dg.Columns[7].MaxWidth = 0;
                    dg.Columns[8].MaxWidth = 0;
                    dg.Columns[9].MaxWidth = 0;
                }
            }
            if (_isTeacherClass)
            {
                TeacherClass tmp = dg.SelectedItem as TeacherClass;
                if (tmp != null)
                {
                    if (tmp.teacherclass_code == 0)
                        course_projectEntities.GetContext().TeacherClass.Add(tmp);
                    course_projectEntities.GetContext().SaveChanges();
                    List<TeacherClass> teachClass = course_projectEntities.GetContext().TeacherClass.ToList();
                    dg.ItemsSource = teachClass;
                    dg.Columns[3].MaxWidth = 0;
                    dg.Columns[4].MaxWidth = 0;
                }
            }
            if (_isTimeTable)
            {
                TimeTable tt = dg.SelectedItem as TimeTable;
                if (tt != null)
                {
                    if (tt.id_timetable == 0)
                        course_projectEntities.GetContext().TimeTable.Add(tt);
                    course_projectEntities.GetContext().SaveChanges();
                    List<TimeTable> timeTable = course_projectEntities.GetContext().TimeTable.ToList();
                    dg.ItemsSource = timeTable;
                    dg.Columns[7].MaxWidth = 0;
                    dg.Columns[8].MaxWidth = 0;
                    dg.Columns[9].MaxWidth = 0; 
                }
            }
        }

        private static object RemoveSpaces(object obj, Tables s) 
        {
            if (obj != null)
            {
                if (s == Tables.Student)
                {
                    Student tmp = obj as Student;
                    tmp.surname = tmp.surname.Replace(" ", "");
                    tmp.middlename = tmp.middlename.Replace(" ", "");
                    tmp.nameStudent = tmp.nameStudent.Replace(" ", "");
                    return tmp;
                }
               
                if (s == Tables.Item)
                {
                    Item tmp = obj as Item;
                    tmp.name = tmp.name.Replace(" ", "");
                    return tmp;
                }
                if (s == Tables.Teacher)
                {
                    Teacher tmp = obj as Teacher;
                    tmp.name = tmp.name.Replace(" ", "");
                    tmp.surname = tmp.surname.Replace(" ", ""); ;
                    tmp.middlename = tmp.middlename.Replace(" ", "");
                    return tmp;
                }
                if (s == Tables.Class)
                {
                    Class tmp = obj as Class;
                    tmp.name = tmp.name.Replace(" ", "");
                    return tmp;
                }
            }
            return null;
        }

        enum Tables
        {
            Admin,
            Student,
            Class,
            Teacher,
            Item,
        }

        private void DeleteRowButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (_isAdmin)
                {
                    Administrators tmp = dg.SelectedItem as Administrators;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().Administrators.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<Administrators> admins = course_projectEntities.GetContext().Administrators.ToList();
                        List<Administrators> updatetAdmins = new List<Administrators>();
                        foreach (Administrators tcs in admins)
                        {
                            updatetAdmins.Add(RemoveSpaces(tcs, Tables.Admin) as Administrators);
                        }
                        dg.ItemsSource = updatetAdmins;
                    }
                }
                if (_isClass)
                {
                    Class tmp = dg.SelectedItem as Class;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().Class.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<Class> classes = course_projectEntities.GetContext().Class.ToList();
                        List<Class> updatetedClasses = new List<Class>();
                        foreach (Class cls in classes)
                        {
                            updatetedClasses.Add(RemoveSpaces(cls, Tables.Class) as Class);
                        }
                        dg.ItemsSource = updatetedClasses;
                        dg.Columns[3].MaxWidth = 0;
                        dg.Columns[4].MaxWidth = 0;
                    }
                }
                if (_isItem)
                {
                    Item tmp = dg.SelectedItem as Item;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().Item.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<Item> items = course_projectEntities.GetContext().Item.ToList();
                        List<Item> updatetItems = new List<Item>();
                        foreach (Item tcs in items)
                        {
                            updatetItems.Add(RemoveSpaces(tcs, Tables.Item) as Item);
                        }
                        dg.ItemsSource = updatetItems;
                        dg.Columns[2].MaxWidth = 0;
                        dg.Columns[3].MaxWidth = 0;
                    }
                }
                if (_isStudent)
                {
                    Student tmp = dg.SelectedItem as Student;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().Student.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<Student> students = course_projectEntities.GetContext().Student.ToList();
                        List<Student> updatetedStudents = new List<Student>();
                        foreach (Student stud in students)
                        {
                            updatetedStudents.Add(RemoveSpaces(stud, Tables.Student) as Student);
                        }
                        dg.ItemsSource = updatetedStudents;
                        dg.Columns[7].MaxWidth = 0;
                        dg.Columns[8].MaxWidth = 0;
                    }
                }
                if (_isStudentTeacherItem)
                {
                    StudentTeacherItem tmp = dg.SelectedItem as StudentTeacherItem;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().StudentTeacherItem.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<StudentTeacherItem> stis = course_projectEntities.GetContext().StudentTeacherItem.ToList();
                        dg.ItemsSource = stis;
                        dg.Columns[6].MaxWidth = 0;
                        dg.Columns[7].MaxWidth = 0;
                        dg.Columns[8].MaxWidth = 0;
                    }
                }
                if (_isTeacher)
                {
                    Teacher tmp = dg.SelectedItem as Teacher;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().Teacher.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<Teacher> teachers = course_projectEntities.GetContext().Teacher.ToList();
                        List<Teacher> updatetedTeachers = new List<Teacher>();
                        foreach (Teacher teach in teachers)
                        {
                            updatetedTeachers.Add(RemoveSpaces(teach, Tables.Teacher) as Teacher);
                        }
                        dg.ItemsSource = updatetedTeachers;
                        dg.Columns[7].MaxWidth = 0;
                        dg.Columns[8].MaxWidth = 0;
                        dg.Columns[9].MaxWidth = 0;
                    }
                }
                if (_isTeacherClass)
                {
                    TeacherClass tmp = dg.SelectedItem as TeacherClass;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().TeacherClass.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<TeacherClass> teachClass = course_projectEntities.GetContext().TeacherClass.ToList();
                        dg.ItemsSource = teachClass;
                        dg.Columns[3].MaxWidth = 0;
                        dg.Columns[4].MaxWidth = 0;
                    }
                }
                if (_isTimeTable)
                {
                    TimeTable tmp = dg.SelectedItem as TimeTable;
                    if (tmp != null)
                    {
                        course_projectEntities.GetContext().TimeTable.Remove(tmp);
                        course_projectEntities.GetContext().SaveChanges();
                        List<TimeTable> timeTable = course_projectEntities.GetContext().TimeTable.ToList();
                        dg.ItemsSource = timeTable;
                        dg.Columns[7].MaxWidth = 0;
                        dg.Columns[8].MaxWidth = 0;
                        dg.Columns[9].MaxWidth = 0;
                    }
                }
            }
        }
        #endregion

        #region SelectButtonClicks
        private void SeletTimeTable_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = false;
            _isTeacher = false;
            _isTeacherClass = false;
            _isStudentTeacherItem = false;
            _isItem = false;
            _isClass = false;
            _isTimeTable = true;

            List<TimeTable> timesTables = course_projectEntities.GetContext().TimeTable.ToList();
            dg.ItemsSource = timesTables;
            dg.Columns[7].MaxWidth = 0;
            dg.Columns[8].MaxWidth = 0;
            dg.Columns[9].MaxWidth = 0;
        }

        private void SelectStudentButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = true;
            _isAdmin = false;
            _isTeacher = false;
            _isTeacherClass = false;
            _isStudentTeacherItem = false;
            _isItem = false;
            _isClass = false;
            _isTimeTable = false;

            List<Student> students = course_projectEntities.GetContext().Student.ToList();
            List<Student> updatetedStudents = new List<Student>();
            foreach (Student stud in students)
            {
                updatetedStudents.Add(RemoveSpaces(stud, Tables.Student) as Student);
            }
            dg.ItemsSource = updatetedStudents;
            dg.Columns[7].MaxWidth = 0;
            dg.Columns[8].MaxWidth = 0;
        }

        private void SelectTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = false;
            _isTeacher = true;
            _isTeacherClass = false;
            _isStudentTeacherItem = false;
            _isItem = false;
            _isClass = false;
            _isTimeTable = false;

            List<Teacher> teachers = course_projectEntities.GetContext().Teacher.ToList();
            List<Teacher> updatetedTeachers = new List<Teacher>();
            foreach (Teacher teach in teachers)
            {
                updatetedTeachers.Add(RemoveSpaces(teach, Tables.Teacher) as Teacher);
            }
            dg.ItemsSource = updatetedTeachers;
            dg.Columns[7].MaxWidth = 0;
            dg.Columns[8].MaxWidth = 0;
            dg.Columns[9].MaxWidth = 0;
        }

        private void SelectClassButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = false;
            _isTeacher = false;
            _isTeacherClass = false;
            _isStudentTeacherItem = false;
            _isItem = false;
            _isClass = true;
            _isTimeTable = false;

            List<Class> classes = course_projectEntities.GetContext().Class.ToList();
            List<Class> updatetedClasses = new List<Class>();
            foreach (Class cls in classes)
            {
                updatetedClasses.Add(RemoveSpaces(cls, Tables.Class) as Class);
            }
            dg.ItemsSource = updatetedClasses;
            dg.Columns[3].MaxWidth = 0;
            dg.Columns[4].MaxWidth = 0;
        }

        private void SelectTeacherClassButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = false;
            _isTeacher = false;
            _isTeacherClass = true;
            _isStudentTeacherItem = false;
            _isItem = false;
            _isClass = false;
            _isTimeTable = false;

            List<TeacherClass> teachClass = course_projectEntities.GetContext().TeacherClass.ToList();
            dg.ItemsSource = teachClass;

            dg.Columns[3].MaxWidth = 0;
            dg.Columns[4].MaxWidth = 0;
        }

        private void SelectStudentTeacherItemButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = false;
            _isTeacher = false;
            _isTeacherClass = false;
            _isStudentTeacherItem = true;
            _isItem = false;
            _isClass = false;
            _isTimeTable = false;

            List<StudentTeacherItem> stis = course_projectEntities.GetContext().StudentTeacherItem.ToList();
            dg.ItemsSource = stis;
            dg.Columns[6].MaxWidth = 0;
            dg.Columns[7].MaxWidth = 0;
            dg.Columns[8].MaxWidth = 0;
        }

        private void SelectItemButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = false;
            _isTeacher = false;
            _isTeacherClass = false;
            _isStudentTeacherItem = false;
            _isItem = true;
            _isClass = false;
            _isTimeTable = false;

            List<Item> items = course_projectEntities.GetContext().Item.ToList();
            List<Item> updatetItems = new List<Item>();
            foreach (Item tcs in items)
            {
                updatetItems.Add(RemoveSpaces(tcs, Tables.Item) as Item);
            }
            dg.ItemsSource = updatetItems;
            dg.Columns[2].MaxWidth = 0;
            dg.Columns[3].MaxWidth = 0;
        }

        private void SelectAdminButton_Click(object sender, RoutedEventArgs e)
        {
            _isStudent = false;
            _isAdmin = true;
            _isTeacher = false;
            _isTeacherClass = false;
            _isStudentTeacherItem = false;
            _isItem = false;
            _isClass = false;
            _isTimeTable = false;

            List<Administrators> admins = course_projectEntities.GetContext().Administrators.ToList();
            //List<Administrators> updatetAdmins = new List<Administrators>();
            //foreach (Administrators tcs in admins)
            //{
            //    updatetAdmins.Add(RemoveSpaces(tcs, Tables.Admin) as Administrators);
            //}
            dg.ItemsSource = admins ;
        }
        #endregion

        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherWindow atw = new AddTeacherWindow();
            atw.Show();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow asw = new AddStudentWindow();
            asw.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            InformationOfUser.id = 0;
            InformationOfUser.type = TypeUserEnum.None;
            mw.Show();
            this.Close();
        }
    }
}
