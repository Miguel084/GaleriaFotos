using GaleriaFotos.Server.Data;
using GaleriaFotos.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GaleriaFotos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FotosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Fotos>> Post([FromForm] FotoModel fotoModel)
        {
            if (fotoModel == null || fotoModel.Imagem == null)
            {
                return BadRequest("Invalid data");
            }

            Fotos fotos = new Fotos()
            {
                Nome = fotoModel.Nome
            };

            if (fotoModel.Imagem.Length > 0)
            {
                var fileName = Path.GetRandomFileName();
                var filePath = Path.Combine("Imagens", fileName); 

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fotoModel.Imagem.CopyToAsync(stream);
                }

                fotos.Imagem = fileName; 
            }

            _context.fotos.Add(fotos);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = fotos.FotosId }, fotos);
        }

    }

    public class FotoModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public IFormFile Imagem { get; set; }
    }
}
