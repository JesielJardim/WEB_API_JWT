using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProduct.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationProduct.Controllers
{
    [Authorize(Policy = "UsuarioAPI")]
    public class ProdutosController : Controller
    {
        [HttpGet]
        [Route("api/ListarProdutos")]
        public IActionResult ListarProdutos()
        {

            var lista = new List<ModelProduct>();

            for (int i = 1; i <= 10; i++)
            {
                lista.Add(new ModelProduct { Id = i, NameProduct = "Nome produto - " + i.ToString() });
            }

            return Ok(lista);
        }
    }
}
