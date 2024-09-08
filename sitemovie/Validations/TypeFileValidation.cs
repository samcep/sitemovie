using System.ComponentModel.DataAnnotations;

namespace sitemovie.Validations
{
    public class TypeFileValidation : ValidationAttribute
    {
        private readonly string[] _typesValid;


        public TypeFileValidation(TypeFile TypeFile)
        {
            if(TypeFile == TypeFile.Image)
            {
                _typesValid = new string[] { "image/jpeg" , "image/png" , "image/gif" };
            }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile file = value as IFormFile;
            if (file == null)
            {
                return ValidationResult.Success;
            }

            if (!_typesValid.Contains(file.ContentType))
            {
                return new ValidationResult("The file type is not allowed. please ensure the file is in JPG, PNG or JPEG format");
            }

            return ValidationResult.Success;
        }
    }
}
