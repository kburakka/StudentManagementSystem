//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLOGIN2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class message
    {
        public int messageID { get; set; }
        public string text { get; set; }
        public int from { get; set; }
        public Nullable<int> studentID { get; set; }
        public string about { get; set; }
        public Nullable<System.DateTime> addedtime { get; set; }
        public string fromname { get; set; }
        public string toname { get; set; }
    
        public virtual student student { get; set; }
    }
}
