using sitemovie.Validations;
using System.ComponentModel.DataAnnotations;

namespace sitemovie.DTO
{
    public class ActorCreateDto
    {
        [FileSizeValidation(fileMaxFileSizeInByte: 4)]
        [TypeFileValidation(TypeFile: TypeFile.Image)]
        public IFormFile Photo { get; set; }
        
    }
}
