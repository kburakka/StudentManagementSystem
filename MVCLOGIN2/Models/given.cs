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
    
    public partial class given
    {
        public int givenID { get; set; }
        public int instructorID { get; set; }
        public int courseID { get; set; }
    
        public virtual cours cours { get; set; }
        public virtual instructor instructor { get; set; }
    }
}