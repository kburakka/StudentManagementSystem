using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLOGIN2.Models;

namespace MVCLOGIN2.Models
{
    public class CourseTakesModel
    {
        public List<cours> Courses { get; set; }
        public List<take> TakeLessons { get; set; }
        public List<student> Student { get; set; }
        public List<Cart> Cart { get; set; }
        public List<take> AllTakenLessons { get; set; }

    }
}