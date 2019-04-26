using AutoMapper;
using Domain.Entity;
using ServicoLoja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicoLoja.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Categoria, CategoriaDto>();
                cfg.CreateMap<CategoriaDto, Categoria>();

                cfg.CreateMap<Fornecedor, FornecedorDto>();
                cfg.CreateMap<FornecedorDto, Fornecedor>();

                cfg.CreateMap<Produto, ProdutoDto>();
                cfg.CreateMap<ProdutoDto, Produto>();
            });
        }
    }
}