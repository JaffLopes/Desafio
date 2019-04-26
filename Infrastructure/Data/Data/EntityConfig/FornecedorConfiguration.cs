using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfig
{
    public class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            HasKey(x => x.FornecedorId);

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(250);

            Property(x => x.Telefone)
                .IsRequired();

            Property(x => x.Cnpj)
                .IsRequired()
                .HasMaxLength(14);
        }
    }
}
