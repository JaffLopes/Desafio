﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicoLoja.Dto
{
    public class FornecedorDto
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Cnpj { get; set; }
    }
}