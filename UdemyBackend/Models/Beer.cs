using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyBackend.Models
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BrandId { get; set; }

        // Para no tener problema de migración con los decimal, se hace la siguiente configuración
        // donde se especifíca una longitud de 18 y de los cuales 2 serán para los decimales
        [Column(TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }

        // Relación entre tablas
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }
    }
}
