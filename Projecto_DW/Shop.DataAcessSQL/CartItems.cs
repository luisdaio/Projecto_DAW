//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shop.DataAcessSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartItems
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public System.DateTimeOffset CreatedAt { get; set; }
    
        public virtual Carts Carts { get; set; }
    }
}
