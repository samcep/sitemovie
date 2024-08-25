using System.ComponentModel.DataAnnotations;

namespace sitemovie.DTO
{
    public class GenreCreateDto
    {

        [Required]
        [StringLength(maximumLength: 80)]
        public string Name { get; set; }
    }
}
