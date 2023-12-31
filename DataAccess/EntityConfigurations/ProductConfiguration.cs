﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(b => b.Id);


            builder.Property(b => b.Id).HasColumnName("ProductID").IsRequired();
            builder.Property(b => b.CategoryId).HasColumnName("CategoryID");
            builder.Property(b => b.ProductName).HasColumnName("ProductName").IsRequired();
            builder.Property(b => b.UnitPrice).HasColumnName("UnitPrice").IsRequired();
            builder.Property(b => b.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();
            builder.Property(b => b.QuantityPerUnit).HasColumnName("QuantityPerUnit");

            builder.HasIndex(indexExpression: b => b.ProductName, name: "UK_Products_ProductName").IsUnique();

            builder.HasOne(b => b.Category);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //  categorydeki tüm dataya default olarak bu where koşulunu uygula. where deletedDate is null. Data silinmemişse getir.
        }
    }
}
