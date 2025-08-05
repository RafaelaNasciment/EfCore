using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
            => _livroRepository = livroRepository;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var livros = _livroRepository.GetAll();
                return Ok(livros);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var livros = _livroRepository.GetById(id);
                return Ok(livros);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] LivroInput livroInput)
        {
            try
            {
                var livro = new Core.Entity.Livro()
                {
                    Editora = livroInput.Editora,
                    Nome = livroInput.Nome
                };
                if (livro == null)
                {
                    return BadRequest("Livro cannot be null.");
                }
                _livroRepository.Add(livro);

                return CreatedAtAction(nameof(GetAll), new { id = livro.Id }, livro);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while creating the livro: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] LivroUpdateInput livroInput)
        {
            try
            {
                var livro = _livroRepository.GetById(livroInput.Id);
                if (livro == null)
                {
                    return BadRequest("Livro cannot be null.");
                }
                _livroRepository.Update(livro);

                return CreatedAtAction(nameof(GetAll), new { id = livro.Id }, livro);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while creating the livro: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _livroRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while deleting the livro: {ex.Message}");
            }
        }
    }
}
