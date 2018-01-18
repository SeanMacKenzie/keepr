namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Shares { get; set; }
        public int Views { get; set; }
        public string Public { get; set; }
        public int UserId { get; set; }

    }
}