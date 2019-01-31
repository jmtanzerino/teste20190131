using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfigurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(c => c.DtNasc)
                .IsRequired();
            //.HasColumnType("datetime2");

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
