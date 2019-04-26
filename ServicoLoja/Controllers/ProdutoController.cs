using AutoMapper;
using Domain.Entity;
using Domain.Interfaces.Repository;
using Microsoft.AspNet.Identity;
using ServicoLoja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicoLoja.Controllers
{
    [Authorize]
    [RoutePrefix("api/Produto")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Todos")]
        [HttpGet]
        public IHttpActionResult Todos()
        {
            IList<Produto> produtos = null;
            IList<ProdutoDto> produtosDto = null;

            produtos = _produtoRepository.GetAll().ToList();
            produtosDto = Mapper.Map<IList<Produto>, IList<ProdutoDto>>(produtos);

            if (produtosDto != null && produtosDto.Count == 0)
            {
                return NotFound();
            }

            return Ok(produtosDto);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("PorId/{id}")]
        [HttpGet]
        public IHttpActionResult PorId(int id)
        {
            var produto = _produtoRepository.GetById(id);
            ProdutoDto produtoDto = null;

            if (produto == null)
            {
                return NotFound();
            }

            produtoDto = Mapper.Map<Produto, ProdutoDto>(produto);
            return Ok(produtoDto);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Gravar")]
        [HttpPost]
        public void Gravar(ProdutoDto produtoDto)
        {
            Produto produto = Mapper.Map<ProdutoDto, Produto>(produtoDto);

            if (produto != null && produto.ProdutoId > 0)
            {
                _produtoRepository.Update(produto);
            }
            else
            {
                _produtoRepository.Add(produto);
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Excluir/{id}")]
        [HttpPost]
        public void Excluir(int id)
        {
            Produto produto = _produtoRepository.GetById(id);

            if (produto != null)
            {
                _produtoRepository.Remove(produto);
            }
        }

        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
