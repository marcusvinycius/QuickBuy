using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
                //if(condicao == false)
                //{
                //    return BadRequest("")
                //}
            } catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost] //Atributo
        /*
         * [FromBody] -> Do corpo da requisicao, transforme a informacao que veio por JSON, no objeto Produto
         */
        public IActionResult Post([FromBody]Produto produto) 
        {
            try
            {
                _produtoRepositorio.Adicionar(produto);
                return Created("controller", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
