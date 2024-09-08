using System.ComponentModel.DataAnnotations;

namespace sitemovie.DTO
{
    public class ActorPatchDto
    {
        [Required]
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    
    }
}
