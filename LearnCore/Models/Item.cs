using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnCore.Models
{
    [Table("Items",Schema ="HR")]
    public class Item
    {
        [Key]
        [Display(Name ="Item Id")]
        public int? Id { get; set; }
        
        [Display(Name="name of item")]
        [Column(TypeName ="varchar(250)")]
        public string Name { get; set; }

        [Display(Name ="Price")]
        [Column(TypeName ="Decimal(12,4)")]
        [Range(100,50000,ErrorMessage ="The price must be in range from 100 to 50000")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Created Time")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? imagePath { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
