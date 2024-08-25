using System.ComponentModel.DataAnnotations;

namespace sitemovie.DTO
{
    public class ActorDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPhoto { get; set; }
    }
}
