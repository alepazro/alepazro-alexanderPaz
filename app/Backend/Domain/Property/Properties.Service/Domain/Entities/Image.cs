
namespace Properties.Service.Domain.Entities
{
    public partial class Image
    {
        public Guid ImageId { get; set; }
        public Guid PropertyId { get; set; }
        public string File { get; set; }
        public string Enable { get; set; }
        public virtual Property Property { get; set; }
    }
}
