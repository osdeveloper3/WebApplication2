//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class user_table
    {
        public int user_id { get; set; }

        [Required]
        public string user_name { get; set; }

        [Required]
        [StringLength(16,ErrorMessage = "Password must 3 character and less than 16 character", MinimumLength = 3)]
        public string password { get; set; }
    }
}