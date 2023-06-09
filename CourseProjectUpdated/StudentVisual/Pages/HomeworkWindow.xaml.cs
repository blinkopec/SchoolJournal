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
    /// Логика взаимодействия для HomeworkWindow.xaml
    /// </summary>
    public partial class HomeworkWindow : Window
    {
        public HomeworkWindow(DateTime date, string itemName, string description)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ItemTittleLabel.Content = itemName;
            DateLabel.Content = date.Date;
            DescriptionBlock.Text = description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
