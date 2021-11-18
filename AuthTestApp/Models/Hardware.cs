using System.ComponentModel.DataAnnotations;

namespace AuthTestApp.Models
{
    public class Hardware
    {
        public int Id {  get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

        public string Model_Number { get; set; }

        public string Location { get; set; }

        [Key]
        public string SN { get; set; }

        public float MAC_Address { get; set; }

        public string In_Use { get; set; }

        public string Status { get; set; }
    }
}
