using Core.Entity;
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

        [HttpPost("cadastrar-em-massa")]
        public IActionResult CadastroEmMassa()
        {
            try
            {
                var livros = new List<Livro>()
                {
                    new Livro(){ Editora = "Teste 1", Nome = "Teste 1"},
                    new Livro(){ Editora = "Teste 2", Nome = "Teste 2"},
                    new Livro(){ Editora = "Teste 3", Nome = "Teste 3"},
                    new Livro(){ Editora = "Teste 4", Nome = "Teste 4"},
                    new Livro(){ Editora = "Teste 5", Nome = "Teste 5"},
                    new Livro(){ Editora = "Teste 6", Nome = "Teste 6"},
                    new Livro(){ Editora = "Teste 7", Nome = "Teste 7"},
                    new Livro(){ Editora = "Teste 8", Nome = "Teste 8"},
                    new Livro(){ Editora = "Teste 9", Nome = "Teste 9"},
                    new Livro(){ Editora = "Teste 10", Nome = "Teste 10"},
                    new Livro(){ Editora = "Teste 11", Nome = "Teste 11"},
                    new Livro(){ Editora = "Teste 12", Nome = "Teste 12"},
                    new Livro(){ Editora = "Teste 13", Nome = "Teste 13"},
                    new Livro(){ Editora = "Teste 14", Nome = "Teste 14"}
                };

                _livroRepository.AddList(livros);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
