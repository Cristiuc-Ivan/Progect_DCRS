//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLogic.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class IP
    {
        public int IP_Id { get; set; }
        public string Ip_Address { get; set; }
        public Nullable<int> IP_wrongAtt { get; set; }
        public Nullable<System.DateTime> IP_CreatedAt { get; set; }
        public Nullable<bool> IP_Banned { get; set; }
    }
}