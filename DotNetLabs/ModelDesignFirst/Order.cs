//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelDesignFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int TotalValue { get; set; }
        public System.DateTime Date { get; set; }
        public int CustomerId { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
