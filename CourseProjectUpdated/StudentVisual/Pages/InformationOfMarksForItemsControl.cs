using CourseProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectUpdated.StudentVisual.Pages
{
    internal class InformationOfMarksForItemsControl
    {
        public string ItemName { get; set; }
        public List<Mark> Marks { get; set; }
        public int AVG { get; set; }
        public InformationOfMarksForItemsControl(string ItemName,  List<Mark> Marks)
        {
            this.ItemName = ItemName;
            this.Marks = Marks;
            AVG = CalculateAVG(Marks);
        }
        public InformationOfMarksForItemsControl(string ItemName, int number)
        {
            this.ItemName = ItemName;
            this.Marks = GenerateEmptyList(number);
        }

        private List<Mark> GenerateEmptyList(int j)
        {
            List<Mark> tmp = new List<Mark>();
            for (int i = 1; i <= j; i++)
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

            return (int)result.Average();
        }
    }
    class Mark
    {
        public int StudentCode { get; set; }
        public int MarkId { get; set; }
        public string MarkText { get; set;}

        public Mark(string MarkText, int markId, int studentCode)
        {
            this.MarkText = MarkText;
            MarkId = markId;
            StudentCode = studentCode;
        }
    }

}
