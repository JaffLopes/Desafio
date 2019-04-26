namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.Context;
    using Domain.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<ServicoLojaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ServicoLojaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Categorias.AddOrUpdate(
                new Categoria { CategoriaId = 1, Nome = "Eletrônicos" },
                new Categoria { CategoriaId = 2, Nome = "Alimentos" },
                new Categoria { CategoriaId = 3, Nome = "Limpeza" }
            );

            context.Fornecedores.AddOrUpdate(
                new Fornecedor { FornecedorId = 1, Nome = "Fornecedor A", Cnpj = "11111111111111", Email = "fornecedora@teste.com.br", Telefone = 999999999 },
                new Fornecedor { FornecedorId = 2, Nome = "Fornecedor B", Cnpj = "22222222222222", Email = "fornecedorb@teste.com.br", Telefone = 888888888 },
                new Fornecedor { FornecedorId = 3, Nome = "Fornecedor C", Cnpj = "33333333333333", Email = "fornecedorc@teste.com.br", Telefone = 999999999 }
            );

            //context.Produtos.AddOrUpdate(
            //    new Produto { ProdutoId = 1, Nome = "Copo de Iogurte", Descricao = "Copo de Iogurte de frutas", DataFabricacao = new DateTime(2019, 4, 20), DataValidade = new DateTime(2019, 5, 10), Preco = 4m, CategoriaId = 2, FornecedorId = 1 },
            //    new Produto { ProdutoId = 2, Nome = "Sabão Líquido", Descricao = "Sabão Líquido 500ml", DataFabricacao = new DateTime(2018, 11, 15), DataValidade = new DateTime(2020, 11, 15), Preco = 5.5m, CategoriaId = 3, FornecedorId = 2 },
            //    new Produto { ProdutoId = 3, Nome = "Notebook 15", Descricao = "Notebook 15 com Windows", DataFabricacao = new DateTime(2018, 6, 10), DataValidade = DateTime.MinValue, Preco = 3000m, CategoriaId = 1, FornecedorId = 1 }
            //);

            context.SaveChanges();
        }
    }
}
