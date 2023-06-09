using CourseProject.Administrator;
using CourseProject.Logic;
using CourseProject.StudentVisual;
using CourseProjectUpdated;
using CourseProjectUpdated.TeacherVisual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            MainGrid.Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));

            //using (var context = new course_projectEntities())
            //{
            //    var blogs = context.Student
            //        .Where(b => b.student_login == "makar")
            //        .ToList();
            //}


        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //в зависимоти от ошибки (логин или пароль неправильные). Выводим это в ErrorLabel
            //пароль в бд должен храниться в зашифрованном виде
            if (PsswdBox.Password != null && LoginBox.Text != null)
            {
                string pswdOnDatabase = null;
                bool isStudent = false;
                bool isTeacher = false;
                bool isAdministrator = false;

                using (var context = new course_projectEntities())
                {
                    try
                    {
                        pswdOnDatabase = context.Student
                            .Where(b => b.student_login == LoginBox.Text)
                            .Select(b => b.student_password)
                            .Single();

                        if (pswdOnDatabase != null)
                            isStudent = true;
                    }
                    catch (Exception ex)
                    {
                        ErrorLabel.Content = "Неверный логин или пароль";
                    }

                    if (!isStudent)
                    {
                        try
                        {
                            pswdOnDatabase = context.Teacher
                            .Where(b => b.teacher_login == LoginBox.Text)
                            .Select(b => b.teacher_password)
                            .Single();

                            if (pswdOnDatabase != null)
                                isTeacher = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLabel.Content = "Неверный логин или пароль";
                        }
                    }
                    if (!isStudent && !isTeacher)
                    {
                        try
                        {
                            pswdOnDatabase = context.Administrators
                           .Where(b => b.login_admin == LoginBox.Text)
                           .Select(b => b.password_admin)
                           .Single();
                            if (pswdOnDatabase != null)
                                isAdministrator = true;
                        }
                        catch(Exception ex)
                        {
                            ErrorLabel.Content = "Неверный логин или пароль";
                        }
                    }

                } 
                if (pswdOnDatabase != null)
                {
                    string hashedpassword = HashPassword(PsswdBox.Password);
                    if (VerifyHashedPassword(hashedpassword, LoginBox.Text))
                    { 
                        //переход
                        if (isStudent)
                        {
                            InformationOfUser.type = TypeUserEnum.Student;
                            using (var context = new course_projectEntities())
                            {
                                InformationOfUser.id = context.Student
                                    .Where(b => b.student_login == LoginBox.Text)
                                    .Select(b => b.student_code)
                                    .Single();
                            }
                            StudentMainWindow smw = new StudentMainWindow();
                            smw.Show();
                            this.Close();
                        }   
                        if (isAdministrator)
                        {
                            InformationOfUser.type = TypeUserEnum.Admin;
                            using (var context = new course_projectEntities())
                            {
                                InformationOfUser.id = context.Administrators
                                    .Where(b => b.login_admin == LoginBox.Text)
                                    .Select(b => b.id_admin)
                                    .Single();
                            }
                            AdminWindow amw = new AdminWindow();
                            amw.Show();
                            this.Close();
                        }
                        if (isTeacher)
                        {
                            InformationOfUser.type = TypeUserEnum.Teacher;
                            using (var context = new course_projectEntities())
                            {
                                InformationOfUser.id = context.Teacher
                                    .Where(b => b.teacher_login == LoginBox.Text)
                                    .Select(b => b.teacher_code)
                                    .Single();
                            }
                            TeacherMainWindow tmw = new TeacherMainWindow();
                            tmw.Show();
                            this.Close();
                        }
                    }
                }
            }

        }
    

        #region HashPassword
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

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
        #endregion
    }
}
