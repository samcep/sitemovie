using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace sitemovie.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPhoto { get; set; }
    }
}
