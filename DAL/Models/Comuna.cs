namespace DAL.Models
{
    public class Comuna
    {
        public int IdComuna { get; set; }
        public int IdRegion { get; set; }
        public string? Nombre { get; set; }
        public string? InformacionAdicional { get; set; }
    }
}
