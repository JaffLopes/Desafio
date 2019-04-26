using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(x => x.ProdutoId);

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(x => x.DataValidade)
                .IsRequired();

            Property(x => x.DataFabricacao)
                .IsRequired();

            Property(x => x.Preco)
                .IsRequired();

            HasRequired(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CategoriaId);

            HasRequired(x => x.Fornecedor)
                .WithMany()
                .HasForeignKey(x => x.FornecedorId);
        }
    }
}
