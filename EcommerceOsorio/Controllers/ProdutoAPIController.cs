using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceOsorio.Controllers
{
    [RoutePrefix("api/Produto")]
    public class ProdutoAPIController : ApiController
    {
        [Route("Produtos")]
        public List<Produto> GetProdutos()
        {
            return ProdutoDAO.RetornarProdutos();
        }

        //GET: api/Produto/ProdutosPorCategoria/3
        [Route("ProdutosPorCategoria/{categoriaId}")]
        public List<Produto> GetProdutosCategoria(int categoriaId)
        {
            return ProdutoDAO.BuscarProdutoPorCategoria(categoriaId);
        }

        //GET: api/Produto/ProdutoPorId/5
        [Route("ProdutoPorId/{produtoId}")]
        public dynamic GetProdutoPorId(int produtoId)
        {
            List<Categoria> categorias = CategoriaDAO.RetornarCategoria();
            Produto produto = ProdutoDAO.BuscarProdutoPorId(produtoId);
            if (produto != null)
            {
                dynamic produtoDinamico = new
                {
                    Nome = produto.NomeProduto,
                    Preco = produto.PrecoProduto.ToString("C2"),
                    Categoria = categorias,
                    DataEnvio = DateTime.Now.ToString("yyyy/MM/dd")
                };
                return new { Produto = produtoDinamico }; 
            }
            return NotFound();
        }
    }
}
