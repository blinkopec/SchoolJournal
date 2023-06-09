using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.StudentVisual.Pages
{
    internal class Day
    {
        public int code_timetable { get; set; }
        public string item_name { get; set; }
        public int class_code { get; set; }
        public string teacher_name { get; set;}
        public string class_name { get; set; }
        public string day_name { get; set; }
        public int number_item { get; set; }

        public Day(int code_timetable,string item_name, int class_code,string class_name, string teach_name, string teach_surname,string teach_middlename, string day_name, int number_item)
        {
            this.code_timetable = code_timetable;
            this.item_name = item_name;
            this.class_code = class_code;
            this.teacher_name = ConvertNameToFio(teach_surname, teach_name, teach_middlename);
            this.class_name = class_name;
            this.day_name = day_name;
            this.number_item = number_item;
        }

        public string ConvertNameToFio(string surname, string name, string middlename)
        {
            string result = null;

            if (surname != null && name != null && middlename != null)
                result += surname + " " + name[0] + ". " + middlename[0] + ".";

            return result;
        }
    }
}
