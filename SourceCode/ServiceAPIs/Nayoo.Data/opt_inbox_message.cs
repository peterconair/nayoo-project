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
    
    public partial class opt_inbox_message
    {
        public int messageId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public System.DateTime sentDate { get; set; }
        public string sentFrom { get; set; }
        public string sentTo { get; set; }
        public System.DateTime readDate { get; set; }
        public int orgId { get; set; }
        public string orgUniqueId { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public string messageUniqueId { get; set; }
    }
}
