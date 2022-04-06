namespace oebb.efi.DataAccess.Entities
{
    public class StationEntity
    {        
        public long Id { get; set; }
        public string Shortcut { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
    }
}
