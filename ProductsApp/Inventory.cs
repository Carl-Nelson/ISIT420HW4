//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductsApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int ItemID { get; set; }
        public int cdID { get; set; }
        public int ItemQuantity { get; set; }
    
        public virtual CDTable CDTable { get; set; }
    }
}
