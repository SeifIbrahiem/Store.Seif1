﻿using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.ProductBrand)
                    .WithMany()
                    .HasForeignKey(p => p.BrandId);

            builder.HasOne(P => P.ProductType)
                   .WithMany()
                   .HasForeignKey(P => P.TypeId);

            builder.Property(P => P.Price)
                .HasColumnType("decimal(18,2)");
                   


        }
    }
}
