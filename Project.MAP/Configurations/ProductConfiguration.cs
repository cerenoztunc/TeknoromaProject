using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configurations
{
    public class ProductConfiguration:BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UnitPrice).HasColumnType("money");
            builder.Property(x => x.QuantityPerUnit).HasMaxLength(20);
            builder.Property(x => x.Discontinued).IsRequired();
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasOne(p => p.Supplier).WithMany(s => s.Products).HasForeignKey(p => p.SupplierId);
            //builder.HasMany<OrderDetail>().WithOne().HasForeignKey(x => x.ProductId).IsRequired();

            builder.ToTable("Products");

        }
    }
}
