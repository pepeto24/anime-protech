using AnimesProtech.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Infra.Mappings
{
    public class AnimeMap : BaseMap<Anime>
    {
        public override void Configure(EntityTypeBuilder<Anime> builder)
        {
            base.Configure(builder);
            builder.ToTable("anime");


            builder.Property(x => x.Diretor)
                .HasColumnName("diretor");

            builder.Property(x => x.Resumo)
                .HasColumnName("resumo");

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.HasIndex(x => x.Nome)
                    .IsUnique();
        }
    }
}
