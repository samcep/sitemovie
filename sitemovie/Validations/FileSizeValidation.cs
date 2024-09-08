using System.ComponentModel.DataAnnotations;

namespace sitemovie.Validations
{
    public class FileSizeValidation : ValidationAttribute
    {

        private readonly int _fileMaxFileSizeInByte;
        public FileSizeValidation(int fileMaxFileSizeInByte) 
        {
            _fileMaxFileSizeInByte = fileMaxFileSizeInByte;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
           if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile imageFile = value as IFormFile;
            if (imageFile == null)
            {
                return ValidationResult.Success;
            }

            if(imageFile.Length > (_fileMaxFileSizeInByte * 1024 * 1024)) 
            {
                return new ValidationResult($"The file size exceeds  the maximum allowed size of {_fileMaxFileSizeInByte}MB ");
            }

            return ValidationResult.Success;

        }   
    }
}
