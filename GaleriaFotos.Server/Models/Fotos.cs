using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GaleriaFotos.Server.Models
{
    public class Fotos 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotosId { get; set; }

        [Required]
        public required string Imagem { get; set; }

        [Required]
        public required string Nome { get; set; }

    }
}
