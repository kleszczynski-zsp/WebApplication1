using Microsoft.Build.Framework;

namespace WebApplication1.Models.DB
{
    public class Model
    {
        public int ModelId { get; set; }
        public string NazwaModelu { get; set; }

        [Required]
        public Marka Marka { get; set; }
    }
}
