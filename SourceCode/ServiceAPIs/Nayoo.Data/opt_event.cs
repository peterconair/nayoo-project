//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nayoo.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class opt_event
    {
        public int eventId { get; set; }
        public int eventTypeId { get; set; }
        public string eventTypeUniqueId { get; set; }
        public string houseNo { get; set; }
        public string houseUniqueId { get; set; }
        public int orgId { get; set; }
        public string orgUniqueId { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public string eventUniqueId { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
