using CourseProject.Logic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для TeacherUserPage.xaml
    /// </summary>
    public partial class TeacherUserPage : Page
    {
        public TeacherUserPage()
        {
            InitializeComponent();
            using (var context = new course_projectEntities())
            {
                var teacher = context.Teacher
                    .Where(b => b.teacher_code == InformationOfUser.id)
                    .Single();

                if (teacher.teacherImage != null)
                    ImageProfile.Source = ImgFromBytes(teacher.teacherImage);
                SurnameBox.Text = teacher.surname;
                NameBox.Text = teacher.name;
                MiddlenameBox.Text = teacher.middlename;

            }
        }

        private void LoadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                ImageProfile.Source = new BitmapImage(new Uri(@dlg.FileName));

                using (var context = new course_projectEntities())
                {
                    foreach (var std in context.Teacher)
                    {
                        if (std.teacher_code == InformationOfUser.id)
                        {
                            std.teacherImage = ImageToByteArr(new BitmapImage(new Uri(@dlg.FileName)));
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameBox.Text != null && NameBox.Text != null && MiddlenameBox.Text != null)
            {
                using (var context = new course_projectEntities())
                {
                    foreach (var std in context.Teacher)
                    {
                        if (std.teacher_code == InformationOfUser.id)
                        {
                            std.surname = SurnameBox.Text;
                            std.name = NameBox.Text;
                            std.middlename = MiddlenameBox.Text;
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private byte[] ImageToByteArr(BitmapImage bmp)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
                return data;
            }
        }

        private static BitmapImage ImgFromBytes(byte[] arr)
        {
            var image = new BitmapImage();

            using (var mem = new MemoryStream(arr))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();

            return image;
        }
    }
}
