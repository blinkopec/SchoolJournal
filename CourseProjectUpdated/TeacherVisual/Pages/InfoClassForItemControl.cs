using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectUpdated.TeacherVisual.Pages
{
    internal class InfoClassForItemControl
    {
        public int ClassCode { get; set; }
        public string ClassName { get; set; }   
        public InfoClassForItemControl(int ClassCode, string ClassName) 
        {
            this.ClassCode = ClassCode;
            this.ClassName = ClassName;
        }
    }
}
