//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uppgift4Interaktiva.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TvProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Stop { get; set; }
        public string Channel { get; set; }
        public string Info { get; set; }
        public Nullable<int> ChannelId { get; set; }






        public override string ToString()
        {
            return String.Format("Name: {0} Info: {1}.", Name, Info);
        }
    }
}
