using CourseProject.Logic;
using CourseProject.StudentVisual.Pages;
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

namespace CourseProjectUpdated.TeacherVisual.Pages
{
    /// <summary>
    /// Логика взаимодействия для TImeTableTeacher.xaml
    /// </summary>
    public partial class TImeTableTeacher : Page
    {
        DateTime date;
        int dayofweek;
        List<TimeTable> timeTables;
        List<Day> Mondays;
        List<Day> Thuesdays;
        List<Day> Wednesdays;
        List<Day> Thursdays;
        List<Day> Fridays;
        List<Day> Saturdays;

        public TImeTableTeacher()
        {
            InitializeComponent();

            date = DateTime.Today;
            dayofweek = (int)date.DayOfWeek;

            Mondays = new List<Day>();
            Thuesdays = new List<Day>();
            Wednesdays = new List<Day>();
            Thursdays = new List<Day>();
            Fridays = new List<Day>();
            Saturdays = new List<Day>();

            timeTables = course_projectEntities.GetContext().TimeTable
                    .Where(b => b.teacher_code == InformationOfUser.id)
                    .ToList();

            List<DateTime> intervalOfDate = ConvertDateToWeek(date, dayofweek);
            GetActualTimeTable(timeTables, intervalOfDate);
            InsertItems();
        }
        private List<DateTime> ConvertDateToWeek(DateTime dt, int dofweek)
        {
            List<DateTime> result = new List<DateTime>();

            if (dofweek == 1) //понедельник
            {
                result.Add(dt);
                result.Add(dt.AddDays(1));
                result.Add(dt.AddDays(2));
                result.Add(dt.AddDays(3));
                result.Add(dt.AddDays(4));
                result.Add(dt.AddDays(5));
                result.Add(dt.AddDays(6));


                //string sat = null;
                //foreach (DateTime df in result)
                //{
                //    sat += df.DayOfWeek.ToString() + "   ";
                //}
                //MessageBox.Show(sat);
            }
            if (dofweek == 2)
            {
                result.Add(dt.Subtract(new TimeSpan(10)));
                result.Add(dt);
                result.Add(dt.AddDays(1));
                result.Add(dt.AddDays(2));
                result.Add(dt.AddDays(3));
                result.Add(dt.AddDays(4));
                result.Add(dt.AddDays(5));
            }
            if (dofweek == 3)
            {
                result.Add(dt.Subtract(TimeSpan.FromDays(2)));
                result.Add(dt.Subtract(TimeSpan.FromDays(1)));
                result.Add(dt);
                result.Add(dt.AddDays(1));
                result.Add(dt.AddDays(2));
                result.Add(dt.AddDays(3));
                result.Add(dt.AddDays(4));

            }
            if (dofweek == 4)
            {
                result.Add(dt.Subtract(TimeSpan.FromDays(3)));
                result.Add(dt.Subtract(TimeSpan.FromDays(2)));
                result.Add(dt.Subtract(TimeSpan.FromDays(1)));
                result.Add(dt);
                result.Add(dt.AddDays(1));
                result.Add(dt.AddDays(2));
                result.Add(dt.AddDays(3));
            }
            if (dofweek == 5)
            {
                result.Add(dt.Subtract(TimeSpan.FromDays(4)));
                result.Add(dt.Subtract(TimeSpan.FromDays(3)));
                result.Add(dt.Subtract(TimeSpan.FromDays(2)));
                result.Add(dt.Subtract(TimeSpan.FromDays(1)));
                result.Add(dt);
                result.Add(dt.AddDays(1));
                result.Add(dt.AddDays(2));
            }
            if (dofweek == 6) //с субботы показываем следующее расписание если есть
            {
                result.Add(dt.AddDays(2));
                result.Add(dt.AddDays(3));
                result.Add(dt.AddDays(4));
                result.Add(dt.AddDays(5));
                result.Add(dt.AddDays(6));
                result.Add(dt.AddDays(7));
                result.Add(dt.AddDays(8));
            }
            if (dofweek == 7)
            {
                result.Add(dt.AddDays(3));
                result.Add(dt.AddDays(4));
                result.Add(dt.AddDays(5));
                result.Add(dt.AddDays(6));
                result.Add(dt.AddDays(7));
                result.Add(dt.AddDays(8));
                result.Add(dt.AddDays(9));
            }

            return result;
        }

        private void GetActualTimeTable(List<TimeTable> ttlist, List<DateTime> intervalList)
        {
            if (ttlist != null && intervalList != null)
            {
                foreach (TimeTable table in ttlist)
                {
                    foreach (DateTime dt in intervalList)
                    {
                        if (Convert.ToDateTime(table.date_timetable).Date == dt.Date)
                        {
                            Day tmp = new Day(table.id_timetable, table.Item.name, (int)table.class_code, table.Class.name,table.Teacher.name, table.Teacher.surname, table.Teacher.middlename, dt.DayOfWeek.ToString(), (int)table.number_of_item);
                            if ((int)dt.DayOfWeek == 1)
                                Mondays.Add(tmp);
                            if ((int)dt.DayOfWeek == 2)
                                Thuesdays.Add(tmp);
                            if ((int)dt.DayOfWeek == 3)
                                Wednesdays.Add(tmp);
                            if ((int)dt.DayOfWeek == 4)
                                Thursdays.Add(tmp);
                            if ((int)dt.DayOfWeek == 5)
                                Fridays.Add(tmp);
                            if ((int)dt.DayOfWeek == 6)
                                Saturdays.Add(tmp);
                        }
                    }
                }
            }
        }

