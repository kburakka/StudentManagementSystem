using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLOGIN2.Models
{
    public class NewMessage
    {
        public List<student> student { get; set; }
        public List<message> messages { get; set; }
    }
}