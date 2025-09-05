namespace Properties.Service.Domain.Entities
{
    public partial class Property
    {
        public Guid PropertyId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; private set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
