using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly AppDbContext _context; //injeção de dependência do contexto do banco de dados, para acessar os dados do banco

        public CategoriasController(AppDbContext context) //pedindo injecao do contexto que sera informada pelo container di nativo
        {
            _context = context;
        }


        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProduto() 
        {


            return _context.Categorias.Include(p=> p.Produtos).ToList();
        }
   

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {

            try
            {
                throw new DataMisalignedException("Teste de exceção personalizada");

                //return _context.Categorias.ToList();

            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a solicitação.");
            }

        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria is null)
            {
                return NotFound("Nenhuma categoria encontrada pelo id");
            }
            return Ok(categoria);

        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtRoute("ObterCategoria", new { id = categoria.CategoriaId }, categoria);

        }

        [HttpPut("{id:int}")]
        public ActionResult<Categoria> Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Id da categoria não corresponde ao id da URL");
            }
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }   

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria is null)
            {
                return NotFound("Nenhuma categoria encontrada pelo id");
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
