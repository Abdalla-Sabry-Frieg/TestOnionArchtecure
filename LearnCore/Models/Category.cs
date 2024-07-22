using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnCore.Models
{
    public class Category
    {
        [Key]
        public int? Id { get; set; }
        public String? Name { get; set; }

        public ICollection<Item>? Items { get; set; }

        [NotMapped]

        public IFormFile clientFile { get; set; }

        public byte[]? DbImage { get; set; }

        [NotMapped]
        public string? ImageSrc
        {
            
          get
            {
                if(DbImage != null)
                {
                    string base64string = Convert.ToBase64String(DbImage,0,DbImage.Length);
                    return "data:image/jpg;base64," + base64string; 
                }
                else
                {
                    return string.Empty;
                }
            }
        
        }
    }
}
