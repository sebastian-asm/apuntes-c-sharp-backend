using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyBackend.Models
{
    public class Brand
    {
        // Transformar el id en una primary key autoicrementable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
