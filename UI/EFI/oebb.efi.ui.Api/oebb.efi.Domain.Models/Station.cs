namespace oebb.efi.Domain.Models
{
    public class Station
    {
        public long Id { get; set; }       
        public string Description { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
    }
}