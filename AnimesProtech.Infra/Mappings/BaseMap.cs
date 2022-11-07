using AnimesProtech.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimesProtech.Infra.Mappings
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.Ativo)
                .HasColumnName("ativo")
                .IsRequired();

            builder.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();
            builder.Property(x => x.DataInativacao).HasColumnName("data_inativacao");
            builder.Property(x => x.AlteradoEm).HasColumnName("alterado_em");
        }
    }
}
