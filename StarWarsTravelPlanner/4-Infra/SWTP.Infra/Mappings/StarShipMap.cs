using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWTP.Domain.Entities;

namespace SWTP.Infra.Mappings
{
    public class StarShipMap : IEntityTypeConfiguration<StarShip>
    {
        public void Configure(EntityTypeBuilder<StarShip> builder)
        {
        //    builder.ToTable("StarShip", "dbo");
        //    builder.HasKey(x => x.IdIngrediente);

        //    builder.Property(x => x.IdIngrediente).HasColumnName(@"IdIngrediente").HasColumnType("bigint").ValueGeneratedNever().IsRequired();
        //    builder.Property(x => x.Valor).HasColumnName(@"Valor").HasColumnType("decimal").IsRequired().HasPrecision(18, 2);
        //    builder.Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar(100)").IsRequired().IsUnicode(false);
        }
    }
}
