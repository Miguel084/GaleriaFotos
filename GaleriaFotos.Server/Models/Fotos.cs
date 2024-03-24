using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaleriaFotos.Server.Models
{
    public class Fotos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotosId { get; set; }

        [Required]
        public string? Imagem { get; set; }

        [Required]
        public required string Nome { get; set; }

    }
}
