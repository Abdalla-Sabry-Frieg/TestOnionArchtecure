using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearnCore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String phone { get; set; }
        public String Email { get; set; }

        [DisplayName("Published year")]
        public String yearPublished { get; set; }
        public decimal salary { get; set; }

    }
}
