using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AuthTestApp.Models
{
    public partial class Ticket
    {  
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public float PhoneNumber { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        public string Status { get; set; }
        public int Urgency { get; set; }
    }
}
