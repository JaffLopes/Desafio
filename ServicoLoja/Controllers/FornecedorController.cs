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
    [RoutePrefix("api/Fornecedor")]
    public class FornecedorController : ApiController
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Todos")]
        [HttpGet]
        public IHttpActionResult Todos()
        {
            IList<Fornecedor> fornecedores = null;
            IList<FornecedorDto> fornecedoresDto = null;

            fornecedores = _fornecedorRepository.GetAll().ToList();
            fornecedoresDto = Mapper.Map<IList<Fornecedor>, IList<FornecedorDto>>(fornecedores);

            if (fornecedoresDto.Count == 0)
            {
                return NotFound();
            }

            return Ok(fornecedoresDto);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("PorId/{id}")]
        [HttpGet]
        public IHttpActionResult PorId(int id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            FornecedorDto fornecedorDto = null;

            if (fornecedor == null)
            {
                return NotFound();
            }

            fornecedorDto = Mapper.Map<Fornecedor, FornecedorDto>(fornecedor);
            return Ok(fornecedorDto);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Gravar")]
        [HttpPost]
        public void Gravar(FornecedorDto fornecedorDto)
        {
            Fornecedor fornecedor = Mapper.Map<FornecedorDto, Fornecedor>(fornecedorDto);

            if (fornecedor != null && fornecedor.FornecedorId > 0)
            {
                _fornecedorRepository.Update(fornecedor);
            }
            else
            {
                _fornecedorRepository.Add(fornecedor);
            }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Excluir/{id}")]
        [HttpPost]
        public void Excluir(int id)
        {
            Fornecedor fornecedor = _fornecedorRepository.GetById(id);

            if (fornecedor != null)
            {
                _fornecedorRepository.Remove(fornecedor);
            }
        }

        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
