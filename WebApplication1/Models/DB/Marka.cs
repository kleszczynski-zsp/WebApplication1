namespace WebApplication1.Models.DB
{
    public class Marka
    {
        public int MarkaId { get; set; }

        public int NazwaMarki { get; set; }
        public bool IsDisabled { get; set; }

        public List<Model>? ModelList { get;set; }
    }
}
