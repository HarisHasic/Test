namespace oebb.efi.DataAccess.Models
{
    public class Station
    {        
        public long Id { get; set; }
        public string Shortcut { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
    }
}
