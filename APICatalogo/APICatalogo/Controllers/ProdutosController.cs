using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase //controller serve para criar endpoints de API, endpoints são as rotas que a API vai expor
    {
        private readonly AppDbContext _context; //injeção de dependência do contexto do banco de dados, para acessar os dados do banco

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        //primeiro mettodo action
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if(produtos.Count == 0)
            {
                return NotFound("Nenhum produto encontrado");
            }
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto is null)
            {
                return NotFound("Nenhum produto encontrado pelo id");
            }
            return Ok(produto);
        }

    }
}
