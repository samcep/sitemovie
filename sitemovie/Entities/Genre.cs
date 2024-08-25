using System.ComponentModel.DataAnnotations;

namespace sitemovie.Entities
{
    public class Genre
    {

        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 80)]
        public string Name { get; set; }
    }
}
