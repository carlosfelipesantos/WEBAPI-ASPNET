using APICatalogo.Context;
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


    }
}
