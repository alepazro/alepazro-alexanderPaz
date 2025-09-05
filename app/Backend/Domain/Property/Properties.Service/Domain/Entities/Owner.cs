namespace Properties.Service.Domain.Entities
{
    public partial class Owner
    {
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
