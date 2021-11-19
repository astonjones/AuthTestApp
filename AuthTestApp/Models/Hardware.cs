using System;
using System.Collections.Generic;

#nullable disable

namespace AuthTestApp.Models
{
    public partial class Hardware
    {
        public string SN { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model_Number { get; set; }
        public string Location { get; set; }
        public float MAC_Address { get; set; }
        public string In_Use { get; set; }
        public string Status { get; set; }
    }
}
