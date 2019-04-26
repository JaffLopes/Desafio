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
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Todos")]
        [HttpGet]
        public IHttpActionResult Todos()
        {
            IList<Categoria> categorias = null;
            IList<CategoriaDto> categoriasDto = null;

            categorias = _categoriaRepository.GetAll().ToList();
            categoriasDto = Mapper.Map<IList<Categoria>, IList<CategoriaDto>>(categorias);

            if (categoriasDto.Count == 0)
            {
                return NotFound();
            }

            return Ok(categoriasDto);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("PorId/{id}")]
        [HttpGet]
        public IHttpActionResult PorId(int id)
        {
            var categoria = _categoriaRepository.GetById(id);
            CategoriaDto categoriaDto = null;

            if (categoria == null)
            {
                return NotFound();
            }

            categoriaDto = Mapper.Map<Categoria, CategoriaDto>(categoria);
            return Ok(categoriaDto);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Gravar/{categoriaDto}")]
        [System.Web.Http.HttpPost]
        public void Gravar(CategoriaDto categoriaDto)
        {
            Categoria categoria = Mapper.Map<CategoriaDto, Categoria>(categoriaDto);

            if (categoria != null && categoria.CategoriaId > 0)
            {
                _categoriaRepository.Update(categoria);
            }
            else
            {
                _categoriaRepository.Add(categoria);
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Excluir/{id}")]
        [HttpPost]
        public void Excluir(int id)
        {
            Categoria categoria = _categoriaRepository.GetById(id);

            if (categoria != null)
            {
                _categoriaRepository.Remove(categoria);
            }
        }

        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