        private void InsertItems()
        {
            foreach (Day day in Mondays)
            {
                if (day.number_item == 1)
                {
                    MondayItem1.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 2)
                {
                    MondayItem2.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 3)
                {
                    MondayItem3.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 4)
                {
                    MondayItem4.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 5)
                {
                    MondayItem5.Content = day.item_name + "\n" + day.class_name;
                }
            }

            foreach (Day day in Thuesdays)
            {
                if (day.number_item == 1)
                {
                    ThuesdayItem1.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 2)
                {
                    ThuesdayItem2.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 3)
                {
                    ThuesdayItem3.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 4)
                {
                    ThuesdayItem4.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 5)
                {
                    ThuesdayItem5.Content = day.item_name + "\n" + day.class_name;
                }
            }

            foreach (Day day in Wednesdays)
            {
                if (day.number_item == 1)
                {
                    WednesdayItem1.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 2)
                {
                    WednesdayItem2.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 3)
                {
                    WednesdayItem3.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 4)
                {
                    WednesdayItem4.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 5)
                {
                    WednesdayItem5.Content = day.item_name + "\n" + day.class_name;
                }
            }

            foreach (Day day in Thursdays)
            {
                if (day.number_item == 1)
                {
                    ThursdayItem1.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 2)
                {
                    ThursdayItem2.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 3)
                {
                    ThursdayItem3.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 4)
                {
                    ThursdayItem4.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 5)
                {
                    ThursdayItem5.Content = day.item_name + "\n" + day.class_name;
                }
            }

            foreach (Day day in Fridays)
            {
                if (day.number_item == 1)
                {
                    FridayItem1.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 2)
                {
                    FridayItem2.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 3)
                {
                    FridayItem3.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 4)
                {
                    FridayItem4.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 5)
                {
                    FridayItem5.Content = day.item_name + "\n" + day.class_name;
                }
            }

            foreach (Day day in Saturdays)
            {
                if (day.number_item == 1)
                {
                    SaturdayItem1.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 2)
                {
                    SaturdayItem2.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 3)
                {
                    SaturdayItem3.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 4)
                {
                    SaturdayItem4.Content = day.item_name + "\n" + day.class_name;
                }
                if (day.number_item == 5)
                {
                    SaturdayItem5.Content = day.item_name + "\n" + day.class_name;
                }
            }
        }



        #region ButtonHandlers
        #region Mondays

        private void MondayItem1_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Mondays)
                if (day.number_item == 1)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void MondayItem2_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Mondays)
                if (day.number_item == 2)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void MondayItem3_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Mondays)
                if (day.number_item == 3)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void MondayItem4_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Mondays)
                if (day.number_item == 4)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void MondayItem5_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Mondays)
                if (day.number_item == 5)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        #endregion

        #region Thuesdays
        private void ThuesdayItem1_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thuesdays)
                if (day.number_item == 1)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThuesdayItem2_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thuesdays)
                if (day.number_item == 2)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThuesdayItem4_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thuesdays)
                if (day.number_item == 4)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThuesdayItem3_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thuesdays)
                if (day.number_item == 3)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThuesdayItem5_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thuesdays)
                if (day.number_item == 5)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }
        #endregion

        #region Wednesdays
        private void WednesdayItem1_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Wednesdays)
                if (day.number_item == 1)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void WednesdayItem2_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Wednesdays)
                if (day.number_item == 2)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void WednesdayItem3_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Wednesdays)
                if (day.number_item == 3)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void WednesdayItem4_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Wednesdays)
                if (day.number_item == 4)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void WednesdayItem5_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Wednesdays)
                if (day.number_item == 5)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }
        #endregion

        #region Thursdays
        private void ThursdayItem1_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thursdays)
                if (day.number_item == 1)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThursdayItem2_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thursdays)
                if (day.number_item == 2)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

            private void ThursdayItem3_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thursdays)
                if (day.number_item == 3)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThursdayItem4_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thursdays)
                if (day.number_item == 4)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void ThursdayItem5_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Thursdays)
                if (day.number_item == 5)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }
        #endregion

        #region Fridays
        private void FridayItem1_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Fridays)
                if (day.number_item == 1)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void FridayItem2_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Fridays)
                if (day.number_item == 2)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void FridayItem3_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Fridays)
                if (day.number_item == 3)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void FridayItem4_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Fridays)
                if (day.number_item == 4)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void FridayItem5_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Fridays)
                if (day.number_item == 5)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }
        #endregion

        #region Saturdays
        private void SaturdayItem1_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Saturdays)
                if (day.number_item == 1)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void SaturdayItem2_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Saturdays)
                if (day.number_item == 2)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void SaturdayItem3_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Saturdays)
                if (day.number_item == 3)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void SaturdayItem4_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Saturdays)
                if (day.number_item == 4)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }

        private void SaturdayItem5_Click(object sender, RoutedEventArgs e)
        {
            Day item = null;
            foreach (Day day in Saturdays)
                if (day.number_item == 5)
                    item = day;



            if (item != null)
            {

                using (var context = new course_projectEntities())
                {
                    var infoOfItem = context.TimeTable
                      .Where(b => b.id_timetable == item.code_timetable)
                      .Select(b => new
                      {
                          date = (DateTime)b.date_timetable,
                          desc = b.description_of_item
                      })
                      .Single();


                    AddHomeworkWindow ahw = new AddHomeworkWindow(item.code_timetable, infoOfItem.date, infoOfItem.desc);
                    ahw.Show();
                }
            }
        }
        #endregion
        #endregion
    }
}
