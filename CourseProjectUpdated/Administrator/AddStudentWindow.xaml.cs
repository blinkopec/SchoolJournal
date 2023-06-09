using CourseProjectUpdated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            MainGrid.Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));

            using (var context = new course_projectEntities())
            {
                var classes = context.Class
                    .Select(b => b.name)
                    .ToList();
                classBox.ItemsSource = classes;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherInDataBase();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddTeacherInDataBase()
        {
            if (surnameBox.Text != null && nameBox.Text != null && middlenameBox.Text != null && classBox.SelectedItem != null)
            {
                try
                {
                    Student std = new Student()
                    {
                        surname = surnameBox.Text,
                        nameStudent = nameBox.Text,
                        middlename = middlenameBox.Text,
                        class_code = ConvertNameClassToCode(classBox.SelectedItem.ToString()),
                        student_login = loginBox.Text,
                        student_password = HashPassword(passwordBox.Text),
                    };

                    course_projectEntities.GetContext().Student.Add(std);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    course_projectEntities.GetContext().SaveChanges();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните данные!");
            }
        }
        private int ConvertNameClassToCode(string nameItem)
        {
            int result = 0;
            if (nameItem != null)
            {
                using (var context = new course_projectEntities())
                {
                    var classes = context.Class
                        .ToList();
                    foreach (Class cls in classes)
                    {
                        if (cls.name == nameItem)
                        {
                            result = cls.class_code;
                        }
                    }
                }
            }
            return result;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}
