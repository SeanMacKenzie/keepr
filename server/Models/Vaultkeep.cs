namespace keepr.Models
{
    public class Vaultkeep
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Shares { get; set; }
        public int Views { get; set; } 
    }
}