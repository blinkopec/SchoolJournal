using CourseProjectUpdated;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    { 
        public AddTeacherWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            MainGrid.Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));

            using (var context = new course_projectEntities())
            {
                var items = context.Item
                    .Select(b => b.name)
                    .ToList();
                itemBox.ItemsSource = items;
            }
           
        }
        private int ConvertNameItemToCode(string nameItem)
        {
            int result = 0;
            if (nameItem != null)
            {
                using (var context = new course_projectEntities())
                {
                    var items = context.Item
                        .ToList();
                    foreach (Item item in items)
                    {
                        if (item.name == nameItem)
                        {
                            result = item.item_code;
                        }
                    }
                }
            }
            return result;
        }

        private void AddTeacherInDataBase()
        {
            if (surnameBox.Text != null && nameBox.Text != null && middlenameBox.Text != null && itemBox.SelectedItem != null)
            {
                try
                {
                    Teacher tch = new Teacher()
                    {
                        surname = surnameBox.Text,
                        name = nameBox.Text,
                        middlename = middlenameBox.Text,
                        item_code = ConvertNameItemToCode(itemBox.SelectedItem.ToString()),
                        teacher_login = loginBox.Text,
                        teacher_password = HashPassword(passwordBox.Text),
                    };

                    course_projectEntities.GetContext().Teacher.Add(tch);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherInDataBase();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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
