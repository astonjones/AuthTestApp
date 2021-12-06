using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthTestApp.Models
{
    public partial class Hardware
    {
        [Key]
        [Required]
        public string SN { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Model_Number { get; set; }
        [Required]
        public string Location { get; set; }
        public string MAC_Address { get; set; }
        [Required]
        public Char In_Use { get; set; }
        [Required]
        public string Status { get; set; }
        public string? Warranty { get; set; }
        public DateTime? Warranty_Exp_Date { get; set; }
        public string? Vendor { get; set; }
        public string? Comments { get; set; }
    }
}
