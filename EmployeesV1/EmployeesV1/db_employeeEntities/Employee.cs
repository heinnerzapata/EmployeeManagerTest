//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace db_employeeEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int EmploId { get; set; }
        public string EmploPicture { get; set; }
        public string EmploName { get; set; }
        public Nullable<int> EmploPosition { get; set; }
        public Nullable<int> EmploProj { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual Project Project { get; set; }
    }
}
