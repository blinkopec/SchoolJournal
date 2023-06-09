using CourseProject.Logic;
using CourseProjectUpdated.StudentVisual.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectUpdated.TeacherVisual.Pages
{
    class TableStudents
    {
        public int StudentCode { get; set; }
        public string StudentName { get; set; }
        public List<Mark> marks { get; set; }
        public int AVG { get; set; }

        //у оценок с нулевым айдишником нет привязки в бд
        public TableStudents(int StudentCode,string StudentName, string StudentSurname, string StudentMiddlename, List<Mark> marks) 
        { 
            this.StudentCode = StudentCode;
            this.StudentName = StudentSurname + " " + StudentName[0] + ". " + StudentMiddlename[0] + ".";
            this.marks = marks; 
            AVG = CalculateAVG(marks);
        }

        public TableStudents(int StudentCode, string StudentName, string StudentSurname,
            string StudentMiddlename, int number)
        {
            this.StudentCode = StudentCode;
            this.StudentName = StudentSurname + " " + StudentName[0] + " " + StudentMiddlename[0];
            this.marks = GenerateEmptyList(number);
            
        }

        private List<Mark> GenerateEmptyList(int j)
        {
            List<Mark> tmp = new List<Mark>();
            for (int i = 1; i<=j; i++)
            {
                tmp.Add(new Mark(" ", 0, InformationOfUser.id));
            }
            return tmp;
        }

        private int CalculateAVG(List<Mark> MarksList)
        {
            List<int> result = new List<int>();
            foreach (Mark mark in MarksList)
            {
                if (mark.MarkText.Replace(" ", "") != "N" && mark.MarkText != null
                        && mark.MarkText != " ")
                    result.Add(Convert.ToInt32(mark.MarkText));
            }
            if (result != null)
                return (int)result.Average();
            return 0;
        }
    }
}
