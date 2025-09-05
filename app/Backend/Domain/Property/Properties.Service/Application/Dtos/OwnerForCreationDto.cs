namespace Properties.Service.Application.Dtos
{
    public class OwnerForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
    }
}
