namespace Properties.Service.Application.Dtos
{
    public class OwnerDto
    {
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }

    }
}
